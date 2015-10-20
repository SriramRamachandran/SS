<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="SSWebApplication.Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       USERNAME: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/QRCode.aspx">Continue to QR</asp:HyperLink>
        <br />
        PASSWORD: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        
    </form>
</body>
</html>
