﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSWebApplication.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>System Security Web App</title>
    <link rel="stylesheet" type="text/css" href="Styles/Loginstyle.css" />
    <link rel="stylesheet" type="text/css" href="Styles/demo.css" />
    
</head>
<body>
<form id="Form1"  action="" runat="server" > 
   <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="margin-top:100px;">
         
         <div id="container_demo" >
                   
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>   
                    <div id="wrapper">
                        <div id="login" class="animate form">
                            
                                <h1>LOG IN</h1> 
                                <p> 
                                    <asp:Label ID="Label1" runat="server" > Your email or username </asp:Label>
                                    <asp:Textbox id="username" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com"></asp:Textbox>
                                </p>
                                <p> 
                                    <asp:Label ID="Label2" runat="server"  > Your password </asp:Label>
                                    <asp:TextBox id="password" TextMode="Password" runat="server" Tooltip="eg. X8df!90EO" ></asp:TextBox>
                                </p>
                               
                               <asp:Label ID="lblMsg" runat="server" style="margin-left: 20px;" Width="300px"></asp:Label>
                                
                                <p class="login button"> 
                                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click" /> 
								</p>
                               <p class="change_link">
									Not a member yet ?
									<a href="Register.aspx" class="to_register">Register</a>
								</p>
                           
                        </div>
              </div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
 </form>
</body>
</html>

