using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Management;
using System.Diagnostics;
using System.Threading;
using RecoEngine_BI;
using System.Data;
using Telerik.WinControls;


namespace RecoEngine
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                bool bNewCreated = false;
                Mutex m = new Mutex(true, "RecoEngine", out bNewCreated);

                if (bNewCreated)
                {
                    //not running presently.


                    if (ConfigurationManager.AppSettings["ConnectionString"] != null && ConfigurationManager.AppSettings["ConnectionString"].ToString() != "")
                    {
                        RecoEngine_BI.Common.iDBType = 1;
                        RecoEngine_BI.Common.SetConnectionString(ConfigurationManager.AppSettings["ConnectionString"].ToString());
                                      
                       Common.bIsConnectionStringEstablish = true;
                    
                        if (fnCheckDBUpdate())
                        {
                    
                            Common.SetRunningStatus(false);
                            bool bIsExitTheApplication = false;
                            if (bIsExitTheApplication)
                                return;

                            if (fnCheckLicense() == false)
                                return;
                            // fnFixColumnRename();

                            Application.Run(new frmLogin());
                            Common.SetRunningStatus(true);
                            m.ReleaseMutex();
                        }
                        else
                        {
                            Common.SetRunningStatus(true);
                        }
                    }
                    else if (ConfigurationManager.AppSettings["MysqlConnectionString"] != null && ConfigurationManager.AppSettings["MysqlConnectionString"].ToString() != "")
                    { 
                        RecoEngine_BI.Common.iDBType = 3;
                        RecoEngine_BI.Common.SetConnectionString(ConfigurationManager.AppSettings["MysqlConnectionString"].ToString());

                        Common.bIsConnectionStringEstablish = true;

                        if (fnCheckDBUpdate())
                        {

                            Common.SetRunningStatus(false);
                            bool bIsExitTheApplication = false;
                            if (bIsExitTheApplication)
                                return;

                            if (fnCheckLicense() == false)
                                return;
                            // fnFixColumnRename();

                            Application.Run(new frmLogin());
                            Common.SetRunningStatus(true);
                            m.ReleaseMutex();
                        }
                        else
                        {
                            Common.SetRunningStatus(true);
                        }
                    }
                    else
                    {                       
                        Common.bIsConnectionStringEstablish = false;                       
                        Application.Run(new frmDatsource());                       
                    }

                   


                }
            }

            catch (Exception ex)
            {                
                Telerik.WinControls.RadMessageBox.Show(ex.Message, "RecoEngine", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                if (ex.InnerException != null)
                {
                    Telerik.WinControls.RadMessageBox.Show(ex.InnerException.Message, "RecoEngine", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    //MessageBox.Show(ex.InnerException.Message, "RecoEngine2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.StackTrace != null)
                {
                    Telerik.WinControls.RadMessageBox.Show(ex.StackTrace, "RecoEngine", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);                    
                }

                Common.LogMessage(ex);
                Common.SetRunningStatus(true);
            }

        }

        private static bool fnCheckDBUpdate()
        {
            return true;
        }
        private static bool fnCheckLicense()
        {
            return true;
        }

    }
}


