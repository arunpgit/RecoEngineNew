using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using System.Runtime.InteropServices;
using RecoEngine_BI;

namespace RecoEngine
{
    public partial class frmLogin : Telerik.WinControls.UI.ShapedForm
    {
        clsUsers clsObj = new clsUsers();
        private int LOGON32_PROVIDER_DEFAULT = 0;
        private int LOGON32_LOGON_INTERACTIVE = 2;


        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);

        int iTicks = 0;
        bool bRelogin = false;
        bool bAutoLogin = false;
        string strWindowsLoginName = "";
        string strSytemDomainName = "";
        string sLastUserName = "";
        string sLastLanguageId = "0";
        string sGalleryId = "0";
        string sIsLangRightToLeft = "0";

        public frmLogin()
        {
            InitializeComponent();

            Common.GetLastLoginDetailsFromRegistry(ref sLastUserName);

            txtUserName.Text = sLastUserName;

            btnOk.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            bAutoLogin = fnCheckWindowsUserWithTREuserAndAutologin();

            if (Common.sUserName == null)
            {
                this.ShowInTaskbar = true;
                tmrSplash.Interval = 1;
                tmrSplash.Enabled = true;

            }
            else
            {
                fnGetWindowsDeatils();
                this.ShowInTaskbar = false;
            }
        }
        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            try
            {
                if (iTicks == 4 || (bAutoLogin == true && bRelogin == false && iTicks == 2))
                {
                    //lblAbout.Visible = true;
                    tmrSplash.Enabled = false;
                    if (bAutoLogin)
                    {
                        DataSet ds = clsObj.fnCheckUser(strWindowsLoginName);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            fnSetDefaultValues(ds);
                            Common.SetLoginDetailsToRegistry();
                            Common.fMain.Visible = true;
                            this.Hide();
                        }
                    }
                    else
                        ShowLoginFields();
                }
                else
                    iTicks += 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void ShowLoginFields()
        {
            try
            {
                pnMain.Visible = true;
                if (txtUserName.Text.Trim().ToString() != "")
                    txtPassword.Focus();
                else
                    txtUserName.Focus();
                // test message
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUserName.Text.ToLower().ToString() != "")
                {
                    bool bValidUser = false;
                    bool bIsWindowsPassword = false;

                    if (txtUserName.Text.Trim().ToUpper() == strWindowsLoginName.ToUpper().Trim())
                    {
                        if (clsObj.fnCheckUserName(strWindowsLoginName, ref bIsWindowsPassword))
                        {
                            if (bIsWindowsPassword)
                            {
                                if (ValidateUser(txtUserName.Text, txtPassword.Text, strSytemDomainName))
                                {
                                    // user has windows password option and enetr right password
                                    DataSet ds = clsObj.fnCheckUser(txtUserName.Text.ToString());
                                    fnSetDefaultValues(ds);
                                    bValidUser = true;
                                    // open the VTS                 
                                }
                                else
                                {
                                    // entered wrong windows password
                                    MessageBox.Show("Invalid Password", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtPassword.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUserName.Focus();
                            return;
                        }

                    }

                    if (!bValidUser)
                    {

                        DataSet ds = clsObj.fnCheckUser(txtUserName.Text.ToString());
                        if (ds.Tables[0].Rows.Count != 0)
                        {

                            if ((ds.Tables[0].Rows[0]["IsActive"] != null) && (!Convert.ToBoolean(int.Parse(ds.Tables[0].Rows[0]["IsActive"].ToString()))))
                            {
                                MessageBox.Show("Username is in inactive mode.", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUserName.Focus();
                                return;
                            }

                            if ((ds.Tables[0].Rows[0]["UseWindowsPassword"] != null) && (ds.Tables[0].Rows[0]["UseWindowsPassword"].ToString() != ""))
                                bIsWindowsPassword = Convert.ToBoolean(int.Parse(ds.Tables[0].Rows[0]["UseWindowsPassword"].ToString()));


                            if (bIsWindowsPassword)
                            {
                                // entered wrong windows password
                                MessageBox.Show("Can not login as windows password is enabled for this user.", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtPassword.Focus();
                                return;

                            }
                            else
                            {

                                //if (ds.Tables[0].Rows[0]["loginpassword"].ToString() == Common.GetEncriptedValue(txtPassword.Text.ToString()))
                                if (ds.Tables[0].Rows[0]["password"].ToString() == txtPassword.Text.ToString())
                                {

                                    fnSetDefaultValues(ds);

                                }
                                else
                                {
                                    MessageBox.Show("Invalid Password.", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtPassword.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username.", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUserName.Focus();
                            return;
                        }

                    }

                    //// Writing the UserID,LanguageID in Flat File
                    Common.SetLoginDetailsToRegistry();

                    //DialogResult = DialogResult.OK;               
                    if (bRelogin)
                        DialogResult = DialogResult.OK;
                    else
                    {

                       Common.fMain.Visible = true;
                        Common.fMain.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        this.Hide();
                    }

                    txtPassword.Visible = false;
                    txtUserName.Visible = false;
                }
                else
                {
                    MessageBox.Show("Username cannot be blank.", Common.strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //this.DialogResult = DialogResult.Cancel;
                if (Common.sUserName != null)
                    this.DialogResult = DialogResult.Cancel;
                else
                {
                    Common.SetRunningStatus(true);
                    Application.Exit();
                }
                //this.Close();}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            try
            {

                txtPassword.SelectionStart = 0;
                txtPassword.SelectionLength = txtPassword.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUserName.SelectionStart = 0;
                txtUserName.SelectionLength = txtUserName.Text.Length;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    btnOK_Click(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = 0 - this.Height;
                this.Visible = false;


                //tmrMove.Enabled = false;

                string strLogin = "login";
                SetWindowText(this.Handle, Common.strProductName + " " + strLogin);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void fnSetDefaultValues(DataSet ds)
        {
            try
            {

                Common.sUserFullName = ds.Tables[0].Rows[0]["First_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Last_Name"].ToString();
                Common.sUserName = txtUserName.Text.ToString();

                Common.iUserID = int.Parse(ds.Tables[0].Rows[0]["User_Id"].ToString());
                Common.iUserType = int.Parse(ds.Tables[0].Rows[0]["UserType_id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        private void fnGetWindowsDeatils()
        {
            try
            {
                strSytemDomainName = System.Environment.UserDomainName;
                Common.strWindowsUser = strWindowsLoginName = System.Environment.UserName;

                string ipAddrees = "";

                for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
                {
                    ipAddrees = Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();

                    IPAddress address;
                    if (IPAddress.TryParse(ipAddrees, out address))
                    {
                        switch (address.AddressFamily)
                        {
                            case System.Net.Sockets.AddressFamily.InterNetwork:
                                // we have IPv4    
                                Common.strIPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();
                                break;
                            case System.Net.Sockets.AddressFamily.InterNetworkV6:
                                // we have IPv6   

                                break;
                            default:
                                break;
                        }
                    }
                }
                if (strSytemDomainName == "")
                    strWindowsLoginName = System.Environment.MachineName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK);
                Common.LogMessage(ex);
            }
        }
        private bool fnCheckWindowsUserWithTREuserAndAutologin()
        {
            try
            {


                fnGetWindowsDeatils();

                bool bIsAutoLogin = false;
                bool bIsActive = false;


                bool bIsWindowsPwd = false;
                if (clsObj.fnCheckUserName(strWindowsLoginName, ref bIsAutoLogin, ref bIsWindowsPwd, ref bIsActive))
                {
                    // system login user is in VTS



                    if (!bIsActive)
                    {
                        return false;
                    }

                    if (bIsAutoLogin)
                    {
                        // user has auntologin provision
                        if ((Common.sUserName != null) && (Common.sUserName != ""))
                            txtUserName.Text = Common.sUserName;
                        else
                            txtUserName.Text = strWindowsLoginName;
                        return true;
                        // direct open VTS with ou showing login details
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.LogMessage(ex);
                return false;
            }
        }
        private void tmrMove_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Left > ((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2))
                {
                    this.Top = this.Top + 20;
                    this.Visible = false;
                }
                else
                {
                    this.Top = ((Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                    tmrMove.Enabled = false;

                    this.Visible = true;

                    Application.DoEvents();

                    if (Common.sUserName != null)
                    {
                        tmrSplash.Enabled = false;
                        bRelogin = true;
                        //  lblAbout.Visible = true;
                        ShowLoginFields();
                        txtUserName.Focus();
                        return;
                    }

                    Common.fMain = new frmOriginal();

                    // Common.fMain = new frmMain();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }
        public bool ValidateUser(string UserName, string Pwd, string Domain)
        {
            IntPtr tokenHandle = IntPtr.Zero;
            try
            {
                //Call the LogonUser function to obtain a handle to an access token.
                bool returnValue = LogonUser(UserName, Domain, Pwd, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
                if (!returnValue)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == NativeMethods.WM_MOSAIQUE_BRING_TO_FRONT)
            {
                this.TopMost = true;
                this.Focus();
                this.TopMost = false;
                //teest
            }
            base.WndProc(ref message);
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    btnOK_Click(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogMessage(ex);
            }
        }

    }
}
