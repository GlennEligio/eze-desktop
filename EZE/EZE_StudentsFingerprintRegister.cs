 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Error;
using DPFP.Capture;
using DPFP.Processing;
using MetroFramework;
using MetroFramework.Forms;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_StudentsFingerprintRegister : Form, DPFP.Capture.EventHandler
    {      
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }
        private Enrollment Enroller;
        private Capture Capturee;
        private Template Template;
        private EZEEntities context;
        public EZE_StudentsFingerprintRegister()
        {
            InitializeComponent();
            Picture.Select();
            Size = new Size(600, 402);
        }
        private void Init()
        {
            Enroller = new Enrollment(); //Create an enrollment
            UpdateStatus();            
            try
            {
                Capturee= new Capture(); //Create a capture operation
                if (null != Capturee)
                    Capturee.EventHandler = this; //Subscribe for capturing events
                else
                {
                    SetPrompt("Could not start capture operation.");
                }
            }
            catch
            {
                MessageBox.Show(this, "Could not start capture operation.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Process(Sample Sample)
        {
            //Draw fingerprint sample image
            DrawPicture(ConvertSampleToBitmap(Sample));
            //Process the sample and create a feature set for the enrollment purpose
            FeatureSet features = ExtractFeatures(Sample, DataPurpose.Enrollment);
            //Check quality of the sample and add to enroller if it is good
            if (features != null)
            {
                try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features); //Add feature set to template
                }
                catch (SDKException ex)
                {
                    SetPrompt(ex.Message);
                }
                finally
                {
                    UpdateStatus();
                    //Check if template has been created
                    switch (Enroller.TemplateStatus)
                    {
                        case Enrollment.Status.Ready: //Report success and stop capturing
                            OnTemplate(Enroller.Template);
                            Stop();
                            break;
                        case Enrollment.Status.Failed: //Report success and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
            }                      
        }
        private void UpdateStatus()
        {
            //Show number of samples needed
            SetStatus(string.Format("Fingerprint samples needed : {0}", Enroller.FeaturesNeeded));
        }
        private void Start()
        {
            if (null != Capturee)
            {
                try
                {
                    Capturee.StartCapture();
                    SetPrompt("Scan your fingerprint using the reader.");
                }
                catch
                {
                    SetPrompt("Cannot start capture.");
                }
            }
        }
        private void Stop()
        {
            if (null != Capturee)
            {
                try
                {
                    Capturee.StopCapture();
                }
                catch
                {
                    SetPrompt("Cannot finish capture.");
                }
            }
        }

        #region Form Event Handlers
        private void FingerprintRegister_Load(object sender, EventArgs e)
        {
            Init();
            Start(); //Start capture operation
            context = new EZEEntities();
            //Declaration para ma-catch yung value from students to this form
            txtSnum.Text = EZE_StudentsDatabase.SetTextForStudentNumber;
            txtFname.Text = EZE_StudentsDatabase.SetTextForFullName;
            txtYas.Text = EZE_StudentsDatabase.SetTextForYearandSection;
            txtYearlevel.Text = EZE_StudentsDatabase.SetTextForYearLevel;
        }
        private void FingerprintRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        #endregion

        #region EventHandler Members        
        void DPFP.Capture.EventHandler.OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The fingerprint has been captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
        }
        void DPFP.Capture.EventHandler.OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint was removed from the reader.");
            Invoke(new MethodInvoker(delegate
            {
                Picture.Image = Properties.Resources.icons8_fingerprint_scan_filled_96px;
            }));
        }
        void DPFP.Capture.EventHandler.OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The reader was touched.");           
        }
        void DPFP.Capture.EventHandler.OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader has been connected.");
        }
        void DPFP.Capture.EventHandler.OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader has been disconnected.");
        }
        void DPFP.Capture.EventHandler.OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == CaptureFeedback.Good)
            {
                MakeReport("Fingerprint quality is GOOD.");
            }
            else
            {
                MakeReport("Fingerprint quality is BAD.");
            }
        }
        #endregion

        private Bitmap ConvertSampleToBitmap(Sample Sample)
        {
            SampleConversion Convertor = new SampleConversion();  //Create a sample convertor
            Bitmap bitmap = null; //TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap); //TODO: return bitmap as a result
            return bitmap;
        }
        private FeatureSet ExtractFeatures(Sample Sample, DataPurpose Purpose)
        {
            FeatureExtraction Extractor = new FeatureExtraction();  //Create a feature extractor
            CaptureFeedback feedback = CaptureFeedback.None;
            FeatureSet features = new FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); //TODO: return features as a result
            if (feedback == CaptureFeedback.Good)
            {
                return features;
            }
            else
            {
                return null;
            }
        }
        private void SetStatus(string status)
        {
            Invoke(new MethodInvoker(delegate
            {
                StatusLine.Text = status;
            }));
        }
        private void SetPrompt(string prompt)
        {
            Invoke(new MethodInvoker(delegate
            {
                Prompt.Text = prompt;
            }));
        }
        private void MakeReport(string message)
        {
            Invoke(new MethodInvoker(delegate
            {
                StatusText.AppendText(message + "\r\n");
            }));
        }
        private void DrawPicture(Bitmap bitmap)
        {
             Picture.Image = new Bitmap(bitmap, Picture.Size);  //Fit the image into the picture box			
        }
        private void OnTemplate(Template template)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    Template = template;
                    if (Template != null)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("The fingerprint template is ready for saving.");                        
                        btnSave.Enabled = true;
                        pg.Close();
                    }
                    else
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("The fingerprint template is not valid. Please repeat the fingerprint enrollment.");
                        StatusText.Text = "";
                        pg.Close();
                    }
                }));
            }
        }   
        private void btnSave_Click(object sender, EventArgs e)
        {          
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                byte[] streamfingerprint = Template.Bytes;
                FingerprintsTable fprints = new FingerprintsTable()
                {
                    Student_Number = txtSnum.Text = EZE_StudentsDatabase.SetTextForStudentNumber,
                    Full_Name = txtFname.Text = EZE_StudentsDatabase.SetTextForFullName,
                    Year_and_Section = txtYas.Text = EZE_StudentsDatabase.SetTextForYearandSection,
                    Year_Level = txtYearlevel.Text = EZE_StudentsDatabase.SetTextForYearLevel,
                    Fingerprint = streamfingerprint
                };
                context.FingerprintsTables.Add(fprints);
                context.SaveChanges();
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("");
                Cursor.Current = Cursors.Default;
                pg.Close();
                Template = null;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}