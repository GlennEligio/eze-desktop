using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EZE
{
    public partial class ViewDetails2 : Form
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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn

 (
     int nLeftRect,     // x-coordinate of upper-left corner
     int nTopRect,      // y-coordinate of upper-left corner
     int nRightRect,    // x-coordinate of lower-right corner
     int nBottomRect,   // y-coordinate of lower-right corner
     int nWidthEllipse, // height of ellipse
     int nHeightEllipse // width of ellipse
 );

        public ViewDetails2()
        {
            InitializeComponent();
            Size = new Size(490, 200);

            //For rounded corners
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }       
        private void ViewDetails2_Load(object sender, EventArgs e)
        {
            lblFullName.Text = EZE_AccountsDatabase.SetTextForLabel1.ToUpper(); //Full name all caps
            lblUsername.Text = EZE_AccountsDatabase.SetTextForLabel2;
            lblPassword.Text = EZE_AccountsDatabase.SetTextForLabel3;
            lblUserType.Text = EZE_AccountsDatabase.SetTextForLabel4;
            lblEmail.Text = EZE_AccountsDatabase.SetTextForLabel5;
            pbUserImage.Image = EZE_AccountsDatabase.SetTextForLabel6;
            pbUserImage1.Image = EZE_AccountsDatabase.SetTextForLabel6;

            Image circle = CropToCircle.croptocircle(pbUserImage.Image, new Size(150,150), Color.White);
            Image circle1 = CropToCircle.croptocircle(pbUserImage1.Image, new Size(150, 150), Color.FromArgb(37, 170, 226));
            if (circle != null && circle1 != null)
            {
                pbUserImage.Image = circle;
                pbUserImage1.Image = circle1;
            }
            //Flash label whether registered or not
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from FingerprintsTableUser where Username='" + lblUsername.Text + "'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                string username = string.Empty;
                while (dr.Read())
                {
                    username = dr["Username"].ToString();
                }
                if (lblUsername.Text == username)
                {
                    fprintreg.Visible = true;
                }
                else if (lblUsername.Text != username)
                {
                    fprintnotreg.Visible = true;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }            
    }
}
