using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hzxt
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;
                DropDownList2.Items.Add(dt.Year.ToString());
                DropDownList3.Items.Add(dt.Month.ToString());
                DropDownList4.Items.Add(dt.Day.ToString());
                DropDownList4.Items.Add("23");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //System.DateTime currentTime = new System.DateTime();
            //currentTime = System.DateTime.Now;
            //string strYMD = currentTime.ToString("f");
            //TextBox1.Text = strYMD;
            string s1 = DateTime.Now.ToString();
            string s2="2020/5/26 21:51:20";
            DateTime dt1 = Convert.ToDateTime(s1);
            DateTime dt2 = Convert.ToDateTime(s2);
            if (DateTime.Compare(dt1, dt2) > 0)
            {
                TextBox1.Text = s1;
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.Items[0].ChildItems[0].Selected)
            {
                TextBox1.Text = Menu1.SelectedItem.Text;
            }
            if (Menu1.Items[1].ChildItems[0].Selected)
            {
                TextBox1.Text = Menu1.SelectedItem.Text;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = DropDownList1.SelectedValue.ToString() + DropDownList2.SelectedValue.ToString();
            if (DropDownList1.SelectedValue.ToString() == "2")
            {
                int y = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                if (y > 1)
                {
                    TextBox1.Text = DropDownList1.SelectedValue.ToString() + DropDownList2.SelectedValue.ToString();
                }
            }
                
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(DropDownList2.SelectedValue + "-" + DropDownList3.SelectedValue + "-" + DropDownList4.SelectedValue);
        }
    }
}