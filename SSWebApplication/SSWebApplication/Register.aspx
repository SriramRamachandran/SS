<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" style="background-color:#F7F7F7">
    <title></title>
     <script src="http://code.jquery.com/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //on Button click event
            $('#Wizard1_btnSubmit').click(function () {
                validate($('#Wizard1_password').val());
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
                            $('#Wizard1_TDStatus').html('Congratulations! Your password is strong.');
                        }
                        else if (msg.d == "fail") {
                            $('#Wizard1_TDStatus').html(error);
                        }
                    }
                },
                async: false,
                error: function (xhr, status, error) {
                    //alert(xhr.statusText);
                    $('#Wizard1_TDStatus').html('<center>Error occured!</center>');
                }
            });
        }
    </script>
    <style>
        .wizard {
            margin-left:500px;
            margin-top:200px;
        }
        #wizHeader li .prevStep
{
    background-color: #669966;
}
#wizHeader li .prevStep:after
{
    border-left-color:#669966 !important;
}
#wizHeader li .currentStep
{
    background-color: #C36615;
}
#wizHeader li .currentStep:after
{
    border-left-color: #C36615 !important;
}
#wizHeader li .nextStep
{
    background-color:#C2C2C2;
}
#wizHeader li .nextStep:after
{
    border-left-color:#C2C2C2 !important;
}
#wizHeader
{
    list-style: none;
    overflow: hidden;
    font: 18px Helvetica, Arial, Sans-Serif;
    margin: 0px;
    padding: 0px;
}
#wizHeader li
{
    float: left;
}
#wizHeader li a
{
    color: white;
    text-decoration: none;
    padding: 10px 0 10px 55px;
    background: brown; /* fallback color */
    background: hsla(34,85%,35%,1);
    position: relative;
    display: block;
    float: left;
}
#wizHeader li a:after
{
    content: " ";
    display: block;
    width: 0;
    height: 0;
    border-top: 50px solid transparent; /* Go big on the size, and let overflow hide */
    border-bottom: 50px solid transparent;
    border-left: 30px solid hsla(34,85%,35%,1);
    position: absolute;
    top: 50%;
    margin-top: -50px;
    left: 100%;
    z-index: 2;
}
#wizHeader li a:before
{
    content: " ";
    display: block;
    width: 0;
    height: 0;
    border-top: 50px solid transparent;
    border-bottom: 50px solid transparent;
    border-left: 30px solid white;
    position: absolute;
    top: 50%;
    margin-top: -50px;
    margin-left: 1px;
    left: 100%;
    z-index: 1;
}        
#wizHeader li:first-child a
{
    padding-left: 10px;
}
#wizHeader li:last-child 
{
    padding-right: 50px;
}
#wizHeader li a:hover
{
    background: #FE9400;
}
#wizHeader li a:hover:after
{
    border-left-color: #FE9400 !important;
}        
.content
{
    height:auto;           
    padding-top:15px;
    text-align:center;
    background-color:#F9F9F9;
    font-size:20px;
}
.error
        {
            color: Red;
        }
    </style>
</head>
<body style="background-color:#F7F7F7">
    <form id="form1" runat="server">
    <div>
    
        <asp:Wizard ID="Wizard1" runat="server" CssClass="wizard" Height="195px" Width="329px" DisplaySideBar="false">
            <WizardSteps>
               <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                <div class="content"><strong>UserName and Password</strong></div>
                   <div>
                       <p> 
                                    <asp:Label ID="Label1" runat="server" > Username </asp:Label>
                                    <asp:Textbox id="username" runat="server" TextMode="SingleLine" ToolTip="myusername or mymail@mail.com"></asp:Textbox>
                                </p>
                                <p> 
                                    <asp:Label ID="Label2" runat="server" >Password </asp:Label>
                                    <asp:TextBox id="password" TextMode="Password" runat="server" Tooltip="eg. X8df!90EO" ></asp:TextBox>
                                </p>
                       <p>
                           <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />
                       </p>
                       <p id="TDStatus" runat="server" class="error">
                           <asp:Label ID="lblmsg" runat="server"></asp:Label>
                       </p>
                   </div>
               </asp:WizardStep>
               <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                   <div class="content">QR code</div>
                   <div>
                        <asp:PlaceHolder ID="plBarCode" runat="server" />
                   </div>
               </asp:WizardStep>
               <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                  <div class="content">FingerPrint</div>
               </asp:WizardStep>
            </WizardSteps>
            <HeaderTemplate>
               <ul id="wizHeader">
                   <asp:Repeater ID="SideBarList" runat="server">
                       <ItemTemplate>
                           <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                               <%# Eval("Name")%></a> </li>
                       </ItemTemplate>
                   </asp:Repeater>
               </ul>
           </HeaderTemplate>
        </asp:Wizard>
    
    </div>
    </form>
</body>
</html>
