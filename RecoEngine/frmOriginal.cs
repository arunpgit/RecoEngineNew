using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecoEngine_BI;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading;

namespace RecoEngine
{
    public partial class frmOriginal : Telerik.WinControls.UI.RadRibbonForm
    {
        bool bFormLoded = false;
        clsDataSource clsObj = new clsDataSource();
        CntrlReports ctlReports = new CntrlReports();
        int iLeftMenuHeight = 0;
        bool IspageSelected = true;
       
        public frmOriginal()
        {
            InitializeComponent();
         //   this.WindowState = FormWindowState.Maximized;
 
        }
        private void frmOriginal_Load(object sender, EventArgs e)
        {
            
            if (!Common.bIsConnectionStringEstablish)
            {
                fnDisableControls(Common.bIsConnectionStringEstablish, false);
                btnDataConnection_Click(null, null);
            }
            //else
            //{
            //    fnIsTableMapped();
            //    //rbbtnDataConnection.Enabled = false;
            //    //btnDataConnection.Enabled = false;
            //}

            iLeftMenuHeight = radLeftMenu.Height;

            fnSetImagesOfficeColors();
            fnShowProjects(false);
            fnMapProjectDetails();
           // fnOffersOpprortunityCount();
            
             fnIsTableMapped();
            RadPageViewExplorerBarElement explorerBarElement = (this.radLeftMenu.ViewElement as RadPageViewExplorerBarElement);
          explorerBarElement.ContentSizeMode = ExplorerBarContentSizeMode.AutoSizeToBestFit;

            //radLeftMenu.SelectedPage = radLeftMenu.Pages["pgRecommendation"];
            radLeftMenu.Pages["pgRecommendation"].IsContentVisible = true;
           // btnMovementWindow_Click(null, null);
            btnMovementWindow.PerformClick();
            bFormLoded = true;
        }
        private void fnIsTableMapped()
        {
            DataTable dt = clsObj.fnGetColMappingData(Common.iProjectID);
            if (dt.Rows.Count == 0)
            {
                Common.strTableName = "";
                fnDisableControls(false, true);
            }
            else
            {
                Common.strTableName = dt.Rows[0]["TableName"].ToString();

                DataRow[] drRow = dt.Select("TYPE=" + (int)Enums.ColType.Key);
                if (drRow.Length > 0)
                {
                    Common.strKeyName = drRow[0]["COLNAME"].ToString();
                }
                Common.SetLoginDetailsToRegistry();
            }
        }
        void fnDisableControls(bool bIsEnable, bool bIsDataFeild)
        {
            if (!bIsDataFeild)
            {
                rbbtnDataConnection.Enabled = btnDataConnection.Enabled = !bIsEnable;
                rbbtnDataFields.Enabled = btnDataFields.Enabled = bIsEnable;
            }
            else
            {
                //rbbtnDataConnection.Enabled = btnDataConnection.Enabled = bIsEnable;
                //rbbtnDataFields.Enabled = btnDataFields.Enabled = !bIsEnable;
            }
            rbbtnDataPreview.Enabled = bIsEnable;
            radbtnPProjects.Enabled = bIsEnable;
            rbRecommendation.Enabled = bIsEnable;
            rbBtnReports.Enabled = bIsEnable;
            pgRecommendation.Enabled = bIsEnable;
            pgExport.Enabled = bIsEnable;
            pgUserManagement.Enabled = bIsEnable;
           // pgOfferLibrary.Enabled = bIsEnable;
            //pgReports.Enabled = bIsEnable;
            btnPreview.Enabled = bIsEnable;

        }
               private void radLeftMenu_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                IspageSelected = true;
                switch (radLeftMenu.SelectedPage.Tag.ToString().ToLower())
                {

                    case "datasource":
                        fnShowDataSource(1);
                        break;
                    case "recommendation":
                        fnShowRecommendations(1);
                        break;
                    case "reports":
                        fnShowReports();
                        break;
                    case "offerlibrary":
                        fnShowOffers(1);
                        break;
                    case "usermanagement":
                        fnShowUserManagement();
                        break;
                    case "export":
                        fnShowExport();
                   // radLeftMenu.SelectedPage.IsContentVisible = false;
                         break;
                       
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        void fnShowDataSource(int iTabIndex)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                bottomRightPanel.Controls.Clear();
                CntrlDataSource ctlDataSource = new CntrlDataSource(iTabIndex);
                ctlDataSource.Dock = DockStyle.Fill;
                ctlDataSource.PreviewNxtBtnClick += new EventHandler(ctlDataSource_PreviewNxtBtnClick);
                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlDataSource);
                bottomRightPanel.Controls.Remove(gbDummy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        void ctlDataSource_PreviewNxtBtnClick(object sender, EventArgs e)
        {

            rbbtnDataPreview.Enabled = true;
            radbtnPProjects.Enabled = true;
            rbRecommendation.Enabled = true;
            rbBtnReports.Enabled = true;
            pgRecommendation.Enabled = true;
            pgExport.Enabled = true;
            pgUserManagement.Enabled = true;
            //pgOfferLibrary.Enabled = true;
            //pgReports.Enabled = true;
            btnPreview.Enabled = true;

            radLeftMenu.SelectedPage = radLeftMenu.Pages["pgRecommendation"];
            radLeftMenu.Pages["pgRecommendation"].IsContentVisible = true;
            fnShowRecommendations(1);
        }
        void fnShowRecommendations(int iTabIndex)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                fnOffersOpprortunityCount();
                bottomRightPanel.Controls.Clear();
                CntrlRecommendation ctlRecommendations = new CntrlRecommendation(iTabIndex);
                ctlRecommendations.Dock = DockStyle.Fill;

                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlRecommendations);
                bottomRightPanel.Controls.Remove(gbDummy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        void fnShowReports()
        {
            try
            {

                bottomRightPanel.Controls.Clear();
                
                ctlReports.Dock = DockStyle.Fill;

                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlReports);
                bottomRightPanel.Controls.Remove(gbDummy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void fnShowUserManagement()
        {
            try
            {

                bottomRightPanel.Controls.Clear();
                cntrlUsers ctlUsers = new cntrlUsers();
                ctlUsers.Dock = DockStyle.Fill;
                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);
                bottomRightPanel.Controls.Add(ctlUsers);
                bottomRightPanel.Controls.Remove(gbDummy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void fnShowExport()
        {
            try
            {

                bottomRightPanel.Controls.Clear();
                CntrlExport ctlExports = new CntrlExport();
                ctlExports.Dock = DockStyle.Fill;

                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlExports);
                bottomRightPanel.Controls.Remove(gbDummy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void radLeftMenu_PageExpanded(object sender, Telerik.WinControls.UI.RadPageViewEventArgs e)
        {
            try
            {
                if (radLeftMenu.SelectedPage.Item.Text != "")
                {
                    if (IspageSelected)
                    {
                        for (int i = 0; i < radLeftMenu.Pages.Count; i++)
                        {
                            radLeftMenu.Pages[i].IsContentVisible = false;
                        }
                        IspageSelected = false;
                   
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void rdProjectAdd_Click(object sender, EventArgs e)
        {
            fnShowProjects(true);
        }

        private void rdProejctsOpen_Click(object sender, EventArgs e)
        {
            fnShowProjects(false);
        }

        void fnShowProjects(bool bIsNew)
        {
            frmProject frm = new frmProject(bIsNew, Common.iProjectID);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblCreatedBy.Text = "Created By : " + frm.strProjectCreatedBy;
                lblProjectName.Text = "Project Name : " + frm.strProjectName;
                lblCreatedDate.Text = "Created On : " + frm.strProjectCReatedDate;
                Common.iProjectID = frm.iProjectId;
                Common.SetLoginDetailsToRegistry();
            }
        }

        private void btnDataConnection_Click(object sender, EventArgs e)
        {
            fnShowDataSource(2);
        }

        void ctl_EnableDataSource()
        {
            rbbtnDataFields.Enabled = Common.bIsConnectionStringEstablish;
            btnDataFields.Enabled = Common.bIsConnectionStringEstablish;
            fnShowDataSource(1);
        }
        private void fnMapProjectDetails()
        {
            if (Common.iProjectID != 0)
            {
                clsProjects clsPObj = new clsProjects();
                DataTable dt = clsPObj.fnGetProjectDetails(Common.iProjectID);
                if (dt.Rows.Count > 0)
                {
                    lblCreatedBy.Text = "Created By : " + dt.Rows[0]["UName"];
                    lblProjectName.Text = "Project Name : " + dt.Rows[0]["Name"];
                    lblCreatedDate.Text = "Created On : " + dt.Rows[0]["CREATEDON"];
                }

            }
            else
            {
                fnShowProjects(false);
            }
        }
        public void fnOffersOpprortunityCount()
        {
            clsProjects clsPObj = new clsProjects();
            int iOfferCount = 0;
            int iOpportunityCount = clsPObj.fnGetOpportunityCount(Common.iProjectID, Common.iUserID, ref iOfferCount);

            lblOpportunities.Text = "Opportunities : : " + iOpportunityCount.ToString();
            //lblOffers.Text = "Offers : : " + iOfferCount.ToString();
            }

    
        //public string LabelText
        //{
        //  ////  get
        //  ////  {
        //  //////      return this.lblOffers.Text;
        //  ////  }
        //  ////  set
        //  ////  {
        //  //// //     this.lblOffers.Text = value;
        //  ////  }
        //}
                private void btnDataFields_Click(object sender, EventArgs e)
        {
            fnShowDataSource(1);
        }
        private void fnSetImagesOfficeColors()
        {
            try
            {
                if (bFormLoded)
                    return;

                //this.CreateBuiltInVisualStyleCommand(rbtnClrBlue, "rcmdBlue", "Blue", Color.FromArgb(118, 153, 199));
                //this.CreateBuiltInVisualStyleCommand(rbtnClrSilver, "rcmdSilver", "Silver", Color.FromArgb(192, 192, 192));
                //this.CreateBuiltInVisualStyleCommand(rbtnClrBlack, "rcmdBlack", "Black", Color.FromArgb(0, 0, 0));
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void CreateBuiltInVisualStyleCommand(Telerik.WinControls.UI.RadToggleButtonElement btnCmd, string key, string text, Color imageColor)
        {
            try
            {
                btnCmd.Tag = imageColor;
                btnCmd.Text = text;
                btnCmd.Image = CreateColorImage(imageColor, 32, 32);
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void CreateBuiltInVisualStyleCommand(Telerik.WinControls.UI.RadButtonElement btnCmd, string key, string text, Color imageColor)
        {
            try
            {

                btnCmd.Tag = imageColor;
                btnCmd.Text = text; //Common.TranslateText(Enums.InterFaces.Home, text, Enums.TextType.Labels);
                btnCmd.Image = CreateColorImage(imageColor, 32, 32);
                btnCmd.SmallImage = CreateColorImage(imageColor, 32, 32);
            }
            catch (Exception ex)
            {
                throw ex;
                //OfficeDialog.OfficeBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, OfficeBoxIcon.Error);
                //Common.LogMessage(ex);
            }
        }

        private Image CreateColorImage(Color clr, int width, int height)
        {
            try
            {
                // to create the  rectangle for custom colors with given color
                Bitmap bmp = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(clr);
                Rectangle r = new Rectangle(0, 0, width - 1, height - 1);
                g.DrawRectangle(Pens.Black, r);
                r.Inflate(-1, -1);
                g.DrawRectangle(Pens.White, r);
                g.Dispose();
                return bmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        string strStandardColor = "";
        private void rbtnClrBlue_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Common.AppPath() + @"\ControlDefault.tssp"))
            {
                ThemeResolutionService.LoadPackageFile(Common.AppPath() + @"\ControlDefault.tssp");
            }

            ThemeResolutionService.ApplicationThemeName = "ControlDefault";


            strStandardColor = "Blue";
            //rbtnClrBlack.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            //rbtnClrSilver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;

            //ColorBlueForSomeControls();

        }

        private void rbtnClrBlack_Click(object sender, EventArgs e)
        {


            ThemeResolutionService.LoadPackageResource("RecoEngine.Themes.Office2007Black.tssp");
            //if (System.IO.File.Exists(Common.AppPath() + @"\Office2007Black.tssp"))
            //{

            //    ThemeResolutionService.LoadPackageResource("RecoEngine.Themes.Office2007Black.tssp");
            //    ThemeResolutionService.LoadPackageFile(Common.AppPath() + @"\Office2007Black.tssp");
            //}

            //ThemeResolutionService.ApplyThemeToControlTree(this, "Office2007Black");
            //ThemeResolutionService.ApplicationThemeName = "Office2007Black";

            CntrlReports cntrlre = (CntrlReports)Common.TopMostParent(this);
           // cntrlre.Controls.
            strStandardColor = "Black";
            
            //rbtnClrBlue.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            //rbtnClrSilver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            //ColorBlackForSomeControls();
        }

        private void rbtnClrSilver_Click(object sender, EventArgs e)
        {
            //if (System.IO.File.Exists(Common.AppPath() + @"\Office2007Silver.tssp"))
            //{
            //    ThemeResolutionService.LoadPackageFile(Common.AppPath() + @"\Office2007Silver.tssp");
            //}
            //ThemeResolutionService.ApplyThemeToControlTree(this, "Office2007Silver");

            ThemeResolutionService.LoadPackageResource("RecoEngine.Themes.Office2007Silver.tssp");
            ThemeResolutionService.ApplicationThemeName = "Office2007Silver";
            strStandardColor = "Silver";
            //rbtnClrBlue.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            //rbtnClrBlack.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            //ColorSilverForSomeControls();
        }
        //private void ColorBlueForSomeControls()
        //{
        //    try
        //    {
        //        rbTREDetails.RibbonBarElement.TabStripElement.ContentArea.BackColor = Color.FromArgb(225, 239, 255);


        //        rbViewgroupOfficeColors.GroupFill.BackColor = Color.FromArgb(225, 239, 255);
        //        rbViewgroupOfficeColors.GroupFill.GradientStyle = GradientStyles.Solid;
        //           if (rbViewgroupOfficeColors.Children[1].Children.Count > 0)
        //            rbViewgroupOfficeColors.Children[1].Children[1].ShouldPaint = false;                             //Reports Tab


        //    }
        //    catch (Exception ex)
        //    {
        //        Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //        Common.LogMessage(ex);
        //    }
        //}

        //private void ColorBlackForSomeControls()
        //{
        //    try
        //    {
             

        //        rbTREDetails.RibbonBarElement.TabStripElement.ContentArea.BackColor = Color.FromArgb(215, 219, 224);
        //        reportsPanel.BackColor = Color.White;
               

        //        //pgReports.BackColor = Color.White;
        //        //RadChartView.ShouldPaint = false;
        //        //rbViewgroupOfficeColors.GroupFill.BackColor = Color.FromArgb(215, 219, 224);
        //        //     if (rbViewgroupOfficeColors.Children[1].Children.Count > 0)
        //        //    rbViewgroupOfficeColors.Children[1].Children[1].ShouldPaint = false;   
        //        ////Start Tab

        //    }
        //    catch (Exception ex)
        //    {
        //        Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //        Common.LogMessage(ex);
        //    }

        //}
        //private void ColorSilverForSomeControls()
        //{
        //    try
        //    {
        //        rbTREDetails.RibbonBarElement.TabStripElement.ContentArea.BackColor = Color.FromArgb(240, 242, 247);


        //        rbViewgroupOfficeColors.GroupFill.BackColor = Color.FromArgb(240, 242, 247);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //        Common.LogMessage(ex);
        //    }

        //}

        private void rbbtnDataFields_Click(object sender, EventArgs e)
        {
            fnShowDataSource(2);
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            fnShowDataSource(3);
        }

        private void rbbtnDataPreview_Click(object sender, EventArgs e)
        {
            fnShowDataSource(3);
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            fnShowRecommendations(3);

        }

        private void btnMovementWindow_Click(object sender, EventArgs e)
        {
            fnShowRecommendations(1);
        }

        private void btnOppurtunityMapping_Click(object sender, EventArgs e)
        {
            fnShowRecommendations(2);
        }

        private void btnGrouping_Click(object sender, EventArgs e)
        {
            fnShowRecommendations(1);
        }

        private void rdBtnUser_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                bottomRightPanel.Controls.Clear();
                cntrlUsers ctlUsers = new cntrlUsers();
                ctlUsers.Dock = DockStyle.Fill;

                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlUsers);
                bottomRightPanel.Controls.Remove(gbDummy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmOriginal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnOpportunityPtnl_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowRecommendations(5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOppurtunities_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowRecommendations(6);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOffers_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowOffers(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void fnShowOffers(int iTabIndex)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                fnOffersOpprortunityCount();
                bottomRightPanel.Controls.Clear();
                CntrlOfferLibrary ctlOffers = new CntrlOfferLibrary(iTabIndex);
                ctlOffers.Dock = DockStyle.Fill;

                Telerik.WinControls.UI.RadGroupBox gbDummy = Common.GetfrmDummy();
                bottomRightPanel.Controls.Add(gbDummy);

                bottomRightPanel.Controls.Add(ctlOffers);
                bottomRightPanel.Controls.Remove(gbDummy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnOffer_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowOffers(1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }        
        }

        private void btnCampaign_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowOffers(2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        private void btnSetup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
             dlg.Filter = "Img files (*.jpeg)|*.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    Bitmap image=  new Bitmap(dlg.FileName);
                  rbTREDetails.StartButtonImage = new Bitmap(image,20,20);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            fnShowExport();
        }

 
     
       
      

     
       

     }
}
