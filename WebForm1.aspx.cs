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
        public partial class WebForm1 : System.Web.UI.Page
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
            protected void Page_Load(object sender, EventArgs e)
            {

                if (!IsPostBack)
                {


                    DataSet ds = new DataSet();
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spgetallstatename", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlsatate.Items.Clear();

                        ddlsatate.Items.Add("select State");

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ddlsatate.Items.Add(ds.Tables[0].Rows[i][0].ToString());
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
             if(Chkdotnet.Checked)
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
                String sql= "insert into registration values('" + firstname +"','"+lastname+"','"+username+"','"+password+"','"+emailid+ "' ,'" + state + "','" + city + "','" + pincode + "','" + gender + "','" + programming + "')";
                SqlCommand cmd = new SqlCommand(sql,conn);
                int Result = cmd.ExecuteNonQuery();
            if (Result==1)
                {
                    lblmessage.Text = "registration done successfully";
                    ClearTextBox();

                }
                else
                {
                    lblmessage.Text = "Any errror,please check!";

                }
                conn.Close();
            }
            public void ClearTextBox()
            {
                FNAME.Text = string.Empty;
                LNAME.Text = string.Empty;
                USER.Text = string.Empty;
                PASS.Text = string.Empty;
                MAIL.Text = string.Empty;


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
                SqlCommand cmd = new SqlCommand("spgetallcity",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@statename",statename);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i=0;i<ds.Tables[0].Rows.Count;i++)
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
