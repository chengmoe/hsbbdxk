using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hzxt
{
    public partial class zhujiemian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["un"] != null)
            {
                Label1.Text = "欢迎您，" + Request.Cookies["un"].Value;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.Items[0].ChildItems[0].Selected)
            {
                Response.Redirect("WebForm4.aspx");
            }
            if (Menu1.Items[0].ChildItems[1].Selected)
            {
                Response.Redirect("releas.aspx");
            }
            if (Menu1.Items[0].ChildItems[2].Selected)
            {
                Response.Redirect("WebForm5.aspx");
            }
        }
    }
}