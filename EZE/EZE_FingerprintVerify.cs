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
using DPFP.Capture;
using DPFP.Verification;
using DPFP.Processing;
using MetroFramework.Forms;
using MetroFramework;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Ongoing
{
    public partial class EZE_FingerprintVerify : MetroForm, DPFP.Capture.EventHandler
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
        private Verification Verificator;
        private Capture Capturee;
        private EZEEntities context;
        private Template Template;
        public EZE_FingerprintVerify()
        {
            context = new EZEEntities();
            InitializeComponent();
            Picture.Select();
            Size = new Size(368, 270);
        }
        private void Verify(Template template)
        {
            Template = template;
            ShowDialog();
        }
        private void Init()
        {
            try
            {
                Capturee = new Capture(); // Create a capture operation.
                if (null != Capturee)
                    Capturee.EventHandler = this; // Subscribe for capturing events.
                else
                {
                    SetPrompt("Could not start capture operation.");
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Could not start capture operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Verificator = new Verification(); // Create a fingerprint template
            UpdateStatus(0);
        }
        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(string.Format("False accept rate (FAR) = {0}", FAR));
        }
        private void Process(Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
            // Process the sample ans create a feature set for the enrollment process.
            FeatureSet features = ExtractFeatures(Sample, DataPurpose.Verification);
            // Check quality of the sample and start verification if it is good
            // TODO: move to a separate task   
            Verification.Result result = new Verification.Result();
            Template template = new Template();
            Stream stream;

            // Compare the feature set with our template

            foreach (var emp in context.FingerprintsTables)
            {
                if (features != null)
                {
                    stream = new MemoryStream(emp.Fingerprint);
                    template = new Template(stream);
                    Verificator.Verify(features, template, ref result);
                    UpdateStatus(result.FARAchieved);                    
                    if (result.Verified)
                    {
                        MakeReport("FINGERPRINT IDENTIFIED : " + emp.Student_Number);
                        SetPrompt("This fingerprint is already registered.");
                        Invoke(new MethodInvoker(delegate ()
                        {
                            Fprintred.Visible = true;
                            Fprintred.Text = "\n\n" + "This fingerprint is already registered." + "\n" + "IDENTIFIED : " + emp.Student_Number;
                            Fprintgreen.Visible = false;
                            Fprintblack.Visible = false;
                            btnBack.Visible = true;
                        }));
                        break;
                    }                   
                }
            }
            if (!result.Verified)
            {
                MakeReport("NO MATCH FOUND...");
                SetPrompt("This fingerprint is still available for registration.");
                Invoke(new MethodInvoker(delegate ()
                {
                    Fprintgreen.Visible = true;
                    Fprintred.Visible = false;
                    Fprintblack.Visible = false;
                    btnBack.Visible = false;
                }));
            }
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
        private void CaptureForm2_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            Picture.Select();
            Fprintblack.Visible = true;
            Fprintred.Visible = false;
            Fprintgreen.Visible = false;
        }
        private void CaptureForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        #endregion

        #region EventHandler Members
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The fingerprint has been captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
        }
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint was removed from the reader.");
        }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The reader was touched.");
        }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader has been connected.");
        }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader has been disconnected.");
        }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
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
            SampleConversion Convertor = new SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null; // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap); // TODO: return bitmap as a result
            return bitmap;
        }
        private FeatureSet ExtractFeatures(Sample Sample, DataPurpose Purpose)
        {
            FeatureExtraction Extractor = new FeatureExtraction();  // Create a feature extractor
            CaptureFeedback feedback = CaptureFeedback.None;
            FeatureSet features = new FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); // TODO: return features as a result?
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
            Picture.Image = new Bitmap(bitmap, Picture.Size);  // Fit the image into the picture box			
        }        
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();           
        }
    }
}
