<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MyFinalWork.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="c1.css">
</head>
<body>
    <form id="form1" runat="server">
       <div class ="w1">
            <div class="bgdiv">
                 <div class="pdiv">
                     <asp:Label ID="Label1" runat="server" Text="登录" CssClass="lable"></asp:Label>
                     <br /><br />
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" placeholder="用户名"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户 ID 不能为空" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                     <br />
                     <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="textbox" placeholder="密码"></asp:TextBox>

                     <br /><br />
                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl"></asp:DropDownList>
                     <br /><br />
                     <asp:Button ID="Button1" runat="server" Text="登录" CssClass="button" OnClick="Button1_Click" BorderColor="White" />
                     <br /><br />
                     <p> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                           &nbsp;&nbsp;还没有账号？<a href="register.aspx">注册</a></p>
                 </div>
             </div>
       </div>
    </form>
</body>
</html>
