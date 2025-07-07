using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFinalWork
{
    public partial class AdPage5 : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (!IsPostBack) //网页第一次加载时
            {
                // 初始加载时显示全部数据
                gridviewbind();
             
            }
            if (!IsPostBack)
            {
                string username = Session["Username"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    // 根据用户名定制用户的专属界面
                    //Label1.Text = $"欢迎, {username}!";
                }
                else
                {
                    // 如果会话中没有用户名，重定向到登录页面
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void gridviewbind(string searchUsername = "")
        {
            using (SqlConnection SunCon = new SqlConnection(myConnectionString))
            {
                try
                {
                    SunCon.Open();
                    string strCommand;
                    if (!string.IsNullOrEmpty(searchUsername))
                    {
                        // 根据输入的用户名进行模糊查询
                        strCommand = $"SELECT * FROM 拾取事件管理 WHERE 发布用户 LIKE '%{searchUsername}%'";
                    }
                    else
                    {
                        // 未传入搜索用户名时，查询全部数据
                        strCommand = "SELECT * FROM 拾取事件管理";
                    }
                    SqlCommand StuIns = new SqlCommand(strCommand, SunCon);
                    SqlDataReader SunDa = StuIns.ExecuteReader();
                    // 创建一个临时的DataTable用于存储查询结果
                    DataTable dataTable = new DataTable();
                    dataTable.Load(SunDa);
                    SunDa.Close();

                    // 将DataTable设置为GridView的数据源并绑定数据
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    // 如果查询结果为空（即没有匹配的数据），则清空GridView的数据源并重新绑定，使其显示为空
                    if (dataTable.Rows.Count == 0)
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // 在这里添加更完善的错误处理逻辑，比如记录日志等
                    Console.WriteLine($"数据库操作出现错误: {ex.Message}");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string searchText = TextBox1.Text.Trim();
            gridviewbind(searchText);
        }
    }
}