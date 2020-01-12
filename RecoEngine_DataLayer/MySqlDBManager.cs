using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;

namespace RecoEngine_DataLayer
{
   public class MySqlDBManager
    {
        #region "Variable & Declaration"

         MySqlConnection _cn;
        private string sConnectionString = "";
        public string strProductName = "";

        private bool bDebugOn = false;

        public void SetDebug(bool bValue)
        {
            bDebugOn = bValue;
        }

        private MySqlTransaction _Transaction;
        public bool bInTransaction = false;
        #endregion "Variable & Declaration"

        # region "Constructor"

        public MySqlDBManager(string sConStr)
        {
            sConnectionString = sConStr;
        }

        #endregion "Constructor"



        #region "Begin Commit Rollback"
        public bool BeginTrans()
        {
            try
            {
                OpenConnection();
                _Transaction = _cn.BeginTransaction();
                bInTransaction = true;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CommitTrans()
        {
            try
            {
                _Transaction.Commit();
                CloseConnection();
                bInTransaction = false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RollbackTrans()
        {
            try
            {
                _Transaction.Rollback();
                CloseConnection();
                bInTransaction = false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        # endregion "Begin Commit Rollback"

        private MySqlConnection Con
        {
            get { return _cn; }
            set
            {
                _cn = value;
                _cn.Open();
            }
        }

        public string GetConnectionString
        {

            get { return sConnectionString; }

        }

        public void GetConnectionAttributes(ref string sDataSource, ref string sDatabase, ref string sUserId, ref string sPassword)
        {
            string[] sAttrib = sConnectionString.Split(';');
            string[] sArrTemp = null;

            for (int i = 0; i < sAttrib.Length; i++)
            {
                sArrTemp = sAttrib[i].Split('=');
                if (sArrTemp.Length == 2)
                {
                    if (sArrTemp[0] == "Data Source")
                        sDataSource = sArrTemp[1].Trim();
                    else if (sArrTemp[0] == "Initial Catalog")
                        sDatabase = sArrTemp[1].Trim();
                    else if (sArrTemp[0] == "User Id")
                        sUserId = sArrTemp[1].Trim();
                    else if (sArrTemp[0] == "Password")
                        sPassword = sArrTemp[1].Trim();
                }
            }
        }

        private void CloseConnection()
        {
            if ((_cn != null))
            {
                _cn.Close();
                _cn.Dispose();
                _cn = null;
            }
        }

        private void OpenConnection()
        {
            _cn = new MySqlConnection(sConnectionString);
            if ((_cn != null))
            {
                _cn.Open();
            }
        }


        private void AttachParameters(MySqlCommand Cmd, MySqlParameter[] Param)
        {

            if (Cmd == null)
                throw new ArgumentNullException("Cmd");

            if (Param == null)
            {
                foreach (MySqlParameter p in Param)
                {
                    if ((p != null))
                    {
                        if ((p.Direction == ParameterDirection.InputOutput | p.Direction == ParameterDirection.Input) & p.Value.ToString() == "")
                        {
                            p.Value = DBNull.Value;
                        }
                    }
                    Cmd.Parameters.Add(p);
                }
            }
            else
            {
                foreach (MySqlParameter p in Param)
                {
                    Cmd.Parameters.Add(p);

                }
            }
        }

        private void PrepareCommand(ref MySqlCommand Cmd, CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {

            if (Cmd == null)
            {
                throw new ArgumentNullException("Cmd");
            }

            if (CmdText == "" | CmdText.Length == 0)
            {
                throw new ArgumentNullException("CmdText");
            }

            if (!bInTransaction)
            {
                if (!(Con.State == ConnectionState.Open))
                {
                    OpenConnection();
                }
            }

            Cmd.Connection = Con;

            if (bInTransaction)
                Cmd.Transaction = _Transaction;

            Cmd.CommandText = CmdText;
            Cmd.CommandType = CmdType;
            Cmd.CommandTimeout = 6000;
            if ((Params != null))
            {
                AttachParameters(Cmd, Params);
            }
        }

        public int ExecuteNonQuery(CommandType CmdType, string CmdText)
        {
           
            return ExecuteNonQuery(CmdType, CmdText, (MySqlParameter[])null);
        }
        public int ExecuteNonQueryprocedure(CommandType CmdType, string CmdText,MySqlParameter[] param,MySqlCommand cmd,string sql)
        {

            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            try
            {

                int retVal;
               if (!bInTransaction)
                    OpenConnection();
                PrepareCommand(ref cmd, CmdType, CmdText, param);

                if (bInTransaction)
                    cmd.Transaction = _Transaction;

                retVal = cmd.ExecuteNonQuery();

                if (!bInTransaction)
                    CloseConnection();

                cmd.Parameters.Clear();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int ExecuteNonQuery(MySqlCommand cmd)
        {
            if (!bInTransaction)
                OpenConnection();
            
            cmd.Connection = Con;
            if (bInTransaction)
                cmd.Transaction = _Transaction;

            int iResult = cmd.ExecuteNonQuery();
            cmd.CommandTimeout = 60;

            if (!bInTransaction)
                CloseConnection();

            return iResult;

        }


        public int ExecuteNonQuery(CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {

            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                int retVal;

                if (!bInTransaction)
                    OpenConnection();
                PrepareCommand(ref cmd, CmdType, CmdText, Params);

                if (bInTransaction)
                    cmd.Transaction = _Transaction;

                retVal = cmd.ExecuteNonQuery();

                if (!bInTransaction)
                    CloseConnection();

                cmd.Parameters.Clear();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(CommandType CmdType, string CmdText, MySqlParameter[] Params, bool bIsOutParms)
        {

            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                int retVal;

                if (!bInTransaction)
                    OpenConnection();

                PrepareCommand(ref cmd, CmdType, CmdText, Params);

                if (bInTransaction)
                    cmd.Transaction = _Transaction;

                retVal = cmd.ExecuteNonQuery();
                if (bIsOutParms)
                    retVal = Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
                if (!bInTransaction)
                    CloseConnection();

                cmd.Parameters.Clear();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExecuteDataSet(CommandType CmdType, string CmdText)
        {
           
            return ExecuteDataSet(CmdType, CmdText, (MySqlParameter[])null);
        }

        public DataSet ExecuteDataSet(CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {
            try
            {
                if (bDebugOn == true)
                    System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                MySqlCommand cmd = new MySqlCommand();

                if (!bInTransaction)
                    OpenConnection();

                PrepareCommand(ref cmd, CmdType, CmdText, Params);

                if (bInTransaction)
                    cmd.Transaction = _Transaction;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (!bInTransaction)
                    CloseConnection();

                cmd.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteDataTable(CommandType CmdType, string CmdText)
        {
             return ExecuteDataTable(CmdType, CmdText, (MySqlParameter[])null);
        }

        public DataTable ExecuteDataTable(CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {

            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            MySqlCommand cmd = new MySqlCommand();
            if (!bInTransaction)
                OpenConnection();

            PrepareCommand(ref cmd, CmdType, CmdText, Params);

            if (bInTransaction)
                cmd.Transaction = _Transaction;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (!bInTransaction)
                CloseConnection();

            cmd.Parameters.Clear();
            return dt;
        }
        public MySqlDataReader ExecuteReader(CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {

            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;

            if (!bInTransaction)
                OpenConnection();

            PrepareCommand(ref cmd, CmdType, CmdText, Params);

            if (bInTransaction)
                cmd.Transaction = _Transaction;

            dr = cmd.ExecuteReader();

            if (!bInTransaction)
                CloseConnection();

            cmd.Parameters.Clear();
            return dr;
        }


        public string ExecuteScalar(CommandType CmdType, string CmdText)
        {
           
            return ExecuteScalar(CmdType, CmdText, (MySqlParameter[])null);
        }

        public string ExecuteScalar(CommandType CmdType, string CmdText, MySqlParameter[] Params)
        {
            Object rValue;
            if (bDebugOn == true)
                System.Windows.Forms.MessageBox.Show(CmdText, strProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            MySqlCommand cmd = new MySqlCommand();

            if (!bInTransaction)
                OpenConnection();

            PrepareCommand(ref cmd, CmdType, CmdText, Params);

            if (bInTransaction)
                cmd.Transaction = _Transaction;

            rValue = cmd.ExecuteScalar();

            if (!bInTransaction)
                CloseConnection();

            cmd.Parameters.Clear();

            if (rValue == null)
                return "";
            else
                return rValue.ToString();
        }

        public int GetInsertedMasterProject(int P_EPM_PROJECT_ID, int P_VENDOR_ID, string P_PROJECT_DESC, DateTime P_PROJECT_START_DATE, int P_CURRENCY_ID, int P_EXCHANGE_RATE, int P_DEPT_UNIT_ID, string P_CONTRACT_NO)
        {
            MySqlCommand cmd = new MySqlCommand();
            OpenConnection();
            cmd.Connection = _cn;
            cmd.CommandText = "TESTEPM.INS_PROJECT_MASTER";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlParameter par;

            par = new MySqlParameter("P_EPM_PROJECT_ID", MySqlDbType.Int32);
            par.Value = P_EPM_PROJECT_ID;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_VENDOR_ID", MySqlDbType.Int32);
            par.Value = P_VENDOR_ID;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_PROJECT_DESC", MySqlDbType.VarChar);
            par.Value = P_PROJECT_DESC;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_PROJECT_START_DATE", MySqlDbType.DateTime);
            par.Value = P_PROJECT_START_DATE;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_CURRENCY_ID", MySqlDbType.Int32);
            par.Value = P_CURRENCY_ID;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_EXCHANGE_RATE", MySqlDbType.Int32);
            par.Value = P_EXCHANGE_RATE;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_DEPT_UNIT_ID", MySqlDbType.Int32);
            par.Value = P_DEPT_UNIT_ID;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("P_CONTRACT_NO", MySqlDbType.VarChar);
            par.Value = P_CONTRACT_NO;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("RETURN_VALUE", MySqlDbType.Int32);
            par.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
            CloseConnection();
            return Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
        }
        public void savepotentialRankingExport(int ProjectId)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["MysqlConnectionString"].ToString());
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "recousr.Inserttreranking_base";
                cmd.CommandTimeout = 6000;
                cmd.CommandType = CommandType.StoredProcedure;
                //MySqlParameter par;

                //par = new MySqlParameter("@ProjectId", MySqlDbType.Int16);
                //par.Value = ProjectId;
                //par.Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
              
        }

        public int GetInsertedProjectMilestone(int p_project_id, int p_epm_milestone_id, string p_milestone_code, string p_milestone_desc, int p_milestone_amount, int p_currency_id, int p_exchange_rate)
        {
            MySqlCommand cmd = new MySqlCommand();
            OpenConnection();
            cmd.Connection = _cn;
            cmd.CommandText = "<sd$epm.insert_project_milestone>";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlParameter par =
            new MySqlParameter("RETURN_VALUE", MySqlDbType.Int32);
            par.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_project_id", MySqlDbType.Int32);
            par.Value = p_project_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_epm_milestone_id", MySqlDbType.Int32);
            par.Value = p_epm_milestone_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_milestone_code", MySqlDbType.VarChar);
            par.Value = p_milestone_code;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_milestone_desc", MySqlDbType.VarChar);
            par.Value = p_milestone_desc;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_milestone_amount", MySqlDbType.Int32);
            par.Value = p_milestone_amount;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_currency_id", MySqlDbType.Int32);
            par.Value = p_currency_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_exchange_rate", MySqlDbType.Int32);
            par.Value = p_exchange_rate;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
            CloseConnection();
            return Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
        }

        public int GetInsertedMilestoneInvoice(int p_milestone_id, int p_epm_invoice_id, int p_vendor_id, string p_desc_n, DateTime p_invoice_date, string p_invoice_no, int p_invoice_amount, int p_penalty_amount, string p_penalty_desc, int p_currency_id, int p_exchange_rate, string p_file_name)
        {
            MySqlCommand cmd = new MySqlCommand();
            OpenConnection();
            cmd.Connection = _cn;
            cmd.CommandText = "<sd$epm.insert_milestone_invoice>";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlParameter par =
            new MySqlParameter("RETURN_VALUE", MySqlDbType.Int32);
            par.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_milestone_id", MySqlDbType.Int32);
            par.Value = p_milestone_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_epm_invoice_id", MySqlDbType.Int32);
            par.Value = p_epm_invoice_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_vendor_id", MySqlDbType.Int32);
            par.Value = p_vendor_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_desc_n", MySqlDbType.VarChar);
            par.Value = p_desc_n;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_invoice_date", MySqlDbType.DateTime);
            par.Value = p_invoice_date;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_invoice_no", MySqlDbType.VarChar);
            par.Value = p_invoice_no;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_invoice_amount", MySqlDbType.Int32);
            par.Value = p_invoice_amount;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_penalty_amount", MySqlDbType.Int32);
            par.Value = p_penalty_amount;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_penalty_desc", MySqlDbType.VarChar);
            par.Value = p_penalty_desc;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_currency_id", MySqlDbType.Int32);
            par.Value = p_currency_id;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_exchange_rate", MySqlDbType.Int32);
            par.Value = p_exchange_rate;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            par = new MySqlParameter("p_file_name", MySqlDbType.VarChar);
            par.Value = p_file_name;
            par.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
            CloseConnection();
            return Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
        }

    }

}

