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

namespace EZE
{
    public partial class Validation : Form
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
       

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
   (
       int nLeftRect,     // x-coordinate of upper-left corner
       int nTopRect,      // y-coordinate of upper-left corner
       int nRightRect,    // x-coordinate of lower-right corner
       int nBottomRect,   // y-coordinate of lower-right corner
       int nWidthEllipse, // height of ellipse
       int nHeightEllipse // width of ellipse
   );

        public Validation(string _message)
        {
            InitializeComponent();
            l1.Text = _message;    //USERNAME REQUIRED
                                   //PROF NAME REQUIRED                                   
                                   //CONTACT NUMBER REQUIRED
                                   //NO SPECIAL CHARACTERS
                                   //NO SPECIAL CHARACTERS OR DIGITS
                                   //NO SPECIAL CHARACTERS OR LETTERS
                                   //USERNAME TAKEN
                                   //VERIFY PROF NAME
                                   //PASSWORDS DON'T MATCH (ADD AND EDIT FEATURE)
                                   //PROF NAME ALREADY REGISTERED
                                   //NAME OF EQUIPMENT REQUIRED
                                   //CONTACT NUMBER REQUIRED


            l4.Text = _message;    //VERIFYING USERNAME
                                   //VERIFYING PROF NAME
                                   //VERIFYING STUDENT NUMBER

            l16.Text = _message;   //DELETE ACCOUNT
                                   //DELETE ACCOUNTS
            l5.Text = _message;    //DELETE FINGERPRINT/S
                                   //DELETE EQUIPMENT
                                   //DELETE EQUIPMENTS
            l6.Text = _message;    //DELETE FINGERPRINT SUCCESS        
                                   //DELETE FINGERPRINTS SUCCESS
                                   //DELETE USER ACCOUNT SUCCESS
                                   //DELETE USER ACCOUNTS SUCCESS
                                   //DELETE EQUIPMENT SUCCESS
                                   //DELETE EQUIPMENTS SUCCESS
            l7.Text = _message;    //NO DATA TO DELETE
                                   //NO DATA TO EDIT
                                   //NO DATA TO EXPORT
                                   //NO DATA TO FLASH ANY INFORMATION
            l8.Text = _message;    //COMPLETE NECESSARY FIELDS
                                   //COMPLETE FINGERPRINT ENROLLMENT
            l8A.Text = _message;   //COMPLETE NECESSARY FIELDS THEN ENROLL FINGERPRINT
            l9.Text = _message;    //USER TYPE REQUIRED
                                   //GOOD OR DEFECTIVE
            l10.Text = _message;   //PASSWORD NO SPECIAL CHAR               
            l12.Text = _message;   //ACCOUNT SAVED
                                   //EQUIPMENT SAVED                      
                                   //USER FINGERPRINT SAVED
                                   //CONTACT INFO SAVED
                                   //ACCOUNT UPDATED
                                   //EQUIPMENT UPDATED
                                   //CONTACT INFO UPDATED
                                   //BARCODE REQUIRED
                                   //STUDENT INFO SAVED
                                   //STUDENT FINGERPRINT SAVED

            l13.Text = _message;   //WRONG IMAGE FILE PATH
            l14.Text = _message;   //FINGERPRINT TEMPLATE READY TO SAVE
            l14A.Text = _message;  //FINGERPRINT TEMPLATE NOT VALID
            l15.Text = _message;   //CANT EDIT MULTIPLE ACCOUNTS AT ONCE
                                   //CANT DISPLAY MULTIPLE PROFILES AT ONCE
                                   //CANT EDIT MULTIPLE EQUIPMENTS AT ONCE
                                   //CANT EDIT MULTIPLE CONTACTS AT ONCE
          
            l17.Text = _message;   //EXPORT ACCOUNT/S
                                   //EXPORT EQUIPMENT/S
            l18.Text = _message;   //SERIAL NUMBER NOT AVAILABLE
                                   //CONTACT NUMBER NOT AVAILABLE

            l19.Text = _message;   //CANT DISPLAY INFORMATION
                                   //NO SPECIAL CHAR FOR STUDENT NUMBER


            //For rounded corners
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Size = new Size(440, 100);


            // To make a circle panel for the user's image
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(0, 0, p13.Width - 1, p13.Height - 1);
            //Region rg = new Region(gp);
            //p13.Region = rg;
        }
        public static DialogResult showdialog(string message)
        {
            Validation V = new Validation(message);
            return V.ShowDialog();
        }
        private void Validation_Load(object sender, EventArgs e)
        {
               btnDummy.Select();
            //USERNAME REQUIRED || PROF NAME REQUIRED || NO SPECIAL CHARACTERS || NO SPECIAL CHARACTERS OR DIGITS || USERNAME TAKEN
            //VERIFY PROF NAME || NO SPECIAL CHARACTERS OR LETTERS || PASSWORDS DON'T MATCH || PROF NAME ALREADY REGISTERED
            //NAME OF EQUIPMENT REQUIRED || BARCODE REQUIRED || CONTACT NUMBER REQUIRED
            if (l1.Text == "Username is required. Don't leave it as blank." || l1.Text == "Professor's name is required." ||
                l1.Text == "No special characters are allowed." || l1.Text == "No special characters or digits are allowed." ||
                l1.Text == "This username is already taken." || l1.Text == "To proceed, please verify the professor's name." ||
                l1.Text == "Contact number is required." || l1.Text == "No special characters or letters are allowed." ||
                l1.Text == "Passwords you have entered don't match." || l1.Text == "Passwords don't match. Please try again." ||
                l1.Text == "This name is already registered in the database." || l1.Text == "Description or name of equipment is required." ||
                l1.Text == "Barcode or serial number is required.")
            {
                p1.Visible = true;
                bunifuDragControl1.TargetControl = p1;
                bunifuDragControl2.TargetControl = l1;
                bunifuDragControl3.TargetControl = h1;
                bunifuDragControl4.TargetControl = pb1;
            }            
           
            //VERIFYING USERNAME || VERIFYING PROF NAME || VERIFYING STUDENT NUMBER
            else if (l4.Text == "Do you want to use this as your username? Once selected, you can't change it anymore." ||
                l4.Text == "This is currently your recorded name in the database. Do you want to change it?" ||
                l4.Text == "Do you want to register this student number? Once selected, you can't change it anymore.")
            {
                p4.Visible = true;
                bunifuDragControl1.TargetControl = p4;
                bunifuDragControl2.TargetControl = l4;
                bunifuDragControl3.TargetControl = h4;
                bunifuDragControl4.TargetControl = pb4;
            }
            //DELETE FINGERPRINT/S || DELETE EQUIPMENT/S || DELETE CONTACT/S
            else if (l5.Text == "The selected fingerprint data will be removed. Once deleted, you can't undo this. Continue?" ||
                l5.Text == "The selected equipment will be removed. Once deleted, you can't undo this. Continue?" ||
                l5.Text == "The selected equipments will be removed. Once deleted, you can't undo this. Continue?" ||
                l5.Text == "The selected contact detail will be removed. Once deleted, you can't undo this. Continue?" ||
                l5.Text == "The selected contact details will be removed. Once deleted, you can't undo this. Continue?")
            {
                p5.Visible = true;
                bunifuDragControl1.TargetControl = p5;
                bunifuDragControl2.TargetControl = l5;
                bunifuDragControl3.TargetControl = h5;
                bunifuDragControl4.TargetControl = pb5;
            }
            //DELETE FINGERPRINT/S SUCCESS || DELETE USER ACCOUNT/S SUCCESS || DELETE EQUIPMENT/S SUCCESS
            //DELETE CONTACT DETAIL/S SUCCESS
            else if (l6.Text == "Fingerprint was successfully deleted." || l6.Text == "Fingerprints were successfully deleted." ||
                l6.Text == "User account was successfully deleted." || l6.Text == "User accounts were successfully deleted." ||
                l6.Text == "Equipment was successfully deleted." || l6.Text == "Equipments were successfully deleted." ||
                l6.Text == "Contact detail was successfully deleted." || l6.Text == "Contact details were successfully deleted.")
            {
                p6.Visible = true;
                bunifuDragControl1.TargetControl = p6;
                bunifuDragControl2.TargetControl = l6;
                bunifuDragControl3.TargetControl = h6;
                bunifuDragControl4.TargetControl = pb6;
            }
            //NO DATA FOUND DELETE || NO DATA FOUND EDIT || NO DATA FOUND EXPORT || NO DATA FOUND TO FLASH ANY INFORMATION
            else if (l7.Text == "No data found. Delete isn't available." || l7.Text == "No data found. Edit isn't available."
                || l7.Text == "No data found. Export isn't available." || l7.Text == "No data found. Can't display any information.")
            {
                p7.Visible = true;
                bunifuDragControl1.TargetControl = p7;
                bunifuDragControl2.TargetControl = l7;
                bunifuDragControl3.TargetControl = h7;
                bunifuDragControl4.TargetControl = pb7;
            }
            //COMPLETE NECESSARY FIELDS || COMPLETE FINGERPRINT ENROLLMENT
            else if (l8.Text == "Please complete all the necessary fields." || l8.Text == "Please complete the fingerprint enrollment.")
            {
                p8.Visible = true;
                bunifuDragControl1.TargetControl = p8;
                bunifuDragControl2.TargetControl = l8;
                bunifuDragControl3.TargetControl = h8;
                bunifuDragControl4.TargetControl = pb8;
            }           
            //COMPLETE NECESSARY FIELDS THEN ENROLL FINGERPRINT
            else if (l8A.Text == "Please complete all the necessary fields. Then click for 'Enroll Fingerprint'.")
            {
                p8A.Visible = true;
                bunifuDragControl1.TargetControl = p8A;
                bunifuDragControl2.TargetControl = l8A;
                bunifuDragControl3.TargetControl = h8A;
                bunifuDragControl4.TargetControl = pb8A;
            }
            //USER TYPE REQUIRED || GOOD OR DEFECTIVE
            else if (l9.Text == "User type is required.\nAdministrator or Student Assistant?" || l9.Text == "Status of equipment is required.\nGOOD or DEFECTIVE?")
            {               
                p9.Visible = true;
                bunifuDragControl1.TargetControl = p9;
                bunifuDragControl2.TargetControl = l9;
                bunifuDragControl3.TargetControl = h9;
                bunifuDragControl4.TargetControl = pb9;
            }
            //PASSWORD NO SPECIAL CHAR
            else if (l10.Text == "Password doesn't support special characters.")
            {
                p10.Visible = true;
                bunifuDragControl1.TargetControl = p10;
                bunifuDragControl2.TargetControl = l10;
                bunifuDragControl3.TargetControl = h10;
                bunifuDragControl4.TargetControl = pb10;
            }            
            //ACCOUNT SAVED || USER FINGERPRINT SAVED || EQUIPMENT SAVED || ACCOUNT UPDATED || EQUIPMENT UPDATED
            //CONTACT INFO SAVED || CONTACT INFO UPDATED || STUDENT INFO SAVED || STUDENT FINGERPRINT SAVED
            else if (l12.Text == "Account was successfully saved." || l12.Text == "Fingerprint was successfully saved." ||
                l12.Text == "Equipment was successfully saved." || l12.Text == "Account was successfully updated." ||
                l12.Text == "Equipment was successfully updated." || l12.Text == "Contact information was successfully saved." ||
                l12.Text == "Contact information was successfully updated." || l12.Text == "Student information was successfully saved." ||
                l12.Text == "")
            {
                p12.Visible = true;
                bunifuDragControl1.TargetControl = p12;
                bunifuDragControl2.TargetControl = l12;
                bunifuDragControl3.TargetControl = h12;
                bunifuDragControl4.TargetControl = pb12;

                if (l12.Text == "Fingerprint was successfully saved.")
                {
                    btn12.Visible = false;
                    btnUserFprintOK.Visible = true;
                }
                else if (l12.Text == "Account was successfully saved.")
                {
                    EZE_AccountsDatabase._instance.mlink2.Visible = true; //Visible na ulet yung cancel after maclick yung save button
                    EZE_AccountsDatabase._instance.mlink3.Enabled = true; //Enabled na ulet yung txtFName after maclick yung save button
                }
                else if (l12.Text == "")
                {
                    l12.Text = "Fingerprint was successfully saved.";
                    btn12.Visible = false;
                    btnStudentFprintOK.Visible = true;
                }
                else if (l12.Text == "Student information was successfully saved.")
                {
                    EZE_StudentsDatabase._instance.btnCancelee.Visible = true; //Visible na ulet yung cancel after maclick yung save button
                    EZE_StudentsDatabase._instance.txtFNameee.Enabled = true; //Enabled na ulet yung txtFName after maclick yung save button
                    EZE_StudentsDatabase._instance.txtYasee.Enabled = true; //Enabled na ulet yung txtYaS after maclick yung save button
                }
            }          
            //WRONG IMAGE FILE PATH
            else if (l13.Text == EZE_AccountsDatabase.SetTextForl13)
            {
                p13.Visible = true;
                bunifuDragControl1.TargetControl = p13;
                bunifuDragControl2.TargetControl = l13;
                bunifuDragControl3.TargetControl = h13;
                bunifuDragControl4.TargetControl = pb13;
            }
            //FINGERPRINT TEMPLATE READY TO SAVE
            else if (l14.Text == "The fingerprint template is ready for saving.")
            {
                p14.Visible = true;
                bunifuDragControl1.TargetControl = p14;
                bunifuDragControl2.TargetControl = l14;
                bunifuDragControl3.TargetControl = h14;
                bunifuDragControl4.TargetControl = pb14;
            }
            //FINGEPRINT TEMPLATE NOT VALID
            else if (l14A.Text == "The fingerprint template is not valid. Please repeat the fingerprint enrollment.")
            {
                p14A.Visible = true;
                bunifuDragControl1.TargetControl = p14A;
                bunifuDragControl2.TargetControl = l14A;
                bunifuDragControl3.TargetControl = h14A;
                bunifuDragControl4.TargetControl = pb14A;
            }
            //CANT EDIT MULTIPLE ACCOUNTS AT ONCE || CANT DISPLAY MULTIPLE ACCOUNTS AT ONCE || CANT EDIT MULTIPLE EQUIPMENTS AT ONCE
            //CANT EDIT MULTIPLE CONTACTS AT ONCE
            else if (l15.Text == "Can't edit multiple accounts at once." || l15.Text == "Can't display multiple profiles at once." ||
                l15.Text == "Can't edit multiple equipments at once." || l15.Text == "Can't edit multiple contacts at once.")
            {
                p15.Visible = true;
                bunifuDragControl1.TargetControl = p15;
                bunifuDragControl2.TargetControl = l15;
                bunifuDragControl3.TargetControl = h15;
                bunifuDragControl4.TargetControl = pb15;
            }                      
            //DELETE ACCOUNT || DELETE ACCOUNTS
            else if (l16.Text == "Removing this data will also wipe the fingerprint attached to this user. Once deleted, you can't undo this. Continue?" ||
                l16.Text == "Removing these data will also wipe the fingerprints attached to each user. Once deleted, you can't undo this. Continue?")
            {
                p16.Visible = true;
                bunifuDragControl1.TargetControl = p16;
                bunifuDragControl2.TargetControl = l16;
                bunifuDragControl3.TargetControl = h16;
                bunifuDragControl4.TargetControl = pb16;
            }            
            //EXPORT ACCOUNT/S || EXPORT EQUIPMENT/S
            else if (l17.Text == "All the data in this table will be exported to an excel file. Continue?")
            {
                p17.Visible = true;
                bunifuDragControl1.TargetControl = p17;
                bunifuDragControl2.TargetControl = l17;
                bunifuDragControl3.TargetControl = h17;
                bunifuDragControl4.TargetControl = pb17;
            }
            //SERIAL NUMBER NOT AVAILABLE || CONTACT NUMBER NOT AVAILABLE
            else if (l18.Text == "This serial number has already been used by another equipment." || l18.Text == "This contact number is already registered in the database.")
            {
                p18.Visible = true;
                bunifuDragControl1.TargetControl = p18;
                bunifuDragControl2.TargetControl = l18;
                bunifuDragControl3.TargetControl = h18;
                bunifuDragControl4.TargetControl = pb18;
            }
            //CANT DIPLAY INFORMATION || NO SPECIAL CHAR FOR STUDENT NUMBER
            else if (l19.Text == "Can't display information because there is no image attached for this account." ||
                l19.Text == "No special characters or lower case letters are allowed for student number.")
            {
                p19.Visible = true;
                bunifuDragControl1.TargetControl = p19;
                bunifuDragControl2.TargetControl = l19;
                bunifuDragControl3.TargetControl = h19;
                bunifuDragControl4.TargetControl = pb19;
            }
        }
        private void btnUserFprintOK_Click(object sender, EventArgs e)
        {
            EZE_AccountsDatabase._instance.mlink.Visible = true; //lblFingerprint is visible na
            EZE_AccountsDatabase._instance.mlink1.Visible = false; //btnEnrollFprint not visible na
            EZE_AccountsDatabase._instance.mlink2.Visible = false; //btnCancel not visible na
            EZE_AccountsDatabase._instance.mlink3.Enabled = false; //txtFName not enabled na
            btn12.Visible = true;
            btnUserFprintOK.Visible = false;
        }
        private void btnStudentFprintOK_Click(object sender, EventArgs e)
        {
            EZE_StudentsDatabase._instance.Fprinregee.Visible = true; //lblFingerprint is visible na
            EZE_StudentsDatabase._instance.btnEnrollee.Visible = false; //btnEnrollFprint not visible na
            EZE_StudentsDatabase._instance.btnCancelee.Visible = false; //btnCancel not visible na
            EZE_StudentsDatabase._instance.txtFNameee.Enabled = false; //txtFName not enabled na
            EZE_StudentsDatabase._instance.txtYasee.Enabled = false; //txtYaS not enabled na
            btn12.Visible = true;
            btnStudentFprintOK.Visible = false;

        }
    }
}
