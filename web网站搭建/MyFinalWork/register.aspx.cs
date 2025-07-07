using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;// 使 用 类 名 空 间 System.Configuration 下 的ConfigurationManager 类获取 web.configure 文件中的数据库连接字符串
using System.Data;
using System.Data.SqlClient;

namespace MyFinalWork
{
    public partial class register : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection SunCon = new SqlConnection(myConnectionString);
    try
    {
        SunCon.Open();
        string StuSQL;
        StuSQL = "INSERT INTO 用户(用户名,密码,邮箱) VALUES('" + TextBox1.Text + "', '" +
            TextBox3.Text + "','" + TextBox4.Text + "')";
        SqlCommand StuIns = new SqlCommand(StuSQL, SunCon);
        StuIns.ExecuteNonQuery();
        // 注册成功后弹出提示框
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('注册成功！');", true);
    }
    catch (Exception ex)
    {
        // 注册失败弹出错误提示框
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('注册失败！用户名重复！请更换用户名！');", true);
    }
    finally
    {
        SunCon.Close();
    }
        }
    }
}