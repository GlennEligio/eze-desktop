using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace EZE
{
    public partial class UCRP : UserControl
    {
        string Email = UCFP.to;

        public static UCRP _instance;
        public static UCRP Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCRP();
                return _instance;
            }
        }
        public UCRP()
        {
            InitializeComponent();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtResetPword.Text == "" || txtResetPwordVerify.Text == "")
            {
                //MetroFramework.MetroMessageBox.Show(this, "Please complete necessary fields.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                link1.Visible = true;
                timerforlabel.Start();
                txtResetPword.Focus();
            }
            else if (txtResetPword.Text == txtResetPwordVerify.Text)
            {
                string myConnnection = @"Data Source=JELO-PC\JELOSQL;Initial Catalog=EZE;Integrated Security=True";
                using (SqlConnection myConn = new SqlConnection(myConnnection))
                {
                    SqlCommand SelectCommand = new SqlCommand(" UPDATE [dbo].[AccountsTable] SET [Password] = '" + txtResetPwordVerify.Text + "' WHERE [Email] = '" + Email + "' COLLATE SQL_Latin1_General_CP1_CS_AS ", myConn);
                    myConn.Open();
                    SelectCommand.ExecuteNonQuery();

                    MetroFramework.MetroMessageBox.Show(this, "Reset successful." + " Proceed now to Login Page.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pnlRP.Enabled = false;
                    EZE_ForgotPassword.Instance.CloseButton2.Visible = true;
                }
            }
            else
            {
                //MetroFramework.MetroMessageBox.Show(this, "The new password don't match." + "\nPlease check and try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                link2.Visible = true;
                timerforlabel.Start();
                txtResetPword.Text = "";
                txtResetPwordVerify.Text = "";
                txtResetPword.Focus();
                txtResetPwordVerify.PasswordChar = '•';
                pbEyeLock.Image = Properties.Resources.icons8_hide;
            }
        }
        private void pbEyeLock_Click(object sender, EventArgs e)
        {
            if (txtResetPwordVerify.PasswordChar == '•')
            {
                txtResetPwordVerify.PasswordChar = '\0';
                pbEyeLock.Image = Properties.Resources.icons8_visible;
            }
            else
            {
                txtResetPwordVerify.PasswordChar = '•';
                pbEyeLock.Image = Properties.Resources.icons8_hide;
            }
        }        
        private void UCRP_Load(object sender, EventArgs e)
        {
            txtResetPwordVerify.PasswordChar = '•';
        }

        private void timerforlabel_Tick(object sender, EventArgs e)
        {
            link1.Visible = false;
            link2.Visible = false;
        }
    }
}

