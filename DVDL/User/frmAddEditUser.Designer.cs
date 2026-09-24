namespace DVDL.User
{
    partial class frmAddEditUser
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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVDL.People.Controls.ctrlPersonCardWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbReleaseDetainedLicense = new System.Windows.Forms.CheckBox();
            this.cbReplacementLicense = new System.Windows.Forms.CheckBox();
            this.cbDashboard = new System.Windows.Forms.CheckBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cbAddUser = new System.Windows.Forms.CheckBox();
            this.cbChangePassword = new System.Windows.Forms.CheckBox();
            this.cbInternationalAppliaction = new System.Windows.Forms.CheckBox();
            this.cbListOfLocalApplication = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtConfirmPasssword = new System.Windows.Forms.TextBox();
            this.chkbIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcUserInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonInfo);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(42, 94);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(885, 560);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(877, 531);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(734, 472);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 43);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next -->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.AddShowPerson = true;
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ctrlPersonCardWithFilter1.FilterEnable = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(26, 26);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(834, 422);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.tableLayoutPanel2);
            this.tpLoginInfo.Controls.Add(this.tableLayoutPanel1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 25);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(877, 531);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Permissions";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cbReleaseDetainedLicense, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cbReplacementLicense, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.cbDashboard, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbAll, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbAddUser, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbChangePassword, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbInternationalAppliaction, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.cbListOfLocalApplication, 0, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(551, 98);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 293);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cbReleaseDetainedLicense
            // 
            this.cbReleaseDetainedLicense.AutoSize = true;
            this.cbReleaseDetainedLicense.Location = new System.Drawing.Point(3, 255);
            this.cbReleaseDetainedLicense.Name = "cbReleaseDetainedLicense";
            this.cbReleaseDetainedLicense.Size = new System.Drawing.Size(250, 21);
            this.cbReleaseDetainedLicense.TabIndex = 14;
            this.cbReleaseDetainedLicense.Tag = "ReleaseDetainedLicense";
            this.cbReleaseDetainedLicense.Text = "Release Detained License Application";
            this.cbReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.cbReleaseDetainedLicense.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbReplacementLicense
            // 
            this.cbReplacementLicense.AutoSize = true;
            this.cbReplacementLicense.Location = new System.Drawing.Point(3, 219);
            this.cbReplacementLicense.Name = "cbReplacementLicense";
            this.cbReplacementLicense.Size = new System.Drawing.Size(272, 21);
            this.cbReplacementLicense.TabIndex = 13;
            this.cbReplacementLicense.Tag = "ReplacementLicense";
            this.cbReplacementLicense.Text = "List Of Replacement Damaged or Lost Driving license Application";
            this.cbReplacementLicense.UseVisualStyleBackColor = true;
            this.cbReplacementLicense.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbDashboard
            // 
            this.cbDashboard.AutoSize = true;
            this.cbDashboard.Location = new System.Drawing.Point(3, 111);
            this.cbDashboard.Name = "cbDashboard";
            this.cbDashboard.Size = new System.Drawing.Size(97, 21);
            this.cbDashboard.TabIndex = 12;
            this.cbDashboard.Tag = "Dashboard";
            this.cbDashboard.Text = "Dashboard";
            this.cbDashboard.UseVisualStyleBackColor = true;
            this.cbDashboard.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(3, 3);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(42, 21);
            this.cbAll.TabIndex = 9;
            this.cbAll.Tag = "All";
            this.cbAll.Text = "All";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // cbAddUser
            // 
            this.cbAddUser.AutoSize = true;
            this.cbAddUser.Location = new System.Drawing.Point(3, 39);
            this.cbAddUser.Name = "cbAddUser";
            this.cbAddUser.Size = new System.Drawing.Size(91, 21);
            this.cbAddUser.TabIndex = 9;
            this.cbAddUser.Tag = "AddUser";
            this.cbAddUser.Text = "Add Users";
            this.cbAddUser.UseVisualStyleBackColor = true;
            this.cbAddUser.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbChangePassword
            // 
            this.cbChangePassword.AutoSize = true;
            this.cbChangePassword.Location = new System.Drawing.Point(3, 75);
            this.cbChangePassword.Name = "cbChangePassword";
            this.cbChangePassword.Size = new System.Drawing.Size(139, 21);
            this.cbChangePassword.TabIndex = 10;
            this.cbChangePassword.Tag = "ChangePassword";
            this.cbChangePassword.Text = "Change Password";
            this.cbChangePassword.UseVisualStyleBackColor = true;
            this.cbChangePassword.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbInternationalAppliaction
            // 
            this.cbInternationalAppliaction.AutoSize = true;
            this.cbInternationalAppliaction.Location = new System.Drawing.Point(3, 183);
            this.cbInternationalAppliaction.Name = "cbInternationalAppliaction";
            this.cbInternationalAppliaction.Size = new System.Drawing.Size(272, 21);
            this.cbInternationalAppliaction.TabIndex = 11;
            this.cbInternationalAppliaction.Tag = "InternationalLicense";
            this.cbInternationalAppliaction.Text = "List Of International Driving license Application";
            this.cbInternationalAppliaction.UseVisualStyleBackColor = true;
            this.cbInternationalAppliaction.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // cbListOfLocalApplication
            // 
            this.cbListOfLocalApplication.AutoSize = true;
            this.cbListOfLocalApplication.Location = new System.Drawing.Point(3, 147);
            this.cbListOfLocalApplication.Name = "cbListOfLocalApplication";
            this.cbListOfLocalApplication.Size = new System.Drawing.Size(262, 21);
            this.cbListOfLocalApplication.TabIndex = 9;
            this.cbListOfLocalApplication.Tag = "LocalLicense";
            this.cbListOfLocalApplication.Text = "List Of Local Driving license Application";
            this.cbListOfLocalApplication.UseVisualStyleBackColor = true;
            this.cbListOfLocalApplication.CheckedChanged += new System.EventHandler(this.CheckedPermission);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.42505F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.57495F));
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUserID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmPasssword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkbIsActive, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 236);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.Location = new System.Drawing.Point(194, 101);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(216, 33);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserID
            // 
            this.lblUserID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(194, 15);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(39, 17);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "[???]";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Confirm Passsword";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.Location = new System.Drawing.Point(194, 54);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(216, 33);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // txtConfirmPasssword
            // 
            this.txtConfirmPasssword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConfirmPasssword.Location = new System.Drawing.Point(194, 148);
            this.txtConfirmPasssword.Multiline = true;
            this.txtConfirmPasssword.Name = "txtConfirmPasssword";
            this.txtConfirmPasssword.Size = new System.Drawing.Size(216, 33);
            this.txtConfirmPasssword.TabIndex = 3;
            this.txtConfirmPasssword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPasssword_Validating);
            // 
            // chkbIsActive
            // 
            this.chkbIsActive.AutoSize = true;
            this.chkbIsActive.Location = new System.Drawing.Point(194, 191);
            this.chkbIsActive.Name = "chkbIsActive";
            this.chkbIsActive.Size = new System.Drawing.Size(81, 21);
            this.chkbIsActive.TabIndex = 4;
            this.chkbIsActive.Text = "Is Active";
            this.chkbIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(801, 665);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 43);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(669, 665);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Location = new System.Drawing.Point(43, 36);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(93, 17);
            this.lblMainTitle.TabIndex = 6;
            this.lblMainTitle.Text = "Add New User";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 719);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 10);
            this.panel2.TabIndex = 16;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(966, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditUser";
            this.Activated += new System.EventHandler(this.frmAddEditUser_Activated);
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtConfirmPasssword;
        private System.Windows.Forms.CheckBox chkbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbChangePassword;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.CheckBox cbAddUser;
        private System.Windows.Forms.CheckBox cbListOfLocalApplication;
        private System.Windows.Forms.CheckBox cbDashboard;
        private System.Windows.Forms.CheckBox cbInternationalAppliaction;
        private System.Windows.Forms.CheckBox cbReleaseDetainedLicense;
        private System.Windows.Forms.CheckBox cbReplacementLicense;
    }
}