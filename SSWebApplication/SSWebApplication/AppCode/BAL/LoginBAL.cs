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

        public DataTable LoginVerification(string username, string pass,string hash)
        {
            return objDAL.LoginVerification(username, pass,hash);
        }
    }

