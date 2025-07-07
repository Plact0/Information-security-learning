<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="MyFinalWork.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="c1.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="bgdiv">
            <div class="pdiv">
                <asp:Label ID="Label1" runat="server" Text="注册" CssClass="lable"></asp:Label>
                <br /><br />
                <asp:TextBox ID="TextBox1" runat="server" placeholder="输入用户名" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" placeholder="输入密码" TextMode="Password" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" EnableViewState="True" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                <br /><br />
                <asp:TextBox ID="TextBox3" runat="server" placeholder="再次输入密码" TextMode="Password" CssClass="textbox"></asp:TextBox>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次输入的密码不同" ControlToCompare="TextBox2" ControlToValidate="TextBox3"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" placeholder="输入邮箱" CssClass="textbox"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBox4"></asp:RegularExpressionValidator>
                <br />
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" CssClass="button" BorderColor="White" />
                <br /><br />
                <p> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="login.aspx">返回登陆页面</a></p>
            </div>
        </div>
    </form>
</body>
</html>
