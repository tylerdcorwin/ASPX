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
    public class SectionCS
    {
        #region Properties
        //Getters & Setters
        public int Sect_ID { get; set; }
        public string Sect_Name { get; set; }
        public string Sect_Desc { get; set; }
        public bool Sect_Active = false;

        #endregion

        #region Constructors

        //Default
        public SectionCS() { }

        //Overloaded
        public SectionCS(int sect_id)
        {
            DataTable dt = GetSectionItemsID(sect_id);

            if (dt.Rows.Count > 0)
            {
                this.Sect_ID = (int)dt.Rows[0]["sect_id"];
                this.Sect_Name = dt.Rows[0]["sect_name"].ToString();
                this.Sect_Desc = dt.Rows[0]["sect_desc"].ToString();
                this.Sect_Active = (bool)dt.Rows[0]["sect_active"];
            }
        }
        #endregion

        #region Methods/Functions
        //GetAll
        private static DataTable GetSectionItemsID(int item_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sections_getById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sect_id", SqlDbType.Int).Value = item_id;

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

        public static bool InsertSectionItem(SectionCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sections_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            
            cmd.Parameters.Add(
                "@sect_name", SqlDbType.VarChar).Value = sr.Sect_Name;
            cmd.Parameters.Add(
                "@sect_desc", SqlDbType.VarChar).Value = sr.Sect_Desc;
            cmd.Parameters.Add(
                "@sect_active", SqlDbType.Bit).Value = sr.Sect_Active;

            // Open database connection -> execute command
            try
            {
                cn.Open();
                //execute -> stored procedure
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

        public static bool UpdateSectionItems(SectionCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sections_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@sect_id", SqlDbType.Int).Value = sr.Sect_ID;
            cmd.Parameters.Add(
                  "@sect_name", SqlDbType.VarChar).Value = sr.Sect_Name;
            cmd.Parameters.Add(
                "@sect_desc", SqlDbType.VarChar).Value = sr.Sect_Desc;
            cmd.Parameters.Add(
                "@sect_active", SqlDbType.Bit).Value = sr.Sect_Active;

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

        #endregion

    }

}
