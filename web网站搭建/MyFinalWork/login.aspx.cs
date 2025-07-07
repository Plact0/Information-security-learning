using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace MyFinalWork
{
    public partial class login : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                DropDownList1.Items.Add("用户");
                DropDownList1.Items.Add("管理员");
            }
        }

        // 提取通用的登录验证方法
        private bool ValidateLogin(string tableName, string targetPage, string username, string password)
        {
            using (SqlConnection myConn = new SqlConnection(myConnectionString))
            {
                // 根据表名动态确定用户名对应的字段名
                string userFieldName = (tableName.ToLower() == "用户") ? "用户名" : "管理员名称";
                string mySql = $"select * from {tableName} where {userFieldName}=@Username and 密码=@Password";
                SqlCommand myCommand = new SqlCommand(mySql, myConn);
                // 添加参数化查询的参数设置
                myCommand.Parameters.AddWithValue("@Username", username);
                myCommand.Parameters.AddWithValue("@Password", password);

                try
                {
                    myConn.Open();
                    SqlDataReader myDr = myCommand.ExecuteReader();
                    if (myDr.Read())
                    {
                        // 使用Session 存数据
                        Session["UserId"] = Server.HtmlEncode(username);
                        Session["Password"] = Server.HtmlEncode(password);
                        return true;
                    }
                    myDr.Close();
                }
                catch (Exception ex)
                {
                    // 处理异常并弹出提示
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('发生错误：{ex.Message}');", true);
                }
            }
            return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedOption = DropDownList1.SelectedItem.Text;
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            if (selectedOption == "用户")
            {
                if (ValidateLogin("用户", "UserMainPage.aspx", username, password))
                {
                    // 保存用户名到会话状态
                    Session["Username"] = username;
                    Response.Redirect("UserPageMain.aspx");
                }
                else
                {
                    // 用户登录失败弹出提示
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('用户登录失败！用户名或密码错误。" +
                        "忘记密码请联系管理员:1658346496@qq.com!!!');", true);
                }
            }
            else if (selectedOption == "管理员")
            {
                if (ValidateLogin("管理员", "AdminorMain.aspx", username, password))
                {
                    // 保存用户名到会话状态
                    Session["Username"] = username;
                    Response.Redirect("AdminorMain.aspx");
                }
                else
                {
                    // 管理员登录失败弹出提示
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('管理员登录失败！用户名或密码错误。');", true);
                }
            }
            else
            {
                // 处理无效选项
                return;
            }
        }
    }
}