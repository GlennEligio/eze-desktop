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
using System.Configuration;
using Dapper;
using System.Net;
using System.Net.Mail;
using MetroFramework.Controls;
using MetroFramework;

namespace EZE
{
    public partial class UCFP : UserControl
    {
        string randomCode;
        public static string to;

        public static UCFP _instance;
        public static UCFP Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCFP();
                return _instance;
            }
        }
        public MetroTextBox VerifyCodeText
        {
            get { return txtVerifyCode; }
            set { txtVerifyCode = value; }
        }
        public MetroTextBox UsernameText
        {
            get { return txtUsername; }
            set { txtUsername = value; }
        }
        public MetroButton SendButton
        {
            get { return btnSend; }
            set { btnSend = value; }
        }
        public Panel Panelfp
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        public Panel Panelfp1
        {
            get { return panel2; }
            set { panel2 = value; }
        }     
        public UCFP()
        {
            InitializeComponent();
        }      
        private void btnVerifyEmail_Click(object sender, EventArgs e)
        {
            try
            {
                btnDummy.Select();                
                if (txtUsername.Text == "")
                {
                    link2.Visible = true;
                    txtUsername.Focus();
                    var t = new Timer();
                    t.Interval = 1000; // it will Tick in n seconds
                    t.Tick += (s, f) =>
                    {
                        link2.Visible = false;
                        t.Stop();
                    };
                    t.Start();
                }
                else if (txtEmail.Text == "")
                {
                    link3.Visible = true;
                    txtUsername.Focus();
                    var t = new Timer();
                    t.Interval = 1000; // it will Tick in n seconds
                    t.Tick += (s, f) =>
                    {
                        link3.Visible = false;
                        t.Stop();
                    };
                    t.Start();
                }
                else if (txtUsername.Text == "" && txtEmail.Text == "")
                {
                    link1.Visible = true;
                    txtUsername.Focus();
                    var t = new Timer();
                    t.Interval = 1000; // it will Tick in n seconds
                    t.Tick += (s, f) =>
                    {
                        link1.Visible = false;
                        t.Stop();
                    };
                    t.Start();
                }
                //else
                //{
                //    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                //    {
                //        if (myConn.State == ConnectionState.Closed)
                //        { myConn.Open(); }
                //        SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable where Username ='"+txtUsername.Text+"'", myConn);
                //        SqlDataReader dr;
                //        dr = SelectCommand.ExecuteReader();
                //        int count = 0;
                //        string username = string.Empty;
                //        string email = string.Empty;
                //        while (dr.Read())
                //        {
                //            count = count + 1;
                //            username = dr["Username"].ToString();
                //            email = dr["Email"].ToString();
                //        }
                //        if (txtUsername.Text == username && txtEmail.Text == email)
                //        {
                //            link6.Visible = true;
                //            btnVerifyEmail.Visible = false;
                //            btnSend.Visible = true;
                //            panel1.Enabled = false;
                //            btnDummy.Select();
                //            var t = new Timer();
                //            t.Interval = 1000; // it will Tick in n seconds
                //            t.Tick += (s, f) =>
                //            {
                //                link6.Visible = false;
                //                t.Stop();
                //            };
                //            t.Start();
                //        }
                //        else if (txtUsername.Text == username && txtEmail.Text != email)
                //        {
                //            link4.Visible = true;
                //            txtEmail.Text = "";
                //            txtEmail.Focus();
                //            var t = new Timer();
                //            t.Interval = 1000; // it will Tick in n seconds
                //            t.Tick += (s, f) =>
                //            {
                //                link4.Visible = false;
                //                t.Stop();
                //            };
                //            t.Start();
                //        }
                //        else if (txtUsername.Text != username && txtEmail.Text != email)
                //        {
                //            link5.Visible = true;
                //            txtEmail.Text = "";
                //            txtUsername.Text = "";
                //            txtUsername.Focus();
                //            var t = new Timer();
                //            t.Interval = 1000; // it will Tick in n seconds
                //            t.Tick += (s, f) =>
                //            {
                //                link5.Visible = false;
                //                t.Stop();
                //            };
                //            t.Start();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnDummy.Select();
                string from, pass, messageBody;
                Random rand = new Random();
                randomCode = rand.Next(999999).ToString();
                MailMessage message = new MailMessage();
                to = txtEmail.Text.ToString();
                from = "ezeteam101@gmail.com";
                pass = "bestthesis101";
                messageBody = "Your reset code is " + randomCode + " .." + "\nThank you!";
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Password resetting code";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                smtp.Send(message);
                MetroMessageBox.Show(this, "Code sent successfully." + "\nPlease check your Email now.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                panel2.Enabled = true;
                btnSend.Enabled = false;
                EZE_ForgotPassword.Instance.BackButton.Visible = false;
                EZE_ForgotPassword.Instance.HelpButton.Visible = false;
                EZE_ForgotPassword.Instance.HelpButton2.Visible = true;
                EZE_ForgotPassword.Instance.BackButton2.Visible = true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (txtVerifyCode.Text == "")
            {
                link8.Visible = true;
                txtVerifyCode.Focus();
                var t = new Timer();
                t.Interval = 1000; // it will Tick in n seconds
                t.Tick += (s, f) =>
                {
                    link8.Visible = false;
                    t.Stop();
                };
                t.Start();
            }
            else if (!EZE_ForgotPassword.Instance.UCPnlMain.Controls.ContainsKey("UCRP") && randomCode == txtVerifyCode.Text.ToString())
            {
                to = txtEmail.Text;

                UCRP un = new UCRP();
                un.Dock = DockStyle.Fill;
                EZE_ForgotPassword.Instance.UCPnlMain.Controls.Add(un);
                EZE_ForgotPassword.Instance.UCPnlMain.Controls["UCRP"].BringToFront();
                EZE_ForgotPassword.Instance.BackButton.Visible = false;
                EZE_ForgotPassword.Instance.HelpButton.Visible = false;
                EZE_ForgotPassword.Instance.BackButton2.Visible = false;
                EZE_ForgotPassword.Instance.HelpButton2.Visible = false;
            }
            else
            {
                link7.Visible = true;
                txtVerifyCode.Text = "";
                txtVerifyCode.Focus();
                var t = new Timer();
                t.Interval = 1000; // it will Tick in n seconds
                t.Tick += (s, f) =>
                {
                    link7.Visible = false;
                    t.Stop();
                };
                t.Start();
            }                       
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
                btnVerifyEmail_Click(sender, e);
            }
        }
    }
}







