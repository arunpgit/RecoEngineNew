using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RecoEngine_DataLayer;
using System.Data;

namespace RecoEngine_BI
{
    public class clsUsers
    {
        public clsUsers()
        {
        }

        public bool fnActiveUsers(string strUserId)
        {
            bool flag;
            try
            {
                string[] strArrays = strUserId.Split(new char[] { ';' });
                if ((int)strArrays.Length > 0)
                {
                    if (Common.iDBType == 1 || Common.iDBType == 2)
                    {
                        string str = string.Concat("UPDATE Users SET  ISACTIVE = ", strArrays[1], " WHERE  USER_ID = ", strArrays[0]);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if(Common.iDBType == 3)
                    {
                        string str = string.Concat("UPDATE Users SET  ISACTIVE = ", strArrays[1], " WHERE  USER_ID = ", strArrays[0]);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);

                    }
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataSet fnCheckUser(string strUserName)
        {
            DataSet dataSet;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    DataSet dataSet1 = new DataSet();
                    string str = string.Concat("select * from users where username='", strUserName, "'");
                    dataSet1 = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str));
                    dataSet = dataSet1;
                }
                else
                {
                    DataSet dataSet1 = new DataSet();
                    string str = string.Concat("select * from users where username='", strUserName, "'");
                    dataSet1 = (((MySqlDBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str));
                    dataSet = dataSet1;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }

        public bool fnCheckUserName(string strUserName, ref bool bIsWindowsPassword)
        {
            bool flag = false;
            bool flag1 = false;
            return this.fnCheckUserName(strUserName, ref flag, ref bIsWindowsPassword, ref flag1);
        }

        public bool fnCheckUserName(string strUserName, ref bool bIsAutologin, ref bool bIsWindowsPassword, ref bool bIsActive)
        {
            bool flag;
            try
            {
                DataSet dataSet = new DataSet();
                string str = string.Concat("select * from users where username='", strUserName, "'");
                if (Common.iDBType ==1 || Common.iDBType ==2)
                {
                    dataSet = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str));

                }
                else if(Common.iDBType == 3)
                {
                    dataSet = ((MySqlDBManager)Common.dbMgr).ExecuteDataSet(CommandType.Text, str);
                }
                if (dataSet.Tables[0].Rows.Count <= 0)
                {
                    flag = false;
                }
                else

                {
                    if (dataSet.Tables[0].Rows[0]["UseWindowsPassword"] != null && dataSet.Tables[0].Rows[0]["UseWindowsPassword"].ToString() != "")
                    {
                        bIsWindowsPassword = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["UseWindowsPassword"]);
                    }
                    if (dataSet.Tables[0].Rows[0]["AutoLogin"] != null && dataSet.Tables[0].Rows[0]["AutoLogin"].ToString() != "")
                    {
                        bIsAutologin = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["AutoLogin"]);
                    }
                    if (dataSet.Tables[0].Rows[0]["IsActive"] != null && dataSet.Tables[0].Rows[0]["IsActive"].ToString() != "")
                    {
                        bIsActive = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsActive"]);
                    }
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool fnDeleteUser(string strId)
        {
            bool flag;
            try
            {
                string str = string.Concat("Delete from Users where user_id=", strId);
                if (Common.iDBType == 2)
                {
                    ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if(Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if(Common.iDBType ==3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);

                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataTable fnGetUsersDetails()
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = string.Concat("Select A.User_ID, A.FIRST_NAME,A.LAST_NAME,Case When A.USERTYPE_ID=", 0, " Then 'Administrators'");
                object obj = str;
                object[] objArray = new object[] { obj, " When A.USERTYPE_ID=", 3, " Then 'Employees' When A.USERTYPE_ID=", 4, " Then 'Customers' " };
                str = string.Concat(objArray);
                object obj1 = str;
                object[] objArray1 = new object[] { obj1, " When A.USERTYPE_ID=", 2, " Then 'Managers' When A.USERTYPE_ID=", 1, " Then 'Operators' Else 'Administrators' End as UserType" };
                str = string.Concat(objArray1);
                str = string.Concat(str, " ,A.USERNAME,A.EMAIL,Case When A.ISACTIVE=1 Then 'Yes' Else 'NO' End as IsActive,'' as Flag from Users A");
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    dataTable1 = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }
                else
                {
                    dataTable1 = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                    dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable fnGetUsersDetails(int iUserId)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = string.Concat("Select User_ID, FIRST_NAME,LAST_NAME,USERTYPE_ID,USERNAME,EMAIL,ISACTIVE from Users Where User_Id=", iUserId);
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }
                else
                {
                    dataTable1 = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                    dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public void fnSaveUser(int iUserId, string strFName, string strLName, int iUserType, string strUserName, string strPassword, string strEmail, int iIsActive)
        {
            try
            {
                string str = "";
                if (iUserId != 0)
                {
                    str = "Update Users Set ";
                    str = string.Concat(str, "FIRST_NAME = '", strFName.Replace("'", "''"), "',");
                    str = string.Concat(str, "LAST_NAME='", strLName.Replace("'", "''"), "',");
                    object obj = str;
                    object[] objArray = new object[] { obj, "USERTYPE_ID=", iUserType, "," };
                    str = string.Concat(objArray);
                    str = string.Concat(str, "EMAIL='", strEmail.Replace("'", "''"), "',");
                    str = string.Concat(str, "USERNAME='", strUserName.Replace("'", "''"), "',");
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, "ISACTIVE=", iIsActive, " Where USER_ID=", iUserId };
                    str = string.Concat(objArray1);
                }
                else
                {
                    str = "Insert into Users (FIRST_NAME,LAST_NAME,USERTYPE_ID,USERNAME,PASSWORD,EMAIL,ISACTIVE) values(";
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, "'", strFName.Replace("'", "''"), "','", strLName.Replace("'", "''"), "',", iUserType, ",'", strUserName.Replace("'", "''"), "'," };
                    str = string.Concat(objArray2);
                    object obj3 = str;
                    object[] objArray3 = new object[] { obj3, "'", strPassword.Replace("'", "''"), "','", strEmail.Replace("'", "''"), "',", iIsActive, ")" };
                    str = string.Concat(objArray3);
                }
                if (Common.iDBType == 2)
                {
                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                else if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
