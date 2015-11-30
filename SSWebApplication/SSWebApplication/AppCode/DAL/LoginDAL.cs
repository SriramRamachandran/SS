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

        public void LoginVerification(string username, string pass,string hash,int roleid,string id,int securityid,string secanswer,int rand)
        {
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "Login");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@roleid", roleid);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@secid", securityid);
            cmd.Parameters.AddWithValue("@secans", secanswer);
            cmd.Parameters.AddWithValue("@rand", rand);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        

        public DataTable GetSecurityqs()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@Mode","Securityqs")
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;
        }

        public DataTable GetLoginDetails(string username, string password)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@Mode","getlogindetails"),
                    new SqlParameter("@username",username),
                    new SqlParameter("@pass",password)
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;
        }

        public DataTable IDgenerate(int id)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@Mode","IDgenerate"),
                    new SqlParameter("@roleid",id)
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;
        }

        public DataTable getpeopledetails(int id, string rolename)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@Mode","getpeople"),
                    new SqlParameter("@rolename",rolename)
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;
        }

        public void updateuserdetils(int count, string username,string from,string to)
        {
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "updateuserdetails");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@roleid", count);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getid(string p)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;

            cmd.Parameters.AddRange(
                    new SqlParameter[] {
                    new SqlParameter("@Mode","getid"),
                    new SqlParameter("@username",p)
                }
                );

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            return dt;
        }

        public void updateapprovedetails(int userid)
        {
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "updateapprovaldetails");
            cmd.Parameters.AddWithValue("@userid", userid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
