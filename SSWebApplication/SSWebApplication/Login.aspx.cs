using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    LoginBAL objBAL = new LoginBAL();
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        dt = objBAL.GetLoginDetails(username.Text, password.Text);
        Session["dt"] = dt;
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Approved"].ToString() == "Yes")
            {
                count = 0;
                lblMsg.Text = "Login Successfull";
                Session["username"] = dt.Rows[0]["Username"].ToString();
                Session["ID"] = dt.Rows[0]["ID"].ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Login Successfull", true);
                Response.Redirect("QRCode.aspx");
            }
            else
            {
                lblMsg.Text = "Admin didn't approve you. Wait for approval...";
            }
        }
        else
        {
            count++;
            lblMsg.Text = "Login Failed!!!";
            //int id=Convert.ToInt32(dt.Rows[0]["UserID"]);
            if ((count > 3))// && (id!=3))
            {
                //objBAL.updateapprovedetails(id);
                lblMsg.Text = "Password has been mistyped 3 times...Wait for Admin to approve you!!!";
            }
        }
    }
}
