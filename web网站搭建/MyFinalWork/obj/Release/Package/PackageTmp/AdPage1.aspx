<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdPage1.aspx.cs" Inherits="MyFinalWork.AdPage1" %>

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
                <div class ="maindiv">
                    <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" BorderColor="#B6D0E2" />
                    
                </div>
            </div>
             <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField DataField="用户编号" HeaderText="用户编号"></asp:BoundField>
                 <asp:BoundField DataField="用户名" HeaderText="用户名"></asp:BoundField>
                 <asp:BoundField DataField="密码" HeaderText="密码"></asp:BoundField>
                 <asp:BoundField DataField="邮箱" HeaderText="邮箱"></asp:BoundField>
                 <asp:CommandField ShowEditButton="True"></asp:CommandField>
                 <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
             </Columns>
         </asp:GridView>
            <a class="aaa"  href="AdminorMain.aspx">返回</a>
        </div>
    </form>
</body>
</html>
