using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using DPFP;
using DPFP.Capture;
using DPFP.Verification;
using DPFP.Processing;
using System.IO;
using Dapper;
using MetroFramework;
using Transitions;
using System.IO.Ports;
using EZE.ADO.NetModels;
using EZE.Utilities;
using EZE.Repositories;

namespace EZE
{
    public partial class EZE_TransactionBorrow : MetroForm, DPFP.Capture.EventHandler
    {       
        private Verification Verificator;
        private Capture Capturee;
        private EZEEntities context;
        private EZEEntities2 context1;
        private Template Template;
        private string dataOUT;
        private string dataIN;
        private string code;
        private string message;
        private string message1;
        private string verificationCode;
        private string status = "NOT VERIFIED";
        private string verified = "VERIFIED";
        private string comport = "COM4";
        int ID = 0;
        DataTable dt;
        public static string SetTextForBorrower = "";
        public static string SetTextForSNum = "";
        public static string SetTextForProf = "";
        public static string SetTextForCode = "";
        public static string SetTextForEquipment = "";
        public static string SetTextForStatus = "NOT VERIFIED";
        public static EZE_TransactionBorrow _instance;
        // TODO: Implement GSM feature without triggering the error
        //private GSMsms gsmSms;
        //private MessageRepository messageRepository;
        //private BorrowEquipmentsClassRepository borrowRepository;
        //private ProfessorRepository professorRepository;

        public EZE_TransactionBorrow()
        {
            InitializeComponent();
            searchstudnum();
            searchbarcode();
            //Size = new Size(1050, 560);
            _instance = this;
            txtBarcode.Click += TextBoxOnClick;
            txtBarcode1.Click += TextBoxOnClick1;
            txtSearch.Click += TextBoxOnClick2;
            cmbProf_Click();
            cmbProf1_Click();
            cmbProf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProf1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void TransactionBorrow_Load(object sender, EventArgs e)
        {
            txtPersoninCharge.Text = EZE_SAMenu.SetTextforPersoninCharge;
            txtBarcode.Select();
            timer1.Start();
            Init();
            Start();
            context = new EZEEntities();
            context1 = new EZEEntities2();
            FillMetroGrid();


            // TODO: Implement GSM feature without triggering the error
            //string cnUrl = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            //Console.WriteLine(cnUrl);
            //borrowRepository = BorrowEquipmentsClassRepository.getInstance(cnUrl);
            //professorRepository = ProfessorRepository.getInstance();
            //professorRepository = ProfessorRepository.getInstance();
            //messageRepository = MessageRepository.getInstance();
            //gsmSms = GSMsms.getInstance(messageRepository);
            //gsmSms.Connect();
            //gsmSms.Start_Read_Interval();
            //timerGsmPoll.Start();

            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlDataAdapter da = new SqlDataAdapter("Select * from StudentsTable", myConn);
                dt = new DataTable();
                da.Fill(dt);
                metroGrid1.DataSource = dt;
            }
        }

        #region Fingerprint Verification
        private void Verify(Template template)
        {
            Template = template;
            ShowDialog();
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
            if (!IsHandleCreated)
            {
                CreateControl();
            }
            Invoke(new MethodInvoker(delegate
            {
                StatusText.AppendText(message + "\r\n");
            }));
        }

