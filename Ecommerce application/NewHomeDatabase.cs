using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class NewHomeDatabase
    {
        string constr = "Server = LAPTOP-RS59N8IM; database = Ecommerce; integrated security = true;";
        Connection connect = new Connection();
        public void SaveUser(NewHomeClass hc)
        {
            using (SqlConnection con = connect.CreateConnection())
            {
                con.Open();
                string query = "INSERT INTO tblUser VALUES ('" + hc.id + "','" + hc.FirstName + "','" + hc.LastName + "','" + hc.Username + "','" + hc.Password + "','" + hc.photo + "', '"  + hc.Phone + "' , '" + hc.Email + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                    MessageBox.Show("Save Successful");
                con.Close();

            }
        }

        public void SaveUserByStoredProc(NewHomeClass hc)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertCustomer", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", hc.id);
                    cmd.Parameters.AddWithValue("@fname", hc.FirstName);
                    cmd.Parameters.AddWithValue("@lname", hc.LastName);
                    cmd.Parameters.AddWithValue("@userName", hc.Username);
                    cmd.Parameters.AddWithValue("@password", hc.Password);
                    cmd.Parameters.AddWithValue("@phone", hc.Phone);
                    cmd.Parameters.AddWithValue("@email ", hc.Email);
                    //cmd.Parameters.AddWithValue("@role", u.role);
                    cmd.Parameters.AddWithValue("@photo", hc.photo);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Save Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void DeleteUserByStoredProc(string id)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Deleted Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateUserByStoredProc(NewHomeClass u)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", u.id);
                    cmd.Parameters.AddWithValue("@firstname", u.FirstName);
                    cmd.Parameters.AddWithValue("@fathername", u.LastName);
                    cmd.Parameters.AddWithValue("@username", u.Username);
                    cmd.Parameters.AddWithValue("@password", u.Password);
                    cmd.Parameters.AddWithValue("@photo", u.photo);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Updated Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable getUser(string fn, string ln)
        {
            SqlConnection con = connect.CreateConnection();
            SqlDataAdapter da = new SqlDataAdapter("spGetUser", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@fn", fn);
            da.SelectCommand.Parameters.AddWithValue("@ln", ln);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblUser");
            DataTable dt = ds.Tables["tblUser"];
            return dt;
        }

        public DataTable CustomerProductCategory(string category, string name)
        {
            DataTable dt = null;
            try
            {
                using(SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", name);
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable PopulateItem()
        {
            DataTable dt = null;
            //Home home = new Home();
            //string constr = "Server = LAPTOP-RS59N8IM;   Database = Ecommerce; integrated security=true";
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spLoad_data", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                   /* LoadItems[] a = new LoadItems[dt.Rows.Count];
                    //home.resize();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a[i] = new LoadItems();
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                        a[i].Name = dt.Rows[i]["name"].ToString();
                        a[i].Description = dt.Rows[i]["description"].ToString();
                        a[i].Price = string.Format(dt.Rows[i]["price"].ToString());

                        if (home.flowLayoutPanel1.Controls.Count < 0)
                            home.flowLayoutPanel1.Controls.Clear();
                        else
                            home.flowLayoutPanel1.Controls.Add(a[i]);
                    }*/

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        private Dictionary<string, int> GetCount(string columnName)
        {
            string currentKey = "";
            Dictionary<string, int> ValuesAndCounts = new Dictionary<string, int>();
            foreach(DataGridViewRow row in Home.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if(row.Cells[columnName].Value != null)
                    {
                        currentKey = row.Cells[columnName].Value.ToString();
                        if (ValuesAndCounts.ContainsKey(currentKey))
                        {
                            ValuesAndCounts[currentKey]++;
                        }
                        else
                        {
                            ValuesAndCounts.Add(currentKey, 1);
                        }
                    }

                }
            }
            return ValuesAndCounts;
        }

        static string cat;
        static string price1;
        static string id1;
        static string qty1;
        
        public void array(string id2)
        {
            Dictionary<string, int> coloumn_counts = GetCount("id");
            Queue cate = new Queue();
            Queue price = new Queue();
            Queue id = new Queue();
            Queue qty2 = new Queue();
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    foreach(KeyValuePair<string, int> keyvaluePair in coloumn_counts)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select category, price from Product where productid = @id", con);
                        cmd.Parameters.AddWithValue("@id", id2);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            cate.Enqueue(da.GetValue(0).ToString());
                            price.Enqueue(da.GetValue(1).ToString());
                            id.Enqueue(Convert.ToString(id2));
                            qty2.Enqueue(Convert.ToString(keyvaluePair.Value));
                        }
                        con.Close();
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            cat = (string)cate.Dequeue();
            price1 = (string)price.Dequeue();
            id1 = (string)id.Dequeue();
            qty1 = (string)qty2.Dequeue();
        }

        public void Transaction()
        {

            LoadItems l = new LoadItems();
            NewHomeClass newHome = new NewHomeClass();
            Dictionary<string, int> column_counts = GetCount("id");
            string now = DateTime.Now.ToShortDateString();
            int rowAffected = 0;
            foreach(KeyValuePair<string, int> keyValuePair in column_counts) { }
            try
            {
                using(SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    for(int i = 0; i < Home.dataGridView1.Rows.Count; i++)
                    {
                        array(Home.dataGridView1.Rows[i].Cells["id"].Value.ToString());
                        cmd = new SqlCommand("spTransaction", con);
                        //cmd.Parameters.AddWithValue("@user_name", Home.name);
                        cmd.Parameters.AddWithValue("@productID", Home.dataGridView1.Rows[i].Cells["id"].Value);

                        cmd.Parameters.AddWithValue("@totalPrice", price1);
                        cmd.Parameters.AddWithValue("@category", cat);
                        cmd.Parameters.AddWithValue("@date", now);
                        cmd.Parameters.AddWithValue("@quantity", qty1);
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Our partner Addis Delivery will contact you in a moment through your mobile number.");
                        MessageBox.Show("Thank you for using our application!");
                    }
                    else
                        MessageBox.Show("Something is wrong with our server please restart the application.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
