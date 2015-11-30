<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SSWebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <style type="text/css">
        #form1 {
            height: 418px;
        }
    </style>
</head>
<body style="background-image: url('image1.jpg'); background-repeat: inherit; height: 273px;">
    <form id="form1" runat="server">
        <div style="float: right; margin-right: 20px; margin-top: 5px;">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" onClick="if(confirm('Are you sure want to logout?'))return true; else return false;">
                <asp:Image ID="Image1" runat="server" Width="20px" Height="20px" ImageUrl="~/logout.png" />
            </asp:HyperLink>
        </div>
        <div style="float:left;">
            <span style="color: firebrick; font-weight: bold;">Your ID: </span><span style="color: green; font-weight: bold;">
                <asp:Label ID="Label1" runat="server"></asp:Label></span>
        </div>
        <div style="float: right; width: auto; height: auto; font-size: 20px; margin-right: 20px;">
            <span style="color: firebrick; font-weight: bold;">Welcome </span><span style="color: Red; font-weight: bold;">
                <asp:Label ID="lblusername" runat="server"></asp:Label></span>
        </div>
        <div style="float: left; width: 100%; height: 158px;">
            <h2 style="margin-left: 463px">Role Based Access Rights</h2>
            <div id="div1" runat="server" style="width: 33%; float: left">
                <h3>List of Documents</h3>
                <ul id="ul1" runat="server"></ul>
            </div>
            <div id="div2" runat="server" style="width: 33%; float: left; height: 87px;">
                <h3>Read and Write Files</h3>
                <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
                <span style="color: green;">
                    <asp:Label ID="lblfileupload" runat="server"></asp:Label></span>
            </div>
            <div id="div3" runat="server" style="width: 33%; float: left">
                <h3>Adding Users</h3>
                <asp:Label ID="Label3" runat="server"> Role</asp:Label>
                <asp:RadioButtonList ID="roles" runat="server" AutoPostBack="true" RepeatDirection="Vertical" OnSelectedIndexChanged="roles_SelectedIndexChanged">
                    <asp:ListItem Text="Student"></asp:ListItem>
                    <asp:ListItem Text="Staff"></asp:ListItem>
                </asp:RadioButtonList>
                <p>
                    <asp:Label ID="Label5" runat="server"> Select People </asp:Label>
                    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlpeople" runat="server" Height="26px" Width="242px"></asp:DropDownList>
                </p>
                <p><strong>Access Rights</strong></p>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem Text="Read"></asp:ListItem>
                    <asp:ListItem Text="Upload"></asp:ListItem>
                </asp:CheckBoxList>
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Make this User as Admin" />
                <br />
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>
