using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;// 使 用 类 名 空 间 System.Configuration 下 的ConfigurationManager 类获取 web.configure 文件中的数据库连接字符串
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace MyFinalWork
{
    public partial class AdPage1 : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        private void BindGrid(string searchUsername = "")
        {
            string strCommand;
            if (!string.IsNullOrEmpty(searchUsername))
            {
                // 根据输入的用户名进行模糊查询，你可以根据实际需求调整查询方式，比如精确查询等
                strCommand = $"select * from 用户 where 用户名 like '%{searchUsername}%'";
            }
            else
            {
                strCommand = "select * from 用户";
            }
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            GridView1.DataSource = ds.Tables["user"].DefaultView;
            GridView1.DataKeyNames = new string[] { "用户名" };
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
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
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = (int)e.NewEditIndex; //当前行作为待编辑行
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; //－１表示没有行是可编辑的
            BindGrid();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView1.EditIndex = -1;
            //BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 获取当前行的用户名（假设学号是主键，用于定位要更新的记录）
            string username = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
            // 获取编辑后各字段的新值
            string password = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            string updateCommand = "update 用户 set 密码 = @password, 邮箱 = @email where 用户名 = @username";
            SqlConnection myConn = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(updateCommand, myConn);

            // 添加参数及对应的值
            myCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username; // 确保类型匹配
            myCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = password; // 确保类型匹配
            myCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email; // 确保类型匹配

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                GridView1.EditIndex = -1; // 取消编辑模式
                BindGrid(); // 重新绑定数据源
            }
            catch (SqlException ex)
            {
                // 可以根据实际需求更详细地记录异常信息或者给用户显示合适的错误提示
                Console.WriteLine("数据库更新操作出现异常: " + ex.Message);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('更新失败');", true);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 获取当前行的用户名（用于确定要删除的记录）
            string username = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
            string deleteCommand = "delete from 用户 where 用户名 = @username";
            SqlConnection myConn = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(deleteCommand, myConn);

            myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

            try
            {
                myConn.Open();
                int rowsAffected = myCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    // 如果受影响的行数为0，很可能是因为外键约束等原因导致删除失败
                    Console.WriteLine("删除操作未执行成功，可能存在外键约束关联，请检查相关表数据。");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('删除失败，可能存在关联数据，请检查后再试');", true);
                }
                else
                {
                    Console.WriteLine("删除成功");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // SQL Server中外键约束冲突的错误编号，不同数据库这个编号可能不同
                {
                    Console.WriteLine("因外键约束，无法删除该记录，请先处理关联数据。");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('因外键约束，无法删除该记录，请先处理关联数据');", true);
                }
                else
                {
                    // 处理其他数据库删除操作相关的SqlException异常，输出详细错误信息
                    StringBuilder sqlErrorMessage = new StringBuilder();
                    sqlErrorMessage.AppendLine("数据库删除操作出现异常: ");
                    sqlErrorMessage.AppendLine($"错误编号: {ex.Number}");
                    sqlErrorMessage.AppendLine($"错误消息: {ex.Message}");
                    sqlErrorMessage.AppendLine($"出现错误的行号: {ex.LineNumber}");
                    sqlErrorMessage.AppendLine($"源: {ex.Source}");
                    sqlErrorMessage.AppendLine($"过程: {ex.Procedure}");
                    if (ex.InnerException != null)
                    {
                        sqlErrorMessage.AppendLine($"内部异常消息: {ex.InnerException.Message}");
                    }
                    Console.WriteLine(sqlErrorMessage.ToString());
                }
            }
            catch (IOException ex)
            {
                // 捕获可能出现的网络相关输入输出异常，比如数据库连接因网络问题中断等情况
                StringBuilder ioErrorMessage = new StringBuilder();
                ioErrorMessage.AppendLine("网络相关输入输出操作出现异常: ");
                ioErrorMessage.AppendLine($"错误消息: {ex.Message}");
                ioErrorMessage.AppendLine($"出现错误的源: {ex.Source}");
                Console.WriteLine(ioErrorMessage.ToString());
            }
            catch (FormatException ex)
            {
                // 捕获可能在获取用户名等操作中出现的数据格式转换异常，例如用户名值不符合预期格式
                StringBuilder formatErrorMessage = new StringBuilder();
                formatErrorMessage.AppendLine("数据格式转换出现异常: ");
                formatErrorMessage.AppendLine($"错误消息: {ex.Message}");
                formatErrorMessage.AppendLine($"出现错误的对象: {ex.Source}");
                Console.WriteLine(formatErrorMessage.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                // 捕获操作已释放对象导致的异常，比如连接对象被意外提前释放等情况
                StringBuilder disposedErrorMessage = new StringBuilder();
                disposedErrorMessage.AppendLine("操作已释放的对象出现异常: ");
                disposedErrorMessage.AppendLine($"错误消息: {ex.Message}");
                disposedErrorMessage.AppendLine($"出现错误的源: {ex.Source}");
                Console.WriteLine(disposedErrorMessage.ToString());
            }
            catch (Exception ex)
            {
                // 作为兜底，捕获其他未明确处理的通用异常，避免程序因未捕获的异常而崩溃
                StringBuilder generalErrorMessage = new StringBuilder();
                generalErrorMessage.AppendLine("出现未知异常: ");
                generalErrorMessage.AppendLine($"错误消息: {ex.Message}");
                generalErrorMessage.AppendLine($"出现错误的源: {ex.Source}");
                Console.WriteLine(generalErrorMessage.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string searchText = TextBox1.Text.Trim();
            BindGrid(searchText);
        }
    }
}