<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRCode.aspx.cs" Inherits="SSWebApplication.QRCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QR CODE</title>
</head>
<body style="background-image: url(image1.jpg); background-repeat: inherit">
    <form id="form1" runat="server">
         <h2 style="margin-left:500px; margin-top:100px;">Two Way Authenticator</h2>
        <div style="margin-top: 50px;float:left;width:50%">
            <div style="float: left; margin-left: 50px; width: 50%">
                <h4 style="width: 105px; margin-top: 0px; float: left">Account Name</h4>
                <span style="float: left">
                    <asp:TextBox ID="username" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com" Height="18px" Width="207px"></asp:TextBox></span>

            </div>
            <div style="float: left; margin-top: 25px; margin-left: 50px; width: 459px;">
                <h4 style="width: 230px; margin-top: 0px; float: left">Type the QR Code from Mobile</h4>
                <span style="float: left">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com" Height="18px" Width="207px"></asp:TextBox></span>
            </div>


            <div style="float: left;width:30%; margin-top: 25px; margin-left: 275px;">
                <asp:PlaceHolder ID="plBarCode" runat="server" />
                <br />
                <br />
                <span style="color: green">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label></span>
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <div id="securitydiv" runat="server" style="margin-top: 50px;float:left; width: 50%; height: 233px;">

            <h4 style="height: 23px;float:left; width: 135px"><asp:Label ID="Label5" runat="server"> Security Questions</asp:Label></h4>
            <span style="margin-left:10px;float:left;width:100%; height: 25px;">
                <asp:DropDownList ID="ddlsecurity" runat="server" Height="30px" Width="450px"></asp:DropDownList></span>
            <h4 style="height: 23px;float: left; width: 135px; margin-top: 10px;"><asp:Label ID="Label1" runat="server"> Answer</asp:Label></h4>
            <span style="float:left;margin-left:10px;width:100%">
               <asp:TextBox ID="TextBox2" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com" Height="18px" Width="207px"></asp:TextBox>
            <br />
            <br />
            </span>
            <span style="color: green">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            </span>
            <br />
            <span style="float:left;">    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></span>
        </div>
    </form>
</body>
</html>
