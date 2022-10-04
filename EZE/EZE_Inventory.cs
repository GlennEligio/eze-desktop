using Dapper;
using EZE.ADO.NetModels;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZE
{
    public partial class EZE_Inventory : Form
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
       
        private string status;
        private string datetime;
        private EZEEntities3 context;
        public static EZE_Inventory _instance;
        public EZE_Inventory()
        {
            InitializeComponent();
            _instance = this;
            Size = new Size(988, 540);
            datetimer.Start();
            txtSearch.Click += TextBoxOnClick;
            // SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            metroGrid.RowHeadersVisible = true;
       //     metroGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            //  EnableDoubleBuffering();
        }
        private void EnableDoubleBuffering()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        #region DATE AND TIME
        private void datetimer_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lbldatetime.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        #endregion

        #region INVENTORY LOAD
        private void EZE_Inventory_Load(object sender, EventArgs e)
        {
            context = new EZEEntities3();
            RefreshEquipments();
        }
        public static void RefreshEquipments()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    _instance.equipmentsClassBindingSource.DataSource = db.Query<EquipmentsClass>("Select * from EquipmentsTable", commandType: CommandType.Text);
                    EquipmentsClass obj = _instance.equipmentsClassBindingSource.Current as EquipmentsClass;
                    if (obj != null)
                    {
                        if (obj.Status == "GOOD")
                        {
                            _instance.metroRadioButton1.Checked = true;
                        }
                        else if (obj.Status == "DEFECTIVE")
                        {
                            _instance.metroRadioButton2.Checked = true;
                        }
                        else if (string.IsNullOrWhiteSpace(obj.Status))
                        {
                            _instance.metroRadioButton1.Checked = false;
                            _instance.metroRadioButton2.Checked = false;
                        }
                    }
                }
                //Count number of equipments
                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (myConn.State == ConnectionState.Closed)
                    { myConn.Open(); }
                    SqlCommand cmd;
                    string sql = "select count(ID) from EquipmentsTable";
                    cmd = new SqlCommand(sql, myConn);
                    int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (rows_count.ToString() == "0")
                    { _instance.lblONOE.Text = "No record of any equipment."; }
                    else
                    { _instance.lblONOE.Text = "Total number of equipments : " + rows_count.ToString(); }
                }
            }
            catch (Exception ex)
            {
                Plexiglass pg = new Plexiglass(_instance);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }
        }
        #endregion

        #region ADD BUTTON
        EntityState objState = EntityState.Unchanged;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtDescription.Select();
            objState = EntityState.Added;
            equipmentsClassBindingSource.Add(new EquipmentsClass());
            equipmentsClassBindingSource.MoveLast();  //No data sa grid dahil dito
            metroGrid.Visible = false;
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnRefresh.Visible = false;
            btnSearch.Visible = false;
            btnImport.Visible = false;
            btnExport.Visible = false;
            line1.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            txtSearch.Visible = false;
            mlSearch.Visible = false;
        }
        #endregion

        #region EDIT BUTTON
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtDescription.Select();
                txtSearch.Visible = false;
                mlSearch.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                if (metroGrid.Rows.Count < 1)
                {
                    Plexiglass pg = new Plexiglass(this);
                    Validation.showdialog("No data found. Edit isn't available.");
                    pg.Close();
                }
                else if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
                {
                    Plexiglass pg = new Plexiglass(this);
                    Validation.showdialog("Can't edit multiple equipments at once.");
                    pg.Close();
                }
                else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
                {
                    txtDescription.Select(); //Set focus
                    txtDescription.Select(txtDescription.Text.Length, 0); //Set focus at the end of textbox

                    btnImport.Visible = false;
                    btnExport.Visible = false;
                    line1.Visible = false;
                    objState = EntityState.Changed;
                    EZE_Inventory_Load(sender, e);
                    metroGrid.Visible = false;
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnRefresh.Visible = false;
                    btnSearch.Visible = false;
                    txtSerialNumberDummy.Text = txtSerialNumber.Text;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                txtDescription.Select(); //Set focus
                txtDescription.Select(txtDescription.Text.Length, 0); //Set focus at the end of textbox

                txtSearch.Visible = false;
                mlSearch.Visible = false;
                btnImport.Visible = false;
                btnExport.Visible = false;
                line1.Visible = false;
                objState = EntityState.Changed;
                metroGrid.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnRefresh.Visible = false;
                btnSearch.Visible = false;
                txtSerialNumberDummy.Text = txtSerialNumber.Text;
            }
            else if (!string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count > 1)
            {
                btnDummy.Select();
                txtSearch.Visible = false;
                mlSearch.Visible = false;
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("Can't edit multiple equipments at once.");
                pg.Close();
                txtSearch.Visible = true;
                mlSearch.Visible = true;
                txtSearch.Select();
            }
            else if (!string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Rows.Count < 1)
            {
                btnDummy.Select();
                txtSearch.Visible = false;
                mlSearch.Visible = false;
                Plexiglass pg = new Plexiglass(this);
                Validation.showdialog("No data found. Edit isn't available.");
                pg.Close();
                txtSearch.Visible = true;
                mlSearch.Visible = true;
                txtSearch.Select();
            }
        }
        #endregion

        #region DELETE BUTTON
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            txtSearch.Visible = false;
            mlSearch.Visible = false;
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                if (Validation.showdialog("The selected equipments will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        EquipmentsTable equip = new EquipmentsTable()
                        {
                            Barcode = row.Cells[0].Value.ToString(),
                            Equipment = row.Cells[1].Value.ToString(),
                            Status = row.Cells[2].Value.ToString(),
                            Defective_Since = lbldatetime.ToString()
                        };
                        context.EquipmentsTables.Attach(equip);
                        context.EquipmentsTables.Remove(equip);
                        context.SaveChanges();
                    }
                    Cursor.Current = Cursors.Default;
                    equipmentsClassBindingSource.MoveFirst();
                    EZE_Inventory_Load(sender, e);
                    txtSearch.Text = "";
                    Validation.showdialog("Equipments were successfully deleted.");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        txtSearch.Visible = true;
                        mlSearch.Visible = true;
                        txtSearch.Select();
                    }
                }
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                if (Validation.showdialog("The selected equipment will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        EquipmentsTable equip = new EquipmentsTable()
                        {
                            Barcode = row.Cells[0].Value.ToString(),
                            Equipment = row.Cells[1].Value.ToString(),
                            Status = row.Cells[2].Value.ToString(),
                            Defective_Since = lbldatetime.ToString()
                        };
                        context.EquipmentsTables.Attach(equip);
                        context.EquipmentsTables.Remove(equip);
                        context.SaveChanges();
                    }
                    Cursor.Current = Cursors.Default;
                    equipmentsClassBindingSource.MoveFirst();
                    EZE_Inventory_Load(sender, e);
                    txtSearch.Text = "";
                    Validation.showdialog("Equipment was successfully deleted.");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        txtSearch.Visible = true;
                        mlSearch.Visible = true;
                        txtSearch.Select();
                    }
                }
            }
            else if (metroGrid.Rows.Count < 1)
            {
                Validation.showdialog("No data found. Delete isn't available.");
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    btnRefresh_Click(sender, e);
                }
                else
                {
                    txtSearch.Visible = true;
                    mlSearch.Visible = true;
                    txtSearch.Select();
                }
            }
            pg.Close();
        }
        #endregion

        #region CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (objState == EntityState.Changed && !string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Visible == false)
            {
                metroGrid.Visible = true;
                btnRefresh.Visible = true;
                btnSearch.Visible = true;
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnImport.Visible = true;
                btnExport.Visible = true;
                line1.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = false;
                txtSearch.Visible = true;
                mlSearch.Visible = true;
                txtSearch.Select();
            }
            else if (objState == EntityState.Added && !string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Rows.Count >= 1 ||
                objState == EntityState.Added && !string.IsNullOrWhiteSpace(txtSearch.Text) && metroGrid.Rows.Count == 1)
            {
                metroGrid.Visible = true;
                btnRefresh.Visible = true;
                btnSearch.Visible = true;
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnImport.Visible = true;
                btnExport.Visible = true;
                line1.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = false;
                txtSearch.Visible = true;
                mlSearch.Visible = true;
                txtSearch.Select();
                equipmentsClassBindingSource.MoveFirst();
                txtSearch_TextChanged(sender, e);
            }
            else
            {
                metroGrid.Visible = true;
                btnRefresh.Visible = true;
                btnSearch.Visible = true;
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnImport.Visible = true;
                btnExport.Visible = true;
                line1.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = false;
                txtSearch.Text = "";
                txtDescription.Text = "";
                txtSerialNumber.Text = "";
                txtSerialNumberDummy.Text = "";
                EZE_Inventory_Load(sender, e);
                equipmentsClassBindingSource.MoveFirst();
            }
        }
        void Clear()
        {
            txtDescription.Text = "";
            txtSerialNumber.Text = "";
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
        }
        #endregion

        #region SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                EquipmentsClass obj = equipmentsClassBindingSource.Current as EquipmentsClass;
                if (obj != null)
                {
                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Description or name of equipment is required.");
                        pg.Close();
                        txtDescription.Text = "";
                        txtDescription.Select();
                    }
                    else if (string.IsNullOrEmpty(txtSerialNumber.Text))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Barcode or serial number is required.");
                        pg.Close();
                        txtSerialNumber.Select();
                        txtSerialNumber.Select(txtSerialNumber.Text.Length, 0); //Set focus at the end of textbox
                    }
                    else if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Status of equipment is required.\nGOOD or DEFECTIVE?");
                        pg.Close();
                    }
                    else
                    {
                        obj.Equipment = Regex.Replace(txtDescription.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                        using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (myConn.State == ConnectionState.Closed)
                            { myConn.Open(); }
                            SqlCommand SelectCommand = new SqlCommand(" Select * from EquipmentsTable where Barcode='" + txtSerialNumber.Text + "'", myConn);
                            SqlDataReader dr;
                            dr = SelectCommand.ExecuteReader();
                            string barcode = string.Empty;
                            while (dr.Read())
                            {
                                barcode = dr["Barcode"].ToString();
                            }
                            if (txtSerialNumber.Text == barcode)
                            {
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("This serial number has already been used by another equipment.");
                                txtSerialNumber.Select();
                                txtSerialNumber.Select(txtSerialNumber.Text.Length, 0); //Set focus at the end of textbox
                                pg.Close();
                            }
                            else
                            {
                                if (metroRadioButton1.Checked == true)
                                { status = "GOOD"; datetime = ""; }
                                else if (metroRadioButton2.Checked == true)
                                { status = "DEFECTIVE"; datetime = lbldatetime.Text; }
                                DynamicParameters p = new DynamicParameters();
                                p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                                p.AddDynamicParams(new
                                {
                                    Equipment = obj.Equipment,
                                    Barcode = obj.Barcode,
                                    Status = status,
                                    Defective_Since = datetime
                                });
                                db.Execute("EquipmentsTableInsert", p, commandType: CommandType.StoredProcedure);
                                obj.ID = p.Get<int>("@ID");
                                Plexiglass pg = new Plexiglass(this);
                                Validation.showdialog("Equipment was successfully saved.");
                                pg.Close();
                                Clear();
                                EZE_Inventory_Load(sender, e);
                                equipmentsClassBindingSource.MoveFirst();

                                metroGrid.Visible = true;
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnDelete.Visible = true;
                                btnRefresh.Visible = true;
                                btnSearch.Visible = true;
                                btnImport.Visible = true;
                                btnExport.Visible = true;
                                line1.Visible = true;
                                txtSearch.Text = "";
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region UPDATE BUTTON
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                EquipmentsClass obj = equipmentsClassBindingSource.Current as EquipmentsClass;
                if (obj != null)
                {
                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Description or name of equipment is required.");
                        pg.Close();
                        txtDescription.Text = "";
                        txtDescription.Select();
                    }
                    else if (string.IsNullOrEmpty(txtSerialNumber.Text))
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Barcode or serial number is required.");
                        pg.Close();
                        txtSerialNumber.Select();
                        txtSerialNumber.Select(txtSerialNumber.Text.Length, 0); //Set focus at the end of textbox
                    }
                    else if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
                    {
                        Plexiglass pg = new Plexiglass(this);
                        Validation.showdialog("Status of equipment is required.\nGOOD or DEFECTIVE?");
                        pg.Close();
                    }
                    else
                    {
                        try
                        {
                            obj.Equipment = Regex.Replace(txtDescription.Text, "\\s+", " ").Trim(); //Remove whitespaces infront and back of textbox
                            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                            {
                                if (myConn.State == ConnectionState.Closed)
                                { myConn.Open(); }
                                SqlCommand SelectCommand = new SqlCommand(" Select * from EquipmentsTable where Barcode = '" + txtSerialNumber.Text + "'", myConn);
                                SqlDataReader dr;
                                dr = SelectCommand.ExecuteReader();
                                string bcode = string.Empty;
                                while (dr.Read())
                                {
                                    bcode = dr["Barcode"].ToString();
                                }
                                if (txtSerialNumber.Text == bcode && txtSerialNumberDummy.Text != txtSerialNumber.Text)
                                {
                                    Plexiglass pg = new Plexiglass(this);
                                    Validation.showdialog("This serial number has already been used by another equipment.");
                                    txtSerialNumber.Select();
                                    txtSerialNumber.Select(txtSerialNumber.Text.Length, 0); //Set focus at the end of textbox
                                    pg.Close();
                                }
                                else if (txtSerialNumber.Text != bcode || txtSerialNumberDummy.Text == txtSerialNumber.Text)
                                {
                                    if (metroRadioButton1.Checked == true)
                                    { status = "GOOD"; datetime = ""; }
                                    else if (metroRadioButton2.Checked == true)
                                    { status = "DEFECTIVE"; datetime = lbldatetime.Text; }
                                    db.Execute("EquipmentsTableUpdate", new
                                    {
                                        ID = obj.ID,
                                        Equipment = obj.Equipment,
                                        Barcode = obj.Barcode,
                                        Status = status,
                                        Defective_Since = datetime
                                    }, commandType: CommandType.StoredProcedure);
                                    Plexiglass pg = new Plexiglass(this);
                                    Validation.showdialog("Equipment was successfully updated.");
                                    pg.Close();

                                    btnUpdate.Visible = false;
                                    btnAdd.Visible = true;
                                    btnEdit.Visible = true;
                                    btnDelete.Visible = true;
                                    txtSerialNumberDummy.Text = "";
                                    line1.Visible = true;
                                    btnImport.Visible = true;
                                    btnExport.Visible = true;
                                    Clear();
                                    EZE_Inventory_Load(sender, e);
                                    equipmentsClassBindingSource.MoveFirst();
                                    txtSearch.Text = "";
                                    metroGrid.Visible = true;
                                    btnRefresh.Visible = true;
                                    btnSearch.Visible = true;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            Validation.showdialog("This serial number has already been used by another equipment.");
                            txtSerialNumber.Select();
                            txtSerialNumber.Select(txtSerialNumber.Text.Length, 0); //Set focus at the end of textbox
                            pg.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region IMPORT BUTTON
        private void btnImport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (txtSearch.Visible == true && !string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Visible == false && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "";
                txtSearch.Visible = false;
                mlSearch.Visible = false;
            }
            else if (txtSearch.Visible == true && string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Visible == false && string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Visible = false;
                mlSearch.Visible = false;
            }
            Plexiglass pg = new Plexiglass(this);
            EZE_ImportExcelFile ief = new EZE_ImportExcelFile();
            ief.ShowDialog();
            pg.Close();
        }
        #endregion

        #region EXPORT BUTTON
        private void btnExportContent()
        {
            Cursor.Current = Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbooks wb = xcelApp.Workbooks;
            try
            {
                wb.Add(Type.Missing);
                for (int i = 1; i < metroGrid.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = metroGrid.Columns[i - 1].HeaderText;
                    Range xcelRange = (Range)xcelApp.Cells[i];
                    xcelRange.Font.Bold = -1;
                    xcelRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }
                for (int i = 0; i < metroGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < metroGrid.Columns.Count; j++)
                    {
                        if (metroGrid.Rows[i].Cells[j].Value == null)
                        {
                            metroGrid.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and leave it as blank 
                            Range xlRange1 = (Range)xcelApp.Cells[i + 2, j + 1];
                        }
                        Range xcelRange = (Range)xcelApp.Cells[i + 2, j + 1];
                        xcelRange.NumberFormat = "@";
                        xcelApp.Cells[i + 2, j + 1] = metroGrid.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(wb);
                Marshal.FinalReleaseComObject(xcelApp);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            txtSearch.Visible = false;
            mlSearch.Visible = false;
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count == 1)
            {
                if (Validation.showdialog("All the data in this table will be exported to an excel file. Continue?") == DialogResult.Yes)
                {
                    btnExportContent();
                }
                Cursor.Current = Cursors.Default;
            }
            else if (metroGrid.Rows.Count > 1)
            {
                if (Validation.showdialog("All the data in this table will be exported to an excel file. Continue?") == DialogResult.Yes)
                {
                    btnExportContent();
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                Validation.showdialog("No data found. Export isn't available.");
            }
            pg.Close();
        }
        #endregion

        #region SEARCH EQUIPMENT
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SearchText", txtSearch.Text.Trim());
                    List<EquipmentsClass> list = db.Query<EquipmentsClass>("EquipmentsTableViewAllOrSearch", param, commandType: CommandType.StoredProcedure).ToList();
                    equipmentsClassBindingSource.DataSource = list;
                    EquipmentsClass obj = equipmentsClassBindingSource.Current as EquipmentsClass;
                }
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    //Binding of filtered data to textboxes
                    foreach (DataGridViewRow row in metroGrid.SelectedRows)
                    {
                        EquipmentsTable equip = new EquipmentsTable()
                        {
                            Barcode = row.Cells[0].Value.ToString(),
                            Equipment = row.Cells[1].Value.ToString(),
                            Status = row.Cells[2].Value.ToString(),
                            Defective_Since = lbldatetime.ToString()
                        };
                        txtDescription.Text = row.Cells[1].Value.ToString();
                        txtSerialNumber.Text = row.Cells[0].Value.ToString();
                        if (row.Cells[2].Value.ToString() == "GOOD")
                        {
                            metroRadioButton1.Checked = true;
                        }
                        else if (row.Cells[2].Value.ToString() == "DEFECTIVE")
                        {
                            metroRadioButton2.Checked = true;
                        }
                    }
                }
                else
                {
                    equipmentsClassBindingSource.MoveFirst();
                }
            }
            catch (Exception ex)
            {
                Plexiglass pg = new Plexiglass(_instance);
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Visible == false)
            {
                mlSearch.Visible = true;
                txtSearch.Visible = true;
                txtSearch.Select();
            }
            else
            {
                mlSearch.Visible = false;
                txtSearch.Visible = false;
                btnDummy.Select();
            }
        }
        #endregion

        #region EXTRAS
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
        }
        private void txtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
            if (e.KeyChar == (char)Keys.Space)
            { e.Handled = true; }
        }
        private void txtSerialNumber_Click(object sender, EventArgs e)
        {
            txtSerialNumber.SelectAll();
            txtSerialNumber.Select();
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Select();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            EZE_Inventory_Load(sender, e);
            equipmentsClassBindingSource.MoveFirst();
            txtSearch.Text = "";
            txtSearch.Visible = false;
            mlSearch.Visible = false;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lblONOE.Visible = false;
        }
        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearch.Visible = false;
            mlSearch.Visible = false;
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            panelListofEquipments.Visible = true;
        }
        private void TextBoxOnClick(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Select();
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            lblONOE.Visible = true;
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand cmd;
                string sql = "select count(ID) from EquipmentsTable";
                cmd = new SqlCommand(sql, myConn);
                int rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows_count.ToString() == "0")
                { _instance.lblONOE.Text = "No record of any equipment."; }
                else
                { _instance.lblONOE.Text = "Total number of equipments : " + rows_count.ToString(); }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion
    }
}
