using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SSWebApplication.AppCode;

namespace SSWebApplication.AppCode.BAL
{
    public class LoginDAL
    {
        GlobalDAL ObjGlobal = new GlobalDAL();
        SqlConnection con = null;
        SqlCommand cmd = null;

        public LoginDAL()
        {
            con = ObjGlobal.GlobalDAL1();
        }

        public DataTable LoginVerification(string username, string pass,string hash)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@username",username),
                    new SqlParameter("@pass",pass),
                    new SqlParameter("@hash",hash),
                    new SqlParameter("@Mode","Login")
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;

        }
    }
}
