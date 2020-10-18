namespace KyeSwapperTemplate
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConvertB = new System.Windows.Forms.Button();
            this.RevertB = new System.Windows.Forms.Button();
            this.swaptoicon = new System.Windows.Forms.PictureBox();
            this.Swap = new System.ComponentModel.BackgroundWorker();
            this.Revert = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.ResetConfigB = new System.Windows.Forms.Button();
            this.SettingsB = new System.Windows.Forms.PictureBox();
            this.swapfromicon = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.swaptoicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swapfromicon)).BeginInit();
            this.SuspendLayout();
            // 
            // ConvertB
            // 
            this.ConvertB.BackColor = System.Drawing.Color.White;
            this.ConvertB.FlatAppearance.BorderSize = 0;
            this.ConvertB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertB.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ConvertB.Location = new System.Drawing.Point(218, 112);
            this.ConvertB.Name = "ConvertB";
            this.ConvertB.Size = new System.Drawing.Size(209, 39);
            this.ConvertB.TabIndex = 0;
            this.ConvertB.Text = "Convert";
            this.ConvertB.UseVisualStyleBackColor = false;
            this.ConvertB.Click += new System.EventHandler(this.button1_Click);
            // 
            // RevertB
            // 
            this.RevertB.BackColor = System.Drawing.Color.White;
            this.RevertB.FlatAppearance.BorderSize = 0;
            this.RevertB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RevertB.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.RevertB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RevertB.Location = new System.Drawing.Point(218, 157);
            this.RevertB.Name = "RevertB";
            this.RevertB.Size = new System.Drawing.Size(209, 39);
            this.RevertB.TabIndex = 1;
            this.RevertB.Text = "Revert";
            this.RevertB.UseVisualStyleBackColor = false;
            this.RevertB.Click += new System.EventHandler(this.button2_Click);
            // 
            // swaptoicon
            // 
            this.swaptoicon.ErrorImage = null;
            this.swaptoicon.InitialImage = null;
            this.swaptoicon.Location = new System.Drawing.Point(3, 2);
            this.swaptoicon.Name = "swaptoicon";
            this.swaptoicon.Size = new System.Drawing.Size(209, 194);
            this.swaptoicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swaptoicon.TabIndex = 2;
            this.swaptoicon.TabStop = false;
            // 
            // Swap
            // 
            this.Swap.WorkerSupportsCancellation = true;
            this.Swap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Swap_DoWork);
            // 
            // Revert
            // 
            this.Revert.WorkerSupportsCancellation = true;
            this.Revert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Revert_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(252, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ON/OFF";
            // 
            // ResetConfigB
            // 
            this.ResetConfigB.BackColor = System.Drawing.Color.White;
            this.ResetConfigB.FlatAppearance.BorderSize = 0;
            this.ResetConfigB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetConfigB.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetConfigB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResetConfigB.Location = new System.Drawing.Point(329, 69);
            this.ResetConfigB.Name = "ResetConfigB";
            this.ResetConfigB.Size = new System.Drawing.Size(98, 30);
            this.ResetConfigB.TabIndex = 5;
            this.ResetConfigB.Text = "Reset Config";
            this.ResetConfigB.UseVisualStyleBackColor = false;
            this.ResetConfigB.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // SettingsB
            // 
            this.SettingsB.ErrorImage = null;
            this.SettingsB.Image = ((System.Drawing.Image)(resources.GetObject("SettingsB.Image")));
            this.SettingsB.InitialImage = null;
            this.SettingsB.Location = new System.Drawing.Point(329, 2);
            this.SettingsB.Name = "SettingsB";
            this.SettingsB.Size = new System.Drawing.Size(98, 61);
            this.SettingsB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsB.TabIndex = 6;
            this.SettingsB.TabStop = false;
            this.SettingsB.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // swapfromicon
            // 
            this.swapfromicon.BackColor = System.Drawing.Color.Transparent;
            this.swapfromicon.ErrorImage = null;
            this.swapfromicon.InitialImage = null;
            this.swapfromicon.Location = new System.Drawing.Point(0, 135);
            this.swapfromicon.Name = "swapfromicon";
            this.swapfromicon.Size = new System.Drawing.Size(58, 61);
            this.swapfromicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swapfromicon.TabIndex = 9;
            this.swapfromicon.TabStop = false;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Black;
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.title.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(0, 202);
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.title.Size = new System.Drawing.Size(433, 123);
            this.title.TabIndex = 10;
            this.title.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(433, 325);
            this.Controls.Add(this.SettingsB);
            this.Controls.Add(this.title);
            this.Controls.Add(this.swapfromicon);
            this.Controls.Add(this.ResetConfigB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.swaptoicon);
            this.Controls.Add(this.RevertB);
            this.Controls.Add(this.ConvertB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SwapperName";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.swaptoicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swapfromicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertB;
        private System.Windows.Forms.Button RevertB;
        private System.Windows.Forms.PictureBox swaptoicon;
        private System.ComponentModel.BackgroundWorker Swap;
        private System.ComponentModel.BackgroundWorker Revert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResetConfigB;
        private System.Windows.Forms.PictureBox SettingsB;
        private System.Windows.Forms.PictureBox swapfromicon;
        private System.Windows.Forms.RichTextBox title;
    }
}

