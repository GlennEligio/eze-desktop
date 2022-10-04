using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using WinFormCharpWebCam;
using System.IO;
using MetroFramework.Forms;

namespace EZE
{
    public partial class EZE_Camera : Form
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
        WebCam webcam;
        public EZE_Camera()
        {
            InitializeComponent();
            Size = new Size(600, 402);
        }        
        private void EZE_Camera_Load(object sender, EventArgs e)
        {
            btnDummy.Select();
            btnCapture.Enabled = false;
            webcam = new WebCam();
            webcam.InitializeWebCam(ref pictureBox1);
            webcam.AdvanceSetting();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (btnStart.Visible == true)
            {
                webcam.Start();
                btnStop.Visible = true;
                btnStart.Visible = false;
                btnCapture.Enabled = true;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (btnStop.Visible == true)
            {
                webcam.Stop();
                btnStart.Visible = true;
                btnStop.Visible = false;
                btnCapture.Enabled = false;
                pictureBox1.Image = Properties.Resources.icons8_user_filled_100px;
            }
        }    
        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Helper.SaveImageCapture(pictureBox1.Image);
        }                    
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelCamera.Visible = true;
        }
    }
}
