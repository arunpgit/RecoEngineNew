namespace RecoEngine
{
    partial class frmUsers
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
            this.gbMain = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.txtFName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lblprjctDesc = new Telerik.WinControls.UI.RadLabel();
            this.lblPrjctname = new Telerik.WinControls.UI.RadLabel();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlUserType = new Telerik.WinControls.UI.RadDropDownList();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUserName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.chkIsActive = new Telerik.WinControls.UI.RadCheckBox();
            this.btnSaveContinuee = new Telerik.WinControls.UI.RadButton();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtCPassword = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbMain)).BeginInit();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblprjctDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrjctname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUserType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveContinuee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.txtCPassword);
            this.gbMain.Controls.Add(this.txtPassword);
            this.gbMain.Controls.Add(this.btnSaveContinuee);
            this.gbMain.Controls.Add(this.chkIsActive);
            this.gbMain.Controls.Add(this.radLabel5);
            this.gbMain.Controls.Add(this.radLabel4);
            this.gbMain.Controls.Add(this.radLabel3);
            this.gbMain.Controls.Add(this.txtUserName);
            this.gbMain.Controls.Add(this.txtEmail);
            this.gbMain.Controls.Add(this.radLabel2);
            this.gbMain.Controls.Add(this.ddlUserType);
            this.gbMain.Controls.Add(this.radLabel1);
            this.gbMain.Controls.Add(this.txtLastName);
            this.gbMain.Controls.Add(this.btnSave);
            this.gbMain.Controls.Add(this.btnClose);
            this.gbMain.Controls.Add(this.txtFName);
            this.gbMain.Controls.Add(this.lblprjctDesc);
            this.gbMain.Controls.Add(this.lblPrjctname);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(444, 250);
            this.gbMain.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(301, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(369, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 24);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.Transparent;
            this.txtFName.Location = new System.Drawing.Point(145, 9);
            this.txtFName.MaxLength = 50;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(285, 20);
            this.txtFName.TabIndex = 0;
            // 
            // lblprjctDesc
            // 
            this.lblprjctDesc.Location = new System.Drawing.Point(64, 37);
            this.lblprjctDesc.Name = "lblprjctDesc";
            this.lblprjctDesc.Size = new System.Drawing.Size(64, 18);
            this.lblprjctDesc.TabIndex = 8;
            this.lblprjctDesc.Text = "Last Name :";
            // 
            // lblPrjctname
            // 
            this.lblPrjctname.Location = new System.Drawing.Point(62, 10);
            this.lblPrjctname.Name = "lblPrjctname";
            this.lblPrjctname.Size = new System.Drawing.Size(66, 18);
            this.lblPrjctname.TabIndex = 7;
            this.lblPrjctname.Text = "First Name :";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.Location = new System.Drawing.Point(145, 36);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(285, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(67, 64);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 16;
            this.radLabel1.Text = "User Type :";
            // 
            // ddlUserType
            // 
            this.ddlUserType.BackColor = System.Drawing.Color.Transparent;
            this.ddlUserType.DropDownAnimationEnabled = true;
            this.ddlUserType.Location = new System.Drawing.Point(145, 63);
            this.ddlUserType.MaxDropDownItems = 0;
            this.ddlUserType.Name = "ddlUserType";
            this.ddlUserType.ShowImageInEditorArea = true;
            this.ddlUserType.Size = new System.Drawing.Size(285, 20);
            this.ddlUserType.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Location = new System.Drawing.Point(145, 90);
            this.txtEmail.MaxLength = 20;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(90, 91);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(38, 18);
            this.radLabel2.TabIndex = 18;
            this.radLabel2.Text = "Email :";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.Location = new System.Drawing.Point(145, 117);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(285, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(61, 118);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 18);
            this.radLabel3.TabIndex = 21;
            this.radLabel3.Text = "User Name :";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(69, 145);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(59, 18);
            this.radLabel4.TabIndex = 23;
            this.radLabel4.Text = "Password :";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(26, 172);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(102, 18);
            this.radLabel5.TabIndex = 25;
            this.radLabel5.Text = "Confirm Password :";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(145, 195);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(58, 18);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkIsActive.Visible = false;
            // 
            // btnSaveContinuee
            // 
            this.btnSaveContinuee.Location = new System.Drawing.Point(184, 218);
            this.btnSaveContinuee.Name = "btnSaveContinuee";
            this.btnSaveContinuee.Size = new System.Drawing.Size(111, 24);
            this.btnSaveContinuee.TabIndex = 8;
            this.btnSaveContinuee.Text = "Save && Continuee";
            this.btnSaveContinuee.Click += new System.EventHandler(this.btnSaveContinuee_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Location = new System.Drawing.Point(145, 143);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(285, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TabStop = false;
            // 
            // txtCPassword
            // 
            this.txtCPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtCPassword.Location = new System.Drawing.Point(145, 170);
            this.txtCPassword.MaxLength = 10;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.PasswordChar = '*';
            this.txtCPassword.Size = new System.Drawing.Size(285, 20);
            this.txtCPassword.TabIndex = 6;
            this.txtCPassword.TabStop = false;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 250);
            this.Controls.Add(this.gbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsers";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Users";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbMain)).EndInit();
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblprjctDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrjctname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUserType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveContinuee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel gbMain;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadTextBoxControl txtFName;
        private Telerik.WinControls.UI.RadLabel lblprjctDesc;
        private Telerik.WinControls.UI.RadLabel lblPrjctname;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl txtLastName;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBoxControl txtUserName;
        private Telerik.WinControls.UI.RadTextBoxControl txtEmail;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlUserType;
        private Telerik.WinControls.UI.RadCheckBox chkIsActive;
        private Telerik.WinControls.UI.RadButton btnSaveContinuee;
        private Telerik.WinControls.UI.RadTextBox txtCPassword;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
    }
}
