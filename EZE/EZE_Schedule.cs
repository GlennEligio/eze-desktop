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
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using EZE.Properties;
using Transitions;
using EZE.ADO.NetModels;

namespace EZE
{
    public partial class EZE_Schedule : Form
    {
        private EZEEntities8 context;
        string yearlevel;
        public EZE_Schedule()
        {
            InitializeComponent();
            Size = new Size(988, 540);
            metroTabControl1.SelectedTab = firstyear;
            metroGrid1.Columns[6].Visible = false; metroGrid2.Columns[6].Visible = false;
            metroGrid3.Columns[6].Visible = false; metroGrid4.Columns[6].Visible = false;
            metroGrid5.Columns[6].Visible = false; metroGrid2.Columns[7].Visible = false;
            metroGrid1.Columns[7].Visible = false; metroGrid3.Columns[7].Visible = false;
            metroGrid4.Columns[7].Visible = false; metroGrid5.Columns[7].Visible = false;
        }

        #region Timer                    
        private void datetimeright_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            lbldatetimeright.Text = datetime.ToShortDateString() + " " + datetime.ToShortTimeString();
        }
        #endregion

        #region User Settings      
        public void getsettings1()
        {
            btn11.Visible = Settings.Default.b11;
            btn12.Visible = Settings.Default.b12;
            btn13.Visible = Settings.Default.b13;
            btn14.Visible = Settings.Default.b14;
            btn15.Visible = Settings.Default.b15;
            btn11p.Visible = Settings.Default.b11p;
        }
        public void getsettings2()
        {
            btn21.Visible = Settings.Default.b21;
            btn22.Visible = Settings.Default.b22;
            btn23.Visible = Settings.Default.b23;
            btn24.Visible = Settings.Default.b24;
            btn25.Visible = Settings.Default.b25;
            btn21p.Visible = Settings.Default.b21p;
        }
        public void getsettings3()
        {
            btn31.Visible = Settings.Default.b31;
            btn32.Visible = Settings.Default.b32;
            btn33.Visible = Settings.Default.b33;
            btn34.Visible = Settings.Default.b34;
            btn35.Visible = Settings.Default.b35;
            btn31p.Visible = Settings.Default.b31p;
        }
        public void getsettings4()
        {
            btn41.Visible = Settings.Default.b41;
            btn42.Visible = Settings.Default.b42;
            btn43.Visible = Settings.Default.b43;
            btn44.Visible = Settings.Default.b44;
            btn45.Visible = Settings.Default.b45;
            btn41p.Visible = Settings.Default.b41p;
        }
        public void getsettings5()
        {
            btn51.Visible = Settings.Default.b51;
            btn52.Visible = Settings.Default.b52;
            btn53.Visible = Settings.Default.b53;
            btn54.Visible = Settings.Default.b54;
            btn55.Visible = Settings.Default.b55;
            btn51p.Visible = Settings.Default.b51p;
        }
        public void getsettings6()
        {
            lblAcademicYear1.Text = Settings.Default.cmb;
        }      
        #endregion

        private void EZE_Schedule_Load(object sender, EventArgs e)
        {
            context = new EZEEntities8();
            datetimeright.Start();
            getsettings1();
            getsettings2();
            getsettings3();
            getsettings4();
            getsettings5();
            getsettings6();
            metroTabControl1_SelectedIndexChanged(sender, e);           
        }

        #region Bind1
        void bind11()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-1'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind12()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-2'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind13()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-3'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind14()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-4'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind15()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-5'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind11p()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '1-1P'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        #endregion

        #region Bind2
        void bind21()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-1'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind22()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-2'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind23()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-3'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind24()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-4'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind25()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-5'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind21p()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '2-1P'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        #endregion

        #region Bind3
        void bind31()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-1'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind32()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-2'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind33()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-3'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind34()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-4'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind35()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-5'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind31p()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '3-1P'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        #endregion

        #region Bind4
        void bind41()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-1'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind42()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-2'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind43()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-3'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind44()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-4'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind45()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-5'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind41p()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '4-1P'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        #endregion

