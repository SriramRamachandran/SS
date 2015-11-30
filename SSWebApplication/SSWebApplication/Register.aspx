<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SSWebApplication.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" type="text/css" href="Styles/Loginstyle.css" />
     <link rel="stylesheet" type="text/css" href="Styles/demo.css" />
    <title>Register</title>
    <script src="http://code.jquery.com/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {
            //on Button click event
            $('#Button1').click(function () {
                validate($('#password').val());
            });
        });
        var error = "Password must use a combination of these:<br />I.Atleast 1 upper case letters (A – Z)<br />II.Lower case letters (a – z)<br />III.Atleast 1 number (0 – 9)<br />IV.Atleast 1 non-alphanumeric symbol (e.g. @ ‘$%£!’)";
        function validate(val) {
            $('#TDStatus').html('');
            $.ajax({
                type: "POST",
                url: "Register.aspx/ValidatePassword",
                data: "{'password':'" + val + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    
                    if (msg.d.length > 0) {
                        if (msg.d == "success") {
                            $('#TDStatus').html('Congratulations! Your password is strong.');
                        }
                        else if (msg.d == "fail") {
                            $('#TDStatus').html(error);
                        }
                    }
                },
                async: false,
                error: function (xhr, status, error) {
                    //alert(xhr.statusText);
                    $('#TDStatus').html('<center>Error occured!</center>');
                }
            });
        }

        function validateEmail() {
            var regex = /^[a-zA-Z0-9._-]+@([a-zA-Z0-9.-]+\.)+[a-zA-Z0-9.-]{2,4}$/;
            alert(regex.test(document.getElementById('<%= username.ClientID %>').value));
        }
        </script>
</head>
<body style="background-image:url(image1.jpg);background-repeat:inherit">
    <form id="form1" runat="server">
    <div id="container_demo" style="margin-left:400px">
         <div id="wrapper">
                            <div style="width:auto;">
                                <div id="login" class="animate form">

                                    <h1>REGISTER</h1>
                                    <p>
                                        <asp:Label ID="Label3" runat="server"> Role</asp:Label>
                                        <asp:RadioButtonList ID="roles" runat="server" AutoPostBack="true" RepeatDirection="Vertical" OnSelectedIndexChanged="roles_SelectedIndexChanged">
                                            <asp:ListItem Text="Student"></asp:ListItem>
                                            <asp:ListItem Text="Staff"></asp:ListItem>
                                            <asp:ListItem Text="Admin"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </p>
                                   <p>
                                        <asp:Label ID="Label4" runat="server"> ID</asp:Label>
                                        <span style="margin-left:150px"><asp:TextBox ID="ID" Enabled="false" runat="server" TextMode="SingleLine"></asp:TextBox></span>
                                    </p>
                                    
                                     <p>
                                        <asp:Label ID="Label1" runat="server"> Your email or username </asp:Label>
                                        <asp:TextBox ID="username" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label2" runat="server"> Your password </asp:Label>
                                        <span style="margin-left:60px"><asp:TextBox ID="password" TextMode="Password" runat="server" ToolTip="eg. X8df!90EO"></asp:TextBox></span>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label5" runat="server"> Security Questions</asp:Label>
                                        <asp:DropDownList ID="ddlsecurity" runat="server"></asp:DropDownList>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label6" runat="server"> Security Answer</asp:Label>
                                         <span style="margin-left:50px"><asp:TextBox ID="securityanswer" runat="server" TextMode="SingleLine"></asp:TextBox></span>
                                    </p>
                                    <p id="TDStatus" runat="server" style="color:red">
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </p>
                                    <p class="login button">
                                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" OnClientClick="validateEmail();" />
                                    </p>
                                </div>
                            </div>
                        </div>
    </div>
    </form>
</body>
</html>
