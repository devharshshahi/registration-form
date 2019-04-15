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
    public partial class registartiondata : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        DataSet ds = new DataSet();
        protected List<registration> o = new List<registration>();
  

        protected void Page_Load(object sender, EventArgs e)
        {
            string EmailId = string.Empty;
            if (Session["emailid"] !=null)
            {
                EmailId = Session["emailId"].ToString();
                if(EmailId !=null)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spregistartion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Lblmessage.Text = "welcome "  + ds.Tables[0].Rows[0]["first_name"].ToString();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            o.Add(new registration
                            {
                                Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()),
                                Firstname = ds.Tables[0].Rows[i]["first_name"].ToString(),
                                Lastname = ds.Tables[0].Rows[i]["last_name"].ToString(),
                                Username = ds.Tables[0].Rows[i]["user_name"].ToString(),
                                Password = ds.Tables[0].Rows[i]["password"].ToString(),
                                Emailid = ds.Tables[0].Rows[i]["email_id"].ToString(),
                                State = ds.Tables[0].Rows[i]["state"].ToString(),
                                City = ds.Tables[0].Rows[i]["city"].ToString(),
                                Pincode = ds.Tables[0].Rows[i]["pincode"].ToString(),
                                Gender = ds.Tables[0].Rows[i]["gender"].ToString(),
                                Programming = ds.Tables[0].Rows[i]["programming"].ToString(),
                            });
                        }
                    }
                


                }
                else
            {
                Response.Redirect("~/LoginForm.aspx");
            }
           

            }
            else
            {


            }

        }
    }
}