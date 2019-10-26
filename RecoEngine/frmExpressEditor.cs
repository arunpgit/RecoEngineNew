using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Collections;
using System.Linq;
using RecoEngine_BI;
using System.Windows;


namespace RecoEngine
{
    public partial class frmExpressEditor : Telerik.WinControls.UI.RadForm
    {
        private string _selectedItemType;
        private List<KeyValuePair<string, Type>> _availableFields;
        private List<KeyValuePair<string, Type>> _availableFields_New = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, Type>> { };
        public string strColName = "";

        public IDictionary<string, Type> _fieldDict;
        private readonly IList<string> _operators;
        public string strExpression = "";
        //private readonly Parser _parser = new Parser();
        public DataTable dtSource = new DataTable();
        string strTabName = "";

        

        public List<KeyValuePair<string, Type>> AvailableFields
        {
            set
            {
                _availableFields = value;
                _fieldDict = _availableFields.ToDictionary(k => k.Key, v => v.Value);
            }
        }

        bool bIsPotnl = false;
        int iExpressionFor = 1;


        public frmExpressEditor(int iExpressionFor, string strTabName, string expression = null)
        {
            InitializeComponent();
            this.strTabName = strTabName;
            this.iExpressionFor = iExpressionFor;

            if (iExpressionFor == (int)Enums.ExpressionType.Opp_ptnl)
            {
                btnStopper.Visible = true;
                btnStopper.Enabled = true;
                btnDropper.Visible = true;
                btnDropper.Enabled = true;
                btnGrower.Visible = true;
                btnGrower.Enabled = true;
                btnFlat.Visible = true;
                btnFlat.Enabled = true;
                btnNewusr.Visible = true;
                btnNewusr.Enabled = true;
                btnNonusr.Visible = true;
                btnNonusr.Enabled = true;
            }
            _operators = new List<string>()
			{
				">", "<", "<=", ">=", "=",  "<>",  "+", "-", "*",  "/","(",")"
			};
            lstItemTypes.SelectedIndex = 0;
            Text = string.Format("Custom Column Expression Editor");

            expression = expression == null ? "" : expression.Trim();
            if (expression.Length == 0 || expression[0] != '=') expression = '=' + expression;

            txtExpression.Text = expression;

            LabelParserError.Text = null;
            LabelParserResult.Text = null;
        }

