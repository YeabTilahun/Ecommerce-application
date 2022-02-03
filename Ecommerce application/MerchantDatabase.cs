using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;

namespace Ecommerce_application
{
    class MerchantDatabase
    {
        Connection connect = new Connection();
        //Add Product
        public void AddProduct(MerchantClass sell)
        {    
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", sell.productName);
                    cmd.Parameters.AddWithValue("@price", sell.price);
                    cmd.Parameters.AddWithValue("@quantity", sell.quantity);
                    cmd.Parameters.AddWithValue("@category", sell.category);
                    cmd.Parameters.AddWithValue("@description", sell.description);
                    cmd.Parameters.AddWithValue("@expireDate", sell.exDate);
                    cmd.Parameters.AddWithValue("@DateStamp", sell.stamp);
                    cmd.Parameters.AddWithValue("@Photo", sell.photo);
                    cmd.Parameters.AddWithValue("@merchantName", sell.user);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("New product added sucessfully");
                    }
                    else
                        MessageBox.Show("Adding product failed! Try again.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Delete Product
        public void Delete(String id)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", id);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Product deleted Sucessfully");
                    }
                    else
                        MessageBox.Show("Failed! Please try again.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Update Product
        public void UpdateProduct(MerchantClass sell)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", sell.productName);
                    cmd.Parameters.AddWithValue("@price", sell.price);
                    cmd.Parameters.AddWithValue("@quantity", sell.quantity);
                    cmd.Parameters.AddWithValue("@category", sell.category);
                    cmd.Parameters.AddWithValue("@description", sell.description);
                    cmd.Parameters.AddWithValue("@expireDate", sell.exDate);
                    cmd.Parameters.AddWithValue("@DateStamp", sell.stamp);
                    cmd.Parameters.AddWithValue("@Photo", sell.photo);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Product Updated Sucessfully!");

                    }
                    else
                        MessageBox.Show("Failed! Please try again");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //GET ITEMS ACCORDING TO THE SELECTED CATEGORY
        public DataTable Selected_Cat(string category)
        {
          DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spSelected-cat-product", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        static string cat;
        static string price1;
        static string id1;
        static string qty;
        Merchant cp = new Merchant();
        public void array(string id2)
        {
            Dictionary<string, int> column_Counts = cp.GetCountOfValues("id");
            try
            {

                using (SqlConnection con = connect.CreateConnection())
                {
                    foreach (KeyValuePair<string, int> kvp in column_Counts)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select category,price from product where productid=@id", con);
                        cmd.Parameters.AddWithValue("@id", id2);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            cat = da.GetValue(0).ToString();
                            price1 = da.GetValue(1).ToString();
                            id1 = Convert.ToString(id2);
                            qty = Convert.ToString(kvp.Value);
                        }
                        con.Close();
                    }
                   ;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add transaction information when buy clicked

        public void Transaction1()
        {
            int counter = 0;
            MerchantLoadProducts a = new MerchantLoadProducts();
            Merchant b = new Merchant();
            Dictionary<string, int> column_Counts = b.GetCountOfValues("id");
            string now = DateTime.Now.ToShortDateString();
            int rowAffected = 0;
            foreach (KeyValuePair<string, int> kvp in column_Counts)
            {
                using (SqlConnection con = connect.CreateConnection())
                {

                    SqlDataAdapter da = new SqlDataAdapter("spGetProductImageAndName", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@id", int.Parse(kvp.Key));
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProfile");
                    DataTable dt = ds.Tables["tblProfile"];
                    if (int.Parse(dt.Rows[0]["quantity"].ToString()) < kvp.Value && !Convert.IsDBNull(dt.Rows[0]["quantity"]))
                    {
                        MessageBox.Show("There is no Efficent Quantity by {0} Product in our store", dt.Rows[0]["name"].ToString());
                        counter++;
                        break;
                    }

                }
            }
            if(counter == 0)
            {
                try
                {
                    using (SqlConnection con = connect.CreateConnection())
                    {

                        con.Open();
                        SqlCommand cmd = new SqlCommand();

                        for (int i = 0; i < Merchant.dataGridView2.Rows.Count; i++)
                        {
                            array(Merchant.dataGridView2.Rows[i].Cells["id"].Value.ToString());
                            cmd = new SqlCommand("spTransaction", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user_name", Merchant.name);
                            cmd.Parameters.AddWithValue("@productID", Merchant.dataGridView2.Rows[i].Cells["id"].Value);

                            cmd.Parameters.AddWithValue("@totalPrice", price1);
                            cmd.Parameters.AddWithValue("@category", cat);
                            cmd.Parameters.AddWithValue("@date", now);
                            cmd.Parameters.AddWithValue("@quantity", qty);
                            rowAffected = cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Our partner Addis Delivery will contact you in a moment through your mobile number.");
                            MessageBox.Show("Thank you for using our application!");
                        }
                        else
                            MessageBox.Show("You don't have any product to buy");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        //check if merchant is valid or not
        public string check()
        {

        string check = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select status from merchant where username=@user", con);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        check = da.GetValue(0).ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }

       /* //Fetch information about merchant from database and assign it to my profile page
        public void loadMyProfile()
        {
            MerchantProfile1 mp = new MerchantProfile1();
             try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select fname,lname,birthday,email,userName,photo from merchant where merchantName=@user", con);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {

                        mp.fnameBox.Text = da.GetValue(0).ToString();
                        mp.lnameBox.Text = da.GetValue(1).ToString();
                        mp.birthdayBox.Value = Convert.ToDateTime(da.GetValue(2).ToString());
                        mp.emailBox.Text = da.GetValue(3).ToString();
                        mp.usernameBox.Text = da.GetValue(4).ToString();

                        byte[] photo = (byte[])da.GetValue(5);
                        MemoryStream ms = new MemoryStream(photo);
                        mp.profileImage.Image = Image.FromStream(ms);
                    }
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        //display all products in datatbase
        public DataTable PopulateItem()
        {
            DataTable dt = null;
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
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        //get products added by the user
        public DataTable Getproduct(String user)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    // mb.panelBuy.Controls.Clear();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetMyProduct", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", user);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        //method that search the database 
        public DataTable search(string key)
        {
            DataTable dt = null;
           try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand sqlCmd = new SqlCommand("Exec spSearch @search", con);
                    sqlCmd.Parameters.AddWithValue("@search", key);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(reader);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        // Get the catagories that are available in the database
        public string [] GetCategory()
        {
            string[] category = null;
            try
            {
               using (SqlConnection con = connect.CreateConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetCategory", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblCategory");
                    DataTable dt = ds.Tables["tblCategory"];
                    category = new string[dt.Rows.Count];
                    DataRow row;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        row = dt.Rows[i];
                        category[i] = row["category"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return category;
        }

        //Fetch old password nd return to check from the entered password
        //wrong
        public string GetOldPassword(string user)
        {
            string old_pass = null;
           try
            {
/*                using (SqlConnection con = connect.CreateConnection())
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetPassword", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", "yoo");
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblpass");
                    DataTable dt = ds.Tables["tblpass"];
                    old_pass = dt.Rows[0]["password"].ToString();

                }*/
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return old_pass;
        }

        //string for update pass in table all
        string pass1 = null;
        //This will update the password if called
        public void UpdatePassword(string pass)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdatePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Password reset!");
                        pass1 = pass;

                    }
                    else
                        MessageBox.Show("Failed! Please try again");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //to update table all
        string uname = null;
        string olduser = Merchant.name;
        //This will update merchant database information when called
        public void UpdateProfile(MerchantClass mp)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateMerchantProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* MemoryStream ms = new MemoryStream();
                     mp.profileImage.BackgroundImage.Save(ms, mp.profileImage.BackgroundImage.RawFormat);
                     byte[] Photo = ms.ToArray();*/
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    cmd.Parameters.AddWithValue("@fname", mp.fname);
                    cmd.Parameters.AddWithValue("@lname", mp.lname);
                    cmd.Parameters.AddWithValue("@birthday", mp.bday);
                    cmd.Parameters.AddWithValue("@email", mp.email);
                    cmd.Parameters.AddWithValue("@username", mp.username);
                    cmd.Parameters.AddWithValue("@phone", mp.phone);
                    cmd.Parameters.AddWithValue("@photo", mp.photo2);
                    int rowAffected = cmd.ExecuteNonQuery();

                    con.Close();
                    if (rowAffected > 0)
                    {
                        UpdateTblAll();
                        MessageBox.Show("Saved Sucessfully! Please restart application");
                        Merchant.name = mp.username;
                        uname = mp.username;
                       
                    }
                    else
                        MessageBox.Show("Failed Please tryagain!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateTblAll()
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spChangePasswordTblAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@olduser", olduser);
                    cmd.Parameters.AddWithValue("@username", uname);
                    cmd.Parameters.AddWithValue("@password", pass1);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Password and user Changed Successfully to All");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Load merchant info
        public DataTable GetProfile()
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetMerchantProfile", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", Merchant.name);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblProfile");
                dt = ds.Tables["tblProfile"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}