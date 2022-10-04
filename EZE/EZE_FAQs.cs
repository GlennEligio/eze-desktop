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
using System.Diagnostics;

namespace EZE
{
    public partial class EZE_FAQs : Form
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
        public EZE_FAQs()
        {
            InitializeComponent();
            Size = new Size(988, 540);
        }       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dapper-plus.net");
        }           
        private void btnFAQ_Click(object sender, EventArgs e)
        {
            panel2.Visible = false; //database
            panel1.Visible = false; //excel
            panel3.Visible = true; //faqs
            if (btnFAQ1.Visible == true)
            {            
                btnExcelError.Visible = true;
                btnFAQ1.Visible = false;
            }
            else if (btnFAQ.Visible == true)
            {
                btnDatabaseError.Visible = true;
                btnFAQ.Visible = false;       
            }                
        }    
        private void btnDatabaseError_Click(object sender, EventArgs e)
        {
            panel2.Visible = true; //database
            panel1.Visible = false; //excel
            panel3.Visible = false; //faqs 
            if (btnFAQ1.Visible == true)
            {
                btnFAQ1.Visible = false;
                btnFAQ.Visible = true;
                btnExcelError.Visible = true;
                btnDatabaseError.Visible = false;
            }
            else
            {
                btnDatabaseError.Visible = false;
                btnFAQ.Visible = true;
            }
        }
        private void btnExcelError_Click(object sender, EventArgs e)
        {
            panel1.Visible = true; //excel
            panel2.Visible = false; //database
            panel3.Visible = false; //faqs
            if (btnFAQ.Visible == true)
            {
                btnFAQ.Visible = false;
                btnFAQ1.Visible = true;
                btnDatabaseError.Visible = true;
                btnExcelError.Visible = false;
            }
            else
            {
                btnFAQ1.Visible = true;
                btnExcelError.Visible = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelFAQs.Visible = true;
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}
