using DiamondInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiamondInventory.Repo
{
    public class Dailyworkrepo 
    {
        string strConString = @"Data Source=sql5101.site4now.net;Initial Catalog=db_a6b32d_diamondinventory;User ID=db_a6b32d_diamondinventory_admin;Password=Diamond@123";
        public List<Dailywork_list> GetDailywork()
        {
            List<Dailywork_list> list = new List<Dailywork_list>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_mst_Dailywork_ShowList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
                list.Add(new Dailywork_list()
                {
                    DailyworkID = new Guid(dt.Rows[i]["DailyworkID"].ToString()),
                    WorkerID = new Guid(dt.Rows[i]["WorkID"].ToString()),
                    Work = Convert.ToInt32(dt.Rows[i]["Work"]),
                    Work_Date = (DateTime)dt.Rows[i]["Work_Date"],
                    WorkerName= dt.Rows[i]["Workername"].ToString(),
                    WorkType= dt.Rows[i]["WorkType"].ToString(),
                    price= Convert.ToDecimal(dt.Rows[i]["Price"])
                });
            return list;
        }
        public Dailywork Edit(Guid DailyworkID)
        {
            Dailywork list = new Dailywork();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_mst_Dailywork_Id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DailyworkID", DailyworkID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                con.Close();
            }
            {
                list.DailyworkID = new Guid(dt.Rows[0]["DailyworkID"].ToString());
                list.WorkerID = new Guid(dt.Rows[0]["WorkID"].ToString());
                list.Work = Convert.ToInt32(dt.Rows[0]["Work"]);
                list.Work_Date = (DateTime)(dt.Rows[0]["Work_Date"]);
            }
            return list;
        }
        public string Add(Dailywork Dailywork)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    
                    SqlCommand cmd = new SqlCommand("Sp_mst_Dailywork_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DailyworkID", Dailywork.DailyworkID);
                    cmd.Parameters.AddWithValue("@WorkID", Dailywork.WorkerID);
                    cmd.Parameters.AddWithValue("@Work", Dailywork.Work);
                    cmd.Parameters.AddWithValue("@Work_Date", Dailywork.Work_Date);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
                //throw;
            }
        }
        public string update(Dailywork Dailywork)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Update mst_Dailywork SET  WorkID=@WorkID , Work=@Work, Work_Date=@Work_Date where DailyworkID=@DailyworkID";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_Dailywork_Update", con);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DailyworkID", Dailywork.DailyworkID);
                    cmd.Parameters.AddWithValue("@WorkID", Dailywork.WorkerID);
                    cmd.Parameters.AddWithValue("@Work", Dailywork.Work);
                    cmd.Parameters.AddWithValue("@Work_Date", Dailywork.Work_Date);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;

                // throw;
            }

        }
        public bool Delete(Guid DailyworkID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Delete from mst_Dailywork where DailyworkID=@DailyworkID";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_Dailywork_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DailyworkID", DailyworkID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }

            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        


    }
}
   
