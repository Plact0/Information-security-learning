<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminorMain.aspx.cs" Inherits="MyFinalWork.AdminorMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Ad1.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="whole">
           <div class="box">
               <div class="maindiv">
                     <h2>管理员页面</h2>
                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                     <br /><br />
                    <asp:Button ID="Button1" runat="server" Text="管理用户" OnClick="Button1_Click" CssClass="btn" BorderColor="White" />
                      <br /><br />
                    <asp:Button ID="Button2" runat="server" Text="管理丢失事件" OnClick="Button2_Click" CssClass="btn" BorderColor="White" />
                      <br /><br />
                    <asp:Button ID="Button3" runat="server" Text="管理拾取事件" OnClick="Button3_Click" CssClass="btn" BorderColor="White" />
                      <br /><br />
                    <asp:Button ID="Button4" runat="server" Text="丢失事件显示" OnClick="Button4_Click" CssClass="btn" BorderColor="White" />
                      <br /><br />
                    <asp:Button ID="Button5" runat="server" Text="拾取事件显示" OnClick="Button5_Click" CssClass="btn" BorderColor="White" />

                   <asp:Button ID="Button6" runat="server" Text="退出" CssClass="a1" BorderColor="White" OnClick="Button6_Click" />
                </div>
           </div>
        </div>
    </form>
</body>
</html>
