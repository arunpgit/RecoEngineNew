using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using RecoEngine_BI;

namespace RecoEngine
{
    public partial class frmUsers : Telerik.WinControls.UI.RadForm
    {
        clsUsers clsObj = new clsUsers();
        int iUserID = 0;
        public frmUsers(int iUserId = 0)
        {
            iUserID = iUserId;
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                fnFillUserTypes();
                if (iUserID != 0)
                {
                    fnFillUserDetails();
                    btnSaveContinuee.Visible = false;
                    txtPassword.Enabled = txtCPassword.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void fnFillUserDetails()
        {
            try
            {
                DataTable dt = clsObj.fnGetUsersDetails(iUserID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtFName.Text = dt.Rows[0]["FIRST_NAME"] + "";
                    txtLastName.Text = dt.Rows[0]["LAST_NAME"] + "";
                    txtUserName.Text = dt.Rows[0]["USERNAME"] + "";
                    txtEmail.Text = dt.Rows[0]["EMAIL"] + "";
                    ddlUserType.SelectedValue =int.Parse(dt.Rows[0]["USERTYPE_ID"].ToString()) ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fnFillUserTypes()
        {
            try
            {
                DataTable dtTypes = new DataTable();
                dtTypes.Columns.Add(new DataColumn("Id", typeof(int)));
                dtTypes.Columns.Add(new DataColumn("Type", typeof(string)));

                dtTypes.Rows.Add(((int)Enums.UserTypes.administrators).ToString(), "Administrators");
                dtTypes.Rows.Add(((int)Enums.UserTypes.customers).ToString(), "Customers");
                dtTypes.Rows.Add(((int)Enums.UserTypes.employees).ToString(), "Employees");
                dtTypes.Rows.Add(((int)Enums.UserTypes.managers).ToString(), "Managers");
                dtTypes.Rows.Add(((int)Enums.UserTypes.operators).ToString(), "Operators");


                ddlUserType.DataSource = dtTypes;
                ddlUserType.ValueMember = "Id";
                ddlUserType.DisplayMember = "Type";

                ddlUserType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Close();
        }
        private bool fnSave()
        {
            try
            {
                if (txtFName.Text.Trim().Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "First Name Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtFName.Focus();
                    return false;
                }
                if (txtLastName.Text.Trim().Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Last Name Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtLastName.Focus();
                    return false; ;
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "Email Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtEmail.Focus();
                    return false; ;
                }
                if (txtUserName.Text.Trim().Length == 0)
                {
                    Telerik.WinControls.RadMessageBox.Show(this, "UserName Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    txtUserName.Focus();
                    return false; ;
                }

                if (iUserID == 0)
                {
                    if (txtPassword.Text.Trim().Length == 0)
                    {
                        Telerik.WinControls.RadMessageBox.Show(this, "Password Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                        txtPassword.Focus();
                        return false; ;
                    }
                    else
                    {
                        if (txtCPassword.Text.Trim().Length == 0)
                        {
                            Telerik.WinControls.RadMessageBox.Show(this, "Confirm Password Should Not be Empty.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            txtCPassword.Focus();
                            return false; ;
                        }
                        else
                        {
                            if (txtPassword.Text != txtCPassword.Text)
                            {
                                Telerik.WinControls.RadMessageBox.Show(this, "Password & Confirm Password Should same.", "Information", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                                txtCPassword.Focus();
                                return false; ;
                            }
                        }
                    }
                }
                int iISActive = 0;
                if (chkIsActive.Checked)
                    iISActive = 1;

                clsObj.fnSaveUser(iUserID, txtFName.Text.Trim(), txtLastName.Text.Trim(), int.Parse(ddlUserType.SelectedItem.Value.ToString()), txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), iISActive);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (fnSave())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSaveContinuee_Click(object sender, EventArgs e)
        {
            try
            {
                if (fnSave())
                {
                    txtFName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtCPassword.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    ddlUserType.SelectedIndex = 0;
                    chkIsActive.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Telerik.WinControls.RadMessageBox.Show(this, ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }



    }
}
