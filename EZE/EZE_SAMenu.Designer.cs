namespace EZE
{
    partial class EZE_SAMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EZE_SAMenu));
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.borrowAnItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnAnItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsertype = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.lblCamera = new System.Windows.Forms.Label();
            this.lblTransactionHistory = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblStudentDatabase = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblAddTransaction = new System.Windows.Forms.Label();
            this.mlCamera = new System.Windows.Forms.PictureBox();
            this.mlTransactionHistory = new System.Windows.Forms.PictureBox();
            this.mlInventory = new System.Windows.Forms.PictureBox();
            this.mlStudentDatabase = new System.Windows.Forms.PictureBox();
            this.mlSchedule = new System.Windows.Forms.PictureBox();
            this.mlAddTransaction = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnFAQ = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroLink3 = new MetroFramework.Controls.MetroLink();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnDummy = new System.Windows.Forms.Button();
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.calendarClock1 = new CalendarClock.CalendarClock();
            this.pnlPic = new Guna.UI2.WinForms.Guna2Panel();
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mlCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlTransactionHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlStudentDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlAddTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowAnItemToolStripMenuItem,
            this.returnAnItemToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(156, 48);
            // 
            // borrowAnItemToolStripMenuItem
            // 
            this.borrowAnItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("borrowAnItemToolStripMenuItem.Image")));
            this.borrowAnItemToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.borrowAnItemToolStripMenuItem.Name = "borrowAnItemToolStripMenuItem";
            this.borrowAnItemToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.borrowAnItemToolStripMenuItem.Text = "Borrow an item";
            this.borrowAnItemToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borrowAnItemToolStripMenuItem_MouseDown);
            // 
            // returnAnItemToolStripMenuItem
            // 
            this.returnAnItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("returnAnItemToolStripMenuItem.Image")));
            this.returnAnItemToolStripMenuItem.Name = "returnAnItemToolStripMenuItem";
            this.returnAnItemToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.returnAnItemToolStripMenuItem.Text = "Return an item";
            this.returnAnItemToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.returnAnItemToolStripMenuItem_MouseDown);
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(0, 253);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(250, 24);
            this.lblUsername.TabIndex = 48;
            this.lblUsername.Text = "Full Name";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsertype
            // 
            this.lblUsertype.BackColor = System.Drawing.Color.Transparent;
            this.lblUsertype.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsertype.ForeColor = System.Drawing.Color.White;
            this.lblUsertype.Location = new System.Drawing.Point(0, 281);
            this.lblUsertype.Name = "lblUsertype";
            this.lblUsertype.Size = new System.Drawing.Size(250, 18);
            this.lblUsertype.TabIndex = 49;
            this.lblUsertype.Text = "User Type";
            this.lblUsertype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(10, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 2);
            this.panel1.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 33);
            this.label1.TabIndex = 62;
            this.label1.Text = "Student Assistant Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort3
            // 
            this.serialPort3.PortName = "COM4";
            this.serialPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort3_DataReceived);
            // 
            // lblCamera
            // 
            this.lblCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(193)))), ((int)(((byte)(50)))));
            this.lblCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCamera.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCamera.ForeColor = System.Drawing.Color.White;
            this.lblCamera.Location = new System.Drawing.Point(126, 416);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(87, 19);
            this.lblCamera.TabIndex = 122;
            this.lblCamera.Text = "Camera";
            this.lblCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCamera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlCamera_MouseDown);
            // 
            // lblTransactionHistory
            // 
            this.lblTransactionHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(105)))), ((int)(((byte)(46)))));
            this.lblTransactionHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTransactionHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransactionHistory.ForeColor = System.Drawing.Color.White;
            this.lblTransactionHistory.Location = new System.Drawing.Point(260, 278);
            this.lblTransactionHistory.Name = "lblTransactionHistory";
            this.lblTransactionHistory.Size = new System.Drawing.Size(88, 19);
            this.lblTransactionHistory.TabIndex = 121;
            this.lblTransactionHistory.Text = "Records";
            this.lblTransactionHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTransactionHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlTransactionHistory_MouseDown);
            // 
            // lblInventory
            // 
            this.lblInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(95)))), ((int)(((byte)(42)))));
            this.lblInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInventory.ForeColor = System.Drawing.Color.White;
            this.lblInventory.Location = new System.Drawing.Point(129, 278);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(77, 19);
            this.lblInventory.TabIndex = 120;
            this.lblInventory.Text = "Inventory";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInventory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlInventory_MouseDown);
            // 
            // lblStudentDatabase
            // 
            this.lblStudentDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(156)))), ((int)(((byte)(252)))));
            this.lblStudentDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStudentDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudentDatabase.ForeColor = System.Drawing.Color.White;
            this.lblStudentDatabase.Location = new System.Drawing.Point(254, 140);
            this.lblStudentDatabase.Name = "lblStudentDatabase";
            this.lblStudentDatabase.Size = new System.Drawing.Size(99, 19);
            this.lblStudentDatabase.TabIndex = 119;
            this.lblStudentDatabase.Text = "Student Database";
            this.lblStudentDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStudentDatabase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlStudentDatabase_MouseDown);
            // 
            // lblSchedule
            // 
            this.lblSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(15)))), ((int)(((byte)(150)))));
            this.lblSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSchedule.ForeColor = System.Drawing.Color.White;
            this.lblSchedule.Location = new System.Drawing.Point(261, 416);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(87, 19);
            this.lblSchedule.TabIndex = 118;
            this.lblSchedule.Text = "Schedule";
            this.lblSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlSchedule_MouseDown);
            // 
            // lblAddTransaction
            // 
            this.lblAddTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.lblAddTransaction.ContextMenuStrip = this.metroContextMenu1;
            this.lblAddTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddTransaction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddTransaction.ForeColor = System.Drawing.Color.White;
            this.lblAddTransaction.Location = new System.Drawing.Point(122, 140);
            this.lblAddTransaction.Name = "lblAddTransaction";
            this.lblAddTransaction.Size = new System.Drawing.Size(92, 19);
            this.lblAddTransaction.TabIndex = 117;
            this.lblAddTransaction.Text = "Add Transaction";
            this.lblAddTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mlCamera
            // 
            this.mlCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(162)))), ((int)(((byte)(39)))));
            this.mlCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlCamera.Image = global::EZE.Properties.Resources.ImageCaptureedited;
            this.mlCamera.Location = new System.Drawing.Point(103, 311);
            this.mlCamera.Name = "mlCamera";
            this.mlCamera.Size = new System.Drawing.Size(130, 132);
            this.mlCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlCamera.TabIndex = 112;
            this.mlCamera.TabStop = false;
            this.mlCamera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlCamera_MouseDown);
            // 
            // mlTransactionHistory
            // 
            this.mlTransactionHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(86)))), ((int)(((byte)(36)))));
            this.mlTransactionHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlTransactionHistory.Image = global::EZE.Properties.Resources.ActivityMonitoredited;
            this.mlTransactionHistory.Location = new System.Drawing.Point(239, 173);
            this.mlTransactionHistory.Name = "mlTransactionHistory";
            this.mlTransactionHistory.Size = new System.Drawing.Size(130, 132);
            this.mlTransactionHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlTransactionHistory.TabIndex = 111;
            this.mlTransactionHistory.TabStop = false;
            this.mlTransactionHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlTransactionHistory_MouseDown);
            // 
            // mlInventory
            // 
            this.mlInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(79)))), ((int)(((byte)(34)))));
            this.mlInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlInventory.Image = global::EZE.Properties.Resources.iBooksedited;
            this.mlInventory.Location = new System.Drawing.Point(103, 173);
            this.mlInventory.Name = "mlInventory";
            this.mlInventory.Size = new System.Drawing.Size(130, 132);
            this.mlInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlInventory.TabIndex = 110;
            this.mlInventory.TabStop = false;
            this.mlInventory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlInventory_MouseDown);
            // 
            // mlStudentDatabase
            // 
            this.mlStudentDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(129)))), ((int)(((byte)(211)))));
            this.mlStudentDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlStudentDatabase.Image = global::EZE.Properties.Resources.TextEditedited;
            this.mlStudentDatabase.Location = new System.Drawing.Point(239, 35);
            this.mlStudentDatabase.Name = "mlStudentDatabase";
            this.mlStudentDatabase.Size = new System.Drawing.Size(130, 132);
            this.mlStudentDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlStudentDatabase.TabIndex = 109;
            this.mlStudentDatabase.TabStop = false;
            this.mlStudentDatabase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlStudentDatabase_MouseDown);
            // 
            // mlSchedule
            // 
            this.mlSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(2)))), ((int)(((byte)(117)))));
            this.mlSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlSchedule.Image = global::EZE.Properties.Resources.Remindersedited;
            this.mlSchedule.Location = new System.Drawing.Point(239, 311);
            this.mlSchedule.Name = "mlSchedule";
            this.mlSchedule.Size = new System.Drawing.Size(130, 132);
            this.mlSchedule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlSchedule.TabIndex = 116;
            this.mlSchedule.TabStop = false;
            this.mlSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlSchedule_MouseDown);
            // 
            // mlAddTransaction
            // 
            this.mlAddTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(125)))), ((int)(((byte)(119)))));
            this.mlAddTransaction.ContextMenuStrip = this.metroContextMenu1;
            this.mlAddTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mlAddTransaction.Image = global::EZE.Properties.Resources.iBookAuthoredited;
            this.mlAddTransaction.Location = new System.Drawing.Point(103, 35);
            this.mlAddTransaction.Name = "mlAddTransaction";
            this.mlAddTransaction.Size = new System.Drawing.Size(130, 132);
            this.mlAddTransaction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mlAddTransaction.TabIndex = 108;
            this.mlAddTransaction.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 132;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.label1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel3.Controls.Add(this.pnlPic);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.btnAbout);
            this.panel3.Controls.Add(this.btnFAQ);
            this.panel3.Controls.Add(this.lblUsername);
            this.panel3.Controls.Add(this.lblUsertype);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 540);
            this.panel3.TabIndex = 133;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(4, 496);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(246, 40);
            this.btnLogout.TabIndex = 87;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(4, 450);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(246, 40);
            this.btnAbout.TabIndex = 86;
            this.btnAbout.Text = "About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            // 
            // btnFAQ
            // 
            this.btnFAQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFAQ.FlatAppearance.BorderSize = 0;
            this.btnFAQ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFAQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFAQ.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnFAQ.ForeColor = System.Drawing.Color.White;
            this.btnFAQ.Image = ((System.Drawing.Image)(resources.GetObject("btnFAQ.Image")));
            this.btnFAQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFAQ.Location = new System.Drawing.Point(4, 404);
            this.btnFAQ.Name = "btnFAQ";
            this.btnFAQ.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFAQ.Size = new System.Drawing.Size(246, 40);
            this.btnFAQ.TabIndex = 85;
            this.btnFAQ.Text = "FAQs";
            this.btnFAQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFAQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFAQ.UseVisualStyleBackColor = true;
            this.btnFAQ.Click += new System.EventHandler(this.btnFAQ_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel2.Controls.Add(this.metroLink3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 60);
            this.panel2.TabIndex = 134;
            // 
            // metroLink3
            // 
            this.metroLink3.BackColor = System.Drawing.Color.Transparent;
            this.metroLink3.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroLink3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroLink3.Image = ((System.Drawing.Image)(resources.GetObject("metroLink3.Image")));
            this.metroLink3.ImageSize = 35;
            this.metroLink3.Location = new System.Drawing.Point(300, 11);
            this.metroLink3.Name = "metroLink3";
            this.metroLink3.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("metroLink3.NoFocusImage")));
            this.metroLink3.Size = new System.Drawing.Size(40, 40);
            this.metroLink3.TabIndex = 76;
            this.metroLink3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink3.UseCustomBackColor = true;
            this.metroLink3.UseCustomForeColor = true;
            this.metroLink3.UseMnemonic = false;
            this.metroLink3.UseSelectable = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.panel2;
            this.bunifuDragControl2.Vertical = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel7.Location = new System.Drawing.Point(248, 59);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(738, 4);
            this.panel7.TabIndex = 158;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel5.Location = new System.Drawing.Point(248, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(4, 540);
            this.panel5.TabIndex = 157;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(988, 4);
            this.panel8.TabIndex = 153;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel11.Location = new System.Drawing.Point(984, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(4, 540);
            this.panel11.TabIndex = 156;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel9.Location = new System.Drawing.Point(0, 536);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(988, 4);
            this.panel9.TabIndex = 155;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(4, 540);
            this.panel10.TabIndex = 154;
            // 
            // btnDummy
            // 
            this.btnDummy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDummy.FlatAppearance.BorderSize = 0;
            this.btnDummy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDummy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDummy.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDummy.ForeColor = System.Drawing.Color.White;
            this.btnDummy.Image = ((System.Drawing.Image)(resources.GetObject("btnDummy.Image")));
            this.btnDummy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDummy.Location = new System.Drawing.Point(361, 582);
            this.btnDummy.Name = "btnDummy";
            this.btnDummy.Size = new System.Drawing.Size(172, 40);
            this.btnDummy.TabIndex = 159;
            this.btnDummy.UseVisualStyleBackColor = false;
            this.btnDummy.Visible = false;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.metroLink3;
            this.bunifuDragControl3.Vertical = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.lblAddTransaction);
            this.panel6.Controls.Add(this.lblInventory);
            this.panel6.Controls.Add(this.lblCamera);
            this.panel6.Controls.Add(this.lblStudentDatabase);
            this.panel6.Controls.Add(this.lblSchedule);
            this.panel6.Controls.Add(this.lblTransactionHistory);
            this.panel6.Controls.Add(this.mlStudentDatabase);
            this.panel6.Controls.Add(this.mlAddTransaction);
            this.panel6.Controls.Add(this.mlInventory);
            this.panel6.Controls.Add(this.mlTransactionHistory);
            this.panel6.Controls.Add(this.mlSchedule);
            this.panel6.Controls.Add(this.mlCamera);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(250, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(738, 480);
            this.panel6.TabIndex = 160;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.calendarClock1);
            this.panel4.Location = new System.Drawing.Point(375, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 408);
            this.panel4.TabIndex = 137;
            // 
            // calendarClock1
            // 
            this.calendarClock1.BackColor = System.Drawing.Color.Transparent;
            this.calendarClock1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.calendarClock1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.calendarClock1.Location = new System.Drawing.Point(0, 76);
            this.calendarClock1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.calendarClock1.Name = "calendarClock1";
            this.calendarClock1.Size = new System.Drawing.Size(256, 303);
            this.calendarClock1.TabIndex = 54;
            // 
            // pnlPic
            // 
            this.pnlPic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(217)))), ((int)(((byte)(221)))));
            this.pnlPic.BorderRadius = 60;
            this.pnlPic.BorderThickness = 2;
            this.pnlPic.Controls.Add(this.pic);
            this.pnlPic.FillColor = System.Drawing.Color.Transparent;
            this.pnlPic.Location = new System.Drawing.Point(63, 119);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.ShadowDecoration.Parent = this.pnlPic;
            this.pnlPic.Size = new System.Drawing.Size(124, 124);
            this.pnlPic.TabIndex = 336;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic.BorderRadius = 60;
            this.pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic.FillColor = System.Drawing.Color.Transparent;
            this.pic.Location = new System.Drawing.Point(2, 2);
            this.pic.Name = "pic";
            this.pic.ShadowDecoration.Parent = this.pic;
            this.pic.Size = new System.Drawing.Size(120, 120);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 336;
            this.pic.TabStop = false;
            // 
            // EZE_SAMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 540);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnDummy);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EZE_SAMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EZE_SAMenu_Load);
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mlCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlTransactionHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlStudentDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlAddTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsertype;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem borrowAnItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnAnItemToolStripMenuItem;
        public System.IO.Ports.SerialPort serialPort3;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblTransactionHistory;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblStudentDatabase;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblAddTransaction;
        private System.Windows.Forms.PictureBox mlCamera;
        private System.Windows.Forms.PictureBox mlTransactionHistory;
        private System.Windows.Forms.PictureBox mlInventory;
        private System.Windows.Forms.PictureBox mlStudentDatabase;
        private System.Windows.Forms.PictureBox mlSchedule;
        private System.Windows.Forms.PictureBox mlAddTransaction;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFAQ;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAbout;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private MetroFramework.Controls.MetroLink metroLink3;
        private System.Windows.Forms.Button btnDummy;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private CalendarClock.CalendarClock calendarClock1;
        private Guna.UI2.WinForms.Guna2Panel pnlPic;
        private Guna.UI2.WinForms.Guna2PictureBox pic;
    }
}