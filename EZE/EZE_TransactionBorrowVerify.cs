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
using Dapper;
using MetroFramework.Forms;

namespace EZE
{
    public partial class EZE_TransactionBorrowVerify : MetroForm
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
        private string verified = "VERIFIED";
        public EZE_TransactionBorrowVerify()
        {
            InitializeComponent();
            Size = new Size(384, 232);
            btnDummy.Select();
        }
        private void EZE_TransactionBorrowVerify_Load(object sender, EventArgs e)
        {
            txtFName.Text = EZE_TransactionBorrow.SetTextForBorrower;
            txtProf.Text = EZE_TransactionBorrow.SetTextForProf;
            txtSNum.Text = EZE_TransactionBorrow.SetTextForSNum;
            txtVCode.Text = EZE_TransactionBorrow.SetTextForCode;
            txtEquipment.Text = EZE_TransactionBorrow.SetTextForEquipment;
            txtVERIFIED.Text = EZE_TransactionBorrow.SetTextForStatus;
        }
        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            if (txtVERIFIED.Text == verified)
            {
                MessageBox.Show("This transaction is already verified.");
                Close();
            }
            else
            {
                txtVERIFIED.Text = verified;
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand SelectCommand = new SqlCommand("Update BorrowEquipmentsTable set Status = '" + txtVERIFIED.Text + "' where Code = '" + txtVCode.Text + "'", myConn);
                    SqlDataReader dr;
                    dr = SelectCommand.ExecuteReader();

                    EZE_TransactionBorrow.FillMetroGrid();
                    Close();
                }
            }
        }
    }
}
