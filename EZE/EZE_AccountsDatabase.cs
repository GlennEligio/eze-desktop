using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using MetroFramework.Controls;
using System.Runtime.InteropServices;
using System.Linq;
using EZE.ADO.NetModels;
using System.Text.RegularExpressions;

namespace EZE
{
    public partial class EZE_AccountsDatabase : Form
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
        string utype;
        private EZEEntities4 context;
        private EZEEntities1 context1;
        public static string SetTextForUName = "";
        public static string SetTextForFName = "";
        public static string SetUserType = "";
        public static string SetTextForl13 = "";
        public static string SetTextForLabel1 = "";
        public static string SetTextForLabel2 = "";
        public static string SetTextForLabel3 = "";
        public static string SetTextForLabel4 = "";
        public static string SetTextForLabel5 = "";
        public static Image SetTextForLabel6 = null;
        public static EZE_AccountsDatabase _instance;
        public MetroLink mlink
        {
            get { return Fprintreg; }
            set { Fprintreg = value; }
        }
        public MetroLink mlink1
        {
            get { return btnEnroll; }
            set { btnEnroll = value; }
        }
        public MyButton mlink2
        {
            get { return btnCancel; }
            set { btnCancel = value; }
        }
        public MetroTextBox mlink3
        {
            get { return txtFName; }
            set { txtFName = value; }
        }
        public EZE_AccountsDatabase()
        {
            InitializeComponent();
            _instance = this;
            Size = new Size(988, 540);
            pic.AllowDrop = true;
            datetime.Start();
            txtPword.Click += TextBoxOnClick;
            txtCPword.Click += TextBoxOnClick1;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            metroGrid.RowHeadersVisible = true;
        }

        #region DATE AND TIME               
        private void datetime_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lbldatetime.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        #endregion

