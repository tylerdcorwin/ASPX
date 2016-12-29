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
    public class TableCS
    {
        #region Properties
        //Getters & Setters
        public int Table_ID { get; set; }
        public int Sect_ID { get; set; }
        public string Table_Name { get; set; }
        public string Table_Desc { get; set; }
        public int Table_SeatCnt { get; set; }
        public bool Table_Active = false;

        #endregion

        #region Constructors

        //Default
        public TableCS() { }

        //Overloaded
        public TableCS(int table_id)
        {
            DataTable dt = GetTables(table_id);

            if (dt.Rows.Count > 0)
            {
                this.Table_ID = (int)dt.Rows[0]["tbl_id"];
                this.Sect_ID = (int)dt.Rows[0]["sect_id"];
                this.Table_Name = dt.Rows[0]["tbl_name"].ToString();
                this.Table_Desc = dt.Rows[0]["tbl_desc"].ToString();
                this.Table_SeatCnt = (int)dt.Rows[0]["tbl_seat_cnt"];
                this.Table_Active = (bool)dt.Rows[0]["tbl_active"];
            }
        }
        #endregion

        #region Methods/Functions
        //GetAll
        private static DataTable GetTables(int tbl_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_getById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tbl_id", SqlDbType.Int).Value = tbl_id;

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

        public static bool InsertTable(TableCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure

            cmd.Parameters.Add(
                "@sect_id", SqlDbType.Int).Value = sr.Sect_ID;
            cmd.Parameters.Add(
                "@tbl_name", SqlDbType.VarChar).Value = sr.Table_Name;
            cmd.Parameters.Add(
                "@tbl_desc", SqlDbType.VarChar).Value = sr.Table_Desc;
            cmd.Parameters.Add(
                "@tbl_seat_cnt", SqlDbType.Int).Value = sr.Table_SeatCnt;
            cmd.Parameters.Add(
                "@tbl_active", SqlDbType.Bit).Value = sr.Table_Active;

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

        public static bool UpdateTable(TableCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@tbl_id", SqlDbType.Int).Value = sr.Table_ID;
            cmd.Parameters.Add(
                  "@sect_id", SqlDbType.Int).Value = sr.Sect_ID;
            cmd.Parameters.Add(
                  "@tbl_name", SqlDbType.VarChar).Value = sr.Table_Name;
            cmd.Parameters.Add(
                "@tbl_desc", SqlDbType.VarChar).Value = sr.Table_Desc;
            cmd.Parameters.Add(
                "@tbl_seat_cnt", SqlDbType.Int).Value = sr.Table_SeatCnt;
            cmd.Parameters.Add(
                "@tbl_active", SqlDbType.Bit).Value = sr.Table_Active;

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