        private void Init()
        {
            try
            {
                Capturee = new Capture(); // Create a capture operation.
                if (null != Capturee)
                {
                    Capturee.EventHandler = this; // Subscribe for capturing events.
                }
                else
                {
                    SetPrompt("Could not start capture operation.");
                }
            }
            catch
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Could not start capture operation.");
                pg.Close();
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
                        MakeReport("FINGERPRINT IDENTIFIED : " + emp.Full_Name);
                        SetPrompt("Fingerprint Identified.");
                        Invoke(new MethodInvoker(delegate ()
                        {
                            txtFName.Text = emp.Full_Name;
                            txtSNum.Text = emp.Student_Number;
                            cmbProf.Enabled = true;
                            cmbProf.Select();
                            txtProfNum.Enabled = true;
                            btnBorrow.Enabled = false;
                            foreach (var e in context1.StudentsTables)
                            {
                                if (e.Student_Number == txtSNum.Text)
                                {
                                    txtStudCon.Text = e.Contact_Number;
                                    txtYaS.Text = e.Year_and_Section;
                                    pictureBox.Image = Image.FromFile(e.Image_Location);
                                }
                            }
                        }));
                        //Stop();
                        break;
                    }
                }
            }
            if (!result.Verified)
            {
                MakeReport("NO MATCH FOUND...");
                SetPrompt("No Match Found.");
                Invoke(new MethodInvoker(delegate ()
                {
                    cmbProf.Enabled = false;
                    txtProfNum.Enabled = false;
                    metroLink1.Visible = true;
                    txtFName.Text = "";
                    txtYaS.Text = "";
                    txtSNum.Text = "";
                    pnlAuto.Enabled = false;
                    cmbProf.SelectedIndex = -1;
                    pictureBox.Select();
                    pictureBox.Image = Properties.Resources.icons8_user_filled_100px_2;
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
        void DPFP.Capture.EventHandler.OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The fingerprint has been captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
        }
        void DPFP.Capture.EventHandler.OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint was removed from the reader.");
        }
        void DPFP.Capture.EventHandler.OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The reader was touched.");
            Invoke(new MethodInvoker(delegate ()
            {
                metroLink1.Visible = false;
                metroLink2.Visible = false;
                metroLink3.Visible = false;
                txtSNum.Text = "";
                txtFName.Text = "";
                txtYaS.Text = "";
                txtEquipment.Text = "";
                txtBarcode.Text = "";
                cmbProf.Text = "";
                txtProfNum.Text = "";
                txtTotalEquipment.Text = "";
                txtTotalBarcode.Text = "";
                txtCodeGen.Text = "";
                cmbProf.SelectedIndex = -1;
                pictureBox.Image = Properties.Resources.icons8_user_filled_100px_2;
            }));
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
            { return features; }
            else
            { return null; }
        }

        private void DrawPicture(Bitmap bitmap)
        {
            Picture.Image = new Bitmap(bitmap, Picture.Size);  // Fit the image into the picture box			
        }
        private void TransactionBorrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
            
        }
        #endregion

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Equipment_Barcode='" + txtBarcode.Text + "'", myConn);
                SqlDataReader dr;
                List<string> bar = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string barcodee = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    barcodee = dr["Equipment_Barcode"].ToString();
                    bar.Add(barcodee);
                }
                if (count == 1 && txtBarcode.Text == barcodee || count == 1 && txtBarcode.Text == barcodee && bar.Contains(txtTotalBarcode.Text) 
                    || count == 1 && txtBarcode.Text != barcodee && !bar.Contains(txtTotalBarcode.Text))
                {
                    Plexiglass pg = new Plexiglass(this);
                    messagebox.showdialog("Duplicate barcode found.");
                    pg.Close();
                    txtBarcode.Select();
                    txtBarcode.Text = "";
                    txtEquipment.Text = "";
                    txtTotalBarcode.Text = "";
                    txtTotalEquipment.Text = "";
                }
                else if (txtBarcode.Text == "")
                {
                    Plexiglass pg = new Plexiglass(this);
                    messagebox.showdialog("Can't add a blank value.");
                    pg.Close();
                    txtBarcode.Select();
                    txtBarcode.Text = "";
                    txtEquipment.Text = "";
                }
                else if (count != 1)
                {
                    try
                    {
                        if (txtTotalEquipment.Text.Split(',').Length == txtTotalBarcode.Text.Split(',').Length)
                        {
                            RandomCode();
                            if (serialPort1.IsOpen)
                            {
                                string totalEquipment = txtTotalEquipment.Text.Substring(0, txtTotalEquipment.Text.Length);
                                dataOUT = "#" + txtProfNum.Text + "001" + txtFName.Text + "002" + totalEquipment + "003" + cmbProf.SelectedItem.ToString() + "004" + code;
                                serialPort1.WriteLine(dataOUT);

                            }
                            string replaceValue = txtTotalEquipment.Text.Replace(Environment.NewLine, ",");
                            string replaceValue1 = txtTotalBarcode.Text.Replace(Environment.NewLine, ",");
                            string[] values = replaceValue.Split(',');
                            string[] values1 = replaceValue1.Split(',');
                            var valuesvalues1 = values.Zip(values1, (v, v1) => new { Values = v, Values1 = v1 });
                            foreach (var vv1 in values.Zip(values1, Tuple.Create))
                            {
                                SaveRecord(vv1.Item1, vv1.Item2);
                            }
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Code sent successfully.");
                            pg.Close();

                            txtPersoninCharge.Text = EZE_SAMenu.SetTextforPersoninCharge;
                            txtBarcode.Select();
                            timer1.Start();
                            Init();
                            Start();
                            context = new EZEEntities();
                            context1 = new EZEEntities2();
                            FillMetroGrid();

                            pnlAuto.Enabled = false;
                            cmbProf.Enabled = false;

                            // TODO: Implement GSM feature without triggering the error
                            //if (gsmSms.isConnected)
                            //{
                            //    string studentName = txtFName.Text;
                            //    string itemsName = replaceValue;
                            //    string tCode = code;
                            //    string message = "Student: " + studentName + "\n" +
                            //        "Equipment(s): " + "\n" +
                            //        itemsName + "\n" +
                            //        "Code: " + tCode;
                            //    gsmSms.Send(txtProfNum.Text, message);
                            //} else
                            //{
                            //    MessageBox.Show("App not connected to GSM Module.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}

                            txtTotalEquipment.Text = "";
                            txtTotalBarcode.Text = "";
                            txtCodeGen.Text = "";
                            txtFName.Text = "";
                            txtYaS.Text = "";
                            txtSNum.Text = "";
                            txtProfNum.Text = "";
                            txtMessage.Text = "";
                            cmbProf.SelectedIndex = -1;
                            pictureBox.Image = Properties.Resources.icons8_user_filled_100px_2;
                        }
                        else
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Total number of equipment/s recorded doesn't match the count of scanned barcode.");
                            pg.Close();
                            txtTotalBarcode.Text = "";
                            txtTotalEquipment.Text = "";
                        }                      
                    }
                    catch (Exception)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Duplicate barcode found.");
                        pg.Close();
                        txtBarcode.Select();
                        txtBarcode.Text = "";
                        txtEquipment.Text = "";
                        txtTotalBarcode.Text = "";
                        txtTotalEquipment.Text = "";
                    }
                }
            }
        }
        public void SaveRecord(string value, string value1)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                param.Add("@Student_Number", txtSNum.Text.Trim());
                param.Add("@Borrower", txtFName.Text.Trim());
                param.Add("@Year_and_Section", txtYaS.Text.Trim());
                param.Add("@Equipment_Borrowed", value.Trim());
                param.Add("@Equipment_Barcode", value1.Trim());
                param.Add("@Time_and_Date_Borrowed", lblTimeandDate.Text.Trim());
                param.Add("@Professor", cmbProf.SelectedItem.ToString().Trim());
                param.Add("@Code", txtCodeGen.Text.Trim());
                param.Add("@Person_in_Charge", txtPersoninCharge.Text.Trim());
                param.Add("@Status", status.Trim());
                param.Add("@Student_Contact_Number", txtStudCon.Text.Trim());
                myConn.Execute("BorrowTableInsert", param, commandType: CommandType.StoredProcedure);
                FillMetroGrid();
                txtBarcode.Select();
                txtBarcode.Text = "";
                txtEquipment.Text = "";
            }
        }
        public void SaveRecord1(string value, string value1)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                param.Add("@Student_Number", txtSNum1.Text.Trim());
                param.Add("@Borrower", txtFName1.Text.Trim());
                param.Add("@Year_and_Section", txtYaS1.Text.Trim());
                param.Add("@Equipment_Borrowed", value.Trim());
                param.Add("@Equipment_Barcode", value1.Trim());
                param.Add("@Time_and_Date_Borrowed", lblTimeandDate1.Text.Trim());
                param.Add("@Professor", cmbProf1.SelectedItem.ToString().Trim());
                param.Add("@Code", txtCodeGen.Text.Trim());
                param.Add("@Person_in_Charge", txtPersoninCharge.Text.Trim());
                param.Add("@Status", verified.Trim());
                param.Add("@Student_Contact_Number", txtStudCon.Text.Trim());
                myConn.Execute("BorrowTableInsert", param, commandType: CommandType.StoredProcedure);
                FillMetroGrid();
                txtBarcode1.Select();
                txtBarcode1.Text = "";
                txtEquipment1.Text = "";
            }
        }
        public static void FillMetroGrid()
        {
            try
            {               
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.borrowEquipmentsClassBindingSource.DataSource = db.Query<BorrowEquipmentsClass>("Select * from BorrowEquipmentsTable", commandType: CommandType.Text);
                    BorrowEquipmentsClass obj = _instance.borrowEquipmentsClassBindingSource.Current as BorrowEquipmentsClass;
                }
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand cmd;
                    string sql = "select count(ID) from BorrowEquipmentsTable";
                    cmd = new SqlCommand(sql, myConn);
                    int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (rows_count.ToString() == "0")
                    {
                        _instance.lblBorrowedItems.Text = "No borrowed item/s.";
                        _instance.lblBorrowedItems1.Text = "No borrowed item/s.";
                    }
                    else
                    {
                        _instance.lblBorrowedItems.Text = "Borrowed Item/s : " + rows_count.ToString();
                        _instance.lblBorrowedItems1.Text = "Borrowed Item/s : " + rows_count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Plexiglass pg = new Plexiglass(_instance);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lblTimeandDate.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
            lblTimeandDate1.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            var t = new Timer();
            t.Interval = 1000; // it will Tick in n seconds
            t.Tick += (s, f) =>
            {
                TextBoxOnClick(sender, e);
                t.Stop();
            };
            t.Start();

            if (txtBarcode.Text == "")
            {
                mlred.Visible = false;
                mlgreen.Visible = false;
                metroLink3.Visible = false;
                txtEquipment.Text = "";
                txtTotalEquipment.Text = "";
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable where Barcode='" + txtBarcode.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string barcodee = string.Empty;
                    string equipment = string.Empty;
                    while (dr.Read())
                    {
                        count = count + 1;
                        equipment = dr["Equipment"].ToString();
                        barcodee = dr["Barcode"].ToString();
                    }
                    if (txtBarcode.Text == barcodee)
                    {
                        txtEquipment.Text = equipment;
                        mlred.Visible = false;
                        mlgreen.Visible = true;
                        metroLink3.Visible = false;
                    }
                    else if (txtBarcode.Text != barcodee && txtTotalEquipment.Text != "")
                    {
                        txtEquipment.Text = "";
                        mlred.Visible = true;
                        mlgreen.Visible = false;
                        metroLink3.Visible = true;
                    }
                    else if (txtBarcode.Text != barcodee && txtTotalEquipment.Text == "")
                    {
                        mlred.Visible = true;
                        mlgreen.Visible = false;
                        metroLink3.Visible = true;
                    }
                }
            }
        }
        #region TextBoxOnClick
        private void TextBoxOnClick(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
            txtBarcode.Select();
        }
        private void TextBoxOnClick1(object sender, EventArgs e)
        {
            txtBarcode1.SelectAll();
            txtBarcode1.Select();
        }
        private void TextBoxOnClick2(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Select();
        }
        #endregion
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbComPort.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.Open();
                progressBar1.Value = 100;
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                lblStatusCom.Text = "ON";
            }
            catch (Exception ex)
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
            }
        }
        void RandomCode()
        {
            var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            code = finalString.ToString();
            txtCodeGen.Text = code;
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            Invoke(new System.EventHandler(ShowData));
        }
        private void ShowData(object sender, EventArgs e)
        {
            txtMessage.Text += dataIN;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }
        private void txtEquipment_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable where Barcode='" + txtBarcode.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string barcodee = string.Empty;
                string equipment = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    equipment = dr["Equipment"].ToString();
                    barcodee = dr["Barcode"].ToString();
                }
                if (txtTotalEquipment.Text == "")
                {
                    txtTotalEquipment.Text = txtEquipment.Text;
                    txtTotalBarcode.Text = txtBarcode.Text;
                }
                else if (txtBarcode.Text == barcodee)
                {
                    if (txtTotalBarcode.Text.Contains(txtBarcode.Text))
                    {
                        txtTotalBarcode.Text = txtTotalBarcode.Text;
                    }
                    else
                    {
                        txtTotalEquipment.Text = txtTotalEquipment.Text + "  " + txtEquipment.Text;
                        txtTotalEquipment.Text = txtTotalEquipment.Text.Replace("  ", ",");
                        txtTotalBarcode.Text = txtTotalBarcode.Text + " " + txtBarcode.Text;
                        txtTotalBarcode.Text = txtTotalBarcode.Text.Replace(" ", ",");
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                btnOpen.Enabled = true;
                lblStatusCom.Text = "OFF";
            }
            //Close();
            Dispose();
        }
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            var t = new Timer();
            t.Interval = 2000; // it will Tick in n seconds
            t.Tick += (s, f) =>
            {
                if (txtMessage.Text.Length > 100)
                {
                    txtMessage.Text = "";
                    txtVerificationCode.Text = "";
                }
                else if (txtMessage.Text.Length == 56)
                {
                    message = txtMessage.Text;
                    verificationCode = message.Substring(49, 5);
                    txtVerificationCode.Text = verificationCode;
                    txtMessage.Text = "";
                }
                else if (txtMessage.Text.Length < 100)
                {
                    if (txtTotalEquipment.Text != "")
                    {
                        txtMessage.Text = "";
                    }
                }
                t.Stop();
            };
            t.Start();
        }
        void cmbProf_Click()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from ProfessorsTable", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = count + 1;
                    string professor = dr.GetString(1);
                    cmbProf.Items.Add(professor);
                }
            }
        }
        private void cmbProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select *from ProfessorsTable where Professor ='" + cmbProf.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    string profnum = dr.GetString(2);
                    txtProfNum.Text = profnum;
                }
            }
        }
        private void txtVerificationCode_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Code = '" + txtVerificationCode.Text + "'", myConn);
                SqlDataReader dr;
                List<string> eq = new List<string>();
                List<string> codd = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string codee = string.Empty;
                string snum = string.Empty;
                string name = string.Empty;
                string prof = string.Empty;
                string equip = string.Empty;
                string stat = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    codee = dr["Code"].ToString();
                    snum = dr["Student_Number"].ToString();
                    name = dr["Borrower"].ToString();
                    prof = dr["Professor"].ToString();
                    stat = dr["Status"].ToString();
                    equip = dr["Equipment_Borrowed"].ToString();
                    eq.Add(equip);
                    codd.Add(codee);
                }
                if (codd.Contains(txtVerificationCode.Text))
                {
                    var t = new Timer();
                    t.Interval = 2000; // it will Tick in n seconds
                    t.Tick += (s, f) =>
                    {
                        if (txtMessage.Text.Length > 100)
                        {
                            txtMessage.Text = "";
                            txtVerificationCode.Text = "";
                        }
                        else if (txtMessage.Text.Length == 56)
                        {
                            message1 = txtMessage.Text;
                            verificationCode = message1.Substring(49, 5);
                            txtVerificationCode.Text = verificationCode;
                            txtMessage.Text = "";
                        }
                        else if (txtMessage.Text.Length < 100)
                        {
                            if (txtTotalEquipment.Text != "")
                            {
                                txtMessage.Text = "";
                            }
                        }
                        t.Stop();
                    };
                    t.Start();

                    var message = string.Join(",", eq);
                    SetTextForBorrower = name;
                    SetTextForProf = prof;
                    SetTextForSNum = snum;
                    SetTextForCode = codee;
                    SetTextForEquipment = message;
                    SetTextForStatus = stat;

                    EZE_TransactionBorrowVerify tbv = new EZE_TransactionBorrowVerify();
                    tbv.Show();
                }
                else if (!codd.Contains(txtVerificationCode.Text))
                {
                    Plexiglass pg = new Plexiglass(this);
                    messagebox.showdialog("Verification code doesn't match in any transaction.");
                    pg.Close();
                }
            }
        }
        private void txtTotalEquipment_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalEquipment.Text != "")
            {
                btnSendCode.Enabled = true;
            }
            else if (txtTotalEquipment.Text == "")
            {
                btnSendCode.Enabled = false;
            }
        }
        private void txtProfNum_TextChanged(object sender, EventArgs e)
        {
            if (txtProfNum.Text != "" && txtSNum.Text != "" && txtYaS.Text != "" && txtFName.Text != "" && pictureBox.Image != null)
            {
                pnlAuto.Enabled = true;
                txtBarcode.Select();
            }
        }

        //manual verification pag wala reply yung prof
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (metroGrid.Rows.Count < 1)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("No data available.");
                pg.Close();
            }
            else if (metroGrid.CurrentRow.Cells[5].Value.ToString() == "VERIFIED")
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("This transaction is already verified.");
                pg.Close();
            }
            else
            {
                txtStatus.Text = "VERIFIED";
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    BorrowEquipmentsClass obj = borrowEquipmentsClassBindingSource.Current as BorrowEquipmentsClass;
                    if (obj != null)
                    {
                        db.Execute("BorrowTableUpdate", new
                        { ID = obj.ID, Status = verified }, commandType: CommandType.StoredProcedure);
                        FillMetroGrid();
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Verified successfully.");
                        pg.Close();
                    }
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("Student_Number LIKE '%{0}%'", txtSearch.Text);
            metroGrid1.DataSource = DV;

            if (txtSearch.Text == "")
            {
                pictureBox1.Image = Properties.Resources.icons8_user_filled_100px_2;
                txtFName1.Text = "";
                txtYaS1.Text = "";
                txtSNum1.Text = "";
                cmbProf1.Enabled = false;
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from StudentsTable where Student_Number = '" + txtSearch.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string snum = string.Empty;
                    string yas = string.Empty;
                    string fname = string.Empty;
                    string imageloc = string.Empty;
                    string cnum = string.Empty;
                    try
                    {
                        while (dr.Read())
                        {
                            count = count + 1;
                            snum = dr["Student_Number"].ToString();
                            yas = dr["Year_and_Section"].ToString();
                            fname = dr["Full_Name"].ToString();
                            cnum = dr["Contact_Number"].ToString();
                        }
                        if (txtSearch.Text == snum)
                        {
                            txtFName1.Text = fname;
                            txtYaS1.Text = yas;
                            txtSNum1.Text = snum;
                            pictureBox1.Image = Image.FromFile(metroGrid1.CurrentRow.Cells[10].Value.ToString());
                            cmbProf1.Enabled = true;
                            txtStudCon.Text = cnum;
                        }
                        else if (txtSearch.Text != snum)
                        {
                            txtFName1.Text = "";
                            txtYaS1.Text = "";
                            txtSNum1.Text = "";
                            pictureBox1.Image = Properties.Resources.icons8_user_filled_100px_2;
                            cmbProf1.Enabled = false;
                            cmbProf1.SelectedIndex = -1;
                            pnlManual.Enabled = false;
                        }
                    }
                    catch (Exception)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Image file path doesn't exist.");
                        pg.Close();
                    }
                }
            }
        }
        void searchstudnum()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd = new SqlCommand("Select *from StudentsTable", myConn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string SNum = Convert.ToString(dr["Student_Number"]);
                    coll.Add(SNum);
                }
                txtSearch.AutoCompleteCustomSource = coll;
            }
        }
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            btnSwitch.Visible = false;
            btnSwitch2.Visible = true;
            btnSwitch1.Visible = true;
            btnSwitch3.Visible = false;
            Control ctrlOnScreen, ctrlOffScreen;
            if (panel2.Left == 0) //nakatagong panel
            {
                panel2.Visible = false;
                ctrlOnScreen = panel2;
                ctrlOffScreen = panel1;
                Start();
            }
            else
            {
                panel2.Visible = true;
                pnlAuto.Enabled = false;
                cmbProf.Enabled = false;
                txtSearch.Select();
                txtBarcode.Text = "";
                txtTotalEquipment.Text = "";
                txtTotalBarcode.Text = "";
                txtCodeGen.Text = "";
                txtFName.Text = "";
                txtYaS.Text = "";
                txtSNum.Text = "";
                txtProfNum.Text = "";
                txtMessage.Text = "";
                metroLink3.Visible = false;
                metroLink1.Visible = false;
                mlgreen.Visible = false;
                mlred.Visible = false;
                txtSearch.Select();
                cmbProf.SelectedIndex = -1;
                pictureBox.Image = Properties.Resources.icons8_user_filled_100px_2;

                ctrlOnScreen = panel1;
                ctrlOffScreen = panel2;
                Stop();
            }
            ctrlOnScreen.SendToBack();
            ctrlOffScreen.BringToFront();
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(ctrlOnScreen, "Left", 0 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", 0);
            t.run();         
        }

        private void btnSwitch1_Click(object sender, EventArgs e)
        {
            btnSwitch1.Visible = false;
            btnSwitch3.Visible = true;
            btnSwitch.Visible = true;
            btnSwitch2.Visible = false;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(panel2, "Left", +1 * panel2.Width); //+1
            t.run();
            var tt = new Timer();
            tt.Interval = 300; // it will Tick in n seconds
            tt.Tick += (s, f) =>
            {
                panel2.Visible = false;
                txtSearch.Text = "";
                txtFName1.Text = "";
                txtYaS1.Text = "";
                txtSNum1.Text = "";
                cmbProf1.SelectedIndex = -1;
                txtBarcode1.Text = "";
                txtTotalBarcode1.Text = "";
                pictureBox1.Image = Properties.Resources.icons8_user_filled_100px_2;
                Start();
                tt.Stop();
            };
            tt.Start();
        }
        void cmbProf1_Click()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from ProfessorsTable", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = count + 1;
                    string professor = dr.GetString(1);
                    cmbProf1.Items.Add(professor);
                }
            }
        }
        private void cmbProf1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select *from ProfessorsTable where Professor ='" + cmbProf1.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    string profnum = dr.GetString(2);
                    txtProfNum.Text = profnum;
                }
                pnlManual.Enabled = true;
                txtBarcode1.Select();
            }        
        }
        private void txtBarcode1_TextChanged(object sender, EventArgs e)
        {           
            if (txtBarcode1.Text == "")
            {
                mlred1.Visible = false;
                mlgreen1.Visible = false;
                metroLink31.Visible = false;
                txtEquipment1.Text = "";
                txtTotalEquipment1.Text = "";
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable where Barcode='" + txtBarcode1.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string barcodee = string.Empty;
                    string equipment = string.Empty;
                    while (dr.Read())
                    {
                        count = count + 1;
                        equipment = dr["Equipment"].ToString();
                        barcodee = dr["Barcode"].ToString();
                    }
                    if (txtBarcode1.Text == barcodee)
                    {
                        txtEquipment1.Text = equipment;
                        mlred1.Visible = false;
                        mlgreen1.Visible = true;
                        metroLink31.Visible = false;
                    }
                    else if (txtBarcode1.Text != barcodee && txtTotalEquipment1.Text != "")
                    {
                        txtEquipment1.Text = "";
                        mlred1.Visible = true;
                        mlgreen1.Visible = false;
                        metroLink31.Visible = true;
                    }
                    else if (txtBarcode1.Text != barcodee && txtTotalEquipment1.Text == "")
                    {
                        mlred1.Visible = true;
                        mlgreen1.Visible = false;
                        metroLink31.Visible = true;
                    }
                }
            }
        }
        void searchbarcode()
        {
            txtBarcode1.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBarcode1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd = new SqlCommand("Select *from EquipmentsTable", myConn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string BCode = Convert.ToString(dr["Barcode"]);
                    coll.Add(BCode);
                }
                txtBarcode1.AutoCompleteCustomSource = coll;
            }
        }
        private void txtTotalEquipment1_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalEquipment1.Text != "")
            {
                btnBorrow.Enabled = true;
            }
            else if (txtTotalEquipment1.Text == "")
            {
                btnBorrow.Enabled = false;
            }
        }
        private void txtEquipment1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable where Barcode='" + txtBarcode1.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string barcodee = string.Empty;
                string equipment = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    equipment = dr["Equipment"].ToString();
                    barcodee = dr["Barcode"].ToString();
                }
                if (txtTotalEquipment1.Text == "")
                {
                    txtTotalEquipment1.Text = txtEquipment1.Text;
                    txtTotalBarcode1.Text = txtBarcode1.Text;
                }
                else if (txtBarcode1.Text == barcodee)
                {
                    if (txtTotalBarcode1.Text.Contains(txtBarcode1.Text))
                    {
                        txtTotalBarcode1.Text = txtTotalBarcode1.Text;
                    }
                    else
                    {
                        txtTotalEquipment1.Text = txtTotalEquipment1.Text + "  " + txtEquipment1.Text;
                        txtTotalEquipment1.Text = txtTotalEquipment1.Text.Replace("  ", ",");
                        txtTotalBarcode1.Text = txtTotalBarcode1.Text + " " + txtBarcode1.Text;
                        txtTotalBarcode1.Text = txtTotalBarcode1.Text.Replace(" ", ",");
                    }
                }
            }
        }       
        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Equipment_Barcode='" + txtBarcode1.Text + "'", myConn);
                SqlDataReader dr;
                List<string> bar = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string barcodee = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    barcodee = dr["Equipment_Barcode"].ToString();
                    bar.Add(barcodee);
                }
                if (count == 1 && txtBarcode1.Text == barcodee || count == 1 && txtBarcode1.Text == barcodee && bar.Contains(txtTotalBarcode1.Text)
                    || count ==1 && txtBarcode1.Text != barcodee && !bar.Contains(txtTotalBarcode1.Text))
                {
                    Plexiglass pg = new Plexiglass(this);
                    messagebox.showdialog("Duplicate barcode found.");
                    pg.Close();
                    txtBarcode1.Select();
                    txtBarcode1.Text = "";
                    txtEquipment1.Text = "";
                    txtTotalBarcode1.Text = "";
                    txtTotalEquipment1.Text = "";
                }
                else if (txtBarcode1.Text == "")
                {
                    Plexiglass pg = new Plexiglass(this);
                    messagebox.showdialog("Can't add a blank value.");
                    pg.Close();
                    txtBarcode1.Select();
                    txtBarcode1.Text = "";
                    txtEquipment1.Text = "";
                }
                else if (count != 1)
                {
                    try
                    {
                        if (txtTotalEquipment1.Text.Split(',').Length == txtTotalBarcode1.Text.Split(',').Length)
                        {                           
                            string replaceValue = txtTotalEquipment1.Text.Replace(Environment.NewLine, ",");
                            string replaceValue1 = txtTotalBarcode1.Text.Replace(Environment.NewLine, ",");
                            string[] values = replaceValue.Split(',');
                            string[] values1 = replaceValue1.Split(',');
                            var valuesvalues1 = values.Zip(values1, (v, v1) => new { Values = v, Values1 = v1 });
                            foreach (var vv1 in values.Zip(values1, Tuple.Create))
                            {
                                SaveRecord1(vv1.Item1, vv1.Item2);
                            }
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Transaction successful.");
                            pg.Close();

                            txtPersoninCharge.Text = EZE_SAMenu.SetTextforPersoninCharge;
                            txtBarcode1.Select();
                            timer1.Start();                            
                            context = new EZEEntities();
                            context1 = new EZEEntities2();
                            FillMetroGrid();

                            cmbProf1.SelectedIndex = -1;
                            txtSearch.Text = "";
                            txtSearch.Select();
                            pnlManual.Enabled = false;
                            cmbProf1.Enabled = false;
                            txtTotalEquipment1.Text = "";
                            txtTotalBarcode1.Text = "";
                            txtFName1.Text = "";
                            txtYaS1.Text = "";
                            txtSNum1.Text = "";
                            txtProfNum.Text = "";

                            pictureBox1.Image = Properties.Resources.icons8_user_filled_100px_2;
                        }
                        else
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Total number of equipment/s recorded doesn't match the count of scanned barcode.");
                            pg.Close();
                            txtTotalBarcode1.Text = "";
                            txtTotalEquipment1.Text = "";
                        }
                    }
                    catch (Exception)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Duplicate barcode found.");
                        pg.Close();
                        txtBarcode1.Select();
                        txtBarcode1.Text = "";
                        txtEquipment1.Text = "";
                        txtTotalBarcode1.Text = "";
                        txtTotalEquipment1.Text = "";
                    }
                }
            }
        }


        // TODO: Implement GSM feature without triggering the error
        private void timerGsmPoll_Tick(object sender, EventArgs e)
        {
            //List<BorrowEquipmentsClass> borrows = borrowRepository.getBorrowEquipmentsByStatus("NOT VERIFIED");

            //foreach (BorrowEquipmentsClass brw in borrows)
            //{
            //    List<MessagesTable> messages = messageRepository.getMessagesByCode(brw.Code);
            //    if (messages.Count > 0)
            //    {
            //        if (messages[0].Code == brw.Code && messages[0].Sender == professorRepository.getProfessorByName(brw.Professor).Contact_Number)
            //        {
            //            borrowRepository.updateStatusBorrowEquipmentById(brw.ID);
            //        }
            //    }
            //}
            //FillMetroGrid();
        }
    }
}