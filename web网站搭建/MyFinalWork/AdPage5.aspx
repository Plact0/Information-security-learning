<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdPage5.aspx.cs" Inherits="MyFinalWork.AdPage5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="AdL.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="whole">
            <div class="box">
             <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
             
            </div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <a class="aaa"  href="AdminorMain.aspx">返回</a>
        </div>
    </form>
</body>
</html>
