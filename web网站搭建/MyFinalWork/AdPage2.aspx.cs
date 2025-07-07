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
    public partial class AdPage21 : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

        private void BindGrid(string searchUsername = "")
        {
            string strCommand;
            if (!string.IsNullOrEmpty(searchUsername))
            {
                // 根据输入的用户名进行模糊查询，你可以根据实际需求调整查询方式，比如精确查询等
                strCommand = $"select * from Lost where 发布用户 like '%{searchUsername}%'";
            }
            else
            {
                strCommand = "select * from Lost";
            }
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Lost"); // 修改此处表名，与查询语句对应，确保正确填充数据集
            GridView1.DataSource = ds.Tables["Lost"].DefaultView;
            GridView1.DataKeyNames = new string[] { "丢失事件编号" }; // 假设丢失事件编号为主键，用于定位记录
            GridView1.DataBind();
        }

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = (int)e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 获取当前行的丢失事件编号（假设为主键，用于定位要更新的记录）
            string eventId = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
            // 获取编辑后各字段的新值
            string lostItemName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string owner = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string contactMethod = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string publisher = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            string updateCommand = "update Lost set 失物名称 = @lostItemName, 失主 = @owner, 联系方法 = @contactMethod, 发布用户 = @publisher where 丢失事件编号 = @eventId";
            SqlConnection myConn = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(updateCommand, myConn);

            // 添加参数及对应的值
            myCommand.Parameters.Add("@eventId", SqlDbType.VarChar).Value = eventId;
            myCommand.Parameters.Add("@lostItemName", SqlDbType.VarChar).Value = lostItemName;
            myCommand.Parameters.Add("@owner", SqlDbType.VarChar).Value = owner;
            myCommand.Parameters.Add("@contactMethod", SqlDbType.VarChar).Value = contactMethod;
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
            // 获取当前行的丢失事件编号（用于确定要删除的记录）
            string eventId = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
            string deleteCommand = "delete from Lost where 丢失事件编号 = @eventId";
            SqlConnection myConn = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(deleteCommand, myConn);

            myCommand.Parameters.Add("@eventId", SqlDbType.VarChar).Value = eventId;

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // 可以根据实际需求更详细地记录异常信息或者给用户显示合适的错误提示
                Console.WriteLine("数据库删除操作出现异常: " + ex.Message);
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