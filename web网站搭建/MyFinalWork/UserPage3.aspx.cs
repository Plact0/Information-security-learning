using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MyFinalWork
{
    public partial class UserPage3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["UserId"] != null)
            {
                // 找到个人中心导航项并设置为可见（登录后显示）
                HtmlGenericControl liPersonalCenter = (HtmlGenericControl)FindControl("liPersonalCenter");
                Button5.Visible = true;
                if (liPersonalCenter != null)
                {
                    liPersonalCenter.Visible = true;
                }
            }
            else
            {
                // 如果会话中没有用户名，重定向到登录页面
                Response.Redirect("login.aspx");
                // 找到个人中心导航项并设置为不可见（未登录时隐藏）
                HtmlGenericControl liPersonalCenter = (HtmlGenericControl)FindControl("liPersonalCenter");
                Button5.Visible = false;
                if (liPersonalCenter != null)
                {
                    liPersonalCenter.Visible = false;
                }
            }
            if (!IsPostBack)
            {
                // 数据库连接字符串，根据你的实际数据库配置进行修改
                string connectionString = "Data Source=localhost;Initial Catalog=WebWork;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT 拾物名称,拾主,发布用户,发现时间,发现地点,联系方式 FROM Found"; // 查询获取失物名称、失主、发布用户这三列数据
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) // 判断是否有数据行
                        {
                            reader.Read();
                            // 将失物名称赋值给Label2
                            Label2.Text = reader["拾物名称"].ToString();
                            // 将失主名称赋值给Label4
                            Label4.Text = reader["拾主"].ToString();
                            // 将发布用户名称赋值给Label6
                            Label6.Text = reader["发布用户"].ToString();
                            Label8.Text = reader["发现时间"].ToString();
                            Label10.Text = reader["发现地点"].ToString();
                            Label30.Text = reader["联系方式"].ToString();
                        }
                        else
                        {
                            Label2.Text = "null";
                            Label4.Text = "null";
                            Label6.Text = "null";
                            Label8.Text = "null";
                            Label10.Text = "null";
                            Label30.Text = "null";

                        }
                        if (reader.HasRows) // 判断是否有数据行
                        {
                            reader.Read();
                            Label11.Text = reader["拾物名称"].ToString();
                            Label13.Text = reader["拾主"].ToString();
                            Label15.Text = reader["发布用户"].ToString();
                            Label17.Text = reader["发现时间"].ToString();
                            Label19.Text = reader["发现地点"].ToString();
                            Label32.Text = reader["联系方式"].ToString();
                        }
                        else
                        {
                            Label11.Text = "null";
                            Label13.Text = "null";
                            Label15.Text = "null";
                            Label17.Text = "null";
                            Label19.Text = "null";
                            Label32.Text = "null";

                        }
                        if (reader.HasRows) // 判断是否有数据行
                        {
                            reader.Read();
                            Label20.Text = reader["拾物名称"].ToString();
                            Label22.Text = reader["拾主"].ToString();
                            Label24.Text = reader["发布用户"].ToString();
                            Label26.Text = reader["发现时间"].ToString();
                            Label28.Text = reader["发现地点"].ToString();
                            Label34.Text = reader["联系方式"].ToString();
                        }
                        else
                        {
                            Label11.Text = "null";
                            Label13.Text = "null";
                            Label15.Text = "null";
                            Label26.Text = "null";
                            Label28.Text = "null";
                            Label34.Text = "null";

                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // 在这里可以添加更完善的错误处理逻辑，比如记录日志等
                        Response.Write("数据库读取出现错误: " + ex.Message);
                    }
                }
            }
        }
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        private void gridviewbind(string searchname = "")
        {
            string strCommand;
            strCommand = $"select * from Found where 拾物名称 like '%{searchname}%'";
            //if (!string.IsNullOrEmpty(searchname))
            //{
            //    // 根据输入的用户名进行模糊查询，你可以根据实际需求调整查询方式，比如精确查询等
            //    strCommand = $"select * from Found where 拾物名称 like '%{searchname}%'";
            //}
            //else
            //{
            //    strCommand = "select * from Found";
            //}
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Found"); // 修改此处表名，与查询语句对应，确保正确填充数据集
            GridView1.DataSource = ds.Tables["Found"].DefaultView;
            GridView1.DataKeyNames = new string[] { "拾取事件编号" }; // 假设丢失事件编号为主键，用于定位记录
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("PubFind.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string searchText = TextBox1.Text.Trim();
            gridviewbind(searchText);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // 清空TextBox1中的文本内容
            TextBox1.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Button11.Visible = true;
            Button7.Visible = false;
            // 构建查询Found表所有数据的语句
            string allDataCommand = "select * from Found";
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(allDataCommand, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Found");
                    GridView1.DataSource = ds.Tables["Found"].DefaultView;
                    GridView1.DataKeyNames = new string[] { "拾取事件编号" };
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    // 更完善的错误处理，比如记录日志等，这里简单输出错误信息
                    Console.WriteLine($"数据库操作出现错误: {ex.Message}");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label29.Visible = true;
            Label30.Visible = true;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Button1.Visible = false;
            Button8.Visible = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Label31.Visible = false;
            Label32.Visible = false;
            Label11.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label15.Visible = true;
            Label16.Visible = true;
            Label17.Visible = true;
            Label18.Visible = true;
            Label19.Visible = true;
            Button2.Visible = true;
            Button9.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Label33.Visible = false;
            Label34.Visible = false;
            Label20.Visible = true;
            Label21.Visible = true;
            Label22.Visible = true;
            Label23.Visible = true;
            Label24.Visible = true;
            Label25.Visible = true;
            Label26.Visible = true;
            Label27.Visible = true;
            Label28.Visible = true;
            Button6.Visible = true;
            Button10.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Label29.Visible = false;
            Label30.Visible = false;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Button1.Visible = true;
            Button8.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label31.Visible = true;
            Label32.Visible = true;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label15.Visible = false;
            Label16.Visible = false;
            Label17.Visible = false;
            Label18.Visible = false;
            Label19.Visible = false;
            Button2.Visible = false;
            Button9.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label33.Visible = true;
            Label34.Visible = true;
            Label20.Visible = false;
            Label21.Visible = false;
            Label22.Visible = false;
            Label23.Visible = false;
            Label24.Visible = false;
            Label25.Visible = false;
            Label26.Visible = false;
            Label27.Visible = false;
            Label28.Visible = false;
            Button6.Visible = false;
            Button10.Visible = true;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Button7.Visible = true;
            Button11.Visible = false;
        }
    }
}