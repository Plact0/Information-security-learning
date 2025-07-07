<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPageMain.aspx.cs" Inherits="MyFinalWork.UserPageMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="user1.css">
    <link rel="stylesheet" href="userGuide.css">
    <script src="J1.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
<!-- 导航栏 -->
    <div class="guide">
        <p class="name" data-nav-item="title">失物招领平台</p>
        <ul class="guideul" data-nav-item="navList">
            <li class="guideli" data-nav-item="navLink"><a href="userPageMain.aspx" data-nav-item="navLinkInner" class="homepage-link">首页</a></li>
            <li class="guideli" data-nav-item="navLink"><a href="userPage2.aspx" data-nav-item="navLinkInner">失物广场</a></li>
            <li class="guideli" data-nav-item="navLink"><a href="userPage3.aspx" data-nav-item="navLinkInner">招领广场</a></li>
            <li class="guideli" data-nav-item="navLink" runat="server" id="liPersonalCenter"><a href="userPage4.aspx" data-nav-item="navLinkInner">个人中心</a></li>
        </ul>
        <asp:Button ID="Button1" runat="server" Text="登录" CssClass="loginBtn" OnClick="Button1_Click" BorderColor="White" />
        <asp:Button ID="Button2" runat="server" Text="注册" CssClass="registBtn" OnClick="Button2_Click" BorderColor="White" />
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="LoginName"></asp:Label>
        <asp:Button ID="Button3" runat="server" Text="退出登录" OnClick="Button3_Click" CssClass="outlogin" BorderColor="White" />
    </div>
<!-- 轮播图 -->
    <div class="box">
        <div class="box-img">
            <img src="userPage1.jpg" alt="图片">
            
        </div>
        <div class="box-img">
            <img src="userPage2 .jpg" alt="">
           
        </div>
        <div class="box-img">
            <img src="userPage3.jpg" alt="">
            
        </div>
        <div class="box-left">&lt;</div>
        <div class="box-right">&gt;</div>
        <div class="box-dot">
            <ul>
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </div>
    </div>

<!-- 发布失物     -->
        
    <div class="lostbox">
        <p>发布失物</p>
        <a href="UserPage2.aspx">跳转失物页面</a>
        <div class="lostbox1">
            <div class="lostimg">
                <img src="lost1.jpg" alt="图片">
            </div>
            <h3>黑色边框眼镜</h3>
            <p>失主：何小妮<br />
                时间：2024.1.1<br />
            </p>
            <asp:Button ID="Button4" runat="server" Text="查看更多" CssClass="Linkbtn" BorderColor="White" OnClick="Button4_Click" />

        </div>
        <div class="lostbox2">
            <div class="lostimg">
                <img src="lost1.jpg" alt="图片">
            </div>
            <h3>黑色边框眼镜</h3>
            <p>失主：何小妮<br />
                时间：2024.1.1</p>
            <asp:Button ID="Button5" runat="server" Text="查看更多" CssClass="Linkbtn" BorderColor="White" OnClick="Button5_Click" />

        </div>
    </div>
<!-- 发布招领 -->
        
    <div class="findbox">
        <p>发布招领</p>
        <a href="UserPage3.aspx">跳转招领页面</a>
        <div class="findbox1">
            <div class="findimg">
                <img src="lost1.jpg" alt="图片">
            </div>
            <h3>黑色边框眼镜</h3>
            <p>失主：何小妮<br />
                时间：2024.1.1</p>
            <asp:Button ID="Button6" runat="server" Text="查看更多" CssClass="Linkbtn" BorderColor="White" OnClick="Button6_Click" />
        </div>
        <div class="findbox2">
            <div class="findimg">
                <img src="lost1.jpg" alt="图片">
            </div>
            <h3>黑色边框眼镜</h3>
            <p>失主：何小妮<br />
                时间：2024.1.1</p>
            <asp:Button ID="Button7" runat="server" Text="查看更多" CssClass="Linkbtn" BorderColor="White" OnClick="Button7_Click" />
        </div>
    </div>
    </form>
</body>
</html>
