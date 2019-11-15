using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecoEngine_DataLayer;
using RecoEngine_BI;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using NhibernateclassGeneration;
using NhibernateclassGeneration.Domain;
using NhibernateclassGeneration.Reader;
using System.Configuration;
using System.IO;

namespace RecoEngine
{
    public partial class CntrlDataFields : UserControl
    {
        private IMetadataReader metadataReader;
        clsDataSource clsDSOBJ = new clsDataSource();
        public event EventHandler DataFieldsNxtBtnClick;
        bool bIsLoaded = false;
        DataTable dtmain = new DataTable();
        public CntrlDataFields()
        {
            InitializeComponent();

        }
        private void CntrlDataFields_Load(object sender, EventArgs e)
        {

            try
            {
                gbMain.Padding = new Padding(0, 0, 0, 0);
                dataschemaGrid.DoubleClick += new EventHandler(dataschemaGrid_DoubleClick);
                fnLoadTableName();
                dataschemaGridbinding();
                bIsLoaded = true;
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                Common.LogMessage(ex);
            }
        }

        void dataschemaGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataschemaGrid.CurrentRow != null)
                {
                    GridViewRowInfo drRow = dataschemaGrid.CurrentRow;
                    if (drRow.Cells["Table"].Value.ToString() == "C")
                    {

                        DataTable dtcalaculated = clsDSOBJ.fnGetCalaculatedColMappingData(Common.iProjectID,Common.strTableName);
                        string str=drRow.Cells["ColumnName"].Value.ToString() ;
                        DataRow[] dtrows = dtcalaculated.Select("COLNAME = '" + str +"'");
                        bindingExpressionEditor((int)Enums.ExpressionType.CalaculatedColumn, dtrows[0]["COMBINE_COLUMNS"].ToString(), dtrows[0]["COLNAME"].ToString());
            
        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        void fnLoadTableName()
        {
            try
            {
                DataTable dtTbl = new DataTable();

                dtTbl = clsDSOBJ.fnGetTableNames();

                ddlTableName.DataSource = dtTbl;
                ddlTableName.ValueMember = "TNAME";
                ddlTableName.DisplayMember = "TNAME";

                if (Common.strTableName != "")
                    
                    ddlTableName.SelectedIndex = ddlTableName.Items.IndexOf(Common.strTableName.ToLower());
                
                else
                    ddlTableName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dataschemaGridbinding()
        {
            object obj;
            try
            {
                DataTable item = this.clsDSOBJ.fnGetTreDetailsSchema(this.ddlTableName.SelectedValue.ToString());
                DataTable dataTable = this.clsDSOBJ.fnGetCalaculatedColMappingData(Common.iProjectID, Common.strTableName);
                DataTable dataTable1 = this.clsDSOBJ.fnGetColMappingData(Common.iProjectID);
                item.Columns.Add(new DataColumn("Table", typeof(string)));
                item.Columns.Add(new DataColumn("Type", typeof(int)));
                item.Columns.Add(new DataColumn("Required", typeof(bool)));
                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow str = item.NewRow();
                    str["ColumnName"] = row["COLNAME"].ToString();
                    str["Table"] = "C";
                    DataRow dataRow = str;
                    if (row["COLDATATYPE"].ToString() == "NUMBER" || row["COLDATATYPE"].ToString() == "double")
                    {
                        obj = typeof(decimal);
                    }
                    else
                    {
                        obj = (row["COLDATATYPE"].ToString() == "DATE" ? typeof(DateTime) : typeof(string));
                    }
                    dataRow["DataType"] = obj;
                    item.Rows.Add(str);
                }
                for (int i = 0; i < item.Rows.Count; i++)
                {
                    if (dataTable1.Rows.Count <= 0)
                    {
                        item.Rows[i]["Type"] = 5;
                        if (item.Rows[i]["Table"] != null)
                        {
                            item.Rows[i]["Table"] = "M";
                        }
                        item.Rows[i]["Required"] = false;
                    }
                    else
                    {
                        DataRow[] dataRowArray = dataTable1.Select(string.Concat("COLNAME='", item.Rows[i][0].ToString(), "'"));
                        if ((int)dataRowArray.Length <= 0 || !(dataRowArray[0]["TABLENAME"].ToString().ToLower() == this.ddlTableName.SelectedValue.ToString().ToLower()))
                        {
                            item.Rows[i]["Type"] = 5;
                            if ( item.Rows[i]["Table"].ToString() != "C")
                            {
                                item.Rows[i]["Table"] = "M";
                            }
                            item.Rows[i]["Required"] = false;
                        }
                        else
                        {
                            item.Rows[i]["Type"] = dataRowArray[0]["Type"];
                            item.Rows[i]["Required"] = dataRowArray[0]["ISREQUIRED"];
                            if (item.Rows[i]["Table"].ToString() != "C")
                            {
                                item.Rows[i]["Table"] = "M";
                            }
                        }
                    }
                }
                this.dataschemaGrid.DataSource = item;
                GridViewComboBoxColumn gridViewComboBoxColumn = new GridViewComboBoxColumn()
                {
                    HeaderText = "Type",
                    ValueMember = "TypeId",
                    DisplayMember = "Type",
                    FieldName = "Type",
                    DataSource = this.clsDSOBJ.fnCreateColTypes(),
                    Width = 200
                };
                if (this.dataschemaGrid.MasterTemplate.Columns.Contains("Type1"))
                {
                    this.dataschemaGrid.MasterTemplate.Columns.Remove("Type1");
                }
                this.dataschemaGrid.MasterTemplate.Columns.Add(gridViewComboBoxColumn);
                this.dataschemaGrid.Columns["ColumnName"].ReadOnly = true;
                this.dataschemaGrid.Columns["DataType"].ReadOnly = true;
                this.dataschemaGrid.Columns["Type"].ReadOnly = true;
                this.dataschemaGrid.Columns["Type"].IsVisible = false;
                this.dataschemaGrid.Columns["Table"].IsVisible = true;
                this.dataschemaGrid.Columns[0].Width = 200;
                this.dataschemaGrid.Columns["DataType"].Width = 300;
                this.dataschemaGrid.Columns["Required"].Width = 50;
                this.dataschemaGrid.Columns["Table"].Width = 30;
                this.dataschemaGrid.Columns.Remove("NumericPrecision");
                this.dataschemaGrid.Columns.Remove("NumericScale");
                this.dataschemaGrid.Columns.Remove("ProviderType");
                this.dataschemaGrid.Columns.Remove("IsLong");
                this.dataschemaGrid.Columns.Remove("AllowDBNull");
                this.dataschemaGrid.Columns.Remove("IsReadOnly");
                this.dataschemaGrid.Columns.Remove("IsUnique");
                this.dataschemaGrid.Columns.Remove("IsKey");
                this.dataschemaGrid.Columns.Remove("IsAutoIncrement");
                this.dataschemaGrid.Columns.Remove("IsRowVersion");
                this.dataschemaGrid.Columns.Remove("ColumnMapping");
                this.dataschemaGrid.Columns.Remove("AutoIncrementSeed");
                this.dataschemaGrid.Columns.Remove("AutoIncrementStep");
                this.dataschemaGrid.Columns.Remove("BaseCatalogName");
                this.dataschemaGrid.Columns.Remove("BaseSchemaName");
                this.dataschemaGrid.Columns.Remove("BaseTableName");
                this.dataschemaGrid.Columns.Remove("BaseTableNameSpace");
                this.dataschemaGrid.Columns.Remove("BaseColumnName");
                this.dataschemaGrid.Columns.Remove("BaseColumnNameSpace");
                this.dataschemaGrid.Columns.Remove("Expression");
                this.dataschemaGrid.Columns.Remove("DefaultValue");
                this.dataschemaGrid.Columns.Remove("ColumnOrdinal");
                this.dataschemaGrid.Columns.Remove("ColumnSize");
                this.dataschemaGrid.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                this.dataschemaGrid.CellValueChanged += new GridViewCellEventHandler(this.dataschemaGrid_CellValueChanged);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        void dataschemaGrid_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (dataschemaGrid.CurrentRow != null)
                {
                    GridViewRowInfo drRow = dataschemaGrid.CurrentRow;
                   // drRow.Cells["Flag"].Value = "Y";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
       
            //if ((e.Column.Name.ToLower() == "type1"))
            //{
            //    if (Convert.ToInt16(e.Value) == (int)Enums.ColType.None)
            //    {
            //        drRow.Cells["Flag"].Value = "N";
            //    }
            //    else
            //    {
            //        drRow.Cells["Flag"].Value = "Y";
            //    }

            //}
            //else if (e.Column.Name.ToLower() == "required")
            //{
            //    if (Convert.ToInt16(drRow.Cells["type1"].Value) == (int)Enums.ColType.None)
            //    {
            //        drRow.Cells["Flag"].Value = "N";
            //    }
            //    else
            //        drRow.Cells["Flag"].Value = "Y";
            //}

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
               // generateMapclass();
                string strTabName = ddlTableName.SelectedValue.ToString().ToUpper();
                //strTabName = "tre_random".ToUpper();;
                dataschemaGrid.Refresh();
                DataTable dt = (DataTable)dataschemaGrid.DataSource;
                DataRow[] drs = dt.Select("TYPE=" + (int)Enums.ColType.Key);
                if (drs.Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Should map 'Key' to at least one column.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                drs = dt.Select("TYPE=" + (int)Enums.ColType.Time);

                if (drs.Length > 1)
                {
                   // Telerik.WinControls.RadMessageBox.Show(this, "Should not map 'Time' to more than one column.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else if (drs.Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Should map 'Time' to at least one column.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                    return;
                }

             
                drs = dt.Select("Required='True'");
                if (drs.Length > 0)
                {
                    Common.strfiltertxt = clsDSOBJ.fnselectFilterCondition(Common.iProjectID);
                    clsDSOBJ.fnInsertTreMApping(drs, strTabName, Common.strfiltertxt,Common.iProjectID);
                   // clsDSOBJ.fnCreateTreMApping(drs, strTabName,Common.strfiltertxt);
                    Common.strTableName = ddlTableName.SelectedValue.ToString();
                  //  Common.strTableName = "tre_random";
                    Common.bIsTableMapped = true;
                    Common.SetLoginDetailsToRegistry();
                    dataschemaGridbinding();
                }

                
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ddlTableName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

                if (bIsLoaded)
                {

                    Common.strTableName = ddlTableName.SelectedValue.ToString();
                    dataschemaGridbinding();
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void generateMapclass()
        {
           
            var Mapclasssettings = new Connection();
           string mapTempPath = Path.GetTempPath();
           if (mapTempPath.EndsWith(@"\") == false)
           { mapTempPath += @"\"; }
           mapTempPath += @"Mapping\";
           if (Directory.Exists(mapTempPath) == false)
           {
               Directory.CreateDirectory(mapTempPath);
           }
            Mapclasssettings.Domainfolderpath = mapTempPath;
           
            Mapclasssettings.EntityName = "Entity";
            if ((RecoEngine_BI.Common.iDBType) == (int)Enums.DBType.Oracle)
            {
                Mapclasssettings.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                Mapclasssettings.Type = ServerType.Oracle;
            }
           else if ((RecoEngine_BI.Common.iDBType) == (int)Enums.DBType.Mysql)
            {
                Mapclasssettings.ConnectionString = ConfigurationManager.AppSettings["MysqlConnectionString"];
                Mapclasssettings.Type = ServerType.Mysql;
            }

          //  metadataReader = MetadataFactory.GetReader(Mapclasssettings.Type, Mapclasssettings.ConnectionString);
            var owners = metadataReader.GetOwners();
            IList<Table> tblList = metadataReader.GetTables("RECOUSR");
            int tableindex = 0;
            for (int i = 0; i < tblList.Count; i++)
            {
                if (tblList[i].Name == "OPPORTUNITY")
                {
                    tableindex = i;
                    break;
                }
            }
            Table table = tblList[tableindex];
            table.PrimaryKey = metadataReader.DeterminePrimaryKeys(table);
            metadataReader.GetTableDetails(table, "RECOUSR");
            var applicationPreferences = GetApplicationPreferences(table, false, Mapclasssettings);
            new ApplicationController(applicationPreferences, table).Generate();
        }

        private void Generate(Table table, bool generateAll, Connection appSettings)
        {
            try
            {
                var applicationPreferences = GetApplicationPreferences(table, generateAll, appSettings);
                new ApplicationController(applicationPreferences, table).Generate();
            }
            catch (Exception ex)
            {
                
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
         
            }
            
        }
        private ApplicationPreferences GetApplicationPreferences(Table tableName, bool all, Connection appSettings)
        {
            
                var applicationPreferences = new ApplicationPreferences
                {
                    ServerType = appSettings.Type,
                    DomainFolderPath = appSettings.Domainfolderpath,
                    TableName = tableName.Name,
                    NameSpace = appSettings.EntityName,
                    FieldNamingConvention = FieldNamingConvention.SameAsDatabase,
                    FieldGenerationConvention = FieldGenerationConvention.AutoProperty,
                    ConnectionString = appSettings.ConnectionString,
                };

                return applicationPreferences;

            
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            bindingExpressionEditor((int)Enums.ExpressionType.AddColumn);
            
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            bindingExpressionEditor((int)Enums.ExpressionType.Filter);

       }
        void bindingExpressionEditor(int iExpressionType, string CalaculatedColumnValue="", string strColname="")
        {
            try
            {
                clsDataSource clsObj = new clsDataSource();
                DataTable dtSource = clsObj.fnGetColMappingData(Common.iProjectID);
                DataTable dt = clsDSOBJ.fnGetTreDetails(Common.strTableName);
                DataTableReader dr = new DataTableReader(dt);
                DataTable dtSchema = dr.GetSchemaTable();

                string strExpression ="";
                if (iExpressionType == (int)Enums.ExpressionType.Filter)
                {
                    strExpression = clsObj.fnselectFilterCondition(Common.iProjectID);
                }
                else
                {
                    strExpression = "";
                }
                if (iExpressionType == (int)Enums.ExpressionType.CalaculatedColumn)
                {
                    strExpression = CalaculatedColumnValue;

                }
                using (var frm = new frmExpressEditor(iExpressionType, Common.strTableName, strExpression))
                {
                    frm._fieldDict = Common.GetDict(dt);
                    frm.AvailableFields = frm._fieldDict.ToList<KeyValuePair<string, Type>>();
                  frm.dtSource = dtSchema;
                    var res = frm.ShowDialog();
               if (res == System.Windows.Forms.DialogResult.OK)
                {
                    if (iExpressionType == (int)Enums.ExpressionType.Filter)
                        clsObj.fnInserFilter(frm.strExpression, Common.iProjectID);
                    else if (iExpressionType == (int)Enums.ExpressionType.AddColumn)
                    {
                        //  Common.strfiltertxt = "";
                        string strColName = frm.strColName;

                        string strMsg = "";
                        strExpression = frm.strExpression;
                        if (!clsObj.fnAddCalaculatedColumn(Common.strTableName, strColName, strExpression, ref  strMsg, Common.iProjectID))
                        {
                            if (strMsg != "")
                                Telerik.WinControls.RadMessageBox.Show(this, strMsg, "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                      
                    }
                    else if (iExpressionType == (int)Enums.ExpressionType.CalaculatedColumn)
                    {
                        if (!clsObj.fnUpdateCalaculatedColumn(Common.strTableName, strColname, frm.strExpression, Common.iProjectID))
                        {
                            
                        }

                    }
                    dtmain = (DataTable)dataschemaGrid.DataSource;
                    dataschemaGridbinding();
                }
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (DataFieldsNxtBtnClick != null)
                DataFieldsNxtBtnClick(this, e);
        }

    }
}
