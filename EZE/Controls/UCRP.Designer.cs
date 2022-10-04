namespace EZE
{
    partial class UCRP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRP));
            this.pnlRP = new System.Windows.Forms.Panel();
            this.pbEyeLock = new System.Windows.Forms.PictureBox();
            this.txtResetPword = new MetroFramework.Controls.MetroTextBox();
            this.txtResetPwordVerify = new MetroFramework.Controls.MetroTextBox();
            this.btnReset = new MetroFramework.Controls.MetroButton();
            this.link1 = new MetroFramework.Controls.MetroLink();
            this.link2 = new MetroFramework.Controls.MetroLink();
            this.timerforlabel = new System.Windows.Forms.Timer(this.components);
            this.pnlRP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEyeLock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRP
            // 
            this.pnlRP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlRP.BackColor = System.Drawing.Color.White;
            this.pnlRP.Controls.Add(this.pbEyeLock);
            this.pnlRP.Controls.Add(this.txtResetPword);
            this.pnlRP.Controls.Add(this.txtResetPwordVerify);
            this.pnlRP.Controls.Add(this.btnReset);
            this.pnlRP.Controls.Add(this.link1);
            this.pnlRP.Controls.Add(this.link2);
            this.pnlRP.Location = new System.Drawing.Point(40, 35);
            this.pnlRP.Name = "pnlRP";
            this.pnlRP.Size = new System.Drawing.Size(258, 190);
            this.pnlRP.TabIndex = 0;
            // 
            // pbEyeLock
            // 
            this.pbEyeLock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbEyeLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEyeLock.Image = global::EZE.Properties.Resources.icons8_hide;
            this.pbEyeLock.Location = new System.Drawing.Point(220, 103);
            this.pbEyeLock.Name = "pbEyeLock";
            this.pbEyeLock.Size = new System.Drawing.Size(20, 20);
            this.pbEyeLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEyeLock.TabIndex = 11;
            this.pbEyeLock.TabStop = false;
            this.pbEyeLock.Click += new System.EventHandler(this.pbEyeLock_Click);
            // 
            // txtResetPword
            // 
            this.txtResetPword.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtResetPword.CustomButton.Image = null;
            this.txtResetPword.CustomButton.Location = new System.Drawing.Point(204, 2);
            this.txtResetPword.CustomButton.Name = "";
            this.txtResetPword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtResetPword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResetPword.CustomButton.TabIndex = 1;
            this.txtResetPword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResetPword.CustomButton.UseSelectable = true;
            this.txtResetPword.CustomButton.Visible = false;
            this.txtResetPword.DisplayIcon = true;
            this.txtResetPword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtResetPword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txtResetPword.IconRight = true;
            this.txtResetPword.Lines = new string[0];
            this.txtResetPword.Location = new System.Drawing.Point(15, 51);
            this.txtResetPword.MaxLength = 32767;
            this.txtResetPword.Multiline = true;
            this.txtResetPword.Name = "txtResetPword";
            this.txtResetPword.PasswordChar = '\0';
            this.txtResetPword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResetPword.SelectedText = "";
            this.txtResetPword.SelectionLength = 0;
            this.txtResetPword.SelectionStart = 0;
            this.txtResetPword.ShortcutsEnabled = true;
            this.txtResetPword.Size = new System.Drawing.Size(228, 26);
            this.txtResetPword.Style = MetroFramework.MetroColorStyle.Orange;
            this.txtResetPword.TabIndex = 0;
            this.txtResetPword.UseCustomBackColor = true;
            this.txtResetPword.UseCustomForeColor = true;
            this.txtResetPword.UseSelectable = true;
            this.txtResetPword.WaterMark = "New Password";
            this.txtResetPword.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtResetPword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            // 
            // txtResetPwordVerify
            // 
            this.txtResetPwordVerify.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtResetPwordVerify.CustomButton.Image = null;
            this.txtResetPwordVerify.CustomButton.Location = new System.Drawing.Point(204, 2);
            this.txtResetPwordVerify.CustomButton.Name = "";
            this.txtResetPwordVerify.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtResetPwordVerify.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResetPwordVerify.CustomButton.TabIndex = 1;
            this.txtResetPwordVerify.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResetPwordVerify.CustomButton.UseSelectable = true;
            this.txtResetPwordVerify.CustomButton.Visible = false;
            this.txtResetPwordVerify.DisplayIcon = true;
            this.txtResetPwordVerify.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtResetPwordVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txtResetPwordVerify.IconRight = true;
            this.txtResetPwordVerify.Lines = new string[0];
            this.txtResetPwordVerify.Location = new System.Drawing.Point(15, 100);
            this.txtResetPwordVerify.MaxLength = 32767;
            this.txtResetPwordVerify.Multiline = true;
            this.txtResetPwordVerify.Name = "txtResetPwordVerify";
            this.txtResetPwordVerify.PasswordChar = '\0';
            this.txtResetPwordVerify.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResetPwordVerify.SelectedText = "";
            this.txtResetPwordVerify.SelectionLength = 0;
            this.txtResetPwordVerify.SelectionStart = 0;
            this.txtResetPwordVerify.ShortcutsEnabled = true;
            this.txtResetPwordVerify.Size = new System.Drawing.Size(228, 26);
            this.txtResetPwordVerify.Style = MetroFramework.MetroColorStyle.Orange;
            this.txtResetPwordVerify.TabIndex = 1;
            this.txtResetPwordVerify.UseCustomBackColor = true;
            this.txtResetPwordVerify.UseCustomForeColor = true;
            this.txtResetPwordVerify.UseSelectable = true;
            this.txtResetPwordVerify.WaterMark = "Confirm Password";
            this.txtResetPwordVerify.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtResetPwordVerify.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnReset.Location = new System.Drawing.Point(133, 149);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 26);
            this.btnReset.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseCustomBackColor = true;
            this.btnReset.UseCustomForeColor = true;
            this.btnReset.UseSelectable = true;
            this.btnReset.UseStyleColors = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // link1
            // 
            this.link1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.link1.BackColor = System.Drawing.Color.Transparent;
            this.link1.ForeColor = System.Drawing.Color.Red;
            this.link1.Image = ((System.Drawing.Image)(resources.GetObject("link1.Image")));
            this.link1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.link1.ImageSize = 20;
            this.link1.Location = new System.Drawing.Point(25, 13);
            this.link1.Name = "link1";
            this.link1.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("link1.NoFocusImage")));
            this.link1.Size = new System.Drawing.Size(193, 32);
            this.link1.TabIndex = 12;
            this.link1.Text = "Please create a new password";
            this.link1.UseCustomBackColor = true;
            this.link1.UseCustomForeColor = true;
            this.link1.UseSelectable = true;
            this.link1.Visible = false;
            // 
            // link2
            // 
            this.link2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.link2.BackColor = System.Drawing.Color.Transparent;
            this.link2.ForeColor = System.Drawing.Color.Red;
            this.link2.Image = ((System.Drawing.Image)(resources.GetObject("link2.Image")));
            this.link2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.link2.ImageSize = 20;
            this.link2.Location = new System.Drawing.Point(28, 13);
            this.link2.Name = "link2";
            this.link2.NoFocusImage = ((System.Drawing.Image)(resources.GetObject("link2.NoFocusImage")));
            this.link2.Size = new System.Drawing.Size(186, 32);
            this.link2.TabIndex = 12;
            this.link2.Text = "New password don\'t match";
            this.link2.UseCustomBackColor = true;
            this.link2.UseCustomForeColor = true;
            this.link2.UseSelectable = true;
            this.link2.Visible = false;
            // 
            // timerforlabel
            // 
            this.timerforlabel.Interval = 2000;
            this.timerforlabel.Tick += new System.EventHandler(this.timerforlabel_Tick);
            // 
            // UCRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlRP);
            this.Name = "UCRP";
            this.Size = new System.Drawing.Size(336, 279);
            this.Load += new System.EventHandler(this.UCRP_Load);
            this.pnlRP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEyeLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlRP;
        private System.Windows.Forms.PictureBox pbEyeLock;
        private MetroFramework.Controls.MetroTextBox txtResetPword;
        private MetroFramework.Controls.MetroTextBox txtResetPwordVerify;
        private MetroFramework.Controls.MetroButton btnReset;
        private MetroFramework.Controls.MetroLink link1;
        private System.Windows.Forms.Timer timerforlabel;
        private MetroFramework.Controls.MetroLink link2;
    }
}
