using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using Transitions;
using DPFP;
using DPFP.Capture;
using DPFP.Verification;
using DPFP.Processing;
using System.IO;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_StartForm : MetroForm, DPFP.Capture.EventHandler
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
        private EZEEntities1 context; //Fingerprints
        private EZEEntities4 context1; //Accounts
        private Template Template;
        public static string SetTextForFName;
        public static string SetTextForUserType;
        public static Image SetTextForImageLocation = null;

        #region Location of LoginForm Images & Instances    
        List<Image> images = new List<Image>();
        Bitmap[] location = new Bitmap[25];
              
        public EZE_StartForm()
        {
            InitializeComponent();
            context = new EZEEntities1();
            Size = new Size(340, 552);
            pbLockAdmin.Image = Properties.Resources.icons8_hide_white;
            txtPwordAdmin.PasswordChar = '•';
            txtPwordUser.PasswordChar = '•';

            location[0] = Properties.Resources.textbox_user_1;
            location[1] = Properties.Resources.textbox_user_2;
            location[2] = Properties.Resources.textbox_user_3;
            location[3] = Properties.Resources.textbox_user_4;
            location[4] = Properties.Resources.textbox_user_5;
            location[5] = Properties.Resources.textbox_user_6;
            location[6] = Properties.Resources.textbox_user_7;
            location[7] = Properties.Resources.textbox_user_8;
            location[8] = Properties.Resources.textbox_user_9;
            location[9] = Properties.Resources.textbox_user_10;
            location[10] = Properties.Resources.textbox_user_11;
            location[11] = Properties.Resources.textbox_user_12;
            location[12] = Properties.Resources.textbox_user_13;
            location[13] = Properties.Resources.textbox_user_14;
            location[14] = Properties.Resources.textbox_user_15;
            location[15] = Properties.Resources.textbox_user_16;
            location[16] = Properties.Resources.textbox_user_17;
            location[17] = Properties.Resources.textbox_user_18;
            location[18] = Properties.Resources.textbox_user_19;
            location[19] = Properties.Resources.textbox_user_20;
            location[20] = Properties.Resources.textbox_user_21;
            location[21] = Properties.Resources.textbox_user_22;
            location[22] = Properties.Resources.textbox_user_23;
            popo();
        }
        private void popo()
        {
            for (int i = 0; i < 23; i++)
            {
                Bitmap bitmap = new Bitmap(location[i]);
                images.Add(bitmap);
            }
            images.Add(Properties.Resources.textbox_user_24);
        }
        #endregion

        #region Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            var t = new Timer();
            t.Interval = 3000; // it will Tick in 3 seconds
            t.Tick += (s, f) =>
            {
                pnlLoading.Visible = false;
                pbDummy.Select();
                Init();
                Start();
                t.Stop();             
            };
            t.Start();          
        }
        #endregion

        #region Animation of Panels                
        //Line Animation
        private void line()
        {
            if (pnlAdminLogin.Left == 0)
            {
                bunifuSeparator2.LineThickness = 4;
                bunifuSeparator2.LineColor = Color.FromArgb(0, 173, 239);
                bunifuSeparator1.LineThickness = 2;
                bunifuSeparator1.LineColor = Color.Silver;
            }
            if (pnlUserLogin.Left == 0)
            {
                bunifuSeparator2.LineThickness = 2;
                bunifuSeparator2.LineColor = Color.Silver;
                bunifuSeparator1.LineThickness = 4;
                bunifuSeparator1.LineColor = Color.FromArgb(0, 173, 239);
            }
        }         
        // Event of label User Login & Admin Login          
        private void btnUserLogin_Click(object sender, EventArgs e)
        {          
            line();
            Transition.run(pictureBox1, "Top", 40, new TransitionType_ThrowAndCatch(300));
            Control ctrlOnScreen, ctrlOffScreen;
            if (pnlUserLogin.Left == 0)
            {                
                ctrlOnScreen = pnlUserLogin;
                ctrlOffScreen = pnlAdminLogin;
            }
            else
            {
                ctrlOnScreen = pnlAdminLogin;
                ctrlOffScreen = pnlUserLogin;
            }
            ctrlOnScreen.SendToBack();
            ctrlOffScreen.BringToFront();
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(ctrlOnScreen, "Left", 0 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", 0);
            t.run();

            ClearEdits();
            txtUnameUser.Focus();
        }
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            line();
            Transition.run(pictureBox1, "Top", 40, new TransitionType_ThrowAndCatch(300));          
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(pnlUserLogin, "Left", +1 * pnlUserLogin.Width); //+1
            t.run();

            ClearEdits();
            txtUnameAdmin.Focus();
        }
        //Image of lock icon
        private void AdminUnlock()
        {
            if (txtPwordAdmin.PasswordChar == '•')
            {
                txtPwordAdmin.PasswordChar = '\0';
                pbLockAdmin.Image = Properties.Resources.icons8_visible_white;
            }
            else
            {
                txtPwordAdmin.PasswordChar = '•';
                pbLockAdmin.Image = Properties.Resources.icons8_hide_white;
            }
        }
        private void UserUnlock()
        {
            if (txtPwordUser.PasswordChar == '•')
            {
                txtPwordUser.PasswordChar = '\0';
                pbLockUser.Image = Properties.Resources.icons8_visible;
            }
            else
            {
                txtPwordUser.PasswordChar = '•';
                pbLockUser.Image = Properties.Resources.icons8_hide;
            }
        }
        //Event of Eye Icon
        private void pbLockAdmin_Click(object sender, EventArgs e)
        {
            AdminUnlock();
        }
        private void pbLockUser_Click(object sender, EventArgs e)
        {
            UserUnlock();
        }
        //Switch Button
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Control ctrlOnScreen, ctrlOffScreen;
            if (pnlAL.Left == 0)
            {
                ctrlOnScreen = pnlAL;
                ctrlOffScreen = pnlTopleft;
            }
            else
            {
                ctrlOnScreen = pnlTopleft;
                ctrlOffScreen = pnlAL;
            }
            ctrlOnScreen.SendToBack();
            ctrlOffScreen.BringToFront();
            Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
            t.add(ctrlOnScreen, "Left", -1 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", 0);
            t.run();

            txtUnameAdmin.Text = "";
            txtPwordAdmin.Text = "";
            pictureBox1.Image = Properties.Resources.debut;

            if (pnlTopleft.Visible == true)
            {
                btnSwitch1.Visible = true;
                btnSwitch.Visible = false;
                pnlTopleft.Visible = false;
                pnlAL.Visible = true;
                txtUnameAdmin.Focus();
                Template = null;
                Fprintred.Visible = false;
                Fprintscan.Visible = true;
                Stop();
            }
            else if (pnlAL.Visible == true)
            {
                btnSwitch1.Visible = false;
                btnSwitch.Visible = true;
                pnlAL.Visible = false;
                pnlTopleft.Visible = true;
                pbDummy.Select();
                Start();
            }
        }
        #endregion    

        #region Admin Login
        //Event of Admin Login Panel         
        private void txtUnameAdmin_Click(object sender, EventArgs e)
        {
            if (txtUnameAdmin.Text.Length > 0)
            {
                pictureBox1.Image = images[txtUnameAdmin.Text.Length - 1];
            }
            else
            {
                pictureBox1.Image = Properties.Resources.textbox_user_clicked;
                txtUnameUser.Text = "";
            }
        }
        private void txtUnameAdmin_TextChanged(object sender, EventArgs e)
        {
            if (txtUnameAdmin.Text.Length > 0 && txtUnameAdmin.Text.Length <= 15)
            {               
                pictureBox1.Image = images[txtUnameAdmin.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txtUnameAdmin.Text.Length <= 0 )
            {
                pictureBox1.Image = Properties.Resources.debut;             
            }
            else
            {
                pictureBox1.Image = images[22];
            }
        }
        private void txtPwordAdmin_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.textbox_password);
            pictureBox1.Image = bm;
        }
        private void txtPwordAdmin_TextChanged(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.textbox_password);
            pictureBox1.Image = bm;
        }
        #endregion

        #region User Login
        // Event of User Login Panel   
        private void txtUnameUser_Click(object sender, EventArgs e)
        {
            if (txtUnameUser.Text.Length > 0)
            {
                pictureBox1.Image = images[txtUnameUser.Text.Length - 1];
            }
            else
            {
                pictureBox1.Image = Properties.Resources.textbox_user_clicked;
                txtUnameUser.Text = "";
            }
        }
        private void txtUnameUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUnameUser.Text.Length > 0 && txtUnameUser.Text.Length <= 15)
            {
                pictureBox1.Image = images[txtUnameUser.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txtUnameUser.Text.Length <= 0)
            {
                pictureBox1.Image = Properties.Resources.debut;
            }
            else
            {
                pictureBox1.Image = images[22];
            }
        }
        private void txtPwordUser_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.textbox_password);
            pictureBox1.Image = bm;
        }
        private void txtPwordUser_TextChanged(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.textbox_password);
            pictureBox1.Image = bm;
        }
        #endregion

        #region Close Loginform Button & ClearEdits       
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            if (messagebox4.showdialog("Close the application?") == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Environment.Exit(0);
                Cursor.Current = Cursors.Default;
            }
            pg.Close();
        }
        public void ClearEdits()
        {          
            ResetMouseEventArgs();
            txtUnameAdmin.Text = "";
            txtPwordAdmin.Text = "";
            txtUnameUser.Text = "";
            txtPwordUser.Text = "";       
            txtPwordAdmin.PasswordChar = '•';
            pbLockAdmin.Image = Properties.Resources.icons8_hide_white;
            txtPwordUser.PasswordChar = '•';
            pbLockUser.Image = Properties.Resources.icons8_hide;
            pictureBox1.Image = Properties.Resources.debut;
        }
        #endregion

        #region  If Login Admin Button Is Pressed      
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnameAdmin.Text == "" && txtPwordAdmin.Text == "")
                {
                    link1.Visible = true; //username and password are required
                    var t = new Timer();
                    t.Interval = 750; // it will Tick in 1 second
                    t.Tick += (s, f) =>
                    {
                        link1.Visible = false; 
                        t.Stop();
                    };
                    t.Start();
                    txtUnameAdmin.Focus();
                    ClearEdits();
                }
                else
                {
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand SelectCommand = new SqlCommand(" Select * from AccountsTable where Username='" + txtUnameAdmin.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS and Password='" + txtPwordAdmin.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                        SqlDataReader dr;
                        dr = SelectCommand.ExecuteReader();
                        int count = 0;
                        string fullname = string.Empty;
                        string user_type = string.Empty;
                        string imageloc = string.Empty;
                        while (dr.Read())
                        {
                            count = count + 1;
                            user_type = dr["User_Type"].ToString();
                            fullname = dr["Full_Name"].ToString();
                            imageloc = dr["Image_Location"].ToString();
                        }
                        if (count == 1 && user_type == "Administrator")
                        {
                            SetTextForImageLocation = Image.FromFile(imageloc);
                            SetTextForFName = fullname;
                            SetTextForUserType = user_type;
                            Plexiglass pg = new Plexiglass(this);
                            messagebox4.showdialog("");
                            pg.Close();
                            Hide();
                            EZE_AdminMenu adm = new EZE_AdminMenu();
                            adm.ShowDialog();
                            Close();
                        }
                        else if (txtUnameAdmin.Text == "")
                        {
                            link2.Visible = true; //username is required
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link2.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameAdmin.Focus();
                            ClearEdits();
                        }
                        else if (txtPwordAdmin.Text == "") 
                        {
                            link3.Visible = true; //password is required
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link3.Visible = false; 
                                t.Stop();
                            };
                            t.Start();
                            txtUnameAdmin.Focus();
                            ClearEdits();
                        }
                        else if (count == 1 && user_type != "Administrator")
                        {
                            link4.Visible = true;
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link4.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameAdmin.Focus();
                            ClearEdits();
                        }
                        else
                        {
                            link5.Visible = true; //invalid username or password
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link5.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameAdmin.Focus();
                            ClearEdits();
                        }
                    }
                }
            }
            catch (Exception ex)
            {             
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnameAdmin.Focus();
                ClearEdits();
            }
        }
        #endregion

        #region If Login User Button Is Pressed      
        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnameUser.Text == "" && txtPwordUser.Text == "")
                {
                    link6.Visible = true;
                    var t = new Timer();
                    t.Interval = 750; // it will Tick in 1 second
                    t.Tick += (s, f) =>
                    {
                        link6.Visible = false;
                        t.Stop();
                    };
                    t.Start();
                    txtUnameUser.Focus();
                    ClearEdits();
                }
                else
                {
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand SelectCommand = new SqlCommand(" Select * from AccountsTable where Username='" + txtUnameUser.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS and Password='" + txtPwordUser.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                        SqlDataReader dr;
                        dr = SelectCommand.ExecuteReader();
                        int count = 0;
                        string fullname = string.Empty;
                        string user_type = string.Empty;
                        string imageloc = string.Empty;
                        while (dr.Read())
                        {
                            count = count + 1;
                            user_type = dr["User_Type"].ToString();
                            fullname = dr["Full_Name"].ToString();
                            imageloc = dr["Image_Location"].ToString();
                        }
                        if (count == 1 && user_type == "Student Assistant")
                        {
                            SetTextForImageLocation = Image.FromFile(imageloc);
                            SetTextForFName = fullname;
                            SetTextForUserType = user_type;
                            Plexiglass pg = new Plexiglass(this);
                            messagebox4.showdialog("");
                            pg.Close();
                            Hide();
                            EZE_SAMenu sa = new EZE_SAMenu();
                            sa.ShowDialog();
                            Close();
                        }
                        else if (txtUnameUser.Text == "")
                        {
                            link7.Visible = true;
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link7.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameUser.Focus();
                            ClearEdits();
                        }
                        else if (txtPwordUser.Text == "")
                        {
                            link8.Visible = true;
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link8.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameUser.Focus();
                            ClearEdits();
                        }
                        else if (count == 1 && user_type != "Student Assistant")
                        {
                            link9.Visible = true;
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link9.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameUser.Focus();
                            ClearEdits();
                        }
                        else
                        {
                            link10.Visible = true;
                            var t = new Timer();
                            t.Interval = 750; // it will Tick in 1 second
                            t.Tick += (s, f) =>
                            {
                                link10.Visible = false;
                                t.Stop();
                            };
                            t.Start();
                            txtUnameUser.Focus();
                            ClearEdits();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnameUser.Focus();
                ClearEdits();
            }
        }
        #endregion

        #region Forgot Password Button
        private void lblForgotPwordAdmin_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            if (messagebox4.showdialog("This feature needs an internet connection. Do you want to continue?") == DialogResult.Yes)
            {
                EZE_ForgotPassword fp = new EZE_ForgotPassword();
                fp.ShowDialog();
            }
            pg.Close();
        }
        private void lblForgotPwordUser_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            if (messagebox4.showdialog("This feature needs an internet connection. Do you want to continue?") == DialogResult.Yes)
            {
                EZE_ForgotPassword fp = new EZE_ForgotPassword();
                fp.ShowDialog();
            }
            pg.Close();
        }
        #endregion    

        #region Fingerprint Identification      
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
                MessageBox.Show("Could not start capture operation.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            foreach (var emp in context.FingerprintsTableUsers)
            {
                if (features != null)
                {
                    stream = new MemoryStream(emp.Fingerprint);
                    template = new Template(stream);
                    Verificator.Verify(features, template, ref result);
                    UpdateStatus(result.FARAchieved);
                    if (result.Verified)
                    {                       
                        Invoke(new MethodInvoker(delegate ()
                        {
                            MakeReport("FINGERPRINT IDENTIFIED : " + emp.Username);
                            SetPrompt("Fingerprint Identified.");
                            Fprintgreen.Text = "IDENTIFIED : " + emp.Username;
                            Fprintgreen.Visible = true;
                            Fprintscan.Visible = false;
                            Fprintred.Visible = false;
                            btnSwitch.Visible = false;
                            btnSwitch1.Visible = false;
                            SetTextForFName = emp.Full_Name;
                            SetTextForUserType = emp.User_Type;                       
                            if (emp.User_Type == "Administrator")
                            {
                                btnProceed.Visible = true;
                                btnProceed1.Visible = false;
                                Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.debut);
                                pictureBox1.Image = bm;

                                //Plexiglass pg = new Plexiglass(this);
                                //messagebox4.showdialog("");
                                //pg.Close();

                                txtUnameAdmin.Text = emp.Username;

                                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                                {
                                    if (myConn.State == ConnectionState.Closed)
                                    { myConn.Open(); }
                                    SqlCommand SelectCommand = new SqlCommand(" Select * from AccountsTable where Username='" + txtUnameAdmin.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                                    SqlDataReader dr;
                                    dr = SelectCommand.ExecuteReader();
                                    int count = 0;
                                    string fullname = string.Empty;
                                    string user_type = string.Empty;
                                    string imageloc = string.Empty;
                                    while (dr.Read())
                                    {
                                        count = count + 1;
                                        user_type = dr["User_Type"].ToString();
                                        fullname = dr["Full_Name"].ToString();
                                        imageloc = dr["Image_Location"].ToString();
                                    }
                                    if (count == 1 && user_type == "Administrator")
                                    {
                                        SetTextForImageLocation = Image.FromFile(imageloc);
                                        SetTextForFName = fullname;
                                        SetTextForUserType = user_type;                               
                                    }
                                }
                            }
                            else if (emp.User_Type == "Student Assistant")
                            {
                                btnProceed1.Visible = true;
                                btnProceed.Visible = false;

                                //Plexiglass pg = new Plexiglass(this);
                                //messagebox4.showdialog("");
                                //pg.Close();

                                txtUnameUser.Text = emp.Username;

                                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                                {
                                    if (myConn.State == ConnectionState.Closed)
                                    { myConn.Open(); }
                                    SqlCommand SelectCommand = new SqlCommand(" Select * from AccountsTable where Username='" + txtUnameUser.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                                    SqlDataReader dr;
                                    dr = SelectCommand.ExecuteReader();
                                    int count = 0;
                                    string fullname = string.Empty;
                                    string user_type = string.Empty;
                                    string imageloc = string.Empty;
                                    while (dr.Read())
                                    {
                                        count = count + 1;
                                        user_type = dr["User_Type"].ToString();
                                        fullname = dr["Full_Name"].ToString();
                                        imageloc = dr["Image_Location"].ToString();
                                    }
                                    if (count == 1 && user_type == "Student Assistant")
                                    {
                                        SetTextForImageLocation = Image.FromFile(imageloc);
                                        SetTextForFName = fullname;
                                        SetTextForUserType = user_type;                                      
                                    }
                                }
                            }
                        }));
                        Stop();
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
                    Fprintred.Visible = true;
                    Fprintgreen.Visible = false;
                    Fprintscan.Visible = false;
                    Fprintred.Text = "-- ACCESS DENIED --";                   
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
        private void EZE_StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The fingerprint has been captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
        }
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint was removed from the reader.");
            Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.debut);
            pictureBox1.Image = bm;
        }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The reader was touched.");           
            Invoke(new MethodInvoker(delegate ()
            {
                Bitmap bm = new Bitmap(pictureBox1.Image = Properties.Resources.textbox_user_10);
                pictureBox1.Image = bm;
                Fprintred.Visible = false;
                Fprintscan.Visible = true;
            }));
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
        #endregion

        #region Prevent pressing enter button in keyboard
        private void txtUnameAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLoginAdmin_Click(sender, e);
            }
        }
        private void txtPwordAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLoginAdmin_Click(sender, e);
            }
        }
        private void txtUnameUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLoginUser_Click(sender, e);
            }
        }
        private void txtPwordUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;                
                btnLoginUser_Click(sender, e);
            }
        }
        #endregion

        #region Proceed Button
        private void btnProceed_Click(object sender, EventArgs e)
        {
            Hide();
            Cursor.Current = Cursors.WaitCursor;
            EZE_AdminMenu adm = new EZE_AdminMenu(); //ADMIN
            adm.ShowDialog();
            Cursor.Current = Cursors.Default;
            Close();
        }
        private void btnProceed1_Click(object sender, EventArgs e)
        {
            Hide();
            Cursor.Current = Cursors.WaitCursor;
            EZE_SAMenu sdb = new EZE_SAMenu(); //STUDENT ASSISTANT
            sdb.ShowDialog();
            Cursor.Current = Cursors.Default;
            Close();
        }
        #endregion

        private void btnSwitch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void EZE_StartForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void btnSwitch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void EZE_StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
            }
        }
    }
}




