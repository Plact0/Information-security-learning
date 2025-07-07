<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage3.aspx.cs" Inherits="MyFinalWork.UserPage3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="userGuide.css">
    <link rel="stylesheet" href="LostandFindBox.css">
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
                    <li class="guideli" data-nav-item="navLink"><a href="userPage3.aspx" data-nav-item="navLinkInner" class="homepage-link">招领广场</a></li>
                    <li class="guideli" data-nav-item="navLink" runat="server" id="liPersonalCenter"><a href="userPage4.aspx" data-nav-item="navLinkInner">个人中心</a></li>
                </ul>
       
            </div>
        <!-- 写一个lable标签 -->
            <div>
                <asp:Label ID="Label1" runat="server" Text="这里是招领广场，如果您遗失了物品，请联系拾主哦！" CssClass="Label0"></asp:Label>
            </div>
        <!-- 搜索框 -->
            <div>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="输入物品名称"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" Text="提交" OnClick="Button3_Click" CssClass="SearchBtn1" BorderColor="White"/>
                <asp:Button ID="Button4" runat="server" Text="重置" OnClick="Button4_Click" CssClass="SearchBtn2" BorderColor="White"/>
            </div>
        <!-- 招领盒子 -->
            <div class="Lostbox">
                <div class="Lostbox1">
                    <div class="imgbox">
                         <img src="Found.jpg" alt="图片">
                    </div>
                     <asp:Label ID="Label2" runat="server" Text="Label" CssClass="labelName"></asp:Label>
                     <br />
                     <asp:Label ID="Label3" runat="server" Text="拾主：" CssClass="label0"></asp:Label>
                     <asp:Label ID="Label4" runat="server" Text="Label" CssClass="label00"></asp:Label>
                     <br />
                     <asp:Label ID="Label5" runat="server" Text="发布人：" CssClass="label1"></asp:Label>
                     <asp:Label ID="Label6" runat="server" Text="Label" CssClass="label01"></asp:Label>
                     <br />
                     <asp:Label ID="Label7" runat="server" Text="拾取时间：" CssClass="label2"></asp:Label>
                     <asp:Label ID="Label8" runat="server" Text="Label" CssClass="label02"></asp:Label>
                     <br />
                     <asp:Label ID="Label9" runat="server" Text="拾取地点：" CssClass="label3"></asp:Label>
                     <asp:Label ID="Label10" runat="server" Text="Label" CssClass="label03"></asp:Label>
                     <br />
                    <asp:Label ID="Label29" runat="server" Text="联系方式：" CssClass="label4" Visible="False"></asp:Label>
                    <asp:Label ID="Label30" runat="server" Text="Label" CssClass="label04" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="Button8" runat="server" Text="关闭" Visible="False" CssClass="CallBtn" BorderColor="White" OnClick="Button8_Click" />
                    <asp:Button ID="Button1" runat="server" Text="联系拾主" CssClass="CallBtn" BorderColor="White" OnClick="Button1_Click" />
                </div>
                <div class="Lostbox2">
                    <div class="imgbox">
                         <img src="Found.jpg" alt="图片">
                    </div>
                     <asp:Label ID="Label11" runat="server" Text="Label" CssClass="labelName"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label12" runat="server" Text="拾主：" CssClass="label0"></asp:Label>
                     <asp:Label ID="Label13" runat="server" Text="Label" CssClass="label00"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label14" runat="server" Text="发布人：" CssClass="label1"></asp:Label>
                     <asp:Label ID="Label15" runat="server" Text="Label" CssClass="label01"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label16" runat="server" Text="拾取时间：" CssClass="label2"></asp:Label>
                     <asp:Label ID="Label17" runat="server" Text="Label" CssClass="label02"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label18" runat="server" Text="拾取地点：" CssClass="label3"></asp:Label>
                     <asp:Label ID="Label19" runat="server" Text="Label" CssClass="label03"></asp:Label>
                     <br /><br />
                    <asp:Label ID="Label31" runat="server" Text="联系方式：" CssClass="label4" Visible="False"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Text="Label" CssClass="label04" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="联系拾主" CssClass="CallBtn" BorderColor="White"  OnClick="Button2_Click" />
                    <asp:Button ID="Button9" runat="server" Text="关闭" Visible="False" CssClass="CallBtn" BorderColor="White" OnClick="Button9_Click" />
                 </div>
                 <div class="Lostbox3">
                     <div class="imgbox">
                         <img src="Found.jpg" alt="图片">
                     </div>
                     <asp:Label ID="Label20" runat="server" Text="Label" CssClass="labelName"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label21" runat="server" Text="拾主：" CssClass="label0"></asp:Label>
                     <asp:Label ID="Label22" runat="server" Text="Label" CssClass="label00"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label23" runat="server" Text="发布人：" CssClass="label1"></asp:Label>
                     <asp:Label ID="Label24" runat="server" Text="Label" CssClass="label01"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label25" runat="server" Text="拾取时间：" CssClass="label2"></asp:Label>
                     <asp:Label ID="Label26" runat="server" Text="Label" CssClass="label02"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label27" runat="server" Text="拾取地点：" CssClass="label3"></asp:Label>
                     <asp:Label ID="Label28" runat="server" Text="Label" CssClass="label03"></asp:Label>
                     <br /><br />
                     <asp:Label ID="Label33" runat="server" Text="联系方式：" CssClass="label4" Visible="False"></asp:Label>
                     <asp:Label ID="Label34" runat="server" Text="Label" CssClass="label04" Visible="False"></asp:Label>
                    <br />
                     <asp:Button ID="Button6" runat="server" Text="联系拾主" CssClass="CallBtn" BorderColor="White"  OnClick="Button6_Click" />
                     <asp:Button ID="Button10" runat="server" Text="关闭" Visible="False" CssClass="CallBtn" BorderColor="White" OnClick="Button10_Click" />
                 </div>
            </div>
       <!-- 查看更多 -->
            <div>
                <asp:Button ID="Button7" runat="server" Text="查看更多" OnClick="Button7_Click" BorderColor="White" CssClass="ReadBtn" />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Button ID="Button11" runat="server" Text="取消" Visible="False" OnClick="Button11_Click" BorderColor="White" CssClass="ReadBtn" />
            </div>

        <!-- 发布失物 -->
            <div>
                <asp:Button ID="Button5" runat="server" Text="发布招领" OnClick="Button5_Click" BorderColor="White" />
            </div>
        </div>
    </form>
</body>
</html>
