using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPUruNet;
using System.Threading;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Enroll : Form
    {
        private Reader reader;
        private bool reset = false;
        private int fingerindex;//indexfinger
        private int count;
        private List<Fmd> preEnrollmentFmd;
        private DataResult<Fmd> enrollmentFmd, fmd1, fmd2;
        public Form_Main _sender;
        private string urlHuella = "";
        public Fmd EnrollmentFmdResult { get; private set; }

        public Enroll(string nombrearchivohuella)
        {
            InitializeComponent();
            urlHuella = @"C:\conf_gympack\huella\" + nombrearchivohuella+ ".bmp";
        }
        private void InitializeReaders()
        {
            ReaderCollection rc = ReaderCollection.GetReaders();
            if (rc.Count == 0)
            {
                //UpdateEnrollMessage("Fingerprint Reader not found. Please check if reader is plugged in and try again", null);
                MessageBox.Show("Fingerprint Reader not found. Please check if reader is plugged in and try again");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            else
            {
                reader = rc[0];
                Constants.ResultCode readersResult = reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
            }
        }
       private void Enroll_Load(object sender, EventArgs e)
        {
           /*InitializeReaders();
            try
            {               
                Constants.ResultCode result = reader.GetStatus();
                if (result == Constants.ResultCode.DP_SUCCESS)
                {
                    StartEnrollment(result);
                }
                else
                    MessageBox.Show("Reader status is:" + result);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           */
        }
        private void StartEnrollment(Constants.ResultCode readerResult)
        {
            fingerindex = 0;
            preEnrollmentFmd = new List<Fmd>();           

            CheckReaderStatus();

            if (readerResult == Constants.ResultCode.DP_SUCCESS)
            {
                reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
                EnrollmentCapture();
            }
            else
            {
                messagelbl.Text = "Could not perform capture. Reader result code :" + readerResult.ToString();
            }
        
        }

        private void EnrollmentCapture()
        {
            count =0;
            Constants.ResultCode captureResult = reader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, reader.Capabilities.Resolutions[0]);
            if (captureResult != Constants.ResultCode.DP_SUCCESS)
            { 
             MessageBox.Show("CaptureResult: " + captureResult.ToString());
            }
        }
        private void OnEnrollmentSuccess(Fmd fmd)
        {
            this.EnrollmentFmdResult = fmd; // Guardamos el resultado
            this.DialogResult = DialogResult.OK; // Cerramos con éxito
            //this.Close();
        }

        void reader_On_Captured(CaptureResult capResult)
        {
            if (reader == null) return;
            if (capResult.Quality == Constants.CaptureQuality.DP_QUALITY_GOOD)
            {
                count++;
                DataResult<Fmd> fmdResult = FeatureExtraction.CreateFmdFromFid(capResult.Data, Constants.Formats.Fmd.DP_PRE_REGISTRATION);
                if (fmdResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                {
                    preEnrollmentFmd.Add(fmdResult.Data);
                    DataResult<Fmd> enrollmentFmd = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.DP_REGISTRATION, preEnrollmentFmd);

                    if (enrollmentFmd.ResultCode == Constants.ResultCode.DP_SUCCESS)
                    {
                        // ¡ÉXITO! Ya se completaron las capturas necesarias y se creó la plantilla
                        this.EnrollmentFmdResult = enrollmentFmd.Data;
                        MostrarImagenHuella(capResult, preEnrollmentFmd.Count);
                        UpdateEnrollMessage("CAPTURAS COMPLETADAS.", null,0);
                        OnEnrollmentSuccess(enrollmentFmd.Data);
                    }
                    else if (enrollmentFmd.ResultCode == Constants.ResultCode.DP_ENROLLMENT_NOT_READY)
                    {
                        int faltantes = 4 - preEnrollmentFmd.Count;
                        MostrarImagenHuella(capResult, preEnrollmentFmd.Count);
                        UpdateEnrollMessage($"MUESTRA CAPTURADA. \nFAVOR DE PONER EL DEDO {faltantes} VEZ/VECES MÁS.", null, 0);

                        switch (preEnrollmentFmd.Count)
                        {
                            case 1:
                                this.Invoke(new Action(() => {
                                    pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                                    pictureBox1.Refresh();
                                }));
                                break;
                            case 2:
                                this.Invoke(new Action(() => {
                                    pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                                    pictureBox2.Refresh();
                                }));
                                break;
                            case 3:
                                this.Invoke(new Action(() => {
                                    pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                                    pictureBox3.Refresh();
                                }));
                                break;
                            case 4:
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show("ERROR! DEBE CAPTURAR EL MISMO DEDO.");
                                    this.DialogResult = DialogResult.Cancel;
                                }));
                                return;
                        }
                        
                    }
                }
                else
                {
                    UpdateEnrollMessage("Error al extraer características de la huella.", null,0);
                }
            }
            else
            {
                UpdateEnrollMessage("Mala calidad de captura. Intente de nuevo.", null,0);
            }
        }

        private void MostrarImagenHuella(CaptureResult capResult, int nroHuella)
        {
            foreach (Fid.Fiv fiv in capResult.Data.Views)
            {
                UpdateEnrollMessage(null, HelperFunctions.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height),nroHuella);
                break;
            }
        }

        public void SaveEnrolledFmd(string userName, string xmlFMD1, string xmlFMD2)
        {
            string saveFmdScript = "Insert into Users values ('" + userName + "', '" + xmlFMD1 + "', '" + xmlFMD2 + "' )";
            // Save user and his relative FMD into database
            HelperFunctions.ConnectDBnExecuteScript(saveFmdScript);
        }


        delegate void UpdateEnrollMessageCallback(string text1, Bitmap image, int nrohuella);
        private void UpdateEnrollMessage(string text, Bitmap image, int nrohuella)
        {
            //Aqui tambien 2
            if (this.messagelbl.InvokeRequired)
            {
                UpdateEnrollMessageCallback callBack = new UpdateEnrollMessageCallback(UpdateEnrollMessage);
                this.Invoke(callBack, new object[] { text, image, nrohuella });
            }
            else
            {
                messagelbl.Text = text;
                if (image != null)
                {
                    switch (nrohuella)
                    {
                        case 1:
                            enrollPicBox.Image = image;
                            enrollPicBox.Refresh();
                            break;
                        case 2:
                            pictureBox1.Image = image;
                            pictureBox1.Refresh();
                            break;
                        case 3:
                            pictureBox2.Image = image;
                            pictureBox2.Refresh();
                            break;
                        case 4:
                            pictureBox3.Image = image;
                            pictureBox3.Refresh();
                            break;
                    }
                    
                }
            }

        }

        public void CancelCaptureAndCloseReader()
        {
            if (reader != null)
            {
                reader.CancelCapture();
                reader.Dispose();
            }
        }

        public void CheckReaderStatus()
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

        private void Enroll_Shown(object sender, EventArgs e)
        {
            InitializeReaders();
            if (reader == null)
            {
                return;
            }
            try
            {
                Constants.ResultCode result = reader.GetStatus();
                if (result == Constants.ResultCode.DP_SUCCESS)
                {
                    StartEnrollment(result);
                }
                else
                    MessageBox.Show("Reader status is:" + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Enroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            CancelCaptureAndCloseReader();
        }

        private void sacwebmp_Click(object sender, EventArgs e)
        {
            //if (enrollPicBox.Image != null)
            //{
            //    saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
            //    saveFileDialog1.Title = "Save fingerprint as";
            //    string filename = (saveFileDialog1.ShowDialog() == DialogResult.Cancel) ? "" : saveFileDialog1.FileName;

            //    if (filename != "")
            //        enrollPicBox.Image.Save(filename, ImageFormat.Bmp);
            //}

            if (enrollPicBox.Image != null)
            {
                if (urlHuella != "")
                {
                    enrollPicBox.Image.Save(urlHuella, ImageFormat.Bmp);
                    this.Close();
                }
            }
            
        }
  
      
    }
}
