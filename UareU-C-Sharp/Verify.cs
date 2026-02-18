using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DPUruNet;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Verify : Form
    {
        private Reader reader;
        private DataResult<Fmd> enrolledFmd = null;
        private Fmd fmd = null;
        private List<Fmd> preEnrollmentFmd;
        private List<ClienteHuella> enrolledFmdList = new List<ClienteHuella>();
        public MENU _sender;
        private string cadenaConexion;


        public Verify()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
        }

        private async void Verify_Load(object sender, EventArgs e)
        {
            pbLoading.Visible = true;
            pbLoading.Refresh();
            VerifyMessageLbl.Text = "Cargando base de datos de huellas...";
            VerifyMessageLbl.Refresh();
            try
            {
                InitializeReaders();
                Constants.ResultCode result = reader.GetStatus();

                if (result == Constants.ResultCode.DP_SUCCESS)
                {
                    if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_READY)
                    {
                        reader.On_Captured += new Reader.CaptureCallback(reader_On_CapturedAsync);
                        VerificationCapture();
                        //VerifyMessageLbl.Text = "Fingerprint Reader found and status is ready";
                        VerifyMessageLbl.Text = "Lector listo. Procesando datos...";
                    }
                }
                else
                {
                    VerifyMessageLbl.Text = "Could not perform capture. Reader result code :" + result.ToString();
                }

                await Task.Run(() =>
                {
                    //System.Threading.Thread.Sleep(9000);
                    CargarHuellasDesdeBD();
                });
                VerifyMessageLbl.Text = "Carga completada. Lector listo.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // 4. Ocultar el cargando pase lo que pase
                pbLoading.Visible = false;
            }
        }

        private void CargarHuellasDesdeBD()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "EXEC Clientes_activos;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            enrolledFmdList.Clear();
                            while (lector.Read())
                            {
                                string fmdXml = lector["HuellaXml"].ToString();
                                string nombreCliente = lector["Nombre"].ToString();
                                DateTime fechaVenc = Convert.ToDateTime(lector["Vigencia"]);
                                if (!string.IsNullOrEmpty(fmdXml))
                                {
                                    try
                                    {
                                        // 2. Deserializamos directamente usando el método del SDK
                                        Fmd fmdCargada = Fmd.DeserializeXml(fmdXml);

                                        // 3. Agregamos a la lista de comparación
                                        //enrolledFmdList.Add(fmdCargada);
                                        enrolledFmdList.Add(new ClienteHuella
                                        {
                                            Nombre = nombreCliente,
                                            Huella = fmdCargada,
                                            FechaVencimiento = fechaVenc
                                        });
                                    }
                                    catch (Exception ex)
                                    {
                                        // Por si algún XML está corrupto, que no se detenga la carga
                                        Console.WriteLine("Error deserializando una huella: " + ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }
        private void InitializeReaders()
        {
            ReaderCollection rc = ReaderCollection.GetReaders();
            if (rc.Count == 0)
            {
                //UpdateEnrollMessage("Fingerprint Reader not found. Please check if reader is plugged in and try again", null);
                VerifyMessageLbl.Text = "Fingerprint Reader not found. Please check if reader is plugged in and try again";
            }
            else
            {
                reader = rc[0];
                Constants.ResultCode readersResult = reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
            }
        }

        private void VerificationCapture()
        {
            //resultion 1 is for 1000 dpi, 0 is for 500 dpi
            Constants.ResultCode captureResult = reader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, reader.Capabilities.Resolutions[0]);
            UpdateVerifyMessage("Swipe finger to start verification", null, "");
            if (captureResult != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("CaptureResult: " + captureResult.ToString());
            }
        }

        private async void reader_On_CapturedAsync(CaptureResult capResult)
        {

            if (this.IsDisposed || this.Disposing) return;
            if (capResult.Quality == Constants.CaptureQuality.DP_QUALITY_GOOD)
            {
                DataResult<Fmd> fmdResult = FeatureExtraction.CreateFmdFromFid(capResult.Data, Constants.Formats.Fmd.DP_VERIFICATION);
                //If successfully extracted fmd then assign fmd
                if (fmdResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                {
                    fmd = fmdResult.Data;
                    // Get view bytes to create bitmap.
                    foreach (Fid.Fiv fiv in capResult.Data.Views)
                    {
                        UpdateVerifyMessage("Fingerprint Captured", CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height),"");
                        break;
                    }

                }
                else
                {
                    UpdateVerifyMessage("Could not successfully create a verification FMD", null, "");
                }

                if (fmd != null)
                {
                    bool boolValidacion = false;
                    List<Fmd> fmdsParaComparar = enrolledFmdList.Select(c => c.Huella).ToList();
                    IdentifyResult vResult = Comparison.Identify(fmd, 0, fmdsParaComparar, 21474, 5);
                    if (vResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                    {
                        if (vResult.Indexes.Length > 0)
                        {
                            boolValidacion = true;
                            int indiceEncontrado = vResult.Indexes[0][0];
                            var cliente = enrolledFmdList[indiceEncontrado];

                            string nombreEncontrado = cliente.Nombre;
                            DateTime vencimiento = cliente.FechaVencimiento;
                            if (!this.IsDisposed)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    lblCliente.Text = "Cliente: " + nombreEncontrado;
                                    lblVencimiento.Text = "Vigente hasta el: " + vencimiento.ToString("dd/MM/yyyy");
                                    VerifyMessageLbl.Text = "¡Acceso Autorizado!";
                                }));
                            }
                            //if (!this.IsDisposed) VerificationCapture();
                        }
                        else
                        {
                            boolValidacion = false;
                        }
                    }
                    else
                    {
                        UpdateVerifyMessage("Error occured on verfication.", null, "");
                    }

                    if (boolValidacion)
                    {
                        try
                        {
                            string rutaImagen = @"C:\conf_gympack\check2.jpeg";
                            Image img2 = Image.FromFile(rutaImagen);
                            pictureBox1.Image = img2;
                            //Thread.Sleep(2000);
                            await Task.Delay(2000);
                            pictureBox1.Image = null;
                            UpdateVerifyMessage("", null, "");
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            MessageBox.Show("No se encontró el archivo de imagen.");
                        }
                        catch (System.NotSupportedException)
                        {
                            MessageBox.Show("Formato de ruta no válido.");
                        }

                    }
                    else
                    {
                        try
                        {
                            string rutaImagen = @"C:\conf_gympack\fail2.jpeg";
                            Image img2 = Image.FromFile(rutaImagen);
                            pictureBox1.Image = img2;
                            //Thread.Sleep(2000);
                            await Task.Delay(2000);
                            pictureBox1.Image = null;
                            UpdateVerifyMessage("", null, "");
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            MessageBox.Show("No se encontró el archivo de imagen.");
                        }
                        catch (System.NotSupportedException)
                        {
                            MessageBox.Show("Formato de ruta no válido.");
                        }
                    }
                }
                else
                {
                    UpdateVerifyMessage("Please swipe finger again", null, "");
                }
            }
            else
            {
                UpdateVerifyMessage("Please swipe finger again", null, "");
            }
        }

        private DataResult<Fmd> ExtractFmdfromByte(byte[] fmdByte)
        {
            preEnrollmentFmd = new List<Fmd>();
            byte[] imageByte = fmdByte;
            int i = 0;
            //height, width and resolution must be same as those of image in ExtractByteArray
            DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, 400, 500, reader.Capabilities.Resolutions[0], Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            // DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, 504, 648, 1000, Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            if (fmd.ResultCode == Constants.ResultCode.DP_SUCCESS)
            {
                while (i < 4)
                {
                    preEnrollmentFmd.Add(fmd.Data);
                    i++;
                }
                enrolledFmd = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.DP_REGISTRATION, preEnrollmentFmd);
                if (enrolledFmd.ResultCode != Constants.ResultCode.DP_SUCCESS)
                { MessageBox.Show("fmd.ResultCode = " + fmd.ResultCode); }
            }
            else
                MessageBox.Show("fmd.ResultCode = " + fmd.ResultCode);

            return enrolledFmd;
        }

        public static Bitmap CreateBitmap(Byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];
            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt32() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);
            return bmp;
        }

        private async Task CheckReaderStatusAsync()
        {
            //If reader is busy, sleep
            if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY)
            {
                //Thread.Sleep(50);
                await Task.Delay(50);
            }
            else if ((reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                reader.Calibrate();
            }
            else if ((reader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + reader.Status.Status);
            }
        }



        delegate void UpdateVerifyMessageCallback(string text1, Bitmap image, string text2);
        private void UpdateVerifyMessage(string text, Bitmap image, string text2)
        {
            if (this.IsDisposed || this.Disposing) return;
            if (this.VerifyMessageLbl.InvokeRequired)
            {
                try
                {
                    UpdateVerifyMessageCallback callBack = new UpdateVerifyMessageCallback(UpdateVerifyMessage);
                    this.Invoke(callBack, new object[] { text, image, text2 });
                }
                catch (ObjectDisposedException) { /* Ignorar si ocurrió justo al cerrar */ }
            }
            else
            {
                VerifyMessageLbl.Text = text;
                lblCliente.Text = text2;
                lblVencimiento.Text = "";
                if (image != null)
                {
                    verifyPicBox.Image = image;
                    verifyPicBox.Refresh();
                }
                else 
                {
                    verifyPicBox.Image = null;
                }

            }

        }


        private void Verify_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (reader != null)
            {
                reader.CancelCapture();
                reader.Dispose();
            }
        }

        private Fmd DeserializarFmdXml(string xmlString)
        {
            try
            {
                // El SDK convierte el string XML directamente al objeto Fmd
                return Fmd.DeserializeXml(xmlString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar XML: " + ex.Message);
                return null;
            }
        }

        private void Verify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)
            {
                // 1. Des-suscribirse del evento primero
                reader.On_Captured -= reader_On_CapturedAsync;

                // 2. Cancelar cualquier captura pendiente
                reader.CancelCapture();

                // 3. Cerrar la conexión con el lector
                reader.Dispose();
                reader = null;
            }
        }
    }
}
