using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using EZE.Properties;
using System.Drawing.Drawing2D;

namespace EZE
{
    public partial class EZE_AdminMenu : Form
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

        public EZE_AdminMenu()
        {
            InitializeComponent();          
            Size = new Size(988, 540);

            //// To make a circle picturebox for the user's image
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(0, 0, pbUser.Width - 3, pbUser.Height - 3);
            //Region rg = new Region(gp);
            //pbUser.Region = rg;
        }
        //private void EZE_AdminMenu_Activated(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        //  Extensions.Restore(this);     
               
        //        WindowState = FormWindowState.Normal;
               
        //    }
        //}
        private void EZE_AdminMenu_Load(object sender, EventArgs e)
        {
            btnDummy.Select();
            lblUsername.Text = EZE_StartForm.SetTextForFName;
            lblUsertype.Text = EZE_StartForm.SetTextForUserType;
            pic.Image = EZE_StartForm.SetTextForImageLocation;

            //Image circle = CropToCircle.croptocircle(pbUser.Image, new Size(120, 120), Color.FromArgb(0, 122, 204));
            //if (circle != null)
            //{
            //    pbUser.Image = circle;
            //}
        }       
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            EZE_StartForm login = new EZE_StartForm();
            login.ShowDialog();
            Close();
        }
        private void mlStudentsDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                using (EZE_StudentsDatabase s = new EZE_StudentsDatabase())
                {
                    s.ShowInTaskbar = false;
                    s.Owner = this;
                    s.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
                pg.Close();

                //Cursor.Current = Cursors.WaitCursor;
                //Plexiglass pg = new Plexiglass(this);
                //EZE_StudentsDatabase sdb = new EZE_StudentsDatabase();
                //sdb.ShowInTaskbar = false;
                //sdb.Owner = this;
                //sdb.ShowDialog();
                //pg.Close();
                //Cursor.Current = Cursors.Default;
            }
        }
        private void mlTransactions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_Report trans = new EZE_Report();
                trans.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void mlAccounts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                //EZE_AccountsDatabase acc = new EZE_AccountsDatabase();
                //acc.ShowDialog();

                using (EZE_AccountsDatabase s = new EZE_AccountsDatabase())
                {
                    s.ShowInTaskbar = false;
                    s.Owner = this;
                    s.ShowDialog();
                }

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
        private void mlFaculty_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.WaitCursor;
                Plexiglass pg = new Plexiglass(this);
                EZE_FacultyInformation fac = new EZE_FacultyInformation();
                fac.ShowDialog();
                pg.Close();
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnFAQ_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Plexiglass pg = new Plexiglass(this);
            EZE_FAQs faq = new EZE_FAQs();
            faq.ShowDialog();
            pg.Close();
            Cursor.Current = Cursors.Default;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
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
    }
}