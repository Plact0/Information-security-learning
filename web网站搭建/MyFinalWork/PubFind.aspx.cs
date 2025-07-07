using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;

namespace MyFinalWork
{
    public partial class PubFind : System.Web.UI.Page
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                // 设置RadioButton1为默认选中状态
                RadioButton1.Checked = true;
                // 根据单选按钮初始选择状态设置验证控件初始状态
                RegularExpressionValidator1.Enabled = true;
                RegularExpressionValidator2.Enabled = false;
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            // 根据单选按钮初始选择状态设置验证控件初始状态
            if (RadioButton1.Checked)
            {
                RegularExpressionValidator1.Enabled = true;
                RegularExpressionValidator2.Enabled = false;
            }
            else if (RadioButton2.Checked)
            {
                RegularExpressionValidator1.Enabled = false;
                RegularExpressionValidator2.Enabled = true;
            }
            else
            {
                // 若都没选，都禁用（可根据实际需求调整）
                RegularExpressionValidator1.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 检查页面验证是否通过（即根据单选按钮选择，对应的验证控件验证成功）
            if (Page.IsValid)
            {
                bool hasEmptyRequiredField = false;
                // 用于记录是否存在必填项为空的情况
                List<string> emptyFieldNames = new List<string>();
                // 存储为空的必填项字段名列表

                if (string.IsNullOrEmpty(TextBox1.Text))
                {
                    emptyFieldNames.Add("物品名称");
                    hasEmptyRequiredField = true;
                }
                if (string.IsNullOrEmpty(TextBox6.Text))
                {
                    emptyFieldNames.Add("拾主");
                    hasEmptyRequiredField = true;
                }
                if (string.IsNullOrEmpty(TextBox4.Text))
                {
                    emptyFieldNames.Add("联系方式");
                    hasEmptyRequiredField = true;
                }

                if (hasEmptyRequiredField)
                {
                    string errorMessage = "以下必填项不能为空：";
                    foreach (string fieldName in emptyFieldNames)
                    {
                        errorMessage += $" {fieldName},";
                    }
                    errorMessage = errorMessage.TrimEnd(',');
                    ClientScript.RegisterStartupScript(this.GetType(), "error", $"alert('{errorMessage}');", true);
                    return;
                }

                if (!RadioButton1.Checked && !RadioButton2.Checked)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error", "请选择联系方式的类型（邮箱或电话）！", true);
                    return;
                }
                //byte[] pictureData = null;
                //// 如果用户选择了上传文件，获取文件数据，若未选择则pictureData保持为null，允许图片为空上传
                //if (FileUpload1.HasFile)
                //{
                //    using (Stream inputStream = FileUpload1.PostedFile.InputStream)
                //    {
                //        MemoryStream memoryStream = new MemoryStream();
                //        inputStream.CopyTo(memoryStream);
                //        pictureData = memoryStream.ToArray();
                //    }
                //}

                string currentUserId = "";
                // 从Session中获取当前登录用户名（这里假设之前登录成功后在Session中存储了Username，你可根据实际情况调整）
                if (Session["Username"] != null)
                {
                    currentUserId = Session["Username"].ToString();
                }

                try
                {
                    SqlConnection SunCon = new SqlConnection(myConnectionString);
                    SunCon.Open();
                    string StuSQL;
                    // 修改后的插入语句，去掉了PictureData字段相关内容
                    StuSQL = "INSERT INTO Found(拾物名称,拾主,发现地点,发现时间,联系方式,描述, 发布用户) VALUES('" + TextBox1.Text + "', '" + TextBox6.Text + "','" + TextBox2.Text + "', '"
                            + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "', '" + currentUserId + "')";
                    SqlCommand StuIns = new SqlCommand(StuSQL, SunCon);
                    // 直接执行数据库插入操作，因为现在SQL语句没有参数占位符了，无需额外参数绑定操作
                    StuIns.ExecuteNonQuery();
                    SunCon.Close();
                    // 数据插入成功弹出提示
                    ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('数据已成功上传！');", true);
                }
                catch (SqlException ex)
                {
                    // 数据插入失败弹出提示，这里可以根据具体的异常信息做更详细的提示，当前只是简单提示失败
                    ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('数据上传失败，请检查网络或联系管理员！');", true);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            //Image1.Visible = false;
            //FileUpload1.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            Button1.Visible = false;
            Button2.Enabled = false;
            Button2.Visible = false;
            //Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            //Image1.Visible = true;
            //FileUpload1.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            Button1.Visible = true;
            Button2.Enabled = true;
            Button2.Visible = true;
            //Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;

        }

        [WebMethod]
        public static string UploadAndDisplayImage(HttpPostedFile file)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/TempImages/");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(filePath, fileName);
            file.SaveAs(fullPath);
            return "~/TempImages/" + fileName;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userpage3.aspx");
        }
    }
}