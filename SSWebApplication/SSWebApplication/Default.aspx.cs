using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;

namespace SSWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        LoginBAL objBAL = new LoginBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPages();
                lblusername.Text = "Admin";
                if (Session["username"] != null)
                {
                    lblusername.Text = Session["username"].ToString();
                    Label1.Text = Session["ID"].ToString();
                }
            }
        }

        private void LoadPages()
        {
            DataTable dt = (DataTable)Session["dt"];
            string rolename = dt.Rows[0]["RoleName"].ToString();
            if (dt.Rows.Count > 0)
            {
                if (rolename == "Student") { div2.Visible = false; div3.Visible = false; div1.Visible = true; }
                else if (rolename == "Staff") { div2.Visible = true; div3.Visible = false; div1.Visible = true; }
                else { div2.Visible = true; div3.Visible = true; div1.Visible = true; }
            }
            else
            {
                //Do Nothing
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            int listItemIds = 1;
            List<string> dirList = new List<string>();
            string path = Server.MapPath(".");
            path = path + "\\Documents\\";
            var filenames4 = Directory
                .EnumerateFiles(path, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            foreach (string d in filenames4)
            {
                dirList.Add(d);
            }
            for (int i = 0; i < dirList.Count; i++)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                LinkButton lnk = new LinkButton();

                lnk.ID = "lnk" + listItemIds;
                lnk.Text = String.Format("{0}", dirList[i]);
                lnk.Click += Clicked;
                li.Controls.Add(lnk);
                ul1.Controls.Add(li);
                listItemIds++;
            }
        }

        public void Clicked(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            string id = clickedButton.Text;
            string path = Server.MapPath(".");
            path = path + "\\Documents\\";
            System.Diagnostics.Process.Start(path + id);
        }

        private void LoadFiles()
        {
            List<string> dirList = new List<string>();
            string path = Server.MapPath(".");
            path = path + "\\Documents\\";
            var filenames4 = Directory
                .EnumerateFiles(path, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            foreach (string d in filenames4)
            {
                dirList.Add(d);
            }
            HtmlGenericControl list = new HtmlGenericControl("ul");
            for (int i = 0; i < dirList.Count; i++)
            {
                HtmlGenericControl listItem = new HtmlGenericControl("li");
                LinkButton textLabel = new LinkButton();
                textLabel.ID = String.Format("{0}", dirList[i]);
                textLabel.Text = String.Format("{0}", dirList[i]);
                textLabel.Click += new EventHandler(lnk_Click);
                listItem.Controls.Add(textLabel);
                list.Controls.Add(listItem);
            }
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            string id = clickedButton.ID;
            string path = Server.MapPath(".");
            path = path + "\\Documents\\";
            System.Diagnostics.Process.Start(path + id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(".");
            path = path + "\\Documents\\";
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(path + FileName);
            }
            Response.Redirect("Default.aspx");
        }

        protected void roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["dt"];
                int id = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                string rolename = roles.SelectedItem.Text;
                Loadpeople(id, rolename);
            }
            catch (Exception ee) { }
        }

        protected void Loadpeople(int id, string rolename)
        {
            DataTable dt = new DataTable();
            dt = objBAL.getpeopledetails(id, rolename);
            ddlpeople.DataSource = dt;
            ddlpeople.DataTextField = "Username";
            ddlpeople.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int count = 0;
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        count++;
                    }
                }
                if (CheckBox1.Checked == true) { count = 3; }
                string username = ddlpeople.SelectedItem.Text;
                dt = objBAL.getid(username);
                string id = dt.Rows[0]["ID"].ToString();
                id = id.Substring(9, 4);
                if (count == 1)
                {
                    objBAL.updateuserdetails(count, username,id,"STUD");
                }
                else if(count==2)
                {
                    objBAL.updateuserdetails(count, username, id, "STAF");
                }
                else 
                    objBAL.updateuserdetails(count, username,id,"ADMN");
                Response.Redirect("Default.aspx");
            }
            catch (Exception ee) { }
        }
    }
}