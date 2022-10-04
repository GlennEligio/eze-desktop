using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_StudentsFingerprint : Form
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
        private EZEEntities context;
        public static EZE_StudentsFingerprint _instance;

        public BindingSource fingerprintsClassBindingSourceee
        {
            get { return fingerprintsClassBindingSource; }
            set { fingerprintsClassBindingSource = value; }
        }
        public EZE_StudentsFingerprint()
        {
            InitializeComponent();
            _instance = this;
            Size = new Size(600, 402);
            metroGrid.RowHeadersVisible = true;
        }
        private void EZE_Fingerprints_Load(object sender, EventArgs e)
        {
            context = new EZEEntities();
           // RefreshFingerprints();

            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            //{
            //    if (db.State == ConnectionState.Closed) { db.Open(); }
            //    EZE_StudentsFingerprint._instance.fingerprintsClassBindingSource.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable where Year_and_Section = '5-4'", commandType: CommandType.Text);
            //    FingerprintsClass obj = _instance.fingerprintsClassBindingSource.Current as FingerprintsClass;
            //}

        }       
        public static void RefreshFingerprints()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                _instance.fingerprintsClassBindingSource.DataSource = db.Query<FingerprintsClass>("Select * from FingerprintsTable", commandType: CommandType.Text);
                FingerprintsClass obj = _instance.fingerprintsClassBindingSource.Current as FingerprintsClass;
            }
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from FingerprintsTable";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { _instance.lblONOE.Text = "No record of any fingerprint."; }
                else
                { _instance.lblONOE.Text = "Registered fingerprints : " + rows_count.ToString(); }
            }
        }       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            mlSearch.Visible = false;
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count < 1)
            {
                messagebox3.showdialog("No data available.");
                EZE_Fingerprints_Load(sender, e);
                fingerprintsClassBindingSource.MoveFirst();
                txtSearch.Text = "";
                txtSearch.Visible = false;
                mlSearch.Visible = false;
            }
            else
            {
                if (messagebox3.showdialog("The selected fingerprint/s will be permanently removed from the database. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (var item in metroGrid.Rows)
                    {
                        DataGridViewRow row = item as DataGridViewRow;
                        if (row.Selected)
                        {
                            string snum = row.Cells[0].Value.ToString();
                            var snumm = context.FingerprintsTables.FirstOrDefault(a => a.Student_Number.Equals(snum));
                            if (snumm != null)
                            {
                                context.FingerprintsTables.Attach(snumm);
                                context.FingerprintsTables.Remove(snumm);
                                context.SaveChanges();
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    fingerprintsClassBindingSource.MoveFirst();
                    EZE_Fingerprints_Load(sender, e);
                    txtSearch.Text = "";
                    messagebox3.showdialog("Fingerprint/s successfully deleted.");
                }
            }
            pg.Close();
        }          
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            //    {
            //        if (myConn.State == ConnectionState.Closed)
            //        { myConn.Open(); }
            //        DynamicParameters param = new DynamicParameters();
            //        param.Add("@SearchText", txtSearch.Text.Trim());
            //        List<FingerprintsClass> list = myConn.Query<FingerprintsClass>("StudentsFingerprintTableViewAllOrSearch", param, commandType: CommandType.StoredProcedure).ToList();
            //        fingerprintsClassBindingSource.DataSource = list;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //if (metroGrid.Rows.Count < 1)
            //{
            //    btnDelete.Visible = false;
            //}
            //else
            //{
            //    btnDelete.Visible = true;
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtSearch.Visible == true)
            //{
            //    mlSearch.Visible = false;
            //    txtSearch.Visible = false;
            //}
            //else
            //{
            //    mlSearch.Visible = true;
            //    txtSearch.Visible = true;
            //    txtSearch.Select();
            //}         
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                //if (myConn.State == ConnectionState.Closed)
                //{ myConn.Open(); }
                //SqlCommand cmd;
                //string sql = "select count(ID) from FingerprintsTable";
                //cmd = new SqlCommand(sql, myConn);
                //int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                //if (rows_count.ToString() == "0")
                //{ lblONOE.Text = "No record of any fingerprint."; }
                //else
                //{ lblONOE.Text = "Registered fingerprints : " + rows_count.ToString(); }
                int rows_count = Convert.ToInt32(metroGrid.Rows.Count);
                lblONOE.Text = "Registered Fingerprints : " + rows_count.ToString();
                lblONOE.Visible = true;
            }
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lblONOE.Visible = false;
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
        }
        private void metroGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSearch.Visible = false;
            mlSearch.Visible = false;
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Select();
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelStudentFingerprint.Visible = true;
        }
    }
}
