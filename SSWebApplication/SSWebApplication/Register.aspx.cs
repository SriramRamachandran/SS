using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSWebApplication
{
    public partial class Register : System.Web.UI.Page
    {
        public static string strResult = "fail";
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;
        LoginBAL objBAL = new LoginBAL();
        DateTime dtt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdown();
            }
        }

        private void LoadDropdown()
        {
            DataTable dt = new DataTable();
            dt = objBAL.GetSecurityqs();
            ddlsecurity.DataSource = dt;
            ddlsecurity.DataTextField = "Security_qs";
            ddlsecurity.DataBind();
            ddlsecurity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (strResult == "success")
            {
                string hashvalue = CreateHash(password.Text);
                TDStatus.InnerText = "Registerd Successfully! Proceed Next..";
                Random generator = new Random();
                String r = generator.Next(0, 1000000).ToString("D6");
                objBAL.LoginVerification(username.Text, password.Text, hashvalue, roles.SelectedIndex+1, ID.Text, ddlsecurity.SelectedIndex, securityanswer.Text,Convert.ToInt32(r));
                Response.Redirect("Login.aspx");
            }
            else
            {
                TDStatus.InnerText = "Password must use a combination of these :" + Environment.NewLine + "I.Atleast 1 upper case letters (A – Z)" + Environment.NewLine + "II.Lower case letters (a – z)" + Environment.NewLine + "III.Atleast 1 number (0 – 9)" + Environment.NewLine + "IV.Atleast 1 non-alphanumeric symbol (e.g. @ ‘$%£!’)";
            }
        }

        [WebMethod]
        public static string ValidatePassword(string password)
        {
            try
            {
                bool result = false;
                bool isDigit = false;
                bool isLetter = false;
                bool isLowerChar = false;
                bool isUpperChar = false;
                bool isNonAlpha = false;

                foreach (char c in password)
                {
                    if (char.IsDigit(c))
                        isDigit = true;
                    if (char.IsLetter(c))
                    {
                        isLetter = true;
                        if (char.IsLower(c))
                            isLowerChar = true;
                        if (char.IsUpper(c))
                            isUpperChar = true;
                    }
                    Match m = Regex.Match(c.ToString(), @"\W|_");
                    if (m.Success)
                        isNonAlpha = true;
                }

                if (isDigit && isLetter && isLowerChar && isUpperChar && isNonAlpha)
                    result = true;

                if (result)
                    strResult = "success";
            }
            catch
            {
                strResult = "fail";
            }

            return strResult;

        }

        protected void roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int id = roles.SelectedIndex;
            dt = objBAL.IDgenerate(id+1);
            string name = null;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string substring = dt.Rows[dt.Rows.Count - 1]["ID"].ToString();
                    if (roles.SelectedIndex == 0)
                    {
                        substring = substring.Substring(13);
                        int idd = Convert.ToInt32(substring);
                        name = "CB.EN.CSESTUD" + (idd + 1); 
                    }
                    else if (roles.SelectedIndex == 1)
                    {
                        substring = substring.Substring(13);
                        int idd = Convert.ToInt32(substring);
                        name = "CB.EN.CSESTAF" + (idd + 1); 
                    }
                    else
                    {
                        substring = substring.Substring(13);
                        int idd = Convert.ToInt32(substring);
                        name = "CB.EN.CSEADMN" + (idd + 1); 
                    }
                }
                else
                {
                    if (roles.SelectedIndex == 0)
                    {
                        name = "CB.EN.CSESTUD"+100;
                    }
                    else if (roles.SelectedIndex == 1)
                    {
                        name = "CB.EN.CSESTAF"+100;
                    }
                    else 
                    {
                        name = "CB.EN.CSEADMN"+100;
                    }
                }
                ID.Enabled = true;
                ID.Text = name;
                ID.Enabled = false;
            }
            catch(Exception ee)
            {
            }
        }


    }
}