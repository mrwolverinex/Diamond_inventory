using DiamondInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiamondInventory.Repo
{
    public class Workertyperepo
    {

        string strConString = @"Data Source=sql5101.site4now.net;Initial Catalog=db_a6b32d_diamondinventory;User ID=db_a6b32d_diamondinventory_admin;Password=Diamond@123";

        public List<WorkerType> GetWorkerType()
        {
            List<WorkerType> list = new List<WorkerType>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                /*SqlCommand cmd = new SqlCommand("Select * from mst_WorkType", con);*/
                SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_ShowAllList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
                list.Add(new WorkerType()
                {
                    WorkTypeID = new Guid(dt.Rows[i]["WorkTypeID"].ToString()),
                    TypeName = dt.Rows[i]["TypeName"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[i]["Price"]),

                });
            return list;
        }
        public WorkerType Edit(Guid WorkTypeID)
        {
            WorkerType list = new WorkerType();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                /*SqlCommand cmd = new SqlCommand("Select * from mst_WorkType where WorkTypeID='" + WorkTypeID + "'", con);*/
                SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkTypeID", WorkTypeID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            {
                list.WorkTypeID = new Guid(dt.Rows[0]["WorkTypeID"].ToString());
                list.TypeName = dt.Rows[0]["TypeName"].ToString();
                list.Price = Convert.ToDecimal(dt.Rows[0]["Price"]);

            }
            return list;
        }
        public string Add(WorkerType WorkerType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Insert into mst_WorkType (WorkTypeID, TypeName,Price) values(@WorkTypeID, @TypeName , @Price)";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkTypeID", WorkerType.WorkTypeID);
                    cmd.Parameters.AddWithValue("@TypeName", WorkerType.TypeName);
                    cmd.Parameters.AddWithValue("@Price", WorkerType.Price);
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
        public string update(WorkerType WorkerType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                   /* string query = "Update mst_WorkType SET WorkTypeID=@WorkTypeID, TypeName=@TypeName , Price=@Price  where WorkTypeID= @WorkTypeID";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkTypeID", WorkerType.WorkTypeID);
                    cmd.Parameters.AddWithValue("@TypeName", WorkerType.TypeName);
                    cmd.Parameters.AddWithValue("@Price", WorkerType.Price);
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
        public bool Delete(Guid WorkTypeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Delete from mst_WorkType where WorkTypeID=@WorkTypeID";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkTypeID", WorkTypeID);
                    cmd.ExecuteNonQuery();
                    con.Close ();
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