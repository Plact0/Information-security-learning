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
    public partial class UserPage4 : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

        private void BindGrid1(string searchUsername)
        {
            string strCommand = $"select * from Lost where 发布用户 = '{searchUsername}'";
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();
            
                da.Fill(ds, "Lost");
                GridView1.DataSource = ds.Tables["Lost"].DefaultView;
                GridView1.DataKeyNames = new string[] { "丢失事件编号" };
                GridView1.DataBind();
            
        }

        private void BindGrid2(string searchUsername)
        {
            string strCommand = $"select * from Found where 发布用户 = '{searchUsername}'";
            SqlDataAdapter da = new SqlDataAdapter(strCommand, myConnectionString);
            DataSet ds = new DataSet();

            da.Fill(ds, "Found");
            GridView2.DataSource = ds.Tables["Found"].DefaultView;
            GridView2.DataKeyNames = new string[] { "拾取事件编号" };
            GridView2.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                string username = Session["Username"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    Label2.Text = username;
                    GetUserInfoFromDatabase(username);
                    BindGrid1(username);
                    BindGrid2(username);

                    // 设置验证控件初始状态为隐藏且有效
                    SetValidatorsInitialState();

                    // 确保验证控件启用客户端脚本验证
                    SetValidatorsClientScriptEnabled(true);
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void SetValidatorsInitialState()
        {
            // 处理TextBox1相关验证控件
            var validator1 = this.form1.FindControl("RegularExpressionValidator1") as BaseValidator;
            if (validator1 != null)
            {
                validator1.Visible = false;
                validator1.IsValid = true;
            }
            var validator2 = this.form1.FindControl("RequiredFieldValidator1") as BaseValidator;
            if (validator2 != null)
            {
                validator2.Visible = false;
                validator2.IsValid = true;
            }

            // 处理TextBox2相关验证控件
            var validator3 = this.form1.FindControl("RequiredFieldValidator2") as BaseValidator;
            if (validator3 != null)
            {
                validator3.Visible = false;
                validator3.IsValid = true;
            }
        }

        private void SetValidatorsClientScriptEnabled(bool enabled)
        {
            // 针对TextBox1的RequiredFieldValidator1
            var validator1 = this.form1.FindControl("RequiredFieldValidator1") as BaseValidator;
            if (validator1 != null)
            {
                validator1.EnableClientScript = enabled;
            }
            // 针对TextBox1的RegularExpressionValidator1
            var validator2 = this.form1.FindControl("RegularExpressionValidator1") as BaseValidator;
            if (validator2 != null)
            {
                validator2.EnableClientScript = enabled;
            }
            // 针对TextBox2的RequiredFieldValidator2
            var validator3 = this.form1.FindControl("RequiredFieldValidator2") as BaseValidator;
            if (validator3 != null)
            {
                validator3.EnableClientScript = enabled;
            }
        }
        private void GetUserInfoFromDatabase(string username)
        {
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 邮箱,密码 FROM 用户 WHERE 用户名 = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // 将获取到的邮箱和密码赋值给对应的Label显示
                        Label3.Text = reader["邮箱"].ToString();
                        Label4.Text = reader["密码"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库查询出错: " + ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            Button6.Visible = false;
            Button1.Visible = false;
            Button3.Visible = true;
            Button5.Visible = false;

            Label3.Visible = true;
            string username = Session["Username"] as string;
            if (!string.IsNullOrEmpty(username))
            {
                TextBox textBox1 = this.form1.FindControl("TextBox1") as TextBox;
                if (textBox1 != null)
                {
                    string newEmail = textBox1.Text.Trim();
                    // 先验证邮箱格式
                    if (string.IsNullOrEmpty(newEmail) || !IsValidEmail(newEmail))
                    {
                        // 直接给出提示，比如通过ScriptManager弹出提示框告知用户格式错误
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", "alert('请输入正确的邮箱格式');", true);
                        return;
                    }
                    using (SqlConnection connection = new SqlConnection(myConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("UpdateUserEmail", connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@NewEmail", newEmail);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                string query = "SELECT 邮箱 FROM 用户 WHERE 用户名 = @Username";
                                SqlCommand queryCommand = new SqlCommand(query, connection);
                                queryCommand.Parameters.AddWithValue("@Username", username);
                                SqlDataReader reader = queryCommand.ExecuteReader();
                                if (reader.Read())
                                {
                                    Label3.Text = reader["邮箱"].ToString();
                                }
                                reader.Close();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "successAlert1", "alert('修改成功');", true);
                                TextBox1.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("修改邮箱时数据库操作出错: " + ex.Message);
                        }
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button4.Visible = true;
            Button6.Visible = false;

            string username = Session["Username"] as string;
            if (!string.IsNullOrEmpty(username))
            {
                TextBox textBox2 = this.form1.FindControl("TextBox2") as TextBox;
                if (textBox2 != null)
                {
                    string newPassword = textBox2.Text.Trim();
                    if (string.IsNullOrEmpty(newPassword))
                    {
                        // 直接通过ScriptManager弹出提示框告知用户密码不能为空
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "passwordErrorAlert", "alert('密码不能为空');", true);
                        return;
                    }
                    using (SqlConnection connection = new SqlConnection(myConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("UpdateUserPassword", connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@NewPassword", newPassword);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                string query = "SELECT 密码 FROM 用户 WHERE 用户名 = @Username";
                                SqlCommand queryCommand = new SqlCommand(query, connection);
                                queryCommand.Parameters.AddWithValue("@Username", username);
                                SqlDataReader reader = queryCommand.ExecuteReader();
                                if (reader.Read())
                                {
                                    Label4.Text = reader["密码"].ToString();
                                }
                                reader.Close();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "successAlert2", "alert('修改成功');", true);
                                TextBox2.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("修改密码时数据库操作出错: " + ex.Message);
                        }
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string username = Label2.Text;
            BindGrid1(username);
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
                Console.WriteLine("数据库删除操作出现异常: " + ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            string username = Label2.Text;
            BindGrid1(username);
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 获取当前行的丢失事件编号（用于确定要删除的记录）
            string eventId = GridView2.DataKeys[e.RowIndex].Value.ToString().Trim();
            string deleteCommand = "delete from Found where 拾取事件编号 = @eventId";
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
                Console.WriteLine("数据库删除操作出现异常: " + ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            string username = Label2.Text;
            BindGrid2(username);
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            string username = Label2.Text;
            BindGrid2(username);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button3.Visible = false;
            Button1.Visible = true;
            TextBox1.Visible = true;
            Button5.Visible = true;
            Label3.Visible = false;
            // 隐藏验证错误提示信息（假设初始状态下不应显示错误提示）
            var validator1 = this.form1.FindControl("RegularExpressionValidator1") as BaseValidator;
            if (validator1 != null)
            {
                validator1.Visible = false;
                validator1.IsValid = true;
            }
            var validator2 = this.form1.FindControl("RequiredFieldValidator1") as BaseValidator;
            if (validator2 != null)
            {
                validator2.Visible = false;
                validator2.IsValid = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button4.Visible = false;
            Button6.Visible = true;
            Button2.Visible = true;
            TextBox2.Visible = true;
            // 隐藏验证错误提示信息（假设初始状态下不应显示错误提示）
            var validator = this.form1.FindControl("RequiredFieldValidator2") as BaseValidator;
            if (validator != null)
            {
                validator.Visible = false;
                validator.IsValid = true;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Button3.Visible = true;
            Button1.Visible = false;
            TextBox1.Visible = false;
            Button5.Visible = false;
            Label3.Visible = true;
            // 清除TextBox1的内容
            TextBox textBox1 = this.form1.FindControl("TextBox1") as TextBox;
            if (textBox1 != null)
            {
                textBox1.Text = "";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Button4.Visible = true;
            Button2.Visible = false;
            TextBox2.Visible = false;
            Button6.Visible = false;
            // 清除TextBox2的内容
            TextBox textBox2 = this.form1.FindControl("TextBox2") as TextBox;
            if (textBox2 != null)
            {
                textBox2.Text = "";
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}