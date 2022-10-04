namespace EZE
{
    partial class EZE_UsersFingerprintRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EZE_UsersFingerprintRegister));
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Prompt = new MetroFramework.Controls.MetroTextBox();
            this.StatusLine = new MetroFramework.Controls.MetroTextBox();
            this.StatusText = new MetroFramework.Controls.MetroTextBox();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.txtUname = new MetroFramework.Controls.MetroTextBox();
            this.txtUtype = new MetroFramework.Controls.MetroTextBox();
            this.txtFname = new MetroFramework.Controls.MetroTextBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLink3 = new MetroFramework.Controls.MetroLink();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new MetroFramework.Controls.MetroLink();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Highlight = true;
            this.btnSave.Location = new System.Drawing.Point(253, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(293, 23);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "S&ave Fingerprint";
            this.btnSave.UseMnemonic = false;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picture.Image = global::EZE.Properties.Resources.icons8_fingerprint_scan_filled_96px;
            this.Picture.Location = new System.Drawing.Point(55, 112);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(192, 208);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // Prompt
            // 
            // 
            // 
            // 
            this.Prompt.CustomButton.Image = null;
            this.Prompt.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.Prompt.CustomButton.Name = "";
            this.Prompt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Prompt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Prompt.CustomButton.TabIndex = 1;
            this.Prompt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Prompt.CustomButton.UseSelectable = true;
            this.Prompt.CustomButton.Visible = false;
            this.Prompt.Lines = new string[0];
            this.Prompt.Location = new System.Drawing.Point(253, 135);
            this.Prompt.MaxLength = 32767;
            this.Prompt.Name = "Prompt";
            this.Prompt.PasswordChar = '\0';
            this.Prompt.ReadOnly = true;
            this.Prompt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Prompt.SelectedText = "";
            this.Prompt.SelectionLength = 0;
            this.Prompt.SelectionStart = 0;
            this.Prompt.ShortcutsEnabled = true;
            this.Prompt.Size = new System.Drawing.Size(293, 23);
            this.Prompt.TabIndex = 1;
            this.Prompt.UseSelectable = true;
            this.Prompt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Prompt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // StatusLine
            // 
            // 
            // 
            // 
            this.StatusLine.CustomButton.Image = null;
            this.StatusLine.CustomButton.Location = new System.Drawing.Point(170, 1);
            this.StatusLine.CustomButton.Name = "";
            this.StatusLine.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.StatusLine.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.StatusLine.CustomButton.TabIndex = 1;
            this.StatusLine.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.StatusLine.CustomButton.UseSelectable = true;
            this.StatusLine.CustomButton.Visible = false;
            this.StatusLine.Lines = new string[0];
            this.StatusLine.Location = new System.Drawing.Point(55, 326);
            this.StatusLine.MaxLength = 32767;
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.PasswordChar = '\0';
            this.StatusLine.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.StatusLine.SelectedText = "";
            this.StatusLine.SelectionLength = 0;
            this.StatusLine.SelectionStart = 0;
            this.StatusLine.ShortcutsEnabled = true;
            this.StatusLine.Size = new System.Drawing.Size(192, 23);
            this.StatusLine.TabIndex = 1;
            this.StatusLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusLine.UseSelectable = true;
            this.StatusLine.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatusLine.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // StatusText
            // 
            // 
            // 
            // 
            this.StatusText.CustomButton.Image = null;
            this.StatusText.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.StatusText.CustomButton.Name = "";
            this.StatusText.CustomButton.Size = new System.Drawing.Size(139, 139);
            this.StatusText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.StatusText.CustomButton.TabIndex = 1;
            this.StatusText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.StatusText.CustomButton.UseSelectable = true;
            this.StatusText.CustomButton.Visible = false;
            this.StatusText.Lines = new string[0];
            this.StatusText.Location = new System.Drawing.Point(254, 179);
            this.StatusText.MaxLength = 32767;
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.PasswordChar = '\0';
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.SelectedText = "";
            this.StatusText.SelectionLength = 0;
            this.StatusText.SelectionStart = 0;
            this.StatusText.ShortcutsEnabled = true;
            this.StatusText.Size = new System.Drawing.Size(292, 141);
            this.StatusText.TabIndex = 1;
            this.StatusText.UseSelectable = true;
            this.StatusText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatusText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PromptLabel
            // 
            this.PromptLabel.BackColor = System.Drawing.Color.Transparent;
            this.PromptLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptLabel.Location = new System.Drawing.Point(251, 117);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(59, 20);
            this.PromptLabel.TabIndex = 1;
            this.PromptLabel.Text = "Prompt :";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(252, 161);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(79, 20);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Status :";
            // 
            // txtUname
            // 
            // 
            // 
            // 
            this.txtUname.CustomButton.Image = null;
            this.txtUname.CustomButton.Location = new System.Drawing.Point(168, 1);
            this.txtUname.CustomButton.Name = "";
            this.txtUname.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtUname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUname.CustomButton.TabIndex = 1;
            this.txtUname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUname.CustomButton.UseSelectable = true;
            this.txtUname.CustomButton.Visible = false;
            this.txtUname.Lines = new string[0];
            this.txtUname.Location = new System.Drawing.Point(606, 66);
            this.txtUname.MaxLength = 32767;
            this.txtUname.Name = "txtUname";
            this.txtUname.PasswordChar = '\0';
            this.txtUname.ReadOnly = true;
            this.txtUname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUname.SelectedText = "";
            this.txtUname.SelectionLength = 0;
            this.txtUname.SelectionStart = 0;
            this.txtUname.ShortcutsEnabled = true;
            this.txtUname.Size = new System.Drawing.Size(192, 25);
            this.txtUname.TabIndex = 37;
            this.txtUname.UseSelectable = true;
            this.txtUname.Visible = false;
            this.txtUname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUtype
            // 
            // 
            // 
            // 
            this.txtUtype.CustomButton.Image = null;
            this.txtUtype.CustomButton.Location = new System.Drawing.Point(168, 1);
            this.txtUtype.CustomButton.Name = "";
            this.txtUtype.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtUtype.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUtype.CustomButton.TabIndex = 1;
            this.txtUtype.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUtype.CustomButton.UseSelectable = true;
            this.txtUtype.CustomButton.Visible = false;
            this.txtUtype.Lines = new string[0];
            this.txtUtype.Location = new System.Drawing.Point(606, 97);
            this.txtUtype.MaxLength = 32767;
            this.txtUtype.Name = "txtUtype";
            this.txtUtype.PasswordChar = '\0';
            this.txtUtype.ReadOnly = true;
            this.txtUtype.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUtype.SelectedText = "";
            this.txtUtype.SelectionLength = 0;
            this.txtUtype.SelectionStart = 0;
            this.txtUtype.ShortcutsEnabled = true;
            this.txtUtype.Size = new System.Drawing.Size(192, 25);
            this.txtUtype.TabIndex = 37;
            this.txtUtype.UseSelectable = true;
            this.txtUtype.Visible = false;
            this.txtUtype.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUtype.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtFname
            // 
            // 
            // 
            // 
            this.txtFname.CustomButton.Image = null;
            this.txtFname.CustomButton.Location = new System.Drawing.Point(168, 1);
            this.txtFname.CustomButton.Name = "";
            this.txtFname.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtFname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFname.CustomButton.TabIndex = 1;
            this.txtFname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFname.CustomButton.UseSelectable = true;
            this.txtFname.CustomButton.Visible = false;
            this.txtFname.Lines = new string[0];
            this.txtFname.Location = new System.Drawing.Point(606, 35);
            this.txtFname.MaxLength = 32767;
            this.txtFname.Name = "txtFname";
            this.txtFname.PasswordChar = '\0';
            this.txtFname.ReadOnly = true;
            this.txtFname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFname.SelectedText = "";
            this.txtFname.SelectionLength = 0;
            this.txtFname.SelectionStart = 0;
            this.txtFname.ShortcutsEnabled = true;
            this.txtFname.Size = new System.Drawing.Size(192, 25);
            this.txtFname.TabIndex = 37;
            this.txtFname.UseSelectable = true;
            this.txtFname.Visible = false;
            this.txtFname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel3;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.metroLink3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnBack);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 60);
            this.panel3.TabIndex = 140;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 4);
            this.panel1.TabIndex = 138;
            // 
            // metroLink3
            // 
            this.metroLink3.BackColor = System.Drawing.Color.Transparent;
            this.metroLink3.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroLink3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroLink3.Image = ((System.Drawing.Image)(resources.GetObject("metroLink3.Image")));
            this.metroLink3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink3.ImageSize = 35;
            this.metroLink3.Location = new System.Drawing.Point(536, 11);
            this.metroLink3.Name = "metroLink3";
            this.metroLink3.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("metroLink3.NoFocusImage")));
            this.metroLink3.Size = new System.Drawing.Size(40, 40);
            this.metroLink3.TabIndex = 75;
            this.metroLink3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink3.UseCustomBackColor = true;
            this.metroLink3.UseCustomForeColor = true;
            this.metroLink3.UseMnemonic = false;
            this.metroLink3.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(295, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 40);
            this.label1.TabIndex = 60;
            this.label1.Text = "Enroll a Fingerprint";
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
            this.btnBack.Location = new System.Drawing.Point(30, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("btnBack.NoFocusImage")));
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnBack.TabIndex = 75;
            this.toolTip.SetToolTip(this.btnBack, "   Back   ");
            this.btnBack.UseCustomBackColor = true;
            this.btnBack.UseMnemonic = false;
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel5.Location = new System.Drawing.Point(596, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(4, 402);
            this.panel5.TabIndex = 141;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(4, 402);
            this.panel4.TabIndex = 142;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 4);
            this.panel2.TabIndex = 143;
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
            // EZE_UsersFingerprintRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1051, 520);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.txtUname);
            this.Controls.Add(this.txtUtype);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EZE_UsersFingerprintRegister";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginFingerprintRegister_FormClosed);
            this.Load += new System.EventHandler(this.LoginFingerprintRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Picture;
        private MetroFramework.Controls.MetroTextBox Prompt;
        private MetroFramework.Controls.MetroTextBox StatusLine;
        private MetroFramework.Controls.MetroTextBox StatusText;
        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.Label StatusLabel;
        private MetroFramework.Controls.MetroTextBox txtUname;
        private MetroFramework.Controls.MetroTextBox txtUtype;
        private MetroFramework.Controls.MetroTextBox txtFname;
        private MetroFramework.Controls.MetroButton btnSave;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLink metroLink3;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLink btnBack;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.ToolTip toolTip;
    }
}