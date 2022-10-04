using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EZE
{
    public partial class messagebox : Form
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
        public messagebox(string _message)
        {
            InitializeComponent();
            lblmessage.Text = _message;
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
            lblmessage11.Text = _message;
            lblmessage12.Text = _message;
            lblmessage13.Text = _message;
            lblmessage14.Text = _message;
            lblmessage15.Text = _message;
            lblmessage16.Text = _message;
            lblmessage17.Text = _message;
            lblmessage18.Text = _message;
            lblmessage19.Text = _message;
            lblmessage20.Text = _message;
            lblmessage21.Text = _message;
            lblmessage22.Text = _message;
            lblmessage23.Text = _message;
            lblmessage24.Text = _message;
            lblmessage25.Text = _message;
            lblmessage26.Text = _message;
            Size = new Size(430, 160);
        }
        public static DialogResult showdialog(string message)
        {
            messagebox mb = new messagebox(message);
            return mb.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {          
            if (lblmessage.Text == "Account successfully saved.")
            {
                panel.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
                EZE_AccountsDatabase._instance.mlink2.Visible = true;
            }
            else if (lblmessage.Text == "Schedule successfully saved.")
            {
                panel.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage1.Text == "Do you want to export this data to excel file?")
            {
                panel1.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }           
            else if (lblmessage2.Text == "This user has already registered his/her fingerprint in the database.")
            {
                panel2.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage3.Text == "Please complete all necessary fields.")
            {
                panel3.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage3.Text == "Please complete all necessary fields before enrolling a fingerprint.")
            {
                panel3.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage4.Text == "Account successfully deleted.")
            {
                panel4.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }          
            else if (lblmessage4.Text == "Fingerprint/s successfully removed from the database.")
            {
                panel4.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage4.Text == "Schedule successfully deleted.")
            {
                panel4.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage5.Text == "Password don't match. Please check and try again.")
            {
                panel5.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage6.Text == "Schedule successfully updated.")
            {
                panel6.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage6.Text == "Account successfully updated.")
            {
                panel6.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
                EZE_AccountsDatabase._instance.mlink2.Visible = true;
            }                       
            else if (lblmessage7.Text == "Please complete the fingerprint enrollment.")
            {
                panel7.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage8.Text == "No data available to allow export.")
            {
                panel8.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }                                                              
            else if (lblmessage9.Text == "No data found. Please choose another file.")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage10.Text == "Excel file imported successfully.")
            {
                panel10.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage11.Text == "You're attempting to remove this account/s from the database. You can't undone this anymore once it is deleted. Continue?")
            {
                panel11.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage11.Text == "You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?")
            {
                panel11.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }            
            else if (lblmessage12.Text == "Please choose the correct database for the excel file you want to import.")
            { 
                panel12.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage12.Text == "Can't display information because there is no image attached for this user.")
            {
                panel12.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }           
            else if (lblmessage13.Text == "This subject already exists in the database.")
            {
                panel13.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }            
            else if (lblmessage14.Text == "This section is not available in the database.")
            { 
                panel14.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage15.Text == "Image file path doesn't exist.")
            {
                panel15.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage16.Text == "Duplicate barcode found.")
            {
                panel16.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage17.Text == "Transaction successful.")
            {
                panel17.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage17.Text == "Code sent successfully.")
            {
                panel17.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage17.Text == "Verified successfully.")
            {
                panel17.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage18.Text == "The selected fingerprint/s will be permanently removed from the database. Continue?")
            {
                panel18.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage19.Text == "Total number of equipment/s recorded doesn't match the count of scanned barcode.")
            {
                panel19.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage20.Text == "Please verify your username before saving any information.")
            {
                panel20.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage21.Text == "Can't add a blank value.")
            {
                panel21.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage21.Text == "No data available.")
            {
                panel21.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage21.Text == "No section available.")
            {
                panel21.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage22.Text == "'Year and Section' you entered doesn't match with the 'Year Level'.")
            {
                panel22.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage23.Text == "Please enter a valid 'Year and Section'.")
            {
                panel23.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage24.Text == "Could not start capture operation.")
            {
                panel24.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage25.Text == "Verification code doesn't match in any transaction.")
            {
                panel25.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage26.Text == EZE_AccountsDatabase.SetTextForl13)
            {               
                panel26.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }

            if (panel.Visible == true)
            {
                bunifuDragControl1.TargetControl = label;
                line1.BackColor = Color.FromArgb(12, 83, 156);
                line2.BackColor = Color.FromArgb(12, 83, 156);
                line3.BackColor = Color.FromArgb(12, 83, 156);
                line4.BackColor = Color.FromArgb(12, 83, 156);
            }
            else if (panel1.Visible == true)
            {
                bunifuDragControl1.TargetControl = label1;
                line1.BackColor = Color.FromArgb(57, 179, 215);
                line2.BackColor = Color.FromArgb(57, 179, 215);
                line3.BackColor = Color.FromArgb(57, 179, 215);
                line4.BackColor = Color.FromArgb(57, 179, 215);
            }
            else if (panel2.Visible == true)
            {
                bunifuDragControl1.TargetControl = label2;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel3.Visible == true)
            {
                bunifuDragControl1.TargetControl = label3;
                line1.BackColor = Color.FromArgb(255, 181, 0);
                line2.BackColor = Color.FromArgb(255, 181, 0);
                line3.BackColor = Color.FromArgb(255, 181, 0);
                line4.BackColor = Color.FromArgb(255, 181, 0);
            }
            else if (panel4.Visible == true)
            {
                bunifuDragControl1.TargetControl = label4;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel5.Visible == true)
            {
                bunifuDragControl1.TargetControl = label5;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel6.Visible == true)
            {
                bunifuDragControl1.TargetControl = label6;
                line1.BackColor = Color.FromArgb(39, 101, 207);
                line2.BackColor = Color.FromArgb(39, 101, 207);
                line3.BackColor = Color.FromArgb(39, 101, 207);
                line4.BackColor = Color.FromArgb(39, 101, 207);
            }
            else if (panel7.Visible == true)
            {
                bunifuDragControl1.TargetControl = label7;
                line1.BackColor = Color.FromArgb(57, 179, 215);
                line2.BackColor = Color.FromArgb(57, 179, 215);
                line3.BackColor = Color.FromArgb(57, 179, 215);
                line4.BackColor = Color.FromArgb(57, 179, 215);
            }
            else if (panel8.Visible == true)
            {
                bunifuDragControl1.TargetControl = label8;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel9.Visible == true)
            {
                bunifuDragControl1.TargetControl = label9;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel10.Visible == true)
            {
                bunifuDragControl1.TargetControl = label10;
                line1.BackColor = Color.FromArgb(12, 83, 156);
                line2.BackColor = Color.FromArgb(12, 83, 156);
                line3.BackColor = Color.FromArgb(12, 83, 156);
                line4.BackColor = Color.FromArgb(12, 83, 156);
            }
            else if (panel11.Visible == true)
            {
                bunifuDragControl1.TargetControl = label11;
                line1.BackColor = Color.FromArgb(244, 67, 54);
                line2.BackColor = Color.FromArgb(244, 67, 54);
                line3.BackColor = Color.FromArgb(244, 67, 54);
                line4.BackColor = Color.FromArgb(244, 67, 54);
            }
            else if (panel12.Visible == true)
            {
                bunifuDragControl1.TargetControl = label12;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel13.Visible == true)
            {
                bunifuDragControl1.TargetControl = label13;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel14.Visible == true)
            {
                bunifuDragControl1.TargetControl = label14;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel15.Visible == true)
            {
                bunifuDragControl1.TargetControl = label15;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel16.Visible == true)
            {
                bunifuDragControl1.TargetControl = label16;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel17.Visible == true)
            {
                bunifuDragControl1.TargetControl = label17;
                line1.BackColor = Color.FromArgb(12, 83, 156);
                line2.BackColor = Color.FromArgb(12, 83, 156);
                line3.BackColor = Color.FromArgb(12, 83, 156);
                line4.BackColor = Color.FromArgb(12, 83, 156);
            }
            else if (panel18.Visible == true)
            {
                bunifuDragControl1.TargetControl = label18;
                line1.BackColor = Color.FromArgb(244, 67, 54);
                line2.BackColor = Color.FromArgb(244, 67, 54);
                line3.BackColor = Color.FromArgb(244, 67, 54);
                line4.BackColor = Color.FromArgb(244, 67, 54);
            }
            else if (panel19.Visible == true)
            {
                bunifuDragControl1.TargetControl = label19;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel20.Visible == true)
            {
                bunifuDragControl1.TargetControl = label20;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel21.Visible == true)
            {
                bunifuDragControl1.TargetControl = label21;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel22.Visible == true)
            {
                bunifuDragControl1.TargetControl = label22;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel23.Visible == true)
            {
                bunifuDragControl1.TargetControl = label23;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel24.Visible == true)
            {
                bunifuDragControl1.TargetControl = label24;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
            else if (panel25.Visible == true)
            {
                bunifuDragControl1.TargetControl = label25;
                line1.BackColor = Color.FromArgb(237, 87, 89);
                line2.BackColor = Color.FromArgb(237, 87, 89);
                line3.BackColor = Color.FromArgb(237, 87, 89);
                line4.BackColor = Color.FromArgb(237, 87, 89);
            }
            else if (panel26.Visible == true)
            {
                bunifuDragControl1.TargetControl = label26;
                line1.BackColor = Color.FromArgb(188, 48, 50);
                line2.BackColor = Color.FromArgb(188, 48, 50);
                line3.BackColor = Color.FromArgb(188, 48, 50);
                line4.BackColor = Color.FromArgb(188, 48, 50);
            }
        }     
    }
}
