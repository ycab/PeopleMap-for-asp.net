using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
namespace peopleMap.Models
{
    public class OracleClobField : PatchForOracleLobField
    {
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (cmd is OracleCommand)
            {
                //CLob、NClob类型的字段，存入中文时参数的OracleDbType必须设置为OracleDbType.Clob
                //否则会变成乱码（Oracle 10g client环境）
                OracleParameter param = cmd.Parameters[index] as OracleParameter;
                if (param != null)
                {
                    param.OracleType = OracleType.Clob;// 关键就这里啦
                    param.IsNullable = true;
                }
            }
            NHibernate.NHibernateUtil.StringClob.NullSafeSet(cmd, value, index);
        }
    }
}