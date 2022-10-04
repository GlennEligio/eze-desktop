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
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_Report : Form
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
        public EZE_Report()
        {
            InitializeComponent();
            Size = new Size(988, 540);
          //  EnableDoubleBuffering();
        }
        private void EnableDoubleBuffering()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnDummy.Select();
            Cursor.Current = Cursors.WaitCursor;
            dtFrom.Visible = false;
            dtTo.Visible = false;
            using (EZEEntities7 db = new EZEEntities7())
            {
                GetReturnFinalBindingSource.DataSource = db.GetReturnFinal(dtFrom.Value, dtTo.Value).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("fromDate",dtFrom.Value.Date.ToShortDateString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("toDate",dtTo.Value.Date.ToShortDateString()),
                };
                reportViewer.LocalReport.SetParameters(rParams);
                reportViewer.RefreshReport();
            }
            Cursor.Current = Cursors.Default;
        }         
        private void EZE_Report_Load(object sender, EventArgs e)
        {
            btnDummy.Select();
        }
        private void btnFrom_Click(object sender, EventArgs e)
        {
            if (dtFrom.Visible == true)
            {
                dtFrom.Visible = false;
            }
            else
            {
                dtFrom.Visible = true;
            }
        }
        private void btnTo_Click(object sender, EventArgs e)
        {
            if (dtTo.Visible == true)
            {
                dtTo.Visible = false;
            }
            else
            {
                dtTo.Visible = true;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }       
        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelReportGenerator.Visible = true;
        }
    }
}
