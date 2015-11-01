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
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
    
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
            Page.MaintainScrollPositionOnPostBack = true;
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            //if (Request["__EVENTTARGET"] == "Button2") { btnSubmit_ServerClick(); }
        }

        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = Wizard1.WizardSteps;
            SideBarList.DataBind();
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

        protected string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = Wizard1.WizardSteps.IndexOf(step);

            if (stepIndex < Wizard1.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > Wizard1.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
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


        protected void btnSubmit_Click(object sender,EventArgs e)
        {
            if (strResult == "success")
            {
                string hashvalue = CreateHash(password.Text);
                //objBAL.LoginVerification(username.Text, password.Text,hashvalue);
                TDStatus.InnerText = "Registerd Successfully! Proceed Next..";
                username.Text = "";
                Random generator = new Random();
                String r = generator.Next(0, 1000000).ToString("D6");
                Session["hiddenOTP"] = r;
                QRgenerator(r);
            }
            else
            {
                TDStatus.InnerText = "Password must use a combination of these :" + Environment.NewLine + "I.Atleast 1 upper case letters (A – Z)" + Environment.NewLine + "II.Lower case letters (a – z)" + Environment.NewLine + "III.Atleast 1 number (0 – 9)" + Environment.NewLine + "IV.Atleast 1 non-alphanumeric symbol (e.g. @ ‘$%£!’)";
            }
        }

        protected void QRgenerator(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.H);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    Session["imgBarcode"] = imgBarCode;
                }
                plBarCode.Controls.Add((System.Web.UI.WebControls.Image)Session["imgBarcode"]);
            }
        }
    }
