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
    public class MenuItemCS
    {

        #region Properties
        //Getters & Setters
        public int Item_ID {
            get;
            set; }
        public int Menu_Id { get; set; }
        public int Cat_Id { get; set; }
        public string Item_Name { get; set; }
        public string Item_Desc { get; set; }
        public string Item_Allergens { get; set; }
        public decimal Item_Price {
            get;
            set; }
        public bool Item_Gluten_Free { get; set; }

        public bool Item_Active = false;

        #endregion

        #region Constructors

        //Default
        public MenuItemCS() { }

        //Overloaded
        public MenuItemCS(int item_id)
        {
            DataTable dt = GetMenuItemsID(item_id);  

            if (dt.Rows.Count > 0)
            {
                this.Item_ID = (int)dt.Rows[0]["item_id"];
                this.Menu_Id = (int)dt.Rows[0]["menu_id"];
                this.Cat_Id = (int)dt.Rows[0]["cat_id"];
                this.Item_Name = dt.Rows[0]["item_name"].ToString();
                this.Item_Desc = dt.Rows[0]["item_desc"].ToString();
                this.Item_Allergens = dt.Rows[0]["item_allergens"].ToString();
                this.Item_Price = (decimal)dt.Rows[0]["item_price"];
                this.Item_Gluten_Free = (bool)dt.Rows[0]["item_gluten_free"];
                this.Item_Active = (bool)dt.Rows[0]["item_active"];
            }
        }
        #endregion

        #region Methods/Functions
        //GetAll
        private static DataTable GetMenuItemsID(int item_id)   
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("menu_items_getById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;

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

        public static bool InsertMenuItem(MenuItemCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("menu_items_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@menu_id", SqlDbType.Int).Value = sr.Menu_Id;
            cmd.Parameters.Add(
                "@cat_id", SqlDbType.Int).Value = sr.Cat_Id;
            cmd.Parameters.Add(
                "@item_name", SqlDbType.VarChar).Value = sr.Item_Name;
            cmd.Parameters.Add(
                "@item_desc", SqlDbType.VarChar).Value = sr.Item_Desc;
            cmd.Parameters.Add(
                "@item_allergens", SqlDbType.VarChar).Value = sr.Item_Allergens;
            cmd.Parameters.Add(
                "@item_price", SqlDbType.Decimal).Value = sr.Item_Price;
            cmd.Parameters.Add(
                "@item_gluten_free", SqlDbType.Bit).Value = sr.Item_Gluten_Free;
            cmd.Parameters.Add(
                "@item_active", SqlDbType.Bit).Value = sr.Item_Active;

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

        public static bool UpdateMenuItems(MenuItemCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_CorwinConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("menu_items_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@item_id", SqlDbType.Int).Value = sr.Item_ID;
            cmd.Parameters.Add(
                  "@menu_id", SqlDbType.Int).Value = sr.Menu_Id;
            cmd.Parameters.Add(
                  "@cat_id", SqlDbType.Int).Value = sr.Cat_Id;
            cmd.Parameters.Add(
                  "@item_name", SqlDbType.VarChar).Value = sr.Item_Name;
            cmd.Parameters.Add(
                "@item_desc", SqlDbType.VarChar).Value = sr.Item_Desc;
            cmd.Parameters.Add(
                "@item_allergens", SqlDbType.VarChar).Value = sr.Item_Allergens;
            cmd.Parameters.Add(
                "@item_price", SqlDbType.Decimal).Value = sr.Item_Price;
            cmd.Parameters.Add(
                "@item_gluten_free", SqlDbType.Bit).Value = sr.Item_Gluten_Free;
            cmd.Parameters.Add(
                "@item_active", SqlDbType.Bit).Value = sr.Item_Active;

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