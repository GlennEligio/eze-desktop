using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EZE
{
    public partial class messagebox2 : MetroForm
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
        public messagebox2(string _message)
        {
            InitializeComponent();
            Size = new Size(480, 180);
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
        }
        // public static properties
        public static DialogResult showdialog(string message)
        {
            messagebox2 mb2 = new messagebox2(message);
            return mb2.ShowDialog();
        }
        private void messagebox2_Load(object sender, EventArgs e)
        {
            if (lblmessage1.Text == "Student information successfully updated.")
            {
                panel1.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
                EZE_StudentsDatabase._instance.btnCancelee.Visible = true;
            }
            else if (lblmessage2.Text == "Please complete all necessary fields.")
            {
                panel2.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage2.Text == "Please complete all necessary fields before enrolling a fingerprint.")
            {
                panel2.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage3.Text == "Student information successfully saved.")
            {
                panel3.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
                EZE_StudentsDatabase._instance.btnCancelee.Visible = true;
            }
            else if (lblmessage4.Text == "Student information successfully deleted.")
            {
                panel4.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }           
            else if (lblmessage5.Text == "'Year and Section' you entered doesn't match with the 'Year Level'.")
            {
                panel5.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }                                              
            else if (lblmessage6.Text == "You already entered the maximum number of sections.")
            {
                panel6.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }                               
            else if (lblmessage7.Text == "No data available.")
            {
                panel7.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage7.Text == "No section available.")
            {
                panel7.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage8.Text == "You're attempting to add a section to this year level. Continue?")
            {
                panel8.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }          
            else if (lblmessage9.Text == "You're attempting to remove 'Section 1P' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "You're attempting to remove 'Section 5' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "You're attempting to remove 'Section 4' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "You're attempting to remove 'Section 3' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "You're attempting to remove 'Section 2' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "You're attempting to remove 'Section 1' from this year level. All information saved here will be permanently removed. You can't undone this anymore once it is deleted. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "Removing these students' information will also wipe out the fingerprint data attached to each student. Once deleted, you can't undo this. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage9.Text == "Removing this student's information will also wipe out the fingerprint data attached to this student. Once deleted, you can't undo this. Continue?")
            {
                panel9.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage10.Text == "No data available to allow export.")
            {
                panel10.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage11.Text == "Please complete the fingerprint enrollment.")
            {
                panel11.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage12.Text == "Section successfully removed from the database.")
            {
                panel12.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage13.Text == "Please enter a valid 'Year and Section'.")
            {
                panel13.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage14.Text == "This section is not available in the database.")
            {
                panel14.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage15.Text == "This student number has already registered his/her fingerprint in the database.")
            {
                panel15.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage16.Text == "Do you want to export this data to excel file?")
            {
                panel16.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
            else if (lblmessage17.Text == "Can't display information because there is no image attached for this student.")
            {
                panel17.Visible = true;
                bunifuFormFadeTransition1.ShowAsyc(this);
            }
        }
        public void btnok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
   
}

