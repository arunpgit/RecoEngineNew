namespace RecoEngine
{
    partial class frmProject
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
            this.pnTop = new Telerik.WinControls.UI.RadPanel();
            this.btnOpen = new Telerik.WinControls.UI.RadButton();
            this.btnNew = new Telerik.WinControls.UI.RadButton();
            this.pnNewprjct = new Telerik.WinControls.UI.RadPanel();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnSaveprjct = new Telerik.WinControls.UI.RadButton();
            this.txtprjctDesc = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtprjctName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.lblprjctDesc = new Telerik.WinControls.UI.RadLabel();
            this.lblPrjctname = new Telerik.WinControls.UI.RadLabel();
            this.pnGrid = new Telerik.WinControls.UI.RadPanel();
            this.grdProject = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNewprjct)).BeginInit();
            this.pnNewprjct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveprjct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprjctDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprjctName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblprjctDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrjctname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGrid)).BeginInit();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProject.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btnOpen);
            this.pnTop.Controls.Add(this.btnNew);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(443, 36);
            this.pnTop.TabIndex = 6;
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(12, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(62, 24);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Choose";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(369, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(62, 24);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnNewprjct
            // 
            this.pnNewprjct.Controls.Add(this.btnDelete);
            this.pnNewprjct.Controls.Add(this.btnSaveprjct);
            this.pnNewprjct.Controls.Add(this.txtprjctDesc);
            this.pnNewprjct.Controls.Add(this.txtprjctName);
            this.pnNewprjct.Controls.Add(this.lblprjctDesc);
            this.pnNewprjct.Controls.Add(this.lblPrjctname);
            this.pnNewprjct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnNewprjct.Location = new System.Drawing.Point(0, 252);
            this.pnNewprjct.Name = "pnNewprjct";
            this.pnNewprjct.Size = new System.Drawing.Size(443, 141);
            this.pnNewprjct.TabIndex = 7;
            this.pnNewprjct.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(300, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 24);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveprjct
            // 
            this.btnSaveprjct.Location = new System.Drawing.Point(368, 106);
            this.btnSaveprjct.Name = "btnSaveprjct";
            this.btnSaveprjct.Size = new System.Drawing.Size(62, 24);
            this.btnSaveprjct.TabIndex = 13;
            this.btnSaveprjct.Text = "Update";
            this.btnSaveprjct.Click += new System.EventHandler(this.btnSaveprjct_Click);
            // 
            // txtprjctDesc
            // 
            this.txtprjctDesc.AcceptsReturn = true;
            this.txtprjctDesc.Location = new System.Drawing.Point(145, 37);
            this.txtprjctDesc.MaxLength = 100;
            this.txtprjctDesc.Multiline = true;
            this.txtprjctDesc.Name = "txtprjctDesc";
            this.txtprjctDesc.Size = new System.Drawing.Size(285, 63);
            this.txtprjctDesc.TabIndex = 11;
            // 
            // txtprjctName
            // 
            this.txtprjctName.Location = new System.Drawing.Point(145, 12);
            this.txtprjctName.MaxLength = 50;
            this.txtprjctName.Name = "txtprjctName";
            this.txtprjctName.Size = new System.Drawing.Size(285, 20);
            this.txtprjctName.TabIndex = 10;
            // 
            // lblprjctDesc
            // 
            this.lblprjctDesc.Location = new System.Drawing.Point(33, 37);
            this.lblprjctDesc.Name = "lblprjctDesc";
            this.lblprjctDesc.Size = new System.Drawing.Size(106, 18);
            this.lblprjctDesc.TabIndex = 8;
            this.lblprjctDesc.Text = "Project Description :";
            // 
            // lblPrjctname
            // 
            this.lblPrjctname.Location = new System.Drawing.Point(33, 10);
            this.lblPrjctname.Name = "lblPrjctname";
            this.lblPrjctname.Size = new System.Drawing.Size(79, 18);
            this.lblPrjctname.TabIndex = 7;
            this.lblPrjctname.Text = "Project Name :";
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.grdProject);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 36);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(443, 216);
            this.pnGrid.TabIndex = 8;
            // 
            // grdProject
            // 
            this.grdProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProject.Location = new System.Drawing.Point(0, 0);
            this.grdProject.Name = "grdProject";
            this.grdProject.Size = new System.Drawing.Size(443, 216);
            this.grdProject.TabIndex = 0;
            this.grdProject.SelectionChanged += new System.EventHandler(this.grdProject_SelectionChanged);
            // 
            // frmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 393);
            this.Controls.Add(this.pnGrid);
            this.Controls.Add(this.pnNewprjct);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProject";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projects";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).EndInit();
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNewprjct)).EndInit();
            this.pnNewprjct.ResumeLayout(false);
            this.pnNewprjct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveprjct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprjctDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprjctName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblprjctDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrjctname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGrid)).EndInit();
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProject.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnTop;
        private Telerik.WinControls.UI.RadPanel pnNewprjct;
        private Telerik.WinControls.UI.RadButton btnSaveprjct;
        private Telerik.WinControls.UI.RadTextBoxControl txtprjctDesc;
        private Telerik.WinControls.UI.RadTextBoxControl txtprjctName;
        private Telerik.WinControls.UI.RadLabel lblprjctDesc;
        private Telerik.WinControls.UI.RadLabel lblPrjctname;
        private Telerik.WinControls.UI.RadPanel pnGrid;
        private Telerik.WinControls.UI.RadGridView grdProject;
        private Telerik.WinControls.UI.RadButton btnOpen;
        private Telerik.WinControls.UI.RadButton btnNew;
        private Telerik.WinControls.UI.RadButton btnDelete;
    }
}
