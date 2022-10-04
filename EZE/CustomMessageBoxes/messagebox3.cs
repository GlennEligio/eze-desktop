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

namespace EZE
{
    public partial class messagebox3 : Form
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
        public messagebox3(string _message)
        {
            InitializeComponent();
            lblmessage1.Text = _message;
            lblmessage2.Text = _message;
            lblmessage3.Text = _message;
            lblmessage4.Text = _message;
            lblmessage5.Text = _message;
            lblmessage6.Text = _message;
            lblmessage7.Text = _message;
            lblmessage8.Text = _message;
            lblmessage9.Text = _message;
            lblmessage10.Text = _message;
            lblmessage10A.Text = _message;
            lblmessage11.Text = _message;
            lblmessage11A.Text = _message;
            lblmessage12.Text = _message;
            lblmessage12A.Text = _message;
            lblmessage13.Text = _message;
            lblmessage13A.Text = _message;
            lblmessage14.Text = _message;
            lblmessage14A.Text = _message;
            lblmessage15.Text = _message;
            lblmessage16.Text = _message;
            lblmessage17.Text = _message;
            lblmessage18.Text = _message;
            lblmessage18A.Text = _message;
            lblmessage19.Text = _message;
            lblmessage20.Text = _message;
            lblmessage21.Text = _message;
            lblmessage21A.Text = _message;
            label29.Text = _message;
            Size = new Size(988, 180);
        }
        // public static properties
        public static DialogResult showdialog(string message)
        {
            messagebox3 mb3 = new messagebox3(message);
            return mb3.ShowDialog();
        }
        private void messagebox3_Load(object sender, EventArgs e)
        {           
            btnDummy.Select();
            if (lblmessage1.Text == "Fingerprint successfully saved.")
            {
                pnl1.Visible = true;
                bunifuDragControl1.TargetControl = pnl1;
            }
            else if (lblmessage2.Text == "The fingerprint template is not valid. Repeat fingerprint enrollment.")
            {
                pnl2.Visible = true;
                bunifuDragControl1.TargetControl = pnl2;
            }
            else if (lblmessage3.Text == "The fingerprint template is ready for saving.")
            {
                pnl3.Visible = true;
                bunifuDragControl1.TargetControl = pnl3;
            }
            else if (lblmessage4.Text == "")
            {
                lblmessage4.Text = "Fingerprint successfully saved.";
                pnl4.Visible = true;
                bunifuDragControl1.TargetControl = pnl4;
            }
            else if (lblmessage5.Text == "No data available.")
            {
                pnl5.Visible = true;
                bunifuDragControl1.TargetControl = pnl5;
            }
            else if (lblmessage6.Text == "Please complete all necessary fields.")
            {
                pnl6.Visible = true;
                bunifuDragControl1.TargetControl = pnl6;
            }
            else if (lblmessage7.Text == "Contact information successfully updated.")
            {
                pnl7.Visible = true;
                bunifuDragControl1.TargetControl = pnl7;
            }
            else if (lblmessage8.Text == "This contact number already exists in the database.")
            {
                pnl8.Visible = true;
                bunifuDragControl1.TargetControl = pnl8;
            }
            else if (lblmessage9.Text == "Contact information successfully saved.")
            {
                pnl9.Visible = true;
                bunifuDragControl1.TargetControl = pnl9;
            }
            else if (lblmessage10.Text == "Contact information successfully deleted.") //pinaghiwalay kona. diko pa nacheck sa contacts
            {
                pnl10.Visible = true;
                bunifuDragControl1.TargetControl = pnl10;
            }
            else if (lblmessage10A.Text == "Contact informations successfully deleted.") //pinaghiwalay kona. diko pa nacheck sa contacts
            {
                pnl10A.Visible = true;
                bunifuDragControl1.TargetControl = pnl10A;
            }
            else if (lblmessage11.Text == "Do you want to export this data to excel file?")
            {
                pnl11.Visible = true;
                bunifuDragControl1.TargetControl = pnl11;
            }
            else if (lblmessage11A.Text == "Do you want to export these data to excel file?")
            {
                pnl11A.Visible = true;
                bunifuDragControl1.TargetControl = pnl11A;
            }
            else if (lblmessage12.Text == "You're attempting to remove this contact number from the database. You can't undone this once it is deleted. Continue?") //pinaghiwalay kona. diko pa nacheck sa contacts
            {
                pnl12.Visible = true;
                bunifuDragControl1.TargetControl = pnl12;
            }
            else if (lblmessage12A.Text == "You're attempting to remove these contact numbers from the database. You can't undone this once it is deleted. Continue?") //pinaghiwalay kona. diko pa nacheck sa contacts
            {
                pnl12A.Visible = true;
                bunifuDragControl1.TargetControl = pnl12A;
            }
            else if (lblmessage13.Text == "You're attempting to remove this equipment from the database. You can't undone this once it is deleted. Continue?")
            {
                pnl13.Visible = true;
                bunifuDragControl1.TargetControl = pnl13;
            }
            else if (lblmessage13A.Text == "You're attempting to remove these equipments from the database. You can't undone this once it is deleted. Continue?")
            {
                pnl13A.Visible = true;
                bunifuDragControl1.TargetControl = pnl13A;
            }
            else if (lblmessage14.Text == "Fingerprint successfully deleted.") //pinaghiwalay kona. diko pa nacheck sa fingerprints
            {
                pnl14.Visible = true;
                bunifuDragControl1.TargetControl = pnl14;
            }
            else if (lblmessage14A.Text == "Fingerprints successfully deleted.") //pinaghiwalay kona. diko pa nacheck sa fingerprints
            {
                pnl14A.Visible = true;
                bunifuDragControl1.TargetControl = pnl14A;
            }
            else if (lblmessage15.Text == "Equipment successfully updated.")
            {
                pnl15.Visible = true;
                bunifuDragControl1.TargetControl = pnl15;
            }
            else if (lblmessage16.Text == "This serial number has already been used by another equipment.")
            {
                pnl16.Visible = true;
                bunifuDragControl1.TargetControl = pnl16;
            }
            else if (lblmessage17.Text == "Equipment successfully saved.")
            {
                pnl17.Visible = true;
                bunifuDragControl1.TargetControl = pnl17;
            }
            else if (lblmessage18.Text == "The selected fingerprint will be permanently removed from the database. Continue?") //pinaghiwalay kona. diko pa nacheck sa fingerprints
            {
                pnl18.Visible = true;
                bunifuDragControl1.TargetControl = pnl18;
            }
            else if (lblmessage18A.Text == "The selected fingerprints will be permanently removed from the database. Continue?") //pinaghiwalay kona. diko pa nacheck sa fingerprints
            {
                pnl18A.Visible = true;
                bunifuDragControl1.TargetControl = pnl18A;
            }
            else if (lblmessage19.Text == "No data available to allow export.")
            {
                pnl19.Visible = true;
                bunifuDragControl1.TargetControl = pnl19;
            }
            else if (lblmessage20.Text == "Can't edit multiple equipments at once.")
            {
                pnl20.Visible = true;
                bunifuDragControl1.TargetControl = pnl20;
            }
            else if (lblmessage21.Text == "Equipment successfully deleted.")
            {
                pnl21.Visible = true;
                bunifuDragControl1.TargetControl = pnl21;
            }
            else if (lblmessage21A.Text == "Equipments successfully deleted.")
            {
                pnl21A.Visible = true;
                bunifuDragControl1.TargetControl = pnl21A;
            }
            else if (label29.Text == "The selected fingerprints will be permanently removed from the database. Continue???")
            {
                panel1.Visible = true;
                bunifuDragControl1.TargetControl = panel1;
            }
        }
        private void userfprintok_Click(object sender, EventArgs e)
        {
            EZE_AccountsDatabase._instance.mlink.Visible = true;
            EZE_AccountsDatabase._instance.mlink1.Visible = false;
            EZE_AccountsDatabase._instance.mlink2.Visible = false;
        }
        private void studfprintok_Click(object sender, EventArgs e)
        {
            EZE_StudentsDatabase._instance.Fprinregee.Visible = true;
            EZE_StudentsDatabase._instance.btnEnrollee.Visible = false;
            EZE_StudentsDatabase._instance.btnCancelee.Visible = false;
        }        
    }
}
