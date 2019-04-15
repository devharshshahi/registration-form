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
    public partial class editregistartion : System.Web.UI.Page
    { 
        
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        DataSet ds = new DataSet();
        protected List<registration> o = new List<registration>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cityname;
                string Gender;

                string programming;
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from registration where Id='" + id + "' ; select distinct state from state", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FNAME.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                    LNAME.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                    USER.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
                    PASS.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    MAIL.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
                   
                    if (ds.Tables[1].Rows.Count > 0) 
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            ddlsatate.Items.Add(ds.Tables[1].Rows[i][0].ToString());

                        }


                    }
                    cityname= ds.Tables[0].Rows[0]["city"].ToString();
                    Gender= ds.Tables[0].Rows[0]["gender"].ToString();
                    programming= ds.Tables[0].Rows[0]["programming"].ToString();
                    string statename = ds.Tables[0].Rows[0]["state"].ToString();
                    ddlsatate.SelectedValue = statename;
                    ds.Tables.Clear();
                    cmd = new SqlCommand("spgetallcity", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@statename", statename);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)

                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ddlcity.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                        }

                    }
                    ddlcity.SelectedValue = cityname;
                    if (Gender == "Male")
                    {
                        Rdmale.Checked = true;
                    }
                    else {
                        Rdfemale.Checked = true;
                    }

                    string[] str = programming.Split(',');
                    for (int i = 0; i < str.Count(); i++)
                    {
                        if (str[i] == "java")
                        {
                            Chkjava.Checked = true;
                        }
                        if (str[i] == "dot net")
                        {
                            Chkdotnet.Checked = true;
                        }
                        if (str[i] == "python")
                        {
                            Chkpython.Checked = true;
                        }
                        if (str[i] == "c++")
                        {
                            Chkcplus.Checked = true;
                        }



                    }
                }


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string firstname = FNAME.Text;
            string lastname = LNAME.Text;
            string username = USER.Text;
            string password = PASS.Text;
            string emailid = MAIL.Text;
            string state = ddlsatate.SelectedValue;
            string city = ddlcity.SelectedValue;
            string pincode = txtpincode.Text;
            string gender = string.Empty;
            string programming = string.Empty;
            if (Rdmale.Checked)
            {
                gender = "Male";
            }
            else if (Rdfemale.Checked)
            {
                gender = "female";
            }
            if (Chkjava.Checked)
            {
                programming = Chkjava.Text;
            }
            if (Chkpython.Checked)
            {
                programming = programming + "," + Chkpython.Text;
            }
            if (Chkcplus.Checked)
            {
                programming = programming + "," + Chkcplus.Text;
            }
            if (Chkdotnet.Checked)
            {
                programming = programming + "," + Chkdotnet.Text;
            }



            if (string.IsNullOrEmpty(firstname))
            {
                lblmessage.Text = "please insert your first name";
                return;
            }
            else if (string.IsNullOrEmpty(lastname))
            {
                lblmessage.Text = "please insert your last name";
                return;
            }
            else if (string.IsNullOrEmpty(username))
            {
                lblmessage.Text = "please insert your user name";
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                lblmessage.Text = "please insert your password";
                return;
            }
            else if (string.IsNullOrEmpty(emailid))
            {
                lblmessage.Text = "please insert your emailid";
                return;
            }







            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname",firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@emailid",emailid);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int Result = cmd.ExecuteNonQuery();
            if (Result == 1)
            {
                lblmessage.Text = "your data update successfully";
             

            }
            else
            {
                lblmessage.Text = "Any errror,please check!";

            }
            conn.Close();

        }

        protected void ddlsatate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ddlcity.Items.Clear();
                ddlcity.Items.Add("select city");
             }
            DataSet ds = new DataSet();
            string statename = ddlsatate.SelectedValue;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spgetallcity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statename", statename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlcity.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

            }
        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string cityname = ddlcity.SelectedValue;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spgetpincode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pincode", cityname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {


                txtpincode.Text = ds.Tables[0].Rows[0][0].ToString();


            }

        }
    }
}