        #region Bind5
        void bind51()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-1'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind52()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-2'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind53()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-3'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind54()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-4'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind55()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-5 '", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        void bind51p()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                { db.Open(); }
                schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_and_Section = '5-1P'", commandType: CommandType.Text);
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    if (obj.Year_Level == "First Year")
                    { mrb1.Checked = true; }
                    else if (obj.Year_Level == "Second Year")
                    { mrb2.Checked = true; }
                    else if (obj.Year_Level == "Third Year")
                    { mrb3.Checked = true; }
                    else if (obj.Year_Level == "Fourth Year")
                    { mrb4.Checked = true; }
                    else if (obj.Year_Level == "Fifth Year")
                    { mrb5.Checked = true; }
                }
            }
        }
        #endregion

        #region Add Button
        EntityState objState = EntityState.Unchanged;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            mrb1.Enabled = false;
            mrb2.Enabled = false;
            mrb3.Enabled = false;
            mrb4.Enabled = false;
            mrb5.Enabled = false;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            objState = EntityState.Added;
            schedulesClassBindingSource.Add(new SchedulesClass());
            schedulesClassBindingSource.MoveLast();
            if (metroTabControl1.SelectedTab == firstyear)
            { mrb1.Checked = true; }
            else if (metroTabControl1.SelectedTab == secondyear)
            { mrb2.Checked = true; }
            else if (metroTabControl1.SelectedTab == thirdyear)
            { mrb3.Checked = true; }
            else if (metroTabControl1.SelectedTab == fourthyear)
            { mrb4.Checked = true; }
            else if (metroTabControl1.SelectedTab == fifthyear)
            { mrb5.Checked = true; }
            txtSCode.Select();
            metroTabControl1.Visible = false;
            btnImport.Visible = false;
            btnExport.Visible = false;
            btnRefresh.Visible = false;
            line1.Visible = false;
        }
        #endregion

        #region Edit Button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGrid2.Rows.Count < 1 || metroGrid1.Rows.Count < 1 || metroGrid3.Rows.Count < 1 || metroGrid4.Rows.Count < 1 || metroGrid5.Rows.Count < 1)
            {
                Plexiglass pg = new Plexiglass(this);
                messagebox.showdialog("No data available.");
                pg.Close();
            }
            else
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtSCode.Select();
                mrb1.Enabled = false;
                mrb2.Enabled = false;
                mrb3.Enabled = false;
                mrb4.Enabled = false;
                mrb5.Enabled = false;
                btnSave.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnImport.Visible = false;
                btnExport.Visible = false;
                btnRefresh.Visible = false;
                line1.Visible = false;
                objState = EntityState.Changed;

                if (btn11.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind11(); }
                else if (btn12.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind12(); }
                else if (btn13.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind13(); }
                else if (btn14.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind14(); }
                else if (btn15.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind15(); }
                else if (btn11p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
                { bind11p(); }
                else if (btn21.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind21(); }
                else if (btn22.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind22(); }
                else if (btn23.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind23(); }
                else if (btn24.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind24(); }
                else if (btn25.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind25(); }
                else if (btn21p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
                { bind21p(); }
                else if (btn31.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind31(); }
                else if (btn32.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind32(); }
                else if (btn33.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind33(); }
                else if (btn34.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind34(); }
                else if (btn35.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind35(); }
                else if (btn31p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
                { bind31p(); }
                else if (btn41.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind41(); }
                else if (btn42.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind42(); }
                else if (btn43.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind43(); }
                else if (btn44.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind44(); }
                else if (btn45.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind45(); }
                else if (btn41p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
                { bind41p(); }
                else if (btn51.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind51(); }
                else if (btn52.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind52(); }
                else if (btn53.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind53(); }
                else if (btn54.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind54(); }
                else if (btn55.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind55(); }
                else if (btn51p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
                { bind51p(); }
                else if (btn11.ForeColor != Color.FromArgb(0, 174, 219) || btn25.ForeColor != Color.FromArgb(0, 174, 219) || btn43.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn12.ForeColor != Color.FromArgb(0, 174, 219) || btn21p.ForeColor != Color.FromArgb(0, 174, 219) || btn44.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn13.ForeColor != Color.FromArgb(0, 174, 219) || btn31.ForeColor != Color.FromArgb(0, 174, 219) || btn45.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn14.ForeColor != Color.FromArgb(0, 174, 219) || btn32.ForeColor != Color.FromArgb(0, 174, 219) || btn41p.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn15.ForeColor != Color.FromArgb(0, 174, 219) || btn33.ForeColor != Color.FromArgb(0, 174, 219) || btn51.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn11p.ForeColor != Color.FromArgb(0, 174, 219) || btn34.ForeColor != Color.FromArgb(0, 174, 219) || btn52.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn21.ForeColor != Color.FromArgb(0, 174, 219) || btn35.ForeColor != Color.FromArgb(0, 174, 219) || btn53.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn22.ForeColor != Color.FromArgb(0, 174, 219) || btn31p.ForeColor != Color.FromArgb(0, 174, 219) || btn54.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn23.ForeColor != Color.FromArgb(0, 174, 219) || btn41.ForeColor != Color.FromArgb(0, 174, 219) || btn55.ForeColor != Color.FromArgb(0, 174, 219) ||
                    btn24.ForeColor != Color.FromArgb(0, 174, 219) || btn42.ForeColor != Color.FromArgb(0, 174, 219) || btn51p.ForeColor != Color.FromArgb(0, 174, 219))
                {
                    if (metroTabControl1.SelectedTab == firstyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'First Year'", commandType: CommandType.Text);
                            cancelshit();
                        }
                    }
                    else if (metroTabControl1.SelectedTab == secondyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Second Year'", commandType: CommandType.Text);
                            cancelshit();
                        }
                    }
                    else if (metroTabControl1.SelectedTab == thirdyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Third Year'", commandType: CommandType.Text);
                            cancelshit();
                        }
                    }
                    else if (metroTabControl1.SelectedTab == fourthyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Fourth Year'", commandType: CommandType.Text);
                            cancelshit();
                        }
                    }
                    else if (metroTabControl1.SelectedTab == fifthyear)
                    {
                        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed)
                            { db.Open(); }
                            schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Fifth Year'", commandType: CommandType.Text);
                            cancelshit();
                        }
                    }
                }
                metroTabControl1.Visible = false;
            }
        }
        #endregion

        #region Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                if (obj != null)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed)
                        { db.Open(); }
                        if (txtSCode.Text == "" || txtSName.Text == "" || txtYaS.Text == "" || txtDay.Text == "" || txtRoom.Text == "" || txtTime.Text == "" || txtProf.Text == ""
                            || mrb1.Checked == false && mrb2.Checked == false && mrb3.Checked == false && mrb4.Checked == false && mrb5.Checked == false)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Please complete all necessary fields.");
                            pg.Close();
                        }
                        else if (txtYaS.Text != "1-1" && txtYaS.Text != "1-2" && txtYaS.Text != "1-3" && txtYaS.Text != "1-4" && txtYaS.Text != "1-5" && txtYaS.Text != "1-1P" &&
                               txtYaS.Text != "2-1" && txtYaS.Text != "2-2" && txtYaS.Text != "2-3" && txtYaS.Text != "2-4" && txtYaS.Text != "2-5" && txtYaS.Text != "2-1P" &&
                               txtYaS.Text != "3-1" && txtYaS.Text != "3-2" && txtYaS.Text != "3-3" && txtYaS.Text != "3-4" && txtYaS.Text != "3-5" && txtYaS.Text != "3-1P" &&
                               txtYaS.Text != "4-1" && txtYaS.Text != "4-2" && txtYaS.Text != "4-3" && txtYaS.Text != "4-4" && txtYaS.Text != "4-5" && txtYaS.Text != "4-1P" &&
                               txtYaS.Text != "5-1" && txtYaS.Text != "5-2" && txtYaS.Text != "5-3" && txtYaS.Text != "5-4" && txtYaS.Text != "5-5" && txtYaS.Text != "5-1P")
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("Please enter a valid 'Year and Section'.");
                            pg.Close();
                        }
                        else if (mrb1.Checked == true && txtYaS.Text == "1-1" && Settings.Default.b11 == false || mrb1.Checked == true && txtYaS.Text == "1-2" && Settings.Default.b12 == false
                                 || mrb1.Checked == true && txtYaS.Text == "1-3" && Settings.Default.b13 == false || mrb1.Checked == true && txtYaS.Text == "1-4" && Settings.Default.b14 == false
                                 || mrb1.Checked == true && txtYaS.Text == "1-5" && Settings.Default.b15 == false || mrb1.Checked == true && txtYaS.Text == "1-1P" && Settings.Default.b11p == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-1" && Settings.Default.b21 == false || mrb2.Checked == true && txtYaS.Text == "2-2" && Settings.Default.b22 == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-3" && Settings.Default.b23 == false || mrb2.Checked == true && txtYaS.Text == "2-4" && Settings.Default.b24 == false
                                 || mrb2.Checked == true && txtYaS.Text == "2-5" && Settings.Default.b25 == false || mrb2.Checked == true && txtYaS.Text == "2-1P" && Settings.Default.b21p == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-1" && Settings.Default.b31 == false || mrb3.Checked == true && txtYaS.Text == "3-2" && Settings.Default.b32 == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-3" && Settings.Default.b32 == false || mrb3.Checked == true && txtYaS.Text == "3-4" && Settings.Default.b34 == false
                                 || mrb3.Checked == true && txtYaS.Text == "3-5" && Settings.Default.b35 == false || mrb3.Checked == true && txtYaS.Text == "3-1P" && Settings.Default.b31p == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-1" && Settings.Default.b41 == false || mrb4.Checked == true && txtYaS.Text == "4-2" && Settings.Default.b42 == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-3" && Settings.Default.b43 == false || mrb4.Checked == true && txtYaS.Text == "4-4" && Settings.Default.b44 == false
                                 || mrb4.Checked == true && txtYaS.Text == "4-5" && Settings.Default.b45 == false || mrb4.Checked == true && txtYaS.Text == "4-1P" && Settings.Default.b41p == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-1" && Settings.Default.b51 == false || mrb5.Checked == true && txtYaS.Text == "5-2" && Settings.Default.b52 == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-3" && Settings.Default.b53 == false || mrb5.Checked == true && txtYaS.Text == "5-4" && Settings.Default.b54 == false
                                 || mrb5.Checked == true && txtYaS.Text == "5-5" && Settings.Default.b55 == false || mrb5.Checked == true && txtYaS.Text == "5-1P" && Settings.Default.b51p == false)
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("This section is not available in the database.");
                            pg.Close();
                        }
                        else if (mrb1.Checked == true && txtYaS.Text == "2-1" || mrb1.Checked == true && txtYaS.Text == "2-2" || mrb1.Checked == true && txtYaS.Text == "2-3"
                                || mrb1.Checked == true && txtYaS.Text == "2-4" || mrb1.Checked == true && txtYaS.Text == "2-5" || mrb1.Checked == true && txtYaS.Text == "2-1P"
                                || mrb1.Checked == true && txtYaS.Text == "3-1" || mrb1.Checked == true && txtYaS.Text == "3-2" || mrb1.Checked == true && txtYaS.Text == "3-3"
                                || mrb1.Checked == true && txtYaS.Text == "3-4" || mrb1.Checked == true && txtYaS.Text == "3-5" || mrb1.Checked == true && txtYaS.Text == "3-1P"
                                || mrb1.Checked == true && txtYaS.Text == "4-1" || mrb1.Checked == true && txtYaS.Text == "4-2" || mrb1.Checked == true && txtYaS.Text == "4-3"
                                || mrb1.Checked == true && txtYaS.Text == "4-4" || mrb1.Checked == true && txtYaS.Text == "4-5" || mrb1.Checked == true && txtYaS.Text == "4-1P"
                                || mrb1.Checked == true && txtYaS.Text == "5-1" || mrb1.Checked == true && txtYaS.Text == "5-2" || mrb1.Checked == true && txtYaS.Text == "5-3"
                                || mrb1.Checked == true && txtYaS.Text == "5-4" || mrb1.Checked == true && txtYaS.Text == "5-5" || mrb1.Checked == true && txtYaS.Text == "5-1P"
                                || mrb2.Checked == true && txtYaS.Text == "1-1" || mrb2.Checked == true && txtYaS.Text == "1-2" || mrb2.Checked == true && txtYaS.Text == "1-3"
                                || mrb2.Checked == true && txtYaS.Text == "1-4" || mrb2.Checked == true && txtYaS.Text == "1-5" || mrb2.Checked == true && txtYaS.Text == "1-1P"
                                || mrb2.Checked == true && txtYaS.Text == "3-1" || mrb2.Checked == true && txtYaS.Text == "3-2" || mrb2.Checked == true && txtYaS.Text == "3-3"
                                || mrb2.Checked == true && txtYaS.Text == "3-4" || mrb2.Checked == true && txtYaS.Text == "3-5" || mrb2.Checked == true && txtYaS.Text == "3-1P"
                                || mrb2.Checked == true && txtYaS.Text == "4-1" || mrb2.Checked == true && txtYaS.Text == "4-2" || mrb2.Checked == true && txtYaS.Text == "4-3"
                                || mrb2.Checked == true && txtYaS.Text == "4-4" || mrb2.Checked == true && txtYaS.Text == "4-5" || mrb2.Checked == true && txtYaS.Text == "4-1P"
                                || mrb2.Checked == true && txtYaS.Text == "5-1" || mrb2.Checked == true && txtYaS.Text == "5-2" || mrb2.Checked == true && txtYaS.Text == "5-3"
                                || mrb2.Checked == true && txtYaS.Text == "5-4" || mrb2.Checked == true && txtYaS.Text == "5-5" || mrb2.Checked == true && txtYaS.Text == "5-1P"
                                || mrb3.Checked == true && txtYaS.Text == "2-1" || mrb3.Checked == true && txtYaS.Text == "2-2" || mrb3.Checked == true && txtYaS.Text == "2-3"
                                || mrb3.Checked == true && txtYaS.Text == "2-4" || mrb3.Checked == true && txtYaS.Text == "2-5" || mrb3.Checked == true && txtYaS.Text == "2-1P"
                                || mrb3.Checked == true && txtYaS.Text == "1-1" || mrb3.Checked == true && txtYaS.Text == "1-2" || mrb3.Checked == true && txtYaS.Text == "1-3"
                                || mrb3.Checked == true && txtYaS.Text == "1-4" || mrb3.Checked == true && txtYaS.Text == "1-5" || mrb3.Checked == true && txtYaS.Text == "1-1P"
                                || mrb3.Checked == true && txtYaS.Text == "4-1" || mrb3.Checked == true && txtYaS.Text == "4-2" || mrb3.Checked == true && txtYaS.Text == "4-3"
                                || mrb3.Checked == true && txtYaS.Text == "4-4" || mrb3.Checked == true && txtYaS.Text == "4-5" || mrb3.Checked == true && txtYaS.Text == "4-1P"
                                || mrb3.Checked == true && txtYaS.Text == "5-1" || mrb3.Checked == true && txtYaS.Text == "5-2" || mrb3.Checked == true && txtYaS.Text == "5-3"
                                || mrb3.Checked == true && txtYaS.Text == "5-4" || mrb3.Checked == true && txtYaS.Text == "5-5" || mrb3.Checked == true && txtYaS.Text == "5-1P"
                                || mrb4.Checked == true && txtYaS.Text == "2-1" || mrb4.Checked == true && txtYaS.Text == "2-2" || mrb4.Checked == true && txtYaS.Text == "2-3"
                                || mrb4.Checked == true && txtYaS.Text == "2-4" || mrb4.Checked == true && txtYaS.Text == "2-5" || mrb4.Checked == true && txtYaS.Text == "2-1P"
                                || mrb4.Checked == true && txtYaS.Text == "3-1" || mrb4.Checked == true && txtYaS.Text == "3-2" || mrb4.Checked == true && txtYaS.Text == "3-3"
                                || mrb4.Checked == true && txtYaS.Text == "3-4" || mrb4.Checked == true && txtYaS.Text == "3-5" || mrb4.Checked == true && txtYaS.Text == "3-1P"
                                || mrb4.Checked == true && txtYaS.Text == "1-1" || mrb4.Checked == true && txtYaS.Text == "1-2" || mrb4.Checked == true && txtYaS.Text == "1-3"
                                || mrb4.Checked == true && txtYaS.Text == "1-4" || mrb4.Checked == true && txtYaS.Text == "1-5" || mrb4.Checked == true && txtYaS.Text == "1-1P"
                                || mrb4.Checked == true && txtYaS.Text == "5-1" || mrb4.Checked == true && txtYaS.Text == "5-2" || mrb4.Checked == true && txtYaS.Text == "5-3"
                                || mrb4.Checked == true && txtYaS.Text == "5-4" || mrb4.Checked == true && txtYaS.Text == "5-5" || mrb4.Checked == true && txtYaS.Text == "5-1P"
                                || mrb5.Checked == true && txtYaS.Text == "2-1" || mrb5.Checked == true && txtYaS.Text == "2-2" || mrb5.Checked == true && txtYaS.Text == "2-3"
                                || mrb5.Checked == true && txtYaS.Text == "2-4" || mrb5.Checked == true && txtYaS.Text == "2-5" || mrb5.Checked == true && txtYaS.Text == "2-1P"
                                || mrb5.Checked == true && txtYaS.Text == "3-1" || mrb5.Checked == true && txtYaS.Text == "3-2" || mrb5.Checked == true && txtYaS.Text == "3-3"
                                || mrb5.Checked == true && txtYaS.Text == "3-4" || mrb5.Checked == true && txtYaS.Text == "3-5" || mrb5.Checked == true && txtYaS.Text == "3-1P"
                                || mrb5.Checked == true && txtYaS.Text == "4-1" || mrb5.Checked == true && txtYaS.Text == "4-2" || mrb5.Checked == true && txtYaS.Text == "4-3"
                                || mrb5.Checked == true && txtYaS.Text == "4-4" || mrb5.Checked == true && txtYaS.Text == "4-5" || mrb5.Checked == true && txtYaS.Text == "4-1P"
                                || mrb5.Checked == true && txtYaS.Text == "1-1" || mrb5.Checked == true && txtYaS.Text == "1-2" || mrb5.Checked == true && txtYaS.Text == "1-3"
                                || mrb5.Checked == true && txtYaS.Text == "1-4" || mrb5.Checked == true && txtYaS.Text == "1-5" || mrb5.Checked == true && txtYaS.Text == "1-1P")
                        {
                            Plexiglass pg = new Plexiglass(this);
                            messagebox.showdialog("'Year and Section' you entered doesn't match with the 'Year Level'.");
                            pg.Close();
                        }
                        else
                        {
                            if (objState == EntityState.Changed)
                            {
                                if (mrb1.Checked == true)
                                { yearlevel = "First Year"; }
                                else if (mrb2.Checked == true)
                                { yearlevel = "Second Year"; }
                                else if (mrb3.Checked == true)
                                { yearlevel = "Third Year"; }
                                else if (mrb4.Checked == true)
                                { yearlevel = "Fourth Year"; }
                                else if (mrb5.Checked == true)
                                { yearlevel = "Fifth Year"; }
                                db.Execute("SchedulesTableUpdate", new
                                {
                                    ID = obj.ID,
                                    Subject_Code = obj.Subject_Code,
                                    Subject_Name = obj.Subject_Name,
                                    Day = obj.Day,
                                    Time = obj.Time,
                                    Room = obj.Room,
                                    Professor = obj.Professor,
                                    Year_Level = yearlevel,
                                    Year_and_Section = obj.Year_and_Section
                                }, commandType: CommandType.StoredProcedure);

                                Plexiglass pg = new Plexiglass(this);                               
                                if (yearlevel == "First Year")
                                {
                                    if (obj.Year_and_Section == "1-1")
                                    { metroTabControl1.SelectedIndex = 0; btn11_Click(sender, e); }
                                    else if (obj.Year_and_Section == "1-2")
                                    { metroTabControl1.SelectedIndex = 0; btn12_Click(sender, e); }
                                    else if (obj.Year_and_Section == "1-3")
                                    { metroTabControl1.SelectedIndex = 0; btn13_Click(sender, e); }
                                    else if (obj.Year_and_Section == "1-4")
                                    { metroTabControl1.SelectedIndex = 0; btn14_Click(sender, e); }
                                    else if (obj.Year_and_Section == "1-5")
                                    { metroTabControl1.SelectedIndex = 0; btn15_Click(sender, e); }
                                    else if (obj.Year_and_Section == "1-1P")
                                    { metroTabControl1.SelectedIndex = 0; btn11p_Click(sender, e); }
                                }
                                else if (yearlevel == "Second Year")
                                {
                                    if (obj.Year_and_Section == "2-1")
                                    { metroTabControl1.SelectedIndex = 1; btn21_Click(sender, e); }
                                    else if (obj.Year_and_Section == "2-2")
                                    { metroTabControl1.SelectedIndex = 1; btn22_Click(sender, e); }
                                    else if (obj.Year_and_Section == "2-3")
                                    { metroTabControl1.SelectedIndex = 1; btn23_Click(sender, e); }
                                    else if (obj.Year_and_Section == "2-4")
                                    { metroTabControl1.SelectedIndex = 1; btn24_Click(sender, e); }
                                    else if (obj.Year_and_Section == "2-5")
                                    { metroTabControl1.SelectedIndex = 1; btn25_Click(sender, e); }
                                    else if (obj.Year_and_Section == "2-1P")
                                    { metroTabControl1.SelectedIndex = 1; btn21p_Click(sender, e); }
                                }
                                else if (yearlevel == "Third Year")
                                {
                                    if (obj.Year_and_Section == "3-1")
                                    { metroTabControl1.SelectedIndex = 2; btn31_Click(sender, e); }
                                    else if (obj.Year_and_Section == "3-2")
                                    { metroTabControl1.SelectedIndex = 2; btn32_Click(sender, e); }
                                    else if (obj.Year_and_Section == "3-3")
                                    { metroTabControl1.SelectedIndex = 2; btn33_Click(sender, e); }
                                    else if (obj.Year_and_Section == "3-4")
                                    { metroTabControl1.SelectedIndex = 2; btn34_Click(sender, e); }
                                    else if (obj.Year_and_Section == "3-5")
                                    { metroTabControl1.SelectedIndex = 2; btn35_Click(sender, e); }
                                    else if (obj.Year_and_Section == "3-1P")
                                    { metroTabControl1.SelectedIndex = 2; btn31p_Click(sender, e); }
                                }
                                else if (yearlevel == "Fourth Year")
                                {
                                    if (obj.Year_and_Section == "4-1")
                                    { metroTabControl1.SelectedIndex = 3; btn41_Click(sender, e); }
                                    else if (obj.Year_and_Section == "4-2")
                                    { metroTabControl1.SelectedIndex = 3; btn42_Click(sender, e); }
                                    else if (obj.Year_and_Section == "4-3")
                                    { metroTabControl1.SelectedIndex = 3; btn43_Click(sender, e); }
                                    else if (obj.Year_and_Section == "4-4")
                                    { metroTabControl1.SelectedIndex = 3; btn44_Click(sender, e); }
                                    else if (obj.Year_and_Section == "4-5")
                                    { metroTabControl1.SelectedIndex = 3; btn45_Click(sender, e); }
                                    else if (obj.Year_and_Section == "4-1P")
                                    { metroTabControl1.SelectedIndex = 3; btn41p_Click(sender, e); }
                                }
                                else if (yearlevel == "Fifth Year")
                                {
                                    if (obj.Year_and_Section == "5-1")
                                    { metroTabControl1.SelectedIndex = 4; btn51_Click(sender, e); }
                                    else if (obj.Year_and_Section == "5-2")
                                    { metroTabControl1.SelectedIndex = 4; btn52_Click(sender, e); }
                                    else if (obj.Year_and_Section == "5-3")
                                    { metroTabControl1.SelectedIndex = 4; btn53_Click(sender, e); }
                                    else if (obj.Year_and_Section == "5-4")
                                    { metroTabControl1.SelectedIndex = 4; btn54_Click(sender, e); }
                                    else if (obj.Year_and_Section == "5-5")
                                    { metroTabControl1.SelectedIndex = 4; btn55_Click(sender, e); }
                                    else if (obj.Year_and_Section == "5-1P")
                                    { metroTabControl1.SelectedIndex = 4; btn51p_Click(sender, e); }
                                }
                                messagebox.showdialog("Schedule successfully updated.");
                                metroTabControl1.Visible = true;
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnDelete.Visible = true;
                                btnCancel.Visible = false;
                                btnUpdate.Visible = false;

                                btnImport.Visible = true;
                                btnExport.Visible = true;
                                btnRefresh.Visible = true;
                                line1.Visible = true;
                                pg.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                    if (obj != null)
                    {
                        if (objState == EntityState.Added)
                        {
                            if (txtSCode.Text == "" || txtSName.Text == "" || txtYaS.Text == "" || txtDay.Text == "" || txtRoom.Text == "" || txtTime.Text == "" || txtProf.Text == ""
                                || mrb1.Checked == false && mrb2.Checked == false && mrb3.Checked == false && mrb4.Checked == false && mrb5.Checked == false)
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox.showdialog("Please complete all necessary fields.");
                                pg.Close();
                            }
                            else if (txtYaS.Text != "1-1" && txtYaS.Text != "1-2" && txtYaS.Text != "1-3" && txtYaS.Text != "1-4" && txtYaS.Text != "1-5" && txtYaS.Text != "1-1P" &&
                                  txtYaS.Text != "2-1" && txtYaS.Text != "2-2" && txtYaS.Text != "2-3" && txtYaS.Text != "2-4" && txtYaS.Text != "2-5" && txtYaS.Text != "2-1P" &&
                                  txtYaS.Text != "3-1" && txtYaS.Text != "3-2" && txtYaS.Text != "3-3" && txtYaS.Text != "3-4" && txtYaS.Text != "3-5" && txtYaS.Text != "3-1P" &&
                                  txtYaS.Text != "4-1" && txtYaS.Text != "4-2" && txtYaS.Text != "4-3" && txtYaS.Text != "4-4" && txtYaS.Text != "4-5" && txtYaS.Text != "4-1P" &&
                                  txtYaS.Text != "5-1" && txtYaS.Text != "5-2" && txtYaS.Text != "5-3" && txtYaS.Text != "5-4" && txtYaS.Text != "5-5" && txtYaS.Text != "5-1P")
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox.showdialog("Please enter a valid 'Year and Section'.");
                                pg.Close();
                            }
                            else if (mrb1.Checked == true && txtYaS.Text == "1-1" && Settings.Default.b11 == false || mrb1.Checked == true && txtYaS.Text == "1-2" && Settings.Default.b12 == false
                                     || mrb1.Checked == true && txtYaS.Text == "1-3" && Settings.Default.b13 == false || mrb1.Checked == true && txtYaS.Text == "1-4" && Settings.Default.b14 == false
                                     || mrb1.Checked == true && txtYaS.Text == "1-5" && Settings.Default.b15 == false || mrb1.Checked == true && txtYaS.Text == "1-1P" && Settings.Default.b11p == false
                                     || mrb2.Checked == true && txtYaS.Text == "2-1" && Settings.Default.b21 == false || mrb2.Checked == true && txtYaS.Text == "2-2" && Settings.Default.b22 == false
                                     || mrb2.Checked == true && txtYaS.Text == "2-3" && Settings.Default.b23 == false || mrb2.Checked == true && txtYaS.Text == "2-4" && Settings.Default.b24 == false
                                     || mrb2.Checked == true && txtYaS.Text == "2-5" && Settings.Default.b25 == false || mrb2.Checked == true && txtYaS.Text == "2-1P" && Settings.Default.b21p == false
                                     || mrb3.Checked == true && txtYaS.Text == "3-1" && Settings.Default.b31 == false || mrb3.Checked == true && txtYaS.Text == "3-2" && Settings.Default.b32 == false
                                     || mrb3.Checked == true && txtYaS.Text == "3-3" && Settings.Default.b33 == false || mrb3.Checked == true && txtYaS.Text == "3-4" && Settings.Default.b34 == false
                                     || mrb3.Checked == true && txtYaS.Text == "3-5" && Settings.Default.b35 == false || mrb3.Checked == true && txtYaS.Text == "3-1P" && Settings.Default.b31p == false
                                     || mrb4.Checked == true && txtYaS.Text == "4-1" && Settings.Default.b41 == false || mrb4.Checked == true && txtYaS.Text == "4-2" && Settings.Default.b42 == false
                                     || mrb4.Checked == true && txtYaS.Text == "4-3" && Settings.Default.b43 == false || mrb4.Checked == true && txtYaS.Text == "4-4" && Settings.Default.b44 == false
                                     || mrb4.Checked == true && txtYaS.Text == "4-5" && Settings.Default.b45 == false || mrb4.Checked == true && txtYaS.Text == "4-1P" && Settings.Default.b41p == false
                                     || mrb5.Checked == true && txtYaS.Text == "5-1" && Settings.Default.b51 == false || mrb5.Checked == true && txtYaS.Text == "5-2" && Settings.Default.b52 == false
                                     || mrb5.Checked == true && txtYaS.Text == "5-3" && Settings.Default.b53 == false || mrb5.Checked == true && txtYaS.Text == "5-4" && Settings.Default.b54 == false
                                     || mrb5.Checked == true && txtYaS.Text == "5-5" && Settings.Default.b55 == false || mrb5.Checked == true && txtYaS.Text == "5-1P" && Settings.Default.b51p == false
                                     )
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox.showdialog("This section is not available in the database.");
                                pg.Close();
                            }
                            else if (mrb1.Checked == true && txtYaS.Text == "2-1" || mrb1.Checked == true && txtYaS.Text == "2-2" || mrb1.Checked == true && txtYaS.Text == "2-3"
                                       || mrb1.Checked == true && txtYaS.Text == "2-4" || mrb1.Checked == true && txtYaS.Text == "2-5" || mrb1.Checked == true && txtYaS.Text == "2-1P"
                                       || mrb1.Checked == true && txtYaS.Text == "3-1" || mrb1.Checked == true && txtYaS.Text == "3-2" || mrb1.Checked == true && txtYaS.Text == "3-3"
                                       || mrb1.Checked == true && txtYaS.Text == "3-4" || mrb1.Checked == true && txtYaS.Text == "3-5" || mrb1.Checked == true && txtYaS.Text == "3-1P"
                                       || mrb1.Checked == true && txtYaS.Text == "4-1" || mrb1.Checked == true && txtYaS.Text == "4-2" || mrb1.Checked == true && txtYaS.Text == "4-3"
                                       || mrb1.Checked == true && txtYaS.Text == "4-4" || mrb1.Checked == true && txtYaS.Text == "4-5" || mrb1.Checked == true && txtYaS.Text == "4-1P"
                                       || mrb1.Checked == true && txtYaS.Text == "5-1" || mrb1.Checked == true && txtYaS.Text == "5-2" || mrb1.Checked == true && txtYaS.Text == "5-3"
                                       || mrb1.Checked == true && txtYaS.Text == "5-4" || mrb1.Checked == true && txtYaS.Text == "5-5" || mrb1.Checked == true && txtYaS.Text == "5-1P"
                                       || mrb2.Checked == true && txtYaS.Text == "1-1" || mrb2.Checked == true && txtYaS.Text == "1-2" || mrb2.Checked == true && txtYaS.Text == "1-3"
                                       || mrb2.Checked == true && txtYaS.Text == "1-4" || mrb2.Checked == true && txtYaS.Text == "1-5" || mrb2.Checked == true && txtYaS.Text == "1-1P"
                                       || mrb2.Checked == true && txtYaS.Text == "3-1" || mrb2.Checked == true && txtYaS.Text == "3-2" || mrb2.Checked == true && txtYaS.Text == "3-3"
                                       || mrb2.Checked == true && txtYaS.Text == "3-4" || mrb2.Checked == true && txtYaS.Text == "3-5" || mrb2.Checked == true && txtYaS.Text == "3-1P"
                                       || mrb2.Checked == true && txtYaS.Text == "4-1" || mrb2.Checked == true && txtYaS.Text == "4-2" || mrb2.Checked == true && txtYaS.Text == "4-3"
                                       || mrb2.Checked == true && txtYaS.Text == "4-4" || mrb2.Checked == true && txtYaS.Text == "4-5" || mrb2.Checked == true && txtYaS.Text == "4-1P"
                                       || mrb2.Checked == true && txtYaS.Text == "5-1" || mrb2.Checked == true && txtYaS.Text == "5-2" || mrb2.Checked == true && txtYaS.Text == "5-3"
                                       || mrb2.Checked == true && txtYaS.Text == "5-4" || mrb2.Checked == true && txtYaS.Text == "5-5" || mrb2.Checked == true && txtYaS.Text == "5-1P"
                                       || mrb3.Checked == true && txtYaS.Text == "2-1" || mrb3.Checked == true && txtYaS.Text == "2-2" || mrb3.Checked == true && txtYaS.Text == "2-3"
                                       || mrb3.Checked == true && txtYaS.Text == "2-4" || mrb3.Checked == true && txtYaS.Text == "2-5" || mrb3.Checked == true && txtYaS.Text == "2-1P"
                                       || mrb3.Checked == true && txtYaS.Text == "1-1" || mrb3.Checked == true && txtYaS.Text == "1-2" || mrb3.Checked == true && txtYaS.Text == "1-3"
                                       || mrb3.Checked == true && txtYaS.Text == "1-4" || mrb3.Checked == true && txtYaS.Text == "1-5" || mrb3.Checked == true && txtYaS.Text == "1-1P"
                                       || mrb3.Checked == true && txtYaS.Text == "4-1" || mrb3.Checked == true && txtYaS.Text == "4-2" || mrb3.Checked == true && txtYaS.Text == "4-3"
                                       || mrb3.Checked == true && txtYaS.Text == "4-4" || mrb3.Checked == true && txtYaS.Text == "4-5" || mrb3.Checked == true && txtYaS.Text == "4-1P"
                                       || mrb3.Checked == true && txtYaS.Text == "5-1" || mrb3.Checked == true && txtYaS.Text == "5-2" || mrb3.Checked == true && txtYaS.Text == "5-3"
                                       || mrb3.Checked == true && txtYaS.Text == "5-4" || mrb3.Checked == true && txtYaS.Text == "5-5" || mrb3.Checked == true && txtYaS.Text == "5-1P"
                                       || mrb4.Checked == true && txtYaS.Text == "2-1" || mrb4.Checked == true && txtYaS.Text == "2-2" || mrb4.Checked == true && txtYaS.Text == "2-3"
                                       || mrb4.Checked == true && txtYaS.Text == "2-4" || mrb4.Checked == true && txtYaS.Text == "2-5" || mrb4.Checked == true && txtYaS.Text == "2-1P"
                                       || mrb4.Checked == true && txtYaS.Text == "3-1" || mrb4.Checked == true && txtYaS.Text == "3-2" || mrb4.Checked == true && txtYaS.Text == "3-3"
                                       || mrb4.Checked == true && txtYaS.Text == "3-4" || mrb4.Checked == true && txtYaS.Text == "3-5" || mrb4.Checked == true && txtYaS.Text == "3-1P"
                                       || mrb4.Checked == true && txtYaS.Text == "1-1" || mrb4.Checked == true && txtYaS.Text == "1-2" || mrb4.Checked == true && txtYaS.Text == "1-3"
                                       || mrb4.Checked == true && txtYaS.Text == "1-4" || mrb4.Checked == true && txtYaS.Text == "1-5" || mrb4.Checked == true && txtYaS.Text == "1-1P"
                                       || mrb4.Checked == true && txtYaS.Text == "5-1" || mrb4.Checked == true && txtYaS.Text == "5-2" || mrb4.Checked == true && txtYaS.Text == "5-3"
                                       || mrb4.Checked == true && txtYaS.Text == "5-4" || mrb4.Checked == true && txtYaS.Text == "5-5" || mrb4.Checked == true && txtYaS.Text == "5-1P"
                                       || mrb5.Checked == true && txtYaS.Text == "2-1" || mrb5.Checked == true && txtYaS.Text == "2-2" || mrb5.Checked == true && txtYaS.Text == "2-3"
                                       || mrb5.Checked == true && txtYaS.Text == "2-4" || mrb5.Checked == true && txtYaS.Text == "2-5" || mrb5.Checked == true && txtYaS.Text == "2-1P"
                                       || mrb5.Checked == true && txtYaS.Text == "3-1" || mrb5.Checked == true && txtYaS.Text == "3-2" || mrb5.Checked == true && txtYaS.Text == "3-3"
                                       || mrb5.Checked == true && txtYaS.Text == "3-4" || mrb5.Checked == true && txtYaS.Text == "3-5" || mrb5.Checked == true && txtYaS.Text == "3-1P"
                                       || mrb5.Checked == true && txtYaS.Text == "4-1" || mrb5.Checked == true && txtYaS.Text == "4-2" || mrb5.Checked == true && txtYaS.Text == "4-3"
                                       || mrb5.Checked == true && txtYaS.Text == "4-4" || mrb5.Checked == true && txtYaS.Text == "4-5" || mrb5.Checked == true && txtYaS.Text == "4-1P"
                                       || mrb5.Checked == true && txtYaS.Text == "1-1" || mrb5.Checked == true && txtYaS.Text == "1-2" || mrb5.Checked == true && txtYaS.Text == "1-3"
                                       || mrb5.Checked == true && txtYaS.Text == "1-4" || mrb5.Checked == true && txtYaS.Text == "1-5" || mrb5.Checked == true && txtYaS.Text == "1-1P")
                            {
                                Plexiglass pg = new Plexiglass(this);
                                messagebox.showdialog("'Year and Section' you entered doesn't match with the 'Year Level'.");
                                pg.Close();
                            }
                            else
                            {
                                using (SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                                {
                                    if (myConn.State == ConnectionState.Closed)
                                    { myConn.Open(); }
                                    SqlCommand SelectCommand = new SqlCommand(" Select * from SchedulesTable where Subject_Code='" + txtSCode.Text + "'", myConn);
                                    SqlDataReader dr;
                                    dr = SelectCommand.ExecuteReader();
                                    int count = 0;
                                    string scode = string.Empty;
                                    string yearandsection = string.Empty;
                                    while (dr.Read())
                                    {
                                        count = count + 1;
                                        scode = dr["Subject_Code"].ToString();
                                        //yearandsection = dr["Year_and_Section"].ToString();
                                        yearlevel = dr["Year Level"].ToString();
                                    }
                                    if (txtSCode.Text == scode && btn11.ForeColor == Color.FromArgb(0, 174, 219) || btn12.ForeColor == Color.FromArgb(0, 174, 219) || btn13.ForeColor == Color.FromArgb(0, 174, 219) || btn14.ForeColor == Color.FromArgb(0, 174, 219) || btn15.ForeColor == Color.FromArgb(0, 174, 219) || btn11p.ForeColor == Color.FromArgb(0, 174, 219))                                       
                                    {
                                        Plexiglass pg = new Plexiglass(this);
                                        messagebox.showdialog("This subject already exists in the database.");
                                        pg.Close();
                                    }
                                    else
                                    {
                                        if (mrb1.Checked == true)
                                        { yearlevel = "First Year"; }
                                        else if (mrb2.Checked == true)
                                        { yearlevel = "Second Year"; }
                                        else if (mrb3.Checked == true)
                                        { yearlevel = "Third Year"; }
                                        else if (mrb4.Checked == true)
                                        { yearlevel = "Fourth Year"; }
                                        else if (mrb5.Checked == true)
                                        { yearlevel = "Fifth Year"; }
                                        DynamicParameters p = new DynamicParameters();
                                        p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                                        p.AddDynamicParams(new
                                        {
                                            Subject_Code = obj.Subject_Code,
                                            Subject_Name = obj.Subject_Name,
                                            Day = obj.Day,
                                            Time = obj.Time,
                                            Room = obj.Room,
                                            Professor = obj.Professor,
                                            Year_Level = yearlevel,
                                            Year_and_Section = obj.Year_and_Section
                                        });
                                        db.Execute("SchedulesTableInsert", p, commandType: CommandType.StoredProcedure);
                                        obj.ID = p.Get<int>("@ID");

                                        Plexiglass pg = new Plexiglass(this);
                                        if (yearlevel == "First Year")
                                        {
                                            if (obj.Year_and_Section == "1-1")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn11_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "1-2")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn12_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "1-3")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn13_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "1-4")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn14_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "1-5")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn15_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "1-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 0;
                                                btn11p_Click(sender, e);
                                            }
                                        }
                                        else if (yearlevel == "Second Year")
                                        {
                                            if (obj.Year_and_Section == "2-1")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn21_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "2-2")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn22_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "2-3")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn23_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "2-4")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn24_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "2-5")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn25_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "2-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 1;
                                                btn21p_Click(sender, e);
                                            }
                                        }
                                        else if (yearlevel == "Third Year")
                                        {
                                            if (obj.Year_and_Section == "3-1")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn31_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "3-2")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn32_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "3-3")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn33_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "3-4")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn34_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "3-5")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn35_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "3-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 2;
                                                btn31p_Click(sender, e);
                                            }
                                        }
                                        else if (yearlevel == "Fourth Year")
                                        {
                                            if (obj.Year_and_Section == "4-1")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn41_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "4-2")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn42_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "4-3")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn43_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "4-4")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn44_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "4-5")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn45_Click(sender, e);
                                            }
                                            else if (obj.Year_and_Section == "4-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 3;
                                                btn41p_Click(sender, e);
                                            }
                                        }
                                        else if (yearlevel == "Fifth Year")
                                        {
                                            if (obj.Year_and_Section == "5-1")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn51_Click(sender, e);
                                            }
                                            if (obj.Year_and_Section == "5-2")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn52_Click(sender, e);
                                            }
                                            if (obj.Year_and_Section == "5-3")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn53_Click(sender, e);
                                            }
                                            if (obj.Year_and_Section == "5-4")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn54_Click(sender, e);
                                            }
                                            if (obj.Year_and_Section == "5-5")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn55_Click(sender, e);
                                            }
                                            if (obj.Year_and_Section == "5-1P")
                                            {
                                                metroTabControl1.SelectedIndex = 4;
                                                btn51p_Click(sender, e);
                                            }
                                        }
                                        messagebox.showdialog("Schedule successfully saved.");
                                        schedulesClassBindingSource.MoveFirst();
                                        metroTabControl1.Visible = true;
                                        btnAdd.Visible = true;
                                        btnEdit.Visible = true;
                                        btnDelete.Visible = true;
                                        btnCancel.Visible = false;
                                        btnSave.Visible = false;
                                        btnImport.Visible = true;
                                        btnExport.Visible = true;
                                        btnRefresh.Visible = true;
                                        line1.Visible = true;
                                        pg.Close();                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            metroTabControl1.Visible = true;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnImport.Visible = true;
            btnExport.Visible = true;
            btnRefresh.Visible = true;
            line1.Visible = true;
            if (btn11.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind11(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn12.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind12(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn13.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind13(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn14.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind14(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn15.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind15(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn11p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == firstyear)
            { bind11p(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn21.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind21(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn22.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind22(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn23.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind23(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn24.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind24(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn25.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind25(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn21p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == secondyear)
            { bind21p(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn31.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind31(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn32.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind32(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn33.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind33(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn34.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind34(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn35.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind35(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn31p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == thirdyear)
            { bind31p(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn41.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind41(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn42.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind42(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn43.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind43(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn44.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind44(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn45.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind45(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn41p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fourthyear)
            { bind41p(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn51.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind51(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn52.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind52(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn53.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind53(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn54.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind54(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn55.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind55(); schedulesClassBindingSource.MoveFirst(); }
            else if (btn51p.ForeColor == Color.FromArgb(0, 174, 219) && metroTabControl1.SelectedTab == fifthyear)
            { bind51p(); schedulesClassBindingSource.MoveFirst(); }
            else
            { metroTabControl1_SelectedIndexChanged(sender, e); }          
        }
        #endregion

        #region Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
             Plexiglass pg = new Plexiglass(this);
            if (metroGrid1.Rows.Count < 1 || metroGrid2.Rows.Count < 1 || metroGrid3.Rows.Count < 1 || metroGrid4.Rows.Count < 1 || metroGrid5.Rows.Count < 1)
            {
                messagebox.showdialog("No data available.");
            }
            else if (metroTabControl1.SelectedTab == firstyear)
            {
                if (messagebox.showdialog("You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid1.SelectedRows)
                    {
                        string scode = row.Cells[0].Value.ToString();
                        var scodee = context.SchedulesTables.FirstOrDefault(a => a.Subject_Code.Equals(scode));
                        if (scodee != null)
                        {
                            context.SchedulesTables.Attach(scodee);
                            context.SchedulesTables.Remove(scodee);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    schedulesClassBindingSource.MoveFirst();
                    btnCancel_Click(sender, e);
                    messagebox.showdialog("Schedule successfully deleted.");
                }
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                if (messagebox.showdialog("You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid2.SelectedRows)
                    {
                        string scode = row.Cells[0].Value.ToString();
                        var scodee = context.SchedulesTables.FirstOrDefault(a => a.Subject_Code.Equals(scode));
                        if (scodee != null)
                        {
                            context.SchedulesTables.Attach(scodee);
                            context.SchedulesTables.Remove(scodee);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    schedulesClassBindingSource.MoveFirst();
                    btnCancel_Click(sender, e);
                    messagebox.showdialog("Schedule successfully deleted.");
                }
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                if (messagebox.showdialog("You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid3.SelectedRows)
                    {
                        string scode = row.Cells[0].Value.ToString();
                        var scodee = context.SchedulesTables.FirstOrDefault(a => a.Subject_Code.Equals(scode));
                        if (scodee != null)
                        {
                            context.SchedulesTables.Attach(scodee);
                            context.SchedulesTables.Remove(scodee);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    schedulesClassBindingSource.MoveFirst();
                    btnCancel_Click(sender, e);
                    messagebox.showdialog("Schedule successfully deleted.");
                }
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                if (messagebox.showdialog("You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid4.SelectedRows)
                    {
                        string scode = row.Cells[0].Value.ToString();
                        var scodee = context.SchedulesTables.FirstOrDefault(a => a.Subject_Code.Equals(scode));
                        if (scodee != null)
                        {
                            context.SchedulesTables.Attach(scodee);
                            context.SchedulesTables.Remove(scodee);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    schedulesClassBindingSource.MoveFirst();
                    btnCancel_Click(sender, e);
                    messagebox.showdialog("Schedule successfully deleted.");
                }
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                if (messagebox.showdialog("You're attempting to remove this schedule/s from the database. You can't undone this anymore once it is deleted. Continue?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow row in metroGrid5.SelectedRows)
                    {
                        string scode = row.Cells[0].Value.ToString();
                        var scodee = context.SchedulesTables.FirstOrDefault(a => a.Subject_Code.Equals(scode));
                        if (scodee != null)
                        {
                            context.SchedulesTables.Attach(scodee);
                            context.SchedulesTables.Remove(scodee);
                            context.SaveChanges();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    schedulesClassBindingSource.MoveFirst();
                    btnCancel_Click(sender, e);
                    messagebox.showdialog("Schedule successfully deleted.");
                }
            }
            pg.Close();
        }
        #endregion   
 
        #region Button 1-1 to 5-1P
        private void btn11_Click(object sender, EventArgs e)
        {
            p11.Visible = true;
            p12.Visible = false;
            p13.Visible = false;
            p14.Visible = false;
            p15.Visible = false;
            p11p.Visible = false;
            btn11.ForeColor = Color.FromArgb(0, 174, 219);
            btn12.ForeColor = Color.FromArgb(128, 128, 128);
            btn13.ForeColor = Color.FromArgb(128, 128, 128);
            btn14.ForeColor = Color.FromArgb(128, 128, 128);
            btn15.ForeColor = Color.FromArgb(128, 128, 128);
            btn11p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind11();
        }
        private void btn12_Click(object sender, EventArgs e)
        {
            p12.Visible = true;
            p11.Visible = false;
            p13.Visible = false;
            p14.Visible = false;
            p15.Visible = false;
            p11p.Visible = false;
            btn12.ForeColor = Color.FromArgb(0, 174, 219);
            btn11.ForeColor = Color.FromArgb(128, 128, 128);
            btn13.ForeColor = Color.FromArgb(128, 128, 128);
            btn14.ForeColor = Color.FromArgb(128, 128, 128);
            btn15.ForeColor = Color.FromArgb(128, 128, 128);
            btn11p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind12();
        }
        private void btn13_Click(object sender, EventArgs e)
        {
            p13.Visible = true;
            p11.Visible = false;
            p12.Visible = false;
            p14.Visible = false;
            p15.Visible = false;
            p11p.Visible = false;
            btn13.ForeColor = Color.FromArgb(0, 174, 219);
            btn11.ForeColor = Color.FromArgb(128, 128, 128);
            btn12.ForeColor = Color.FromArgb(128, 128, 128);
            btn14.ForeColor = Color.FromArgb(128, 128, 128);
            btn15.ForeColor = Color.FromArgb(128, 128, 128);
            btn11p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind13();
        }
        private void btn14_Click(object sender, EventArgs e)
        {
            p14.Visible = true;
            p11.Visible = false;
            p12.Visible = false;
            p13.Visible = false;
            p15.Visible = false;
            p11p.Visible = false;
            btn14.ForeColor = Color.FromArgb(0, 174, 219);
            btn11.ForeColor = Color.FromArgb(128, 128, 128);
            btn12.ForeColor = Color.FromArgb(128, 128, 128);
            btn13.ForeColor = Color.FromArgb(128, 128, 128);
            btn15.ForeColor = Color.FromArgb(128, 128, 128);
            btn11p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind14();
        }
        private void btn15_Click(object sender, EventArgs e)
        {
            p15.Visible = true;
            p11.Visible = false;
            p12.Visible = false;
            p13.Visible = false;
            p14.Visible = false;
            p11p.Visible = false;
            btn15.ForeColor = Color.FromArgb(0, 174, 219);
            btn11.ForeColor = Color.FromArgb(128, 128, 128);
            btn12.ForeColor = Color.FromArgb(128, 128, 128);
            btn13.ForeColor = Color.FromArgb(128, 128, 128);
            btn14.ForeColor = Color.FromArgb(128, 128, 128);
            btn11p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind15();
        }
        private void btn11p_Click(object sender, EventArgs e)
        {
            p11p.Visible = true;
            p11.Visible = false;
            p12.Visible = false;
            p13.Visible = false;
            p14.Visible = false;
            p15.Visible = false;
            btn11p.ForeColor = Color.FromArgb(0, 174, 219);
            btn11.ForeColor = Color.FromArgb(128, 128, 128);
            btn12.ForeColor = Color.FromArgb(128, 128, 128);
            btn13.ForeColor = Color.FromArgb(128, 128, 128);
            btn14.ForeColor = Color.FromArgb(128, 128, 128);
            btn15.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind11p();
        }
        private void btn21_Click(object sender, EventArgs e)
        {
            p21.Visible = true;
            p22.Visible = false;
            p23.Visible = false;
            p24.Visible = false;
            p25.Visible = false;
            p21p.Visible = false;
            btn21.ForeColor = Color.FromArgb(0, 174, 219);
            btn22.ForeColor = Color.FromArgb(128, 128, 128);
            btn23.ForeColor = Color.FromArgb(128, 128, 128);
            btn24.ForeColor = Color.FromArgb(128, 128, 128);
            btn25.ForeColor = Color.FromArgb(128, 128, 128);
            btn21p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind21();
        }
        private void btn22_Click(object sender, EventArgs e)
        {
            p22.Visible = true;
            p21.Visible = false;
            p23.Visible = false;
            p24.Visible = false;
            p25.Visible = false;
            p21p.Visible = false;
            btn22.ForeColor = Color.FromArgb(0, 174, 219);
            btn21.ForeColor = Color.FromArgb(128, 128, 128);
            btn23.ForeColor = Color.FromArgb(128, 128, 128);
            btn24.ForeColor = Color.FromArgb(128, 128, 128);
            btn25.ForeColor = Color.FromArgb(128, 128, 128);
            btn21p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind22();
        }
        private void btn23_Click(object sender, EventArgs e)
        {
            p23.Visible = true;
            p21.Visible = false;
            p22.Visible = false;
            p24.Visible = false;
            p25.Visible = false;
            p21p.Visible = false;
            btn23.ForeColor = Color.FromArgb(0, 174, 219);
            btn21.ForeColor = Color.FromArgb(128, 128, 128);
            btn22.ForeColor = Color.FromArgb(128, 128, 128);
            btn24.ForeColor = Color.FromArgb(128, 128, 128);
            btn25.ForeColor = Color.FromArgb(128, 128, 128);
            btn21p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind23();
        }
        private void btn24_Click(object sender, EventArgs e)
        {
            p24.Visible = true;
            p21.Visible = false;
            p22.Visible = false;
            p23.Visible = false;
            p25.Visible = false;
            p21p.Visible = false;
            btn24.ForeColor = Color.FromArgb(0, 174, 219);
            btn21.ForeColor = Color.FromArgb(128, 128, 128);
            btn22.ForeColor = Color.FromArgb(128, 128, 128);
            btn23.ForeColor = Color.FromArgb(128, 128, 128);
            btn25.ForeColor = Color.FromArgb(128, 128, 128);
            btn21p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind24();
        }
        private void btn25_Click(object sender, EventArgs e)
        {
            p25.Visible = true;
            p21.Visible = false;
            p22.Visible = false;
            p23.Visible = false;
            p24.Visible = false;
            p21p.Visible = false;
            btn25.ForeColor = Color.FromArgb(0, 174, 219);
            btn21.ForeColor = Color.FromArgb(128, 128, 128);
            btn22.ForeColor = Color.FromArgb(128, 128, 128);
            btn23.ForeColor = Color.FromArgb(128, 128, 128);
            btn24.ForeColor = Color.FromArgb(128, 128, 128);
            btn21p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind25();
        }
        private void btn21p_Click(object sender, EventArgs e)
        {
            p21p.Visible = true;
            p21.Visible = false;
            p22.Visible = false;
            p23.Visible = false;
            p24.Visible = false;
            p25.Visible = false;
            btn21p.ForeColor = Color.FromArgb(0, 174, 219);
            btn21.ForeColor = Color.FromArgb(128, 128, 128);
            btn22.ForeColor = Color.FromArgb(128, 128, 128);
            btn23.ForeColor = Color.FromArgb(128, 128, 128);
            btn24.ForeColor = Color.FromArgb(128, 128, 128);
            btn25.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind21p();
        }
        private void btn31_Click(object sender, EventArgs e)
        {
            p31.Visible = true;
            p32.Visible = false;
            p33.Visible = false;
            p34.Visible = false;
            p35.Visible = false;
            p31p.Visible = false;
            btn31.ForeColor = Color.FromArgb(0, 174, 219);
            btn32.ForeColor = Color.FromArgb(128, 128, 128);
            btn33.ForeColor = Color.FromArgb(128, 128, 128);
            btn34.ForeColor = Color.FromArgb(128, 128, 128);
            btn35.ForeColor = Color.FromArgb(128, 128, 128);
            btn31p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind31();
        }
        private void btn32_Click(object sender, EventArgs e)
        {
            p32.Visible = true;
            p31.Visible = false;
            p33.Visible = false;
            p34.Visible = false;
            p35.Visible = false;
            p31p.Visible = false;
            btn32.ForeColor = Color.FromArgb(0, 174, 219);
            btn31.ForeColor = Color.FromArgb(128, 128, 128);
            btn33.ForeColor = Color.FromArgb(128, 128, 128);
            btn34.ForeColor = Color.FromArgb(128, 128, 128);
            btn35.ForeColor = Color.FromArgb(128, 128, 128);
            btn31p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind32();
        }
        private void btn33_Click(object sender, EventArgs e)
        {
            p33.Visible = true;
            p31.Visible = false;
            p32.Visible = false;
            p34.Visible = false;
            p35.Visible = false;
            p31p.Visible = false;
            btn33.ForeColor = Color.FromArgb(0, 174, 219);
            btn31.ForeColor = Color.FromArgb(128, 128, 128);
            btn32.ForeColor = Color.FromArgb(128, 128, 128);
            btn34.ForeColor = Color.FromArgb(128, 128, 128);
            btn35.ForeColor = Color.FromArgb(128, 128, 128);
            btn31p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind33();
        }
        private void btn34_Click(object sender, EventArgs e)
        {
            p34.Visible = true;
            p31.Visible = false;
            p32.Visible = false;
            p33.Visible = false;
            p35.Visible = false;
            p31p.Visible = false;
            btn34.ForeColor = Color.FromArgb(0, 174, 219);
            btn31.ForeColor = Color.FromArgb(128, 128, 128);
            btn32.ForeColor = Color.FromArgb(128, 128, 128);
            btn33.ForeColor = Color.FromArgb(128, 128, 128);
            btn35.ForeColor = Color.FromArgb(128, 128, 128);
            btn31p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind34();
        }
        private void btn35_Click(object sender, EventArgs e)
        {
            p35.Visible = true;
            p31.Visible = false;
            p32.Visible = false;
            p33.Visible = false;
            p34.Visible = false;
            p31p.Visible = false;
            btn35.ForeColor = Color.FromArgb(0, 174, 219);
            btn31.ForeColor = Color.FromArgb(128, 128, 128);
            btn32.ForeColor = Color.FromArgb(128, 128, 128);
            btn33.ForeColor = Color.FromArgb(128, 128, 128);
            btn34.ForeColor = Color.FromArgb(128, 128, 128);
            btn31p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind35();
        }
        private void btn31p_Click(object sender, EventArgs e)
        {
            p31p.Visible = true;
            p31.Visible = false;
            p32.Visible = false;
            p33.Visible = false;
            p34.Visible = false;
            p35.Visible = false;
            btn31p.ForeColor = Color.FromArgb(0, 174, 219);
            btn31.ForeColor = Color.FromArgb(128, 128, 128);
            btn32.ForeColor = Color.FromArgb(128, 128, 128);
            btn33.ForeColor = Color.FromArgb(128, 128, 128);
            btn34.ForeColor = Color.FromArgb(128, 128, 128);
            btn35.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind31p();
        }
        private void btn41_Click(object sender, EventArgs e)
        {
            p41.Visible = true;
            p42.Visible = false;
            p43.Visible = false;
            p44.Visible = false;
            p45.Visible = false;
            p41p.Visible = false;
            btn41.ForeColor = Color.FromArgb(0, 174, 219);
            btn42.ForeColor = Color.FromArgb(128, 128, 128);
            btn43.ForeColor = Color.FromArgb(128, 128, 128);
            btn44.ForeColor = Color.FromArgb(128, 128, 128);
            btn45.ForeColor = Color.FromArgb(128, 128, 128);
            btn41p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind41();
        }
        private void btn42_Click(object sender, EventArgs e)
        {
            p42.Visible = true;
            p41.Visible = false;
            p43.Visible = false;
            p44.Visible = false;
            p45.Visible = false;
            p41p.Visible = false;
            btn42.ForeColor = Color.FromArgb(0, 174, 219);
            btn41.ForeColor = Color.FromArgb(128, 128, 128);
            btn43.ForeColor = Color.FromArgb(128, 128, 128);
            btn44.ForeColor = Color.FromArgb(128, 128, 128);
            btn45.ForeColor = Color.FromArgb(128, 128, 128);
            btn41p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind42();
        }
        private void btn43_Click(object sender, EventArgs e)
        {
            p43.Visible = true;
            p41.Visible = false;
            p42.Visible = false;
            p44.Visible = false;
            p45.Visible = false;
            p41p.Visible = false;
            btn43.ForeColor = Color.FromArgb(0, 174, 219);
            btn41.ForeColor = Color.FromArgb(128, 128, 128);
            btn42.ForeColor = Color.FromArgb(128, 128, 128);
            btn44.ForeColor = Color.FromArgb(128, 128, 128);
            btn45.ForeColor = Color.FromArgb(128, 128, 128);
            btn41p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind43();
        }
        private void btn44_Click(object sender, EventArgs e)
        {
            p44.Visible = true;
            p41.Visible = false;
            p42.Visible = false;
            p43.Visible = false;
            p45.Visible = false;
            p41p.Visible = false;
            btn44.ForeColor = Color.FromArgb(0, 174, 219);
            btn41.ForeColor = Color.FromArgb(128, 128, 128);
            btn42.ForeColor = Color.FromArgb(128, 128, 128);
            btn43.ForeColor = Color.FromArgb(128, 128, 128);
            btn45.ForeColor = Color.FromArgb(128, 128, 128);
            btn41p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind44();
        }
        private void btn45_Click(object sender, EventArgs e)
        {
            p45.Visible = true;
            p41.Visible = false;
            p42.Visible = false;
            p43.Visible = false;
            p44.Visible = false;
            p41p.Visible = false;
            btn45.ForeColor = Color.FromArgb(0, 174, 219);
            btn41.ForeColor = Color.FromArgb(128, 128, 128);
            btn42.ForeColor = Color.FromArgb(128, 128, 128);
            btn43.ForeColor = Color.FromArgb(128, 128, 128);
            btn44.ForeColor = Color.FromArgb(128, 128, 128);
            btn41p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind45();
        }  
        private void btn41p_Click(object sender, EventArgs e)
        {
            p41p.Visible = true;
            p41.Visible = false;
            p42.Visible = false;
            p43.Visible = false;
            p44.Visible = false;
            p45.Visible = false;
            btn41p.ForeColor = Color.FromArgb(0, 174, 219);
            btn41.ForeColor = Color.FromArgb(128, 128, 128);
            btn42.ForeColor = Color.FromArgb(128, 128, 128);
            btn43.ForeColor = Color.FromArgb(128, 128, 128);
            btn44.ForeColor = Color.FromArgb(128, 128, 128);
            btn45.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind41p();
        }
        private void btn51_Click(object sender, EventArgs e)
        {
            p51.Visible = true;
            p52.Visible = false;
            p53.Visible = false;
            p54.Visible = false;
            p55.Visible = false;
            p51p.Visible = false;
            btn51.ForeColor = Color.FromArgb(0, 174, 219);
            btn52.ForeColor = Color.FromArgb(128, 128, 128);
            btn53.ForeColor = Color.FromArgb(128, 128, 128);
            btn54.ForeColor = Color.FromArgb(128, 128, 128);
            btn55.ForeColor = Color.FromArgb(128, 128, 128);
            btn51p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind51();
        }
        private void btn52_Click(object sender, EventArgs e)
        {
            p52.Visible = true;
            p51.Visible = false;
            p53.Visible = false;
            p54.Visible = false;
            p55.Visible = false;
            p51p.Visible = false;
            btn52.ForeColor = Color.FromArgb(0, 174, 219);
            btn51.ForeColor = Color.FromArgb(128, 128, 128);
            btn53.ForeColor = Color.FromArgb(128, 128, 128);
            btn54.ForeColor = Color.FromArgb(128, 128, 128);
            btn55.ForeColor = Color.FromArgb(128, 128, 128);
            btn51p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind52();
        }
        private void btn53_Click(object sender, EventArgs e)
        {
            p53.Visible = true;
            p51.Visible = false;
            p52.Visible = false;
            p54.Visible = false;
            p55.Visible = false;
            p51p.Visible = false;
            btn53.ForeColor = Color.FromArgb(0, 174, 219);
            btn51.ForeColor = Color.FromArgb(128, 128, 128);
            btn52.ForeColor = Color.FromArgb(128, 128, 128);
            btn54.ForeColor = Color.FromArgb(128, 128, 128);
            btn55.ForeColor = Color.FromArgb(128, 128, 128);
            btn51p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind53();
        }
        private void btn54_Click(object sender, EventArgs e)
        {
            p54.Visible = true;
            p51.Visible = false;
            p52.Visible = false;
            p53.Visible = false;
            p55.Visible = false;
            p51p.Visible = false;
            btn54.ForeColor = Color.FromArgb(0, 174, 219);
            btn51.ForeColor = Color.FromArgb(128, 128, 128);
            btn52.ForeColor = Color.FromArgb(128, 128, 128);
            btn53.ForeColor = Color.FromArgb(128, 128, 128);
            btn55.ForeColor = Color.FromArgb(128, 128, 128);
            btn51p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind54();
        }
        private void btn55_Click(object sender, EventArgs e)
        {
            p55.Visible = true;
            p51.Visible = false;
            p52.Visible = false;
            p53.Visible = false;
            p54.Visible = false;
            p51p.Visible = false;
            btn55.ForeColor = Color.FromArgb(0, 174, 219);
            btn51.ForeColor = Color.FromArgb(128, 128, 128);
            btn52.ForeColor = Color.FromArgb(128, 128, 128);
            btn53.ForeColor = Color.FromArgb(128, 128, 128);
            btn54.ForeColor = Color.FromArgb(128, 128, 128);
            btn51p.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind55();
        }
        private void btn51p_Click(object sender, EventArgs e)
        {
            p51p.Visible = true;
            p51.Visible = false;
            p52.Visible = false;
            p53.Visible = false;
            p54.Visible = false;
            p55.Visible = false;
            btn51p.ForeColor = Color.FromArgb(0, 174, 219);
            btn51.ForeColor = Color.FromArgb(128, 128, 128);
            btn52.ForeColor = Color.FromArgb(128, 128, 128);
            btn53.ForeColor = Color.FromArgb(128, 128, 128);
            btn54.ForeColor = Color.FromArgb(128, 128, 128);
            btn55.ForeColor = Color.FromArgb(128, 128, 128);
            schedulesClassBindingSource.MoveFirst();
            bind51p();
        }
        #endregion

        #region Refresh Button
        public void RefreshSchedule()
        {
            schedulesClassBindingSource.MoveFirst();
            if (metroTabControl1.SelectedTab == firstyear)
            {
                p11.Visible = false;
                p12.Visible = false;
                p13.Visible = false;
                p14.Visible = false;
                p15.Visible = false;
                p11p.Visible = false;
                btn11.ForeColor = Color.FromArgb(128, 128, 128);
                btn12.ForeColor = Color.FromArgb(128, 128, 128);
                btn13.ForeColor = Color.FromArgb(128, 128, 128);
                btn14.ForeColor = Color.FromArgb(128, 128, 128);
                btn15.ForeColor = Color.FromArgb(128, 128, 128);
                btn11p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'First Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }               
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                p21.Visible = false;
                p22.Visible = false;
                p23.Visible = false;
                p24.Visible = false;
                p25.Visible = false;
                p21p.Visible = false;
                btn21.ForeColor = Color.FromArgb(128, 128, 128);
                btn22.ForeColor = Color.FromArgb(128, 128, 128);
                btn23.ForeColor = Color.FromArgb(128, 128, 128);
                btn24.ForeColor = Color.FromArgb(128, 128, 128);
                btn25.ForeColor = Color.FromArgb(128, 128, 128);
                btn21p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Second Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                p31.Visible = false;
                p32.Visible = false;
                p33.Visible = false;
                p34.Visible = false;
                p35.Visible = false;
                p31p.Visible = false;
                btn31.ForeColor = Color.FromArgb(128, 128, 128);
                btn32.ForeColor = Color.FromArgb(128, 128, 128);
                btn33.ForeColor = Color.FromArgb(128, 128, 128);
                btn34.ForeColor = Color.FromArgb(128, 128, 128);
                btn35.ForeColor = Color.FromArgb(128, 128, 128);
                btn31p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Third Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                p41.Visible = false;
                p42.Visible = false;
                p43.Visible = false;
                p44.Visible = false;
                p45.Visible = false;
                p41p.Visible = false;
                btn41.ForeColor = Color.FromArgb(128, 128, 128);
                btn42.ForeColor = Color.FromArgb(128, 128, 128);
                btn43.ForeColor = Color.FromArgb(128, 128, 128);
                btn44.ForeColor = Color.FromArgb(128, 128, 128);
                btn45.ForeColor = Color.FromArgb(128, 128, 128);
                btn41p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Fourth Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                p51.Visible = false;
                p52.Visible = false;
                p53.Visible = false;
                p54.Visible = false;
                p55.Visible = false;
                p51p.Visible = false;
                btn51.ForeColor = Color.FromArgb(128, 128, 128);
                btn52.ForeColor = Color.FromArgb(128, 128, 128);
                btn53.ForeColor = Color.FromArgb(128, 128, 128);
                btn54.ForeColor = Color.FromArgb(128, 128, 128);
                btn55.ForeColor = Color.FromArgb(128, 128, 128);
                btn51p.ForeColor = Color.FromArgb(128, 128, 128);
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Fifth Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSchedule();
        }       
        #endregion
       
        #region Selectedindexchanged
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == firstyear)
            {
                p11.Visible = false;
                p12.Visible = false;
                p13.Visible = false;
                p14.Visible = false;
                p15.Visible = false;
                p11p.Visible = false;
                btn11.ForeColor = Color.FromArgb(128, 128, 128);
                btn12.ForeColor = Color.FromArgb(128, 128, 128);
                btn13.ForeColor = Color.FromArgb(128, 128, 128);
                btn14.ForeColor = Color.FromArgb(128, 128, 128);
                btn15.ForeColor = Color.FromArgb(128, 128, 128);
                btn11p.ForeColor = Color.FromArgb(128, 128, 128);
                schedulesClassBindingSource.MoveFirst();
                getsettings1();
                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'First Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == secondyear)
            {
                p21.Visible = false;
                p22.Visible = false;
                p23.Visible = false;
                p24.Visible = false;
                p25.Visible = false;
                p21p.Visible = false;
                btn21.ForeColor = Color.FromArgb(128, 128, 128);
                btn22.ForeColor = Color.FromArgb(128, 128, 128);
                btn23.ForeColor = Color.FromArgb(128, 128, 128);
                btn24.ForeColor = Color.FromArgb(128, 128, 128);
                btn25.ForeColor = Color.FromArgb(128, 128, 128);
                btn21p.ForeColor = Color.FromArgb(128, 128, 128);
                schedulesClassBindingSource.MoveFirst();
                getsettings2();
                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Second Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == thirdyear)
            {
                p31.Visible = false;
                p32.Visible = false;
                p33.Visible = false;
                p34.Visible = false;
                p35.Visible = false;
                p31p.Visible = false;
                btn31.ForeColor = Color.FromArgb(128, 128, 128);
                btn32.ForeColor = Color.FromArgb(128, 128, 128);
                btn33.ForeColor = Color.FromArgb(128, 128, 128);
                btn34.ForeColor = Color.FromArgb(128, 128, 128);
                btn35.ForeColor = Color.FromArgb(128, 128, 128);
                btn31p.ForeColor = Color.FromArgb(128, 128, 128);
                schedulesClassBindingSource.MoveFirst();
                getsettings3();
                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Third Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == fourthyear)
            {
                p41.Visible = false;
                p42.Visible = false;
                p43.Visible = false;
                p44.Visible = false;
                p45.Visible = false;
                p41p.Visible = false;
                btn41.ForeColor = Color.FromArgb(128, 128, 128);
                btn42.ForeColor = Color.FromArgb(128, 128, 128);
                btn43.ForeColor = Color.FromArgb(128, 128, 128);
                btn44.ForeColor = Color.FromArgb(128, 128, 128);
                btn45.ForeColor = Color.FromArgb(128, 128, 128);
                btn41p.ForeColor = Color.FromArgb(128, 128, 128);
                schedulesClassBindingSource.MoveFirst();
                getsettings4();
                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'Fourth Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
            else if (metroTabControl1.SelectedTab == fifthyear)
            {
                p51.Visible = false;
                p52.Visible = false;
                p53.Visible = false;
                p54.Visible = false;
                p55.Visible = false;
                p51p.Visible = false;
                btn51.ForeColor = Color.FromArgb(128, 128, 128);
                btn52.ForeColor = Color.FromArgb(128, 128, 128);
                btn53.ForeColor = Color.FromArgb(128, 128, 128);
                btn54.ForeColor = Color.FromArgb(128, 128, 128);
                btn55.ForeColor = Color.FromArgb(128, 128, 128);
                btn51p.ForeColor = Color.FromArgb(128, 128, 128);
                schedulesClassBindingSource.MoveFirst();
                getsettings5();
                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    { db.Open(); }
                    schedulesClassBindingSource.DataSource = db.Query<SchedulesClass>("Select * from SchedulesTable where Year_Level = 'FIfth Year'", commandType: CommandType.Text);
                    SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
                }
            }
        }
        #endregion
        
        void cancelshit()
        {
            SchedulesClass obj = schedulesClassBindingSource.Current as SchedulesClass;
            if (obj != null)
            {
                if (obj.Year_Level == "First Year")
                { mrb1.Checked = true; }
                else if (obj.Year_Level == "Second Year")
                { mrb2.Checked = true; }
                else if (obj.Year_Level == "Third Year")
                { mrb3.Checked = true; }
                else if (obj.Year_Level == "Fourth Year")
                { mrb4.Checked = true; }
                else if (obj.Year_Level == "Fifth Year")
                { mrb5.Checked = true; }
            }
        }                     
        private void txtSCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; }
        }          
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            EZE_ImportExcelFile ief = new EZE_ImportExcelFile();
            ief.ShowDialog();
            pg.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Plexiglass pg = new Plexiglass(this);
            if (metroGrid1.Rows.Count > 0 || metroGrid2.Rows.Count > 0 || metroGrid3.Rows.Count > 0 || metroGrid4.Rows.Count > 0 || metroGrid5.Rows.Count > 0)
            {
                if (messagebox.showdialog("Do you want to export this data to excel file?") == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbooks wb = xcelApp.Workbooks;
                    try
                    {
                        if (metroTabControl1.SelectedTab == firstyear || metroTabControl1.SelectedTab == firstyear && btn11.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && btn12.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == firstyear && btn13.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && btn14.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == firstyear && btn15.ForeColor == Color.FromArgb(0, 174, 219)
                        || metroTabControl1.SelectedTab == firstyear && btn11p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid1.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid2.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid2.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid1.Columns.Count; j++)
                                    {
                                        if (metroGrid1.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid1.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and insert N/A 
                                            Range xlRange1 = (Range)xcelApp.Cells[i + 2, j + 1];
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid1.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == secondyear || metroTabControl1.SelectedTab == secondyear && btn21.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && btn22.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == secondyear && btn23.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && btn24.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == secondyear && btn25.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == secondyear && btn21p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid2.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid2.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid2.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid2.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid2.Columns.Count; j++)
                                    {
                                        if (metroGrid2.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid2.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid2.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == thirdyear || metroTabControl1.SelectedTab == thirdyear && btn31.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && btn32.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == thirdyear && btn33.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && btn34.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == thirdyear && btn35.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == thirdyear && btn31p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid3.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid3.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid3.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid3.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid3.Columns.Count; j++)
                                    {
                                        if (metroGrid3.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid3.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid3.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fourthyear || metroTabControl1.SelectedTab == fourthyear && btn41.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && btn42.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fourthyear && btn43.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && btn44.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fourthyear && btn45.ForeColor == Color.FromArgb(0, 174, 219)
                           || metroTabControl1.SelectedTab == fourthyear && btn41p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid4.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid4.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid5.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid4.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid4.Columns.Count; j++)
                                    {
                                        if (metroGrid4.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid4.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid4.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                            else
                            {
                                messagebox.showdialog("No data available to allow export.");
                            }
                        }
                        else if (metroTabControl1.SelectedTab == fifthyear || metroTabControl1.SelectedTab == fifthyear && btn51.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && btn52.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fifthyear && btn53.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && btn54.ForeColor == Color.FromArgb(0, 174, 219) || metroTabControl1.SelectedTab == fifthyear && btn55.ForeColor == Color.FromArgb(0, 174, 219)
                          || metroTabControl1.SelectedTab == fifthyear && btn51p.ForeColor == Color.FromArgb(0, 174, 219))
                        {
                            if (metroGrid5.Rows.Count > 0)
                            {
                                wb.Add(Type.Missing);
                                for (int i = 1; i < metroGrid5.Columns.Count + 1; i++)
                                {
                                    xcelApp.Cells[1, i] = metroGrid5.Columns[i - 1].HeaderText;
                                    Range xlRange = (Range)xcelApp.Cells[i];
                                    xlRange.Font.Bold = -1;
                                    xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                }
                                for (int i = 0; i < metroGrid5.Rows.Count; i++)
                                {
                                    for (int j = 0; j < metroGrid5.Columns.Count; j++)
                                    {
                                        if (metroGrid5.Rows[i].Cells[j].Value == null)
                                        {
                                            metroGrid5.Rows[i].Cells[j].Value = ""; // Where the gridview is empty do a checking and Insert N/A 
                                        }
                                        Range xlRange = (Range)xcelApp.Cells[i + 2, j + 1];
                                        xlRange.NumberFormat = "@";
                                        xcelApp.Cells[i + 2, j + 1] = metroGrid5.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                xcelApp.Columns.AutoFit();
                                xcelApp.Visible = true;
                            }
                        }
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.FinalReleaseComObject(wb);
                        Marshal.FinalReleaseComObject(xcelApp);
                    }
                }
            }
            else
            {
                messagebox.showdialog("No data available to allow export.");
            }
            pg.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            panelClassSchedules.Visible = true;
        }
    }
}