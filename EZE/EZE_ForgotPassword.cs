using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using MetroFramework.Controls;
using MetroFramework;

namespace EZE
{
    public partial class EZE_ForgotPassword : MetroForm
    {
        public static EZE_ForgotPassword _instance;
        public static EZE_ForgotPassword Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EZE_ForgotPassword();
                }
                return _instance;
            }
        }

        #region Controls
        public Panel panell
        {
            get { return UCPnlMain; }
            set { UCPnlMain = value; }
        }
        public MetroLink BackButton
        {
            get { return btnBack; }
            set { btnBack = value; }
        }
        public MetroLink BackButton2
        {
            get { return btnBack2; }
            set { btnBack2 = value; }
        }
        public new MetroLink HelpButton
        {
            get { return btnHelp; }
            set { btnHelp = value; }
        }
        public MetroLink HelpButton2
        {
            get { return btnHelp2; }
            set { btnHelp2 = value; }
        }
        public MetroLink CloseButton
        {
            get { return btnClose; }
            set { btnClose = value; }
        }
        public MetroLink CloseButton2
        {
            get { return btnClose2; }
            set { btnClose2 = value; }
        }
        public MetroLink CloseButton3
        {
            get { return btnClose3; }
            set { btnClose3 = value; }
        }
        #endregion
        public EZE_ForgotPassword()
        {
            InitializeComponent();
        }
        private void EZE_ForgotPassword_Load(object sender, EventArgs e)
        {
            _instance = this;

            UCFP ucfp = new UCFP();
            ucfp.Dock = DockStyle.Fill;
            UCPnlMain.Controls.Add(ucfp);
            ucfp.UsernameText.Select();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!UCPnlMain.Controls.Contains(UCHelp.Instance))
            {
                UCPnlMain.Controls.Add(UCHelp.Instance);
                UCHelp.Instance.Dock = DockStyle.Fill;
                UCHelp.Instance.BringToFront();
            }
            else
            {
                UCHelp.Instance.BringToFront();
            }
            btnHelp.Visible = false;
            btnBack.Visible = false;
            btnClose.Visible = true;
        }
        private void btnHelp2_Click(object sender, EventArgs e)
        {
            if (!UCPnlMain.Controls.Contains(UCHelp.Instance))
            {
                UCPnlMain.Controls.Add(UCHelp.Instance);
                UCHelp.Instance.Dock = DockStyle.Fill;
                UCHelp.Instance.BringToFront();
            }
            else
            {
                UCHelp.Instance.BringToFront();
            }
            btnBack2.Visible = false;
            btnHelp2.Visible = false;
            btnClose3.Visible = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {           
            ActiveForm.Show();
            Close();                   
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
            var ans = MetroMessageBox.Show(this, "The code sent to you will expire once you go back. Continue to exit this page?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans == DialogResult.Yes)
            {
                ActiveForm.Show();
                Close();
            }
            else
            {
                UCFP.Instance.VerifyCodeText.Focus();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            UCPnlMain.Controls["UCFP"].BringToFront();
            btnBack.Visible = true;
            btnClose.Visible = false;
            btnHelp.Visible = true;
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {          
            Close();
            ActiveForm.Show();
        }
        private void btnClose3_Click(object sender, EventArgs e)
        {
            UCPnlMain.Controls["UCFP"].BringToFront();
            btnClose3.Visible = false;
            btnHelp2.Visible = true;
            btnBack2.Visible = true;
        }
    }
}

