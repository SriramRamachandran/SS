using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace SSWebApplication
{
    public partial class QRCode : System.Web.UI.Page
    {
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
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
                }
                //plBarCode.Controls.Add(imgBarCode);
                //img.
                imagesave(code,imgBarCode);
            }
        }

        protected void imagesave(string name, System.Web.UI.WebControls.Image imgs)
        {
            try
            {
                string root = Server.MapPath("~");
                string path = "\\Images\\QRCodes" + name;
                string originalpath = System.IO.Path.Combine(root, path);
                //bool isExists = System.IO.Directory.Exists(Server.MapPath(@"~\\" + originalpath));
                //if (!isExists)
                //{
                //    System.IO.Directory.CreateDirectory(Server.MapPath(@"~\\" + originalpath));
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already exists')", true);
                //}
                if (img.ImageUrl != null)
                {
                    MemoryStream stream = new MemoryStream();
                    
                }

                Bitmap b = new Bitmap(Server.MapPath(originalpath));
                System.Drawing.Image i = (System.Drawing.Image)b;
                MemoryStream streamP = new MemoryStream();
                i.Save(streamP, ImageFormat.Jpeg);
                streamP.Position = 0;
                byte[] data = new byte[streamP.Length];
                streamP.Read(data, 0, Convert.ToInt32(streamP.Length)); 
            }
            catch (Exception ee) { }
        }
    }
}