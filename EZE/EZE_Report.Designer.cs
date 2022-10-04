namespace EZE
{
    partial class EZE_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EZE_Report));
            this.GetReturnFinalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataSet = new EZE.ReportDataSet();
            this.dtFrom = new MetroFramework.Controls.MetroDateTime();
            this.dtTo = new MetroFramework.Controls.MetroDateTime();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetReturnFinalTableAdapter = new EZE.ReportDataSetTableAdapters.GetReturnFinalTableAdapter();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.metroLink3 = new MetroFramework.Controls.MetroLink();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new MetroFramework.Controls.MetroLink();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnOptions = new EZE.MyButton();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.panelReportGenerator = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFrom = new EZE.MyButton();
            this.btnTo = new EZE.MyButton();
            this.btnLoad = new EZE.MyButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDummy = new EZE.MyButton();
            ((System.ComponentModel.ISupportInitialize)(this.GetReturnFinalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelReportGenerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetReturnFinalBindingSource
            // 
            this.GetReturnFinalBindingSource.DataMember = "GetReturnFinal";
            this.GetReturnFinalBindingSource.DataSource = this.ReportDataSet;
            // 
            // ReportDataSet
            // 
            this.ReportDataSet.DataSetName = "ReportDataSet";
            this.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtFrom
            // 
            this.dtFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFrom.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtFrom.Location = new System.Drawing.Point(62, 382);
            this.dtFrom.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtFrom.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(193, 25);
            this.dtFrom.TabIndex = 0;
            this.dtFrom.TabStop = false;
            this.dtFrom.Visible = false;
            // 
            // dtTo
            // 
            this.dtTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtTo.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtTo.Location = new System.Drawing.Point(62, 422);
            this.dtTo.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtTo.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(193, 25);
            this.dtTo.TabIndex = 0;
            this.dtTo.TabStop = false;
            this.dtTo.Visible = false;
            // 
            // reportViewer
            // 
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            reportDataSource1.Name = "FinalReportDataSet";
            reportDataSource1.Value = this.GetReturnFinalBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "EZE.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(60, 60);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.Size = new System.Drawing.Size(924, 476);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.TabStop = false;
            // 
            // GetReturnFinalTableAdapter
            // 
            this.GetReturnFinalTableAdapter.ClearBeforeFill = true;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel13.Controls.Add(this.panel10);
            this.panel13.Controls.Add(this.metroLink3);
            this.panel13.Controls.Add(this.label1);
            this.panel13.Controls.Add(this.btnBack);
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(988, 60);
            this.panel13.TabIndex = 147;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(988, 4);
            this.panel10.TabIndex = 139;
            // 
            // metroLink3
            // 
            this.metroLink3.BackColor = System.Drawing.Color.Transparent;
            this.metroLink3.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroLink3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroLink3.Image = ((System.Drawing.Image)(resources.GetObject("metroLink3.Image")));
            this.metroLink3.ImageSize = 40;
            this.metroLink3.Location = new System.Drawing.Point(924, 11);
            this.metroLink3.Name = "metroLink3";
            this.metroLink3.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("metroLink3.NoFocusImage")));
            this.metroLink3.Size = new System.Drawing.Size(40, 40);
            this.metroLink3.TabIndex = 75;
            this.metroLink3.TabStop = false;
            this.metroLink3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink3.UseCustomBackColor = true;
            this.metroLink3.UseCustomForeColor = true;
            this.metroLink3.UseMnemonic = false;
            this.metroLink3.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(681, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 40);
            this.label1.TabIndex = 60;
            this.label1.Text = "Report Generator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.btnBack.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageSize = 30;
            this.btnBack.Location = new System.Drawing.Point(17, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("btnBack.NoFocusImage")));
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnBack.TabIndex = 75;
            this.btnBack.TabStop = false;
            this.toolTip.SetToolTip(this.btnBack, "   Back   ");
            this.btnBack.UseCustomBackColor = true;
            this.btnBack.UseMnemonic = false;
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel11.Location = new System.Drawing.Point(984, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(4, 540);
            this.panel11.TabIndex = 151;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel9.Location = new System.Drawing.Point(0, 536);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(988, 4);
            this.panel9.TabIndex = 149;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(4, 540);
            this.panel12.TabIndex = 150;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel5.Controls.Add(this.btnOptions);
            this.panel5.Controls.Add(this.metroLink1);
            this.panel5.Controls.Add(this.panelReportGenerator);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(60, 480);
            this.panel5.TabIndex = 148;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.Location = new System.Drawing.Point(4, 436);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(56, 40);
            this.btnOptions.TabIndex = 164;
            this.btnOptions.TabStop = false;
            this.toolTip.SetToolTip(this.btnOptions, "   Options   ");
            this.btnOptions.UseMnemonic = false;
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // metroLink1
            // 
            this.metroLink1.BackColor = System.Drawing.Color.Transparent;
            this.metroLink1.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroLink1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroLink1.Image = ((System.Drawing.Image)(resources.GetObject("metroLink1.Image")));
            this.metroLink1.ImageSize = 44;
            this.metroLink1.Location = new System.Drawing.Point(4, 4);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("metroLink1.NoFocusImage")));
            this.metroLink1.Size = new System.Drawing.Size(56, 56);
            this.metroLink1.TabIndex = 154;
            this.metroLink1.TabStop = false;
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink1.UseCustomBackColor = true;
            this.metroLink1.UseCustomForeColor = true;
            this.metroLink1.UseMnemonic = false;
            this.metroLink1.UseSelectable = true;
            // 
            // panelReportGenerator
            // 
            this.panelReportGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelReportGenerator.Controls.Add(this.panel3);
            this.panelReportGenerator.Controls.Add(this.btnFrom);
            this.panelReportGenerator.Controls.Add(this.btnTo);
            this.panelReportGenerator.Controls.Add(this.btnLoad);
            this.panelReportGenerator.Location = new System.Drawing.Point(4, 136);
            this.panelReportGenerator.Name = "panelReportGenerator";
            this.panelReportGenerator.Size = new System.Drawing.Size(56, 300);
            this.panelReportGenerator.TabIndex = 163;
            this.panelReportGenerator.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 299);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(56, 1);
            this.panel3.TabIndex = 139;
            // 
            // btnFrom
            // 
            this.btnFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrom.FlatAppearance.BorderSize = 0;
            this.btnFrom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrom.ForeColor = System.Drawing.Color.White;
            this.btnFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnFrom.Image")));
            this.btnFrom.Location = new System.Drawing.Point(0, 179);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(56, 40);
            this.btnFrom.TabIndex = 165;
            this.btnFrom.TabStop = false;
            this.toolTip.SetToolTip(this.btnFrom, "   Choose Date (From)   ");
            this.btnFrom.UseMnemonic = false;
            this.btnFrom.UseVisualStyleBackColor = false;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnTo
            // 
            this.btnTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTo.FlatAppearance.BorderSize = 0;
            this.btnTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTo.ForeColor = System.Drawing.Color.White;
            this.btnTo.Image = ((System.Drawing.Image)(resources.GetObject("btnTo.Image")));
            this.btnTo.Location = new System.Drawing.Point(0, 219);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(56, 40);
            this.btnTo.TabIndex = 164;
            this.btnTo.TabStop = false;
            this.toolTip.SetToolTip(this.btnTo, "   Choose Date (Up To)     ");
            this.btnTo.UseMnemonic = false;
            this.btnTo.UseVisualStyleBackColor = false;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(0, 259);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(56, 40);
            this.btnLoad.TabIndex = 169;
            this.btnLoad.TabStop = false;
            this.toolTip.SetToolTip(this.btnLoad, "   Load Data   ");
            this.btnLoad.UseMnemonic = false;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(12, 64);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(40, 2);
            this.panel6.TabIndex = 153;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel13;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.label1;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.metroLink3;
            this.bunifuDragControl3.Vertical = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 3000;
            this.toolTip.BackColor = System.Drawing.Color.Gainsboro;
            this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 400;
            this.toolTip.ShowAlways = true;
            // 
            // btnDummy
            // 
            this.btnDummy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnDummy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDummy.FlatAppearance.BorderSize = 0;
            this.btnDummy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDummy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDummy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDummy.ForeColor = System.Drawing.Color.White;
            this.btnDummy.Location = new System.Drawing.Point(12, 652);
            this.btnDummy.Name = "btnDummy";
            this.btnDummy.Size = new System.Drawing.Size(88, 30);
            this.btnDummy.TabIndex = 165;
            this.btnDummy.TabStop = false;
            this.btnDummy.Text = "btnDummy";
            this.toolTip.SetToolTip(this.btnDummy, "   Options   ");
            this.btnDummy.UseMnemonic = false;
            this.btnDummy.UseVisualStyleBackColor = false;
            this.btnDummy.Visible = false;
            // 
            // EZE_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1085, 601);
            this.ControlBox = false;
            this.Controls.Add(this.btnDummy);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.reportViewer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EZE_Report";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EZE_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetReturnFinalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panelReportGenerator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtFrom;
        private MetroFramework.Controls.MetroDateTime dtTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource GetReturnFinalBindingSource;
        private ReportDataSet ReportDataSet;
        private ReportDataSetTableAdapters.GetReturnFinalTableAdapter GetReturnFinalTableAdapter;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel10;
        private MetroFramework.Controls.MetroLink metroLink3;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLink btnBack;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.ToolTip toolTip;
        private MetroFramework.Controls.MetroLink metroLink1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelReportGenerator;
        private System.Windows.Forms.Panel panel3;
        private MyButton btnFrom;
        private MyButton btnTo;
        private MyButton btnLoad;
        private MyButton btnOptions;
        private MyButton btnDummy;
    }
}