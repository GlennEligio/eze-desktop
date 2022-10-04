using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Z.Dapper.Plus;
using ExcelDataReader;
using System.Text;
using EZE.Properties;

namespace EZE
{
    public partial class EZE_ImportExcelFile : Form
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
        DataTableCollection tbcollect;
        DataTable dt;
        public EZE_ImportExcelFile()
        {
            InitializeComponent();
            Size = new Size(988, 540);
            cmbDB.DropDownStyle = ComboBoxStyle.DropDownList;
            metroGrid.RowHeadersVisible = true; metroGrid1.RowHeadersVisible = true; metroGrid2.RowHeadersVisible = true;
            metroGrid3.RowHeadersVisible = true; metroGrid4.RowHeadersVisible = true;
        }

        #region Button Choose File
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (cmbSheet.Text != "")
            {
                btnCheckforDuplicates.Visible = true;
                btnCheckforDuplicates.Enabled = false;
                btnDeleteDuplicates.Visible = false;
                btnSavetoDB.Visible = false;
                cmbSheet.Text = "";
            }
            using (OpenFileDialog ofdialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", ValidateNames = true })
            {
                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofdialog.FileName;
                    using (var stream = File.Open(ofdialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tbcollect = result.Tables;
                            cmbSheet.Items.Clear();
                            foreach (DataTable table in tbcollect)
                            {
                                cmbSheet.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }                  
                }                
            }
        }
        private void btnChooseFile1_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (cmbSheet1.Text != "")
            {
                btnCheckforDuplicates1.Visible = true;
                btnCheckforDuplicates1.Enabled = false;
                btnDeleteDuplicates1.Visible = false;
                btnSavetoDB1.Visible = false;
                cmbSheet1.Text = "";
            }
            using (OpenFileDialog ofdialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", ValidateNames = true })
            {
                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath1.Text = ofdialog.FileName;
                    using (var stream = File.Open(ofdialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tbcollect = result.Tables;
                            cmbSheet1.Items.Clear();
                            foreach (DataTable table in tbcollect)
                            {
                                cmbSheet1.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                }
            }
        }
        private void btnChooseFile2_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (cmbSheet2.Text != "")
            {
                btnCheckforDuplicates2.Visible = true;
                btnCheckforDuplicates2.Enabled = false;
                btnDeleteDuplicates2.Visible = false;
                btnSavetoDB2.Visible = false;
                cmbSheet2.Text = "";
            }
            using (OpenFileDialog ofdialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", ValidateNames = true })
            {
                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath2.Text = ofdialog.FileName;
                    using (var stream = File.Open(ofdialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tbcollect = result.Tables;
                            cmbSheet2.Items.Clear();
                            foreach (DataTable table in tbcollect)
                            {
                                cmbSheet2.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                }
            }
        }
        private void btnChooseFile3_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (cmbSheet3.Text != "")
            {
                btnCheckforDuplicates3.Visible = true;
                btnCheckforDuplicates3.Enabled = false;
                btnDeleteDuplicates3.Visible = false;
                btnSavetoDB3.Visible = false;
                cmbSheet3.Text = "";
            }
            using (OpenFileDialog ofdialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", ValidateNames = true })
            {
                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath3.Text = ofdialog.FileName;
                    using (var stream = File.Open(ofdialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tbcollect = result.Tables;
                            cmbSheet3.Items.Clear();
                            foreach (DataTable table in tbcollect)
                            {
                                cmbSheet3.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                }
            }
        }
        private void btnChooseFile4_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            if (cmbSheet4.Text != "")
            {
                btnCheckforDuplicates4.Visible = true;
                btnCheckforDuplicates4.Enabled = false;
                btnDeleteDuplicates4.Visible = false;
                btnSavetoDB4.Visible = false;
                cmbSheet4.Text = "";
            }
            using (OpenFileDialog ofdialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", ValidateNames = true })
            {
                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath4.Text = ofdialog.FileName;
                    using (var stream = File.Open(ofdialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tbcollect = result.Tables;
                            cmbSheet4.Items.Clear();
                            foreach (DataTable table in tbcollect)
                            {
                                cmbSheet4.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Button Check for Duplicates
        private void HighlightDuplicate(DataGridView grv)
        {
            //Use the currentrow to compare against the other rows
            for (int currentRow = 0; currentRow < grv.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = grv.Rows[currentRow];
                //Specify otherrow as currentRow + 1
                for (int otherRow = currentRow + 1; otherRow < grv.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = grv.Rows[otherRow];
                    bool duplicateRow = true;
                    //Compare cell student number between the two rows
                    if (!rowToCompare.Cells[0].Value.Equals(row.Cells[0].Value))
                    {
                        duplicateRow = false;
                    }
                    //Highlight both the currentrow and otherrow if Student Number matches 
                    if (duplicateRow)
                    {
                        rowToCompare.DefaultCellStyle.BackColor = Color.DarkOrange;
                        rowToCompare.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.BackColor = Color.DarkOrange;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        Plexiglass pg = new Plexiglass(this);
                        MessageBox.Show("Duplicate username found. Please fix this issue to import the excel file.");
                        btnSavetoDB.Enabled = false;
                        pg.Close();
                    }
                }
            }
        }        
        private void btnCheckforDuplicates_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            HighlightDuplicate(metroGrid);
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from StudentsTable", myConn);
                SqlDataReader dr;
                List<string> snumlist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int white = 0; int orange = 0; int blue = 0;
                string studentnumber = string.Empty;
                while (dr.Read())
                {
                    studentnumber = dr["Student_Number"].ToString();
                    snumlist.Add(studentnumber);
                }
                foreach (DataGridViewRow row in metroGrid.Rows)
                {
                    //Cell 3 = Year and Section Column
                    if (Settings.Default.b12.Equals(false) && row.Cells[3].Value.ToString() == "1-2" || Settings.Default.b13.Equals(false) && row.Cells[3].Value.ToString() == "1-3" ||
                        Settings.Default.b14.Equals(false) && row.Cells[3].Value.ToString() == "1-4" || Settings.Default.b15.Equals(false) && row.Cells[3].Value.ToString() == "1-5" ||
                        Settings.Default.b11p.Equals(false) && row.Cells[3].Value.ToString() == "1-1P")
                    {
                        MessageBox.Show("Please add the proper section in the students' database to use the import function without any errors. e.g. If you want to import a student with year and section of 1-5, the section 5 must be visible in the students' database.", "ERROR!!!");
                        return;
                    }
                    else if (Settings.Default.b21.Equals(false) && row.Cells[3].Value.ToString() == "2-1" || Settings.Default.b23.Equals(false) && row.Cells[3].Value.ToString() == "2-3" ||
                       Settings.Default.b24.Equals(false) && row.Cells[3].Value.ToString() == "2-4" || Settings.Default.b25.Equals(false) && row.Cells[3].Value.ToString() == "2-5" ||
                       Settings.Default.b21p.Equals(false) && row.Cells[3].Value.ToString() == "2-1P")
                    {
                        MessageBox.Show("Please add the proper section in the students' database to use the import function without any errors. e.g. If you want to import a student with year and section of 1-5, the section 5 must be visible in the students' database.", "ERROR!!!");
                        return;
                    }
                    else if (Settings.Default.b32.Equals(false) && row.Cells[3].Value.ToString() == "3-2" || Settings.Default.b33.Equals(false) && row.Cells[3].Value.ToString() == "3-3" ||
                       Settings.Default.b34.Equals(false) && row.Cells[3].Value.ToString() == "3-4" || Settings.Default.b35.Equals(false) && row.Cells[3].Value.ToString() == "3-5" ||
                       Settings.Default.b31p.Equals(false) && row.Cells[3].Value.ToString() == "3-1P")
                    {
                        MessageBox.Show("Please add the proper section in the students' database to use the import function without any errors. e.g. If you want to import a student with year and section of 1-5, the section 5 must be visible in the students' database.", "ERROR!!!");
                        return;
                    }
                    else if (Settings.Default.b42.Equals(false) && row.Cells[3].Value.ToString() == "4-2" || Settings.Default.b43.Equals(false) && row.Cells[3].Value.ToString() == "4-3" ||
                       Settings.Default.b44.Equals(false) && row.Cells[3].Value.ToString() == "4-4" || Settings.Default.b45.Equals(false) && row.Cells[3].Value.ToString() == "4-5" ||
                       Settings.Default.b41p.Equals(false) && row.Cells[3].Value.ToString() == "4-1P")
                    {
                        MessageBox.Show("Please add the proper section in the students' database to use the import function without any errors. e.g. If you want to import a student with year and section of 1-5, the section 5 must be visible in the students' database.", "ERROR!!!");
                        return;
                    }
                    else if (Settings.Default.b52.Equals(false) && row.Cells[3].Value.ToString() == "5-2" || Settings.Default.b53.Equals(false) && row.Cells[3].Value.ToString() == "5-3" ||
                       Settings.Default.b54.Equals(false) && row.Cells[3].Value.ToString() == "5-4" || Settings.Default.b55.Equals(false) && row.Cells[3].Value.ToString() == "5-5" ||
                       Settings.Default.b51p.Equals(false) && row.Cells[3].Value.ToString() == "5-1P")
                    {
                        MessageBox.Show("Please add the proper section in the students' database to use the import function without any errors. e.g. If you want to import a student with year and section of 1-5, the section 5 must be visible in the students' database.", "ERROR!!!");
                        return;
                    }
                    else
                    {
                        row.Selected = false;
                        if (row.DefaultCellStyle.BackColor == Color.White)
                        { white++; }
                        if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                        { orange++; }
                        if (row.DefaultCellStyle.BackColor == Color.FromArgb(0, 173, 239))
                        { blue++; }
                        if (snumlist.Contains(row.Cells[0].Value.ToString())) //if snum is present sa db and sa metrogrid
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(245, 157, 15);
                            row.Selected = true;
                            btnDeleteDuplicates.BringToFront();
                            btnDeleteDuplicates.Visible = true;
                            btnCheckforDuplicates.Visible = false;
                        }
                        else if (!snumlist.Contains(row.Cells[0].Value.ToString()) && blue == 0 && orange == 0) //all data, no duplicate sa grid and db
                        {
                            btnSavetoDB.Visible = true;
                            btnCheckforDuplicates.Visible = false;
                        }
                    }
                }
            }
        }
        private void btnCheckforDuplicates1_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable", myConn);
                SqlDataReader dr;
                List<string> acclist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int white = 0; int orange = 0; int blue = 0;
                string username = string.Empty;
                while (dr.Read())
                {
                    username = dr["Username"].ToString();
                    acclist.Add(username);
                }
                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    row.Selected = false;
                    if (row.DefaultCellStyle.BackColor == Color.White)
                    { white++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    { orange++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(0, 173, 239))
                    { blue++; }
                    if (!acclist.Contains(row.Cells[1].Value.ToString()) && blue == 0 && orange == 0) //all data, no duplicate sa grid and db
                    {
                        btnSavetoDB1.Visible = true;
                        btnCheckforDuplicates1.Visible = false;
                    }
                    else if (acclist.Contains(row.Cells[1].Value.ToString())) //if username is present sa db and sa metrogrid
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 157, 15);
                        row.Selected = true;
                        btnDeleteDuplicates1.BringToFront();
                        btnDeleteDuplicates1.Visible = true;
                        btnCheckforDuplicates1.Visible = false;
                    }
                }
            }
        }
        private void btnCheckforDuplicates2_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable", myConn);
                SqlDataReader dr;
                List<string> elist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int white = 0; int orange = 0; int blue = 0;
                string equipment = string.Empty;
                while (dr.Read())
                {
                    equipment = dr["Barcode"].ToString();
                    elist.Add(equipment);
                }
                foreach (DataGridViewRow row in metroGrid2.Rows)
                {
                    row.Selected = false;
                    if (row.DefaultCellStyle.BackColor == Color.White)
                    { white++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    { orange++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(0, 173, 239))
                    { blue++; }
                    if (!elist.Contains(row.Cells[0].Value.ToString()) && blue == 0 && orange == 0) //all data, no duplicate sa grid and db
                    {
                        btnSavetoDB2.Visible = true;
                        btnCheckforDuplicates2.Visible = false;
                    }
                    else if (elist.Contains(row.Cells[0].Value.ToString())) //if snum is present sa db and sa metrogrid
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 157, 15);
                        row.Selected = true;
                        btnDeleteDuplicates2.BringToFront();
                        btnDeleteDuplicates2.Visible = true;
                        btnCheckforDuplicates2.Visible = false;
                    }
                }
            }
        }
        private void btnCheckforDuplicates3_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from ProfessorsTable", myConn);
                SqlDataReader dr;
                List<string> elist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int white = 0; int orange = 0; int blue = 0;
                string prof = string.Empty;
                while (dr.Read())
                {
                    prof = dr["Contact_Number"].ToString();
                    elist.Add(prof);
                }
                foreach (DataGridViewRow row in metroGrid3.Rows)
                {
                    row.Selected = false;
                    if (row.DefaultCellStyle.BackColor == Color.White)
                    { white++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    { orange++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(0, 173, 239))
                    { blue++; }
                    if (!elist.Contains(row.Cells[1].Value.ToString()) && blue == 0 && orange == 0) //all data, no duplicate sa grid and db
                    {
                        btnSavetoDB3.Visible = true;
                        btnCheckforDuplicates3.Visible = false;
                    }
                    else if (elist.Contains(row.Cells[1].Value.ToString())) //if snum is present sa db and sa metrogrid
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 157, 15);
                        row.Selected = true;
                        btnDeleteDuplicates3.BringToFront();
                        btnDeleteDuplicates3.Visible = true;
                        btnCheckforDuplicates3.Visible = false;
                    }
                }
            }
        }
        private void btnCheckforDuplicates4_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from SchedulesTable", myConn);
                SqlDataReader dr;
                List<string> scodelist = new List<string>();
                List<string> yaslist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int white = 0; int orange = 0; int blue = 0;
                string scode = string.Empty;
                string yas = string.Empty;
                while (dr.Read())
                {
                    scode = dr["Subject_Code"].ToString();
                    yas = dr["Year_and_Section"].ToString();
                    scodelist.Add(scode);
                    yaslist.Add(yas);
                }
                foreach (DataGridViewRow row in metroGrid4.Rows)
                {
                    row.Selected = false;
                    if (row.DefaultCellStyle.BackColor == Color.White)
                    { white++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    { orange++; }
                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(0, 173, 239))
                    { blue++; }
                    if (!scodelist.Contains(row.Cells[0].Value.ToString()) && !yaslist.Contains(row.Cells[7].Value.ToString()) && blue == 0 && orange == 0) //all data, no duplicate sa grid and db
                    {
                        btnSavetoDB4.Visible = true;
                        btnCheckforDuplicates4.Visible = false;
                    }
                    else if (scodelist.Contains(row.Cells[0].Value.ToString()) && yaslist.Contains(row.Cells[7].Value.ToString())) //if snum is present sa db and sa metrogrid
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 157, 15);
                        row.Selected = true;
                        btnDeleteDuplicates4.BringToFront();
                        btnDeleteDuplicates4.Visible = true;
                        btnCheckforDuplicates4.Visible = false;
                    }
                }
            }
        }
        #endregion

        #region Button Delete Duplicates
        private void btnDeleteDuplicates_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from StudentsTable", myConn);
                SqlDataReader dr;
                List<string> snumlist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                string studentnumber = string.Empty;
                while (dr.Read())
                {
                    studentnumber = dr["Student_Number"].ToString();
                    snumlist.Add(studentnumber);
                }
                foreach (DataGridViewRow row in metroGrid.SelectedRows)
                {
                    if (!row.IsNewRow && snumlist.Contains(row.Cells[0].Value.ToString()) && row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    {
                        metroGrid.Rows.Remove(row);
                    }
                    CountRowColor();
                }
                if (metroGrid.Rows.Count < 1)
                {                  
                    txtFilePath.Text = "";
                    btnDeleteDuplicates.Visible = false;
                    cmbSheet.Items[cmbSheet.SelectedIndex] = string.Empty;
                    btnCheckforDuplicates.Visible = true;
                    btnCheckforDuplicates.Enabled = false;
                    messagebox.showdialog("No data found. Please choose another file.");
                }
            }
            pg.Close();
        }
        private void btnDeleteDuplicates1_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from AccountsTable", myConn);
                SqlDataReader dr;
                List<string> acclist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string username = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    username = dr["Username"].ToString();
                    acclist.Add(username);
                }
                foreach (DataGridViewRow row in metroGrid1.SelectedRows)
                {
                    if (!row.IsNewRow && acclist.Contains(row.Cells[1].Value.ToString()) && row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    {
                        metroGrid1.Rows.Remove(row);
                    }
                    CountRowColor1();
                }
                if (metroGrid1.Rows.Count < 1)
                {
                    txtFilePath1.Text = "";
                    btnDeleteDuplicates1.Visible = false;
                    cmbSheet1.Items[cmbSheet1.SelectedIndex] = string.Empty;
                    btnCheckforDuplicates1.Visible = true;
                    btnCheckforDuplicates1.Enabled = false;
                    messagebox.showdialog("No data found. Please choose another file.");
                }
            }
            pg.Close();
        }
        private void btnDeleteDuplicates2_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from EquipmentsTable", myConn);
                SqlDataReader dr;
                List<string> elist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string equipment = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    equipment = dr["Barcode"].ToString();
                    elist.Add(equipment);
                }
                foreach (DataGridViewRow row in metroGrid2.SelectedRows)
                {
                    if (!row.IsNewRow && elist.Contains(row.Cells[0].Value.ToString()) && row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    {
                        metroGrid2.Rows.Remove(row);
                    }
                    CountRowColor2();
                }
                if (metroGrid2.Rows.Count < 1)
                {
                    txtFilePath2.Text = "";
                    btnDeleteDuplicates2.Visible = false;
                    cmbSheet2.Items[cmbSheet2.SelectedIndex] = string.Empty;
                    btnCheckforDuplicates2.Visible = true;
                    btnCheckforDuplicates2.Enabled = false;
                    messagebox.showdialog("No data found. Please choose another file.");
                }
            }
            pg.Close();
        }
        private void btnDeleteDuplicates3_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from ProfessorsTable", myConn);
                SqlDataReader dr;
                List<string> elist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string prof = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    prof = dr["Contact_Number"].ToString();
                    elist.Add(prof);
                }
                foreach (DataGridViewRow row in metroGrid3.SelectedRows)
                {
                    if (!row.IsNewRow && elist.Contains(row.Cells[1].Value.ToString()) && row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    {
                        metroGrid3.Rows.Remove(row);
                    }
                    CountRowColor3();
                }
                if (metroGrid3.Rows.Count < 1)
                {
                    txtFilePath3.Text = "";
                    btnDeleteDuplicates3.Visible = false;
                    cmbSheet3.Items[cmbSheet3.SelectedIndex] = string.Empty;
                    btnCheckforDuplicates3.Visible = true;
                    btnCheckforDuplicates3.Enabled = false;
                    messagebox.showdialog("No data found. Please choose another file.");
                }
            }
            pg.Close();
        }
        private void btnDeleteDuplicates4_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            btnDummy.Select();
            using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (myConn.State == ConnectionState.Closed)
                { myConn.Open(); }
                SqlCommand SelectCommand = new SqlCommand("Select * from SchedulesTable", myConn);
                SqlDataReader dr;
                List<string> scodelist = new List<string>();
                List<string> yaslist = new List<string>();
                dr = SelectCommand.ExecuteReader();
                int count = 0;
                string scode = string.Empty;
                string yas = string.Empty;
                while (dr.Read())
                {
                    count = count + 1;
                    scode = dr["Subject_Code"].ToString();
                    yas = dr["Year_and_Section"].ToString();
                    scodelist.Add(scode);
                    yaslist.Add(yas);
                }
                foreach (DataGridViewRow row in metroGrid4.SelectedRows)
                {
                    if (!row.IsNewRow && scodelist.Contains(row.Cells[0].Value.ToString()) && yaslist.Contains(row.Cells[7].Value.ToString()) && row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                    {
                        metroGrid4.Rows.Remove(row);
                    }
                    CountRowColor4();
                }
                if (metroGrid4.Rows.Count < 1)
                {
                    txtFilePath4.Text = "";
                    btnDeleteDuplicates4.Visible = false;
                    cmbSheet4.Items[cmbSheet4.SelectedIndex] = string.Empty;
                    btnCheckforDuplicates4.Visible = true;
                    btnCheckforDuplicates4.Enabled = false;
                    messagebox.showdialog("No data found. Please choose another file.");
                }
            }
            pg.Close();
        }
        #endregion

        #region Button Save to Database        
        private void btnSavetoDB_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count < 1)
            { messagebox.showdialog("No data available."); }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                DapperPlusManager.Entity<StudentsClass>().Table("StudentsTable"); //"StudentsTable" name ng table sa db.
                List<StudentsClass> students = studentsClassBindingSource.DataSource as List<StudentsClass>;
                if (students != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        db.BulkInsert(students);
                    }
                    txtFilePath.Text = "";
                    metroGrid.Rows.Clear();
                    metroGrid.Refresh();
                    cmbSheet.Items[cmbSheet.SelectedIndex] = string.Empty;
                    btnSavetoDB.Visible = false;
                    btnCheckforDuplicates.Visible = true;
                    btnCheckforDuplicates.Enabled = false;
                    messagebox.showdialog("Excel file imported successfully.");
                }
                Cursor.Current = Cursors.Default;
            }      
            pg.Close();            
        }
        private void btnSavetoDB1_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid1.Rows.Count < 1)
            { messagebox.showdialog("No data available."); }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                DapperPlusManager.Entity<AccountsListClass>().Table("AccountsTable"); //"AccountsTable" name ng table sa db.
                List<AccountsListClass> accounts = accountsListClassBindingSource.DataSource as List<AccountsListClass>;
                if (accounts != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        db.BulkInsert(accounts);
                    }
                    txtFilePath1.Text = "";
                    metroGrid1.Rows.Clear();
                    metroGrid1.Refresh();
                    cmbSheet1.Items[cmbSheet1.SelectedIndex] = string.Empty;
                    btnSavetoDB1.Visible = false;
                    btnCheckforDuplicates1.Visible = true;
                    btnCheckforDuplicates1.Enabled = false;
                    messagebox.showdialog("Excel file imported successfully.");
                }
                Cursor.Current = Cursors.Default;
            }
            pg.Close();
        }
        private void btnSavetoDB2_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid2.Rows.Count < 1)
            { messagebox.showdialog("No data available."); }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                DapperPlusManager.Entity<EquipmentsClass>().Table("EquipmentsTable"); //"EquipmentsTable" name ng table sa db.
                List<EquipmentsClass> equipments = equipmentsClassBindingSource.DataSource as List<EquipmentsClass>;
                if (equipments != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        db.BulkInsert(equipments);
                    }
                    txtFilePath2.Text = "";
                    metroGrid2.Rows.Clear();
                    metroGrid2.Refresh();
                    cmbSheet2.Items[cmbSheet2.SelectedIndex] = string.Empty;
                    btnSavetoDB2.Visible = false;
                    btnCheckforDuplicates2.Visible = true;
                    btnCheckforDuplicates2.Enabled = false;
                    messagebox.showdialog("Excel file imported successfully.");
                }
                Cursor.Current = Cursors.Default;
            }
            pg.Close();
        }
        private void btnSavetoDB3_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid3.Rows.Count < 1)
            { messagebox.showdialog("No data available."); }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                DapperPlusManager.Entity<ProfessorsClass>().Table("ProfessorsTable"); //"ProfessorsTable" name ng table sa db.
                List<ProfessorsClass> professors = professorsClassBindingSource.DataSource as List<ProfessorsClass>;
                if (professors != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        db.BulkInsert(professors);
                    }
                    txtFilePath3.Text = "";
                    metroGrid3.Rows.Clear();
                    metroGrid3.Refresh();
                    cmbSheet3.Items[cmbSheet3.SelectedIndex] = string.Empty;
                    btnSavetoDB3.Visible = false;
                    btnCheckforDuplicates3.Visible = true;
                    btnCheckforDuplicates3.Enabled = false;
                    messagebox.showdialog("Excel file imported successfully.");
                }
                Cursor.Current = Cursors.Default;
            }
            pg.Close();
        }
        private void btnSavetoDB4_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid4.Rows.Count < 1)
            { messagebox.showdialog("No data available."); }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                DapperPlusManager.Entity<SchedulesClass>().Table("SchedulesTable"); //"SchedulesTable" name ng table sa db.
                List<SchedulesClass> schedules = schedulesClassBindingSource.DataSource as List<SchedulesClass>;
                if (schedules != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        db.BulkInsert(schedules);
                    }
                    txtFilePath4.Text = "";
                    metroGrid4.Rows.Clear();
                    metroGrid4.Refresh();
                    cmbSheet4.Items[cmbSheet4.SelectedIndex] = string.Empty;
                    btnSavetoDB4.Visible = false;
                    btnCheckforDuplicates4.Visible = true;
                    btnCheckforDuplicates4.Enabled = false;
                    messagebox.showdialog("Excel file imported successfully.");
                }
                Cursor.Current = Cursors.Default;
            }
            pg.Close();
        }
        #endregion

        #region MetroGrid DataBindingComplete
        private void metroGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGrid.ClearSelection();
        }
        private void metroGrid1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGrid1.ClearSelection();
        }
        private void metroGrid2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGrid2.ClearSelection();
        }
        private void metroGrid3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGrid3.ClearSelection();
        }
        private void metroGrid4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGrid4.ClearSelection();
        }
        #endregion

        #region ComboBox Sheet SelectedIndexChanged
        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = tbcollect[cmbSheet.SelectedItem.ToString()];
                if (dt != null)
                {
                    List<StudentsClass> sclass = new List<StudentsClass>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StudentsClass student = new StudentsClass();
                        student.Student_Number = dt.Rows[i]["Student Number"].ToString().Trim(); //column name sa excel file yung may ""
                        student.Full_Name = dt.Rows[i]["Full Name"].ToString().Trim();
                        student.Year_and_Section = dt.Rows[i]["Year and Section"].ToString().Trim();
                        student.Contact_Number = dt.Rows[i]["Contact Number"].ToString().Trim();
                        student.Birthday = dt.Rows[i]["Birthday"].ToString().Trim();
                        student.Address = dt.Rows[i]["Home Address"].ToString().Trim();
                        student.Email = dt.Rows[i]["Email Address"].ToString().Trim();
                        student.Guardian = dt.Rows[i]["Guardian's Name"].ToString().Trim();
                        student.Guardian_Number = dt.Rows[i]["Guardian's Number"].ToString().Trim();
                        student.Year_Level = dt.Rows[i]["Year Level"].ToString().Trim();
                        student.Image_Location = dt.Rows[i]["Image Location"].ToString().Trim();
                        sclass.Add(student);
                        //kahit maremove yung column sa datagridview, papasok parin yung data sa db after masave.
                    }
                    btnCheckforDuplicates.Enabled = true;
                    btnDeleteDuplicates.Visible = false;
                    studentsClassBindingSource.DataSource = sclass;
                } 
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Please choose the correct database for the excel file you want to import.");
                pg.Close();
            }
        }
        private void cmbSheet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = tbcollect[cmbSheet1.SelectedItem.ToString()];
                if (dt != null)
                {
                    List<AccountsListClass> aclass = new List<AccountsListClass>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AccountsListClass account = new AccountsListClass();
                        account.Full_Name = dt.Rows[i]["Full Name"].ToString().Trim(); //column name sa excel file yung may ""
                        account.Username = dt.Rows[i]["Username"].ToString().Trim();
                        account.Password = dt.Rows[i]["Password"].ToString().Trim();
                        account.User_Type = dt.Rows[i]["User Type"].ToString().Trim();
                        account.Date_Time_Registered = dt.Rows[i]["Date and Time Registered"].ToString().Trim();
                        account.Email = dt.Rows[i]["Email Address"].ToString().Trim();
                        account.Image_Location = dt.Rows[i]["Image Location"].ToString().Trim();
                        aclass.Add(account);
                        //kahit maremove yung column sa datagridview, papasok parin yung data sa db after masave.
                    }
                    btnCheckforDuplicates1.Enabled = true;
                    btnDeleteDuplicates1.Visible = false;
                    accountsListClassBindingSource.DataSource = aclass;
                }
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Please choose the correct database for the excel file you want to import.");
                pg.Close();
            }
        }
        private void cmbSheet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = tbcollect[cmbSheet2.SelectedItem.ToString()];
                if (dt != null)
                {
                    List<EquipmentsClass> eclass = new List<EquipmentsClass>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EquipmentsClass equipment = new EquipmentsClass();
                        equipment.Barcode = dt.Rows[i]["Serial Number"].ToString().Trim(); //column name sa excel file yung may ""
                        equipment.Equipment = dt.Rows[i]["Description"].ToString().Trim(); 
                        equipment.Status = dt.Rows[i]["Status"].ToString().Trim();
                        equipment.Defective_Since = dt.Rows[i]["Defective Since"].ToString().Trim();
                        eclass.Add(equipment);
                        //kahit maremove yung column sa datagridview, papasok parin yung data sa db after masave.
                    }
                    btnCheckforDuplicates2.Enabled = true;
                    btnDeleteDuplicates2.Visible = false;
                    equipmentsClassBindingSource.DataSource = eclass;
                }
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Please choose the correct database for the excel file you want to import.");
                pg.Close();
            }
        }
        private void cmbSheet3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = tbcollect[cmbSheet3.SelectedItem.ToString()];
                if (dt != null)
                {
                    List<ProfessorsClass> profclass = new List<ProfessorsClass>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProfessorsClass proff = new ProfessorsClass();
                        proff.Professor = dt.Rows[i]["Professor"].ToString().Trim(); //column name sa excel file yung may ""
                        proff.Contact_Number = dt.Rows[i]["Contact Number"].ToString().Trim();
                        profclass.Add(proff);
                        //kahit maremove yung column sa datagridview, papasok parin yung data sa db after masave.
                    }
                    btnCheckforDuplicates3.Enabled = true;
                    btnDeleteDuplicates3.Visible = false;
                    professorsClassBindingSource.DataSource = profclass;
                }
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Please choose the correct database for the excel file you want to import.");
                pg.Close();
            }
        }
        private void cmbSheet4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = tbcollect[cmbSheet4.SelectedItem.ToString()];
                if (dt != null)
                {
                    List<SchedulesClass> schedclass = new List<SchedulesClass>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SchedulesClass schedd = new SchedulesClass();
                        schedd.Subject_Code = dt.Rows[i]["Subject Code"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Subject_Name = dt.Rows[i]["Subject Name"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Day = dt.Rows[i]["Day"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Time = dt.Rows[i]["Time"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Room = dt.Rows[i]["Room"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Professor = dt.Rows[i]["Professor"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Year_Level = dt.Rows[i]["Year Level"].ToString().Trim(); //column name sa excel file yung may ""
                        schedd.Year_and_Section = dt.Rows[i]["Year and Section"].ToString().Trim(); //column name sa excel file yung may ""
                        schedclass.Add(schedd);
                        //kahit maremove yung column sa datagridview, papasok parin yung data sa db after masave.
                    }
                    btnCheckforDuplicates4.Enabled = true;
                    btnDeleteDuplicates4.Visible = false;
                    schedulesClassBindingSource.DataSource = schedclass;
                }
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("Please choose the correct database for the excel file you want to import.");
                pg.Close();
            }
        }
        #endregion

        #region ComboBox Database SelectedIndexChanged
        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDB.SelectedIndex == 0)
            {
                EZE_StudentsDatabase.getsettings1();
                EZE_StudentsDatabase.getsettings2();
                EZE_StudentsDatabase.getsettings3();
                EZE_StudentsDatabase.getsettings4();
                EZE_StudentsDatabase.getsettings5();

                pnlMain.Visible = false;
                pnlStudents.Visible = true;
                btnCheckforDuplicates.Enabled = false;
                btnHome.Visible = true;
                btnNormalBack.Visible = false;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
                btnBackforStudentsDatabase.Visible = true;
            }
            else if (cmbDB.SelectedIndex == 1)
            {
                pnlMain.Visible = false;
                pnlAccounts.Visible = true;
                btnCheckforDuplicates1.Enabled = false;
                btnHome.Visible = true;
                btnNormalBack.Visible = false;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
                btnBackforUserAccounts.Visible = true;
            }
            else if (cmbDB.SelectedIndex == 2)
            {
                pnlMain.Visible = false;
                pnlInventory.Visible = true;
                btnCheckforDuplicates2.Enabled = false;
                btnHome.Visible = true;
                btnNormalBack.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
                btnBackforEquipmentsDatabase.Visible = true;
            }
            else if (cmbDB.SelectedIndex == 3)
            {
                pnlMain.Visible = false;
                pnlFaculty.Visible = true;
                btnCheckforDuplicates3.Enabled = false;
                btnHome.Visible = true;
                btnNormalBack.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforSchedules.Visible = false;
                btnBackforProfessors.Visible = true;
            }
            else if (cmbDB.SelectedIndex == 4)
            {
                pnlMain.Visible = false;
                pnlSchedules.Visible = true;
                btnCheckforDuplicates4.Enabled = false;
                btnHome.Visible = true;
                btnNormalBack.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = true;
            }
        }
        #endregion

        #region Home Button
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (pnlStudents.Visible == true)
            {
                cmbDB.Text = "";
                cmbDB.SelectedIndex = -1;
                cmbSheet.Items.Clear();
                cmbSheet.Text = "";
                txtFilePath.Text = "";
                metroGrid.Rows.Clear();
                metroGrid.Refresh();
                btnSavetoDB.Visible = false;
                btnDeleteDuplicates.Visible = false;
                btnCheckforDuplicates.Visible = true;
                btnHome.Visible = false;
                pnlStudents.Visible = false;
                pnlMain.Visible = true;
                btnNormalBack.Visible = true;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
            }
            else if (pnlAccounts.Visible == true)
            {
                cmbDB.Text = "";
                cmbDB.SelectedIndex = -1;
                cmbSheet1.Items.Clear();
                cmbSheet1.Text = "";
                txtFilePath1.Text = "";
                metroGrid1.Rows.Clear();
                metroGrid1.Refresh();
                btnSavetoDB1.Visible = false;
                btnDeleteDuplicates1.Visible = false;
                btnCheckforDuplicates1.Visible = true;
                btnHome.Visible = false;
                pnlAccounts.Visible = false;
                pnlMain.Visible = true;
                btnNormalBack.Visible = true;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
            }
            else if (pnlInventory.Visible == true)
            {
                cmbDB.Text = "";
                cmbDB.SelectedIndex = -1;
                cmbSheet2.Items.Clear();
                cmbSheet2.Text = "";
                txtFilePath2.Text = "";
                metroGrid2.Rows.Clear();
                metroGrid2.Refresh();
                btnSavetoDB2.Visible = false;
                btnDeleteDuplicates2.Visible = false;
                btnCheckforDuplicates2.Visible = true;
                btnHome.Visible = false;
                pnlInventory.Visible = false;
                pnlMain.Visible = true;
                btnNormalBack.Visible = true;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
            }
            else if (pnlFaculty.Visible == true)
            {
                cmbDB.Text = "";
                cmbDB.SelectedIndex = -1;
                cmbSheet3.Items.Clear();
                cmbSheet3.Text = "";
                txtFilePath3.Text = "";
                metroGrid3.Rows.Clear();
                metroGrid3.Refresh();
                btnSavetoDB3.Visible = false;
                btnDeleteDuplicates3.Visible = false;
                btnCheckforDuplicates3.Visible = true;
                btnHome.Visible = false;
                pnlFaculty.Visible = false;
                pnlMain.Visible = true;
                btnNormalBack.Visible = true;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
            }
            else if (pnlSchedules.Visible == true)
            {
                cmbDB.Text = "";
                cmbDB.SelectedIndex = -1;
                cmbSheet4.Items.Clear();
                cmbSheet4.Text = "";
                txtFilePath4.Text = "";
                metroGrid4.Rows.Clear();
                metroGrid4.Refresh();
                btnSavetoDB4.Visible = false;
                btnDeleteDuplicates4.Visible = false;
                btnCheckforDuplicates4.Visible = true;
                btnHome.Visible = false;
                pnlSchedules.Visible = false;
                pnlMain.Visible = true;
                btnNormalBack.Visible = true;
                btnBackforEquipmentsDatabase.Visible = false;
                btnBackforStudentsDatabase.Visible = false;
                btnBackforUserAccounts.Visible = false;
                btnBackforProfessors.Visible = false;
                btnBackforSchedules.Visible = false;
            }
        }
        #endregion

        #region CountRowColor
        private void CountRowColor()
        {
            int orange = 0;
            foreach (DataGridViewRow row in metroGrid.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                {
                    orange++;
                }
            }
            if (orange == 0 && metroGrid.Rows.Count >= 1)
            {
                btnDeleteDuplicates.Visible = false;
                btnSavetoDB.BringToFront();
                btnSavetoDB.Visible = true;                
            }
        }
        private void CountRowColor1()
        {
            int orange = 0;
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                {
                    orange++;
                }
            }
            if (orange == 0 && metroGrid1.Rows.Count >= 1)
            {
                btnDeleteDuplicates1.Visible = false;
                btnSavetoDB1.BringToFront();
                btnSavetoDB1.Visible = true;
            }
        }
        private void CountRowColor2()
        {
            int orange = 0;
            foreach (DataGridViewRow row in metroGrid2.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                {
                    orange++;
                }
            }
            if (orange == 0 && metroGrid2.Rows.Count >= 1)
            {
                btnDeleteDuplicates2.Visible = false;
                btnSavetoDB2.BringToFront();
                btnSavetoDB2.Visible = true;
            }
        }
        private void CountRowColor3()
        {
            int orange = 0;
            foreach (DataGridViewRow row in metroGrid3.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                {
                    orange++;
                }
            }
            if (orange == 0 && metroGrid3.Rows.Count >= 1)
            {
                btnDeleteDuplicates3.Visible = false;
                btnSavetoDB3.BringToFront();
                btnSavetoDB3.Visible = true;
            }
        }
        private void CountRowColor4()
        {
            int orange = 0;
            foreach (DataGridViewRow row in metroGrid4.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 157, 15))
                {
                    orange++;
                }
            }
            if (orange == 0 && metroGrid4.Rows.Count >= 1)
            {
                btnDeleteDuplicates4.Visible = false;
                btnSavetoDB4.BringToFront();
                btnSavetoDB4.Visible = true;
            }
        }
        #endregion
        private void btnBackforUserAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                EZE_AccountsDatabase.LoadAccountsToMetrogrid();
                Close();
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Please choose the proper database for the file you want to import.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            } 
        }
        private void btnBackforEquipmentsDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                EZE_Inventory.RefreshEquipments();
                Close();
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Please choose the proper database for the file you want to import.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }
            
        }
        private void btnBackforStudentsDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                EZE_StudentsDatabase.mtcSelectedIndexChanged();
                Close();
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Please choose the proper database for the file you want to import.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }
        }
        private void btnNormalBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnBackforProfessors_Click(object sender, EventArgs e)
        {
            try
            {
                EZE_FacultyInformation.RefreshFaculty();
                Close();
            }
            catch (Exception)
            {
                Plexiglass pg = new Plexiglass(this);
                MessageBox.Show("Please choose the proper database for the file you want to import.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pg.Close();
            }  
        }
        private void btnBackforSchedules_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void EZE_ImportExcelFile_Load(object sender, EventArgs e)
        {
            btnNormalBack.Visible = true;
            btnBackforEquipmentsDatabase.Visible = false;
            btnBackforStudentsDatabase.Visible = false;
            btnBackforUserAccounts.Visible = false;
            btnBackforProfessors.Visible = false;
            btnBackforSchedules.Visible = false;
        }
    }
}

