
using System;
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
        DataTable dt = new DataTable();
        bool bDonotFireSelectionChange = false;
        int iCurrentRankID = 0;
        void fnBindRanking()
        {
            try
            {
                if(ddRankingCriteria.DataSource ==null)
                ddRankingCriteria.DataSource = Enum.GetValues(typeof(RecoEngine_BI.Enums.Rank_Criteria));
                bIsRankingLoaded = true;
                if (!bIsRankingLoaded)
                    fnShowOpportunityRanking();
                bIsRankingLoaded = true;
             
       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fnShowOpportunityRanking()
        {
            try
            {

                clsOpportunities clsObj = new clsOpportunities();
                bool bIsOpplist = false;
                dt = clsObj.fnGetOpportunity(Common.iProjectID,Common.iUserID, bIsOpplist);
               
                ddlOppRank4.Enabled = false;
                ddlOppRank3.Enabled = false;
                ddlOppRank2.Enabled = false;
                
                bDonotFireSelectionChange = true;
                ddlOppRank1.DataSource = dt;
                ddlOppRank1.SelectedValue = "";
                ddlOppRank1.SelectedText = "";
                ddlOppRank1.ValueMember = "OPPORTUNITY_ID";
                ddlOppRank1.DisplayMember = "OPP_NAME";


                ddlOppRank2.BindingContext = new BindingContext();
                ddlOppRank2.DataSource = dt;
                ddlOppRank2.SelectedValue = "";
                ddlOppRank2.SelectedText = "";
                ddlOppRank2.ValueMember = "OPPORTUNITY_ID";
                ddlOppRank2.DisplayMember = "OPP_NAME";


                ddlOppRank3.BindingContext = new BindingContext();
                ddlOppRank3.DataSource = dt;
                ddlOppRank3.SelectedValue = "";
                ddlOppRank3.SelectedText = "";
                ddlOppRank3.ValueMember = "OPPORTUNITY_ID";
                ddlOppRank3.DisplayMember = "OPP_NAME";


                ddlOppRank4.BindingContext = new BindingContext();
                ddlOppRank4.DataSource = dt;
                ddlOppRank4.SelectedValue = "";
                ddlOppRank4.SelectedText = "";
                ddlOppRank4.ValueMember = "OPPORTUNITY_ID";
                ddlOppRank4.DisplayMember = "OPP_NAME";

                bDonotFireSelectionChange = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ddlOppRank1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {



            if (bIsRankingLoaded && ddlOppRank1.SelectedIndex != -1 && ddlOppRank1.SelectedValue.ToString() != "")
            {

                if (dt.Rows.Count > 1)
                    ddlOppRank2.Enabled = true;


                if (ddlOppRank2.SelectedValue != null && int.Parse(ddlOppRank2.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank2.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank1.SelectedIndex = -1;
                        ddlOppRank1.Focus();
                        return;
                    }

                }
                if (ddlOppRank3.SelectedValue != null && int.Parse(ddlOppRank3.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank3.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank1.SelectedIndex = -1;
                        ddlOppRank1.Focus();
                        return;
                    }

                }
                if (ddlOppRank4.SelectedValue != null && int.Parse(ddlOppRank4.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank4.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank1.SelectedIndex = -1;
                        ddlOppRank1.Focus();
                        return;
                    }

                }
            }

        }
        private void ddlOppRank2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            //ddlOppRank3.Enabled = false;
            //ddlOppRank4.Enabled = false;
            if (ddlOppRank2.SelectedIndex != -1)
            {
                if (dt.Rows.Count > 2)
                    ddlOppRank3.Enabled = true;

                if (ddlOppRank1.SelectedIndex != -1 && ddlOppRank1.SelectedValue != null && int.Parse(ddlOppRank1.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank2.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank2.SelectedIndex = -1;
                        ddlOppRank2.Focus();
                        return;
                    }

                }

                if (ddlOppRank3.SelectedIndex != -1 && ddlOppRank3.SelectedValue != null && int.Parse(ddlOppRank3.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank3.SelectedValue.ToString() == ddlOppRank2.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank2.SelectedIndex = -1;
                        ddlOppRank2.Focus();
                        return;
                    }
                }
                if (ddlOppRank4.SelectedIndex != -1 && ddlOppRank4.SelectedValue != null && int.Parse(ddlOppRank4.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank4.SelectedValue.ToString() == ddlOppRank2.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank2.SelectedIndex = -1;
                        ddlOppRank2.Focus();
                        return;
                    }

                }
            }


        }
        private void ddlOppRank3_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            //ddlOppRank4.Enabled = false;

            if (ddlOppRank3.SelectedIndex != -1)
            {
                if (dt.Rows.Count > 3)
                    ddlOppRank4.Enabled = true;
                if (ddlOppRank1.SelectedIndex != -1 && ddlOppRank1.SelectedValue != null && int.Parse(ddlOppRank1.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank3.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank3.SelectedIndex = -1;
                        ddlOppRank3.Focus();
                        return;
                    }

                }



                if (ddlOppRank2.SelectedIndex != -1 && ddlOppRank2.SelectedValue != null && int.Parse(ddlOppRank2.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank2.SelectedValue.ToString() == ddlOppRank3.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank3.SelectedIndex = -1;
                        ddlOppRank3.Focus();
                        return;
                    }

                }

                if (ddlOppRank4.SelectedIndex != -1 && ddlOppRank4.SelectedValue != null && int.Parse(ddlOppRank4.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank4.SelectedValue.ToString() == ddlOppRank3.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank3.SelectedIndex = -1;
                        ddlOppRank3.Focus();
                        return;
                    }

                }


            }
        }
        private void ddlOppRank4_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (ddlOppRank4.SelectedIndex != -1)
            {
                bDonotFireSelectionChange = true;
                if (ddlOppRank1.SelectedIndex != -1 && ddlOppRank1.SelectedValue != null && int.Parse(ddlOppRank1.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank4.SelectedValue.ToString() == ddlOppRank1.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank4.SelectedIndex = -1;
                        ddlOppRank4.Focus();
                        return;
                    }

                }

                if (ddlOppRank2.SelectedIndex != -1 && ddlOppRank2.SelectedValue != null && int.Parse(ddlOppRank2.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank2.SelectedValue.ToString() == ddlOppRank4.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank4.SelectedIndex = -1;
                        ddlOppRank4.Focus();
                        return;
                    }
                }


                if (ddlOppRank3.SelectedIndex != -1 && ddlOppRank3.SelectedValue != null && int.Parse(ddlOppRank3.SelectedValue.ToString()) > 0)
                {
                    if (ddlOppRank3.SelectedValue.ToString() == ddlOppRank4.SelectedValue.ToString())
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "This Opportunity hase been selected for another rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        ddlOppRank4.SelectedIndex = -1;
                        ddlOppRank4.Focus();
                        return;
                    }
                }


            }
        }
        private void ddRankingCriteria_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddRankingCriteria.SelectedItem.ToString() == RecoEngine_BI.Enums.Rank_Criteria.Potential.ToString())
            {
                ddlOppRank1.Enabled = false;
                ddlOppRank2.Enabled = false;
                ddlOppRank3.Enabled = false;
                ddlOppRank4.Enabled = false;
            }
            else
            {
                ddlOppRank1.Enabled = true;
                ddlOppRank2.Enabled = true;
                ddlOppRank3.Enabled = true;
                ddlOppRank4.Enabled = true;
                fnShowOpportunityRanking();
            
            }
        }
        private void btnRnkngSave_Click(object sender, EventArgs e)
        {
            try
            {

                string strTimperiod = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp1);
                string strTimperiod1 = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp2);
                if (!this.objRanking.fnCheckOpportunityExists(Common.iProjectID))
                {
                    RadMessageBox.Show(this, "There are no Opportunities to do ranking ", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else if (this.ddRankingCriteria.SelectedItem.ToString() != Enums.Rank_Criteria.Custom.ToString())
                {
                    string str = "NULL";
                    string str1 = "NULL";
                    string str2 = "NULL";
                    string str3 = "NULL";
                    this.ClsObj.fnSaveOPPRanking("Potential", Common.iProjectID, str, str1, str2, str3);

                    if (this.ClsObj.fnRunOPoortunitiesfrmProcedure(Common.iProjectID, Common.strTableName, strTimperiod, strTimperiod1, true))
                    {
                        this.objRanking.fnPotentialRanking(Common.iProjectID);
                        this.fnBindRanking();
                    }
                }
                else if (this.ddlOppRank1.SelectedIndex != -1 || this.ddlOppRank2.SelectedIndex != -1 || this.ddlOppRank3.SelectedIndex != -1 || this.ddlOppRank4.SelectedIndex != -1)
                {
                    string str4 = "";
                    string str5 = "";
                    string str6 = "";
                    if (this.ddlOppRank1.SelectedValue != null)
                    {
                        if (this.ddlOppRank2.SelectedIndex != -1)
                        {
                            str4 = this.ddlOppRank2.SelectedItem.ToString();
                            if (str4 == this.ddlOppRank1.SelectedValue.ToString())
                            {
                                RadMessageBox.Show(this, "An Opportunity is Selected for More then One Rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                                this.ddlOppRank2.Focus();
                                return;
                            }
                        }
                        else if (this.ddlOppRank2.SelectedIndex == -1 && this.ddlOppRank2.Enabled)
                        {
                            RadMessageBox.Show(this, "Please Select the Opportunity for Rank 2.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            this.ddlOppRank4.Focus();
                            return;
                        }
                        if (this.ddlOppRank3.SelectedIndex != -1)
                        {
                            str5 = this.ddlOppRank3.SelectedItem.ToString();
                            if (str5 == str4 || str5 == this.ddlOppRank1.SelectedValue.ToString())
                            {
                                RadMessageBox.Show(this, "An Opportunity is Selected for More then One Rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                                this.ddlOppRank3.Focus();
                                return;
                            }
                        }
                        else if (this.ddlOppRank3.SelectedIndex == -1 && this.ddlOppRank3.Enabled)
                        {
                            RadMessageBox.Show(this, "Please Select the Opportunity for Rank 3.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            this.ddlOppRank4.Focus();
                            return;
                        }
                        if (this.ddlOppRank4.SelectedIndex != -1)
                        {
                            str6 = this.ddlOppRank4.SelectedItem.ToString();
                            if (str6 == str5 || str6 == str4 || str6 == this.ddlOppRank1.SelectedValue.ToString())
                            {
                                RadMessageBox.Show(this, "An Opportunity is Selected for More then One Rank.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                                this.ddlOppRank4.Focus();
                                return;
                            }
                        }
                        else if (this.ddlOppRank4.SelectedIndex == -1 && this.ddlOppRank4.Enabled)
                        {
                            RadMessageBox.Show(this, "Please Select the Opportunity for Rank 4.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            this.ddlOppRank4.Focus();
                            return;
                        }
                        if (this.ClsObj.fnRunOPoortunitiesfrmProcedure(Common.iProjectID, Common.strTableName, strTimperiod, strTimperiod1, true))
                        {
                            this.ClsObj.fnSaveOPPRanking("Custom", Common.iProjectID, this.ddlOppRank1.SelectedItem.ToString(), str4, str5, str6);
                            this.objRanking.fnCustomRanking(Common.iProjectID, this.ddlOppRank1.SelectedItem.ToString(), str4, str5, str6);
                            this.fnBindRanking();
                        }
                       
                    }
                    else
                    {
                        RadMessageBox.Show(this, "Please select opportunity 1.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        this.ddlOppRank1.Focus();
                        return;
                    }
                }
                else
                {
                    RadMessageBox.Show(this, "Please select the opportunity.", "Opportunity Ranking", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    this.ddlOppRank1.Focus();
                    return;
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
