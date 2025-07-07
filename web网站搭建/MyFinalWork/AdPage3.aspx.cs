using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyFinalWork
{
    public partial class AdPage3 : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {
                BindGrid();
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

        private void BindGrid(string searchUsername = "")
        {
            string strCommand;
            if (!string.IsNullOrEmpty(searchUsername))
            {
                // 根据输入的用户名进行模糊查询，你可以根据实际需求调整查询方式，比如精确查询等
                strCommand = $"select * from Found where 发布用户 like '%{searchUsername}%'";
            }
            else
            {
                strCommand = "select * from Found";
            }
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Found"); // 修改此处表名，与查询语句对应，确保正确填充数据集
            GridView1.DataSource = ds.Tables["Found"].DefaultView;
            GridView1.DataKeyNames = new string[] { "拾取事件编号" }; // 假设拾取事件编号为主键，用于定位记录
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = (int)e.NewEditIndex; // 当前行作为待编辑行
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; // －１表示没有行是可编辑的
            BindGrid();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 获取当前编辑行的主键值（假设主键是"拾取事件编号"）
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            // 获取各个字段编辑后的值
            string itemName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string owner = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string contact = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string publisher = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            string updateCommand = "UPDATE Found SET 拾物名称=@itemName, 拾主=@owner, 联系方式=@contact, 发布用户=@publisher WHERE 拾取事件编号=@id";
            SqlConnection myConn = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(updateCommand, myConn);

            // 添加参数及对应的值
            myCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            myCommand.Parameters.Add("@itemName", SqlDbType.VarChar).Value = itemName;
            myCommand.Parameters.Add("@owner", SqlDbType.VarChar).Value = owner;
            myCommand.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
            myCommand.Parameters.Add("@publisher", SqlDbType.VarChar).Value = publisher;

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                BindGrid();
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
            // 获取当前要删除行的主键值（假设主键是"拾取事件编号"）
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string deleteCommand = "DELETE FROM Found WHERE 拾取事件编号=@id";
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand command = new SqlCommand(deleteCommand, connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // 详细记录异常信息，此处简单输出到控制台示例
                    Console.WriteLine($"数据库删除操作出现异常: {ex.Message}，详细错误信息: {ex.ToString()}");
                    // 可以给用户显示合适的错误提示，如弹框提示
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('删除失败，请联系管理员');", true);
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