        #region ACCOUNTSDATABASE LOAD      
        private void RefreshAccountsWithoutCatch()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.accountsListClassBindingSource.DataSource = db.Query<AccountsListClass>("Select * from AccountsTable", commandType: CommandType.Text);
                    _instance.panel2.Enabled = true;
                    AccountsListClass obj = _instance.accountsListClassBindingSource.Current as AccountsListClass;
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.Image_Location))
                        {
                            _instance.pic.Image = Image.FromFile(obj.Image_Location);
                        }
                        if (obj.User_Type == "Administrator")
                        {
                            _instance.metroRadioButton1.Checked = true;
                        }
                        else if (obj.User_Type == "Student Assistant")
                        {
                            _instance.metroRadioButton2.Checked = true;
                        }
                    }
                }               
            }
            catch (Exception)
            {
                //Remain blank para di macatch yung error
            }
        }
        private void RefreshAccountsWithCatch()
        {
            //Pag naka try catch tas may laman yung catch, madedetect yung image path error exception pag nag edit
            //Also pag naka try catch pag wala naman laman yung catch, ndi madedetect yung error
            //Pag wala naman try catch, matic madedetect yung image path error pag nag edit
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.accountsListClassBindingSource.DataSource = db.Query<AccountsListClass>("Select * from AccountsTable", commandType: CommandType.Text);
                    _instance.panel2.Enabled = true;
                    AccountsListClass obj = _instance.accountsListClassBindingSource.Current as AccountsListClass;
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.Image_Location))
                        {
                            _instance.pic.Image = Image.FromFile(obj.Image_Location);
                        }
                        if (obj.User_Type == "Administrator")
                        {
                            _instance.metroRadioButton1.Checked = true;
                        }
                        else if (obj.User_Type == "Student Assistant")
                        {
                            _instance.metroRadioButton2.Checked = true;
                        }
                    }
                }
                //Show kung registered or not yung fingerprint ng user
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTableUser where Username ='" + _instance.txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    int count = 0;
                    string username = string.Empty;
                    while (dr.Read())
                    {
                        count = count + 1;
                        username = dr["Username"].ToString();
                    }
                    if (_instance.txtUname.Text == username)
                    {
                        _instance.btnEnroll.Visible = false;
                        _instance.Fprintnotreg.Visible = false;
                        _instance.Fprintreg.Visible = true;
                    }
                    else if (_instance.txtUname.Text != username)
                    {
                        _instance.Fprintnotreg.Visible = true;
                        _instance.Fprintreg.Visible = false;
                        _instance.btnEnroll.Visible = false;
                        var t = new Timer();
                        t.Interval = 1000; //It will tick in n seconds
                        t.Tick += (s, f) =>
                        {
                            _instance.Fprintnotreg.Visible = false;
                            _instance.btnEnroll.Visible = true;
                            t.Stop();
                        };
                        t.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                //Show pop-up message pag yung image saved file path can't be found or pag nag iba yung directory ng saved image
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable where Image_Location ='" + _instance.metroGrid.CurrentRow.Cells[6].Value.ToString() + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    string imgloc = string.Empty;
                    string uname = string.Empty;
                    while (dr.Read())
                    {
                        imgloc = dr["Image_Location"].ToString();
                        uname = dr["Username"].ToString();
                    }
                    if (_instance.metroGrid.CurrentRow.Cells[6].Value.ToString() == imgloc)
                    {
                        SetTextForl13 = "Sorry " + uname + "!" + " Image file not found." + "\r\n" + ex.Message;
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog(SetTextForl13);
                        pg.Close();
                        AccountsListClass obj = _instance.accountsListClassBindingSource.Current as AccountsListClass;
                        if (obj != null)
                        {
                            if (obj.User_Type == "Administrator")
                            {
                                _instance.metroRadioButton1.Checked = true;
                            }
                            else if (obj.User_Type == "Student Assistant")
                            {
                                _instance.metroRadioButton2.Checked = true;
                            }
                        }
                    }
                }
            }
        }
        public static void LoadAccountsToMetrogrid()
        {
            //Load the data from database to metrogrid
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                _instance.accountsListClassBindingSource.DataSource = db.Query<AccountsListClass>("Select * from AccountsTable", commandType: CommandType.Text);
                AccountsListClass obj = _instance.accountsListClassBindingSource.Current as AccountsListClass;
            }
        }
        private void AccountsDatabase_Load(object sender, EventArgs e)
        {
            context = new EZEEntities4();
            context1 = new EZEEntities1();
            LoadAccountsToMetrogrid();
        }
        #endregion

        #region ADD BUTTON
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnEnroll.Visible = false;
            Fprintnotreg.Visible = false;
            Fprintreg.Visible = false;
            panel2.Enabled = false;
            pic.Image = null;
            btnVerifyUname.Visible = true;
            lblUsernameVerified.Visible = false;
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
            txtCPword.Visible = true;
            txtUname.Enabled = true;
            btnUpdate.Visible = false;
            txtUname.Select();
            objState = EntityState.Added;
            accountsListClassBindingSource.Add(new AccountsListClass());
            accountsListClassBindingSource.MoveLast();  //No data sa grid because of this line

            metroGrid.Visible = false;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnImport.Visible = false;
            btnExport.Visible = false;
            btnViewFingerprints.Visible = false;
            line1.Visible = false;
        }
        #endregion

        #region EDIT BUTTON
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("Can't edit multiple accounts at once.");
                pg.Close();
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                txtCPword.Select();
                txtUname.Enabled = false;
                txtFName.Enabled = false;
                metroRadioButton1.Enabled = false;
                metroRadioButton2.Enabled = false;
                label2.Enabled = false;
                btnVerifyUname.Visible = false;
                panel2.Enabled = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                lblUsernameVerified.Visible = true;
                txtCPword.Visible = true;
                txtCPword.Text = "";
                pic.Image = null;

                btnImport.Visible = false;
                btnExport.Visible = false;
                line1.Visible = false;
                btnViewFingerprints.Visible = false;
                objState = EntityState.Changed;
                RefreshAccountsWithCatch(); //Need macatch yung file path error pag nag edit kaya with catch
                metroGrid.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;

                //Show label kung registered na yung user or not
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTableUser where Username='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    string uname = string.Empty;
                    while (dr.Read())
                    {
                        uname = dr["Username"].ToString();
                    }
                    if (txtUname.Text == uname)
                    {
                        btnEnroll.Visible = false;
                        Fprintnotreg.Visible = false;
                        Fprintreg.Visible = true;
                    }
                    else if (txtUname.Text != uname)
                    {
                        Fprintnotreg.Visible = true;
                        Fprintreg.Visible = false;
                        btnEnroll.Visible = false;
                        var t = new Timer();
                        t.Interval = 1500; //It will tick in n seconds
                        t.Tick += (s, f) =>
                        {
                            Fprintnotreg.Visible = false;
                            btnEnroll.Visible = true;
                            t.Stop();
                        };
                        t.Start();
                    }
                }
            }
            else if (metroGrid.Rows.Count < 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("No data found. Edit isn't available.");
                pg.Close();
            }
        }
        #endregion

        #region DELETE BUTTON      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                if (Validation.showdialog("Removing these data will also wipe the fingerprints attached to each user. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        AccountsTable acc = new AccountsTable()
                        {
                            Full_Name = row.Cells[0].Value.ToString(),
                            Username = row.Cells[1].Value.ToString(),
                            Password = row.Cells[2].Value.ToString(),
                            User_Type = row.Cells[3].Value.ToString(),
                            Date_Time_Registered = lbldatetime.ToString(),
                            Email = row.Cells[5].Value.ToString(),
                            Image_Location = row.Cells[6].Value.ToString()
                        };
                        context.AccountsTables.Attach(acc);
                        context.AccountsTables.Remove(acc);
                        context.SaveChanges();

                        //Pag dinelete yung user info madedelete din yung fingerprint data ng user
                        string uname = row.Cells[1].Value.ToString();
                        var unamee = context1.FingerprintsTableUsers.FirstOrDefault(a => a.Username.Equals(uname));
                        if (unamee != null)
                        {
                            context1.FingerprintsTableUsers.Attach(unamee);
                            context1.FingerprintsTableUsers.Remove(unamee);
                            context1.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    accountsListClassBindingSource.MoveFirst();
                    AccountsDatabase_Load(sender, e); //Pagkadelete, refresh lang pde na. No need na yung refereshwithcatch or w/o catch
                    Validation.showdialog("User accounts were successfully deleted.");
                }
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                if (Validation.showdialog("Removing this data will also wipe the fingerprint attached to this user. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        AccountsTable acc = new AccountsTable()
                        {
                            Full_Name = row.Cells[0].Value.ToString(),
                            Username = row.Cells[1].Value.ToString(),
                            Password = row.Cells[2].Value.ToString(),
                            User_Type = row.Cells[3].Value.ToString(),
                            Date_Time_Registered = lbldatetime.ToString(),
                            Email = row.Cells[5].Value.ToString(),
                            Image_Location = row.Cells[6].Value.ToString()
                        };
                        context.AccountsTables.Attach(acc);
                        context.AccountsTables.Remove(acc);
                        context.SaveChanges();

                        //Pag dinelete yung user info madedelete din yung fingerprint data ng user
                        string uname = row.Cells[1].Value.ToString();
                        var unamee = context1.FingerprintsTableUsers.FirstOrDefault(a => a.Username.Equals(uname));
                        if (unamee != null)
                        {
                            context1.FingerprintsTableUsers.Attach(unamee);
                            context1.FingerprintsTableUsers.Remove(unamee);
                            context1.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    accountsListClassBindingSource.MoveFirst();
                    AccountsDatabase_Load(sender, e); //Pagkadelete, refresh lang pde na. No need na yung refereshwithcatch or w/o catch
                    Validation.showdialog("User account was successfully deleted.");
                }
            }
            else if (metroGrid.Rows.Count < 1)
            {
                Validation.showdialog("No data found. Delete isn't available.");
            }
            pg.Close();
        }
        #endregion

        #region CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            accountsListClassBindingSource.MoveFirst();
            metroGrid.Visible = true;
            btnImport.Visible = true;
            btnExport.Visible = true;
            btnViewFingerprints.Visible = true;
            line1.Visible = true;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            txtCPword.Text = "";
            btnEnroll.Visible = false;
            Fprintnotreg.Visible = false;
            Fprintreg.Visible = false;
            txtFName.Enabled = true;
            metroRadioButton1.Enabled = true;
            metroRadioButton2.Enabled = true;
            label2.Enabled = true;
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
            RefreshAccountsWithoutCatch(); //Di naman need macatch yung error pag nagcancel kaya without catch
        }
        void Clear()
        {
            txtUname.Text = "";
            txtPword.Text = "";
            txtFName.Text = "";
            txtEmail.Text = "";
            txtCPword.Text = "";
            pic.Image = null;
            lblUsernameVerified.Visible = false; //kaka add ko lang nito 11:51pm - kambal to nung lblnotregistered
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
            txtUname.Enabled = true;
        }
        #endregion
       
        #region SAVE BUTTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                AccountsListClass obj = accountsListClassBindingSource.Current as AccountsListClass;
                if (obj != null)
                {
                    if (objState == EntityState.Added)
                    {
                        string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,.- ";
                        string allowedcharforpassword = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789";
                        if (string.IsNullOrEmpty(txtUname.Text) || string.IsNullOrEmpty(txtPword.Text) || string.IsNullOrWhiteSpace(txtFName.Text) ||
                            string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCPword.Text) || pic.Image == null)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("Please complete all the necessary fields.");
                            pg.Close();
                            txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox

                            //Check textboxes kung may laman and assign a focus
                            if (lblUsernameVerified.Visible == false)
                            {
                                txtUname.Select();
                                txtUname.Select(txtUname.Text.Length, 0); //Set cursor at the end of textbox
                            }
                            else if (lblUsernameVerified.Visible == true)
                            {
                                if (string.IsNullOrWhiteSpace(txtFName.Text))
                                {
                                    txtFName.Select();
                                }
                                else if (string.IsNullOrEmpty(txtEmail.Text))
                                {
                                    txtEmail.Select();
                                }
                                else if (string.IsNullOrEmpty(txtPword.Text))
                                {
                                    txtPword.Select();
                                }
                                else if (string.IsNullOrEmpty(txtCPword.Text))
                                {
                                    txtCPword.Select();
                                }
                            }
                        }
                        else if (!txtFName.Text.All(allowedcharforname.Contains)) //Pag may name pero may maling char sa name
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("No special characters or digits are allowed.");
                            pg.Close();
                            txtFName.Text = "";
                            txtFName.Select();
                        }
                        else if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("User type is required.\nAdministrator or Student Assistant?");
                            pg.Close();
                        }
                        else if (!txtPword.Text.All(allowedcharforpassword.Contains) || !txtCPword.Text.All(allowedcharforpassword.Contains) ||
                            !txtPword.Text.All(allowedcharforpassword.Contains) && !txtCPword.Text.All(allowedcharforpassword.Contains))
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("Password doesn't support special characters.");
                            pg.Close();
                            txtPword.Text = "";
                            txtCPword.Text = "";
                            txtPword.Select();
                        }
                        else if (txtCPword.Text != txtPword.Text)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("Passwords you have entered don't match.");
                            pg.Close();
                            txtCPword.Text = "";
                            txtCPword.Select();
                        }
                        else
                        {
                            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                            {
                                if (myConn.State == ConnectionState.Closed)
                                { myConn.Open(); }
                                SqlCommand SelectCommand = new SqlCommand(" Select * from FingerprintsTableUser where Username='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                                SqlDataReader dr;
                                dr = SelectCommand.ExecuteReader();
                                string username = string.Empty;
                                while (dr.Read())
                                {
                                    username = dr["Username"].ToString();
                                }
                                if (txtUname.Text != username)
                                {
                                    Plexiglass pg = new Plexiglass(this);
                                    Validation.showdialog("Please complete the fingerprint enrollment.");
                                    pg.Close();
                                    txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                                }
                                else
                                {
                                    obj.Full_Name = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                                    if (metroRadioButton1.Checked == true)
                                    { utype = "Administrator"; }
                                    else if (metroRadioButton2.Checked == true)
                                    { utype = "Student Assistant"; }
                                    DynamicParameters p = new DynamicParameters();
                                    p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                                    p.AddDynamicParams(new
                                    {
                                        Username = obj.Username,
                                        Password = obj.Password,
                                        Full_Name = obj.Full_Name,
                                        User_Type = utype,
                                        Date_Time_Registered = lbldatetime.Text,
                                        Email = obj.Email,
                                        Image_Location = obj.Image_Location
                                    });
                                    db.Execute("AccountsTableInsert", p, commandType: CommandType.StoredProcedure);
                                    obj.ID = p.Get<int>("@ID");

                                    Plexiglass pg = new Plexiglass(this);
                                    Validation.showdialog("Account was successfully saved.");
                                    pg.Close();
                                    Clear();
                                    accountsListClassBindingSource.MoveFirst();
                                    AccountsDatabase_Load(sender, e); //Pagkasave, refresh lang pde na. No need na yung refereshwithcatch or w/o catch
                                    metroGrid.Visible = true;
                                    btnAdd.Visible = true;
                                    btnEdit.Visible = true;
                                    btnDelete.Visible = true;
                                    btnImport.Visible = true;
                                    btnExport.Visible = true;
                                    btnViewFingerprints.Visible = true;
                                    line1.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region UPDATE BUTTON
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                AccountsListClass obj = accountsListClassBindingSource.Current as AccountsListClass;
                if (obj != null)
                {
                    string allowedcharforpassword = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789";
                    if (string.IsNullOrEmpty(txtPword.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCPword.Text) || pic.Image == null)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Please complete all the necessary fields.");
                        pg.Close();
                        //Check textboxes kung may laman and assign a focus
                        if (string.IsNullOrEmpty(txtEmail.Text))
                        {
                            txtEmail.Select();
                        }
                        else if (string.IsNullOrEmpty(txtPword.Text))
                        {
                            txtPword.Select();
                        }
                        else if (string.IsNullOrEmpty(txtCPword.Text))
                        {
                            txtCPword.Select();
                        }
                    }
                    else if (!txtPword.Text.All(allowedcharforpassword.Contains) || !txtCPword.Text.All(allowedcharforpassword.Contains) ||
                        !txtPword.Text.All(allowedcharforpassword.Contains) && !txtCPword.Text.All(allowedcharforpassword.Contains))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Password doesn't support special characters.");
                        pg.Close();
                        txtPword.Text = "";
                        txtCPword.Text = "";
                        txtPword.Select();
                    }
                    else if (txtCPword.Text != txtPword.Text)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Passwords don't match. Please try again.");
                        pg.Close();
                        txtCPword.Text = "";
                        txtCPword.Select();
                    }                    
                    else
                    {
                        using (SqlConnection myConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (myConn1.State == ConnectionState.Closed)
                            { myConn1.Open(); }
                            SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTableUser where Username='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn1);
                            SqlDataReader dr;
                            dr = SelectCommand.ExecuteReader();
                            string username = string.Empty;
                            while (dr.Read())
                            {
                                username = dr["Username"].ToString();
                            }
                            if (txtUname.Text != username)
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("Please complete the fingerprint enrollment.");
                                pg.Close();
                            }
                            else
                            {
                                if (objState == EntityState.Changed)
                                {
                                    if (metroRadioButton1.Checked == true)
                                    {
                                        utype = "Administrator";
                                    }
                                    else if (metroRadioButton2.Checked == true)
                                    {
                                        utype = "Student Assistant";
                                    }
                                    db.Execute("AccountsTableUpdate", new
                                    {
                                        ID = obj.ID,
                                        Username = obj.Username,
                                        Password = obj.Password,
                                        Full_Name = obj.Full_Name,
                                        User_Type = utype,
                                        Email = obj.Email,
                                        Image_Location = obj.Image_Location
                                    }, commandType: CommandType.StoredProcedure);

                                    Plexiglass pg = new Plexiglass(this);
                                    Validation.showdialog("Account was successfully updated.");
                                    pg.Close();

                                    txtFName.Enabled = true;
                                    metroRadioButton1.Enabled = true;
                                    metroRadioButton2.Enabled = true;
                                    label2.Enabled = true;
                                    panel2.Enabled = true;
                                    btnUpdate.Visible = false;
                                    btnAdd.Visible = true;
                                    btnEdit.Visible = true;
                                    btnDelete.Visible = true;
                                    txtCPword.Text = "";
                                    btnImport.Visible = true;
                                    btnExport.Visible = true;
                                    btnViewFingerprints.Visible = true;
                                    line1.Visible = true;

                                    AccountsDatabase_Load(sender, e); //Pagkaupdate, refresh lang pde na. No need na yung refereshwithcatch or w/o catch
                                    metroGrid.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
       
        #region VERIFY USERNAME
        private void btnVerifyUname_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            string allowedcharforusername = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789";
            if (string.IsNullOrEmpty(txtUname.Text))
            {
                Validation.showdialog("Username is required. Don't leave it as blank.");
                txtUname.Select();
            }
            else if (!txtUname.Text.All(allowedcharforusername.Contains))
            {
                Validation.showdialog("No special characters are allowed.");
                txtUname.Text = "";
                txtUname.Select();
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable where Username ='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                    SqlDataReader dr;
                    myConn.Open();
                    dr = SelectCommand.ExecuteReader();
                    string uname = string.Empty;
                    while (dr.Read())
                    {
                        uname = dr["Username"].ToString();
                    }
                    if (txtUname.Text == uname)
                    {
                        Validation.showdialog("This username is already taken.");
                        txtUname.Text = "";
                        txtUname.Select();
                    }
                    else
                    {
                        if (Validation.showdialog("Do you want to use this as your username? Once selected, you can't change it anymore.") == DialogResult.Yes)
                        {
                            panel2.Enabled = true;
                            //txtFName.Enabled = true;
                            txtUname.Enabled = false;
                            txtFName.Select();
                            btnVerifyUname.Visible = false;
                            lblUsernameVerified.Visible = true;

                            using (SqlConnection myConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                            {
                                if (myConn1.State == ConnectionState.Closed)
                                { myConn1.Open(); }
                                SqlCommand SelectCommand1 = new SqlCommand("Select * from FingerprintsTableUser where Username ='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn1);
                                SqlDataReader dr1;
                                dr1 = SelectCommand1.ExecuteReader();
                                string username = string.Empty;
                                while (dr1.Read())
                                {
                                    username = dr1["Username"].ToString();
                                }
                                if (txtUname.Text == username)
                                {
                                    Fprintreg.Visible = true;
                                }
                                else
                                {
                                    Fprintnotreg.Visible = true;
                                    var t = new Timer();
                                    t.Interval = 3000; //It will tick in n seconds
                                    t.Tick += (s, f) =>
                                    {
                                        Fprintnotreg.Visible = false;
                                        btnEnroll.Visible = true;
                                        t.Stop();
                                    };
                                    t.Start();
                                }
                            }
                        }
                        else //Pag no yung response
                        {
                            txtUname.Select(); //Set focus
                            txtUname.Select(txtUname.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                }
            }
            pg.Close();            
        }
        #endregion

        #region EXPORT BUTTON      
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count == 1 || metroGrid.Rows.Count > 1)
            {
                if (Validation.showdialog("All the data in this table will be exported to an excel file. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbooks wb = xcelApp.Workbooks;
                    try
                    {
                        wb.Add(Type.Missing);
                        for (int i = 1; i < metroGrid.Columns.Count + 1; i++)
                        {
                            xcelApp.Cells[1, i] = metroGrid.Columns[i - 1].HeaderText;
                            Range xcelRange = (Range)xcelApp.Cells[i];
                            xcelRange.Font.Bold = -1;
                            xcelRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        }
                        for (int i = 0; i < metroGrid.Rows.Count; i++)
                        {
                            for (int j = 0; j < metroGrid.Columns.Count; j++)
                            {
                                if (metroGrid.Rows[i].Cells[j].Value == null)
                                {
                                    metroGrid.Rows[i].Cells[j].Value = ""; //When the gridview is empty do a checking and insert blank value 
                                    Range xlRange1 = (Range)xcelApp.Cells[i + 2, j + 1];
                                }
                                Range xcelRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                xcelRange.NumberFormat = "@";
                                xcelApp.Cells[i + 2, j + 1] = metroGrid.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        xcelApp.Columns.AutoFit();
                        xcelApp.Visible = true;
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.FinalReleaseComObject(wb);
                        Marshal.FinalReleaseComObject(xcelApp);
                    }
                }
                Cursor.Current = Cursors.Default;
            }            
            else
            {
                Validation.showdialog("No data found. Export isn't available.");
            }
            pg.Close();
        }
        #endregion

        #region DISPLAY PROFILE / INFORMATION
        private void metroGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDummy.Select();
            Cursor.Current = Cursors.WaitCursor;
            Plexiglass pg = new Plexiglass(this);
            try
            {
                if (metroGrid.Rows.Count < 1)
                {
                    Validation.showdialog("No data found. Can't display any information.");
                }
                else if (string.IsNullOrWhiteSpace(metroGrid.CurrentRow.Cells[6].Value.ToString())) //If image is null dapat di magopen yung form
                {
                    Validation.showdialog("Can't display information because there is no image attached for this account.");
                }
                else if (metroGrid.SelectedRows.Count > 1)
                {
                    Validation.showdialog("Can't display multiple profiles at once.");
                }
                else
                {
                    ViewDetails2 vd = new ViewDetails2();
                    SetTextForLabel1 = metroGrid.CurrentRow.Cells[0].Value.ToString();
                    SetTextForLabel2 = metroGrid.CurrentRow.Cells[1].Value.ToString();
                    SetTextForLabel3 = metroGrid.CurrentRow.Cells[2].Value.ToString();
                    SetTextForLabel4 = metroGrid.CurrentRow.Cells[3].Value.ToString();
                    SetTextForLabel5 = metroGrid.CurrentRow.Cells[5].Value.ToString();
                    SetTextForLabel6 = Image.FromFile(metroGrid.CurrentRow.Cells[6].Value.ToString());
                    vd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //Show pop-up message pag yung image saved file path can't be found or pag nag iba yung directory ng saved image
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable where Image_Location ='" + _instance.metroGrid.CurrentRow.Cells[6].Value.ToString() + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    string imgloc = string.Empty;
                    string uname = string.Empty;
                    while (dr.Read())
                    {
                        imgloc = dr["Image_Location"].ToString();
                        uname = dr["Username"].ToString();
                    }
                    string SpecificCell = metroGrid.CurrentRow.Cells[1].Value.ToString(); //Get the value of username cell when it is selected                    
                    if (metroGrid.SelectedRows.Count == 1)
                    {
                        if (_instance.metroGrid.CurrentRow.Cells[6].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + SpecificCell + "!" + " Image file not found." + "\r\n" + ex.Message;
                            Validation.showdialog(SetTextForl13);
                        }
                    }
                }
            }
            pg.Close();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region ENROLL FINGERPRINT
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTableUser where Username ='" + txtUname.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                string username = string.Empty;
                while (dr.Read())
                {
                    username = dr["Username"].ToString();
                }
                if (string.IsNullOrEmpty(txtUname.Text) || string.IsNullOrEmpty(txtPword.Text) || string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrEmpty(txtEmail.Text)
                    || string.IsNullOrEmpty(txtCPword.Text) || pic.Image == null || metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
                {
                    Plexiglass pg = new Plexiglass(this);
                    Validation.showdialog("Please complete all the necessary fields. Then click for 'Enroll Fingerprint'.");
                    pg.Close();

                    //Check textboxes kung may laman and assign a focus
                    if (lblUsernameVerified.Visible == true && objState == EntityState.Added)
                    {
                        if (string.IsNullOrWhiteSpace(txtFName.Text))
                        {
                            txtFName.Select();
                        }
                        else if (string.IsNullOrEmpty(txtEmail.Text))
                        {
                            txtEmail.Select();
                        }
                        else if (string.IsNullOrEmpty(txtPword.Text))
                        {
                            txtPword.Select();
                        }
                        else if (string.IsNullOrEmpty(txtCPword.Text))
                        {
                            txtCPword.Select();
                        }
                    }
                    else if (lblUsernameVerified.Visible == true && objState == EntityState.Changed)
                    {
                        if (string.IsNullOrEmpty(txtEmail.Text))
                        {
                            txtEmail.Select();
                        }
                        else if (string.IsNullOrEmpty(txtPword.Text))
                        {
                            txtPword.Select();
                        }
                        else if (string.IsNullOrEmpty(txtCPword.Text))
                        {
                            txtCPword.Select();
                        }
                    }
                }
                else if (txtUname.Text != username) //Pag hindi pa registered yung fingerprint ng user
                {
                    SetTextForUName = txtUname.Text;
                    SetTextForFName = txtFName.Text;
                    Plexiglass pg = new Plexiglass(this);
                    EZE_UsersFingerprintRegister lfpr = new EZE_UsersFingerprintRegister();
                    lfpr.ShowDialog();
                    pg.Close();
                    txtCPword.Select();
                }               
            }
        }
        #endregion

        #region PREVENT PRESSING 'ENTER' AND 'SPACE' IN KEYBOARD
        private void txtUname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SELECT OR DRAG AND DROP AN IMAGE
        EntityState objState = EntityState.Unchanged;
        private void pic_Click(object sender, EventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                return;
            }
            else
            {
                btnDummy.Select();
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pic.Image = Image.FromFile(ofd.FileName);
                        AccountsListClass obj = accountsListClassBindingSource.Current as AccountsListClass;
                        if (obj != null)
                        {
                            obj.Image_Location = ofd.FileName;
                        }
                    }
                }
                //Check textboxes kung may laman and assign a focus
                if (lblUsernameVerified.Visible == false && objState == EntityState.Added)
                {
                    txtUname.Select();
                }
                else if (lblUsernameVerified.Visible == true && objState == EntityState.Added)
                {
                    if (string.IsNullOrWhiteSpace(txtFName.Text))
                    {
                        txtFName.Select();
                    }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        txtEmail.Select();
                    }
                    else if (string.IsNullOrEmpty(txtPword.Text))
                    {
                        txtPword.Select();
                    }
                    else if (string.IsNullOrEmpty(txtCPword.Text))
                    {
                        txtCPword.Select();
                    }
                }
                else if (lblUsernameVerified.Visible == true && objState == EntityState.Changed)
                {
                    if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        txtEmail.Select();
                    }
                    else if (string.IsNullOrEmpty(txtPword.Text))
                    {
                        txtPword.Select();
                    }
                    else if (string.IsNullOrEmpty(txtCPword.Text))
                    {
                        txtCPword.Select();
                    }
                }
            }
        }
        private void pic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void pic_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string picture in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                //Drag image to view in picturebox
                Image img = Image.FromFile(picture);
                pic.Image = img;
                AccountsListClass obj = accountsListClassBindingSource.Current as AccountsListClass;
                if (obj != null)
                {
                    obj.Image_Location = picture;
                }
            }
        }
        #endregion

        #region EXTRAS
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            utype = "Administrator";
            SetUserType = txtUtype.Text = "Administrator";
        }
        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            utype = "Student Assistant";
            SetUserType = txtUtype.Text = "Student Assistant";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
           // Close();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            EZE_ImportExcelFile ief = new EZE_ImportExcelFile();
            ief.ShowDialog();
            pg.Close();
        }
        private void captureAnImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            EZE_Camera cam = new EZE_Camera();
            cam.ShowDialog();
            pg.Close();
        }
        private void btnViewFingerprints_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            EZE_UsersFingerprint ufp = new EZE_UsersFingerprint();
            ufp.ShowDialog();
            pg.Close();
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelRegisteredUsers.Visible = true;
        }        
        private void TextBoxOnClick(object sender, EventArgs e)
        {
            txtPword.SelectAll();
            txtPword.Select();
        }
        private void TextBoxOnClick1(object sender, EventArgs e)
        {
            txtCPword.SelectAll();
            txtCPword.Select();
        }
        #endregion    
    }
}

