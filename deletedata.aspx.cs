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
    public partial class deletedata : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from registration where Id='" + id + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LF.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                    LL.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                    LU.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
                    LP.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    LE.Text = ds.Tables[0].Rows[0]["email_id"].ToString();


                }


            }
        }

        protected void bdelete_Click(object sender, EventArgs e)
        {
            string Emailid = LE.Text;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from registration where email_id='"+Emailid+"'", conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result == 1)
            {
                Response.Redirect("~/registartiondata.aspx");


            }
            else
            {
                Lmessage.Text = "Any error please check";

            }
        }
    }
}