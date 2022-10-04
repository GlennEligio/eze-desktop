using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Data.SqlClient;
using System.Configuration;
using MetroFramework.Controls;
using Transitions;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_TransactionReturn : MetroForm, DPFP.Capture.EventHandler
    {
        private Verification Verificator;
        private Capture Capturee;
        private EZEEntities context;
        private EZEEntities2 context1;
        private Template Template;
        DataTable dt;
        int ID = 0;
        public static EZE_TransactionReturn _instance;
        public EZE_TransactionReturn()
        {
            InitializeComponent();
            searchstudnum();
            searchbarcode();
            Size = new Size(1050,560);
            txtBarcode.Click += TextBoxOnClick;
            txtSearch.Click += TextBoxOnClick1;
            txtBarcode1.Click += TextBoxOnClick2;
            _instance = this;
        }
        private void TransactionReturn_Load(object sender, EventArgs e)
        {
            txtBarcode.Select();
            timer1.Start();
            Init();
            Start();
            context = new EZEEntities();
            context1 = new EZEEntities2();
            FillMetroGrid();

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
                            btnReturnAutomatic.Enabled = false;
                            txtBarcode.Focus();
                            foreach (var e in context1.StudentsTables)
                            {
                                if (e.Student_Number == txtSNum.Text)
                                {
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
                    metroLink1.Visible = true;
                    txtFName.Text = "";
                    txtYaS.Text = "";
                    txtSNum.Text = "";
                    txtProf.Text = "";
                    pnlAuto.Enabled = false;
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
                metroLink4.Visible = false;
                metroLink5.Visible = false;
                txtSNum.Text = "";
                txtFName.Text = "";
                txtYaS.Text = "";
                txtProf.Text = "";
                txtEquipment.Text = "";
                txtBarcode.Text = "";
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
            {
                return features;
            }
            else
            {
                return null;
            }
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
        
        public static void FillMetroGrid()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    string sql = "Select * from BorrowEquipmentsTable";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                    da.Fill(ds);
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    _instance.metroGrid.DataSource = ds.Tables[0];
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
                    { _instance.lblUnreturnedItems.Text = "All items are returned."; }
                    else
                    { _instance.lblUnreturnedItems.Text = "Unreturned Item/s : " + rows_count.ToString(); }
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
        private void btnReturnAutomatic_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {                
                if ((string)row.Cells[0].Value == txtSNum.Text && (string)row.Cells[5].Value == txtBarcode.Text)
                {
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand cmd = new SqlCommand("DELETE from BorrowEquipmentsTable WHERE Equipment_Barcode = '"+txtBarcode.Text+"'", myConn);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();
                        FillMetroGrid();
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Transaction successful.");
                        pg.Close();
                    }
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ID", ID);
                        param.Add("@Student_Number", txtSNum.Text.Trim());
                        param.Add("@Borrower", txtFName.Text.Trim());
                        param.Add("@Year_and_Section", txtYaS.Text.Trim());
                        param.Add("@Equipment_Borrowed", txtEquipment.Text.Trim());
                        param.Add("@Equipment_Barcode", txtBarcode.Text.Trim());
                        param.Add("@Time_and_Date_Returned", lblTimeandDate.Text.Trim());
                        param.Add("@Professor", txtProf.Text.Trim());
                        myConn.Execute("ReturnTableInsert", param, commandType: CommandType.StoredProcedure);
                        txtBarcode.Text = "";
                        txtBarcode.Select();
                        txtEquipment.Text = "";
                    }
                }               
            }            
        }
        private void TextBoxOnClick(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
            txtBarcode.Select();
        }
        private void TextBoxOnClick1(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Select();
            txtSearch.Text = "";
            txtBarcode1.Text = "";
            txtEquipment1.Text = "";
            btnReturnManual.Enabled = false;
            pnlManual.Enabled = false;
        }
        private void TextBoxOnClick2(object sender, EventArgs e)
        {
            txtBarcode1.SelectAll();
            txtBarcode1.Select();
        }
        private void txtSNum_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Student_Number='" + txtSNum.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string studentnumber = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    studentnumber = dr["Student_Number"].ToString();
                }
                if (txtSNum.Text != studentnumber)
                {
                    pictureBox.Select();
                    metroLink5.Visible = true;
                    pnlAuto.Enabled = false;
                }
                else
                {
                    metroLink5.Visible = false;
                    pnlAuto.Enabled = true;
                }
            }
        }
        private void txtBarcode2_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode2.Text != txtBarcode.Text)
            {
                txtBarcode.Text = "";
            }
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            var t1 = new Timer();
            t1.Interval = 1000; // it will Tick in n seconds
            t1.Tick += (s, f) =>
            {
                TextBoxOnClick(sender, e);
                t1.Stop();
            };
            t1.Start();

            if (txtBarcode.Text == "")
            {
                mlred.Visible = false;
                mlgreen.Visible = false;
                metroLink3.Visible = false;
                metroLink4.Visible = false;
                txtEquipment.Text = "";
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Equipment_Barcode='" + txtBarcode.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string barcodee = string.Empty;
                    string studentnumber = string.Empty;
                    string equipment = string.Empty;
                    string professor = string.Empty;
                    while (dr.Read())
                    {
                        count = count + 1;
                        barcodee = dr["Equipment_Barcode"].ToString();
                        studentnumber = dr["Student_Number"].ToString();
                        equipment = dr["Equipment_Borrowed"].ToString();
                        professor = dr["Professor"].ToString();
                    }
                    if (txtBarcode.Text == barcodee && txtSNum.Text == studentnumber)
                    {
                        //TextBoxOnClick(sender, e);
                        txtEquipment.Text = equipment;
                        txtProf.Text = professor;
                        mlred.Visible = false;
                        mlgreen.Visible = true;
                        btnReturnAutomatic.Enabled = true;
                        metroLink3.Visible = false;
                        metroLink4.Visible = false;
                        txtBarcode2.Text = txtBarcode.Text;
                    }
                    else if (txtBarcode.Text != barcodee && txtSNum.Text == studentnumber || txtBarcode.Text == barcodee && txtSNum.Text != studentnumber)
                    {
                        //TextBoxOnClick(sender, e);
                        metroLink3.Visible = true;
                        metroLink4.Visible = false;
                        txtEquipment.Text = equipment;
                        mlred.Visible = true;
                        mlgreen.Visible = false;
                        btnReturnAutomatic.Enabled = false;
                        txtBarcode2.Text = txtBarcode.Text;
                    }
                    else if (txtBarcode2.Text != txtBarcode.Text)
                    {
                        metroLink4.Visible = true;
                        txtEquipment.Text = "";
                        mlred.Visible = true;
                        mlgreen.Visible = false;
                        btnReturnAutomatic.Enabled = false;
                        metroLink3.Visible = false;
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void EZE_TransactionReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
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
                    try
                    {
                        while (dr.Read())
                        {
                            count = count + 1;
                            snum = dr["Student_Number"].ToString();
                            yas = dr["Year_and_Section"].ToString();
                            fname = dr["Full_Name"].ToString();
                        }
                        if (txtSearch.Text == snum)
                        {
                            txtFName1.Text = fname;
                            txtYaS1.Text = yas;
                            txtSNum1.Text = snum;
                            pictureBox1.Image = Image.FromFile(metroGrid1.CurrentRow.Cells[10].Value.ToString());
                            // pnlManual.Enabled = true;
                            txtBarcode1.Select();
                        }
                        else if (txtSearch.Text != snum)
                        {
                            txtFName1.Text = "";
                            txtYaS1.Text = "";
                            txtSNum1.Text = "";
                            pictureBox1.Image = Properties.Resources.icons8_user_filled_100px_2;
                            //   pnlManual.Enabled = false;
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
                txtSearch.Select();
                txtBarcode.Text = "";
                txtFName.Text = "";
                txtYaS.Text = "";
                txtSNum.Text = "";
                txtProf.Text = "";
                metroLink3.Visible = false;
                metroLink1.Visible = false;
                mlgreen.Visible = false;
                mlred.Visible = false;
                txtSearch.Select();
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
            pictureBox.Select();
            btnSwitch1.Visible = false;
            btnSwitch3.Visible = true;
            btnSwitch.Visible = true;
            btnSwitch2.Visible = false;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(panel2, "Left", +1 * panel2.Width); //+1
            t.run();
            Start();

            txtSearch.Text = "";
            txtBarcode1.Text = "";
            pnlManual.Enabled = false;
        }
        private void txtBarcode1_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode1.Text == "")
            {
                mlred1.Visible = false;
                mlgreen1.Visible = false;
                metroLink8.Visible = false;
                metroLink9.Visible = false;
                metroLink10.Visible = false;
                txtEquipment1.Text = "";
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    {
                        myConn.Open();
                    }
                    SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Equipment_Barcode='" + txtBarcode1.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string barcodee = string.Empty;
                    string studentnumber = string.Empty;
                    string equipment = string.Empty;
                    string professor = string.Empty;
                    while (dr.Read())
                    {
                        count = count + 1;
                        barcodee = dr["Equipment_Barcode"].ToString();
                        studentnumber = dr["Student_Number"].ToString();
                        equipment = dr["Equipment_Borrowed"].ToString();
                        professor = dr["Professor"].ToString();
                    }
                    if (txtBarcode1.Text == barcodee && txtSNum1.Text == studentnumber)
                    {
                        txtEquipment1.Text = equipment;
                        txtProf.Text = professor;
                        mlred1.Visible = false;
                        mlgreen1.Visible = true;
                        btnReturnManual.Enabled = true;
                        metroLink10.Visible = false;
                        metroLink8.Visible = false;
                        txtBarcode2.Text = txtBarcode1.Text;
                    }
                    else if (txtBarcode1.Text != barcodee && txtSNum1.Text == studentnumber || txtBarcode1.Text == barcodee && txtSNum1.Text != studentnumber)
                    {
                        metroLink10.Visible = true;
                        metroLink8.Visible = false;
                        txtEquipment1.Text = equipment;
                        mlred1.Visible = true;
                        mlgreen1.Visible = false;
                        btnReturnManual.Enabled = false;
                        txtBarcode2.Text = txtBarcode1.Text;
                    }
                    else if (txtBarcode2.Text != txtBarcode1.Text)
                    {
                        metroLink8.Visible = true;
                        txtEquipment1.Text = "";
                        txtProf.Text = "";
                        mlred1.Visible = true;
                        mlgreen1.Visible = false;
                        btnReturnManual.Enabled = false;
                        metroLink10.Visible = false;
                        var t = new Timer();
                        t.Interval = 100; // it will Tick in 2 seconds
                        t.Tick += (s, f) =>
                        {
                            t.Stop();
                        };
                        t.Start();
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
                SqlCommand cmd = new SqlCommand("Select *from BorrowEquipmentsTable", myConn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string BCode = Convert.ToString(dr["Equipment_Barcode"]);
                    coll.Add(BCode);
                }
                txtBarcode1.AutoCompleteCustomSource = coll;
            }
        }        
        private void txtSNum1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from BorrowEquipmentsTable where Student_Number='" + txtSNum1.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string studentnumber = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    studentnumber = dr["Student_Number"].ToString();
                }
                if (txtSNum1.Text == studentnumber)
                {
                    metroLink9.Visible = false;
                    pnlManual.Enabled = true;
                }
                else if (txtSNum1.Text != studentnumber)
                {
                    metroLink9.Visible = true;
                    pnlManual.Enabled = false;
                }
            }
        }
        private void btnReturnManual_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                if ((string)row.Cells[0].Value == txtSNum1.Text && (string)row.Cells[5].Value == txtBarcode1.Text)
                {
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand cmd = new SqlCommand("DELETE from BorrowEquipmentsTable WHERE Equipment_Barcode = '" + txtBarcode1.Text + "'", myConn);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();
                        FillMetroGrid();
                        Plexiglass pg = new Plexiglass(this);
                        messagebox.showdialog("Transaction successful.");
                        pg.Close();
                    }
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ID", ID);
                        param.Add("@Student_Number", txtSNum1.Text.Trim());
                        param.Add("@Borrower", txtFName1.Text.Trim());
                        param.Add("@Year_and_Section", txtYaS1.Text.Trim());
                        param.Add("@Equipment_Borrowed", txtEquipment1.Text.Trim());
                        param.Add("@Equipment_Barcode", txtBarcode1.Text.Trim());
                        param.Add("@Time_and_Date_Returned", lblTimeandDate1.Text.Trim());
                        param.Add("@Professor", txtProf.Text.Trim());
                        myConn.Execute("ReturnTableInsert", param, commandType: CommandType.StoredProcedure);
                        txtBarcode1.Text = "";
                        txtBarcode1.Select();
                        txtEquipment1.Text = "";
                    }
                }
            }
        }
    }
}


