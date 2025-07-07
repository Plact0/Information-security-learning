<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage4.aspx.cs" Inherits="MyFinalWork.UserPage4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="userGuide.css">
    <link rel="stylesheet" href="own.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- 导航栏 -->
            <div class="guide">
                <p class="name" data-nav-item="title">失物招领平台</p>
                <ul class="guideul" data-nav-item="navList">
                    <li class="guideli" data-nav-item="navLink"><a href="userPageMain.aspx" data-nav-item="navLinkInner">首页</a></li>
                    <li class="guideli" data-nav-item="navLink"><a href="userPage2.aspx" data-nav-item="navLinkInner">失物广场</a></li>
                    <li class="guideli" data-nav-item="navLink"><a href="userPage3.aspx" data-nav-item="navLinkInner">招领广场</a></li>
                    <li class="guideli" data-nav-item="navLink"><a href="userPage4.aspx" data-nav-item="navLinkInner" class="homepage-link">个人中心</a></li>
                </ul>
               
            </div>

            <!--题头--->
            <asp:Label ID="Label1" runat="server" Text="个人信息中心"></asp:Label>
            <!--个人信息--->
            <div class="box">
                <asp:Label ID="Label7" runat="server" Text="用户名：" CssClass="l"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" CssClass="ll"></asp:Label>
                <br /><br />
                <asp:Label ID="Label8" runat="server" Text="邮箱：" CssClass="l"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Label" CssClass="ll"></asp:Label>
                <asp:Button ID="Button3" runat="server" Text="修改" OnClick="Button3_Click" CssClass="btn" />
                <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" Visible="False" CssClass="btn" ValidationGroup="myGroup" />
                <asp:Button ID="Button5" runat="server" Text="取消" OnClick="Button5_Click" Visible="False" CssClass="btn" />
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                
                <br /><br />
                <asp:Label ID="Label9" runat="server" Text="密码：" CssClass="l"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" CssClass="ll"></asp:Label>
                <asp:Button ID="Button4" runat="server" Text="修改" OnClick="Button4_Click" CssClass="btn" />
                <asp:Button ID="Button2" runat="server" Text="完成" OnClick="Button2_Click" Visible="False" CssClass="btn" ValidationGroup="myGroup" />
                <asp:Button ID="Button6" runat="server" Text="取消" CssClass="btn" OnClick="Button6_Click" Visible="False" />
                <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                <br /><br />
            

            <!--查看自己发布的失物-->
            
                <asp:Label ID="Label5" runat="server" Text="以下是您发布的失物信息：" CssClass="l"></asp:Label>
                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="失物名称" HeaderText="失物名称"></asp:BoundField>
                        <asp:BoundField DataField="失主" HeaderText="失主"></asp:BoundField>
                        <asp:BoundField DataField="丢失时间" HeaderText="丢失时间"></asp:BoundField>
                        <asp:BoundField DataField="丢失地点" HeaderText="丢失地点"></asp:BoundField>
                        <asp:BoundField DataField="联系方法" HeaderText="联系方式"></asp:BoundField>
                        <asp:BoundField DataField="描述" HeaderText="描述"></asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                        </Columns>
                </asp:GridView>
                <br /><br />
            

             <!--查看自己发布的招领-->
             
                 <asp:Label ID="Label6" runat="server" Text="以下是您发布的招领信息：" CssClass="l"></asp:Label>
                 
                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" OnPageIndexChanging="GridView2_PageIndexChanging">
                     <Columns>
                         <asp:BoundField DataField="拾物名称" HeaderText="拾物名称"></asp:BoundField>
                         <asp:BoundField DataField="拾主" HeaderText="拾主"></asp:BoundField>
                         <asp:BoundField DataField="发现时间" HeaderText="发现时间"></asp:BoundField>
                         <asp:BoundField DataField="发现地点" HeaderText="发现地点"></asp:BoundField>
                         <asp:BoundField DataField="联系方式" HeaderText="联系方式"></asp:BoundField>
                         <asp:BoundField DataField="描述" HeaderText="描述"></asp:BoundField>
                         <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                     </Columns>
                 </asp:GridView>

            


        </div>
    </form>
</body>
</html>
