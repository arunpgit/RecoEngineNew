using RecoEngine_BI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace RecoEngine
{
    public partial class ctrlThreshold : RadForm
    {
        private clsTre_Details objTredetails = new clsTre_Details();

        private VerticalLineAnnotation VAStopper = new VerticalLineAnnotation();

        private RectangleAnnotation RAStopper = new RectangleAnnotation();

        private VerticalLineAnnotation VADropper = new VerticalLineAnnotation();

        private RectangleAnnotation RADropper = new RectangleAnnotation();

        private VerticalLineAnnotation VAGrower = new VerticalLineAnnotation();

        private RectangleAnnotation RAGrower = new RectangleAnnotation();

        private DataTable tblchart = new DataTable();

        private double Ymax;

        private int iOpportunityId;

        private string strFormula = "";

        private string strPtnlFilter = "";

        private System.Windows.Forms.DataVisualization.Charting.ChartArea CA;

        public string strCutOff = "";

        public string strCount = "";

        public string strAvgDelta = "";

        private bool bIsTreSholdLoaded;

        private string[] strT1 = Common.timePeriods.strtp1;

        private string[] strT2 = Common.timePeriods.strtp2;

        public ctrlThreshold(int iOpportunityID, string strFormula, string strPtnlFilter, string[] strT1, string[] strT2)
        {
            this.strFormula = strFormula;
            this.strPtnlFilter = strPtnlFilter;
            this.strT1 = strT1;
            this.strT2 = strT2;
            this.iOpportunityId = iOpportunityID;
            this.InitializeComponent();
            base.Load += new EventHandler(this.ctrlThreshold_Load);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsTre_Details clsTreDetail = new clsTre_Details();
                string[] strArrays = Common.timePeriods.strtp1;
                string[] strArrays1 = Common.timePeriods.strtp2;
                string[] text = new string[] { this.txtCtDropper.Text, ";", this.txtCtGrower.Text, ";", this.txtCtStopper.Text };
                this.strCutOff = string.Concat(text);
                string[] text1 = new string[] { this.txtCFlat.Text, ";", this.txtCDropper.Text, ";", this.txtCGrower.Text, ";", this.txtCStopper.Text, ";", this.txtCNonUser.Text, ";", this.txtCNewUser.Text };
                this.strCount = string.Concat(text1);
                string[] text2 = new string[] { this.txtAvgFlat.Text, ";", this.txtAvgDropper.Text, ";", this.txtAvgGrower.Text, ";", this.txtAvgStopper.Text, ";", this.txtAvgNonUser.Text, ";", this.txtAvgNewUser.Text };
                this.strAvgDelta = string.Concat(text2);
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void chartThreshold_AnnotationPositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.VAStopper.X >= this.VADropper.X)
                {
                    this.VAStopper.X = Convert.ToDouble(this.txtCtStopper.Text);
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    MessageBox.Show("Stopper Value Should not exceed Dropper Value");
                }
                else if (this.VADropper.X < this.VAGrower.X)
                {
                    this.RAStopper.X = this.VAStopper.X - this.RAStopper.Width / 2;
                    this.RADropper.X = this.VADropper.X - this.RADropper.Width / 2;
                    this.RAGrower.X = this.VAGrower.X - this.RAGrower.Width / 2;
                    this.trkBarvalues();
                    this.txtCtStopper.Text = Convert.ToString(this.VAStopper.X);
                    this.txtCtDropper.Text = Convert.ToString(this.VADropper.X);
                    this.txtCtGrower.Text = Convert.ToString(this.VAGrower.X);
                    RectangleAnnotation rADropper = this.RADropper;
                    double num = Math.Round(this.VADropper.X, 2);
                    rADropper.Text = num.ToString();
                    RectangleAnnotation rAGrower = this.RAGrower;
                    double num1 = Math.Round(this.VAGrower.X, 2);
                    rAGrower.Text = num1.ToString();
                    RectangleAnnotation rAStopper = this.RAStopper;
                    double num2 = Math.Round(this.VAStopper.X, 2);
                    rAStopper.Text = num2.ToString();
                    this.txtCtFlat.Text = string.Concat(this.txtCtDropper.Text, " - ", this.txtCtGrower.Text);
                    this.chartThreshold.UpdateAnnotations();
                }
                else
                {
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    this.VAGrower.X = Convert.ToDouble(this.txtCtGrower.Text);
                    MessageBox.Show("Dropper Value Should not exceed Grower Value");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ctrlThreshold_Load(object sender, EventArgs e)
        {
            try
            {
                this.fnMappingChart();
                this.fnStprAnnotation();
                this.fnDrprAnnotation();
                this.fnGrwrAnnotation();
                base.DialogResult = DialogResult.None;
                this.bIsTreSholdLoaded = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

     

        private void drprTrackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.VADropper.X = (double)this.drprTrackBar.Value / 10 * 0.1 - 1;
                if (this.VADropper.X < this.VAGrower.X)
                {
                    this.RADropper.X = this.VADropper.X - this.RADropper.Width / 2;
                    this.chartThreshold.UpdateAnnotations();
                    this.txtCtDropper.Text = Convert.ToString(this.VADropper.X);
                    this.fnAvgDeltaCount();
                }
                else
                {
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    this.VAGrower.X = Convert.ToDouble(this.txtCtGrower.Text);
                    MessageBox.Show("Dropper Value Should not exceed Grower Value");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fnAvgDeltaCount()
        {
            try
            {
                DataTable dataTable = new DataTable();
                string[] strArrays = Common.timePeriods.strtp1;
                string[] strArrays1 = Common.timePeriods.strtp2;
                dataTable = this.objTredetails.fnGetTREThreShold(strArrays, strArrays1, this.strFormula, Common.strPtnlFilter, this.txtCtDropper.Text, this.txtCtGrower.Text, this.txtCtStopper.Text, this.iOpportunityId, "Tre_Random"+Common.iProjectID);
                DataTable dataTable1 = dataTable.Clone();
                DataRow[] dataRowArray = dataTable.Select("STATUS ='STOPPER'");
                this.txtCStopper.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgStopper.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox str = this.txtAvgStopper;
                    decimal num = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    str.Text = num.ToString();
                }
                dataRowArray = dataTable.Select("STATUS ='DROPPER'");
                this.txtCDropper.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgDropper.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox radTextBox = this.txtAvgDropper;
                    decimal num1 = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    radTextBox.Text = num1.ToString();
                }
                dataRowArray = dataTable.Select("STATUS ='GROWER'");
                this.txtCGrower.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgGrower.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox str1 = this.txtAvgGrower;
                    decimal num2 = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    str1.Text = num2.ToString();
                }
                dataRowArray = dataTable.Select("STATUS ='FLAT'");
                this.txtCFlat.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgFlat.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox radTextBox1 = this.txtAvgFlat;
                    decimal num3 = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    radTextBox1.Text = num3.ToString();
                }
                dataRowArray = dataTable.Select("STATUS ='NON_USER'");
                this.txtCNonUser.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgNonUser.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox str2 = this.txtAvgNonUser;
                    decimal num4 = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    str2.Text = num4.ToString();
                }
                dataRowArray = dataTable.Select("STATUS ='NEW_USER'");
                this.txtCNewUser.Text = ((int)dataRowArray.Length).ToString();
                if ((int)dataRowArray.Length <= 0)
                {
                    this.txtAvgNewUser.Text = "0";
                }
                else
                {
                    dataTable1 = dataRowArray.CopyToDataTable<DataRow>();
                    RadTextBox radTextBox2 = this.txtAvgNewUser;
                    decimal num5 = decimal.Round(Convert.ToDecimal(dataTable1.Compute("AVG(DELTA)", "")), 2);
                    radTextBox2.Text = num5.ToString();
                }
                if (dataTable.Rows.Count <= 0)
                {
                    this.txtCPDropper.Text = "0";
                    this.txtCPStopper.Text = "0";
                    this.txtCPGrower.Text = "0";
                    this.txtCPNonUser.Text = "0";
                    this.txtCPNewUser.Text = "0";
                    this.txtCPFlat.Text = "0";
                }
                else
                {
                    this.txtCPDropper.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCDropper.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                    this.txtCPStopper.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCStopper.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                    this.txtCPGrower.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCGrower.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                    this.txtCPNonUser.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCNonUser.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                    this.txtCPNewUser.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCNewUser.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                    this.txtCPFlat.Text = string.Concat(string.Format("{0:0.00}", (Convert.ToDecimal(this.txtCFlat.Text) / dataTable.Rows.Count) * new decimal(100)), "%");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void fnDrprAnnotation()
        {
            try
            {
                this.CA = this.chartThreshold.ChartAreas[0];
                this.VADropper.AxisX = this.CA.AxisX;
                this.VADropper.AllowMoving = true;
                this.VADropper.IsInfinitive = true;
                this.VADropper.ClipToChartArea = this.CA.Name;
                this.VADropper.Name = "Dropper";
                this.VADropper.LineColor = Color.Green;
                this.VADropper.LineWidth = 1;
                this.RADropper.AxisX = this.chartThreshold.ChartAreas[0].AxisX;
                this.RADropper.IsSizeAlwaysRelative = false;
                this.RADropper.Width = 0.1;
                this.RADropper.Height = this.Ymax / 10;
                this.RADropper.LineColor = Color.White;
                this.RADropper.BackColor = Color.Green;
                this.RADropper.AxisY = this.chartThreshold.ChartAreas[0].AxisY;
                this.RADropper.Y = -this.RADropper.Height;
                this.RADropper.X = Math.Round(this.VADropper.X - this.RADropper.Width / 2, 2);
                RectangleAnnotation rADropper = this.RADropper;
                double num = Math.Round(this.VADropper.X, 2);
                rADropper.Text = num.ToString();
                this.RADropper.ForeColor = Color.White;
                this.RADropper.Font = new Font("Arial", 8f);
                this.chartThreshold.AnnotationPositionChanged += new EventHandler(this.chartThreshold_AnnotationPositionChanged);
                this.chartThreshold.Annotations.Add(this.VADropper);
                this.chartThreshold.Annotations.Add(this.RADropper);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void fnGrwrAnnotation()
        {
            try
            {
                this.CA = this.chartThreshold.ChartAreas[0];
                this.VAGrower.AxisX = this.CA.AxisX;
                this.VAGrower.AllowMoving = true;
                this.VAGrower.IsInfinitive = true;
                this.VAGrower.ClipToChartArea = this.CA.Name;
                this.VAGrower.Name = "Grower";
                this.VAGrower.LineColor = Color.Black;
                this.VAGrower.LineWidth = 1;
                this.RAGrower.AxisX = this.chartThreshold.ChartAreas[0].AxisX;
                this.RAGrower.IsSizeAlwaysRelative = false;
                this.RAGrower.Width = 0.1;
                this.RAGrower.Height = this.Ymax / 10;
                this.RAGrower.LineColor = Color.White;
                this.RAGrower.BackColor = Color.Black;
                this.RAGrower.AxisY = this.chartThreshold.ChartAreas[0].AxisY;
                this.RAGrower.Y = -this.RAGrower.Height;
                this.RAGrower.X = this.VAGrower.X - this.RAGrower.Width / 2;
                RectangleAnnotation rAGrower = this.RAGrower;
                double num = Math.Round(this.VAGrower.X, 2);
                rAGrower.Text = num.ToString();
                this.RAGrower.ForeColor = Color.White;
                this.RAGrower.Font = new Font("Arial", 8f);
                this.chartThreshold.AnnotationPositionChanged += new EventHandler(this.chartThreshold_AnnotationPositionChanged);
                this.chartThreshold.Annotations.Add(this.VAGrower);
                this.chartThreshold.Annotations.Add(this.RAGrower);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void fnMappingChart()
        {
            try
            {
                Label label = this.lblTop;
                label.Text = string.Concat(label.Text, Common.sOpportunityName);
                this.chartThreshold.ChartAreas.Clear();
                this.chartThreshold.Annotations.Clear();
                this.chartThreshold.Series.Clear();
                if (!this.tblchart.Columns.Contains("X"))
                {
                    this.tblchart.Columns.Add("X", typeof(decimal));
                }
                if (!this.tblchart.Columns.Contains("Y"))
                {
                    this.tblchart.Columns.Add("Y", typeof(double));
                }
                double count = 0;
                DataTable dataTable = new DataTable();
                if (this.iOpportunityId > 0)
                {
                    dataTable = this.objTredetails.fnGetOppBreakDowndetails(this.iOpportunityId);
                }
                string text = "";
                if (this.iOpportunityId <= 0 || dataTable.Rows.Count <= 0)
                {
                    this.txtCtDropper.Text = Common.strDropper;
                    this.txtCtGrower.Text = Common.strGrower;
                    this.txtCtStopper.Text = Common.strStopper;
                    this.txtCtFlat.Text = string.Concat(Common.strDropper, " - ", Common.strGrower);
                }
                else
                {
                    if (dataTable.Rows[0]["T1"] != null && dataTable.Rows[0]["T1"].ToString() != "")
                    {
                        string str = dataTable.Rows[0]["T1"].ToString();
                        char[] chrArray = new char[] { ',' };
                        this.strT1 = str.Split(chrArray);
                    }
                    if (dataTable.Rows[0]["T2"] != null && dataTable.Rows[0]["T2"].ToString() != "")
                    {
                        string str1 = dataTable.Rows[0]["T2"].ToString();
                        char[] chrArray1 = new char[] { ',' };
                        this.strT2 = str1.Split(chrArray1);
                    }
                    if (dataTable.Rows[0]["DROPPERS_CUTOFF"] != null && dataTable.Rows[0]["DROPPERS_CUTOFF"].ToString() != "")
                    {
                        this.txtCtDropper.Text = dataTable.Rows[0]["DROPPERS_CUTOFF"].ToString();
                        text = this.txtCtDropper.Text;
                    }
                    if (dataTable.Rows[0]["STOPPERS_CUTOFF"] != null && dataTable.Rows[0]["STOPPERS_CUTOFF"].ToString() != "")
                    {
                        this.txtCtStopper.Text = dataTable.Rows[0]["STOPPERS_CUTOFF"].ToString();
                    }
                    if (dataTable.Rows[0]["GROWERS_CUTOFF"] != null && dataTable.Rows[0]["GROWERS_CUTOFF"].ToString() != "")
                    {
                        this.txtCtGrower.Text = dataTable.Rows[0]["GROWERS_CUTOFF"].ToString();
                        text = string.Concat(text, " - ", this.txtCtGrower.Text);
                    }
                    if (text != "")
                    {
                        this.txtCtFlat.Text = text;
                    }
                }
                this.txtCtNewUser.Text = "0";
                this.txtCtNonUser.Text = "0";
                this.VAStopper.X = Convert.ToDouble(this.txtCtStopper.Text);
                this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                this.VAGrower.X = Convert.ToDouble(this.txtCtGrower.Text);
                dataTable = this.objTredetails.fnGetTREThreShold(this.strT1, this.strT2, this.strFormula, Common.strPtnlFilter, this.txtCtDropper.Text, this.txtCtGrower.Text, this.txtCtStopper.Text, this.iOpportunityId, "Tre_Random"+Common.iProjectID);
                this.fnAvgDeltaCount();
                var list = dataTable.AsEnumerable().Select((DataRow obj) => new { onnet = obj["DELTA"].ToString() }).ToList();
                for (decimal i = new decimal(-1); i <= new decimal(1); i += new decimal(1, 0, 0, false, 1))
                {
                    if (i != new decimal(1))
                    {
                        count = (double)list.Where((p) => {
                            if (Convert.ToDecimal(p.onnet) < i)
                            {
                                return false;
                            }
                            return Convert.ToDecimal(p.onnet) < (i + Convert.ToDecimal(0.1));
                        }).Select((p) => p.onnet).ToList<string>().Count;
                        count = Convert.ToDouble(count) / Convert.ToDouble(list.Count()) * 100;
                    }
                    else
                    {
                        count = (double)(
                            from p in list
                            where Convert.ToDecimal(p.onnet) >= i
                            select p.onnet).ToList<string>().Count;
                        count = Convert.ToDouble(count) / Convert.ToDouble(list.Count()) * 100;
                    }
                    DataRowCollection rows = this.tblchart.Rows;
                    object[] objArray = new object[] { i, count };
                    rows.Add(objArray);
                }
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                this.chartThreshold.ChartAreas.Add(chartArea);
                Series series = new Series()
                {
                    ChartType = SeriesChartType.Spline,
                    XValueMember = "X",
                    YValueMembers = "Y"
                };
                this.chartThreshold.Series.Add(series);
                this.chartThreshold.DataSource = this.tblchart;
                this.chartThreshold.ChartAreas[0].AxisX.Interval = 0.1;
                this.chartThreshold.DataBind();
                this.chartThreshold.Update();
                this.chartThreshold.ChartAreas[0].RecalculateAxesScale();
                this.Ymax = this.chartThreshold.ChartAreas[0].AxisY.Maximum;
                this.chartThreshold.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                this.chartThreshold.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void fnStprAnnotation()
        {
            try
            {
                this.CA = this.chartThreshold.ChartAreas[0];
                this.VAStopper.AxisX = this.CA.AxisX;
                this.VAStopper.AllowMoving = true;
                this.VAStopper.IsInfinitive = true;
                this.VAStopper.ClipToChartArea = this.CA.Name;
                this.VAStopper.Name = "stopper";
                this.VAStopper.LineColor = Color.Red;
                this.VAStopper.LineWidth = 1;
                this.RAStopper.AxisX = this.chartThreshold.ChartAreas[0].AxisX;
                this.RAStopper.IsSizeAlwaysRelative = false;
                this.RAStopper.Width = 0.1;
                this.RAStopper.Height = this.Ymax / 10;
                this.RAStopper.LineColor = Color.Navy;
                this.RAStopper.BackColor = Color.Red;
                this.RAStopper.AxisY = this.chartThreshold.ChartAreas[0].AxisY;
                this.RAStopper.Y = -this.RAStopper.Height;
                this.RAStopper.X = this.VAStopper.X - this.RAStopper.Width / 2;
                RectangleAnnotation rAStopper = this.RAStopper;
                double num = Math.Round(this.VAStopper.X, 2);
                rAStopper.Text = num.ToString();
                this.RAStopper.ForeColor = Color.White;
                this.RAStopper.Font = new Font("Arial", 8f);
                this.chartThreshold.AnnotationPositionChanged += new EventHandler(this.chartThreshold_AnnotationPositionChanged);
                this.chartThreshold.Annotations.Add(this.VAStopper);
                this.chartThreshold.Annotations.Add(this.RAStopper);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void grwrTrackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.VAGrower.X = (double)this.grwrTrackBar.Value / 10 * 0.1 - 1;
                if (this.VADropper.X < this.VAGrower.X)
                {
                    this.RAGrower.X = this.VAGrower.X - this.RAGrower.Width / 2;
                    this.chartThreshold.UpdateAnnotations();
                    this.txtCtGrower.Text = Convert.ToString(this.VAGrower.X);
                    this.fnAvgDeltaCount();
                }
                else
                {
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    this.VAGrower.X = Convert.ToDouble(this.txtCtGrower.Text);
                    MessageBox.Show("Dropper Value Should not exceed Grower Value");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void stprTrackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.VAStopper.X = (double)this.stprTrackBar.Value / 10 * 0.1 - 1;
                if (this.VAStopper.X < this.VADropper.X)
                {
                    this.RAStopper.X = this.VAStopper.X - this.RAStopper.Width / 2;
                    this.txtCtStopper.Text = Convert.ToString(this.VAStopper.X);
                    this.fnAvgDeltaCount();
                }
                else
                {
                    this.VAStopper.X = Convert.ToDouble(this.txtCtStopper.Text);
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    MessageBox.Show("Stopper Value Should not exceed Dropper Value");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                RadMessageBox.Show(this, exception.Message, exception.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void trkBarvalues()
        {
            this.grwrTrackBar.Value = Convert.ToInt32(Math.Round(this.VAGrower.X + 1, 2) * 100);
            this.drprTrackBar.Value = Convert.ToInt32(Math.Round(this.VADropper.X + 1, 2) * 100);
            this.stprTrackBar.Value = Convert.ToInt32(Math.Round(this.VAStopper.X + 1, 2) * 100);
        }

        private void txtCtDropper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as RadTextBox).Text.IndexOf('.') > -1 && (sender as RadTextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\r')
            {
                if (!this.bIsTreSholdLoaded)
                {
                    return;
                }
                if (this.txtCtDropper.Text.ToString().Trim() != "" && this.txtCtDropper.Text.ToString().Trim() != "-")
                {
                    if (Convert.ToDouble(this.txtCtDropper.Text) > Convert.ToDouble(this.txtCtGrower.Text) || Convert.ToDouble(this.txtCtDropper.Text) < Convert.ToDouble(this.txtCtStopper.Text))
                    {
                        MessageBox.Show("Dropper value cannot be higher than grower or less than stopper");
                        return;
                    }
                    this.VADropper.X = Convert.ToDouble(this.txtCtDropper.Text);
                    this.RADropper.X = this.VADropper.X - this.RADropper.Width / 2;
                    RectangleAnnotation rADropper = this.RADropper;
                    double num = Math.Round(this.VADropper.X, 2);
                    rADropper.Text = num.ToString();
                    this.RAGrower.X = this.VAGrower.X - this.RAGrower.Width / 2;
                    this.txtCtFlat.Text = string.Concat(this.txtCtDropper.Text, " -  +", this.txtCtGrower.Text);
                    this.trkBarvalues();
                }
            }
        }

        private void txtCtGrower_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' && (sender as RadTextBox).Text.IndexOf('.') > -1 && (sender as RadTextBox).Text.IndexOf('-') > -1)
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\r')
                {
                    if (!this.bIsTreSholdLoaded)
                    {
                        return;
                    }
                    else if (this.txtCtGrower.Text.ToString().Trim() != "" && this.txtCtGrower.Text.ToString().Trim() != "-")
                    {
                        if (Convert.ToDouble(this.txtCtStopper.Text) <= Convert.ToDouble(this.txtCtDropper.Text))
                        {
                            this.VAGrower.X = Convert.ToDouble(this.txtCtGrower.Text);
                            this.RAGrower.X = this.VAGrower.X - this.RAStopper.Width / 2;
                            RectangleAnnotation rAGrower = this.RAGrower;
                            double num = Math.Round(this.VAGrower.X, 2);
                            rAGrower.Text = num.ToString();
                            this.txtCtFlat.Text = string.Concat(this.txtCtDropper.Text, " -  +", this.txtCtGrower.Text);
                            this.trkBarvalues();
                        }
                        else
                        {
                            MessageBox.Show("Grower Value cannot be less than Dropper Value");
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void txtCtStopper_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' && (sender as RadTextBox).Text.IndexOf('.') > -1 && (sender as RadTextBox).Text.IndexOf('-') > -1)
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\r')
                {
                    if (!this.bIsTreSholdLoaded)
                    {
                        return;
                    }
                    else if (this.txtCtStopper.Text.ToString().Trim() != "" && this.txtCtStopper.Text.ToString().Trim() != "-")
                    {
                        if (Convert.ToDouble(this.txtCtStopper.Text) <= Convert.ToDouble(this.txtCtDropper.Text))
                        {
                            this.VAStopper.X = Convert.ToDouble(this.txtCtStopper.Text);
                            this.RAStopper.X = this.VAStopper.X - this.RAStopper.Width / 2;
                            RectangleAnnotation rAStopper = this.RAStopper;
                            double num = Math.Round(this.VAStopper.X, 2);
                            rAStopper.Text = num.ToString();
                            this.txtCtFlat.Text = string.Concat(this.txtCtDropper.Text, " -  +", this.txtCtGrower.Text);
                            this.trkBarvalues();
                        }
                        else
                        {
                            MessageBox.Show("Stopper Value must be less than Dropper Value");
                            this.txtCtStopper.Text = "";
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

     
    }
}