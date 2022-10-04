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
using System.IO.Ports;

namespace EZE
{
    public partial class EZE_SAMenu : Form
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
        public static string SetTextforPersoninCharge = "";

        public EZE_SAMenu()
        {
            InitializeComponent();
             Size = new Size(988, 540);

            //// To make a circle picturebox for the user's image
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
            //Region rg = new Region(gp);
            //pictureBox2.Region = rg;
        }
        private void EZE_SAMenu_Load(object sender, EventArgs e)
        {
            btnDummy.Select();
            lblUsername.Text = EZE_StartForm.SetTextForFName;
            lblUsertype.Text = EZE_StartForm.SetTextForUserType;
            pic.Image = EZE_StartForm.SetTextForImageLocation;
        }             
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            EZE_StartForm login = new EZE_StartForm();
            login.ShowDialog();
            Close();
        }      
        private void mlTransactionHistory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_Report rpt = new EZE_Report();
                rpt.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void mlStudentDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_StudentsDatabase sdb = new EZE_StudentsDatabase();
                sdb.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void mlCamera_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_Camera cam = new EZE_Camera();
                cam.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void mlSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_Schedule sched = new EZE_Schedule();
                sched.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void mlInventory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_Inventory inv = new EZE_Inventory();
                inv.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void borrowAnItemToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
           //     Plexiglass pg = new Plexiglass(this);
                SetTextforPersoninCharge = lblUsername.Text;
                EZE_TransactionBorrow br = new EZE_TransactionBorrow();             
                br.Show();

            //    pg.Close();
                Cursor.Current = Cursors.Default;
            }          
        }
        private void returnAnItemToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_TransactionReturn rt = new EZE_TransactionReturn();
                rt.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void serialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //dataIN3 = serialPort3.ReadExisting();
            //Invoke(new System.EventHandler(ShowData));
        }
        private void btnFAQ_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            EZE_FAQs faq = new EZE_FAQs();
            faq.ShowDialog();
            pg.Close();
        }
    }
}
