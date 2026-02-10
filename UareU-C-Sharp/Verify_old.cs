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

namespace UareUWindowsMSSQLCSharp
{
    public partial class Verify : Form
    {
        private Reader reader;
        private DataResult<Fmd> enrolledFmd = null;
        private Fmd fmd = null;
        private List<Fmd> preEnrollmentFmd, preEnrollmentFmd1;
        private List<Fmd> enrolledFmdList = new List<Fmd>();
        //public Form_Main _sender;
        public MENU _sender;
        // DataResult<Fmd> fpDataFmd = new DataResult<Fmd>; 
        //private string cadenaConexion = @"Data Source=DESKTOP-KUBF2IC\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";
        private string cadenaConexion;

        public Verify()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);

        }

        private void Verify_Load(object sender, EventArgs e)
        {
            InitializeReaders();

            Constants.ResultCode result = reader.GetStatus();
            //CheckReaderStatus();
            if (result == Constants.ResultCode.DP_SUCCESS)
            {
                if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_READY)
                {
                    reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
                    VerificationCapture();
                    VerifyMessageLbl.Text = "Fingerprint Reader found and status is ready";
                }
            }
            else
            {
                VerifyMessageLbl.Text = "Could not perform capture. Reader result code :" + result.ToString();
            }

           // ComparacionHuellas();


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

        void reader_On_Captured(CaptureResult capResult)
        {


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
                    // Crear la conexión
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        // Abrir la conexión
                        conexion.Open();

                        // Crear el comando SQL
                        //string consulta = "select idCliente,Nombre,Huella from Clientes;";
                        string consulta = "EXEC Clientes_UltimoPago;";
                        bool boolValidacion = false;
                        string nombreCliente = "";
                        string Frecuencia = "";
                        string FechaPago = "";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            // Ejecutar la consulta y obtener el lector de datos
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {

                                    enrolledFmdList.Clear();
                                    string url = lector["Huella"].ToString();

                                    using (Bitmap img = new Bitmap(url))
                                    {
                                        DataResult<Fmd> fmdfromBMP = ExtractFmdfromBmp(img);
                                        enrolledFmdList.Add(fmdfromBMP.Data);
                                    }
                                    //Bitmap img = new Bitmap(url);
                                    //DataResult<Fmd> fmdfromBMP = ExtractFmdfromBmp(img);
                                    //enrolledFmdList.Add(fmdfromBMP.Data);

                                    //Perform indentification of fmd of captured sample against enrolledFmdList
                                    IdentifyResult vResult = Comparison.Identify(fmd, 0, enrolledFmdList, 21474, 5);
                                    //If number of matches returned by IdentificationResult are greater than 0 then user is authorized
                                    if (vResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                                    {
                                        if (vResult.Indexes.Length > 0)
                                        {
                                            boolValidacion = true;
                                            nombreCliente = lector["Nombre"].ToString();
                                            Frecuencia = lector["Frecuencia"].ToString();
                                            FechaPago = lector["Fecha_Pago"].ToString();
                                            break;
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
                                }
                                if (boolValidacion)
                                {
                                    DateTime fechaActual = DateTime.Now;
                                    DateTime fechaPago = DateTime.Parse(FechaPago);
                                    DateTime fechaPagoMasFrecuancia;

                                    switch (Frecuencia)
                                    {
                                        case "DIARIO":
                                            fechaPagoMasFrecuancia = fechaPago.AddDays(1);
                                            break;
                                        case "SEMANAL":
                                            fechaPagoMasFrecuancia = fechaPago.AddDays(7);
                                            break;
                                        case "MENSUAL":
                                            fechaPagoMasFrecuancia = fechaPago.AddMonths(1);
                                            break;
                                        case "SEMESTRAL":
                                            fechaPagoMasFrecuancia = fechaPago.AddMonths(6);
                                            break;
                                        default:
                                            fechaPagoMasFrecuancia = fechaPago;
                                            break;
                                    }

                                    if (fechaActual < fechaPagoMasFrecuancia)
                                    {
                                        TimeSpan diferencia = fechaPagoMasFrecuancia - fechaActual;
                                        int dias = diferencia.Days+1;

                                        UpdateVerifyMessage("User Authorized", null, "BIENVENIDO \n "+ nombreCliente+" \n TE QUEDAN "+ dias + " DIAS");
                                        try
                                        {
                                            string rutaImagen = @"C:\conf_gympack\check2.jpeg";
                                            Image img2 = Image.FromFile(rutaImagen);
                                            pictureBox1.Image = img2;
                                            Thread.Sleep(2000);
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
                                        string fechaCorta_fechaPagoMasFrecuancia = fechaPagoMasFrecuancia.ToString("d");
                                        UpdateVerifyMessage("User Unauthorized", null, "MEMBRESIA VENCIÓ \n EL DIA:"+ fechaCorta_fechaPagoMasFrecuancia);
                                        try
                                        {
                                            string rutaImagen = @"C:\conf_gympack\fail2.jpeg";
                                            Image img2 = Image.FromFile(rutaImagen);
                                            pictureBox1.Image = img2;
                                            Thread.Sleep(2000);
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
                                    UpdateVerifyMessage("User Unauthorized", null, "FAVOR DE REGISTRARSE");
                                    try
                                    {
                                        string rutaImagen = @"C:\conf_gympack\fail2.jpeg";
                                        Image img2 = Image.FromFile(rutaImagen);
                                        pictureBox1.Image = img2;
                                        Thread.Sleep(2000);
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

        private DataResult<Fmd> ExtractFmdfromBmp(Bitmap img)
        {
            preEnrollmentFmd = new List<Fmd>();
            byte[] imageByte = ExtractByteArray(img);
            int i = 0;
            //height, width and resolution must be same as those of image in ExtractByteArray
            DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, img.Width, img.Height, reader.Capabilities.Resolutions[0], Constants.Formats.Fmd.DP_PRE_REGISTRATION);
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

        private static byte[] ExtractByteArray(Bitmap img)
        {
            byte[] rawData = null;
            byte[] bitData = null;
          //ToDo: CreateFmdFromRaw only works on 8bpp bytearrays. As such if we have an image with 24bpp then average every 3 values in Bitmapdata and assign it to bitdata
            if (img.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                
                //Lock the bitmap's bits
                BitmapData bitmapdata = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);
                //Declare an array to hold the bytes of bitmap
                byte[] imgData = new byte[bitmapdata.Stride * bitmapdata.Height]; //stride=360, height 392

                //Copy bitmapdata into array
                Marshal.Copy(bitmapdata.Scan0, imgData, 0, imgData.Length);//imgData.length =141120

                bitData = new byte[bitmapdata.Width * bitmapdata.Height];//ditmapdata.width =357, height = 392

                for (int y = 0; y < bitmapdata.Height; y++)
                {
                    for (int x = 0; x < bitmapdata.Width; x++)
                    {
                        bitData[bitmapdata.Width * y + x] = imgData[y * bitmapdata.Stride + x];
                    }
                }

                rawData = new byte[bitData.Length];

                for (int i = 0; i < bitData.Length; i++)
                {
                    int avg = (img.Palette.Entries[bitData[i]].R + img.Palette.Entries[bitData[i]].G + img.Palette.Entries[bitData[i]].B) / 3;
                    rawData[i] = (byte)avg;
                }
            }

            else
            {                
               bitData = new byte[img.Width * img.Height];//ditmapdata.width =357, height = 392, bitdata.length=139944
                for (int y = 0; y < img.Height; y++)
                {
                    for (int x = 0; x < img.Width; x ++)
                    {
                        Color pixel = img.GetPixel(x,y);
                        bitData[img.Width * y + x] = (byte)((Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B) )/3);                        
                    }
                }               

            }

            return bitData;
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
            //string path = Path.GetFullPath("../../Images/imageliveDP.bmp");
            //bmp.Save(path);
            return bmp;
        }

        private void CheckReaderStatus()
        {
            //If reader is busy, sleep
            if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY)
            {
                Thread.Sleep(50);
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
            if (this.VerifyMessageLbl.InvokeRequired)
            {
                UpdateVerifyMessageCallback callBack = new UpdateVerifyMessageCallback(UpdateVerifyMessage);
                this.Invoke(callBack, new object[] { text, image, text2 });
            }
            else
            {
                VerifyMessageLbl.Text = text;
                lblCliente.Text = text2;
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

        private void ComparacionHuellas()
        {
            string directorio = @"C:\conf_gympack\huella"; // Reemplaza con la ruta de tu directorio

            // Obtener todos los archivos .bmp en el directorio
            string[] archivosBMP = Directory.GetFiles(directorio, "*.bmp");
            enrolledFmdList.Clear();
            foreach (string archivo in archivosBMP)
            {
                try
                {
                    Bitmap img = new Bitmap(archivo);
                    //Extract Fmd from bmp image saved
                    
                    DataResult<Fmd> fmdfromBMP = ExtractFmdfromBmp(img);
                    enrolledFmdList.Add(fmdfromBMP.Data);
                    //break;
                    //reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
                    //VerificationCapture();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al procesar {archivo}: {ex.Message}");
                }
            }
            reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
            VerificationCapture();
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            //ComparacionHuellas();
            //openFileDialog1.Filter = "Bitmap Files(*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif";
            //openFileDialog1.Title = "Open Image";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = openFileDialog1.FileName;
            //    if (fileName.Length != 0)
            //    {
            //        Bitmap img = new Bitmap(fileName);
            //        //Extract Fmd from bmp image saved
            //        enrolledFmdList.Clear();
            //        DataResult<Fmd> fmdfromBMP = ExtractFmdfromBmp(img);
            //        enrolledFmdList.Add(fmdfromBMP.Data);

            //        reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
            //        VerificationCapture();
            //    }
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (verifyPicBox.Image != null)
            {
                saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
                saveFileDialog1.Title = "Save fingerprint as";
                string filename= (saveFileDialog1.ShowDialog() == DialogResult.Cancel) ? "" : saveFileDialog1.FileName;

                if (filename != "")
                    verifyPicBox.Image.Save(filename, ImageFormat.Bmp);
            }
        }


    }
}