        private void frmExpressEditor_Load(object sender, EventArgs e)
        {
            try
            {
                if (iExpressionFor == (int)Enums.ExpressionType.AddColumn)
                {
                    txtName.Visible = true;
                    lblName.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void lstItemTypes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                lstBoxItems.DisplayMember = string.Empty;
                lstBoxItems.ValueMember = string.Empty;

                _selectedItemType = lstItemTypes.SelectedItem.ToString();
                if (_selectedItemType != null)
                {
                    switch (_selectedItemType)
                    {
                        case "Fields":

                            fnGetItems();
                            lstBoxItems.DataSource = _availableFields_New;//_availableFields;
                            lstBoxItems.DisplayMember = "Key";
                            lstBoxItems.ValueMember = "Key";
                            break;
                        case "Operators":
                            lstBoxItems.DataSource = _operators;
                            break;
                        default:
                            lstBoxItems.DataSource = null;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void fnGetItems()
        {
            try
            {
                if (_availableFields_New.Count == 0)
                {
                    foreach (KeyValuePair<string, Type> entry in _availableFields)
                    {
                        string strItem = entry.Key.ToString();
                        DataRow[] drRow = dtSource.Select("COLUMNNAME ='" + strItem.Replace("Field.", "") + "'");
                        if (drRow.Length > 0)
                        {
                            _availableFields_New.Add(entry);
                        }
                        //if (!bIsPotnl)
                        //{
                        //    DataRow[] drRow = dtSource.Select("COLNAME ='" + strItem.Replace("Field.", "") + "'");
                        //    if (drRow.Length > 0)
                        //    {
                        //        if (drRow[0]["TYPE"].ToString() == ((int)Enums.ColType.Input).ToString() && drRow[0]["ISREQUIRED"].ToString() == "1")
                        //        {
                        //            _availableFields_New.Add(entry);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    DataRow[] drRow = dtSource.Select("COLUMNNAME ='" + strItem.Replace("Field.", "") + "'");
                        //    if (drRow.Length > 0)
                        //    {
                        //        _availableFields_New.Add(entry);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lstBoxItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                fnSetExpression(lstBoxItems.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fnSetExpression(string selectedValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtExpression.Text))
                {
                    txtExpression.Text = "=";
                    txtExpression.SelectionStart++;
                }
                //var selectedValue = lstBoxItems.SelectedValue as string;
                if (selectedValue != null)
                {
                    var expressionText = txtExpression.Text;

                    if (_selectedItemType == "Fields")
                    {
                        selectedValue = selectedValue.Replace(".", "!");
                    }
                    else if (_selectedItemType == "Functions")
                    {
                        selectedValue += "() ";
                    }

                    if (txtExpression.SelectionLength > 0)
                    {
                        expressionText.Remove(txtExpression.SelectionStart, txtExpression.SelectionLength);
                    }
                    expressionText = expressionText.Insert(txtExpression.SelectionStart, selectedValue);
                    txtExpression.Text = expressionText;
                    txtExpression.SelectionStart += expressionText.Length;

                    if (_selectedItemType == "Functions")
                    {
                        txtExpression.SelectionStart -= 2;
                    }
                }
                txtExpression.Focus();
                txtExpression.SelectionStart = txtExpression.Text.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                if ((iExpressionFor == (int)Enums.ExpressionType.AddColumn) && txtName.Text.Trim().Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show("Name Should not be empty", "Newcolumn", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtName.Focus();
                    return;
                }
                strExpression = "";
                bool bIsNotCaseExpression = false;
                if (fnValidateExpression(ref strExpression, ref bIsNotCaseExpression))
                {

                    strColName = txtName.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Telerik.WinControls.RadMessageBox.Show("Expression Parsing Failed with Errors.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        //private void btnOKOld_Click(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        if (!bIsPotnl && txtName.Text.Trim().Length == 0)
        //        {
        //            Telerik.WinControls.RadMessageBox.Show("Name Should not be empty", "Newcolumn", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //            txtName.Focus();
        //            return;
        //        }
        //        strExpression = "";
        //        bool bIsNotCaseExpression = false;
        //        if (fnValidateExpression(ref strExpression, ref bIsNotCaseExpression))
        //        {
        //            string str = txtExpression.Text.Replace("_", "");
        //            if (str.StartsWith("=") == false)
        //            {
        //                str = "=" + str;
        //            }

        //            if ((bIsNotCaseExpression) || txtExpression.Text == string.Empty || (_parser.Parse(str, _fieldDict)))
        //            {
        //                strColName = txtName.Text;
        //                DialogResult = DialogResult.OK;
        //                Close();
        //            }
        //            else
        //            {
        //                Telerik.WinControls.RadMessageBox.Show(string.Format("Expression Parsing Failed with {0} Errors.", _parser.Errors.Count),
        //                    "Custom Column Expression Editor", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //    }
        //}
        //private void btnTestOld_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        strExpression = "";
        //        bool bIsNotCaseExpression = false;
        //        if (fnValidateExpression(ref strExpression, ref bIsNotCaseExpression))
        //        {
        //            string str = txtExpression.Text.Replace("_", "");
        //            if (str.StartsWith("=") == false)
        //            {
        //                str = "=" + str;
        //            }
        //            var successful = _parser.Parse(str, _fieldDict);

        //            if ((bIsNotCaseExpression) || (successful))
        //            {
        //                btnCancel.Enabled = true;
        //                LabelParserError.Text = null;
        //                if ((_parser.FieldsNeeded.Count == 0))
        //                {
        //                    try
        //                    {
        //                        var res = _parser.CompiledDelegate(null);
        //                        LabelParserResult.Text = string.Format("Constant: {0}", res);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        LabelParserResult.Text = "Constant: Failed!";
        //                        LabelParserError.Text = "Exception: " + ex.Message;
        //                        btnCancel.Enabled = false;
        //                    }
        //                }
        //                else
        //                {
        //                    LabelParserResult.Text = string.Format("Success: relies on {0} field(s)", _parser.FieldsNeeded.Count);
        //                }
        //                //  LabelParserResultType.Text = _parser.ResultType.ToString();
        //            }
        //            else
        //            {
        //                btnCancel.Enabled = false;
        //                LabelParserResult.Text = "Failed!";
        //                // LabelParserResultType.Text = string.Empty;
        //                LabelParserError.Text = string.Join("\n", _parser.Errors);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
        //    }
        //}
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                strExpression = "";
                bool bIsNotCaseExpression = false;
                if (fnValidateExpression(ref strExpression, ref bIsNotCaseExpression))
                {
                    btnCancel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private bool fnValidateExpression(ref string strString, ref bool bIsNotCaseExpression)
        {
            try
            {
                strString = txtExpression.Text.Replace("Field.", "").Trim().ToUpper();
               
                    if (strString.StartsWith("="))
                        strString = strString.Substring(1);
                    if (strString == "")
                        strString = "1=1";
                  
                clsDataSource clsObj = new clsDataSource();

                DataTable dtSource = clsObj.fnValidateExpressEditor(strString, strTabName, iExpressionFor);

                if (dtSource != null)
                {
                    LabelParserResult.Text = "Success!";
                    LabelParserError.Text = "";
                    if (strString == "1=1")
                    {
                        strString = "";
                        txtExpression.Text = "=";
                    }
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LabelParserResult.Text = "Constant: Failed!";
                LabelParserError.Text = "Exception: " + ex.Message;
                throw ex;
            }

        }

        private void fnBtnClick(object sender, EventArgs e)
        {
            try
            {
                string str = ((Telerik.WinControls.UI.RadButton)sender).Text;
                fnSetExpression(str);
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                string strFc = txtName.Text.Substring(0, 1);

                if (!Char.IsLetter(txtName.Text, 0))
                {
                    Telerik.WinControls.RadMessageBox.Show("Name should start with Alphabet");
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

        private void btnStopper_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘Stopper’";
        }

        private void btnDropper_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘Dropper’";
        }

        private void btnFlat_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘Flat’";
        }

        private void btnGrower_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘Grower’";
        }

        private void btnNonusr_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘Non User’";
        }

        private void btnNewusr_Click(object sender, EventArgs e)
        {
            txtExpression.Text += "‘New User’";
        }

        private void rbtnPreview_Click(object sender, EventArgs e)
        {
            var frm = new CntrlPreviewExpression(strTabName);
            frm.Show();
        }

        private void lstBoxItems_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }
    }
}
