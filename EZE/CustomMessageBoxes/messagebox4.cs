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
using MetroFramework.Forms;

namespace EZE
{
    public partial class messagebox4 : Form
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
        public messagebox4(string _message)
        {
            InitializeComponent();
            lblmessage1.Text = _message;
            lblmessage2.Text = _message;
            lblmessage3.Text = _message;
            Size = new Size(340, 160);
        }
        public static DialogResult showdialog(string message)
        {
            messagebox4 mb = new messagebox4(message);
            return mb.ShowDialog();
        }
        private void messagebox4_Load(object sender, EventArgs e)
        {
            if (lblmessage1.Text == "This feature needs an internet connection. Do you want to continue?")
            {
                panel1.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);

                line3.Location= new Point(0, 158);
                bunifuDragControl1.TargetControl = label1;
                line1.BackColor = Color.FromArgb(57, 179, 215);
                line2.BackColor = Color.FromArgb(57, 179, 215);
                line3.BackColor = Color.FromArgb(57, 179, 215);
                line4.BackColor = Color.FromArgb(57, 179, 215);
            }
            else if (lblmessage2.Text == "")
            {
                Size = new Size(340, 200);
                panel2.Visible = true;
                pictureBox1.Image = EZE_StartForm.SetTextForImageLocation;
                lblmessage2.Text = EZE_StartForm.SetTextForFName;
                bunifuFormFadeTransition1.ShowAsyc(this);

                line3.Location = new Point(0, 198);
                bunifuDragControl1.TargetControl = label2;
                line1.BackColor = Color.FromArgb(57, 179, 215);
                line2.BackColor = Color.FromArgb(57, 179, 215);
                line3.BackColor = Color.FromArgb(57, 179, 215);
                line4.BackColor = Color.FromArgb(57, 179, 215);
            }
            else if (lblmessage3.Text == "Close the application?")
            {
                panel3.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);

                line3.Location = new Point(0, 158);
                bunifuDragControl1.TargetControl = label3;
                line1.BackColor = Color.FromArgb(244, 67, 54);
                line2.BackColor = Color.FromArgb(244, 67, 54);
                line3.BackColor = Color.FromArgb(244, 67, 54);
                line4.BackColor = Color.FromArgb(244, 67, 54);
            }
        }
    }
}
