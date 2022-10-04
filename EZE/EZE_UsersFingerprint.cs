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
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_UsersFingerprint : Form
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
        private EZEEntities1 context;
        public EZE_UsersFingerprint()
        {
            InitializeComponent();
            Size = new Size(600, 402);
            metroGrid.RowHeadersVisible = true;
        }
        private void UsersFingerprint_Load(object sender, EventArgs e)
        {
            context = new EZEEntities1();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                userFingerprintsClassBindingSource.DataSource = db.Query<UserFingerprintsClass>("Select * from FingerprintsTableUser", commandType: CommandType.Text);
                UserFingerprintsClass obj = userFingerprintsClassBindingSource.Current as UserFingerprintsClass;
            }          
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid.Rows.Count > 1 && metroGrid.SelectedRows.Count > 1)
            {
                if (Validation.showdialog("The selected fingerprint data will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (var item in metroGrid.Rows)
                    {
                        DataGridViewRow row = item as DataGridViewRow;
                        if (row.Selected)
                        {
                            string uname = row.Cells[1].Value.ToString(); //Cell 1 = username cell
                            var unamee = context.FingerprintsTableUsers.FirstOrDefault(a => a.Username.Equals(uname));
                            if (unamee != null)
                            {
                                context.FingerprintsTableUsers.Attach(unamee);
                                context.FingerprintsTableUsers.Remove(unamee);
                                context.SaveChanges();
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    userFingerprintsClassBindingSource.MoveFirst();
                    UsersFingerprint_Load(sender, e);
                    Validation.showdialog("Fingerprints were successfully deleted.");
                }
            }
            else if (metroGrid.Rows.Count >= 1 && metroGrid.SelectedRows.Count == 1)
            {
                if (Validation.showdialog("The selected fingerprint data will be removed. Once deleted, you can't undo this. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (var item in metroGrid.Rows)
                    {
                        DataGridViewRow row = item as DataGridViewRow;
                        if (row.Selected)
                        {
                            string uname = row.Cells[1].Value.ToString(); //Cell 1 = username cell
                            var unamee = context.FingerprintsTableUsers.FirstOrDefault(a => a.Username.Equals(uname));
                            if (unamee != null)
                            {
                                context.FingerprintsTableUsers.Attach(unamee);
                                context.FingerprintsTableUsers.Remove(unamee);
                                context.SaveChanges();
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    userFingerprintsClassBindingSource.MoveFirst();
                    UsersFingerprint_Load(sender, e);
                    Validation.showdialog("Fingerprint was successfully deleted.");
                }
            }
            else if (metroGrid.Rows.Count < 1)
            {
                Validation.showdialog("No data found. Delete isn't available.");
            }            
            pg.Close();
        }                              
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}