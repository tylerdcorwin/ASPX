using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TCorwin_SE256
{
    public class AppUser
    {
        #region Properties
        public int UserId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }

        public bool ValidLogin = false;


        #endregion

        #region Constructors
        //default  assigns a new user a salt that will be theirs for the total existance
        public AppUser() { this.Salt = CreateSalt(); }
        public AppUser(string email)
        {
            DataTable dt = getUser(email);
            if (dt.Rows.Count > 0)
            //(int) casts everything that follows as the new datatype in this case int
            //.tostring() is an inline process so you could cast each with (string) but its unessisary
            {
                this.UserId = (int)dt.Rows[0]["user_id"];
                this.Email = dt.Rows[0]["user_email"].ToString();
                this.Salt = dt.Rows[0]["user_salt"].ToString();
                this.FistName = dt.Rows[0]["user_first"].ToString();
                this.LastName = dt.Rows[0]["user_last"].ToString();
                this.HashedPassword = dt.Rows[0]["user_pwd"].ToString();
                this.ValidLogin = false;
            }
        }
        #endregion


        #region Methods/Functions
        private static string CreateSalt()
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            byte[] saltBytes = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltBytes);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(saltBytes);
        }


        public static string CreatePasswordHash(string salt, string pwd)
        {
            string saltAndPwd = string.Concat(salt, pwd);
            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(saltAndPwd);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            // Optionally, represent the hash value as a base64-encoded string, 
            // For example, if you need to display the value or transmit it over a network.
            return Convert.ToBase64String(bytHash);
        }

        public static AppUser Login(string email, string freeTextPassword)
        {
            AppUser au = new AppUser();
            //will automatically set the userID to 0 in the system
            //this will set up the first and last names, and assign them the salt and freetextpassword provided by the user
            au.FistName = "new";
            au.LastName = "password";
            au.HashedPassword = CreatePasswordHash(au.Salt, freeTextPassword);

            return au;
        }

        //making a function that retrieves a record from a database
        //you need SQL connection, command, paramaters, and dataAdapter
        private static DataTable getUser(string email)
        {
            //this connects to the database using the connection string stored in the web.config file in this case its SE256
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            //this is getting the stored procedure from the sql connection
            SqlCommand cmd = new SqlCommand("users_getByEmail", cn);
            //commandtype is an enumeration (static list of options) make sure to set it to stored procedure instead of txt
            cmd.CommandType = CommandType.StoredProcedure;
            //this gets what you want to find in the db
            cmd.Parameters.Add("@user_email", SqlDbType.VarChar).Value = email;
            //this is creating a new datatable to store what is being searched
            DataTable dt = new DataTable();
            //try to find a record
            try
            {
                //open database connection
                cn.Open();
                //create data adapter with our command object, bridges the gap from return set to return object in sql
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //return the dataTable with the record that was found
                da.Fill(dt);
            }
            //in case there is an error thrown
            catch
            {

            }
            //close connection
            finally
            {
                cn.Close();
            }
            //retrun results from the dataTable
            return dt;
        }

        #endregion

    }
}