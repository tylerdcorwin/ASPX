using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//added
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TCorwin_SE256
{
    public class GuestCS
    {
        #region Properties
        //Getters & Setters
        public int Guest_ID { get; set; }
        public string Guest_Email { get; set; }
        public string Guest_First { get; set; }
        public string Guest_Last { get; set; }
        public string Guest_Salt { get; set; } 
        public string Guest_Pwd { get; set; }
        public string Guest_Phone { get; set; }

        #endregion

        #region Constructors

        //Default
        public GuestCS() {
            this.Guest_Salt = CreateSalt();
        }

        //Overloaded
        public GuestCS(int guest_id)
        {
            DataTable dt = GetGuest(guest_id);

            if (dt.Rows.Count > 0)
            {
                this.Guest_ID = (int)dt.Rows[0]["guest_id"];
                this.Guest_Email = dt.Rows[0]["guest_email"].ToString();
                this.Guest_First = dt.Rows[0]["guest_first"].ToString();
                this.Guest_Last = dt.Rows[0]["guest_last"].ToString();
                this.Guest_Salt = dt.Rows[0]["guest_salt"].ToString(); 
                this.Guest_Pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.Guest_Phone = dt.Rows[0]["guest_phone"].ToString();
            }
        }
        //Overloaded
        public GuestCS(string guest_email)
        {
            DataTable dt = GuestByEmail(guest_email);

            if (dt.Rows.Count > 0)
            {
                this.Guest_ID = (int)dt.Rows[0]["guest_id"];
                this.Guest_Email = dt.Rows[0]["guest_email"].ToString();
                this.Guest_First = dt.Rows[0]["guest_first"].ToString();
                this.Guest_Last = dt.Rows[0]["guest_last"].ToString();
                this.Guest_Salt = dt.Rows[0]["guest_salt"].ToString();
                this.Guest_Pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.Guest_Phone = dt.Rows[0]["guest_phone"].ToString();





            }
        }


        #endregion

        #region Methods/Functions
        //GetAll
        private static DataTable GetGuest(int guest_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_getById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@guest_id", SqlDbType.Int).Value = guest_id;

            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

        public static int InsertGuest(GuestCS sr)
        {
            int new_id = 0;
            //declare return variable

            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(
                "@guest_email", SqlDbType.VarChar).Value = sr.Guest_Email;
            cmd.Parameters.Add(
                "@guest_first", SqlDbType.VarChar).Value = sr.Guest_First;
            cmd.Parameters.Add(
                "@guest_last", SqlDbType.VarChar).Value = sr.Guest_Last;
            cmd.Parameters.Add(
                 "@guest_salt", SqlDbType.VarChar).Value = sr.Guest_Salt;
            cmd.Parameters.Add(
                "@guest_pwd", SqlDbType.VarChar).Value = sr.Guest_Pwd;
            cmd.Parameters.Add(
                "@guest_phone", SqlDbType.VarChar).Value = sr.Guest_Phone;


            // Open database connection -> execute command
            try
            {
                cn.Open();
                //execute -> stored procedure
                cmd.ExecuteNonQuery();
                new_id = Convert.ToInt32(cmd.Parameters["@new_id"].Value);
            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
            }
            finally
            {
                cn.Close();
            }
            return new_id;
        }

        public static bool UpdateGuest(GuestCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@guest_id", SqlDbType.Int).Value = sr.Guest_ID;
            cmd.Parameters.Add(
                  "@guest_email", SqlDbType.VarChar).Value = sr.Guest_Email;
            cmd.Parameters.Add(
                "@guest_first", SqlDbType.VarChar).Value = sr.Guest_First;
            cmd.Parameters.Add(
                  "@guest_last", SqlDbType.VarChar).Value = sr.Guest_Last;
            cmd.Parameters.Add(
                  "@guest_salt", SqlDbType.VarChar).Value = sr.Guest_Salt;
            cmd.Parameters.Add(
                "@guest_pwd", SqlDbType.VarChar).Value = sr.Guest_Pwd;
            cmd.Parameters.Add(
                  "@guest_phone", SqlDbType.VarChar).Value = sr.Guest_Phone;


            // Open database connection -> execute command
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
                blnSuccess = false;
            }
            finally
            {
                cn.Close();
            }
            return blnSuccess;
        }

        public static DataTable GuestByEmail(string email)
        {
            DataTable dt = new DataTable();
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_getByEmail", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure

            cmd.Parameters.Add(
                  "@guest_email", SqlDbType.VarChar).Value = email;


            // Open database connection -> execute command
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();

            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

        private static string CreateSalt()
        {
            // Generate salt using CryptoServiceProvider
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

        #endregion

    }
}