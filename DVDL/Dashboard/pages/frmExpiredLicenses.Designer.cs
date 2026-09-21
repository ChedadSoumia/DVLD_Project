namespace DVDL.Dashboard.pages
{
    partial class frmExpiredLicenses
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
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.dgvExpiredLicensesList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredLicensesList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Location = new System.Drawing.Point(34, 35);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(126, 17);
            this.lblMainTitle.TabIndex = 2;
            this.lblMainTitle.Text = "Expired License List";
            // 
            // dgvExpiredLicensesList
            // 
            this.dgvExpiredLicensesList.AllowUserToAddRows = false;
            this.dgvExpiredLicensesList.AllowUserToDeleteRows = false;
            this.dgvExpiredLicensesList.AllowUserToOrderColumns = true;
            this.dgvExpiredLicensesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpiredLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiredLicensesList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvExpiredLicensesList.Location = new System.Drawing.Point(37, 76);
            this.dgvExpiredLicensesList.Name = "dgvExpiredLicensesList";
            this.dgvExpiredLicensesList.ReadOnly = true;
            this.dgvExpiredLicensesList.RowHeadersWidth = 51;
            this.dgvExpiredLicensesList.RowTemplate.Height = 26;
            this.dgvExpiredLicensesList.Size = new System.Drawing.Size(862, 344);
            this.dgvExpiredLicensesList.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reToolStripMenuItem,
            this.renewLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 52);
            // 
            // reToolStripMenuItem
            // 
            this.reToolStripMenuItem.Name = "reToolStripMenuItem";
            this.reToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.reToolStripMenuItem.Text = "Show Person Info";
            this.reToolStripMenuItem.Click += new System.EventHandler(this.reToolStripMenuItem_Click);
            // 
            // renewLicenseToolStripMenuItem
            // 
            this.renewLicenseToolStripMenuItem.Name = "renewLicenseToolStripMenuItem";
            this.renewLicenseToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.renewLicenseToolStripMenuItem.Text = "Renew License";
            this.renewLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewLicenseToolStripMenuItem_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(117, 435);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(0, 17);
            this.lblRecordsCount.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "#Records:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(911, 10);
            this.panel2.TabIndex = 25;
            // 
            // frmExpiredLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(911, 474);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvExpiredLicensesList);
            this.Controls.Add(this.lblMainTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExpiredLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expired Licenses";
            this.Load += new System.EventHandler(this.frmExpiredLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredLicensesList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.DataGridView dgvExpiredLicensesList;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewLicenseToolStripMenuItem;
    }
}