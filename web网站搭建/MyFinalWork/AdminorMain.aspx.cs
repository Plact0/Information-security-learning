using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFinalWork
{
    public partial class AdminorMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            string username = Session["Username"] as string;
            if (!string.IsNullOrEmpty(username))
            {
                // 根据用户名定制用户的专属界面
                Label1.Text = $"欢迎, 管理员：{username}!";
            }
            else
            {
                // 如果会话中没有用户名，重定向到登录页面
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPage1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPage2.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPage3.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPage4.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPage5.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            // 这里可以添加退出登录的具体逻辑，比如清除Session中的登录相关信息等
            Session["UserId"] = null;
            Session["Username"] = null;
            Response.Redirect("login.aspx");

            ClientScript.RegisterStartupScript(this.GetType(), "RefreshScript", "refreshPage();", true);
        }
    }
}