using System;
using System.Data;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace EZE
{
    public partial class ViewDetails : Form
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
        public ViewDetails()
        {
            InitializeComponent();            
        }
        private void ViewDetails_Load(object sender, EventArgs e)
        {
            label1.Text = EZE_StudentsDatabase.SetTextForLabel1;
            label2.Text = EZE_StudentsDatabase.SetTextForLabel2;
            label3.Text = EZE_StudentsDatabase.SetTextForLabel3;
            label4.Text = EZE_StudentsDatabase.SetTextForLabel4;
            label5.Text = EZE_StudentsDatabase.SetTextForLabel5;
            label6.Text = EZE_StudentsDatabase.SetTextForLabel6;
            label7.Text = EZE_StudentsDatabase.SetTextForLabel7;
            label8.Text = EZE_StudentsDatabase.SetTextForLabel8;
            label9.Text = EZE_StudentsDatabase.SetTextForLabel9;
            pictureBox1.Image = EZE_StudentsDatabase.SetTextForLabel10;

            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand(" Select * from FingerprintsTable where Student_Number='"+label1.Text+"'", myConn);
                SqlDataReader dr;
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string student_number = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    student_number = dr["Student_Number"].ToString();
                }
                if (count == 1 && label1.Text == student_number)
                {
                    fprintreg.Visible = true;
                }
                else if (count != 1 && label1.Text != student_number)
                {
                    fprintnotreg.Visible = true;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
