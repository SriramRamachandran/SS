using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GlobalDAL
/// </summary>
public class GlobalDAL
{
    SqlConnection con = null;
    SqlCommand cmd = null;

    public SqlConnection GlobalDAL1()
    {
        con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SSCONNSTRING"].ConnectionString);
        return (con);
    }
}