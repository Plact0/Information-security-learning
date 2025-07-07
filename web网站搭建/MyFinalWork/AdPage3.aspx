<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdPage3.aspx.cs" Inherits="MyFinalWork.AdPage3" %>

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
                <!--查询发布用户-->
                <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
            </div>
            <!--表-->
            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="拾取事件编号" HeaderText="拾取事件编号"></asp:BoundField>
                    <asp:BoundField DataField="拾物名称" HeaderText="拾物名称"></asp:BoundField>
                    <asp:BoundField DataField="拾主" HeaderText="拾主"></asp:BoundField>
                    <asp:BoundField DataField="联系方式" HeaderText="联系方式"></asp:BoundField>
                    <asp:BoundField DataField="发布用户" HeaderText="发布用户"></asp:BoundField>
                    <asp:CommandField ShowEditButton="True"></asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                </Columns>
            </asp:GridView>
            <a class="aaa"  href="AdminorMain.aspx">返回</a>
        </div>
    </form>
</body>
</html>
