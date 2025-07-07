using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace MyFinalWork
{
    public partial class UserPageMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //浏览器不保存
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            // 检查Session中是否存在登录标识（这里假设登录成功后在Session中存储了某个特定标识，比如UserId）
            if (Session["UserId"] != null)
            {
                // 如果已登录，找到登录按钮和注册按钮并设置为不可见
                Button loginButton = (Button)FindControl("Button1");
                if (loginButton != null)
                {
                    loginButton.Visible = false;
                }
                Button registerButton = (Button)FindControl("Button2");
                if (registerButton != null)
                {
                    registerButton.Visible = false;
                }
                // 找到个人中心导航项并设置为可见（登录后显示）
                HtmlGenericControl liPersonalCenter = (HtmlGenericControl)FindControl("liPersonalCenter");
                if (liPersonalCenter != null)
                {
                    liPersonalCenter.Visible = true;
                }
            }
            else
            {
                // 如果未登录（即Session中没有登录标识），则让登录按钮和注册按钮可见，同时隐藏退出登录按钮和用户名标签
                Button loginButton = (Button)FindControl("Button1");
                if (loginButton != null)
                {
                    loginButton.Visible = true;
                }
                Button registerButton = (Button)FindControl("Button2");
                if (registerButton != null)
                {
                    registerButton.Visible = true;
                }
                Button logoutButton = (Button)FindControl("Button3");
                if (logoutButton != null)
                {
                    logoutButton.Visible = false;
                }
                Label loginNameLabel = (Label)FindControl("Label1");
                if (loginNameLabel != null)
                {
                    loginNameLabel.Visible = false;
                }
                // 找到个人中心导航项并设置为不可见（未登录时隐藏）
                HtmlGenericControl liPersonalCenter = (HtmlGenericControl)FindControl("liPersonalCenter");
                if (liPersonalCenter != null)
                {
                    liPersonalCenter.Visible = false;
                }
            }

            if (!IsPostBack)
            {
                string username = Session["Username"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    // 根据用户名定制用户的专属界面
                    Label1.Text = $"欢迎, {username}!";
                }
                else
                {
                    // 如果会话中没有用户名，重定向到登录页面
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // 这里可以添加退出登录的具体逻辑，比如清除Session中的登录相关信息等
            Session["UserId"] = null;
            Session["Username"] = null;
            //Response.Redirect("login.aspx");

            //ClientScript.RegisterStartupScript(this.GetType(), "RefreshScript", "refreshPage();", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userpage2.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userpage2.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userpage3.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userpage3.aspx");
        }
    }
}