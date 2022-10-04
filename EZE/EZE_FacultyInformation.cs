using Dapper;
using EZE.ADO.NetModels;
using Microsoft.Office.Interop.Excel;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EZE
{
    public partial class EZE_FacultyInformation : Form
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
        private EZEEntities5 context;
        public static EZE_FacultyInformation _instance;
        public EZE_FacultyInformation()
        {
            InitializeComponent();
            _instance = this;
            Size = new Size(988, 540);
            datetime.Start();
            txtProfessor.Click += TextBoxOnClick;
            txtContactNumber.Click += TextBoxOnClick1;
           // SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            metroGrid.RowHeadersVisible = true;
        }


        #region DATE AND TIME
        private void datetime_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lbldatetime.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        #endregion

        #region FACULTYINFORMATION_LOAD
        private void EZE_FacultyInformation_Load(object sender, EventArgs e)
        {
            context = new EZEEntities5();
            RefreshFaculty();
        }
        public static void RefreshFaculty()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                _instance.professorsClassBindingSource.DataSource = db.Query<ProfessorsClass>("Select * from ProfessorsTable", commandType: CommandType.Text);
                ProfessorsClass obj = _instance.professorsClassBindingSource.Current as ProfessorsClass;
            }
        }
        #endregion

        #region ADD BUTTON
        EntityState objState = EntityState.Unchanged;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtProfessor.Select();
            objState = EntityState.Added;
            professorsClassBindingSource.Add(new ProfessorsClass());
            professorsClassBindingSource.MoveLast();  //No data sa grid dahil dito
            metroGrid.Visible = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnImport.Visible = false;
            btnExport.Visible = false;
            line1.Visible = false;
            btnVerifyName.Visible = true;
        }
        #endregion

        #region EDIT BUTTON
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("Can't edit multiple contacts at once.");
                pg.Close();
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                btnVerifyName.Visible = false;
                lblNameVerified.Visible = true;
                btnChangeName.Visible = true;
                txtProfessor.Enabled = false;
                txtContactNumber.Enabled = true;
                btnImport.Visible = false;
                btnExport.Visible = false;
                line1.Visible = false;

                txtContactNumber.Select(); //Set focus
                txtContactNumber.Select(txtContactNumber.Text.Length, 0); //Set focus at the end of textbox

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                objState = EntityState.Changed;
                EZE_FacultyInformation_Load(sender, e);
                metroGrid.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;
                txtProfessorDummy.Text = txtProfessor.Text;
                txtContactNumberDummy.Text = txtContactNumber.Text;
            }
            else if (metroGrid.Rows.Count < 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("No data found. Edit isn't available.");
                pg.Close();
                btnImport.Visible = true;
                btnExport.Visible = true;
                line1.Visible = true;
            }
        }
        private void btnChangeName_Click(object sender, EventArgs e)
        {
            txtProfessor.Enabled = true;
            lblNameVerified.Visible = false;
            btnChangeName.Visible = false;
            btnVerifyName.Visible = true;
            txtProfessor.Select();
            txtProfessor.Select(txtProfessor.Text.Length, 0); //Set focus at the end of textbox
        }
        private void TextBoxOnClick(object sender, EventArgs e)
        {
            txtProfessor.SelectAll();
            txtProfessor.Select();
        }
        private void TextBoxOnClick1(object sender, EventArgs e)
        {
            txtContactNumber.SelectAll();
            txtContactNumber.Select();
        }
        #endregion

        #region DELETE BUTTON
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                if (Validation.showdialog("The selected contact details will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        string cnum = row.Cells[1].Value.ToString();
                        var cnumm = context.ProfessorsTables.FirstOrDefault(a => a.Contact_Number.Equals(cnum));
                        if (cnumm != null && cnum == row.Cells[1].Value.ToString())
                        {
                            context.ProfessorsTables.Attach(cnumm);
                            context.ProfessorsTables.Remove(cnumm);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    professorsClassBindingSource.MoveFirst();
                    EZE_FacultyInformation_Load(sender, e);
                    Validation.showdialog("Contact details were successfully deleted.");
                }
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                if (Validation.showdialog("The selected contact detail will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        string cnum = row.Cells[1].Value.ToString();
                        var cnumm = context.ProfessorsTables.FirstOrDefault(a => a.Contact_Number.Equals(cnum));
                        if (cnumm != null && cnum == row.Cells[1].Value.ToString())
                        {
                            context.ProfessorsTables.Attach(cnumm);
                            context.ProfessorsTables.Remove(cnumm);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    professorsClassBindingSource.MoveFirst();
                    EZE_FacultyInformation_Load(sender, e);
                    Validation.showdialog("Contact detail was successfully deleted.");
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
            metroGrid.Visible = true;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnImport.Visible = true;
            btnExport.Visible = true;
            line1.Visible = true;
            Clear();
            txtProfessorDummy.Text = "";
            txtContactNumberDummy.Text = "";
            btnChangeName.Visible = false;
            btnVerifyName.Visible = true;
            EZE_FacultyInformation_Load(sender, e);
            professorsClassBindingSource.MoveFirst();
        }
        void Clear()
        {
            lblNameVerified.Visible = false;
            txtContactNumber.Text = "";
            txtProfessor.Text = "";
            txtProfessor.Enabled = true;
            txtContactNumber.Enabled = false;
        }
        #endregion

        #region SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                ProfessorsClass obj = professorsClassBindingSource.Current as ProfessorsClass;
                if (obj != null)
                {
                    string allowedcharforcontact = "0123456789+";
                    string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,. ";
                    //Pag dipa verified yung prof name
                    if (string.IsNullOrWhiteSpace(txtProfessor.Text)) //Pag wlang prof name
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Professor's name is required.");
                        pg.Close();
                        txtProfessor.Text = "";
                        txtProfessor.Select();
                    }
                    else if (!txtProfessor.Text.All(allowedcharforname.Contains) && lblNameVerified.Visible == false) //Pag may name pero may maling char sa name, and di pa verified
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("No special characters or digits are allowed.");
                        pg.Close();
                        txtProfessor.Text = "";
                        txtProfessor.Select();
                    }
                    else if (txtProfessor.Text.All(allowedcharforname.Contains) && lblNameVerified.Visible == false) //Pag may name and goods yung all char sa name, and di pa verified
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("To proceed, please verify the professor's name.");
                        pg.Close();
                        txtProfessor.Text = Regex.Replace(txtProfessor.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                        txtProfessor.Select(); //Set focus
                        txtProfessor.Select(txtProfessor.Text.Length, 0); //Set cursor at the end of textbox
                    }
                    //Pag verified na yung prof name (visible na yung lblverified)
                    else if (string.IsNullOrEmpty(txtContactNumber.Text) && lblNameVerified.Visible == true) //Pag blank yung contact number, and verified na
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Contact number is required.");
                        pg.Close();
                        txtContactNumber.Select();
                    }
                    else if (!txtContactNumber.Text.All(allowedcharforcontact.Contains) && lblNameVerified.Visible == true) //Pag may digits pero may maling char, and verified na
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("No special characters or letters are allowed.");
                        pg.Close();
                        txtContactNumber.Text = "";
                        txtContactNumber.Select();
                    }
                    else if (txtContactNumber.Text.All(allowedcharforcontact.Contains) && lblNameVerified.Visible == true) //Pag may digits and goods yung all char, and verified na
                    {
                        using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (myConn.State == ConnectionState.Closed)
                            { myConn.Open(); }
                            SqlCommand SelectCommand = new SqlCommand(" Select * from ProfessorsTable where Contact_Number ='" + txtContactNumber.Text + "'", myConn);
                            SqlDataReader dr;
                            dr = SelectCommand.ExecuteReader();
                            string cnum = string.Empty;
                            while (dr.Read())
                            {
                                //Cnum = contact numbers sa database
                                cnum = dr["Contact_Number"].ToString();
                            }
                            if (txtContactNumber.Text == cnum) //Pag txtcnum.text is recorded na sa database
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("This contact number is already registered in the database.");
                                pg.Close();
                                txtContactNumber.Text = "";
                                txtContactNumber.Select();
                            }
                            else //Pag walang nakitang same number sa database
                            {
                                DynamicParameters p = new DynamicParameters();
                                p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                                p.AddDynamicParams(new
                                {
                                    Contact_Number = obj.Contact_Number,
                                    Professor = obj.Professor

                                });
                                db.Execute("ProfessorsTableInsert", p, commandType: CommandType.StoredProcedure);
                                obj.ID = p.Get<int>("@ID");

                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("Contact information was successfully saved.");
                                pg.Close();
                                Clear();
                                professorsClassBindingSource.MoveFirst();
                                EZE_FacultyInformation_Load(sender, e);

                                metroGrid.Visible = true;
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnDelete.Visible = true;
                                btnSave.Visible = false;
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
                ProfessorsClass obj = professorsClassBindingSource.Current as ProfessorsClass;
                if (obj != null)
                {
                    string allowedcharforcontact = "0123456789+";
                    string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,. ";

                    //Pag dipa verified yung prof name
                    if (string.IsNullOrWhiteSpace(txtProfessor.Text))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Professor's name is required.");
                        pg.Close();
                        txtProfessor.Text = "";
                        txtProfessor.Select();
                    }
                    else if (!txtProfessor.Text.All(allowedcharforname.Contains) && lblNameVerified.Visible == false) //Pag may name pero may maling char sa name, and di pa verified
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("No special characters or digits are allowed.");
                        pg.Close();
                        txtProfessor.Text = "";
                        txtProfessor.Select();
                    }
                    else if (txtProfessor.Text.All(allowedcharforname.Contains) && lblNameVerified.Visible == false) //Pag may name and goods yung all char sa name, and di pa verified
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("To proceed, please verify the professor's name.");
                        pg.Close();
                        txtProfessor.Text = Regex.Replace(txtProfessor.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                        txtProfessor.Select(); //Set focus
                        txtProfessor.Select(txtProfessor.Text.Length, 0); //Set cursor at the end of textbox
                    }

                    //Pag verified na yung prof name (visible na yung lblverified)
                    else if (string.IsNullOrEmpty(txtContactNumber.Text) && lblNameVerified.Visible == true) //Pag blank yung contact number, and verified na
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Contact number is required.");
                        pg.Close();
                        txtContactNumber.Select();
                    }
                    else if (!txtContactNumber.Text.All(allowedcharforcontact.Contains) && lblNameVerified.Visible == true) //Pag may digits pero may maling char, and verified na
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("No special characters or letters are allowed.");
                        pg.Close();
                        txtContactNumber.Text = "";
                        txtContactNumber.Select();
                    }
                    else if (txtContactNumber.Text.All(allowedcharforcontact.Contains) && lblNameVerified.Visible == true) //Pag may digits and goods yung all char, and verified na
                    {
                        using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (myConn.State == ConnectionState.Closed)
                            { myConn.Open(); }
                            SqlCommand SelectCommand = new SqlCommand(" Select * from ProfessorsTable where Contact_Number = '" + txtContactNumber.Text + "'", myConn);
                            SqlDataReader dr;
                            dr = SelectCommand.ExecuteReader();
                            string cnum = string.Empty;
                            while (dr.Read())
                            {
                                cnum = dr["Contact_Number"].ToString();
                            }
                            if (txtContactNumber.Text == cnum && txtContactNumberDummy.Text != txtContactNumber.Text) //Pag yung txtcnum.text is recorded na, tapos != yung dummy sa cnum
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("This contact number is already registered in the database.");
                                pg.Close();
                                txtContactNumber.Text = "";
                                txtContactNumber.Select();
                            }
                            else if (txtContactNumber.Text == cnum && txtContactNumberDummy.Text == txtContactNumber.Text ||
                                txtContactNumber.Text != cnum && txtContactNumberDummy.Text != txtContactNumber.Text)
                            //1st condition - walang binago sa number
                            //2nd confition - new number. wla sa database and ndi same sa txtcnumdummy
                            {
                                db.Execute("ProfessorsTableUpdate", new
                                {
                                    ID = obj.ID,
                                    Professor = obj.Professor,
                                    Contact_Number = obj.Contact_Number
                                }, commandType: CommandType.StoredProcedure);

                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("Contact information was successfully updated.");
                                pg.Close();
                                btnUpdate.Visible = false;
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnDelete.Visible = true;
                                btnImport.Visible = true;
                                btnExport.Visible = true;
                                line1.Visible = true;
                                txtProfessorDummy.Text = "";
                                txtContactNumberDummy.Text = "";
                                btnChangeName.Visible = false;
                                btnVerifyName.Visible = true;
                                Clear();
                                EZE_FacultyInformation_Load(sender, e);
                                professorsClassBindingSource.MoveFirst();
                                metroGrid.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region VERIFY PROF NAME
        private void btnVerifyName_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,. "; //Char allowed sa txtProfessor
            if (string.IsNullOrWhiteSpace(txtProfessor.Text)) //Pag blanko
            {
                Validation.showdialog("Professor's name is required.");
                txtProfessor.Text = "";
                txtProfessor.Select();
            }
            else if (!txtProfessor.Text.All(allowedcharforname.Contains) && !string.IsNullOrWhiteSpace(txtProfessor.Text)) //Pag di blank pero invalid yung char input
            {
                Validation.showdialog("No special characters or digits are allowed.");
                txtProfessor.Text = "";
                txtProfessor.Select();
            }
            else
            {
                if (objState == EntityState.Added)
                {
                    txtProfessor.Text = Regex.Replace(txtProfessor.Text, "\\s+", " ").Trim(); //remove whitespaces infront and back of textbox
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand SelectCommand = new SqlCommand(" Select * from ProfessorsTable where Professor ='" + txtProfessor.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                        SqlDataReader dr;
                        dr = SelectCommand.ExecuteReader();
                        string prof = string.Empty;
                        while (dr.Read())
                        {
                            prof = dr["Professor"].ToString();
                        }
                        if (txtProfessor.Text == prof)
                        {
                            Validation.showdialog("This name is already registered in the database.");
                            txtProfessor.Text = "";
                            txtProfessor.Select();
                        }
                        else
                        {
                            btnVerifyName.Visible = false;
                            lblNameVerified.Visible = true;
                            txtContactNumber.Enabled = true;
                            txtProfessor.Enabled = false;
                            txtContactNumber.Select();
                        }
                    }
                }
                else if (objState == EntityState.Changed)
                {
                    txtProfessor.Text = Regex.Replace(txtProfessor.Text, "\\s+", " ").Trim(); //remove whitespaces infront and back of textbox
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand SelectCommand = new SqlCommand(" Select * from ProfessorsTable where Professor ='" + txtProfessor.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS", myConn);
                        SqlDataReader dr;
                        dr = SelectCommand.ExecuteReader();
                        string prof = string.Empty;
                        while (dr.Read())
                        {
                            prof = dr["Professor"].ToString();
                        }
                        if (txtProfessorDummy.Text == txtProfessor.Text)
                        {
                            if (Validation.showdialog("This is currently your recorded name in the database. Do you want to change it?") == DialogResult.Yes)
                            {
                                txtProfessor.Text = "";
                                txtProfessor.Select();
                                //Continue dito hanggang maverify yung name                               
                            }
                            else
                            {
                                lblNameVerified.Visible = true;
                                btnVerifyName.Visible = false;
                                txtProfessor.Enabled = false;
                                txtContactNumber.Select();
                                txtContactNumber.Select(txtContactNumber.Text.Length, 0); //Set focus at the end of textbox
                                //Cut na dito. Update button na next                              
                            }
                        }
                        else if (txtProfessor.Text == prof) //Pag want palitan yung name pero may record na sa database
                        {
                            Validation.showdialog("This name is already registered in the database.");
                            txtProfessor.Text = "";
                            txtProfessor.Select();
                        }
                        else if (txtProfessor.Text != prof) //Pag want palitan yung name and no record sa database
                        {
                            lblNameVerified.Visible = true;
                            btnVerifyName.Visible = false;
                            txtProfessor.Enabled = false;
                            txtContactNumber.Select();
                            txtContactNumber.Select(txtContactNumber.Text.Length, 0); //Set focus at the end of textbox
                            //Cut na dito. Update button na next
                        }
                    }
                }
            }
            pg.Close();
        }




        #endregion

        #region IMPORT BUTTON
        private void btnImport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            EZE_ImportExcelFile ief = new EZE_ImportExcelFile();
            ief.ShowDialog();
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

        #region EXTRAS
        private void txtProfessor_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelContactDetails.Visible = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion
    }
}
