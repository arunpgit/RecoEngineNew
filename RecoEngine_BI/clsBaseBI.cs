using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecoEngine_DataLayer;

namespace RecoEngine_BI
{
    class clsBaseBI
    {

        public bool BeginTrans()
        {
            if (Common.iDBType == (int)Enums.DBType.Oracle)
                return  ((OraDBManager)Common.dbMgr).BeginTrans();
            else if(Common.iDBType == (int)Enums.DBType.Mysql)
                return ((MySqlDBManager)Common.dbMgr).BeginTrans();

            return ((DBManager)Common.dbMgr).BeginTrans();
        }
        public bool CommitTrans()
        {
            if (Common.iDBType == (int)Enums.DBType.Oracle)
                return ((OraDBManager)Common.dbMgr).CommitTrans();
            if (Common.iDBType == (int)Enums.DBType.Oracle)
                return ((MySqlDBManager)Common.dbMgr).CommitTrans();

            return ((DBManager)Common.dbMgr).CommitTrans();
            
        }
        public bool RollbackTrans()
        {
            if (Common.iDBType == (int)Enums.DBType.Oracle)
                return ((OraDBManager)Common.dbMgr).RollbackTrans();
           else if (Common.iDBType == (int)Enums.DBType.Mysql)
                return ((MySqlDBManager)Common.dbMgr).RollbackTrans();

            return ((DBManager)Common.dbMgr).RoolbackTrans();            
        }
    }
}
