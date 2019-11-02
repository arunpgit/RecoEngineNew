using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecoEngine_BI;
using Telerik.WinControls;
using System.IO;
using System.Globalization;

namespace RecoEngine
{
    public partial class CntrlExport : UserControl
    {
        clsExport objExport = new clsExport();
        clsProjects clsProjObj = new clsProjects();
        clsRanking objRanking = new clsRanking();
        clsTre_Details clstreDetails = new clsTre_Details();
        clsCampaign objCampaigns = new clsCampaign();
        clsOpportunities ClsObj = new clsOpportunities();
        clsDataSource objDatsource = new clsDataSource();
        bool bIsControlGroup = false;
        string strBaseCustomers;
        bool bIsFixedCustomers = false;
        bool bIsInsertintoDBs = false;
        AlertForm alert;

        public CntrlExport()
        {
            InitializeComponent();
            this.Load += new EventHandler(CntrlExport_Load);
        }

        void CntrlExport_Load(object sender, EventArgs e)
        {
            try
            {
                fillLabels();
                BindingTimeperiods();
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnSaveExports_Click(object sender, EventArgs e)
        {
            try
            {
                string Ranking1 = "";

                if (chkRanking1.Checked == true)
                {
                    Ranking1 = "PR_Rank1";
                }
                if (chkRanking2.Checked == true)
                {
                    if (Ranking1 != "")
                        Ranking1 += ",PR_Rank2";
                    else
                        Ranking1 += "PR_Rank2";
                }
                if (chkRanking3.Checked == true)
                {
                    if (Ranking1 != "")
                        Ranking1 += ",PR_Rank3";
                    else
                        Ranking1 += "PR_Rank3";

                }
                if (chkRanking4.Checked == true)
                {
                    if (Ranking1 != "")
                        Ranking1 += ",PR_Rank4";
                    else
                        Ranking1 += "PR_Rank4";



                }
                if (Ranking1 == "")
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Please Select One Of the Ranknigs", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (chkControlGroup.Checked)
                    bIsControlGroup = true;
                if (chkDbExport.Checked && chkFileExport.Checked)
                {

                    Telerik.WinControls.RadMessageBox.Show(this, "Please Select only one either DataBase or File", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    chkDbExport.Checked = false;
                    chkFileExport.Checked = false;
                    return;
                }
                if (bIsControlGroup && txtFixedCustomers.Text != "" && txtBasePercent.Text != "")
                {

                    Telerik.WinControls.RadMessageBox.Show(this, "Please Select only one either Percentage or Fixed Customers", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtFixedCustomers.Text = "";
                    txtBasePercent.Text = "";
                    return;
                }

                if (txtFixedCustomers.Text.Trim() != "")
                {
                    bIsFixedCustomers = true;
                    strBaseCustomers = txtFixedCustomers.Text;
                }

                else
                    strBaseCustomers = txtBasePercent.Text;
                if (bIsControlGroup && strBaseCustomers == "")
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Please Select any one either Percentage or Fixed Customers", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                else
                {

                    if (chkDbExport.Checked)
                        bIsInsertintoDBs = true;
                    else
                        bIsInsertintoDBs = false;
                    if (!chkDbExport.Checked && !chkFileExport.Checked)
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "Please Select any one either File or DataBase", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (chkDbExport.Checked && chkFileExport.Checked)
                    {
                        chkDbExport.Checked = false;
                        chkFileExport.Checked = false;
                        Telerik.WinControls.RadMessageBox.Show(this, "Please Select Only one either File or DataBase", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    // char K=   bIsControlGroup=True?'T':'F'
                    if (objExport.fnInsertExportSettings(bIsControlGroup == true ? 'T' : 'F', strBaseCustomers, bIsFixedCustomers == true ? 'T' : 'F', bIsInsertintoDBs == true ? 'T' : 'F', Common.iProjectID, Ranking1, txtMinimum.Text, txtMaximum.Text))
                        MessageBox.Show("Export Settings saved sucessfully");
                }
            }
            catch (Exception ex)
            {

                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }
        private void chkControlGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkControlGroup.Checked)
            {
                txtBasePercent.Enabled = false;
                txtFixedCustomers.Enabled = false;
            }
            else
            {
                txtBasePercent.Enabled = true;
                txtFixedCustomers.Enabled = true;
            }
        }
        private void chkRanking1_CheckedChanged(object sender, EventArgs e)
        {
            string chkRanking = "";
            chkRanking = (sender as CheckBox).Name;
            switch (chkRanking)
            {
                case "chkRanking1":
                    chkRanking2.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking3.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking4.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking2.Checked = false;
                    chkRanking2.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking3.Checked = false;
                    chkRanking3.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking4.Checked = false;
                    chkRanking4.CheckedChanged += chkRanking1_CheckedChanged;
                    break;
                case "chkRanking2":
                    chkRanking1.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking3.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking4.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking1.Checked = false;
                    chkRanking1.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking3.Checked = false;
                    chkRanking3.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking4.Checked = false;
                    chkRanking4.CheckedChanged += chkRanking1_CheckedChanged;
                    break;
                case "chkRanking3":
                    chkRanking2.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking1.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking4.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking2.Checked = false;
                    chkRanking2.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking1.Checked = false;
                    chkRanking1.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking4.Checked = false;
                    chkRanking4.CheckedChanged += chkRanking1_CheckedChanged;
                    break;
                case "chkRanking4":
                    chkRanking2.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking3.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking1.CheckedChanged -= chkRanking1_CheckedChanged;
                    chkRanking2.Checked = false;
                    chkRanking2.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking3.Checked = false;
                    chkRanking3.CheckedChanged += chkRanking1_CheckedChanged;
                    chkRanking1.Checked = false;
                    chkRanking1.CheckedChanged += chkRanking1_CheckedChanged;
                    break;
            }

        }
        void fillLabels()
        {

            try
            {
                DataTable dt = objExport.fnGetCountValues(Common.iProjectID, Common.strTableName);
                lblCustomers.Text = "";
                lblSegment.Text = "";
                lblOffer.Text = "";
                lblCampaign.Text = "";
                lblCustomers.Text = dt.Rows[0]["CUSTOMERS"].ToString();
                lblSegment.Text = dt.Rows[0]["SEGMENT"].ToString();
                lblOffer.Text = dt.Rows[0]["OFFERS"].ToString();
                lblCampaign.Text = dt.Rows[0]["CAMPAIGNS"].ToString();
                DataTable dt1 = clsProjObj.fnGetProjectNames(Common.iUserID);
                cmbProject.DisplayMember = "Name";
                cmbProject.ValueMember = "Project_Id";
                cmbProject.DataSource = dt1;

            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        void BindingTimeperiods()
        {
            bndgcntrlchkDropDowntp1(chkddlTP1, true);
            bndgcntrlchkDropDowntp1(cntrlchkDropDowntp2, false);
        }
        void bndgcntrlchkDropDowntp1(CntrlchkDropDown ctrl, bool bIsT1)
        {
            try
            {
                DataTable dt = clstreDetails.fnTREtimeperiods(Common.strTableName);
                DataSet ds = new DataSet();
                string Selected = "Selected";
                dt.Columns.Add(new DataColumn("Selected", typeof(bool)));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bIsT1 && (i == 1 || i == 2 || i == 3)) || (!bIsT1 && (i == 0)))
                    {
                        dt.Rows[i]["Selected"] = true;
                    }
                    else
                    {
                        dt.Rows[i]["Selected"] = false;
                    }
                }
                dt.Columns["Selected"].SetOrdinal(0);
                //dt.Columns["timeperiod"].SetOrdinal(0);

                ds.Tables.Add(dt);
                ctrl.ConfigureDropDown(ds, Selected);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void fnExport()
        {

            try
            {
                DataTable dtCampaign = objExport.fnGetCampaigns(Common.iProjectID);
                foreach (DataRow drCamp in dtCampaign.Rows)
                {
                    DataTable dtExport = objExport.fnSelectExportSettings(Common.iProjectID);
                    if (dtExport.Rows.Count > 0)
                    {
                        var str_array = dtExport.Rows[0]["RANKING"].ToString().Split(',');
                        String Ranking = "( ";
                        int iCampaignId = Convert.ToInt16(drCamp["Campaign_Id"]);
                        foreach (string strRank in str_array)
                        {

                            //Ranking += strRank + "=" + iCampaignId + " OR ";
                            Ranking += "TRIM("+strRank +")"+ "=" +"'"+ iCampaignId +"'"+ " OR ";

                        }
                        Ranking = Ranking.Substring(0, Ranking.Length - 3);
                        Ranking += ")";

                        DataTable dtrndm = new DataTable();
                        DataTable dt = objExport.fnExportToFile(dtExport.Rows[0]["ISCONTROLGROUP"].ToString() == "T" ? true : false, dtExport.Rows[0]["ISFIXEDCUSTOMER"].ToString() == "T" ? true : false, dtExport.Rows[0]["BASECUSTOMERS"].ToString(), Convert.ToString(dtExport.Rows[0]["MAXLIMIT"]), Convert.ToString(dtExport.Rows[0]["MINLIMIT"].ToString()), Common.iProjectID, iCampaignId, Ranking, ref dtrndm);

                        if (dt.Rows.Count > 0)
                        {
                            if (dtrndm.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtrndm.Rows)
                                {
                                    DataRow drc = dt.AsEnumerable().Where(r => (r["CUSTOMER"]).Equals(dr["CUSTOMER"])).First(); // getting the row to edit , change it as you need
                                    drc["CG"] = 'N';
                                }
                            }
                        }

                        var groupbyCampaign = from table in dt.AsEnumerable()

                                              group table by new { placeCol = table["RANKING"] } into groupby

                                              select new

                                              {

                                                  Value = groupby.Key,

                                                  ColumnValues = groupby

                                              };
                        foreach (var key in groupbyCampaign)
                        {
                            StringBuilder sbma = new StringBuilder();
                            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                 Select(column => column.ColumnName);
                            sbma.AppendLine(string.Join(",", columnNames));
                            foreach (var columnValue in key.ColumnValues)
                            {
                                sbma.AppendLine(string.Join(",", columnValue["PROJECTID"].ToString(), key.Value.placeCol.ToString(), iCampaignId, columnValue["Customer"].ToString(), columnValue["CG"].ToString()));

                            }
                            File.WriteAllText(@"C:\Users\Public\Downloads\" + "CampaignId" + iCampaignId + key.Value.placeCol.ToString() + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", sbma.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
                                //if (dtfile.Rows.Count > 0)
                                //{
                                //    StringBuilder sb = new StringBuilder();
                                //    IEnumerable<string> columnNames = dtfile.Columns.Cast<DataColumn>().
                                //     Select(column => column.ColumnName);
                                //    sb.AppendLine(string.Join(",", columnNames));
                                //    foreach (DataRow row in dtfile.Rows)
                                //    {
                                //        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                                //        sb.AppendLine(string.Join(",", fields));
                                //    }
                                //    SaveFileDialog saveFiledialog = new SaveFileDialog();
                                //    string path = "";
                                //    File.WriteAllText(@"C:\Users\Public\Downloads\doc.txt", sb.ToString());

                                //    if (saveFiledialog.ShowDialog() == DialogResult.OK)
                                //    {
                                //        path = saveFiledialog.FileName;
                                //    }
                                //    if (path != "")
                                //        File.WriteAllText(@"C:\myfile", sb.ToString());

                                //}
                                //else
                                //{
                                //    Telerik.WinControls.RadMessageBox.Show(this, "There is no data to Export", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);

                                //}


        private bool fnCheckExport(int iProjectId)
        {
            DataTable dtExport = objExport.fnSelectExportSettings(iProjectId);
            if (dtExport.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;

        }

        private void btnRunPrjct_Click(object sender, EventArgs e)
        {
            try
            {
               // create a new instance of the alert form
                alert = new AlertForm();
                alert.SetMessage("Loading data. Please wait..."); // "Loading data. Please wait..."
                alert.TopMost = true;
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
                alert.Refresh();
                    // event handler for the Cancel button in AlertForm
                   // alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                     int iProjectID=0;
                     iProjectID = Convert.ToInt16(cmbProject.SelectedValue); ;
                    Common.iProjectID = iProjectID;
                    this.Show();
                   fnRunProject(iProjectID);
                    //fnExport();
                   alert.Close();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void fnRunProject(int iProjectID)
        {
            try
            {
                string str = this.chkddlTP1.m_TextBox.Text.ToString();
                char[] chrArray = new char[] { ';' };
                Common.timePeriods.strtp1 = str.Split(chrArray).ToArray<string>();
                string str1 = this.cntrlchkDropDowntp2.m_TextBox.Text.ToString();
                char[] chrArray1 = new char[] { ';' };
                Common.timePeriods.strtp2 = str1.Split(chrArray1).ToArray<string>();
                this.clstreDetails.fnInsertTREtimePeriodfrmExport(Common.timePeriods.strtp1, Common.timePeriods.strtp2, Common.strTableName, Common.iProjectID);
                string str2 = "";
                DataTable dataTable = this.objDatsource.fnGetTreDetailsSchema(Common.strTableName);
                foreach (DataRow row in dataTable.Rows)
                {
                    str2 = string.Concat(str2, row[0].ToString());
                    str2 = string.Concat(str2, ",");
                }
                dataTable = this.objDatsource.fnGetCalaculatedColMappingData(Common.iProjectID, Common.strTableName);
                string str3 = this.objDatsource.fnselectFilterCondition(Common.iProjectID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    str2 = string.Concat(str2, dataRow["COMBINE_COLUMNS"].ToString(), " ", dataRow["COLNAME"].ToString());
                    str2 = string.Concat(str2, ",");
                }
                if (str2.Length > 0)
                {
                    str2 = str2.Remove(str2.Length - 1, 1);
                }
                this.clstreDetails.fnCreateTableView(Common.strTableName, str2, str3);
                string str4 = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp1);
                string str5 = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp2);
                if (this.objRanking.fnRankingcriteria(iProjectID).Rows.Count <= 0)
                {
                    RadMessageBox.Show(this, "Ranking Criteria is not choosen for Selected Project", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (!this.fnCheckExport(Common.iProjectID))
                {
                    MessageBox.Show("Export Settings are not choosen");
                }
                else
                {
                    this.clstreDetails.fnDeleteTreOppfrmExport();
                    if (this.ClsObj.fnRunOPoortunitiesfrmExport(iProjectID, Common.strTableName, str4, str5, str3))
                    {
                        this.objRanking.fnMainRankingfrmExport(iProjectID);
                        this.objCampaigns.fnDelteCampaignRankingsfrmExport(Common.iProjectID, Common.strTableName);
                        DataTable dataTable1 = this.objExport.fnGetCampaigns(iProjectID);
                        if (dataTable1.Rows.Count <= 0)
                        {
                            RadMessageBox.Show(this, "There are no campaigns to export", "", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            foreach (DataRow row1 in dataTable1.Rows)
                            {
                                this.objCampaigns.fnSaveCampaignRankingsfrmExport(row1["ELIGIBILITY"].ToString(), Convert.ToInt16(row1["PROJECT_ID"]), row1["SEGMENT_DESCRIPTION"].ToString(), Convert.ToInt16(row1["CAMPAIGN_ID"]), Common.strTableName, str3);
                            }
                            this.objCampaigns.fnPrioritizeRankingsfrmExport(Common.iProjectID, "Average");
                            this.fnExport();
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.alert.Close();
                MessageBox.Show(exception.Message);
            }
        }

        private void chkMinRanking_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMinRanking.Checked)
            {
               
                txtMinimum.Enabled = false;
            }
            else
            {
                //txtBasePercent.Enabled = true;
                txtMinimum.Enabled = true;
            }

        }

        private void chkMaxRanking_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMaxRanking.Checked)
            {
                txtMaximum.Enabled = false;
            }
            else
            {
                txtMaximum.Enabled = true;
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Common.iProjectID = Convert.ToInt16(cmbProject.SelectedValue); ;
                DataTable dt = objExport.fnGetCountValues(Common.iProjectID, Common.strTableName);
                lblCustomers.Text = "";
                lblSegment.Text = "";
                lblOffer.Text = "";
                lblCampaign.Text = "";
                lblCustomers.Text = dt.Rows[0]["CUSTOMERS"].ToString();
                lblSegment.Text = dt.Rows[0]["SEGMENT"].ToString();
                lblOffer.Text = dt.Rows[0]["OFFERS"].ToString();
                lblCampaign.Text = dt.Rows[0]["CAMPAIGNS"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }
        }

        // This event handler is where the time-consuming work is done.
        
    }
}