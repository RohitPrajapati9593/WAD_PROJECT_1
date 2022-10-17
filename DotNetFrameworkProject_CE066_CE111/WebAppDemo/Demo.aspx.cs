using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppDemo
{
    public partial class Demo : System.Web.UI.Page
    {

        protected void ShowStudent()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "Select * from NoteList";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void INSERT_Btn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO NoteList VALUES (@Note_title,@Note_content)", con);


                    cmd.Parameters.AddWithValue("@Id", int.Parse(Id_Txt.Text));

                    cmd.Parameters.AddWithValue("@Note_title", Note_title_Txt.Text);
                    cmd.Parameters.AddWithValue("@Note_content", Note_message_Txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //   MessageBox.Show("Data stored successfully");
                }
            }
            catch (Exception ex)
            {
                Response.Write("errors:" + ex.Message);
            }


            //         cmd.Parameters.AddWithValue("@Note_title", int.Parse(Note_title_Txt.Text));

            //          cmd.Parameters.AddWithValue("@Note_content", int.Parse(Note_message_Txt.Text));



        }

        protected void UPDATE_Btn_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE NoteList SET Note_title=@Note_title,Note_content=@Note_content WHERE Id=@Id", con);


                    cmd.Parameters.AddWithValue("@Id", int.Parse(Id_Txt.Text));

                    cmd.Parameters.AddWithValue("@Note_title", Note_title_Txt.Text);
                    cmd.Parameters.AddWithValue("@Note_content", Note_message_Txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //   MessageBox.Show("Data stored successfully");
                }
            }
            catch (Exception ex)
            {
                Response.Write("errors:" + ex.Message);
            }


        }

        protected void DELETE_Btn_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DELETE NoteList   WHERE Id=@Id", con);


                    cmd.Parameters.AddWithValue("@Id", int.Parse(Id_Txt.Text));

                    cmd.Parameters.AddWithValue("@Note_title", Note_title_Txt.Text);
                    cmd.Parameters.AddWithValue("@Note_content", Note_message_Txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //   MessageBox.Show("Data stored successfully");
                }
            }
            catch (Exception ex)
            {
                Response.Write("errors:" + ex.Message);
            }



        }

        protected void SHOW_Btn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "Select * from NoteList";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    //rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            /*
             SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["notelistConnection"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NoteList ", con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            */
        }
    }
}