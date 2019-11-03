using RecoEngine_BI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace RecoEngine
{
    public partial class CntrlExport : UserControl
    {
        private clsExport objExport = new clsExport();

        private clsProjects clsProjObj = new clsProjects();

        private clsRanking objRanking = new clsRanking();

        private clsTre_Details clstreDetails = new clsTre_Details();

        private clsCampaign objCampaigns = new clsCampaign();

        private clsOpportunities ClsObj = new clsOpportunities();

        private clsDataSource objDatsource = new clsDataSource();

        private bool bIsControlGroup;

        private string strBaseCustomers;

        private bool bIsFixedCustomers;

        private bool bIsInsertintoDBs;

        private AlertForm alert;

        public CntrlExport()
        {
            this.InitializeComponent();
            base.Load += new EventHandler(this.CntrlExport_Load);
        }

        private void BindingTimeperiods()
        {
            this.bndgcntrlchkDropDowntp1(this.chkddlTP1, true);
            this.bndgcntrlchkDropDowntp1(this.cntrlchkDropDowntp2, false);
        }

        private void bndgcntrlchkDropDowntp1(CntrlchkDropDown ctrl, bool bIsT1)
        {
            try
            {
                DataTable dataTable = this.clstreDetails.fnTREtimeperiods(Common.strTableName);
                DataSet dataSet = new DataSet();
                string str = "Selected";
                dataTable.Columns.Add(new DataColumn("Selected", typeof(bool)));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((!bIsT1 || i != 1 && i != 2 && i != 3) && (bIsT1 || i != 0))
                    {
                        dataTable.Rows[i]["Selected"] = false;
                    }
                    else
                    {
                        dataTable.Rows[i]["Selected"] = true;
                    }
                }
                dataTable.Columns["Selected"].SetOrdinal(0);
                dataSet.Tables.Add(dataTable);
                ctrl.ConfigureDropDown(dataSet, str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void btnRunPrjct_Click(object sender, EventArgs e)
        {
            try
            {
                this.alert = new AlertForm();
                this.alert.SetMessage("Loading data. Please wait...");
                this.alert.TopMost = true;
                this.alert.StartPosition = FormStartPosition.CenterScreen;
                this.alert.Show();
                this.alert.Refresh();
                int num = 0;
                num = Convert.ToInt16(cmbProject.SelectedValue);
                Common.iProjectID = num;
                base.Show();
                this.fnRunProject(num);
                this.alert.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSaveExports_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.chkRanking1.Checked)
                {
                    str = "PR_Rank1";
                }
                if (this.chkRanking2.Checked)
                {
                    str = (str == "" ? string.Concat(str, "PR_Rank2") : string.Concat(str, ",PR_Rank2"));
                }
                if (this.chkRanking3.Checked)
                {
                    str = (str == "" ? string.Concat(str, "PR_Rank3") : string.Concat(str, ",PR_Rank3"));
                }
                if (this.chkRanking4.Checked)
                {
                    str = (str == "" ? string.Concat(str, "PR_Rank4") : string.Concat(str, ",PR_Rank4"));
                }
                if (str != "")
                {
                    if (this.chkControlGroup.Checked)
                    {
                        this.bIsControlGroup = true;
                    }
                    if (this.chkDbExport.Checked && this.chkFileExport.Checked)
                    {
                        RadMessageBox.Show(this, "Please Select only one either DataBase or File", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        this.chkDbExport.Checked = false;
                        this.chkFileExport.Checked = false;
                    }
                    else if (!this.bIsControlGroup || !(this.txtFixedCustomers.Text != "") || !(this.txtBasePercent.Text != ""))
                    {
                        if (this.txtFixedCustomers.Text.Trim() == "")
                        {
                            this.strBaseCustomers = this.txtBasePercent.Text;
                        }
                        else
                        {
                            this.bIsFixedCustomers = true;
                            this.strBaseCustomers = this.txtFixedCustomers.Text;
                        }
                        if (!this.bIsControlGroup || !(this.strBaseCustomers == ""))
                        {
                            if (!this.chkDbExport.Checked)
                            {
                                this.bIsInsertintoDBs = false;
                            }
                            else
                            {
                                this.bIsInsertintoDBs = true;
                            }
                            if (!this.chkDbExport.Checked && !this.chkFileExport.Checked)
                            {
                                RadMessageBox.Show(this, "Please Select any one either File or DataBase", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            else if (this.chkDbExport.Checked && this.chkFileExport.Checked)
                            {
                                this.chkDbExport.Checked = false;
                                this.chkFileExport.Checked = false;
                                RadMessageBox.Show(this, "Please Select Only one either File or DataBase", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            else if (this.objExport.fnInsertExportSettings((this.bIsControlGroup ? 'T' : 'F'), this.strBaseCustomers, (this.bIsFixedCustomers ? 'T' : 'F'), (this.bIsInsertintoDBs ? 'T' : 'F'), Common.iProjectID, str, this.txtMinimum.Text, this.txtMaximum.Text))
                            {
                                MessageBox.Show("Export Settings saved sucessfully");
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(this, "Please Select any one either Percentage or Fixed Customers", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, "Please Select only one either Percentage or Fixed Customers", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        this.txtFixedCustomers.Text = "";
                        this.txtBasePercent.Text = "";
                    }
                }
                else
                {
                    RadMessageBox.Show(this, "Please Select One Of the Ranknigs", "Export", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void chkControlGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkControlGroup.Checked)
            {
                this.txtBasePercent.Enabled = false;
                this.txtFixedCustomers.Enabled = false;
                return;
            }
            this.txtBasePercent.Enabled = true;
            this.txtFixedCustomers.Enabled = true;
        }

        private void chkMaxRanking_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkMaxRanking.Checked)
            {
                this.txtMaximum.Enabled = false;
                return;
            }
            this.txtMaximum.Enabled = true;
        }

        private void chkMinRanking_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkMinRanking.Checked)
            {
                this.txtMinimum.Enabled = false;
                return;
            }
            this.txtMinimum.Enabled = true;
        }

        private void chkRanking1_CheckedChanged(object sender, EventArgs e)
        {
            string name = (sender as CheckBox).Name;
            string str = name;
            if (name != null)
            {
                if (str == "chkRanking1")
                {
                    this.chkRanking2.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking3.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking2.Checked = false;
                    this.chkRanking2.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking3.Checked = false;
                    this.chkRanking3.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.Checked = false;
                    this.chkRanking4.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    return;
                }
                if (str == "chkRanking2")
                {
                    this.chkRanking1.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking3.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking1.Checked = false;
                    this.chkRanking1.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking3.Checked = false;
                    this.chkRanking3.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.Checked = false;
                    this.chkRanking4.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    return;
                }
                if (str == "chkRanking3")
                {
                    this.chkRanking2.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking1.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking2.Checked = false;
                    this.chkRanking2.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking1.Checked = false;
                    this.chkRanking1.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    this.chkRanking4.Checked = false;
                    this.chkRanking4.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                    return;
                }
                if (str != "chkRanking4")
                {
                    return;
                }
                this.chkRanking2.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                this.chkRanking3.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                this.chkRanking1.CheckedChanged -= new EventHandler(this.chkRanking1_CheckedChanged);
                this.chkRanking2.Checked = false;
                this.chkRanking2.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                this.chkRanking3.Checked = false;
                this.chkRanking3.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
                this.chkRanking1.Checked = false;
                this.chkRanking1.CheckedChanged += new EventHandler(this.chkRanking1_CheckedChanged);
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Common.iProjectID = Convert.ToInt16(this.cmbProject.SelectedValue);
                DataTable dataTable = this.objExport.fnGetCountValues(Common.iProjectID, Common.strTableName);
                this.lblCustomers.Text = "";
                this.lblSegment.Text = "";
                this.lblOffer.Text = "";
                this.lblCampaign.Text = "";
                this.lblCustomers.Text = dataTable.Rows[0]["CUSTOMERS"].ToString();
                this.lblSegment.Text = dataTable.Rows[0]["SEGMENT"].ToString();
                this.lblOffer.Text = dataTable.Rows[0]["OFFERS"].ToString();
                this.lblCampaign.Text = dataTable.Rows[0]["CAMPAIGNS"].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CntrlExport_Load(object sender, EventArgs e)
        {
            try
            {
                this.fillLabels();
                this.BindingTimeperiods();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void fillLabels()
        {
            try
            {
                DataTable dataTable = this.objExport.fnGetCountValues(Common.iProjectID, Common.strTableName);
                this.lblCustomers.Text = "";
                this.lblSegment.Text = "";
                this.lblOffer.Text = "";
                this.lblCampaign.Text = "";
                this.lblCustomers.Text = dataTable.Rows[0]["CUSTOMERS"].ToString();
                this.lblSegment.Text = dataTable.Rows[0]["SEGMENT"].ToString();
                this.lblOffer.Text = dataTable.Rows[0]["OFFERS"].ToString();
                this.lblCampaign.Text = dataTable.Rows[0]["CAMPAIGNS"].ToString();
                DataTable dataTable1 = this.clsProjObj.fnGetProjectNames(Common.iUserID);
                this.cmbProject.DisplayMember = "Name";
                this.cmbProject.ValueMember = "Project_Id";
                this.cmbProject.DataSource = dataTable1;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool fnCheckExport(int iProjectId)
        {
            if (this.objExport.fnSelectExportSettings(iProjectId).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void fnExport()
        {
            try
            {
                foreach (DataRow row in this.objExport.fnGetCampaigns(Common.iProjectID).Rows)
                {
                    DataTable dataTable = this.objExport.fnSelectExportSettings(Common.iProjectID);
                    if (dataTable.Rows.Count <= 0)
                    {
                        continue;
                    }
                    string[] strArrays = dataTable.Rows[0]["RANKING"].ToString().Split(new char[] { ',' });
                    string str = "( ";
                    int num = Convert.ToInt16(row["Campaign_Id"]);
                    string[] strArrays1 = strArrays;
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        string str1 = strArrays1[i];
                        object obj = str;
                        object[] objArray = new object[] { obj, str1, "=", num, " OR " };
                        str = string.Concat(objArray);
                    }
                    str = str.Substring(0, str.Length - 3);
                    str = string.Concat(str, ")");
                    DataTable dataTable1 = new DataTable();
                    DataTable file = this.objExport.fnExportToFile((dataTable.Rows[0]["ISCONTROLGROUP"].ToString() == "T" ? true : false), (dataTable.Rows[0]["ISFIXEDCUSTOMER"].ToString() == "T" ? true : false), dataTable.Rows[0]["BASECUSTOMERS"].ToString(), Convert.ToString(dataTable.Rows[0]["MAXLIMIT"]), Convert.ToString(dataTable.Rows[0]["MINLIMIT"].ToString()), Common.iProjectID, num, str, ref dataTable1);
                    if (file.Rows.Count > 0 && dataTable1.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            DataRow dataRow1 = file.AsEnumerable().Where<DataRow>((DataRow r) => r["CUSTOMER"].Equals(dataRow["CUSTOMER"])).First<DataRow>();
                            dataRow1["CG"] = 'N';
                        }
                    }
                    var collection =
                        from table in file.AsEnumerable()
                        group table by new { placeCol = table["RANKING"] } into groupby
                        select new { Value = groupby.Key, ColumnValues = groupby };
                    foreach (var variable in collection)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        IEnumerable<string> columns =
                            from DataColumn column in file.Columns
                            select column.ColumnName;
                        stringBuilder.AppendLine(string.Join(",", columns));
                        foreach (DataRow columnValue in variable.ColumnValues)
                        {
                            object[] objArray1 = new object[] { columnValue["PROJECT_ID"].ToString(), variable.Value.placeCol.ToString(), num, columnValue["Customer"].ToString(), columnValue["CG"].ToString() };
                            stringBuilder.AppendLine(string.Join(",", objArray1));
                        }
                        object[] str2 = new object[] { "C:\\Users\\Public\\Downloads\\CampaignId", num, variable.Value.placeCol.ToString(), null, null };
                        str2[3] = DateTime.Now.ToString("yyyy-MM-dd");
                        str2[4] = ".txt";
                        File.WriteAllText(string.Concat(str2), stringBuilder.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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

    }
}