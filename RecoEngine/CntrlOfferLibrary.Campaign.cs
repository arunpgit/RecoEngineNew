using RecoEngine_BI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace RecoEngine
{
    public partial class CntrlOfferLibrary : UserControl
    {
        private clsDataSource clsDSOBJ = new clsDataSource();

        private clsCampaign clsObjcampaign = new clsCampaign();

        private int iCampaignID;

        private DataTable dtOpportunity = new DataTable();

        private bool bIsCampaignLoaded;

        private string strEligibility = "";

        private string[] Status = new string[] { "Non-User", "Dropper", "Stopper", "Grower", "Flat", "New-User" };

        private string[] SegmentType = new string[] { "X-SELL", "MITIGATE", "REVIVE", "NO ACTION", "UP-SELL", "NO-ACTION" };

     

        private void bindingExpressionEditor(int iExpressionType)
        {
            string str;
            try
            {
                DataTable dataTable = clsObjcampaign.fnGetEffectiveTable(Common.iProjectID, out str, Common.strTableName);
                DataTable schemaTable = (new DataTableReader(dataTable)).GetSchemaTable();
                using (frmExpressEditor _frmExpressEditor = new frmExpressEditor(iExpressionType, string.Concat("(", str, ")"), strEligibility))
                {
                    _frmExpressEditor._fieldDict = Common.GetDict(dataTable);
                    _frmExpressEditor.AvailableFields = _frmExpressEditor._fieldDict.ToList<KeyValuePair<string, Type>>();
                    _frmExpressEditor.dtSource = schemaTable;
                    if (_frmExpressEditor.ShowDialog() == DialogResult.OK)
                    {
                        Common.strfiltertxt = _frmExpressEditor.strExpression;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void bndgcntrlchkDropDowntp1(CntrlchkDropDown ctrl, List<int> SelectedItems = null)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet();
                string str = "Selected";
                dataTable.Columns.Add(new DataColumn("Selected", typeof(bool)));
                dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Empty", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Empty2", typeof(string)));
                for (int i = 0; i < Status.Count<string>(); i++)
                {
                    DataRow status = dataTable.NewRow();
                    status["Status"] = Status[i];
                    status["Selected"] = false;
                    dataTable.Rows.Add(status);
                }
                dataTable.Columns["Selected"].SetOrdinal(0);
                if (SelectedItems != null)
                {
                    foreach (int selectedItem in SelectedItems)
                    {
                        dataTable.Rows[selectedItem]["Selected"] = true;
                    }
                }
                dataSet.Tables.Add(dataTable);
                ctrl.ConfigureDropDown(dataSet, str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void btnCInActive_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dataRowArray = ((DataTable)grdCampaign.DataSource).Select("Flag='Y'");
                if ((int)dataRowArray.Length == 0)
                {
                    RadMessageBox.Show(this, "Active/Inactive at least one Campaign.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (RadMessageBox.Show(this, "Do you wish to Active/Inactive selected Campaign(s)?", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ArrayList arrayLists = new ArrayList();
                    string str = "";
                    for (int i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        str = dataRowArray[i]["CAMPAIGN_ID"].ToString();
                        str = (!(bool)dataRowArray[i]["Active"] ? string.Concat(str, ";0") : string.Concat(str, ";1"));
                        arrayLists.Add(str);
                    }
                    if (arrayLists.Count > 0)
                    {
                        int num = 0;
                        while (num < arrayLists.Count)
                        {
                            if (clsObjcampaign.fnActiveCampaigns(arrayLists[num].ToString()))
                            {
                                num++;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    fnLoadCampaigns();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dataRowArray = ((DataTable)grdCampaign.DataSource).Select("Select=1");
                if ((int)dataRowArray.Length == 0)
                {
                    RadMessageBox.Show(this, "Select at least one Campaign.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (RadMessageBox.Show(this, "Do you wish to delete selected Campaign(s)?", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ArrayList arrayLists = new ArrayList();
                    for (int i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        int num = Convert.ToInt32(dataRowArray[i]["CAMPAIGN_ID"]);
                        arrayLists.Add(num);
                    }
                    if (arrayLists.Count > 0)
                    {
                        int num1 = 0;
                        while (num1 < arrayLists.Count)
                        {
                            if (clsObjcampaign.fnDeleteCampaign(Convert.ToInt32(arrayLists[num1]), Common.strTableName))
                            {
                                num1++;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    fnLoadCampaigns();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCampaignName.Text.Trim().Length == 0)
                {
                    RadMessageBox.Show("Campaign Name Should not be blank", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                    txtCampaignName.Focus();
                }
                else if (ddlOffer.SelectedItem == null || ddlSegment.SelectedItem == null)
                {
                    RadMessageBox.Show("Opportunity and Offers must be there to create Campaign", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    int num = 0;
                    if (chkCIsActive.Checked)
                    {
                        num = 1;
                    }
                    strEligibility = Common.strfiltertxt;
                    string str = "";
                    if (txtSegmentType.Text != "STIMULATION")
                    {
                        str = string.Concat(txtSegmentType.Text, "-", ddlSegment.SelectedItem.ToString());
                    }
                    else if (chkSegmentDrpdn.m_TextBox.Text == "")
                    {
                        RadMessageBox.Show("Please Select Segment Type", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        string text = chkSegmentDrpdn.m_TextBox.Text;
                        string[] strArrays = new string[] { ";" };
                        string[] strArrays1 = text.Split(strArrays, StringSplitOptions.None);
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            string str1 = strArrays1[i];
                            string str2 = str;
                            string[] segmentType = new string[] { str2, SegmentType[Array.IndexOf<string>(Status, str1)], "-", ddlSegment.SelectedItem.ToString(), "','" };
                            str = string.Concat(segmentType);
                        }
                        str = str.Trim().Substring(0, str.Length - 3);
                    }
                    iCampaignID = clsObjcampaign.fnSaveCampaign(iCampaignID, txtCampaignName.Text, txtCampaignCode.Text, txtCampaigndesc.Text, ddlSegment.SelectedItem.ToString(), ddlOffer.SelectedItem.Value.ToString(), ddlSegment.SelectedItem.Value.ToString(), ddlChannel.SelectedItem.Value.ToString(), txtRate.Text, strEligibility, txtSegmentType.Text, str, Common.iUserID, Common.iProjectID, num, Common.strTableName);
                    RadMessageBox.Show("Successfully saved.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                    Common.strfiltertxt = "";
                    btnNewCmpgn_Click(null, null);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            try
            {
                bindingExpressionEditor(1);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnNewCmpgn_Click(object sender, EventArgs e)
        {
            try
            {
                fnShowCampaignList(false);
                iOfferID = 0;
                txtCampaignName.Text = "";
                txtCampaignCode.Text = "";
                txtRate.Text = "";
                if (ddlOffer.SelectedItem != null && ddlSegment.SelectedItem != null && ddlChannel.SelectedItem != null)
                {
                    RadTextBox radTextBox = txtCampaignCode;
                    string[] str = new string[] { ddlSegment.SelectedItem.ToString(), "_", ddlOffer.SelectedItem.ToString(), "_", ddlChannel.SelectedItem.ToString() };
                    radTextBox.Text = string.Concat(str);
                }
                ddlSegment.SelectedIndex = 0;
                ddlOffer.SelectedIndex = 0;
                ddlChannel.SelectedIndex = 0;
                strEligibility = "";
                chkIsActive.Checked = true;
                txtCampaigndesc.Text = "";
                bndgcntrlchkDropDowntp1(chkSegmentDrpdn, null);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                iCampaignID = 0;
                fnShowCampaignList(true);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }




        private void ddlSegment_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (bIsCampaignLoaded)
                {
                    RadTextBox radTextBox = txtCampaignCode;
                    string[] str = new string[] { ddlSegment.SelectedItem.ToString(), "_", ddlOffer.SelectedItem.ToString(), "_", ddOpt.SelectedItem.ToString(), "_", ddlAction.SelectedItem.ToString(), "_", ddlChannel.SelectedItem.ToString() };
                    radTextBox.Text = string.Concat(str);
                    txtSegmentType.Text = dtOpportunity.Rows[ddlSegment.SelectedIndex]["OPP_ACTION"].ToString();
                    if (txtSegmentType.Text != "STIMULATION")
                    {
                        chkSegmentDrpdn.Visible = false;
                    }
                    else
                    {
                        chkSegmentDrpdn.Visible = true;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void fnFilldds()
        {
            try
            {
                DataSet dataSet = clsObjcampaign.fnGetSgmntOfferChnl(Common.iProjectID);
                dtOpportunity = dataSet.Tables[0];
                ddlSegment.DataSource = dataSet.Tables[0];
                ddlSegment.ValueMember = "Opportunity_id";
                ddlSegment.DisplayMember = "OPP_NAME";
                ddlSegment.SelectedIndex = 0;
                ddlOffer.DataSource = dataSet.Tables[1];
                ddlOffer.ValueMember = "OFFER_ID";
                ddlOffer.DisplayMember = "CODE";
                ddlOffer.SelectedIndex = 0;
                ddOpt.DataSource = dataSet.Tables[2];
                ddOpt.ValueMember = "CODE";
                ddOpt.DisplayMember = "DESCRIPTION";
                ddOpt.SelectedIndex = 0;
                ddlAction.DataSource = dataSet.Tables[3];
                ddlAction.ValueMember = "CODE";
                ddlAction.DisplayMember = "DESCRIPTION";
                ddlAction.SelectedIndex = 0;
                ddlChannel.DataSource = dataSet.Tables[4];
                ddlChannel.ValueMember = "CODE";
                ddlChannel.DisplayMember = "DESCRIPTION";
                ddlChannel.SelectedIndex = 0;
                ddPrioritise.DataSource = Enum.GetValues(typeof(Enums.Offer_Priority));
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fnLoadCampaigns()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                try
                {
                    DataTable dataTable = clsObjcampaign.fnGetCampaignMapping(Common.iProjectID);
                    dataTable.Columns.Add(new DataColumn("Select", typeof(bool)));
                    dataTable.Columns["Select"].SetOrdinal(0);
                    dataTable.Columns.Add(new DataColumn("Active", typeof(bool)));
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["Select"] = false;
                        if (dataTable.Rows[i]["ISACTIVEID"].ToString() != "1")
                        {
                            dataTable.Rows[i]["Active"] = false;
                        }
                        else
                        {
                            dataTable.Rows[i]["Active"] = true;
                        }
                    }
                    grdCampaign.DataSource = dataTable;
                    grdCampaign.Columns["CAMPAIGN_ID"].IsVisible = false;
                    grdCampaign.Columns["Average1"].IsVisible = false;
                    grdCampaign.Columns["ISACTIVEID"].IsVisible = false;
                    grdCampaign.Columns["Flag"].IsVisible = false;
                    grdCampaign.Columns["Project_ID"].IsVisible = false;
                    grdCampaign.Columns["OPPORTUNITY_ID"].IsVisible = false;
                    grdCampaign.Columns["OFFER_ID"].IsVisible = false;
                    grdCampaign.Columns["CHANNEL"].IsVisible = false;
                    grdCampaign.Columns["ELIGIBILITY"].IsVisible = false;
                    grdCampaign.Columns["SEGMENT_DESCRIPTION"].IsVisible = false;
                    grdCampaign.Columns["ISACTIVEID"].IsVisible = false;
                    grdCampaign.Columns["CREATEDDATE"].IsVisible = false;
                    grdCampaign.Columns["DESCRIPTION"].Width = 200;
                    for (int j = 1; j < dataTable.Columns.Count - 1; j++)
                    {
                        if (dataTable.Columns[j].ColumnName != "Select")
                        {
                            grdCampaign.MasterTemplate.Columns[j].ReadOnly = true;
                        }
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void fnShowCampaignList(bool bShow)
        {
            try
            {
                if (!bShow)
                {
                    bIsShowOPPList = false;
                    gbNewcampaign.Visible = true;
                    gbNewcampaign.Dock = DockStyle.Fill;
                    gbCampaignlist.Visible = false;
                    gbCampaignlist.Dock = DockStyle.None;
                }
                else
                {
                    clsObjcampaign.fnDelteCampaignRankingsfrmExport(Common.iProjectID, Common.strTableName);
                    bIsShowOPPList = true;
                    gbCampaignlist.Visible = true;
                    gbNewcampaign.Visible = false;
                    gbNewcampaign.Dock = DockStyle.None;
                    gbCampaignlist.Dock = DockStyle.Fill;
                    fnLoadCampaigns();
                }
                if (!bIsCampaignLoaded)
                {
                    fnFilldds();
                }
                bIsCampaignLoaded = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }



        private void grdCampaign_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (grdCampaign.CurrentRow != null && e.Column.Name.ToUpper() == "ACTIVE")
                {
                    grdCampaign.CurrentRow.Cells["Flag"].Value = "Y";
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void grdCampaign_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdCampaign.MasterView.CurrentRow != null)
                {
                    iCampaignID = int.Parse(grdCampaign.MasterView.CurrentRow.Cells["CAMPAIGN_ID"].Value.ToString());
                    txtCampaignName.Text = grdCampaign.MasterView.CurrentRow.Cells["Name"].Value.ToString();
                    txtCampaigndesc.Text = grdCampaign.MasterView.CurrentRow.Cells["Description"].Value.ToString();
                    txtCampaignCode.Text = grdCampaign.MasterView.CurrentRow.Cells["CODE"].Value.ToString();
                    txtRate.Text = grdCampaign.MasterView.CurrentRow.Cells["TAKE_UP_RATE"].Value.ToString();
                    int item = (
                        from p in ddlSegment.Items
                        where p.Value.ToString() == grdCampaign.MasterView.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString()
                        select p.RowIndex).ToList<int>()[0];
                    ddlSegment.SelectedIndex = Convert.ToInt16(item);
                    strEligibility = grdCampaign.MasterView.CurrentRow.Cells["ELIGIBILITY"].Value.ToString();
                    string str = grdCampaign.MasterView.CurrentRow.Cells["SEGMENT_DESCRIPTION"].Value.ToString();
                    if (grdCampaign.MasterView.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString() == "STIMULATE")
                    {
                        List<int> nums = new List<int>();
                        string[] strArrays = new string[] { "','" };
                        string[] strArrays1 = str.Split(strArrays, StringSplitOptions.None);
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            string str1 = strArrays1[i];
                            nums.Add(Array.IndexOf<string>(SegmentType, str1.Remove(str1.IndexOf(string.Concat("-", ddlSegment.SelectedItem.ToString())), ddlSegment.SelectedItem.ToString().Length + 1)));
                        }
                        bndgcntrlchkDropDowntp1(chkSegmentDrpdn, nums);
                    }
                    if (grdCampaign.MasterView.CurrentRow.Cells["ISACTIVEID"].Value.ToString() != "1")
                    {
                        chkCIsActive.Checked = false;
                    }
                    else
                    {
                        chkCIsActive.Checked = true;
                    }
                    fnShowCampaignList(false);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void rbtnPrioritise_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (new clsExport()).fnGetCampaigns(Common.iProjectID);
                if (ddPrioritise.SelectedItem.ToString() != Enums.Offer_Priority.Avg_Ptnl.ToString())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        clsObjcampaign.fnSaveCampaignRankings(row["ELIGIBILITY"].ToString(), Convert.ToInt16(row["PROJECT_ID"]), row["SEGMENT_DESCRIPTION"].ToString(), Convert.ToInt16(row["CAMPAIGN_ID"]), Common.strTableName);
                    }
                    clsObjcampaign.fnPrioritizeRankings(Common.iProjectID, "Take_UP_RATE");
                    grdCampaign.DataSource = null;
                    fnLoadCampaigns();
                }
                else
                {
                    clsObjcampaign.fnGetCampaignMapping(Common.iProjectID);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        clsObjcampaign.fnSaveCampaignRankings(dataRow["ELIGIBILITY"].ToString(), Convert.ToInt16(dataRow["PROJECT_ID"]), dataRow["SEGMENT_DESCRIPTION"].ToString(), Convert.ToInt16(dataRow["CAMPAIGN_ID"]), Common.strTableName);
                    }
                    clsObjcampaign.fnPrioritizeRankings(Common.iProjectID, "Average");
                    grdCampaign.DataSource = null;
                    fnLoadCampaigns();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}