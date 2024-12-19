using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.DynamicData;

namespace Hospital_Management_System
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=localhost; user=root; database=hospital_management_system; password=@.Sumanth5472; port=3306;";
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                string query = "INSERT INTO patients_table (ID, Patient_name, Age, Address) VALUES ('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text+ "');";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open(); // Corrected method casing
                cmd.ExecuteNonQuery();
                con.Close(); // Corrected method name
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=localhost; user=root; database=hospital_management_system; password=@.Sumanth5472; port=3306;";
            using (MySqlConnection Con = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM patients_table", Con))
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    cmd.Connection = Con;
                    da.SelectCommand = cmd; // Corrected property name
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt; // Corrected GridView name
                    GridView1.DataBind(); // Corrected GridView name
                }
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=localhost; user=root; database=hospital_management_system; password=@.Sumanth5472; port=3306;";
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                string query = "DELETE FROM patients_table WHERE ID='" + TextBox1.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=localhost; user=root; database=hospital_management_system; password=@.Sumanth5472; port=3306;";
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                string query = "UPDATE patients_table SET ID='" + TextBox2.Text + "', Patient_Name='" + TextBox3.Text + "', Age='" + TextBox4.Text + "', Address='" + TextBox5.Text+ "' WHERE ID='" + TextBox1.Text+"';";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}