<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubLost.aspx.cs" Inherits="MyFinalWork.PubLost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <script type="text/javascript">
       function previewImage() {
           var file = document.getElementById('FileUpload1').files[0];
           if (file) {
               var formData = new FormData();
               formData.append('file', file);
               var xhr = new XMLHttpRequest();
               xhr.open('POST', 'PubLost.aspx/UploadAndDisplayImage', true);
               xhr.onreadystatechange = function () {
                   if (xhr.readyState === 4 && xhr.status === 200) {
                       var imagePath = xhr.responseText;
                       document.getElementById('Image1').src = imagePath;
                   }
               };
               xhr.send(formData);
           }
       }
   </script>
    <link rel="stylesheet" href="PubL.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <div class="box">
                    <div class="UpdatedBox">
                        <h2>失物发布页面</h2>
                        
                        <br /><br />
                        <asp:Label ID="Label2" runat="server" Text="物品名称" CssClass="la"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="必填" CssClass="tb"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="Label7" runat="server" Text="失主" CssClass="la"></asp:Label>
                        <asp:TextBox ID="TextBox6" runat="server" placeholder="必填" CssClass="tb"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="Label3" runat="server" Text="丢失地点" CssClass="la"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="tb"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="Label4" runat="server" Text="丢失时间" CssClass="la"></asp:Label>
                        <asp:Button ID="Button2" runat="server" Text="选择时间" OnClick="Button2_Click" CssClass="btn" BackColor="#B9CDE1" BorderColor="White" />
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" BorderColor="White" ForeColor="#6082B6"></asp:Calendar>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="tb"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="Label5" runat="server" Text="联系方式" CssClass="la"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="必填" CssClass="tb"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不正确" ControlToValidate="TextBox4" ValidateRequestMode="Inherit" ValidationExpression="^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$" CssClass="rr"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="电话格式不正确" ControlToValidate="TextBox4" ValidationExpression="^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$" CssClass="rr"></asp:RegularExpressionValidator>
                        <br /><br />
                        <div class="rbtn">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="邮箱" AutoPostBack="True" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="1" Text="电话" />
                        </div>
                        <br /><br />
                        <asp:Label ID="Label6" runat="server" Text="物品描述" CssClass="la"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" placeholder="最多200字" CssClass="tb"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" CssClass="btn" BorderColor="White" BackColor="#B9CDE1" />
                        <br /><br />
                        <asp:Button ID="Button3" runat="server" Text="返回" BorderColor="White" BackColor="#B9CDE1" OnClick="Button3_Click" />
                    </div>
            </div>

        </div>
    </form>
</body>
</html>
