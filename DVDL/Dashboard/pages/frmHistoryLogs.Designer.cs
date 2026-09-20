namespace DVDL.Dashboard.pages
{
    partial class frmHistoryLogs
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
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.dgvHistoryLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Location = new System.Drawing.Point(77, 54);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(88, 17);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "Login History";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(135, 710);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(0, 17);
            this.lblRecordsCount.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 710);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "#Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-294, -80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Manage People";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.BackgroundImage = global::DVDL.Properties.Resources.personadd1;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddPerson.Location = new System.Drawing.Point(1303, 9);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(37, 31);
            this.btnAddPerson.TabIndex = 20;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            // 
            // dgvHistoryLogs
            // 
            this.dgvHistoryLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistoryLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryLogs.Location = new System.Drawing.Point(59, 115);
            this.dgvHistoryLogs.Name = "dgvHistoryLogs";
            this.dgvHistoryLogs.RowHeadersWidth = 51;
            this.dgvHistoryLogs.RowTemplate.Height = 26;
            this.dgvHistoryLogs.Size = new System.Drawing.Size(1107, 570);
            this.dgvHistoryLogs.TabIndex = 19;
            // 
            // frmHistoryLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1285, 777);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.dgvHistoryLogs);
            this.Controls.Add(this.lblMainTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistoryLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistoryLogs";
            this.Load += new System.EventHandler(this.frmHistoryLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.DataGridView dgvHistoryLogs;
    }
}