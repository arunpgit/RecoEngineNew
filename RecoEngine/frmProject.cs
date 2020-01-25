using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using RecoEngine_BI;
using Telerik.WinControls.UI;

namespace RecoEngine
{
    public partial class frmProject : Telerik.WinControls.UI.RadForm
    {
        bool bIsNew = false;
        clsProjects clsPrjObj = new clsProjects();
        public string strProjectName = "";
        //string strProjectDesc = "";
        public string strProjectCreatedBy = "";
        public string strProjectCReatedDate = "";
        public int iProjectId = 0;
        int iCurrentProjectID = 0;
        public DialogResult drs = DialogResult.None;
        bool bIsFormLoaded = false;
        bool bIsSaveClick= false;
        public frmProject(bool bIsNew, int iProjectID)
       {
            this.bIsNew = bIsNew;
            this.iProjectId = iProjectID;
            InitializeComponent();
        }
        private void frmProject_Load(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                pnNewprjct.Visible = bIsNew;

                bindinggrid(bIsSaveClick);
                bIsFormLoaded = true;
                grdProject_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void bindinggrid(bool bIsSave)
        {
            try
            {
                DataTable dt = clsPrjObj.fnGetProjectDetails(Common.iUserID);
                dt.Columns.Add(new DataColumn("Select", typeof(bool)));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Select"] = false;
                }
                dt.Columns["CREATEDON"].ColumnName = "Creation Date";
                dt.Columns["UName"].ColumnName = "User";
                dt.AcceptChanges();
                grdProject.DataSource = dt;
                grdProject.AllowAddNewRow = false;
                grdProject.ShowRowHeaderColumn = false;
                grdProject.EnableGrouping = false;
                grdProject.ShowFilteringRow = false;
                grdProject.AutoSizeRows = false;
                grdProject.Columns["Project_Id"].IsVisible = false;
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {
                    grdProject.MasterTemplate.Columns[i].ReadOnly = true;
                }
                grdProject.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                if (bIsSave==false)
                {
                    grdProject.ValueChanged += new EventHandler(grdProject_ValueChanged);
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        void grdProject_ValueChanged(object sender, EventArgs e)
        {
            grdProject.ValueChanged -= new EventHandler(grdProject_ValueChanged);
            RadCheckBoxEditor editor = sender as RadCheckBoxEditor;
            if (editor != null)
            {
                previouslySelectedRows.Clear();
                this.grdProject.TableElement.BeginUpdate();
                foreach (GridViewDataRowInfo row in this.grdProject.Rows)
                {
                    if (row != this.grdProject.CurrentRow)
                    {
                        row.Cells["Select"].Value = false;
                    }
                    if (row == this.grdProject.CurrentRow)
                    {
                        if ((bool)row.Cells["Select"].Value == true)
                        {
                            btnOpen.Enabled = false;
                        }
                        else
                        {
                            previouslySelectedRows.Add(grdProject.CurrentRow);
                            btnOpen.Enabled = true;
                        }
                       
                    }

                }
                this.grdProject.TableElement.EndUpdate();
                editor = null;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            pnNewprjct.Visible = true;
            btnDelete.Visible = false;
            btnSaveprjct.Text = "Save";
            txtprjctDesc.Text = "";
            iCurrentProjectID = 0;
            txtprjctName.Text = "";
        }
        private  List<GridViewRowInfo> previouslySelectedRows = new List<GridViewRowInfo>();
        private void btnOpen_Click(object sender, EventArgs e)
        {
           
            DataTable dt = ((DataTable)grdProject.DataSource);
            DataRow[] drRow = dt.Select("Select=1");
            if (grdProject.CurrentRow != null)
            {
                iProjectId = int.Parse(grdProject.CurrentRow.Cells["Project_Id"].Value.ToString());
                strProjectName = grdProject.CurrentRow.Cells["Name"].Value.ToString();
                strProjectCreatedBy = grdProject.CurrentRow.Cells["User"].Value.ToString();
                strProjectCReatedDate = Convert.ToDateTime(grdProject.CurrentRow.Cells["Creation Date"].Value.ToString()).ToShortDateString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnSaveprjct_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtprjctName.Text.Trim() != "")
                {
                    clsPrjObj.fnInsertProjectdtls(iCurrentProjectID, txtprjctName.Text.Trim(), txtprjctDesc.Text.Trim(), Common.iUserID);
                    txtprjctName.Text = "";
                    txtprjctDesc.Text = "";
                    btnOpen.Enabled = false;
                    bIsSaveClick = true;
                    bindinggrid(bIsSaveClick);
                }
                else
                {                    
                    Telerik.WinControls.RadMessageBox.Show(this, "Project Name Cannot be Empty", "Saving", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void grdProject_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (bIsFormLoaded && grdProject.CurrentRow != null)
                {
                    pnNewprjct.Visible = true;
                    GridViewRowInfo grdRow = grdProject.CurrentRow;
                    if (grdRow.Cells["Project_Id"].Value != null)
                    {
                        iCurrentProjectID = int.Parse(grdRow.Cells["Project_Id"].Value.ToString());
                        txtprjctName.Text = grdRow.Cells["Name"].Value.ToString();
                        txtprjctDesc.Text = grdRow.Cells["Description"].Value.ToString();
                    }
                    btnDelete.Visible = true;
                    btnSaveprjct.Text = "Update";
                    //if ((bool)grdRow.Cells["Select"].Value == true)
                      btnOpen.Enabled = true;
                    //else
                    //    btnOpen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //need to check the recomemndations and offers
            // when deleteing recomemndation need to delete all dependencies of that object like cutoffs, offers
            DialogResult ds = Telerik.WinControls.RadMessageBox.Show(this, "On deleting the project all its dependencies will be deleted", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            if (ds != DialogResult.Yes)
            {
                return;
            }
            else
            {
                clsPrjObj.fnDeleteProject(iCurrentProjectID);
                bIsSaveClick = true;
                bindinggrid(bIsSaveClick);
            }
        }


        private void frmProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

            
       
    }
}
