using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSWebApplication.AppCode.BAL;
using System.Data;

    public class LoginBAL
    {
        LoginDAL objDAL = new LoginDAL();
        public LoginBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void LoginVerification(string username, string pass, string hash, int roleid, string id, int securityid, string secanswer,int rand)
        {
            objDAL.LoginVerification(username, pass,hash,roleid,id,securityid,secanswer,rand);
        }

        public DataTable GetSecurityqs()
        {
            return objDAL.GetSecurityqs();
        }

        public DataTable IDgenerate(int id)
        {
            return objDAL.IDgenerate(id);
        }

        public DataTable GetLoginDetails(string username, string password)
        {
            return objDAL.GetLoginDetails(username,password);
        }

        public DataTable getpeopledetails(int id, string rolename)
        {
            return objDAL.getpeopledetails(id, rolename);
        }

        public void updateuserdetails(int count, string username,string from,string to)
        {
            objDAL.updateuserdetils(count, username,from,to);
        }

        public DataTable getid(string p)
        {
            return objDAL.getid(p);
        }
        public void updateapprovedetails(int userid)
        {
            objDAL.updateapprovedetails(userid);
        }
    }

