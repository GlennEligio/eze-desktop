using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZE.ADO.NetModels;
using EZE.Properties;
using MetroFramework.Controls;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using System.Linq.Dynamic;

namespace EZE
{
    public partial class EZE_StudentsDatabase : Form
    {
        //~EZE_StudentsDatabase()
        //{
        //    //breakpoint here                    
        //}
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

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse
);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);




        const int WM_PARENTNOTIFY = 0x0210;
        const int WM_LBUTTONDOWN = 0x0201;
        int ID = 0;
        private EZEEntities2 context;
        private EZEEntities context1;
        private string yearlevel;
        public static string SetTextForl13 = "";
        public static string SetTextForStudentNumber = "";
        public static string SetTextForFullName = "";
        public static string SetTextForYearandSection = "";
        public static string SetTextForYearLevel = "";
        public static string SetTextForLabel1 = "";
        public static string SetTextForLabel2 = "";
        public static string SetTextForLabel3 = "";
        public static string SetTextForLabel4 = "";
        public static string SetTextForLabel5 = "";
        public static string SetTextForLabel6 = "";
        public static string SetTextForLabel7 = "";
        public static string SetTextForLabel8 = "";
        public static string SetTextForLabel9 = "";
        public static Image SetTextForLabel10 = null;
        public static EZE_StudentsDatabase _instance;
        public MetroLink Fprinregee
        {
            get { return Fprintreg; }
            set { Fprintreg = value; }
        }
        public MetroLink btnEnrollee
        {
            get { return btnEnroll; }
            set { btnEnroll = value; }
        }
        public MyGunaButton btnCancelee
        {
            get { return btnCancel; }
            set { btnCancel = value; }
        }
        public MetroTextBox txtFNameee
        {
            get { return txtFName; }
            set { txtFName = value; }
        }
        public MetroTextBox txtYasee
        {
            get { return txtYaS; }
            set { txtYaS = value; }
        }       
        public EZE_StudentsDatabase()
        {
            InitializeComponent();
            _instance = this;
            Size = new Size(988, 540);
            datetime.Start();
            pic.AllowDrop = true;
            metroTabControl1.SelectedTab = allyearlevel;
            metroGrid1.Columns[2].Visible = false; metroGrid2.Columns[2].Visible = false; metroGrid3.Columns[2].Visible = false;
            metroGrid4.Columns[2].Visible = false; metroGrid5.Columns[2].Visible = false; metroGrid6.Columns[2].Visible = false; //Column year level not visible
            metroGrid1.Columns[10].Visible = false; metroGrid2.Columns[10].Visible = false; metroGrid3.Columns[10].Visible = false;
            metroGrid4.Columns[10].Visible = false; metroGrid5.Columns[10].Visible = false; metroGrid6.Columns[10].Visible = false; //Column image location not visible
            //   SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //_instance.Click += new EventHandler(OnClick);
            metroGrid1.RowHeadersVisible = true; metroGrid2.RowHeadersVisible = true; metroGrid3.RowHeadersVisible = true;
            metroGrid4.RowHeadersVisible = true; metroGrid5.RowHeadersVisible = true; metroGrid6.RowHeadersVisible = true;
        }

        #region DATE AND TIME
        private void datetime_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lbldatetime.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        #endregion

        #region USER SETTINGS      
        public static void getsettings1()
        {
            _instance.s11.Visible = Settings.Default.b11; _instance.s12.Visible = Settings.Default.b12;
            _instance.s13.Visible = Settings.Default.b13; _instance.s14.Visible = Settings.Default.b14;
            _instance.s15.Visible = Settings.Default.b15; _instance.s11p.Visible = Settings.Default.b11p;
        }
        public static void getsettings2()
        {
            _instance.s21.Visible = Settings.Default.b21; _instance.s22.Visible = Settings.Default.b22;
            _instance.s23.Visible = Settings.Default.b23; _instance.s24.Visible = Settings.Default.b24;
            _instance.s25.Visible = Settings.Default.b25; _instance.s21p.Visible = Settings.Default.b21p;
        }
        public static void getsettings3()
        {
            _instance.s31.Visible = Settings.Default.b31; _instance.s32.Visible = Settings.Default.b32;
            _instance.s33.Visible = Settings.Default.b33; _instance.s34.Visible = Settings.Default.b34;
            _instance.s35.Visible = Settings.Default.b35; _instance.s31p.Visible = Settings.Default.b31p;
        }
        public static void getsettings4()
        {
            _instance.s41.Visible = Settings.Default.b41; _instance.s42.Visible = Settings.Default.b42;
            _instance.s43.Visible = Settings.Default.b43; _instance.s44.Visible = Settings.Default.b44;
            _instance.s45.Visible = Settings.Default.b45; _instance.s41p.Visible = Settings.Default.b41p;
        }
        public static void getsettings5()
        {
            _instance.s51.Visible = Settings.Default.b51; _instance.s52.Visible = Settings.Default.b52;
            _instance.s53.Visible = Settings.Default.b53; _instance.s54.Visible = Settings.Default.b54;
            _instance.s55.Visible = Settings.Default.b55; _instance.s51p.Visible = Settings.Default.b51p;
        }
        public static void getsettings6()
        { _instance.cmbAcademicYear.Text = Settings.Default.cmb; }

        public static void savesettings1()
        {
            Settings.Default.b11 = _instance.s11.Visible.Equals(true); Settings.Default.b12 = _instance.s12.Visible.Equals(true);
            Settings.Default.b13 = _instance.s13.Visible.Equals(true); Settings.Default.b14 = _instance.s14.Visible.Equals(true);
            Settings.Default.b15 = _instance.s15.Visible.Equals(true); Settings.Default.b11p = _instance.s11p.Visible.Equals(true);
            Settings.Default.Save();
        }
        public static void savesettings2()
        {
            Settings.Default.b21 = _instance.s21.Visible.Equals(true); Settings.Default.b22 = _instance.s22.Visible.Equals(true);
            Settings.Default.b23 = _instance.s23.Visible.Equals(true); Settings.Default.b24 = _instance.s24.Visible.Equals(true);
            Settings.Default.b25 = _instance.s25.Visible.Equals(true); Settings.Default.b21p = _instance.s21p.Visible.Equals(true);
            Settings.Default.Save();
        }
        public static void savesettings3()
        {
            Settings.Default.b31 = _instance.s31.Visible.Equals(true); Settings.Default.b32 = _instance.s32.Visible.Equals(true);
            Settings.Default.b33 = _instance.s33.Visible.Equals(true); Settings.Default.b34 = _instance.s34.Visible.Equals(true);
            Settings.Default.b35 = _instance.s35.Visible.Equals(true); Settings.Default.b31p = _instance.s31p.Visible.Equals(true);
            Settings.Default.Save();
        }
        public static void savesettings4()
        {
            Settings.Default.b41 = _instance.s41.Visible.Equals(true); Settings.Default.b42 = _instance.s42.Visible.Equals(true);
            Settings.Default.b43 = _instance.s43.Visible.Equals(true); Settings.Default.b44 = _instance.s44.Visible.Equals(true);
            Settings.Default.b45 = _instance.s45.Visible.Equals(true); Settings.Default.b41p = _instance.s41p.Visible.Equals(true);
            Settings.Default.Save();
        }
        public static void savesettings5()
        {
            Settings.Default.b51 = _instance.s51.Visible.Equals(true); Settings.Default.b52 = _instance.s52.Visible.Equals(true);
            Settings.Default.b53 = _instance.s53.Visible.Equals(true); Settings.Default.b54 = _instance.s54.Visible.Equals(true);
            Settings.Default.b55 = _instance.s55.Visible.Equals(true); Settings.Default.b51p = _instance.s51p.Visible.Equals(true);
            Settings.Default.Save();
        }     
        #endregion

        #region SELECT OR DRAG AND DROP AN IMAGE
        EntityState objState = EntityState.Unchanged;
        private void pic_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            { return; }
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pic.Image = Image.FromFile(ofd.FileName);
                        StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                        if (obj != null)
                        { obj.Image_Location = ofd.FileName; }
                    }
                }
                //Check textboxes kung may laman and assign a focus
                if (lblStudentNumberVerified.Visible == true && objState == EntityState.Added)
                {
                    if (string.IsNullOrWhiteSpace(txtFName.Text))
                    { txtFName.Select(); }
                    else if (string.IsNullOrEmpty(txtYaS.Text))
                    { txtYaS.Select(); }
                    else if (string.IsNullOrEmpty(txtCNum.Text))
                    { txtCNum.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtBday.Text))
                    { txtBday.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    { txtAddress.Select(); }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    { txtEmail.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                    { txtGuardian.Select(); }
                    else if (string.IsNullOrEmpty(txtGCNum.Text))
                    { txtGCNum.Select(); }
                }
                else if (lblStudentNumberVerified.Visible == true && objState == EntityState.Changed)
                {
                    if (string.IsNullOrEmpty(txtYaS.Text))
                    { txtYaS.Select(); }
                    else if (string.IsNullOrEmpty(txtCNum.Text))
                    { txtCNum.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtBday.Text))
                    { txtBday.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    { txtAddress.Select(); }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    { txtEmail.Select(); }
                    else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                    { txtGuardian.Select(); }
                    else if (string.IsNullOrEmpty(txtGCNum.Text))
                    { txtGCNum.Select(); }
                }
            }
        }
        private void pic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }
        }
        private void pic_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string picture in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                //Drag image to view in picturebox
                Image img = Image.FromFile(picture);
                pic.Image = img;
                StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                if (obj != null)
                { obj.Image_Location = picture; }
            }
        }
        #endregion

        #region ADD SECTION
        private void add1_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (!s11.Visible || !s12.Visible || !s13.Visible || !s14.Visible || !s15.Visible || !s11p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to add a section to this year level. Continue?") == DialogResult.Yes)
                {
                    if (!s11.Visible)
                    { s11.Visible = true; savesettings1(); }
                    else if (!s12.Visible)
                    { s12.Visible = true; savesettings1(); }
                    else if (!s13.Visible)
                    { s13.Visible = true; savesettings1(); }
                    else if (!s14.Visible)
                    { s14.Visible = true; savesettings1(); }
                    else if (!s15.Visible)
                    { s15.Visible = true; savesettings1(); }
                    else if (!s11p.Visible)
                    { s11p.Visible = true; savesettings1(); }
                }
            }
            else if (s11.Visible && s12.Visible && s13.Visible && s14.Visible && s15.Visible && s11p.Visible)
            { messagebox2.showdialog("You already entered the maximum number of sections."); }
            pg.Close();
        }
        private void add2_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (!s21.Visible || !s22.Visible || !s23.Visible || !s24.Visible || !s25.Visible || !s21p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to add a section to this year level. Continue?") == DialogResult.Yes)
                {
                    if (!s21.Visible)
                    { s21.Visible = true; savesettings2(); }
                    else if (!s22.Visible)
                    { s22.Visible = true; savesettings2(); }
                    else if (!s23.Visible)
                    { s23.Visible = true; savesettings2(); }
                    else if (!s24.Visible)
                    { s24.Visible = true; savesettings2(); }
                    else if (!s25.Visible)
                    { s25.Visible = true; savesettings2(); }
                    else if (!s21p.Visible)
                    { s21p.Visible = true; savesettings2(); }
                }
            }
            else if (s21.Visible && s22.Visible && s23.Visible && s24.Visible && s25.Visible && s21p.Visible)
            { messagebox2.showdialog("You already entered the maximum number of sections."); }
            pg.Close();
        }
        private void add3_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (!s31.Visible || !s32.Visible || !s33.Visible || !s34.Visible || !s35.Visible || !s31p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to add a section to this year level. Continue?") == DialogResult.Yes)
                {
                    if (!s31.Visible)
                    { s31.Visible = true; savesettings3(); }
                    else if (!s32.Visible)
                    { s32.Visible = true; savesettings3(); }
                    else if (!s33.Visible)
                    { s33.Visible = true; savesettings3(); }
                    else if (!s34.Visible)
                    { s34.Visible = true; savesettings3(); }
                    else if (!s35.Visible)
                    { s35.Visible = true; savesettings3(); }
                    else if (!s31p.Visible)
                    { s31p.Visible = true; savesettings3(); }
                }
            }
            else if (s31.Visible && s32.Visible && s33.Visible && s34.Visible && s35.Visible && s31p.Visible)
            { messagebox2.showdialog("You already entered the maximum number of sections."); }
            pg.Close();
        }
        private void add4_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (!s41.Visible || !s42.Visible || !s43.Visible || !s44.Visible || !s45.Visible || !s41p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to add a section to this year level. Continue?") == DialogResult.Yes)
                {
                    if (!s41.Visible)
                    { s41.Visible = true; savesettings4(); }
                    else if (!s42.Visible)
                    { s42.Visible = true; savesettings4(); }
                    else if (!s43.Visible)
                    { s43.Visible = true; savesettings4(); }
                    else if (!s44.Visible)
                    { s44.Visible = true; savesettings4(); }
                    else if (!s45.Visible)
                    { s45.Visible = true; savesettings4(); }
                    else if (!s41p.Visible)
                    { s41p.Visible = true; savesettings4(); }
                }
            }
            else if (s41.Visible && s42.Visible && s43.Visible && s44.Visible && s45.Visible && s41p.Visible)
            { messagebox2.showdialog("You already entered the maximum number of sections."); }
            pg.Close();
        }
        private void add5_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (!s51.Visible || !s52.Visible || !s53.Visible || !s54.Visible || !s55.Visible || !s51p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to add a section to this year level. Continue?") == DialogResult.Yes)
                {
                    if (!s51.Visible)
                    { s51.Visible = true; savesettings5(); }
                    else if (!s52.Visible)
                    { s52.Visible = true; savesettings5(); }
                    else if (!s53.Visible)
                    { s53.Visible = true; savesettings5(); }
                    else if (!s54.Visible)
                    { s54.Visible = true; savesettings5(); }
                    else if (!s55.Visible)
                    { s55.Visible = true; savesettings5(); }
                    else if (!s51p.Visible)
                    { s51p.Visible = true; savesettings5(); }
                }
            }
            else if (s51.Visible && s52.Visible && s53.Visible && s54.Visible && s55.Visible && s51p.Visible)
            { messagebox2.showdialog("You already entered the maximum number of sections."); }
            pg.Close();
        }
        #endregion

        #region REMOVE SECTION
        private void remove1_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (s11p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s11p.Visible = false; p11p.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-1P'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s15.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s15.Visible = false; p15.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-5'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s14.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s14.Visible = false; p14.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-4'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s13.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s13.Visible = false; p13.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-3'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s12.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s12.Visible = false; p12.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-2'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s11.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s11.Visible = false; p11.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '1-1'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings1();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (!s11.Visible && !s12.Visible && !s13.Visible && !s14.Visible && !s15.Visible && !s11p.Visible)
            {
                messagebox2.showdialog("No section available.");
            }
            pg.Close();
        }
        private void remove2_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (s21p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s21p.Visible = false; p21p.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-1P'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s25.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s25.Visible = false; p25.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-5'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s24.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s24.Visible = false; p24.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-4'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s23.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s23.Visible = false; p23.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-3'", commandType: CommandType.Text);
                            if (result != 0)
                            {  studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s22.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s22.Visible = false; p22.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-2'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s21.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s21.Visible = false; p21.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '2-1'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings2();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (!s21.Visible && !s22.Visible && !s23.Visible && !s24.Visible && !s25.Visible && !s21p.Visible)
            {
                messagebox2.showdialog("No section available.");
            }
            pg.Close();
        }
        private void remove3_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (s31p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s31p.Visible = false; p31p.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-1P'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s35.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s35.Visible = false; p35.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-5'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s34.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s34.Visible = false; p34.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-4'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s33.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s33.Visible = false; p33.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-3'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s32.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s32.Visible = false; p32.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-2'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s31.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s31.Visible = false; p31.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            {  db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '3-1'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings3();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (!s31.Visible && !s32.Visible && !s33.Visible && !s34.Visible && !s35.Visible && !s31p.Visible)
            {
                messagebox2.showdialog("No section available.");
            }
            pg.Close();

        }
        private void remove4_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (s41p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s41p.Visible = false; p41p.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-1P'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s45.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s45.Visible = false; p45.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-5'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s44.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s44.Visible = false; p44.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-4'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s43.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s43.Visible = false; p43.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-3'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }

                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");

                }
            }
            else if (s42.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s42.Visible = false; p42.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-2'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");

                }
            }
            else if (s41.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s41.Visible = false; p41.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '4-1'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings4();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (!s41.Visible && !s42.Visible && !s43.Visible && !s44.Visible && !s45.Visible && !s41p.Visible)
            {
                messagebox2.showdialog("No section available.");
            }
            pg.Close();
        }
        private void remove5_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (s51p.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s51p.Visible = false; p51p.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-1P'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                        savesettings5();
                        studentsClassBindingSource.MoveFirst();
                        metroTabControl1_SelectedIndexChanged(sender, e);
                        Cursor.Current = Cursors.Default;
                        messagebox2.showdialog("Section successfully removed from the database.");
                    }
                }
            }
            else if (s55.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s55.Visible = false; p55.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-5'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings5();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s54.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s54.Visible = false; p54.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-4'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings5();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s53.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s53.Visible = false; p53.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-3'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings5();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s52.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s52.Visible = false; p52.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-2'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings5();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (s51.Visible)
            {
                if (messagebox2.showdialog("You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    s51.Visible = false; p51.Visible = false;
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null || obj == null)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            int result = db.Execute("delete from StudentsTable where Year_and_Section = '5-1'", commandType: CommandType.Text);
                            if (result != 0)
                            { studentsClassBindingSource.Clear(); }
                        }
                    }
                    savesettings5();
                    studentsClassBindingSource.MoveFirst();
                    metroTabControl1_SelectedIndexChanged(sender, e);
                    Cursor.Current = Cursors.Default;
                    messagebox2.showdialog("Section successfully removed from the database.");
                }
            }
            else if (!s51.Visible && !s52.Visible && !s53.Visible && !s54.Visible && !s55.Visible && !s51p.Visible)
            {
                messagebox2.showdialog("No section available.");
            }
            pg.Close();
        }
        #endregion

        #region STUDENTS DATABASE LOAD      
        private void RefreshStudents()
        { 
            getsettings1(); getsettings2(); getsettings3(); getsettings4(); getsettings5(); getsettings6();
            //Load data from database to metrogrid
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable Order By Full_Name", commandType: CommandType.Text);
            }
            //Count overall students - 1st yr up to 5th yr
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Overall registered students : " + rows_count.ToString(); }
            }
        }
        private void StudentsDatabase_Load(object sender, EventArgs e)
        {
            context = new EZEEntities2();
            context1 = new EZEEntities();
            RefreshStudents();                 
        }
        #endregion

        #region SHOWING IMAGE PATH ERROR
        private void FactorInShowingImagePathError()
        {
            StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
            if (obj != null)
            {
                if (obj.Year_Level == "First Year")
                { mrb1.Checked = true; }
                else if (obj.Year_Level == "Second Year")
                { mrb2.Checked = true; }
                else if (obj.Year_Level == "Third Year")
                { mrb3.Checked = true; }
                else if (obj.Year_Level == "Fourth Year")
                { mrb4.Checked = true; }
                else if (obj.Year_Level == "Fifth Year")
                { mrb5.Checked = true; }

                if (!string.IsNullOrEmpty(obj.Image_Location))
                { pic.Image = Image.FromFile(obj.Image_Location); }
            }
        }
        private void FactorInShowingImagePathErrorWithoutCatch()
        {
            try
            { FactorInShowingImagePathError(); }
            catch (Exception)
            {
                //Leave as blank to not throw exception
                //We dont want to detect error here
            }
        }
        private void FactorInShowingImagePathErrorWithCatch()
        {
            try
            { FactorInShowingImagePathError(); }
            catch (Exception ex)
            {
                //Now we want to catch the error
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnwithmars"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand1 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid2.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                    SqlCommand SelectCommand2 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid3.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                    SqlCommand SelectCommand3 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid4.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                    SqlCommand SelectCommand4 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid5.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                    SqlCommand SelectCommand5 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid6.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand1.ExecuteReader(); dr = SelectCommand2.ExecuteReader(); dr = SelectCommand3.ExecuteReader(); dr = SelectCommand4.ExecuteReader(); dr = SelectCommand5.ExecuteReader();
                    string imgloc = string.Empty;
                    string student_number = string.Empty;
                    while (dr.Read())
                    {
                        imgloc = dr["Image_Location"].ToString();
                        student_number = dr["Student_Number"].ToString();
                    }                    
                    if (metroTabControl1.SelectedTab == firstyear)
                    {
                        if (metroGrid2.CurrentRow.Cells[10].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show(SetTextForl13);
                            pg.Close();
                            txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        if (metroGrid3.CurrentRow.Cells[10].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show(SetTextForl13);
                            pg.Close();
                            txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        if (metroGrid4.CurrentRow.Cells[10].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show(SetTextForl13);
                            pg.Close();
                            txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        if (metroGrid5.CurrentRow.Cells[10].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show(SetTextForl13);
                            pg.Close();
                            txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        if (metroGrid6.CurrentRow.Cells[10].Value.ToString() == imgloc)
                        {
                            SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show(SetTextForl13);
                            pg.Close();
                            txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }                    
                }
            }
        }
        #endregion

        #region BINDING 
        
        #region BIND 1ST YEAR      
        private void BinderooWithCatch11() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch11() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch12() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch12() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch13() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch13() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch14() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch14() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch15() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch15() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch11p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch11p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '1-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void Count1stYearAndSection1()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-1'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count1stYearAndSection2()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-2'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count1stYearAndSection3()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-3'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count1stYearAndSection4()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-4'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count1stYearAndSection5()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-5'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count1stYearAndSection1P()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '1-1P'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_countt.ToString(); }
            }
        }
        #endregion
        #region BIND 2ND YEAR
        private void BinderooWithCatch21() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch21() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch22() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch22() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch23() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch23() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch24() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch24() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch25() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch25() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch21p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch21p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '2-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void Count2ndYearAndSection1()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-1'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count2ndYearAndSection2()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-2'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count2ndYearAndSection3()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-3'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count2ndYearAndSection4()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-4'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count2ndYearAndSection5()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-5'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count2ndYearAndSection1P()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '2-1P'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        #endregion
        #region BIND 3RD YEAR
        private void BinderooWithCatch31() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch31() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch32() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch32() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch33() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch33() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch34() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch34() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch35() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch35() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch31p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch31p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '3-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void Count3rdYearAndSection1()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-1'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count3rdYearAndSection2()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-2'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count3rdYearAndSection3()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-3'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count3rdYearAndSection4()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-4'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count3rdYearAndSection5()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-5'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count3rdYearAndSection1P()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '3-1P'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_countt.ToString(); }
            }
        }
        #endregion
        #region BIND 4TH YEAR
        private void BinderooWithCatch41() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch41() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch42() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch42() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch43() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch43() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch44() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch44() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch45() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch45() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch41p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch41p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '4-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void Count4thYearAndSection1()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-1'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fourth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fourth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count4thYearAndSection2()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-2'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fourth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fourth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count4thYearAndSection3()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-3'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count4thYearAndSection4()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-4'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fourth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fourth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count4thYearAndSection5()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-5'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count4thYearAndSection1P()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '4-1P'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fourth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fourth year registered students : " + rows_countt.ToString(); }
            }
        }
        #endregion
        #region BIND 5TH YEAR
        private void BinderooWithCatch51() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch51() //Section 1
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-1' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch52() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch52() //Section 2
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-2' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch53() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch53() //Section 3
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-3' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch54() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch54() //Section 4
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-4' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch55() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch55() //Section 5
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-5' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void BinderooWithCatch51p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithCatch();
            }
        }
        private void BinderooWithoutCatch51p() //Section 1P
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_and_Section = '5-1P' Order By Full_Name ASC", commandType: CommandType.Text);
                FactorInShowingImagePathErrorWithoutCatch();
            }
        }
        private void Count5thYearAndSection1()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-1'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count5thYearAndSection2()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-2'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count5thYearAndSection3()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-3'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count5thYearAndSection4()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-4'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count5thYearAndSection5()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-5'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        private void Count5thYearAndSection1P()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_and_Section = '5-1P'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                lblNOS.Text = "Number of students : " + rows_count.ToString();
                string sqll = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sqll, myConn);
                int rows_countt = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_countt.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_countt.ToString(); }
            }
        }
        #endregion

        #endregion

        #region CALLING BIND WITH AND WITHOUT CATCH

        #region 1ST YEAR
        private void bind11WithCatch() //For edit
        {
            Count1stYearAndSection1(); BinderooWithCatch11();
        }
        private void bind11WithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection1(); BinderooWithoutCatch11();
        }
        private void bind12WithCatch() //For edit
        {
            Count1stYearAndSection2(); BinderooWithCatch12();
        }
        private void bind12WithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection2(); BinderooWithoutCatch12();
        }
        private void bind13WithCatch() //For edit
        {
            Count1stYearAndSection3(); BinderooWithCatch13();
        }
        private void bind13WithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection3(); BinderooWithoutCatch13();
        }
        private void bind14WithCatch() //For edit
        {
            Count1stYearAndSection4(); BinderooWithCatch14();
        }
        private void bind14WithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection4(); BinderooWithoutCatch14();
        }
        private void bind15WithCatch() //For edit
        {
            Count1stYearAndSection5(); BinderooWithCatch15();
        }
        private void bind15WithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection5(); BinderooWithoutCatch15();
        }
        private void bind11pWithCatch() //For edit
        {
            Count1stYearAndSection1P(); BinderooWithCatch11p();
        }
        private void bind11pWithoutCatch() //For cancel and section click
        {
            Count1stYearAndSection1P(); BinderooWithoutCatch11p();
        }
        #endregion
        #region 2ND YEAR
        private void bind21WithCatch() //For edit
        {
            Count2ndYearAndSection1(); BinderooWithCatch21();
        }
        private void bind21WithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection1(); BinderooWithoutCatch21();
        }
        private void bind22WithCatch() //For edit
        {
            Count2ndYearAndSection2(); BinderooWithCatch22();
        }
        private void bind22WithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection2(); BinderooWithoutCatch22();
        }
        private void bind23WithCatch() //For edit
        {
            Count2ndYearAndSection3(); BinderooWithCatch23();
        }
        private void bind23WithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection3(); BinderooWithoutCatch23();
        }
        private void bind24WithCatch() //For edit
        {
            Count2ndYearAndSection4(); BinderooWithCatch24();
        }
        private void bind24WithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection4(); BinderooWithoutCatch24();
        }
        private void bind25WithCatch() //For edit
        {
            Count2ndYearAndSection5(); BinderooWithCatch25();
        }
        private void bind25WithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection5(); BinderooWithoutCatch25();
        }
        private void bind21pWithCatch() //For edit
        {
            Count2ndYearAndSection1P(); BinderooWithCatch21p();
        }
        private void bind21pWithoutCatch() //For cancel and section click
        {
            Count2ndYearAndSection1P(); BinderooWithoutCatch21p();
        }
        #endregion
        #region 3RD YEAR
        private void bind31WithCatch() //For edit
        {
            Count3rdYearAndSection1(); BinderooWithCatch31();
        }
        private void bind31WithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection1(); BinderooWithoutCatch31();
        }
        private void bind32WithCatch() //For edit
        {
            Count3rdYearAndSection2(); BinderooWithCatch32();
        }
        private void bind32WithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection2(); BinderooWithoutCatch32();
        }
        private void bind33WithCatch() //For edit
        {
            Count3rdYearAndSection3(); BinderooWithCatch33();
        }
        private void bind33WithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection3(); BinderooWithoutCatch33();
        }
        private void bind34WithCatch() //For edit
        {
            Count3rdYearAndSection4(); BinderooWithCatch34();
        }
        private void bind34WithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection4(); BinderooWithoutCatch34();
        }
        private void bind35WithCatch() //For edit
        {
            Count3rdYearAndSection5(); BinderooWithCatch35();
        }
        private void bind35WithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection5(); BinderooWithoutCatch35();
        }
        private void bind31pWithCatch() //For edit
        {
            Count3rdYearAndSection1P(); BinderooWithCatch31p();
        }
        private void bind31pWithoutCatch() //For cancel and section click
        {
            Count3rdYearAndSection1P(); BinderooWithoutCatch31p();
        }
        #endregion
        #region 4TH YEAR
        private void bind41WithCatch() //For edit
        {
            Count4thYearAndSection1(); BinderooWithCatch41();
        }
        private void bind41WithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection1(); BinderooWithoutCatch41();
        }
        private void bind42WithCatch() //For edit
        {
            Count4thYearAndSection2(); BinderooWithCatch42();
        }
        private void bind42WithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection2(); BinderooWithoutCatch42();
        }
        private void bind43WithCatch() //For edit
        {
            Count4thYearAndSection3(); BinderooWithCatch43();
        }
        private void bind43WithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection3(); BinderooWithoutCatch43();
        }
        private void bind44WithCatch() //For edit
        {
            Count4thYearAndSection4(); BinderooWithCatch44();
        }
        private void bind44WithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection4(); BinderooWithoutCatch44();
        }
        private void bind45WithCatch() //For edit
        {
            Count4thYearAndSection5(); BinderooWithCatch45();
        }
        private void bind45WithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection5(); BinderooWithoutCatch45();
        }
        private void bind41pWithCatch() //For edit
        {
            Count4thYearAndSection1P(); BinderooWithCatch41p();
        }
        private void bind41pWithoutCatch() //For cancel and section click
        {
            Count4thYearAndSection1P(); BinderooWithoutCatch41p();
        }
        #endregion
        #region 5TH YEAR
        private void bind51WithCatch() //For edit
        {
            Count5thYearAndSection1(); BinderooWithCatch51();
        }
        private void bind51WithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection1(); BinderooWithoutCatch51();
        }
        private void bind52WithCatch() //For edit
        {
            Count5thYearAndSection2(); BinderooWithCatch52();
        }
        private void bind52WithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection2(); BinderooWithoutCatch52();
        }
        private void bind53WithCatch() //For edit
        {
            Count5thYearAndSection3(); BinderooWithCatch53();
        }
        private void bind53WithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection3(); BinderooWithoutCatch53();
        }
        private void bind54WithCatch() //For edit
        {
            Count5thYearAndSection4(); BinderooWithCatch54();
        }
        private void bind54WithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection4(); BinderooWithoutCatch54();
        }
        private void bind55WithCatch() //For edit
        {
            Count5thYearAndSection5(); BinderooWithCatch55();
        }
        private void bind55WithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection5(); BinderooWithoutCatch55();
        }
        private void bind51pWithCatch() //For edit
        {
            Count5thYearAndSection1P(); BinderooWithCatch51p();
        }
        private void bind51pWithoutCatch() //For cancel and section click
        {
            Count5thYearAndSection1P(); BinderooWithoutCatch51p();
        }
        #endregion

        #endregion

        #region SECTIONS BUTTTON CLICK (1st Year - 5th Year)

        #region FIRST YEAR
        private void s11_Click(object sender, EventArgs e)
        {
            p11.Visible = true; p12.Visible = false; p13.Visible = false; p14.Visible = false; p15.Visible = false; p11p.Visible = false;
            s11.ForeColor = Color.FromArgb(0, 174, 219); s12.ForeColor = Color.FromArgb(128, 128, 128); s13.ForeColor = Color.FromArgb(128, 128, 128);
            s14.ForeColor = Color.FromArgb(128, 128, 128); s15.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind11WithoutCatch();
        }
        private void s12_Click(object sender, EventArgs e)
        {
            p12.Visible = true; p11.Visible = false; p13.Visible = false; p14.Visible = false; p15.Visible = false; p11p.Visible = false;
            s12.ForeColor = Color.FromArgb(0, 174, 219); s11.ForeColor = Color.FromArgb(128, 128, 128); s13.ForeColor = Color.FromArgb(128, 128, 128);
            s14.ForeColor = Color.FromArgb(128, 128, 128); s15.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind12WithoutCatch();
        }
        private void s13_Click(object sender, EventArgs e)
        {
            p13.Visible = true; p11.Visible = false; p12.Visible = false; p14.Visible = false; p15.Visible = false; p11p.Visible = false;
            s13.ForeColor = Color.FromArgb(0, 174, 219); s11.ForeColor = Color.FromArgb(128, 128, 128); s12.ForeColor = Color.FromArgb(128, 128, 128);
            s14.ForeColor = Color.FromArgb(128, 128, 128); s15.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind13WithoutCatch();
        }
        private void s14_Click(object sender, EventArgs e)
        {
            p14.Visible = true; p11.Visible = false; p12.Visible = false; p13.Visible = false; p15.Visible = false; p11p.Visible = false;
            s14.ForeColor = Color.FromArgb(0, 174, 219); s11.ForeColor = Color.FromArgb(128, 128, 128); s12.ForeColor = Color.FromArgb(128, 128, 128);
            s13.ForeColor = Color.FromArgb(128, 128, 128); s15.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind14WithoutCatch();
        }
        private void s15_Click(object sender, EventArgs e)
        {
            p15.Visible = true; p11.Visible = false; p12.Visible = false; p13.Visible = false; p14.Visible = false; p11p.Visible = false;
            s15.ForeColor = Color.FromArgb(0, 174, 219); s11.ForeColor = Color.FromArgb(128, 128, 128); s12.ForeColor = Color.FromArgb(128, 128, 128);
            s13.ForeColor = Color.FromArgb(128, 128, 128); s14.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind15WithoutCatch();
        }
        private void s11p_Click(object sender, EventArgs e)
        {
            p11p.Visible = true; p11.Visible = false; p12.Visible = false; p13.Visible = false; p14.Visible = false; p15.Visible = false;
            s11p.ForeColor = Color.FromArgb(0, 174, 219); s11.ForeColor = Color.FromArgb(128, 128, 128); s12.ForeColor = Color.FromArgb(128, 128, 128);
            s13.ForeColor = Color.FromArgb(128, 128, 128); s14.ForeColor = Color.FromArgb(128, 128, 128); s15.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind11pWithoutCatch();
        }
        #endregion
        #region SECOND YEAR
        private void s21_Click(object sender, EventArgs e)
        {
            p21.Visible = true; p22.Visible = false; p23.Visible = false; p24.Visible = false; p25.Visible = false; p21p.Visible = false;
            s21.ForeColor = Color.FromArgb(0, 174, 219); s22.ForeColor = Color.FromArgb(128, 128, 128); s23.ForeColor = Color.FromArgb(128, 128, 128);
            s24.ForeColor = Color.FromArgb(128, 128, 128); s25.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind21WithoutCatch();
        }
        private void s22_Click(object sender, EventArgs e)
        {
            p22.Visible = true; p21.Visible = false; p23.Visible = false; p24.Visible = false; p25.Visible = false; p21p.Visible = false;
            s22.ForeColor = Color.FromArgb(0, 174, 219); s21.ForeColor = Color.FromArgb(128, 128, 128); s23.ForeColor = Color.FromArgb(128, 128, 128);
            s24.ForeColor = Color.FromArgb(128, 128, 128); s25.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind22WithoutCatch();
        }
        private void s23_Click(object sender, EventArgs e)
        {
            p23.Visible = true; p21.Visible = false; p22.Visible = false; p24.Visible = false; p25.Visible = false; p21p.Visible = false;
            s23.ForeColor = Color.FromArgb(0, 174, 219); s21.ForeColor = Color.FromArgb(128, 128, 128); s22.ForeColor = Color.FromArgb(128, 128, 128);
            s24.ForeColor = Color.FromArgb(128, 128, 128); s25.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind23WithoutCatch();
        }
        private void s24_Click(object sender, EventArgs e)
        {
            p24.Visible = true; p21.Visible = false; p22.Visible = false; p23.Visible = false; p25.Visible = false; p21p.Visible = false;
            s24.ForeColor = Color.FromArgb(0, 174, 219); s21.ForeColor = Color.FromArgb(128, 128, 128); s22.ForeColor = Color.FromArgb(128, 128, 128);
            s23.ForeColor = Color.FromArgb(128, 128, 128); s25.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind24WithoutCatch();
        }
        private void s25_Click(object sender, EventArgs e)
        {
            p25.Visible = true; p21.Visible = false; p22.Visible = false; p23.Visible = false; p24.Visible = false; p21p.Visible = false;
            s25.ForeColor = Color.FromArgb(0, 174, 219); s21.ForeColor = Color.FromArgb(128, 128, 128); s22.ForeColor = Color.FromArgb(128, 128, 128);
            s23.ForeColor = Color.FromArgb(128, 128, 128); s24.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind25WithoutCatch();
        }
        private void s21p_Click(object sender, EventArgs e)
        {
            p21p.Visible = true; p21.Visible = false; p22.Visible = false; p23.Visible = false; p24.Visible = false; p25.Visible = false;
            s21p.ForeColor = Color.FromArgb(0, 174, 219); s21.ForeColor = Color.FromArgb(128, 128, 128); s22.ForeColor = Color.FromArgb(128, 128, 128);
            s23.ForeColor = Color.FromArgb(128, 128, 128); s24.ForeColor = Color.FromArgb(128, 128, 128); s25.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind21pWithoutCatch();
        }
        #endregion
        #region THIRD YEAR
        private void s31_Click(object sender, EventArgs e)
        {
            p31.Visible = true; p32.Visible = false; p33.Visible = false; p34.Visible = false; p35.Visible = false; p31p.Visible = false;
            s31.ForeColor = Color.FromArgb(0, 174, 219); s32.ForeColor = Color.FromArgb(128, 128, 128); s33.ForeColor = Color.FromArgb(128, 128, 128);
            s34.ForeColor = Color.FromArgb(128, 128, 128); s35.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind31WithoutCatch();
        }
        private void s32_Click(object sender, EventArgs e)
        {
            p32.Visible = true; p31.Visible = false; p33.Visible = false; p34.Visible = false; p35.Visible = false; p31p.Visible = false;
            s32.ForeColor = Color.FromArgb(0, 174, 219); s31.ForeColor = Color.FromArgb(128, 128, 128); s33.ForeColor = Color.FromArgb(128, 128, 128);
            s34.ForeColor = Color.FromArgb(128, 128, 128); s35.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind32WithoutCatch();
        }
        private void s33_Click(object sender, EventArgs e)
        {
            p33.Visible = true; p31.Visible = false; p32.Visible = false; p34.Visible = false; p35.Visible = false; p31p.Visible = false;
            s33.ForeColor = Color.FromArgb(0, 174, 219); s31.ForeColor = Color.FromArgb(128, 128, 128); s32.ForeColor = Color.FromArgb(128, 128, 128);
            s34.ForeColor = Color.FromArgb(128, 128, 128); s35.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind33WithoutCatch();
        }
        private void s34_Click(object sender, EventArgs e)
        {
            p34.Visible = true; p31.Visible = false; p32.Visible = false; p33.Visible = false; p35.Visible = false; p31p.Visible = false;
            s34.ForeColor = Color.FromArgb(0, 174, 219); s31.ForeColor = Color.FromArgb(128, 128, 128); s32.ForeColor = Color.FromArgb(128, 128, 128);
            s33.ForeColor = Color.FromArgb(128, 128, 128); s35.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind34WithoutCatch();
        }
        private void s35_Click(object sender, EventArgs e)
        {
            p35.Visible = true; p31.Visible = false; p32.Visible = false; p33.Visible = false; p34.Visible = false; p31p.Visible = false;
            s35.ForeColor = Color.FromArgb(0, 174, 219); s31.ForeColor = Color.FromArgb(128, 128, 128); s32.ForeColor = Color.FromArgb(128, 128, 128);
            s33.ForeColor = Color.FromArgb(128, 128, 128); s34.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind35WithoutCatch();
        }
        private void s31p_Click(object sender, EventArgs e)
        {
            p31p.Visible = true; p31.Visible = false; p32.Visible = false; p33.Visible = false; p34.Visible = false; p35.Visible = false;
            s31p.ForeColor = Color.FromArgb(0, 174, 219); s31.ForeColor = Color.FromArgb(128, 128, 128); s32.ForeColor = Color.FromArgb(128, 128, 128);
            s33.ForeColor = Color.FromArgb(128, 128, 128); s34.ForeColor = Color.FromArgb(128, 128, 128); s35.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind31pWithoutCatch();
        }
        #endregion
        #region FOURTH YEAR
        private void s41_Click(object sender, EventArgs e)
        {
            p41.Visible = true; p42.Visible = false; p43.Visible = false; p44.Visible = false; p45.Visible = false; p41p.Visible = false;
            s41.ForeColor = Color.FromArgb(0, 174, 219); s42.ForeColor = Color.FromArgb(128, 128, 128); s43.ForeColor = Color.FromArgb(128, 128, 128);
            s44.ForeColor = Color.FromArgb(128, 128, 128); s45.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind41WithoutCatch();
        }
        private void s42_Click(object sender, EventArgs e)
        {
            p42.Visible = true; p41.Visible = false; p43.Visible = false; p44.Visible = false; p45.Visible = false; p41p.Visible = false;
            s42.ForeColor = Color.FromArgb(0, 174, 219); s41.ForeColor = Color.FromArgb(128, 128, 128); s43.ForeColor = Color.FromArgb(128, 128, 128);
            s44.ForeColor = Color.FromArgb(128, 128, 128); s45.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind42WithoutCatch();
        }
        private void s43_Click(object sender, EventArgs e)
        {
            p43.Visible = true; p41.Visible = false; p42.Visible = false; p44.Visible = false; p45.Visible = false; p41p.Visible = false;
            s43.ForeColor = Color.FromArgb(0, 174, 219); s41.ForeColor = Color.FromArgb(128, 128, 128); s42.ForeColor = Color.FromArgb(128, 128, 128);
            s44.ForeColor = Color.FromArgb(128, 128, 128); s45.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind43WithoutCatch();
        }
        private void s44_Click(object sender, EventArgs e)
        {
            p44.Visible = true; p41.Visible = false; p42.Visible = false; p43.Visible = false; p45.Visible = false; p41p.Visible = false;
            s44.ForeColor = Color.FromArgb(0, 174, 219); s41.ForeColor = Color.FromArgb(128, 128, 128); s42.ForeColor = Color.FromArgb(128, 128, 128);
            s43.ForeColor = Color.FromArgb(128, 128, 128); s45.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind44WithoutCatch();
        }
        private void s45_Click(object sender, EventArgs e)
        {
            p45.Visible = true; p41.Visible = false; p42.Visible = false; p43.Visible = false; p44.Visible = false; p41p.Visible = false;
            s45.ForeColor = Color.FromArgb(0, 174, 219); s41.ForeColor = Color.FromArgb(128, 128, 128); s42.ForeColor = Color.FromArgb(128, 128, 128);
            s43.ForeColor = Color.FromArgb(128, 128, 128); s44.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind45WithoutCatch();
        }
        private void s41p_Click(object sender, EventArgs e)
        {
            p41p.Visible = true; p41.Visible = false; p42.Visible = false; p43.Visible = false; p44.Visible = false; p45.Visible = false;
            s41p.ForeColor = Color.FromArgb(0, 174, 219); s41.ForeColor = Color.FromArgb(128, 128, 128); s42.ForeColor = Color.FromArgb(128, 128, 128);
            s43.ForeColor = Color.FromArgb(128, 128, 128); s44.ForeColor = Color.FromArgb(128, 128, 128); s45.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind41pWithoutCatch();
        }
        #endregion
        #region FIFTH YEAR
        private void s51_Click(object sender, EventArgs e)
        {
            p51.Visible = true; p52.Visible = false; p53.Visible = false; p54.Visible = false; p55.Visible = false; p51p.Visible = false;
            s51.ForeColor = Color.FromArgb(0, 174, 219); s52.ForeColor = Color.FromArgb(128, 128, 128); s53.ForeColor = Color.FromArgb(128, 128, 128);
            s54.ForeColor = Color.FromArgb(128, 128, 128); s55.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind51WithoutCatch();
        }
        private void s52_Click(object sender, EventArgs e)
        {
            p52.Visible = true; p51.Visible = false; p53.Visible = false; p54.Visible = false; p55.Visible = false; p51p.Visible = false;
            s52.ForeColor = Color.FromArgb(0, 174, 219); s51.ForeColor = Color.FromArgb(128, 128, 128); s53.ForeColor = Color.FromArgb(128, 128, 128);
            s54.ForeColor = Color.FromArgb(128, 128, 128); s55.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind52WithoutCatch();
        }
        private void s53_Click(object sender, EventArgs e)
        {
            p53.Visible = true; p51.Visible = false; p52.Visible = false; p54.Visible = false; p55.Visible = false; p51p.Visible = false;
            s53.ForeColor = Color.FromArgb(0, 174, 219); s51.ForeColor = Color.FromArgb(128, 128, 128); s52.ForeColor = Color.FromArgb(128, 128, 128);
            s54.ForeColor = Color.FromArgb(128, 128, 128); s55.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind53WithoutCatch();
        }
        private void s54_Click(object sender, EventArgs e)
        {
            p54.Visible = true; p51.Visible = false; p52.Visible = false; p53.Visible = false; p55.Visible = false; p51p.Visible = false;
            s54.ForeColor = Color.FromArgb(0, 174, 219); s51.ForeColor = Color.FromArgb(128, 128, 128); s52.ForeColor = Color.FromArgb(128, 128, 128);
            s53.ForeColor = Color.FromArgb(128, 128, 128); s55.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind54WithoutCatch();
        }
        private void s55_Click(object sender, EventArgs e)
        {
            p55.Visible = true; p51.Visible = false; p52.Visible = false; p53.Visible = false; p54.Visible = false; p51p.Visible = false;
            s55.ForeColor = Color.FromArgb(0, 174, 219); s51.ForeColor = Color.FromArgb(128, 128, 128); s52.ForeColor = Color.FromArgb(128, 128, 128);
            s53.ForeColor = Color.FromArgb(128, 128, 128); s54.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind55WithoutCatch();
        }
        private void s51p_Click(object sender, EventArgs e)
        {
            p51p.Visible = true; p51.Visible = false; p52.Visible = false; p53.Visible = false; p54.Visible = false; p55.Visible = false;
            s51p.ForeColor = Color.FromArgb(0, 174, 219); s51.ForeColor = Color.FromArgb(128, 128, 128); s52.ForeColor = Color.FromArgb(128, 128, 128);
            s53.ForeColor = Color.FromArgb(128, 128, 128); s54.ForeColor = Color.FromArgb(128, 128, 128); s55.ForeColor = Color.FromArgb(128, 128, 128);
            studentsClassBindingSource.MoveFirst();
            bind51pWithoutCatch();
        }
        #endregion

        #endregion

        #region SELECTED INDEX CHANGED
        public static void mtcSelectedIndexChanged()
        {
            if (_instance.metroTabControl1.SelectedTab == _instance.firstyear)
            {
                _instance.btnOptions.Visible = true;
                _instance.p11.Visible = false; _instance.p12.Visible = false; _instance.p13.Visible = false; _instance.p14.Visible = false; _instance.p15.Visible = false; _instance.p11p.Visible = false;
                _instance.s11.ForeColor = Color.FromArgb(128, 128, 128); _instance.s12.ForeColor = Color.FromArgb(128, 128, 128); _instance.s13.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.s14.ForeColor = Color.FromArgb(128, 128, 128); _instance.s15.ForeColor = Color.FromArgb(128, 128, 128); _instance.s11p.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.studentsClassBindingSource.MoveFirst();
                getsettings1();
                _instance.txtSearch.Text = "";
                _instance.btnAdd.Visible = true; _instance.btnEdit.Visible = true; _instance.btnDelete.Visible = true;
                _instance.panel1.Visible = false; _instance.panel2.Visible = false; _instance.panel3.Visible = false; _instance.panel4.Visible = false; _instance.panel5.Visible = false;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'First Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    _instance.FactorInShowingImagePathErrorWithoutCatch();
                }
                _instance.CountFirstYearRegisteredStudents();
            }
            else if (_instance.metroTabControl1.SelectedTab == _instance.secondyear)
            {
                _instance.btnOptions.Visible = true;
                _instance.p21.Visible = false; _instance.p22.Visible = false; _instance.p23.Visible = false; _instance.p24.Visible = false; _instance.p25.Visible = false; _instance.p21p.Visible = false;
                _instance.s21.ForeColor = Color.FromArgb(128, 128, 128); _instance.s22.ForeColor = Color.FromArgb(128, 128, 128); _instance.s23.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.s24.ForeColor = Color.FromArgb(128, 128, 128); _instance.s25.ForeColor = Color.FromArgb(128, 128, 128); _instance.s21p.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.studentsClassBindingSource.MoveFirst();
                getsettings2();
                _instance.txtSearch.Text = "";
                _instance.btnAdd.Visible = true; _instance.btnEdit.Visible = true; _instance.btnDelete.Visible = true;
                _instance.panel1.Visible = false; _instance.panel2.Visible = false; _instance.panel3.Visible = false; _instance.panel4.Visible = false; _instance.panel5.Visible = false;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Second Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    _instance.FactorInShowingImagePathErrorWithoutCatch();
                }
                _instance.CountSecondYearRegisteredStudents();
            }
            else if (_instance.metroTabControl1.SelectedTab == _instance.thirdyear)
            {
                _instance.btnOptions.Visible = true;
                _instance.p31.Visible = false; _instance.p32.Visible = false; _instance.p33.Visible = false; _instance.p34.Visible = false; _instance.p35.Visible = false; _instance.p31p.Visible = false;
                _instance.s31.ForeColor = Color.FromArgb(128, 128, 128); _instance.s32.ForeColor = Color.FromArgb(128, 128, 128); _instance.s33.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.s34.ForeColor = Color.FromArgb(128, 128, 128); _instance.s35.ForeColor = Color.FromArgb(128, 128, 128); _instance.s31p.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.studentsClassBindingSource.MoveFirst();
                getsettings3();
                _instance.txtSearch.Text = "";
                _instance.btnAdd.Visible = true; _instance.btnEdit.Visible = true; _instance.btnDelete.Visible = true;
                _instance.panel1.Visible = false; _instance.panel2.Visible = false; _instance.panel3.Visible = false; _instance.panel4.Visible = false; _instance.panel5.Visible = false;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Third Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    _instance.FactorInShowingImagePathErrorWithoutCatch();
                }
                _instance.CountThirdYearRegisteredStudents();
            }
            else if (_instance.metroTabControl1.SelectedTab == _instance.fourthyear)
            {
                _instance.btnOptions.Visible = true;
                _instance.p41.Visible = false; _instance.p42.Visible = false; _instance.p43.Visible = false; _instance.p44.Visible = false; _instance.p45.Visible = false; _instance.p41p.Visible = false;
                _instance.s41.ForeColor = Color.FromArgb(128, 128, 128); _instance.s42.ForeColor = Color.FromArgb(128, 128, 128); _instance.s43.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.s44.ForeColor = Color.FromArgb(128, 128, 128); _instance.s45.ForeColor = Color.FromArgb(128, 128, 128); _instance.s41p.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.studentsClassBindingSource.MoveFirst();
                getsettings4();
                _instance.txtSearch.Text = "";
                _instance.btnAdd.Visible = true; _instance.btnEdit.Visible = true; _instance.btnDelete.Visible = true;
                _instance.panel1.Visible = false; _instance.panel2.Visible = false; _instance.panel3.Visible = false; _instance.panel4.Visible = false; _instance.panel5.Visible = false;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fourth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    _instance.FactorInShowingImagePathErrorWithoutCatch();
                }
                _instance.CountFourthYearRegisteredStudents();
            }
            else if (_instance.metroTabControl1.SelectedTab == _instance.fifthyear)
            {
                _instance.btnOptions.Visible = true;
                _instance.p51.Visible = false; _instance.p52.Visible = false; _instance.p53.Visible = false; _instance.p54.Visible = false; _instance.p55.Visible = false; _instance.p51p.Visible = false;
                _instance.s51.ForeColor = Color.FromArgb(128, 128, 128); _instance.s52.ForeColor = Color.FromArgb(128, 128, 128); _instance.s53.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.s54.ForeColor = Color.FromArgb(128, 128, 128); _instance.s55.ForeColor = Color.FromArgb(128, 128, 128); _instance.s51p.ForeColor = Color.FromArgb(128, 128, 128);
                _instance.studentsClassBindingSource.MoveFirst();
                getsettings5();
                _instance.txtSearch.Text = "";
                _instance.btnAdd.Visible = true;
                _instance.btnEdit.Visible = true;
                _instance.btnDelete.Visible = true;
                _instance.panel1.Visible = false; _instance.panel2.Visible = false; _instance.panel3.Visible = false; _instance.panel4.Visible = false; _instance.panel5.Visible = false;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fifth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    _instance.FactorInShowingImagePathErrorWithoutCatch();
                }
                _instance.CountFifthYearRegisteredStudents();
            }
            else if (_instance.metroTabControl1.SelectedTab == _instance.allyearlevel)
            {
                _instance.btnOptions.Visible = false;
                _instance.panelStudentDatabase.Visible = false;
                _instance.txtSearch.Text = "";
                _instance.btnCancel.Visible = false;
                _instance.btnSave.Visible = false;
                _instance.btnUpdate.Visible = false;
                _instance.btnAdd.Visible = false;
                _instance.btnEdit.Visible = false;
                _instance.btnDelete.Visible = false;
                _instance.RefreshStudents();
                _instance.studentsClassBindingSource.MoveFirst();
            }
        }
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        { mtcSelectedIndexChanged(); }
        private void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.cmb = cmbAcademicYear.Text;
            Settings.Default.Save();
        }
        #endregion

        #region REFRESH BUTTON     
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = allyearlevel;
            studentsClassBindingSource.MoveFirst();
            txtSearch.Text = "";
        }       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            studentsClassBindingSource.MoveFirst();
            RefreshYear();
        }
        private void RefreshYear()
        {
            if (metroTabControl1.SelectedTab == firstyear)
            {
                p11.Visible = false; p12.Visible = false; p13.Visible = false;
                p14.Visible = false; p15.Visible = false; p11p.Visible = false;
                s11.ForeColor = Color.FromArgb(128, 128, 128); s12.ForeColor = Color.FromArgb(128, 128, 128);
                s13.ForeColor = Color.FromArgb(128, 128, 128); s14.ForeColor = Color.FromArgb(128, 128, 128);
                s15.ForeColor = Color.FromArgb(128, 128, 128); s11p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'First Year' Order By Full_Name ASC", commandType: CommandType.Text);
                    //StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                }
                CountFirstYearRegisteredStudents();
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                p21.Visible = false; p22.Visible = false; p23.Visible = false;
                p24.Visible = false; p25.Visible = false; p21p.Visible = false;
                s21.ForeColor = Color.FromArgb(128, 128, 128); s22.ForeColor = Color.FromArgb(128, 128, 128);
                s23.ForeColor = Color.FromArgb(128, 128, 128); s24.ForeColor = Color.FromArgb(128, 128, 128);
                s25.ForeColor = Color.FromArgb(128, 128, 128); s21p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Second Year' Order By Full_Name ASC", commandType: CommandType.Text);
                   // StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                }
                CountSecondYearRegisteredStudents();
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                p31.Visible = false; p32.Visible = false; p33.Visible = false;
                p34.Visible = false; p35.Visible = false; p31p.Visible = false;
                s31.ForeColor = Color.FromArgb(128, 128, 128); s32.ForeColor = Color.FromArgb(128, 128, 128);
                s33.ForeColor = Color.FromArgb(128, 128, 128); s34.ForeColor = Color.FromArgb(128, 128, 128);
                s35.ForeColor = Color.FromArgb(128, 128, 128); s31p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Third Year' Order By Full_Name ASC", commandType: CommandType.Text);
                  //  StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                }
                CountThirdYearRegisteredStudents();
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                p41.Visible = false; p42.Visible = false; p43.Visible = false;
                p44.Visible = false; p45.Visible = false; p41p.Visible = false;
                s41.ForeColor = Color.FromArgb(128, 128, 128); s42.ForeColor = Color.FromArgb(128, 128, 128);
                s43.ForeColor = Color.FromArgb(128, 128, 128); s44.ForeColor = Color.FromArgb(128, 128, 128);
                s45.ForeColor = Color.FromArgb(128, 128, 128); s41p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fourth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                   // StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                }
                CountFourthYearRegisteredStudents();
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                p51.Visible = false; p52.Visible = false; p53.Visible = false;
                p54.Visible = false; p55.Visible = false; p51p.Visible = false;
                s51.ForeColor = Color.FromArgb(128, 128, 128); s52.ForeColor = Color.FromArgb(128, 128, 128);
                s53.ForeColor = Color.FromArgb(128, 128, 128); s54.ForeColor = Color.FromArgb(128, 128, 128);
                s55.ForeColor = Color.FromArgb(128, 128, 128); s51p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fifth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                  //  StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                }
                CountFifthYearRegisteredStudents();
            }
        }
        #endregion

        #region MORE OPTIONS
        private void open_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == firstyear)
            {
                if (panel1.Visible == false) { panel1.Visible = true; }
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                if (panel2.Visible == false) { panel2.Visible = true; }
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                if (panel3.Visible == false) { panel3.Visible = true; }
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                if (panel4.Visible == false) { panel4.Visible = true; }
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                if (panel5.Visible == false) { panel5.Visible = true; }
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == firstyear)
            {
                if (panel1.Visible == true) { panel1.Visible = false; }
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                if (panel2.Visible == true) { panel2.Visible = false; }
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                if (panel3.Visible == true) { panel3.Visible = false; }
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                if (panel4.Visible == true) { panel4.Visible = false; }
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                if (panel5.Visible == true) { panel5.Visible = false; }
            }
        }
        #endregion

        #region ADD BUTTON
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            //          MessageBox.Show("OK");
            if (metroTabControl1.SelectedTab == firstyear && Settings.Default.b11.Equals(false) || metroTabControl1.SelectedTab == secondyear && Settings.Default.b21.Equals(false) ||
                metroTabControl1.SelectedTab == thirdyear && Settings.Default.b31.Equals(false) || metroTabControl1.SelectedTab == fourthyear && Settings.Default.b41.Equals(false) ||
                metroTabControl1.SelectedTab == fifthyear && Settings.Default.b51.Equals(false))
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Add first a section to this year level to properly add a student's information.");
                pg.Close();
            }
            else
            {
                btnEnroll.Visible = false;
                Fprintnotreg.Visible = false;
                Fprintreg.Visible = false;
                btnChangeYearLevel.Visible = false;
                lblStudentNumberVerified.Visible = false;
                txtFName.Enabled = true;
                txtYaS.Enabled = true;
                txtSNum.Enabled = true;
                pic.Image = null;
                pnlStudNum.Enabled = true; //Enabled dapat to
                pnlStudReg.Enabled = false;
                btnVerifySNum.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnUpdate.Visible = false;
                //lblNotRegistered.Visible = false;
                mrb1.Enabled = false;
                mrb2.Enabled = false;
                mrb3.Enabled = false;
                mrb4.Enabled = false;
                mrb5.Enabled = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                objState = EntityState.Added;
                studentsClassBindingSource.Add(new StudentsClass());
                studentsClassBindingSource.MoveLast();  //No data sa grid dahil dito
                                                        //Nakacheck na agad kung what year level
                if (metroTabControl1.SelectedIndex == 1)
                { mrb1.Checked = true; }
                else if (metroTabControl1.SelectedIndex == 2)
                { mrb2.Checked = true; }
                else if (metroTabControl1.SelectedIndex == 3)
                { mrb3.Checked = true; }
                else if (metroTabControl1.SelectedIndex == 4)
                { mrb4.Checked = true; }
                else if (metroTabControl1.SelectedIndex == 5)
                { mrb5.Checked = true; }
                txtSNum.Select();
                metroTabControl1.Visible = false;
            }
        }
        #endregion

        #region EDIT BUTTON
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGrid2.Rows.Count > 1 && metroGrid2.SelectedRows.Count > 1 || metroGrid3.Rows.Count > 1 && metroGrid3.SelectedRows.Count > 1 ||
                metroGrid4.Rows.Count > 1 && metroGrid4.SelectedRows.Count > 1 || metroGrid5.Rows.Count > 1 && metroGrid5.SelectedRows.Count > 1 ||
                metroGrid6.Rows.Count > 1 && metroGrid6.SelectedRows.Count > 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Can't edit multiple accounts at once.");
                pg.Close();
            }
            else if (metroGrid2.Rows.Count >= 1 && metroGrid2.SelectedRows.Count == 1 || metroGrid3.Rows.Count >= 1 && metroGrid3.SelectedRows.Count == 1 ||
                metroGrid4.Rows.Count >= 1 && metroGrid4.SelectedRows.Count == 1 || metroGrid5.Rows.Count >= 1 && metroGrid5.SelectedRows.Count == 1 ||
                metroGrid6.Rows.Count >= 1 && metroGrid6.SelectedRows.Count == 1)
            {
                pnlStudReg.Enabled = true;
                pnlStudNum.Enabled = false;
                txtCNum.Select();
                txtCNum.Select(txtCNum.Text.Length, 0); //Set focus at the end of textbox
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;
                btnEnroll.Visible = false;
                txtFName.Enabled = false;
                txtYaS.Enabled = false;
                btnChangeYearLevel.Visible = true;
                btnVerifySNum.Visible = false;
                txtSNum.Enabled = false;
                lblStudentNumberVerified.Visible = true;
                objState = EntityState.Changed;
                pic.Image = null;

                //Show label kung registered na yung student or not
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTable where Student_Number='" + txtSNum.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    string student_number = string.Empty;
                    while (dr.Read())
                    {
                        student_number = dr["Student_Number"].ToString();
                    }
                    if (txtSNum.Text == student_number)
                    {
                        btnEnroll.Visible = false;
                        Fprintnotreg.Visible = false;
                        Fprintreg.Visible = true;
                    }
                    else if (txtSNum.Text != student_number)
                    {
                        Fprintnotreg.Visible = true;
                        Fprintreg.Visible = false;
                        btnEnroll.Visible = false;
                        btnEnrollTimer.Interval = 3000;
                        btnEnrollTimer.Start();                       
                    }
                }
                if (s11.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind11WithCatch(); }
                else if (s12.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind12WithCatch(); }
                else if (s13.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind13WithCatch(); }
                else if (s14.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind14WithCatch(); }
                else if (s15.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind15WithCatch(); }
                else if (s11p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind11pWithCatch(); }
                else if (s21.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind21WithCatch(); }
                else if (s22.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind22WithCatch(); }
                else if (s23.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind23WithCatch(); }
                else if (s24.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind24WithCatch(); }
                else if (s25.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind25WithCatch(); }
                else if (s21p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind21pWithCatch(); }
                else if (s31.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind31WithCatch(); }
                else if (s32.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind32WithCatch(); }
                else if (s33.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind33WithCatch(); }
                else if (s34.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind34WithCatch(); }
                else if (s35.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind35WithCatch(); }
                else if (s31p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind31pWithCatch(); }
                else if (s41.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind41WithCatch(); }
                else if (s42.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind42WithCatch(); }
                else if (s43.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind43WithCatch(); }
                else if (s44.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind44WithCatch(); }
                else if (s45.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind45WithCatch(); }
                else if (s41p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind41pWithCatch(); }
                else if (s51.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind51WithCatch(); }
                else if (s52.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind52WithCatch(); }
                else if (s53.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind53WithCatch(); }
                else if (s54.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind54WithCatch(); }
                else if (s55.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind55WithCatch(); }
                else if (s51p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind51pWithCatch(); }
                else if (s11.ForeColor != Color.FromArgb(0, 174, 219) || s25.ForeColor != Color.FromArgb(0, 174, 219) || s43.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s12.ForeColor != Color.FromArgb(0, 174, 219) || s21p.ForeColor != Color.FromArgb(0, 174, 219) || s44.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s13.ForeColor != Color.FromArgb(0, 174, 219) || s31.ForeColor != Color.FromArgb(0, 174, 219) || s45.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s14.ForeColor != Color.FromArgb(0, 174, 219) || s32.ForeColor != Color.FromArgb(0, 174, 219) || s41p.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s15.ForeColor != Color.FromArgb(0, 174, 219) || s33.ForeColor != Color.FromArgb(0, 174, 219) || s51.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s11p.ForeColor != Color.FromArgb(0, 174, 219) || s34.ForeColor != Color.FromArgb(0, 174, 219) || s52.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s21.ForeColor != Color.FromArgb(0, 174, 219) || s35.ForeColor != Color.FromArgb(0, 174, 219) || s53.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s22.ForeColor != Color.FromArgb(0, 174, 219) || s31p.ForeColor != Color.FromArgb(0, 174, 219) || s54.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s23.ForeColor != Color.FromArgb(0, 174, 219) || s41.ForeColor != Color.FromArgb(0, 174, 219) || s55.ForeColor != Color.FromArgb(0, 174, 219) ||
                    s24.ForeColor != Color.FromArgb(0, 174, 219) || s42.ForeColor != Color.FromArgb(0, 174, 219) || s51p.ForeColor != Color.FromArgb(0, 174, 219))
                {
                    if (metroTabControl1.SelectedTab == firstyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'First Year' Order By Full_Name ASC", commandType: CommandType.Text);
                            FactorInShowingImagePathErrorWithCatch();
                        }
                        CountFirstYearRegisteredStudents();
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Second Year' Order By Full_Name ASC", commandType: CommandType.Text);
                            FactorInShowingImagePathErrorWithCatch();
                        }
                        CountSecondYearRegisteredStudents();
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Third Year' Order By Full_Name ASC", commandType: CommandType.Text);
                            FactorInShowingImagePathErrorWithCatch();
                        }
                        CountThirdYearRegisteredStudents();
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fourth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                            FactorInShowingImagePathErrorWithCatch();
                        }
                        CountFourthYearRegisteredStudents();
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable where Year_Level = 'Fifth Year' Order By Full_Name ASC", commandType: CommandType.Text);
                            FactorInShowingImagePathErrorWithCatch();
                        }
                        CountFifthYearRegisteredStudents();
                    }
                }
                metroTabControl1.Visible = false;
            }
            else if (metroGrid2.Rows.Count < 1 || metroGrid3.Rows.Count < 1 || metroGrid4.Rows.Count < 1 || metroGrid5.Rows.Count < 1 || metroGrid6.Rows.Count < 1)
            {
                btnDummy.Select();
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("No data available.");
                pg.Close();
            }
        }
        #endregion
        
        #region CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnEnrollTimer.Enabled)
            { btnEnrollTimer.Stop(); }
            metroTabControl1.Visible = true;
            if (s11.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind11WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s12.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind12WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s13.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind13WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s14.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind14WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s15.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind15WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s11p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            {
                bind11pWithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s21.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind21WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s22.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind22WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s23.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind23WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s24.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind24WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s25.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind25WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s21p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            {
                bind21pWithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s31.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind31WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s32.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind32WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s33.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind33WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s34.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind34WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s35.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind35WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s31p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            {
                bind31pWithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s41.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind41WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s42.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind42WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s43.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind43WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s44.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind44WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s45.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind45WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s41p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            {
                bind41pWithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s51.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind51WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s52.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind52WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
            }
            else if (s53.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind53WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s54.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind54WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s55.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind55WithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else if (s51p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                bind51pWithoutCatch(); btnAdd.Visible = true; btnEdit.Visible = true; btnDelete.Visible = true;
                studentsClassBindingSource.MoveFirst();
            }
            else
            {
                metroTabControl1_SelectedIndexChanged(sender, e);
            }           
            btnEnroll.Visible = false;
            Fprintnotreg.Visible = false;
            Fprintreg.Visible = false;
            pic.Image = null;
        }
        
        #endregion

        #region UPDATE BUTTON
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnDummy.Select();
                Cursor.Current = Cursors.WaitCursor;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null)
                    {
                        string allowedcharforcnum = "0123456789+";
                        string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,.- ";
                        string allowedcharforbday = "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ, ";
                        if(mrb1.Checked == false && mrb2.Checked == false && mrb3.Checked == false && mrb4.Checked == false && mrb5.Checked == false)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox2.showdialog("Please choose a year level. Check one above the student number field.");
                            pg.Close();
                        }
                        else if (string.IsNullOrEmpty(txtYaS.Text) || string.IsNullOrEmpty(txtCNum.Text) || string.IsNullOrWhiteSpace(txtBday.Text) ||
                            string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtGuardian.Text) ||
                            string.IsNullOrEmpty(txtGCNum.Text) || pic.Image == null)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox2.showdialog("Please complete all necessary fields.");
                            pg.Close();
                            obj.Birthday = txtBday.Text = Regex.Replace(txtBday.Text, "\\s+", " ").Trim();
                            obj.Address = txtAddress.Text = Regex.Replace(txtAddress.Text, "\\s+", " ").Trim();
                            obj.Guardian = txtGuardian.Text = Regex.Replace(txtGuardian.Text, "\\s+", " ").Trim();

                            //Check textboxes kung may laman and assign a focus
                            if (string.IsNullOrEmpty(txtYaS.Text))
                            { txtYaS.Select(); }
                            else if (string.IsNullOrEmpty(txtCNum.Text))
                            { txtCNum.Select(); }
                            else if (string.IsNullOrWhiteSpace(txtBday.Text))
                            { txtBday.Select(); }
                            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                            { txtAddress.Select(); }
                            else if (string.IsNullOrEmpty(txtEmail.Text))
                            { txtEmail.Select(); }
                            else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                            { txtGuardian.Select(); }
                            else if (string.IsNullOrEmpty(txtGCNum.Text))
                            { txtGCNum.Select(); }
                        }
                        else if (txtYaS.Text != "1-1" && txtYaS.Text != "1-2" && txtYaS.Text != "1-3" && txtYaS.Text != "1-4" && txtYaS.Text != "1-5" && txtYaS.Text != "1-1P" &&
                               txtYaS.Text != "2-1" && txtYaS.Text != "2-2" && txtYaS.Text != "2-3" && txtYaS.Text != "2-4" && txtYaS.Text != "2-5" && txtYaS.Text != "2-1P" &&
                               txtYaS.Text != "3-1" && txtYaS.Text != "3-2" && txtYaS.Text != "3-3" && txtYaS.Text != "3-4" && txtYaS.Text != "3-5" && txtYaS.Text != "3-1P" &&
                               txtYaS.Text != "4-1" && txtYaS.Text != "4-2" && txtYaS.Text != "4-3" && txtYaS.Text != "4-4" && txtYaS.Text != "4-5" && txtYaS.Text != "4-1P" &&
                               txtYaS.Text != "5-1" && txtYaS.Text != "5-2" && txtYaS.Text != "5-3" && txtYaS.Text != "5-4" && txtYaS.Text != "5-5" && txtYaS.Text != "5-1P")
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox2.showdialog("Please enter a valid 'Year and Section'.");
                            pg.Close();
                            txtYaS.Text = "";
                            txtYaS.Select();
                        }
                        else if (mrb1.Checked == true && txtYaS.Text == "1-1" && Settings.Default.b11 == false || mrb1.Checked == true && txtYaS.Text == "1-2" && Settings.Default.b12 == false
                                 || mrb1.Checked == true && txtYaS.Text == "1-3" && Settings.Default.b13 == false || mrb1.Checked == true && txtYaS.Text == "1-4" && Settings.Default.b14 == false
                                 || mrb1.Checked == true && txtYaS.Text == "1-5" && Settings.Default.b15 == false || mrb1.Checked == true && txtYaS.Text == "1-1P" && Settings.Default.b11p == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-1" && Settings.Default.b21 == false || mrb2.Checked == true && txtYaS.Text == "2-2" && Settings.Default.b22 == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-3" && Settings.Default.b23 == false || mrb2.Checked == true && txtYaS.Text == "2-4" && Settings.Default.b24 == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-5" && Settings.Default.b25 == false || mrb2.Checked == true && txtYaS.Text == "2-1P" && Settings.Default.b21p == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-1" && Settings.Default.b31 == false || mrb3.Checked == true && txtYaS.Text == "3-2" && Settings.Default.b32 == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-3" && Settings.Default.b32 == false || mrb3.Checked == true && txtYaS.Text == "3-4" && Settings.Default.b34 == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-5" && Settings.Default.b35 == false || mrb3.Checked == true && txtYaS.Text == "3-1P" && Settings.Default.b31p == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-1" && Settings.Default.b41 == false || mrb4.Checked == true && txtYaS.Text == "4-2" && Settings.Default.b42 == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-3" && Settings.Default.b43 == false || mrb4.Checked == true && txtYaS.Text == "4-4" && Settings.Default.b44 == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-5" && Settings.Default.b45 == false || mrb4.Checked == true && txtYaS.Text == "4-1P" && Settings.Default.b41p == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-1" && Settings.Default.b51 == false || mrb5.Checked == true && txtYaS.Text == "5-2" && Settings.Default.b52 == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-3" && Settings.Default.b53 == false || mrb5.Checked == true && txtYaS.Text == "5-4" && Settings.Default.b54 == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-5" && Settings.Default.b55 == false || mrb5.Checked == true && txtYaS.Text == "5-1P" && Settings.Default.b51p == false)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox2.showdialog("This section is not available in the database.");
                           // txtSNum.Enabled = false;
                            pg.Close();
                            txtYaS.Text = "";
                            txtYaS.Select();
                        }
                        else if (mrb1.Checked == true && txtYaS.Text == "2-1" || mrb1.Checked == true && txtYaS.Text == "2-2" || mrb1.Checked == true && txtYaS.Text == "2-3"
                                || mrb1.Checked == true && txtYaS.Text == "2-4" || mrb1.Checked == true && txtYaS.Text == "2-5" || mrb1.Checked == true && txtYaS.Text == "2-1P"
                                || mrb1.Checked == true && txtYaS.Text == "3-1" || mrb1.Checked == true && txtYaS.Text == "3-2" || mrb1.Checked == true && txtYaS.Text == "3-3"
                                || mrb1.Checked == true && txtYaS.Text == "3-4" || mrb1.Checked == true && txtYaS.Text == "3-5" || mrb1.Checked == true && txtYaS.Text == "3-1P"
                                || mrb1.Checked == true && txtYaS.Text == "4-1" || mrb1.Checked == true && txtYaS.Text == "4-2" || mrb1.Checked == true && txtYaS.Text == "4-3"
                                || mrb1.Checked == true && txtYaS.Text == "4-4" || mrb1.Checked == true && txtYaS.Text == "4-5" || mrb1.Checked == true && txtYaS.Text == "4-1P"
                                || mrb1.Checked == true && txtYaS.Text == "5-1" || mrb1.Checked == true && txtYaS.Text == "5-2" || mrb1.Checked == true && txtYaS.Text == "5-3"
                                || mrb1.Checked == true && txtYaS.Text == "5-4" || mrb1.Checked == true && txtYaS.Text == "5-5" || mrb1.Checked == true && txtYaS.Text == "5-1P"
                                || mrb2.Checked == true && txtYaS.Text == "1-1" || mrb2.Checked == true && txtYaS.Text == "1-2" || mrb2.Checked == true && txtYaS.Text == "1-3"
                                || mrb2.Checked == true && txtYaS.Text == "1-4" || mrb2.Checked == true && txtYaS.Text == "1-5" || mrb2.Checked == true && txtYaS.Text == "1-1P"
                                || mrb2.Checked == true && txtYaS.Text == "3-1" || mrb2.Checked == true && txtYaS.Text == "3-2" || mrb2.Checked == true && txtYaS.Text == "3-3"
                                || mrb2.Checked == true && txtYaS.Text == "3-4" || mrb2.Checked == true && txtYaS.Text == "3-5" || mrb2.Checked == true && txtYaS.Text == "3-1P"
                                || mrb2.Checked == true && txtYaS.Text == "4-1" || mrb2.Checked == true && txtYaS.Text == "4-2" || mrb2.Checked == true && txtYaS.Text == "4-3"
                                || mrb2.Checked == true && txtYaS.Text == "4-4" || mrb2.Checked == true && txtYaS.Text == "4-5" || mrb2.Checked == true && txtYaS.Text == "4-1P"
                                || mrb2.Checked == true && txtYaS.Text == "5-1" || mrb2.Checked == true && txtYaS.Text == "5-2" || mrb2.Checked == true && txtYaS.Text == "5-3"
                                || mrb2.Checked == true && txtYaS.Text == "5-4" || mrb2.Checked == true && txtYaS.Text == "5-5" || mrb2.Checked == true && txtYaS.Text == "5-1P"
                                || mrb3.Checked == true && txtYaS.Text == "2-1" || mrb3.Checked == true && txtYaS.Text == "2-2" || mrb3.Checked == true && txtYaS.Text == "2-3"
                                || mrb3.Checked == true && txtYaS.Text == "2-4" || mrb3.Checked == true && txtYaS.Text == "2-5" || mrb3.Checked == true && txtYaS.Text == "2-1P"
                                || mrb3.Checked == true && txtYaS.Text == "1-1" || mrb3.Checked == true && txtYaS.Text == "1-2" || mrb3.Checked == true && txtYaS.Text == "1-3"
                                || mrb3.Checked == true && txtYaS.Text == "1-4" || mrb3.Checked == true && txtYaS.Text == "1-5" || mrb3.Checked == true && txtYaS.Text == "1-1P"
                                || mrb3.Checked == true && txtYaS.Text == "4-1" || mrb3.Checked == true && txtYaS.Text == "4-2" || mrb3.Checked == true && txtYaS.Text == "4-3"
                                || mrb3.Checked == true && txtYaS.Text == "4-4" || mrb3.Checked == true && txtYaS.Text == "4-5" || mrb3.Checked == true && txtYaS.Text == "4-1P"
                                || mrb3.Checked == true && txtYaS.Text == "5-1" || mrb3.Checked == true && txtYaS.Text == "5-2" || mrb3.Checked == true && txtYaS.Text == "5-3"
                                || mrb3.Checked == true && txtYaS.Text == "5-4" || mrb3.Checked == true && txtYaS.Text == "5-5" || mrb3.Checked == true && txtYaS.Text == "5-1P"
                                || mrb4.Checked == true && txtYaS.Text == "2-1" || mrb4.Checked == true && txtYaS.Text == "2-2" || mrb4.Checked == true && txtYaS.Text == "2-3"
                                || mrb4.Checked == true && txtYaS.Text == "2-4" || mrb4.Checked == true && txtYaS.Text == "2-5" || mrb4.Checked == true && txtYaS.Text == "2-1P"
                                || mrb4.Checked == true && txtYaS.Text == "3-1" || mrb4.Checked == true && txtYaS.Text == "3-2" || mrb4.Checked == true && txtYaS.Text == "3-3"
                                || mrb4.Checked == true && txtYaS.Text == "3-4" || mrb4.Checked == true && txtYaS.Text == "3-5" || mrb4.Checked == true && txtYaS.Text == "3-1P"
                                || mrb4.Checked == true && txtYaS.Text == "1-1" || mrb4.Checked == true && txtYaS.Text == "1-2" || mrb4.Checked == true && txtYaS.Text == "1-3"
                                || mrb4.Checked == true && txtYaS.Text == "1-4" || mrb4.Checked == true && txtYaS.Text == "1-5" || mrb4.Checked == true && txtYaS.Text == "1-1P"
                                || mrb4.Checked == true && txtYaS.Text == "5-1" || mrb4.Checked == true && txtYaS.Text == "5-2" || mrb4.Checked == true && txtYaS.Text == "5-3"
                                || mrb4.Checked == true && txtYaS.Text == "5-4" || mrb4.Checked == true && txtYaS.Text == "5-5" || mrb4.Checked == true && txtYaS.Text == "5-1P"
                                || mrb5.Checked == true && txtYaS.Text == "2-1" || mrb5.Checked == true && txtYaS.Text == "2-2" || mrb5.Checked == true && txtYaS.Text == "2-3"
                                || mrb5.Checked == true && txtYaS.Text == "2-4" || mrb5.Checked == true && txtYaS.Text == "2-5" || mrb5.Checked == true && txtYaS.Text == "2-1P"
                                || mrb5.Checked == true && txtYaS.Text == "3-1" || mrb5.Checked == true && txtYaS.Text == "3-2" || mrb5.Checked == true && txtYaS.Text == "3-3"
                                || mrb5.Checked == true && txtYaS.Text == "3-4" || mrb5.Checked == true && txtYaS.Text == "3-5" || mrb5.Checked == true && txtYaS.Text == "3-1P"
                                || mrb5.Checked == true && txtYaS.Text == "4-1" || mrb5.Checked == true && txtYaS.Text == "4-2" || mrb5.Checked == true && txtYaS.Text == "4-3"
                                || mrb5.Checked == true && txtYaS.Text == "4-4" || mrb5.Checked == true && txtYaS.Text == "4-5" || mrb5.Checked == true && txtYaS.Text == "4-1P"
                                || mrb5.Checked == true && txtYaS.Text == "1-1" || mrb5.Checked == true && txtYaS.Text == "1-2" || mrb5.Checked == true && txtYaS.Text == "1-3"
                                || mrb5.Checked == true && txtYaS.Text == "1-4" || mrb5.Checked == true && txtYaS.Text == "1-5" || mrb5.Checked == true && txtYaS.Text == "1-1P")
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox2.showdialog("'Year and Section' you entered doesn't match with the 'Year Level'.");
                            //pnlStudNum.Enabled = true;
                            //txtSNum.Enabled = false;
                            pg.Close();
                            txtYaS.Text = "";
                            txtYaS.Select();
                        }
                        else if (!txtCNum.Text.All(allowedcharforcnum.Contains)) //Bawal special char or letters sa cnum
                        {
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show("No special characters or letters are allowed for 'Contact Number' field.");
                            pg.Close();
                            txtCNum.Text = "";
                            txtCNum.Select();
                        }
                        else if (!txtBday.Text.All(allowedcharforbday.Contains)) //Bawal special char sa bday
                        {
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show("No special characters are allowed for 'Birthday' field.");
                            pg.Close();
                            txtBday.Text = "";
                            txtBday.Select();
                        }
                        else if (!txtGuardian.Text.All(allowedcharforname.Contains)) //Bawal digits or special char sa guardian name
                        {
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show("No special characters or digits are allowed for 'Guardian Name' field.");
                            pg.Close();
                            txtGuardian.Text = "";
                            txtGuardian.Select();
                        }
                        else if (!txtGCNum.Text.All(allowedcharforcnum.Contains)) //Bawal special char or letters sa guardian cnum
                        {
                            Plexiglass pg = new Plexiglass(this);
                            MessageBox.Show("No special characters or letters are allowed for 'Guardian Contact Number' field.");
                            pg.Close();
                            txtGCNum.Text = "";
                            txtGCNum.Select();
                        }
                        else
                        {
                            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                            {
                                if (myConn.State == ConnectionState.Closed)
                                { myConn.Open(); }
                                SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTable where Student_Number='" + txtSNum.Text + "'", myConn);
                                SqlDataReader dr;
                                dr = SelectCommand.ExecuteReader();
                              //  int count = 0;
                                string student_number = string.Empty;
                                while (dr.Read())
                                {
                                  //  count = count + 1;
                                    student_number = dr["Student_Number"].ToString();
                                }
                                if (txtSNum.Text != student_number)
                                {
                                    Plexiglass pg = new Plexiglass(this);
                                    messagebox2.showdialog("Please complete the fingerprint enrollment.");
                                    pg.Close();
                                }
                                else
                                {
                                    if (objState == EntityState.Changed)
                                    {
                                        if (mrb1.Checked == true)
                                        { yearlevel = "First Year"; }
                                        else if (mrb2.Checked == true)
                                        { yearlevel = "Second Year"; }
                                        else if (mrb3.Checked == true)
                                        { yearlevel = "Third Year"; }
                                        else if (mrb4.Checked == true)
                                        { yearlevel = "Fourth Year"; }
                                        else if (mrb5.Checked == true)
                                        { yearlevel = "Fifth Year"; }
                                        db.Execute("StudentsTableUpdate", new
                                        {
                                            ID = obj.ID,
                                            Student_Number = obj.Student_Number,
                                            Full_Name = obj.Full_Name,
                                            Year_and_Section = obj.Year_and_Section,
                                            Contact_Number = obj.Contact_Number,
                                            Birthday = obj.Birthday,
                                            Address = obj.Address,
                                            Email = obj.Email,
                                            Guardian = obj.Guardian,
                                            Guardian_Number = obj.Guardian_Number,
                                            Image_Location = obj.Image_Location,
                                            Year_Level = yearlevel
                                        }, commandType: CommandType.StoredProcedure);

                                        //Update den yung year and section sa fingerprintstable
                                        var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number == obj.Student_Number);
                                        if (snumm != null)
                                        {                                         
                                            snumm.Year_and_Section = obj.Year_and_Section;
                                            snumm.Year_Level = yearlevel;
                                            context1.SaveChanges();
                                        }
                                        Plexiglass pg = new Plexiglass(this);                                      
                                        MessageBox.Show("Student information successfully updated.");
                                        pg.Close();
                                        btnAdd.Visible = true;
                                        btnEdit.Visible = true;
                                        btnDelete.Visible = true;
                                        btnCancel.Visible = false;
                                        btnUpdate.Visible = false;

                                        if (yearlevel == "First Year")
                                        {
                                            if (obj.Year_and_Section == "1-1")
                                            { metroTabControl1.SelectedIndex = 1; s11_Click(sender, e); }
                                            else if (obj.Year_and_Section == "1-2")
                                            { metroTabControl1.SelectedIndex = 1; s12_Click(sender, e); }
                                            else if (obj.Year_and_Section == "1-3")
                                            { metroTabControl1.SelectedIndex = 1; s13_Click(sender, e); }
                                            else if (obj.Year_and_Section == "1-4")
                                            { metroTabControl1.SelectedIndex = 1; s14_Click(sender, e); }
                                            else if (obj.Year_and_Section == "1-5")
                                            { metroTabControl1.SelectedIndex = 1; s15_Click(sender, e); }
                                            else if (obj.Year_and_Section == "1-1P")
                                            { metroTabControl1.SelectedIndex = 1; s11p_Click(sender, e); }
                                        }
                                        else if (yearlevel == "Second Year")
                                        {
                                            if (obj.Year_and_Section == "2-1")
                                            { metroTabControl1.SelectedIndex = 2; s21_Click(sender, e); }
                                            else if (obj.Year_and_Section == "2-2")
                                            { metroTabControl1.SelectedIndex = 2; s22_Click(sender, e); }
                                            else if (obj.Year_and_Section == "2-3")
                                            { metroTabControl1.SelectedIndex = 2; s23_Click(sender, e); }
                                            else if (obj.Year_and_Section == "2-4")
                                            { metroTabControl1.SelectedIndex = 2; s24_Click(sender, e); }
                                            else if (obj.Year_and_Section == "2-5")
                                            { metroTabControl1.SelectedIndex = 2; s25_Click(sender, e); }
                                            else if (obj.Year_and_Section == "2-1P")
                                            { metroTabControl1.SelectedIndex = 2; s21p_Click(sender, e); }
                                        }
                                        else if (yearlevel == "Third Year")
                                        {
                                            if (obj.Year_and_Section == "3-1")
                                            { metroTabControl1.SelectedIndex = 3; s31_Click(sender, e); }
                                            else if (obj.Year_and_Section == "3-2")
                                            { metroTabControl1.SelectedIndex = 3; s32_Click(sender, e); }
                                            else if (obj.Year_and_Section == "3-3")
                                            { metroTabControl1.SelectedIndex = 3; s33_Click(sender, e); }
                                            else if (obj.Year_and_Section == "3-4")
                                            { metroTabControl1.SelectedIndex = 3; s34_Click(sender, e); }
                                            else if (obj.Year_and_Section == "3-5")
                                            { metroTabControl1.SelectedIndex = 3; s35_Click(sender, e); }
                                            else if (obj.Year_and_Section == "3-1P")
                                            { metroTabControl1.SelectedIndex = 3; s31p_Click(sender, e); }
                                        }
                                        else if (yearlevel == "Fourth Year")
                                        {
                                            if (obj.Year_and_Section == "4-1")
                                            { metroTabControl1.SelectedIndex = 4; s41_Click(sender, e); }
                                            else if (obj.Year_and_Section == "4-2")
                                            { metroTabControl1.SelectedIndex = 4; s42_Click(sender, e); }
                                            else if (obj.Year_and_Section == "4-3")
                                            { metroTabControl1.SelectedIndex = 4; s43_Click(sender, e); }
                                            else if (obj.Year_and_Section == "4-4")
                                            { metroTabControl1.SelectedIndex = 4; s44_Click(sender, e); }
                                            else if (obj.Year_and_Section == "4-5")
                                            { metroTabControl1.SelectedIndex = 4; s45_Click(sender, e); }
                                            else if (obj.Year_and_Section == "4-1P")
                                            { metroTabControl1.SelectedIndex = 4; s41p_Click(sender, e); }
                                        }
                                        else if (yearlevel == "Fifth Year")
                                        {
                                            if (obj.Year_and_Section == "5-1")
                                            { metroTabControl1.SelectedIndex = 5; s51_Click(sender, e); }
                                            else if (obj.Year_and_Section == "5-2")
                                            { metroTabControl1.SelectedIndex = 5; s52_Click(sender, e); }
                                            else if (obj.Year_and_Section == "5-3")
                                            { metroTabControl1.SelectedIndex = 5; s53_Click(sender, e); }
                                            else if (obj.Year_and_Section == "5-4")
                                            { metroTabControl1.SelectedIndex = 5; s54_Click(sender, e); }
                                            else if (obj.Year_and_Section == "5-5")
                                            { metroTabControl1.SelectedIndex = 5; s55_Click(sender, e); }
                                            else if (obj.Year_and_Section == "5-1P")
                                            { metroTabControl1.SelectedIndex = 5; s51p_Click(sender, e); }
                                        }
                                        metroTabControl1.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            { MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region SAVE BUTTON

        #region COUNT REGISTERED STUDENTS PER YEAR
        private void CountFirstYearRegisteredStudents()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_Level = 'First Year'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "First year registered students : " + rows_count.ToString(); }
            }
        }
        private void CountSecondYearRegisteredStudents()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_Level = 'Second Year'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Second year registered students : " + rows_count.ToString(); }
            }
        }
        private void CountThirdYearRegisteredStudents()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_Level = 'Third Year'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Third year registered students : " + rows_count.ToString(); }
            }
        }
        private void CountFourthYearRegisteredStudents()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_Level = 'Fourth Year'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fourth year registered students : " + rows_count.ToString(); }
            }
        }
        private void CountFifthYearRegisteredStudents()
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from StudentsTable where Year_Level = 'Fifth Year'";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { lblONOS.Text = "No record of any student."; }
                else
                { lblONOS.Text = "Fifth year registered students : " + rows_count.ToString(); }
            }
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnDummy.Select();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    if (obj != null)
                    {
                        if (objState == EntityState.Added)
                        {
                            string allowedcharforcnum = "0123456789+";
                            string allowedcharforname = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ,.- ";
                            string allowedcharforbday = "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ, ";
                            string allowedcharforstudnum = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-";
                            //Pag dipa verified yung student number
                            if (string.IsNullOrEmpty(txtSNum.Text))
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("Student number is required.");
                                pg.Close();
                                txtSNum.Select(); 
                            }
                            else if (!txtSNum.Text.All(allowedcharforstudnum.Contains) && lblStudentNumberVerified.Visible == false) //Pag di pa verified and may mali sa char
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("No special characters or lower case letters are allowed for student number.");
                                pg.Close();
                                txtSNum.Text = "";
                                txtSNum.Select();
                            }
                            else if (txtSNum.Text.All(allowedcharforstudnum.Contains) && lblStudentNumberVerified.Visible == false) //Pag di pa verified and good yung all char
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("To proceed, please verify the student number.");
                                pg.Close();
                                txtSNum.Select(); //Set focus
                                txtSNum.Select(txtSNum.Text.Length, 0); //Set cursor at the end of textbox
                            }
                            //Pag verified na
                            else if (string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrEmpty(txtYaS.Text) ||
                                string.IsNullOrEmpty(txtCNum.Text) || string.IsNullOrWhiteSpace(txtBday.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) ||
                                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtGuardian.Text) || string.IsNullOrEmpty(txtGCNum.Text) || pic.Image == null)
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("Please complete all the necessary fields.");
                                pg.Close();
                                obj.Full_Name = txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                                obj.Birthday = txtBday.Text = Regex.Replace(txtBday.Text, "\\s+", " ").Trim();
                                obj.Address = txtAddress.Text = Regex.Replace(txtAddress.Text, "\\s+", " ").Trim();
                                obj.Guardian = txtGuardian.Text = Regex.Replace(txtGuardian.Text, "\\s+", " ").Trim();

                                //Check textboxes kung may laman and assign a focus
                                if (string.IsNullOrWhiteSpace(txtFName.Text))
                                { txtFName.Select(); }
                                else if (string.IsNullOrEmpty(txtYaS.Text))
                                { txtYaS.Select(); }
                                else if (string.IsNullOrEmpty(txtCNum.Text))
                                { txtCNum.Select(); }
                                else if (string.IsNullOrWhiteSpace(txtBday.Text))
                                { txtBday.Select(); }
                                else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                                { txtAddress.Select(); }
                                else if (string.IsNullOrEmpty(txtEmail.Text))
                                { txtEmail.Select(); }
                                else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                                { txtGuardian.Select(); }
                                else if (string.IsNullOrEmpty(txtGCNum.Text))
                                { txtGCNum.Select(); }
                            }            
                            else if (!txtFName.Text.All(allowedcharforname.Contains)) //Bawal digits or special char sa full name
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("No special characters or digits are allowed for 'Full Name' field.");
                                pg.Close();
                                txtFName.Text = "";
                                txtFName.Select();
                            }                        
                            else if (txtYaS.Text != "1-1" && txtYaS.Text != "1-2" && txtYaS.Text != "1-3" && txtYaS.Text != "1-4" && txtYaS.Text != "1-5" && txtYaS.Text != "1-1P" &&
                                txtYaS.Text != "2-1" && txtYaS.Text != "2-2" && txtYaS.Text != "2-3" && txtYaS.Text != "2-4" && txtYaS.Text != "2-5" && txtYaS.Text != "2-1P" &&
                                txtYaS.Text != "3-1" && txtYaS.Text != "3-2" && txtYaS.Text != "3-3" && txtYaS.Text != "3-4" && txtYaS.Text != "3-5" && txtYaS.Text != "3-1P" &&
                                txtYaS.Text != "4-1" && txtYaS.Text != "4-2" && txtYaS.Text != "4-3" && txtYaS.Text != "4-4" && txtYaS.Text != "4-5" && txtYaS.Text != "4-1P" &&
                                txtYaS.Text != "5-1" && txtYaS.Text != "5-2" && txtYaS.Text != "5-3" && txtYaS.Text != "5-4" && txtYaS.Text != "5-5" && txtYaS.Text != "5-1P")
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox2.showdialog("Please enter a valid 'Year and Section'.");
                                pg.Close();
                                txtYaS.Text = "";
                                txtYaS.Select();
                            }
                            else if (mrb1.Checked == true && txtYaS.Text == "1-1" && Settings.Default.b11 == false || mrb1.Checked == true && txtYaS.Text == "1-2" && Settings.Default.b12 == false
                                || mrb1.Checked == true && txtYaS.Text == "1-3" && Settings.Default.b13 == false || mrb1.Checked == true && txtYaS.Text == "1-4" && Settings.Default.b14 == false
                                || mrb1.Checked == true && txtYaS.Text == "1-5" && Settings.Default.b15 == false || mrb1.Checked == true && txtYaS.Text == "1-1P" && Settings.Default.b11p == false
                                || mrb2.Checked == true && txtYaS.Text == "2-1" && Settings.Default.b21 == false || mrb2.Checked == true && txtYaS.Text == "2-2" && Settings.Default.b22 == false
                                || mrb2.Checked == true && txtYaS.Text == "2-3" && Settings.Default.b23 == false || mrb2.Checked == true && txtYaS.Text == "2-4" && Settings.Default.b24 == false
                                || mrb2.Checked == true && txtYaS.Text == "2-5" && Settings.Default.b25 == false || mrb2.Checked == true && txtYaS.Text == "2-1P" && Settings.Default.b21p == false
                                || mrb3.Checked == true && txtYaS.Text == "3-1" && Settings.Default.b31 == false || mrb3.Checked == true && txtYaS.Text == "3-2" && Settings.Default.b32 == false
                                || mrb3.Checked == true && txtYaS.Text == "3-3" && Settings.Default.b32 == false || mrb3.Checked == true && txtYaS.Text == "3-4" && Settings.Default.b34 == false
                                || mrb3.Checked == true && txtYaS.Text == "3-5" && Settings.Default.b35 == false || mrb3.Checked == true && txtYaS.Text == "3-1P" && Settings.Default.b31p == false
                                || mrb4.Checked == true && txtYaS.Text == "4-1" && Settings.Default.b41 == false || mrb4.Checked == true && txtYaS.Text == "4-2" && Settings.Default.b42 == false
                                || mrb4.Checked == true && txtYaS.Text == "4-3" && Settings.Default.b43 == false || mrb4.Checked == true && txtYaS.Text == "4-4" && Settings.Default.b44 == false
                                || mrb4.Checked == true && txtYaS.Text == "4-5" && Settings.Default.b45 == false || mrb4.Checked == true && txtYaS.Text == "4-1P" && Settings.Default.b41p == false
                                || mrb5.Checked == true && txtYaS.Text == "5-1" && Settings.Default.b51 == false || mrb5.Checked == true && txtYaS.Text == "5-2" && Settings.Default.b52 == false
                                || mrb5.Checked == true && txtYaS.Text == "5-3" && Settings.Default.b53 == false || mrb5.Checked == true && txtYaS.Text == "5-4" && Settings.Default.b54 == false
                                || mrb5.Checked == true && txtYaS.Text == "5-5" && Settings.Default.b55 == false || mrb5.Checked == true && txtYaS.Text == "5-1P" && Settings.Default.b51p == false)
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox2.showdialog("This section is not available in the database.");
                                //  txtSNum.Enabled = false;
                                pg.Close();
                                txtYaS.Text = "";
                                txtYaS.Select();
                            }
                            else if (mrb1.Checked == true && txtYaS.Text == "2-1" || mrb1.Checked == true && txtYaS.Text == "2-2" || mrb1.Checked == true && txtYaS.Text == "2-3"
                                    || mrb1.Checked == true && txtYaS.Text == "2-4" || mrb1.Checked == true && txtYaS.Text == "2-5" || mrb1.Checked == true && txtYaS.Text == "2-1P"
                                    || mrb1.Checked == true && txtYaS.Text == "3-1" || mrb1.Checked == true && txtYaS.Text == "3-2" || mrb1.Checked == true && txtYaS.Text == "3-3"
                                    || mrb1.Checked == true && txtYaS.Text == "3-4" || mrb1.Checked == true && txtYaS.Text == "3-5" || mrb1.Checked == true && txtYaS.Text == "3-1P"
                                    || mrb1.Checked == true && txtYaS.Text == "4-1" || mrb1.Checked == true && txtYaS.Text == "4-2" || mrb1.Checked == true && txtYaS.Text == "4-3"
                                    || mrb1.Checked == true && txtYaS.Text == "4-4" || mrb1.Checked == true && txtYaS.Text == "4-5" || mrb1.Checked == true && txtYaS.Text == "4-1P"
                                    || mrb1.Checked == true && txtYaS.Text == "5-1" || mrb1.Checked == true && txtYaS.Text == "5-2" || mrb1.Checked == true && txtYaS.Text == "5-3"
                                    || mrb1.Checked == true && txtYaS.Text == "5-4" || mrb1.Checked == true && txtYaS.Text == "5-5" || mrb1.Checked == true && txtYaS.Text == "5-1P"
                                    || mrb2.Checked == true && txtYaS.Text == "1-1" || mrb2.Checked == true && txtYaS.Text == "1-2" || mrb2.Checked == true && txtYaS.Text == "1-3"
                                    || mrb2.Checked == true && txtYaS.Text == "1-4" || mrb2.Checked == true && txtYaS.Text == "1-5" || mrb2.Checked == true && txtYaS.Text == "1-1P"
                                    || mrb2.Checked == true && txtYaS.Text == "3-1" || mrb2.Checked == true && txtYaS.Text == "3-2" || mrb2.Checked == true && txtYaS.Text == "3-3"
                                    || mrb2.Checked == true && txtYaS.Text == "3-4" || mrb2.Checked == true && txtYaS.Text == "3-5" || mrb2.Checked == true && txtYaS.Text == "3-1P"
                                    || mrb2.Checked == true && txtYaS.Text == "4-1" || mrb2.Checked == true && txtYaS.Text == "4-2" || mrb2.Checked == true && txtYaS.Text == "4-3"
                                    || mrb2.Checked == true && txtYaS.Text == "4-4" || mrb2.Checked == true && txtYaS.Text == "4-5" || mrb2.Checked == true && txtYaS.Text == "4-1P"
                                    || mrb2.Checked == true && txtYaS.Text == "5-1" || mrb2.Checked == true && txtYaS.Text == "5-2" || mrb2.Checked == true && txtYaS.Text == "5-3"
                                    || mrb2.Checked == true && txtYaS.Text == "5-4" || mrb2.Checked == true && txtYaS.Text == "5-5" || mrb2.Checked == true && txtYaS.Text == "5-1P"
                                    || mrb3.Checked == true && txtYaS.Text == "2-1" || mrb3.Checked == true && txtYaS.Text == "2-2" || mrb3.Checked == true && txtYaS.Text == "2-3"
                                    || mrb3.Checked == true && txtYaS.Text == "2-4" || mrb3.Checked == true && txtYaS.Text == "2-5" || mrb3.Checked == true && txtYaS.Text == "2-1P"
                                    || mrb3.Checked == true && txtYaS.Text == "1-1" || mrb3.Checked == true && txtYaS.Text == "1-2" || mrb3.Checked == true && txtYaS.Text == "1-3"
                                    || mrb3.Checked == true && txtYaS.Text == "1-4" || mrb3.Checked == true && txtYaS.Text == "1-5" || mrb3.Checked == true && txtYaS.Text == "1-1P"
                                    || mrb3.Checked == true && txtYaS.Text == "4-1" || mrb3.Checked == true && txtYaS.Text == "4-2" || mrb3.Checked == true && txtYaS.Text == "4-3"
                                    || mrb3.Checked == true && txtYaS.Text == "4-4" || mrb3.Checked == true && txtYaS.Text == "4-5" || mrb3.Checked == true && txtYaS.Text == "4-1P"
                                    || mrb3.Checked == true && txtYaS.Text == "5-1" || mrb3.Checked == true && txtYaS.Text == "5-2" || mrb3.Checked == true && txtYaS.Text == "5-3"
                                    || mrb3.Checked == true && txtYaS.Text == "5-4" || mrb3.Checked == true && txtYaS.Text == "5-5" || mrb3.Checked == true && txtYaS.Text == "5-1P"
                                    || mrb4.Checked == true && txtYaS.Text == "2-1" || mrb4.Checked == true && txtYaS.Text == "2-2" || mrb4.Checked == true && txtYaS.Text == "2-3"
                                    || mrb4.Checked == true && txtYaS.Text == "2-4" || mrb4.Checked == true && txtYaS.Text == "2-5" || mrb4.Checked == true && txtYaS.Text == "2-1P"
                                    || mrb4.Checked == true && txtYaS.Text == "3-1" || mrb4.Checked == true && txtYaS.Text == "3-2" || mrb4.Checked == true && txtYaS.Text == "3-3"
                                    || mrb4.Checked == true && txtYaS.Text == "3-4" || mrb4.Checked == true && txtYaS.Text == "3-5" || mrb4.Checked == true && txtYaS.Text == "3-1P"
                                    || mrb4.Checked == true && txtYaS.Text == "1-1" || mrb4.Checked == true && txtYaS.Text == "1-2" || mrb4.Checked == true && txtYaS.Text == "1-3"
                                    || mrb4.Checked == true && txtYaS.Text == "1-4" || mrb4.Checked == true && txtYaS.Text == "1-5" || mrb4.Checked == true && txtYaS.Text == "1-1P"
                                    || mrb4.Checked == true && txtYaS.Text == "5-1" || mrb4.Checked == true && txtYaS.Text == "5-2" || mrb4.Checked == true && txtYaS.Text == "5-3"
                                    || mrb4.Checked == true && txtYaS.Text == "5-4" || mrb4.Checked == true && txtYaS.Text == "5-5" || mrb4.Checked == true && txtYaS.Text == "5-1P"
                                    || mrb5.Checked == true && txtYaS.Text == "2-1" || mrb5.Checked == true && txtYaS.Text == "2-2" || mrb5.Checked == true && txtYaS.Text == "2-3"
                                    || mrb5.Checked == true && txtYaS.Text == "2-4" || mrb5.Checked == true && txtYaS.Text == "2-5" || mrb5.Checked == true && txtYaS.Text == "2-1P"
                                    || mrb5.Checked == true && txtYaS.Text == "3-1" || mrb5.Checked == true && txtYaS.Text == "3-2" || mrb5.Checked == true && txtYaS.Text == "3-3"
                                    || mrb5.Checked == true && txtYaS.Text == "3-4" || mrb5.Checked == true && txtYaS.Text == "3-5" || mrb5.Checked == true && txtYaS.Text == "3-1P"
                                    || mrb5.Checked == true && txtYaS.Text == "4-1" || mrb5.Checked == true && txtYaS.Text == "4-2" || mrb5.Checked == true && txtYaS.Text == "4-3"
                                    || mrb5.Checked == true && txtYaS.Text == "4-4" || mrb5.Checked == true && txtYaS.Text == "4-5" || mrb5.Checked == true && txtYaS.Text == "4-1P"
                                    || mrb5.Checked == true && txtYaS.Text == "1-1" || mrb5.Checked == true && txtYaS.Text == "1-2" || mrb5.Checked == true && txtYaS.Text == "1-3"
                                    || mrb5.Checked == true && txtYaS.Text == "1-4" || mrb5.Checked == true && txtYaS.Text == "1-5" || mrb5.Checked == true && txtYaS.Text == "1-1P")
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox2.showdialog("'Year and Section' you entered doesn't match with the 'Year Level'.");
                                //pnlStudNum.Enabled = true;
                                //txtSNum.Enabled = false;
                                pg.Close();
                                txtYaS.Text = "";
                                txtYaS.Select();
                            }
                            else if (!txtCNum.Text.All(allowedcharforcnum.Contains)) //Bawal special char or letters sa cnum
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("No special characters or letters are allowed for 'Contact Number' field.");
                                pg.Close();
                                txtCNum.Text = "";
                                txtCNum.Select();
                            }
                            else if (!txtBday.Text.All(allowedcharforbday.Contains)) //Bawal special char sa bday
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("No special characters are allowed for 'Birthday' field.");
                                pg.Close();
                                txtBday.Text = "";
                                txtBday.Select();
                            }
                            else if (!txtGuardian.Text.All(allowedcharforname.Contains)) //Bawal digits or special char sa guardian name
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("No special characters or digits are allowed for 'Guardian Name' field.");
                                pg.Close();
                                txtGuardian.Text = "";
                                txtGuardian.Select();
                            }
                            else if (!txtGCNum.Text.All(allowedcharforcnum.Contains)) //Bawal special char or letters sa guardian cnum
                            {
                                Plexiglass pg = new Plexiglass(this);
                                MessageBox.Show("No special characters or letters are allowed for 'Guardian Contact Number' field.");
                                pg.Close();
                                txtGCNum.Text = "";
                                txtGCNum.Select();
                            }
                            else
                            {
                                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                                {
                                    if (myConn.State == ConnectionState.Closed)
                                    { myConn.Open(); }
                                    SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTable where Student_Number = '" + txtSNum.Text + "';", myConn);
                                    SqlDataReader dr;
                                    dr = SelectCommand.ExecuteReader();
                                    string student_number = string.Empty;
                                    while (dr.Read())
                                    {
                                        student_number = dr["Student_Number"].ToString();
                                    }
                                    if (txtSNum.Text != student_number)
                                    {
                                        Plexiglass pg = new Plexiglass(this);
                                        Validation.showdialog("Please complete the fingerprint enrollment.");
                                        pg.Close();
                                        obj.Full_Name = txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                                        obj.Birthday = txtBday.Text = Regex.Replace(txtBday.Text, "\\s+", " ").Trim();
                                        obj.Address = txtAddress.Text = Regex.Replace(txtAddress.Text, "\\s+", " ").Trim();
                                        obj.Guardian = txtGuardian.Text = Regex.Replace(txtGuardian.Text, "\\s+", " ").Trim();
                                    }
                                    else
                                    {
                                        obj.Full_Name = txtFName.Text = Regex.Replace(txtFName.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                                        obj.Birthday = txtBday.Text = Regex.Replace(txtBday.Text, "\\s+", " ").Trim();
                                        obj.Address = txtAddress.Text = Regex.Replace(txtAddress.Text, "\\s+", " ").Trim();
                                        obj.Guardian = txtGuardian.Text = Regex.Replace(txtGuardian.Text, "\\s+", " ").Trim();
                                        if (mrb1.Checked == true)
                                        { yearlevel = "First Year"; }
                                        else if (mrb2.Checked == true)
                                        { yearlevel = "Second Year"; }
                                        else if (mrb3.Checked == true)
                                        { yearlevel = "Third Year"; }
                                        else if (mrb4.Checked == true)
                                        { yearlevel = "Fourth Year"; }
                                        else if (mrb5.Checked == true)
                                        { yearlevel = "Fifth Year"; }
                                        DynamicParameters p = new DynamicParameters();
                                        p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                                        p.AddDynamicParams(new
                                        {
                                            Student_Number = obj.Student_Number,
                                            Full_Name = obj.Full_Name,
                                            Year_and_Section = obj.Year_and_Section,
                                            Contact_Number = obj.Contact_Number,
                                            Birthday = obj.Birthday,
                                            Address = obj.Address,
                                            Email = obj.Email,
                                            Guardian = obj.Guardian,
                                            Guardian_Number = obj.Guardian_Number,
                                            Image_Location = obj.Image_Location,
                                            Year_Level = yearlevel
                                        });
                                        db.Execute("StudentsTableInsert", p, commandType: CommandType.StoredProcedure);
                                        obj.ID = p.Get<int>("@ID");

                                        Plexiglass pg = new Plexiglass(this);                                        
                                        Validation.showdialog("Student information was successfully saved.");
                                        pg.Close();
                                        btnAdd.Visible = true;
                                        btnEdit.Visible = true;
                                        btnDelete.Visible = true;
                                        btnCancel.Visible = false;
                                        btnSave.Visible = false;

                                        if (yearlevel == "First Year")
                                        {
                                            if (obj.Year_and_Section == "1-1")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s11_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "1-2")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s12_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "1-3")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s13_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "1-4")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s14_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "1-5")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s15_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "1-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                s11p_Click(sender, e);
                                                CountFirstYearRegisteredStudents();
                                            }
                                        }
                                        else if (yearlevel == "Second Year")
                                        {
                                            if (obj.Year_and_Section == "2-1")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s21_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "2-2")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s22_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "2-3")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s23_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "2-4")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s24_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "2-5")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s25_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "2-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                s21p_Click(sender, e);
                                                CountSecondYearRegisteredStudents();
                                            }
                                        }
                                        else if (yearlevel == "Third Year")
                                        {
                                            if (obj.Year_and_Section == "3-1")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s31_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "3-2")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s32_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "3-3")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s33_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "3-4")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s34_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "3-5")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s35_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "3-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                s31p_Click(sender, e);
                                                CountThirdYearRegisteredStudents();
                                            }
                                        }
                                        else if (yearlevel == "Fourth Year")
                                        {
                                            if (obj.Year_and_Section == "4-1")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s41_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "4-2")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s42_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "4-3")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s43_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "4-4")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s44_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "4-5")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s45_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                            else if (obj.Year_and_Section == "4-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                s41p_Click(sender, e);
                                                CountFourthYearRegisteredStudents();
                                            }
                                        }
                                        else if (yearlevel == "Fifth Year")
                                        {
                                            if (obj.Year_and_Section == "5-1")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s51_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                            if (obj.Year_and_Section == "5-2")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s52_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                            if (obj.Year_and_Section == "5-3")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s53_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                            if (obj.Year_and_Section == "5-4")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s54_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                            if (obj.Year_and_Section == "5-5")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s55_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                            if (obj.Year_and_Section == "5-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 5;
                                                s51p_Click(sender, e);
                                                CountFifthYearRegisteredStudents();
                                            }
                                        }
                                        metroTabControl1.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region DELETE BUTTON
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            //objState = EntityState.Deleted;
            if (metroGrid2.Rows.Count < 1 || metroGrid3.Rows.Count < 1 || metroGrid4.Rows.Count < 1 || metroGrid5.Rows.Count < 1 || metroGrid6.Rows.Count < 1)
            {
                Validation.showdialog("No data found. Delete isn't available.");
            }
            else if (metroGrid2.Rows.Count > 1 && metroGrid2.SelectedRows.Count > 1 || metroGrid3.Rows.Count > 1 && metroGrid3.SelectedRows.Count > 1 ||
                metroGrid4.Rows.Count > 1 && metroGrid4.SelectedRows.Count > 1 || metroGrid5.Rows.Count > 1 && metroGrid5.SelectedRows.Count > 1 ||
                metroGrid6.Rows.Count > 1 && metroGrid6.SelectedRows.Count > 1)
            {
                if (messagebox2.showdialog("Removing these students' information will also wipe out the fingerprint data attached to each student. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    if (metroTabControl1.SelectedTab == firstyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid2.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            //pag dinelete yung student info madedelete din yung fingerprint data
                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                     //   studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Students' information were successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid3.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                      //  studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Students' information were successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid4.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                      //  studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Students' information were successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid5.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                      //  studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Students' information were successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid6.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                       // studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Students' information were successfully deleted.");
                    }
                }
            }
            else if (metroGrid2.Rows.Count >= 1 && metroGrid2.SelectedRows.Count == 1 || metroGrid3.Rows.Count >= 1 && metroGrid3.SelectedRows.Count == 1 ||
                metroGrid4.Rows.Count >= 1 && metroGrid4.SelectedRows.Count == 1 || metroGrid5.Rows.Count >= 1 && metroGrid5.SelectedRows.Count == 1 ||
                metroGrid6.Rows.Count >= 1 && metroGrid6.SelectedRows.Count == 1)
            {
                if (messagebox2.showdialog("Removing this student's information will also wipe out the fingerprint data attached to this student. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    if (metroTabControl1.SelectedTab == firstyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid2.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            //pag dinelete yung student info madedelete din yung fingerprint data
                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                       // studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Student's information was successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid3.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                       // studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Student's information was successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid4.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                       // studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Student's information was successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid5.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                      //  studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Student's information was successfully deleted.");
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in metroGrid6.SelectedRows)
                        {
                            StudentsTable equip = new StudentsTable()
                            {
                                Student_Number = row.Cells[0].Value.ToString(),
                                Full_Name = row.Cells[1].Value.ToString(),
                                Year_and_Section = row.Cells[3].Value.ToString(),
                                Contact_Number = row.Cells[4].Value.ToString(),
                                Birthday = row.Cells[5].Value.ToString(),
                                Address = row.Cells[6].Value.ToString(),
                                Email = row.Cells[7].Value.ToString(),
                                Guardian = row.Cells[8].Value.ToString(),
                                Guardian_Number = row.Cells[9].Value.ToString(),
                                Year_Level = row.Cells[2].Value.ToString(),
                                Image_Location = row.Cells[10].Value.ToString()
                            };
                            context.StudentsTables.Attach(equip);
                            context.StudentsTables.Remove(equip);
                            context.SaveChanges();

                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context1.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context1.FingerprintsTables.Attach(snumm);
                                context1.FingerprintsTables.Remove(snumm);
                                context1.SaveChanges();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                     //   studentsClassBindingSource.MoveFirst();
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Student's information was successfully deleted.");
                    }
                }
            }          
            pg.Close();
        }
        #endregion

        #region VERIFY STUDENT NUMBER
        private void btnVerifySNum_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            string allowedcharforstudnum = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-";
            if (string.IsNullOrEmpty(txtSNum.Text))
            {
                MessageBox.Show("Student number is required.");
            }
            else if (!txtSNum.Text.All(allowedcharforstudnum.Contains))
            {
                Validation.showdialog("No special characters or lower case letters are allowed for student number.");
                txtSNum.Text = "";
                txtSNum.Select();
            }
            else
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    //No need for collation kasi di naman allowed char sa studnum yung small letters
                    SqlCommand SelectCommand = new SqlCommand(" Select * from StudentsTable where Student_Number='" + txtSNum.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();
                    string studnum = string.Empty;
                    while (dr.Read())
                    {
                        studnum = dr["Student_Number"].ToString();
                    }
                    if (txtSNum.Text == studnum)
                    {
                        MessageBox.Show("This student number is already taken.");
                        txtSNum.Text = "";
                        txtSNum.Select();
                    }
                    else
                    {
                        if (Validation.showdialog("Do you want to register this student number? Once selected, you can't change it anymore.") == DialogResult.Yes)
                        {
                            pnlStudReg.Enabled = true;
                            pnlStudNum.Enabled = false;
                            txtFName.Select();
                            btnVerifySNum.Visible = false;
                            lblStudentNumberVerified.Visible = true;

                            using (SqlConnection myConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                            {
                                if (myConn1.State == ConnectionState.Closed)
                                { myConn1.Open(); }
                                SqlCommand SelectCommand1 = new SqlCommand("Select * from FingerprintsTable where Student_Number='" + txtSNum.Text + "'", myConn1);
                                SqlDataReader dr1;
                                dr1 = SelectCommand1.ExecuteReader();
                                string student_number = string.Empty;
                                while (dr1.Read())
                                {
                                    student_number = dr1["Student_Number"].ToString();
                                }
                                if (txtSNum.Text == student_number)
                                {
                                    Fprintreg.Visible = true;
                                }
                                else
                                {
                                    Fprintnotreg.Visible = true;
                                    btnEnrollTimer.Interval = 5000;
                                    btnEnrollTimer.Start();                                   
                                }
                            }
                        }
                        else //Pag no yung response
                        {
                            txtSNum.Select(); //Set focus
                            txtSNum.Select(txtSNum.Text.Length, 0); //Set focus at the end of textbox
                        }
                    }
                }               
            }
            pg.Close();   
        }
        #endregion

        #region INFORMATION CLICK
        private void Information_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1) //To not trigger the event if header is doubleclicked
            {
                btnDummy.Select();
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                try
                {
                    if (metroGrid1.Rows.Count < 1 || metroGrid2.Rows.Count < 1 || metroGrid3.Rows.Count < 1 ||
                        metroGrid4.Rows.Count < 1 || metroGrid5.Rows.Count < 1 || metroGrid6.Rows.Count < 1)
                    {
                        Validation.showdialog("No data found. Can't display any information.");
                    }
                    else if (string.IsNullOrWhiteSpace(metroGrid1.CurrentRow.Cells[10].Value.ToString()) || string.IsNullOrWhiteSpace(metroGrid2.CurrentRow.Cells[10].Value.ToString()) ||
                        string.IsNullOrWhiteSpace(metroGrid3.CurrentRow.Cells[10].Value.ToString()) || string.IsNullOrWhiteSpace(metroGrid4.CurrentRow.Cells[10].Value.ToString()) ||
                        string.IsNullOrWhiteSpace(metroGrid5.CurrentRow.Cells[10].Value.ToString()) || string.IsNullOrWhiteSpace(metroGrid6.CurrentRow.Cells[10].Value.ToString())) //if image is null dapat di magopen yung form
                    {
                        MessageBox.Show("Can't display information because there is no image attached for this student.");
                    }
                    else if (metroGrid1.SelectedRows.Count > 1 || metroGrid2.SelectedRows.Count > 1 || metroGrid3.SelectedRows.Count > 1 ||
                        metroGrid4.SelectedRows.Count > 1 || metroGrid5.SelectedRows.Count > 1 || metroGrid6.SelectedRows.Count > 1)
                    {
                        Validation.showdialog("Can't display multiple profiles at once.");
                    }
                    else if (metroTabControl1.SelectedTab == allyearlevel)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid1.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid1.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid1.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid1.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid1.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid1.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid1.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid1.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                    else if (metroTabControl1.SelectedTab == firstyear)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid2.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid2.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid2.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid2.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid2.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid2.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid2.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid2.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid2.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid2.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid3.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid3.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid3.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid3.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid3.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid3.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid3.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid3.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid3.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid3.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid4.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid4.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid4.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid4.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid4.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid4.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid4.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid4.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid4.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid4.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid5.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid5.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid5.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid5.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid5.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid5.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid5.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid5.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid5.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid5.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        ViewDetails vd = new ViewDetails();
                        SetTextForLabel1 = metroGrid6.CurrentRow.Cells[0].Value.ToString();
                        SetTextForLabel2 = metroGrid6.CurrentRow.Cells[1].Value.ToString();
                        SetTextForLabel3 = metroGrid6.CurrentRow.Cells[3].Value.ToString();
                        SetTextForLabel4 = metroGrid6.CurrentRow.Cells[4].Value.ToString();
                        SetTextForLabel5 = metroGrid6.CurrentRow.Cells[5].Value.ToString();
                        SetTextForLabel6 = metroGrid6.CurrentRow.Cells[6].Value.ToString();
                        SetTextForLabel7 = metroGrid6.CurrentRow.Cells[7].Value.ToString();
                        SetTextForLabel8 = metroGrid6.CurrentRow.Cells[8].Value.ToString();
                        SetTextForLabel9 = metroGrid6.CurrentRow.Cells[9].Value.ToString();
                        SetTextForLabel10 = Image.FromFile(metroGrid6.CurrentRow.Cells[10].Value.ToString());
                        vd.ShowDialog();
                    }
                }
                catch (Exception ex)
                {//Now we want to catch the error
                    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnwithmars"].ConnectionString))
                    {
                        if (myConn.State == ConnectionState.Closed)
                        { myConn.Open(); }
                        SqlCommand SelectCommand = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid1.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlCommand SelectCommand1 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid2.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlCommand SelectCommand2 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid3.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlCommand SelectCommand3 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid4.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlCommand SelectCommand4 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid5.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlCommand SelectCommand5 = new SqlCommand("Select * from StudentsTable where Image_Location ='" + metroGrid6.CurrentRow.Cells[10].Value.ToString() + "'", myConn);
                        SqlDataReader dr;
                        dr = SelectCommand.ExecuteReader(); dr = SelectCommand1.ExecuteReader(); dr = SelectCommand2.ExecuteReader();
                        dr = SelectCommand3.ExecuteReader(); dr = SelectCommand4.ExecuteReader(); dr = SelectCommand5.ExecuteReader();
                        string imgloc = string.Empty;
                        string student_number = string.Empty;
                        while (dr.Read())
                        {
                            imgloc = dr["Image_Location"].ToString();
                            student_number = dr["Student_Number"].ToString();
                        }
                        if (metroTabControl1.SelectedTab == allyearlevel)
                        {
                            if (metroGrid1.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                        else if (metroTabControl1.SelectedTab == firstyear)
                        {
                            if (metroGrid2.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                        else if (metroTabControl1.SelectedTab == secondyear)
                        {
                            if (metroGrid3.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                        else if (metroTabControl1.SelectedTab == thirdyear)
                        {
                            if (metroGrid4.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fourthyear)
                        {
                            if (metroGrid5.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fifthyear)
                        {
                            if (metroGrid6.CurrentRow.Cells[10].Value.ToString() == imgloc)
                            {
                                SetTextForl13 = "Sorry " + student_number + "." + "\r\n" + "Image file not found : " + ex.Message;
                                MessageBox.Show(SetTextForl13);
                            }
                        }
                    }
                }
                pg.Close();
            }          
        }
        #endregion       

        #region PREVENT PRESSING ENTER BUTTON IN KEYBOARD
        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
        }
        private void Enter_Space_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
            if (e.KeyChar == (char)Keys.Space)
            { e.Handled = true; }
        }
        #endregion

        #region EXPORT BUTTON
        private void btnExport_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid2.Rows.Count > 0 || metroGrid3.Rows.Count > 0 || metroGrid4.Rows.Count > 0 || metroGrid5.Rows.Count > 0 || metroGrid6.Rows.Count > 0)
            {
                if (messagebox.showdialog("Do you want to export this data to excel file?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbooks wb = xcelApp.Workbooks;
                    try
                    {
                        if (metroTabControl1.SelectedTab == firstyear || metroTabControl1.SelectedTab == firstyear && s11.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && s12.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == firstyear && s13.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && s14.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == firstyear && s15.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && s11p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid2.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid2.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid2.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid2.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid2.Columns.Count; j++)
                                    {
                                        if (metroGrid2.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid2.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and insert N/A 
                                            Range xlRange1 = (Range)xcelApp.Cells[i + 2, j + 1];
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid2.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox2.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == secondyear || metroTabControl1.SelectedTab == secondyear && s21.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && s22.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == secondyear && s23.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && s24.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == secondyear && s25.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && s21p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid3.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid3.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid3.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid3.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid3.Columns.Count; j++)
                                    {
                                        if (metroGrid3.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid3.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid3.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox2.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == thirdyear || metroTabControl1.SelectedTab == thirdyear && s31.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && s32.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == thirdyear && s33.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && s34.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == thirdyear && s35.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && s31p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid4.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid4.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid4.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid4.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid4.Columns.Count; j++)
                                    {
                                        if (metroGrid4.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid4.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid4.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox2.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fourthyear || metroTabControl1.SelectedTab == fourthyear && s41.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && s42.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fourthyear && s43.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && s44.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fourthyear && s45.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && s41p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid5.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid5.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid5.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid5.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid5.Columns.Count; j++)
                                    {
                                        if (metroGrid5.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid5.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid5.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox2.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fifthyear || metroTabControl1.SelectedTab == fifthyear && s51.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && s52.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fifthyear && s53.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && s54.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fifthyear && s55.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && s51p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid6.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid6.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid6.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid6.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid6.Columns.Count; j++)
                                    {
                                        if (metroGrid6.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid6.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid6.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                        }
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.FinalReleaseComObject(wb);
                        Marshal.FinalReleaseComObject(xcelApp);
                    }
                }
            }
            else
            {
                messagebox2.showdialog("No data available to allow export.");
            }
            pg.Close();
        }
        #endregion

        #region IMPORT BUTTON
        private void btnImport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (metroTabControl1.SelectedTab == firstyear && Settings.Default.b11.Equals(false) || metroTabControl1.SelectedTab == secondyear && Settings.Default.b21.Equals(false) ||
                metroTabControl1.SelectedTab == thirdyear && Settings.Default.b31.Equals(false) || metroTabControl1.SelectedTab == fourthyear && Settings.Default.b41.Equals(false) ||
                metroTabControl1.SelectedTab == fifthyear && Settings.Default.b51.Equals(false))
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Add first a section to this year level to properly use the import feature.");
                pg.Close();
            }
            else
            {
                Plexiglass pg = new Plexiglass(this);
                EZE_ImportExcelFile ief = new EZE_ImportExcelFile();
                ief.ShowDialog();
                pg.Close();
            }
        }
        #endregion

        #region ENROLL FINGERPRINT
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTable where Student_Number='" + txtSNum.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                string student_number = string.Empty;
                while (dr.Read())
                {
                    student_number = dr["Student_Number"].ToString();
                }
                if (mrb1.Checked == false && mrb2.Checked == false && mrb3.Checked == false && mrb4.Checked == false && mrb5.Checked == false)
                {
                    Plexiglass pg = new Plexiglass(this);
                    MessageBox.Show("Please choose a year level. Check one above the student number field.");
                    pg.Close();
                }
                else if (string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrEmpty(txtYaS.Text) || string.IsNullOrEmpty(txtCNum.Text) ||
                    string.IsNullOrWhiteSpace(txtBday.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtGuardian.Text) || string.IsNullOrEmpty(txtGCNum.Text) || pic.Image == null)
                {
                    Plexiglass pg = new Plexiglass(this);
                    MessageBox.Show("Please complete all the necessary fields before enrolling a fingerprint.");
                    pg.Close();

                    //Check textboxes kung may laman and assign a focus
                    if (lblStudentNumberVerified.Visible == true && objState == EntityState.Added)
                    {
                        if (string.IsNullOrWhiteSpace(txtFName.Text))
                        { txtFName.Select(); }
                        else if (string.IsNullOrEmpty(txtYaS.Text))
                        { txtYaS.Select(); }
                        else if (string.IsNullOrEmpty(txtCNum.Text))
                        { txtCNum.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtBday.Text))
                        { txtBday.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                        { txtAddress.Select(); }
                        else if (string.IsNullOrEmpty(txtEmail.Text))
                        { txtEmail.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                        { txtGuardian.Select(); }
                        else if (string.IsNullOrEmpty(txtGCNum.Text))
                        { txtGCNum.Select(); }
                    }
                    else if (lblStudentNumberVerified.Visible == true && objState == EntityState.Changed)
                    {
                        if (string.IsNullOrEmpty(txtYaS.Text))
                        { txtYaS.Select(); }
                        else if (string.IsNullOrEmpty(txtCNum.Text))
                        { txtCNum.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtBday.Text))
                        { txtBday.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                        { txtAddress.Select(); }
                        else if (string.IsNullOrEmpty(txtEmail.Text))
                        { txtEmail.Select(); }
                        else if (string.IsNullOrWhiteSpace(txtGuardian.Text))
                        { txtGuardian.Select(); }
                        else if (string.IsNullOrEmpty(txtGCNum.Text))
                        { txtGCNum.Select(); }
                    }
                }
                else if (txtSNum.Text != student_number)
                {
                    if (mrb1.Checked == true)
                    { yearlevel = "First Year"; }
                    else if (mrb2.Checked == true)
                    { yearlevel = "Second Year"; }
                    else if (mrb3.Checked == true)
                    { yearlevel = "Third Year"; }
                    else if (mrb4.Checked == true)
                    { yearlevel = "Fourth Year"; }
                    else if (mrb5.Checked == true)
                    { yearlevel = "Fifth Year"; }
                    
                    SetTextForStudentNumber = txtSNum.Text;
                    SetTextForFullName = txtFName.Text;
                    SetTextForYearandSection = txtYaS.Text;
                    SetTextForYearLevel = yearlevel;
                    Plexiglass pg = new Plexiglass(this);
                    EZE_StudentsFingerprintRegister cf3 = new EZE_StudentsFingerprintRegister();
                    cf3.ShowDialog();
                    pg.Close();
                }               
            }
        }
        #endregion

        #region TEXT SEARCH CHANGED
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
         try
            {
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SearchText", txtSearch.Text.Trim());
                    List<StudentsClass> list = myConn.Query<StudentsClass>("StudentsTableViewAllOrSearch", param, commandType: CommandType.StoredProcedure).ToList();
                    metroGrid1.DataSource = studentsClassBindingSource;
                    studentsClassBindingSource.DataSource = list;
                    //Sort the data to ascending order
                    list.Sort((x, y) => x.Full_Name.CompareTo(y.Full_Name)); //x,y ASC || y,x DESC
                }
            }
            catch (Exception ex)
            { MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region EXTRAS
        private void btnChangeYearLevel_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            btnChangeYearLevel.Visible = false;
            txtYaS.Enabled = true;
            pnlStudNum.Enabled = true;
            mrb1.Enabled = true;
            mrb2.Enabled = true;
            mrb3.Enabled = true;
            mrb4.Enabled = true;
            mrb5.Enabled = true;
            txtYaS.Select();
            txtYaS.Select(txtYaS.Text.Length, 0); //Set focus at the end of textbox
        }
        private void btnViewFingerprints_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            EZE_StudentsFingerprint sf = new EZE_StudentsFingerprint();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed) { db.Open(); }
                if (metroTabControl1.SelectedTab == firstyear)
                {
                    if (s11.ForeColor != Color.FromArgb(0, 174, 219) && s12.ForeColor != Color.FromArgb(0, 174, 219) && s13.ForeColor != Color.FromArgb(0, 174, 219) &&
                        s14.ForeColor != Color.FromArgb(0, 174, 219) && s15.ForeColor != Color.FromArgb(0, 174, 219) && s11p.ForeColor != Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_Level = 'First Year' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s11.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-1' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s12.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-2' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s13.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-3' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s14.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-4' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s15.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-5' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s11p.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '1-1P' Order By Full_Name ASC", commandType: CommandType.Text); }
                }              
                else if (metroTabControl1.SelectedTab == secondyear)
                {
                    if (s21.ForeColor != Color.FromArgb(0, 174, 219) && s22.ForeColor != Color.FromArgb(0, 174, 219) && s23.ForeColor != Color.FromArgb(0, 174, 219) &&
                        s24.ForeColor != Color.FromArgb(0, 174, 219) && s25.ForeColor != Color.FromArgb(0, 174, 219) && s21p.ForeColor != Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_Level = 'Second Year' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s21.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-1' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s22.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-2' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s23.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-3' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s24.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-4' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s25.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-5' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s21p.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '2-1P' Order By Full_Name ASC", commandType: CommandType.Text); }
                }
                else if (metroTabControl1.SelectedTab == thirdyear)
                {
                    if (s31.ForeColor != Color.FromArgb(0, 174, 219) && s32.ForeColor != Color.FromArgb(0, 174, 219) && s33.ForeColor != Color.FromArgb(0, 174, 219) &&
                        s34.ForeColor != Color.FromArgb(0, 174, 219) && s35.ForeColor != Color.FromArgb(0, 174, 219) && s31p.ForeColor != Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_Level = 'Third Year' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s31.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-1' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s32.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-2' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s33.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-3' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s34.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-4' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s35.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-5' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s31p.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '3-1P' Order By Full_Name ASC", commandType: CommandType.Text); }
                }
                else if (metroTabControl1.SelectedTab == fourthyear)
                {
                    if (s41.ForeColor != Color.FromArgb(0, 174, 219) && s42.ForeColor != Color.FromArgb(0, 174, 219) && s43.ForeColor != Color.FromArgb(0, 174, 219) &&
                        s44.ForeColor != Color.FromArgb(0, 174, 219) && s45.ForeColor != Color.FromArgb(0, 174, 219) && s41p.ForeColor != Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_Level = 'Fourth Year' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s41.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-1' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s42.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-2' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s43.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-3' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s44.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-4' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s45.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-5' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s41p.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '4-1P' Order By Full_Name ASC", commandType: CommandType.Text); }
                }
                else if (metroTabControl1.SelectedTab == fifthyear)
                {
                    if (s51.ForeColor != Color.FromArgb(0, 174, 219) && s52.ForeColor != Color.FromArgb(0, 174, 219) && s53.ForeColor != Color.FromArgb(0, 174, 219) &&
                        s54.ForeColor != Color.FromArgb(0, 174, 219) && s55.ForeColor != Color.FromArgb(0, 174, 219) && s51p.ForeColor != Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_Level = 'Fifth Year' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s51.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-1' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s52.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-2' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s53.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-3' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s54.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-4' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s55.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-5' Order By Full_Name ASC", commandType: CommandType.Text); }
                    else if (s51p.ForeColor == Color.FromArgb(0, 174, 219))
                    { EZE_StudentsFingerprint._instance.fingerprintsClassBindingSourceee.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-1P' Order By Full_Name ASC", commandType: CommandType.Text); }
                }
            }            
            sf.ShowDialog();
            pg.Close();
        }
        private void lblTitleForm_MouseHover(object sender, EventArgs e)
        {
            lblONOS.Visible = true;
        }
        private void lblTitleForm_MouseLeave(object sender, EventArgs e)
        {
            lblONOS.Visible = false;
        }
        private void mlNumberOfStudents_MouseHover(object sender, EventArgs e)
        {
            if (s11.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear || s12.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear || s13.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear ||
               s14.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear || s15.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear || s11p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear ||
               s21.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear || s22.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear || s23.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear ||
               s24.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear || s25.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear || s21p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear ||
               s31.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear || s32.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear || s33.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear ||
               s34.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear || s35.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear || s31p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear ||
               s41.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear || s42.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear || s43.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear ||
               s44.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear || s45.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear || s41p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear ||
               s51.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear || s52.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear || s53.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear ||
               s54.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear || s55.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear || s51p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            {
                lblNOS.Visible = true;
            }
            else if (metroTabControl1.SelectedTab == allyearlevel)
            {
                lblNOS.Text = "Academic Year" + Settings.Default.cmb;
                lblNOS.Visible = true;
            }
        }
        private void mlNumberOfStudents_MouseLeave(object sender, EventArgs e)
        {
            lblNOS.Visible = false;
        }
        private void btnAcademicYear_Click(object sender, EventArgs e)
        {
            cmbAcademicYear.Visible = true;
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelStudentDatabase.Visible = true;
        }
        public void OnClick(object sender, EventArgs e)
        {
        }
       
        protected override void WndProc(ref Message m)
        {
            if (!_instance.DesignMode)
            {
                if (m.Msg == WM_PARENTNOTIFY)
                {
                    if (m.WParam.ToInt32() == WM_LBUTTONDOWN)
                    {
                        cmbAcademicYear.Visible = false;
                    }
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        private void btnEnrollTimer_Tick(object sender, EventArgs e)
        {
            Fprintnotreg.Visible = false;
            btnEnroll.Visible = true;
            btnEnrollTimer.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
