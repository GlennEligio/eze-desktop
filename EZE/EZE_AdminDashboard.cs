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
using Dapper;
using FontAwesome.Sharp;

namespace EZE
{
    public partial class EZE_AdminDashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public EZE_AdminDashboard()
        {
            InitializeComponent();
            customizeDesign();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(5, 40);
            panelLeftMenu.Controls.Add(leftBorderBtn);
            //Form
            //Text = string.Empty;
           // ControlBox = false;
            //DoubleBuffered = true;
           // MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }
        
        //Structs
        private struct RGBColors
        {            
            public static Color color1 = Color.FromArgb(255, 255, 0);            
        }
        private void ActivateButton(object senderBtn, Color color)
        {

            //const int WS_EX_COMPOSITED = 0x02000000;
            //CreateParams cp = base.CreateParams;
            //cp.ExStyle |= WS_EX_COMPOSITED;

            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 122, 204);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(4, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lblTitleChildForm.ForeColor = color;
                lblTitleChildForm.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 122, 204);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            // lblTitleChildForm.Text = childForm.Text;
        }
        private void customizeDesign()
        {
            panelTransaction.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void hideSubMenu()
        {
            if (panelTransaction.Visible == true)
            {
                panelTransaction.Visible = false;
            }
            //if (panelPlaylistSubmenu.Visible == true)
            //{
            //    panelPlaylistSubmenu.Visible = false;
            //}
            //if (panelToolsSubmenu.Visible == true)
            //{
            //    panelToolsSubmenu.Visible = false;
            //}
        }
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(panelTransaction);
        }
        private void btnStudentDatabase_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_StudentsDatabase());
        }
        private void btnClassSchedules_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_Schedule());
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_Inventory());
        }
        private void btnTransactionRecords_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_Report());
        }
        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_AccountsDatabase());
        }
        private void btnFaculty_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_FacultyInformation());
        }
        private void btnCamera_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EZE_Camera());
        }
        private void pbIcon_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
            lblTitleChildForm.Text = "Home";
            lblTitleChildForm.ForeColor = Color.White;
        }
        private void EZE_AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    studentsClassBindingSource.DataSource = db.Query<StudentsClass>("Select * from StudentsTable", commandType: CommandType.Text);
                    studentsClassBindingSource1.DataSource = db.Query<StudentsClass>("Select * from StudentsTable", commandType: CommandType.Text);
                    StudentsClass obj = studentsClassBindingSource.Current as StudentsClass;
                    StudentsClass obj1 = studentsClassBindingSource1.Current as StudentsClass;
                    metroGrid.Sort(metroGrid.Columns["Birthday"], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                //  Plexiglass pg = new Plexiglass(this);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  pg.Close();
            }
        }
    }
}
