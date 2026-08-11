namespace DVDL.Drivers
{
    partial class ctrlDriverLicenses
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCountLocalLicenses = new System.Windows.Forms.Label();
            this.dgvAllLocalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCountInternationalLicenses = new System.Windows.Forms.Label();
            this.dgvAllInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 332);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drivers Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCountLocalLicenses);
            this.tabPage1.Controls.Add(this.dgvAllLocalLicenses);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lbl3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCountLocalLicenses
            // 
            this.lblCountLocalLicenses.AutoSize = true;
            this.lblCountLocalLicenses.Location = new System.Drawing.Point(100, 249);
            this.lblCountLocalLicenses.Name = "lblCountLocalLicenses";
            this.lblCountLocalLicenses.Size = new System.Drawing.Size(0, 17);
            this.lblCountLocalLicenses.TabIndex = 9;
            // 
            // dgvAllLocalLicenses
            // 
            this.dgvAllLocalLicenses.AllowUserToAddRows = false;
            this.dgvAllLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvAllLocalLicenses.AllowUserToOrderColumns = true;
            this.dgvAllLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLocalLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllLocalLicenses.Location = new System.Drawing.Point(24, 41);
            this.dgvAllLocalLicenses.Name = "dgvAllLocalLicenses";
            this.dgvAllLocalLicenses.ReadOnly = true;
            this.dgvAllLocalLicenses.RowHeadersWidth = 51;
            this.dgvAllLocalLicenses.RowTemplate.Height = 26;
            this.dgvAllLocalLicenses.Size = new System.Drawing.Size(681, 203);
            this.dgvAllLocalLicenses.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 28);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "#Records:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(21, 12);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(150, 16);
            this.lbl3.TabIndex = 1;
            this.lbl3.Text = "Local Licenses History";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCountInternationalLicenses);
            this.tabPage2.Controls.Add(this.dgvAllInternationalLicenses);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "international";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCountInternationalLicenses
            // 
            this.lblCountInternationalLicenses.AutoSize = true;
            this.lblCountInternationalLicenses.Location = new System.Drawing.Point(106, 279);
            this.lblCountInternationalLicenses.Name = "lblCountInternationalLicenses";
            this.lblCountInternationalLicenses.Size = new System.Drawing.Size(0, 17);
            this.lblCountInternationalLicenses.TabIndex = 13;
            // 
            // dgvAllInternationalLicenses
            // 
            this.dgvAllInternationalLicenses.AllowUserToAddRows = false;
            this.dgvAllInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvAllInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvAllInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInternationalLicenses.Location = new System.Drawing.Point(21, 61);
            this.dgvAllInternationalLicenses.Name = "dgvAllInternationalLicenses";
            this.dgvAllInternationalLicenses.ReadOnly = true;
            this.dgvAllInternationalLicenses.RowHeadersWidth = 51;
            this.dgvAllInternationalLicenses.RowTemplate.Height = 26;
            this.dgvAllInternationalLicenses.Size = new System.Drawing.Size(684, 203);
            this.dgvAllInternationalLicenses.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "#Records:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "International Licenses History";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(766, 349);
            this.Load += new System.EventHandler(this.ctrlDriverLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvAllLocalLicenses;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblCountLocalLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountInternationalLicenses;
        private System.Windows.Forms.DataGridView dgvAllInternationalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
