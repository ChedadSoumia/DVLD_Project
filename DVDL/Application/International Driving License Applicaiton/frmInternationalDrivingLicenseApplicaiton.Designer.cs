namespace DVDL.Application.International_Driving_License_Applicaiton
{
    partial class frmInternationalDrivingLicenseApplicaiton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInternationalDrivingLicenseApplicaiton));
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlInternationalDrivingLicenseApplicaiton1 = new DVDL.Application.International_Driving_License_Applicaiton.ctrlInternationalDrivingLicenseApplicaiton();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Location = new System.Drawing.Point(12, 34);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(201, 17);
            this.lblMainTitle.TabIndex = 36;
            this.lblMainTitle.Text = "Driver International License Info";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(587, 422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 50);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlInternationalDrivingLicenseApplicaiton1
            // 
            this.ctrlInternationalDrivingLicenseApplicaiton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ctrlInternationalDrivingLicenseApplicaiton1.Location = new System.Drawing.Point(12, 85);
            this.ctrlInternationalDrivingLicenseApplicaiton1.Name = "ctrlInternationalDrivingLicenseApplicaiton1";
            this.ctrlInternationalDrivingLicenseApplicaiton1.Size = new System.Drawing.Size(725, 327);
            this.ctrlInternationalDrivingLicenseApplicaiton1.TabIndex = 40;
            // 
            // frmInternationalDrivingLicenseApplicaiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(747, 484);
            this.Controls.Add(this.ctrlInternationalDrivingLicenseApplicaiton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMainTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInternationalDrivingLicenseApplicaiton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International Driving License Application";
            this.Load += new System.EventHandler(this.frmInternationalDrivingLicenseApplicaiton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Button btnClose;
        private ctrlInternationalDrivingLicenseApplicaiton ctrlInternationalDrivingLicenseApplicaiton1;
    }
}