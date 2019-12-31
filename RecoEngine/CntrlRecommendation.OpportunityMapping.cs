﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Collections;
using RecoEngine_BI;


namespace RecoEngine
{
    partial class CntrlRecommendation
    {
        string[] OpportunityTypes = { "ACQUISITION-RECOMMEND", "ACQUISITION-REPLICATE", "ACQUISITION-REACTIVATE", "STIMULATION", "RETENTION-RETAIN", "RETENTION-SATISFY" };
        bool bIsThresholdModified = false;
        bool bIsPtnlModified = false;
        bool bIsOnMain = false;
        string strPtnlFilter = "";
        void fnShowOpporunityList(bool bShow)
        {
            try
            {
                if (bShow)
                {
                    bIsShowOPPList = true;
                    gbOpportunityList.Visible = true;
                    gbMain.Visible = false;
                    gbMain.Dock = DockStyle.None;
                    gbOpportunityList.Dock = DockStyle.Fill;
                    fnLoadOpportunity();
                }
                else
                {
                    bIsShowOPPList = false;
                    gbMain.Visible = true;
                    gbMain.Dock = DockStyle.Fill;
                    gbOpportunityList.Visible = false;
                    gbOpportunityList.Dock = DockStyle.None;
                }
                if (!bOpportunityLoaded)
                    fnFillSource();
                bOpportunityLoaded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            fnShowOpporunityList(false);
            bIsPtnlModified = false;
            strPntlExpression = "";
            strPtnlFilter = "";
            iOpportunityId = 0;

            txtName.Text = "";
            txtDesc.Text = "";
            strExpression = "";
        }
        private void setCurrentOpportunityName()
        {
            if (grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value != null && grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString() != "" && grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString() != "0")
            {
                Common.sOpportunityName = grdOppList.CurrentRow.Cells["OPP_NAME"].Value.ToString();
                iOpportunityId = int.Parse(grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString());
            }
        }
        public void fnShowThreshold()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                try
                {
                    if (Common.sOpportunityName == "")
                    {
                        RadMessageBox.Show(this, "Please select Opportunity.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        this.pgVRecommendation.SelectedPage = this.pgOpportunityMapping;
                        this.fnShowOpporunityList(true);
                    }
                    else
                    {
                        this.iOpportunityId = int.Parse(this.grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString());
                        string str = this.grdOppList.CurrentRow.Cells["FORMULA"].Value.ToString();
                        string str1 = this.grdOppList.CurrentRow.Cells["ELGBL_FORMULA"].Value.ToString();
                        if ((new ctrlThreshold(this.iOpportunityId, str, str1, Common.timePeriods.strtp1, Common.timePeriods.strtp2)).ShowDialog() == DialogResult.OK)
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        void fnLoadOpportunity()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                clsOpportunities clsObj = new clsOpportunities();
                bool bIsOpplist = true;
                DataTable dt = clsObj.fnGetOpportunity(Common.iProjectID, Common.iUserID, bIsOpplist);
                dt.Columns.Add(new DataColumn("Select", typeof(bool)));
                dt.Columns.Add(new DataColumn("Active", typeof(bool)));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Select"] = false;
                    if (dt.Rows[i]["ISACTIVEID"].ToString() == "1")
                        dt.Rows[i]["Active"] = true;
                    else
                        dt.Rows[i]["Active"] = false;

                }

                if (dt.Rows.Count == 0)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        dt.NewRow();
                    }
                }
                dt.Columns["Select"].SetOrdinal(0);
                grdOppList.DataSource = dt;
                grdOppList.Columns["OPPORTUNITY_ID"].IsVisible = false;
                grdOppList.Columns["ISACTIVEID"].IsVisible = false;
                grdOppList.Columns["Flag"].IsVisible = false;
                grdOppList.Columns["FORMULA"].IsVisible = false;
                grdOppList.Columns["Project_ID"].IsVisible = false;
                grdOppList.Columns["CREATEDBY"].IsVisible = false;
                grdOppList.Columns["T1"].IsVisible = false;
                grdOppList.Columns["T2"].IsVisible = false;
                grdOppList.Columns["ISONMAIN"].IsVisible = true;


                grdOppList.Columns["DESCRIPTION"].Width = 200;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (dt.Columns[i].ColumnName != "Select")
                        grdOppList.MasterTemplate.Columns[i].ReadOnly = true;
                }
                grdOppList.CellFormatting += new CellFormattingEventHandler(grdOppList_CellFormatting);
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
        private void btnOppInactive_Click(object sender, EventArgs e)
        {
            try
            {
                clsOpportunities clsOpportunity = new clsOpportunities();
                DataRow[] dataRowArray = ((DataTable)this.grdOppList.DataSource).Select("Flag='Y'");
                if ((int)dataRowArray.Length == 0)
                {
                    RadMessageBox.Show(this, "Active/Inactive at least one Opportunity.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (RadMessageBox.Show(this, "Do you wish to Active/Inactive selected Campaign(s)?", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ArrayList arrayLists = new ArrayList();
                    string str = "";
                    int num = 0;
                    while (num < (int)dataRowArray.Length)
                    {
                        str = dataRowArray[num]["OPP_NAME"].ToString();
                        if (!this.ClsObj.fnCheckOPPHasInRanking(str, Common.iProjectID))
                        {
                            str = (!(bool)dataRowArray[num]["Active"] ? string.Concat(str, ";0") : string.Concat(str, ";1"));
                            arrayLists.Add(str);
                            num++;
                        }
                        else
                        {
                            RadMessageBox.Show(this, "This opportunity is selected in Ranking, you can not Inactive this Opportunity", "Confirmation", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                            break;
                        }
                    }
                    if (arrayLists.Count > 0)
                    {
                        int num1 = 0;
                        while (num1 < arrayLists.Count)
                        {
                            if (clsOpportunity.fnActiveOpportunities(arrayLists[num1].ToString()))
                            {
                                num1++;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    this.fnLoadOpportunity();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }



        private void grdOppList_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value != null && grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString() != "" && grdOppList.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString() != "0")
                {
                    Common.sOpportunityName = grdOppList.CurrentRow.Cells["OPP_NAME"].Value.ToString();
                    if (e.Column.Name.ToLower() == "threshold")
                    {
                        //  pgVRecommendation.SelectedPage = pgThresholds;
                        fnShowThreshold();
                    }
                    if (e.Column.Name.ToUpper() == "SELECT")
                    {
                        GridViewRowInfo drRow = grdOppList.CurrentRow;
                        drRow.Cells["Flag"].Value = "Y";
                    }

                }

            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void grdOppList_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (e.Column.Name.ToLower() == "threshold")
                {
                    e.CellElement.Image = this.imgList.Images[0];
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fnFillSource()
        {
            try
            {
                DataTable dataTable = (new clsDataSource()).fnGetColMappingData(Common.iProjectID);
                int num = 2;
                DataRow[] dataRowArray = dataTable.Select(string.Concat("TYPE=", num.ToString(), " And ISREQUIRED=1"));
                DataTable dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                this.ddlSource.DataSource = dataTable1;
                this.ddlSource.ValueMember = "COLNAME";
                this.ddlSource.DisplayMember = "COLNAME";
                this.ddlSource.SelectedIndex = 0;
                string[] opportunityTypes = this.OpportunityTypes;
                for (int i = 0; i < (int)opportunityTypes.Length; i++)
                {
                    string str = opportunityTypes[i];
                    this.ddlOpportunityType.Items.Add(str);
                }
                this.ddlOpportunityType.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Common.WriteLog("Save button Clicked");
                if (this.txtName.Text.Trim().Length != 0)
                {
                    this.strExpression = this.ddlSource.SelectedValue.ToString();
                    if (this.strExpression == "")
                    {
                        RadMessageBox.Show("Please Add formula.", "Validation", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        this.ddlSource.Focus();
                        return;
                    }
                    else if (this.strCurrentSegmentColumn != "")
                    {
                        Common.strFormula = this.strExpression;
                        string text = this.txtName.Text;
                        Common.sOpportunityName = text;
                        Common.sOpportunityName = text;
                        int num = 0;
                        if (this.chkIsActive.Checked)
                        {
                            num = 1;
                        }
                        this.iOpportunityId = this.ClsObj.fnSaveOpportunity(this.iOpportunityId, this.txtName.Text.ToString(), this.txtDesc.Text.ToString(), this.strExpression, Common.strPtnlFilter, Common.iUserID, Common.iProjectID, Common.strTableName, Common.strKeyName, Common.timePeriods.strtp1, Common.timePeriods.strtp2, num, ddlOpportunityType.SelectedText.ToString());
                        Common.WriteLog("New Opportunity is added to the OPPORTUNITY table");
                        this.fnSaveThresholdAndPotential(this.iOpportunityId);
                        Common.strPtnlFilter = "";
                        ((frmOriginal)this.TopMostParent()).fnOffersOpprortunityCount();
                        this.bIsOnMain = false;
                        Common.WriteLog("Threshold and Potential are added to Status Breakdown");
                    }
                    else
                    {
                        RadMessageBox.Show("Please Select Segment ", "Validation", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                else
                {
                    RadMessageBox.Show("Opportunity Name Should not be blank", "Validation", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                    this.txtName.Focus();
                    return;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
            Common.WriteLog("Save Complete");
        }



        private void fnSaveThresholdAndPotential(int iOpportunityId)
        {
            try
            {
                //bIsThresholdModified = true;
                //saving Thrishould
                clsTre_Details clsTObj = new clsTre_Details();

                if (bIsThresholdModified)
                {
                    string strCtDropper = strCt[0] == "" ? "0" : strCt[0];
                    string strCtGrower = strCt[1] == "" ? "0" : strCt[1];
                    string srtCtStopper = strCt[2] == "" ? "0" : strCt[2];
                    string strCFlat = strCount[0] == "" ? "0" : strCount[0];
                    string strCDropper = strCount[1] == "" ? "0" : strCount[1];
                    string strCGrower = strCount[2] == "" ? "0" : strCount[2];
                    string srtCStopper = strCount[3] == "" ? "0" : strCount[3];
                    string strCNonUser = strCount[4] == "" ? "0" : strCount[4];
                    string strCNewUser = strCount[5] == "" ? "0" : strCount[5];
                    string strAvgFlat = strAvg[0] == "" ? "0" : strAvg[0];
                    string strAvgDropper = strAvg[1] == "" ? "0" : strAvg[1];
                    string strAvgGrower = strAvg[2] == "" ? "0" : strAvg[2];
                    string srtAvgStopper = strAvg[3] == "" ? "0" : strAvg[3];
                    string strAvgNonUser = strAvg[4] == "" ? "0" : strAvg[4];
                    string strAvgNewUser = strAvg[5] == "" ? "0" : strAvg[5];


                    clsTObj.fnSaveOPPBreakDownStatus(iOpportunityId, Convert.ToDecimal(strCtDropper), Convert.ToDecimal(strCtGrower), Convert.ToDecimal(srtCtStopper),
                   Common.timePeriods.strtp1, Common.timePeriods.strtp2, strCurrentSegmentColumn, iIsActive);

                    //if (clsTObj.fnSaveTREThreShold(Common.timePeriods.strtp1, Common.timePeriods.strtp2, Common.sOpportunityName, strCtDropper, strCtGrower, srtCtStopper, iOpportunityId, "Tre_Random", Common.iProjectID, Common.strPtnlFilter, bIsOnMain))
                    //{
                    //    clsTObj.fnGetBaseData(Common.strTableName, strCtGrower, Common.iProjectID);
                    //    clsTObj.fnSaveOPPBreakDownStatus(iOpportunityId, Convert.ToDecimal(strCtDropper), Convert.ToDecimal(strCtGrower), Convert.ToDecimal(srtCtStopper),
                    //   Common.timePeriods.strtp1, Common.timePeriods.strtp2, strCurrentSegmentColumn, iIsActive);
                    //    clsTObj.fnInsertOppValues(iOpportunityId);


                    //    // clsTObj.fnSaveOPPBreakDownStatus(iOpportunityId, 0, Convert.ToDecimal(strCtDropper), Convert.ToDecimal(strCtGrower), Convert.ToDecimal(srtCtStopper), 0, 0,
                    //    //  Convert.ToDecimal(strCFlat), Convert.ToDecimal(strCDropper), Convert.ToDecimal(strCtGrower), Convert.ToDecimal(srtCStopper), Convert.ToDecimal(strCNonUser),
                    //    //Convert.ToDecimal(strCNewUser), Convert.ToDecimal(strAvgFlat), Convert.ToDecimal(strAvgDropper),
                    //    // Convert.ToDecimal(srtAvgStopper), Convert.ToDecimal(strAvgGrower), Convert.ToDecimal(strAvgNonUser), Convert.ToDecimal(strAvgNewUser), timePeriods.strtp1, timePeriods.strtp2, strCurrentSegmentColumn, iIsActive);
                    //}

                }
                // saving Opportunity Potentail
                if (bIsPtnlModified)
                    clsTObj.fnSaveOPPPotential(Common.sOpportunityName, iOpportunityId, Common.strTableName, strPntlExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                string strFc = txtName.Text.Substring(0, 1);

                if (!Char.IsLetter(txtName.Text, 0))
                {
                    Telerik.WinControls.RadMessageBox.Show("Opportunity should start with Alphabet");
                }
                Common.sOpportunityName = txtName.Text;
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {


            base.OnKeyPress(e);

            if (txtName.Text.Length == 0 && e.KeyChar != (char)0x08)
            {
                if (!(char.IsLetter(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsDigit(e.KeyChar)) && (e.KeyChar != '_') && e.KeyChar != (char)0x08)
            {
                e.Handled = true;
                // char is neither letter or digit.
                // there are more methods you can use to determine the
                // type of char, e.g. char.IsSymbol
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            pgVRecommendation.SelectedPage = pgRcmndSettings;
            fnShowOpporunityList(true);
        }
        private void grdOppList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdOppList.MasterView.CurrentRow != null)
                {

                    iOpportunityId = int.Parse(grdOppList.MasterView.CurrentRow.Cells["OPPORTUNITY_ID"].Value.ToString());
                    txtName.Text = grdOppList.MasterView.CurrentRow.Cells["OPP_Name"].Value.ToString();
                    txtDesc.Text = grdOppList.MasterView.CurrentRow.Cells["Description"].Value.ToString();
                    strExpression = grdOppList.MasterView.CurrentRow.Cells["Formula"].Value.ToString();
                    Common.timePeriods.strtp1 = grdOppList.MasterView.CurrentRow.Cells["T1"].Value.ToString().Split(',');
                    Common.timePeriods.strtp2 = grdOppList.MasterView.CurrentRow.Cells["T2"].Value.ToString().Split(',');
                    strPtnlFilter = grdOppList.MasterView.CurrentRow.Cells["ELGBL_FORMULA"].Value.ToString();
                    ddlOpportunityType.SelectedValue = grdOppList.MasterView.CurrentRow.Cells["OPP_ACTION"].Value.ToString();
                    ddlSource.SelectedValue = strExpression;
                    strPntlExpression = grdOppList.MasterView.CurrentRow.Cells["PTNL_FORMULA"].Value.ToString();
                    if (grdOppList.MasterView.CurrentRow.Cells["ISONMAIN"].Value.ToString() == "1")
                        bIsOnMain = true;
                    if (grdOppList.MasterView.CurrentRow.Cells["ISACTIVEID"].Value.ToString() == "1")
                        chkIsActive.Checked = true;
                    else
                        chkIsActive.Checked = false;
                    fnShowOpporunityList(false);

                    //ClsObj
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnOppNext_Click(object sender, EventArgs e)
        {
            fnShowOpporunityList(true);
        }
        private void pictNewThreshold_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                // iOpportunityId = 0;
                string strFormula = ddlSource.SelectedValue.ToString();

                if (ddlSource.SelectedValue.ToString().Trim() == "")
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Please select Opportunity Build.", "Opportunity", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                //if (strPtnlFilter == "")
                //{
                //    Telerik.WinControls.RadMessageBox.Show(this, "You have not selected Eligibility condition for the opportunity you wish to continue", "Opportunity", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                //}
                // pgThresholds.Controls.Clear();
                string[] strT1 = Common.timePeriods.strtp1;
                string[] strT2 = Common.timePeriods.strtp2;
                ctrlThreshold ctl = new ctrlThreshold(iOpportunityId, strFormula, Common.strPtnlFilter, strT1, strT2);
                if (ctl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bIsThresholdModified = true;
                    strCt = ctl.strCutOff.Split(';');
                    strCount = ctl.strCount.Split(';');
                    strAvg = ctl.strAvgDelta.Split(';');
                    // Common.strPtnlFilter="";
                }

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
        private void pctFilter_Click(object sender, EventArgs e)
        {
            bindingExpressionEditor((int)Enums.ExpressionType.Filter);
        }
        void bindingExpressionEditor(int iExpressionType)
        {
            try
            {
                clsDataSource clsDSOBJ = new clsDataSource();
                //   DataTable dt = clsDSOBJ.fnGetTreDetails(Common.strTableName);
                DataTable dt = clsDSOBJ.fnGetTreDetails("Tre_Random");
                DataTableReader dr = new DataTableReader(dt);
                DataTable dtSchema = dr.GetSchemaTable();

                using (var frm = new frmExpressEditor(iExpressionType, "Tre_Random", strPtnlFilter))
                {
                    frm._fieldDict = Common.GetDict(dt);
                    frm.AvailableFields = frm._fieldDict.ToList<KeyValuePair<string, Type>>();
                    frm.dtSource = dtSchema;
                    var res = frm.ShowDialog();

                    if (res == System.Windows.Forms.DialogResult.OK)
                    {
                        strPtnlFilter = frm.strExpression;
                        Common.strPtnlFilter = strPtnlFilter;
                    }
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void pctPotential_Click(object sender, EventArgs e)
        {
            try
            {
                clsOpportunities clsObj = new clsOpportunities();
                // frmExpressEditor frm = new frmExpressEditor();
                DataTable dt = new DataTable();
                DataTable dtSource = clsObj.fnGetBaseColumns(ref dt);

                //if (dtSource.Rows.Count == 0)
                //{
                //    Telerik.WinControls.RadMessageBox.Show(this, " First you need to set Threshold. ", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                //    //pgVRecommendation.SelectedPage = pgThresholds;
                //    return;
                //}

                // dtSource.Columns.Add(new DataColumn("OPPValue", typeof(decimal)));

                using (var frm = new frmExpressEditor((int)Enums.ExpressionType.Opp_ptnl, "ETS_TRE_BASE2", strPntlExpression))
                {
                    frm._fieldDict = Common.GetDict(dtSource);
                    frm.AvailableFields = frm._fieldDict.ToList<KeyValuePair<string, Type>>();
                    frm.dtSource = dt;
                    var res = frm.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.OK)
                    {
                        bIsPtnlModified = true;
                        strPntlExpression = frm.strExpression.Replace("FIELD.", "").Trim();
                        strPntlExpression = frm.strExpression.Replace("FIELD!", "").Trim();
                        //clsTre_Details clsTObj = new clsTre_Details();
                        //clsTObj.fnSaveOPPPotential(Common.sOpportunityName, iOpportunityId, Common.strTableName, strPntlExpression);
                    }
                }

            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dataRowArray = ((DataTable)this.grdOppList.DataSource).Select("Select=1");
                if ((int)dataRowArray.Length == 0)
                {
                    RadMessageBox.Show(this, "Select at least one Opportunity.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (RadMessageBox.Show(this, "Do you wish to delete selected Opportunity(s)?, you will lost all the info of the Opportunity(s)", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ArrayList arrayLists = new ArrayList();
                    string str = "";
                    int num = 0;
                    while (num < (int)dataRowArray.Length)
                    {
                        str = dataRowArray[num]["OPPORTUNITY_ID"].ToString();
                        if (!this.ClsObj.fnCheckOPPHasInRanking(string.Concat("'", dataRowArray[num]["OPP_NAME"].ToString(), "'"), Common.iProjectID))
                        {
                            arrayLists.Add(string.Concat(str, ";", dataRowArray[num]["OPP_NAME"].ToString()));
                            num++;
                        }
                        else
                        {
                            RadMessageBox.Show(this, "This opportunity is selected in Ranking, you can not delete this Opportunity", "Confirmation", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                            break;
                        }
                    }
                    if (arrayLists.Count <= 0 || this.ClsObj.fnDeleteOpportunity(arrayLists))
                    {
                        this.fnLoadOpportunity();
                    }
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
