using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string username = user.Text;
            string password = pass.Text;
           
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spsignup",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                


                if (username == ds.Tables[0].Rows[0][0].ToString() && 
                    password == ds.Tables[0].Rows[0][1].ToString())
                {
                    Session["emailid"] = username;
                    Response.Redirect("~/registartiondata.aspx");

                }
                else
                {
                    Lblmessage.Text = "please check username and password";
                }
               
            }
            else
            {
                Lblmessage.Text = "please check username and password";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}