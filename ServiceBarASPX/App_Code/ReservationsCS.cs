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
    public class ReservationsCS
    {
        #region Properties
        //Getters & Setters
        public int Res_Id { get; set; }
        public int Guest_Id { get; set; }
        public int Table_Id { get; set; }
        public int User_Id { get; set; }
        public string Res_Date { get; set; } 
        //DateTime?
        public string Res_Time { get; set; } 
        //DateTime?
        public int Res_Guest_Cnt { get; set; }
        public string Res_Sp_Req { get; set; }
        

        #endregion

        #region Constructors

        //Default
        public ReservationsCS() { }

        //Overloaded
        public ReservationsCS(int res_id)
        {
            //wtf errors????
            DataTable dt = GetReservations(res_id);

            if (dt.Rows.Count > 0)
            {
                this.Res_Id = (int)dt.Rows[0]["res_id"];
                this.Guest_Id = (int)dt.Rows[0]["guest_id"];
                this.Table_Id = (int)dt.Rows[0]["tbl_id"];
                this.User_Id = (int)dt.Rows[0]["user_id"];
                //this.Res_Date = dt.Rows[0]["res_date"].ToString();
                this.Res_Date = Convert.ToDateTime(dt.Rows[0]["res_date"]).ToString("yyyy-MM-dd");
                this.Res_Time = dt.Rows[0]["res_time"].ToString();
                this.Res_Guest_Cnt = (int)dt.Rows[0]["res_guest_cnt"];
                this.Res_Sp_Req = dt.Rows[0]["res_spec_req"].ToString();
                
            }
        }
        #endregion

        #region Methods/Functions
        //GetAll
        private static DataTable GetReservations(int res_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_getById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@res_id", SqlDbType.Int).Value = res_id;

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

        public static int InsertReservation(ReservationsCS sr)
        {
            //declare return variable
            int new_id = 0;
            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(
                "@guest_id", SqlDbType.Int).Value = sr.Guest_Id;
            cmd.Parameters.Add(
                "@tbl_id", SqlDbType.Int).Value = sr.Table_Id;
            cmd.Parameters.Add(
                "@user_id", SqlDbType.Int).Value = sr.User_Id;
            cmd.Parameters.Add(
                "@res_date", SqlDbType.Date).Value = sr.Res_Date;
            cmd.Parameters.Add(
                "@res_time", SqlDbType.Time).Value = sr.Res_Time;
            cmd.Parameters.Add(
                "@res_guest_cnt", SqlDbType.Int).Value = sr.Res_Guest_Cnt;
            cmd.Parameters.Add(
                "@res_spec_req", SqlDbType.VarChar).Value = sr.Res_Sp_Req;
            
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

        public static bool UpdateReservation(ReservationsCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
               "@res_id", SqlDbType.Int).Value = sr.Res_Id;
            cmd.Parameters.Add(
                "@guest_id", SqlDbType.Int).Value = sr.Guest_Id;
            cmd.Parameters.Add(
                "@tbl_id", SqlDbType.Int).Value = sr.Table_Id;
            cmd.Parameters.Add(
                "@user_id", SqlDbType.Int).Value = sr.User_Id;
            cmd.Parameters.Add(
                "@res_date", SqlDbType.Date).Value = sr.Res_Date;
            cmd.Parameters.Add(
                "@res_time", SqlDbType.Time).Value = sr.Res_Time;
            cmd.Parameters.Add(
                "@res_guest_cnt", SqlDbType.Int).Value = sr.Res_Guest_Cnt;
            cmd.Parameters.Add(
                "@res_spec_req", SqlDbType.VarChar).Value = sr.Res_Sp_Req;
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
        public static int GetAvailableTable(string date, string time, int guestCount)
        {
            int tbl_id = 0;

            SqlConnection cn = new SqlConnection(
               ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_getAvailable", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@res_date", SqlDbType.Date).Value = date;
            cmd.Parameters.Add(
                  "@res_time", SqlDbType.Time).Value = time;
            cmd.Parameters.Add(
                  "@res_guest_cnt", SqlDbType.Int).Value = guestCount;

            // Open database connection -> execute command
            try
            {
                cn.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                tbl_id = Convert.ToInt32(dr["tbl_id"]);

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
            return tbl_id;

        }




        #endregion

    }
}