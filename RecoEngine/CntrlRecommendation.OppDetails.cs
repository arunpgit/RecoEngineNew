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
        string strMainFilter = "";
        AlertForm alert;
        void fnShowOpportunitiesDetails()
        {
            try
            {
                DataTable dt = new DataTable();
               
                dt = clstreDetails.fnGetOpportunityDetails(Common.iProjectID);
                grdOpportunities.DataSource = dt;
                grdOpportunities.MasterTemplate.Refresh(null); 
                grdOpportunities.AllowAddNewRow = false;
                grdOpportunities.ShowRowHeaderColumn = false;
                grdOpportunities.EnableGrouping = false;
                grdOpportunities.ShowFilteringRow = false;
                grdOpportunities.AutoSizeRows = false;
                grdOpportunities.AllowEditRow = false;
                grdOpportunities.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
                grdOpportunities.BestFitColumns();

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    grdOpportunities.MasterTemplate.Columns[i].Width = 100;
                }

                grdOpportunities.AutoScroll = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadMessageBox.Show(this, "This will apply the rules on the entire dataset, are you sure you want to continue", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Info).ToString() == "Yes")
                {
                    if (this.objRanking.fnRankingcriteria(Common.iProjectID).Rows.Count <= 0)
                    {
                        RadMessageBox.Show(this, "Select the  Ranking Criteria ,Inorder to run Opportunities ", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        this.alert = new AlertForm();
                        this.alert.SetMessage("Loading data. Please wait...");
                        this.alert.TopMost = true;
                        this.alert.StartPosition = FormStartPosition.CenterScreen;
                        this.alert.Show();
                        this.alert.Refresh();
                        this.fnCreateView();
                        string str = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp1);
                        string str1 = this.clstreDetails.fnBuildTimePeriod(Common.timePeriods.strtp2);
                        this.clstreDetails.fnDeleteTreOppfrmExport();
                        if (this.ClsObj.fnRunOPoortunities(Common.iProjectID, Common.strTableName, str, str1, this.strMainFilter))
                        {
                            this.objRanking.fnMainRankingfrmExport(Common.iProjectID);
                            this.fnShowOpportunitiesDetails();
                        }
                        this.alert.Close();
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

        private void fnCreateView()
        {
            string str = "";
            clsDataSource _clsDataSource = new clsDataSource();
            this.strMainFilter = _clsDataSource.fnselectFilterCondition(Common.iProjectID);
            DataTable dataTable = _clsDataSource.fnGetTreDetailsSchema(Common.strTableName);
            foreach (DataRow row in dataTable.Rows)
            {
                str = string.Concat(str, row[0].ToString());
                str = string.Concat(str, ",");
            }
            dataTable = _clsDataSource.fnGetCalaculatedColMappingData(Common.iProjectID, Common.strTableName);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                str = string.Concat(str, dataRow["COMBINE_COLUMNS"].ToString(), " ", dataRow["COLNAME"].ToString());
                str = string.Concat(str, ",");
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1, 1);
            }
            this.clstreDetails.fnCreateTableView(Common.strTableName, str, this.strMainFilter);
        }
    }
}
