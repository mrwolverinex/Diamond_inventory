using DiamondInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiamondInventory.Repo
{
    public class Workerrepo
    {

        string strConString = @"Data Source=sql5101.site4now.net;Initial Catalog=db_a6b32d_diamondinventory;User ID=db_a6b32d_diamondinventory_admin;Password=Diamond@123";

        public List<Worker> GetWorkers()
        {
            List<Worker> list = new List<Worker>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                /*SqlCommand cmd = new SqlCommand("Select * from mst_worker", con);*/
                SqlCommand cmd = new SqlCommand("Sp_mst_worker_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal WorkPrice = 0;
                if (dt.Rows[i]["Workprice"].ToString() == null || dt.Rows[i]["Workprice"].ToString() == "")
                {
                    WorkPrice = 0;
                }
                else 
                {
                    WorkPrice = Convert.ToDecimal(dt.Rows[i]["Workprice"]);
                }
                list.Add(new Worker()
                {
                    WorkerId = new Guid(dt.Rows[i]["WorkerId"].ToString()),
                    Workername = dt.Rows[i]["Workername"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    MobileNo = dt.Rows[i]["MobileNo"].ToString(),
                    WorkType = dt.Rows[i]["WorkType"].ToString(),
                    WorkPrice = WorkPrice,
                    Address = dt.Rows[i]["Address"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    BloodGroup = dt.Rows[i]["BloodGroup"].ToString(),
                    JoiningDate = Convert.ToDateTime(dt.Rows[i]["JoiningDate"]),

                });
        }
                
            return list;
        }
        public Worker Edit(Guid WorkerId)
        {
            Worker list = new Worker();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                /* SqlCommand cmd = new SqlCommand("Select * from mst_worker where WorkerId='"+ WorkerId + "'", con);*/
                SqlCommand cmd = new SqlCommand("Sp_mst_worker_ListById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkerId", WorkerId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();    
            }
            {
                list.WorkerId = new Guid(dt.Rows[0]["WorkerId"].ToString());
                list.Workername = dt.Rows[0]["Workername"].ToString();
                list.Email = dt.Rows[0]["Email"].ToString();
                list.MobileNo = dt.Rows[0]["MobileNo"].ToString();
                list.WorkType = dt.Rows[0]["WorkType"].ToString();
                decimal price_;
                if (dt.Rows[0]["Workprice"].ToString() == null| dt.Rows[0]["Workprice"].ToString() == "")
                {
                    price_ = 0;
                }
                else
                {
                    price_ = Convert.ToDecimal(dt.Rows[0]["Workprice"]);
                }

                list.WorkPrice = price_;
                list.Address = dt.Rows[0]["Address"].ToString();
                list.City = dt.Rows[0]["City"].ToString();
                list.State = dt.Rows[0]["State"].ToString();
                list.Country = dt.Rows[0]["Country"].ToString();
                list.BloodGroup = dt.Rows[0]["BloodGroup"].ToString();
                list.JoiningDate = Convert.ToDateTime(dt.Rows[0]["JoiningDate"]);
            }
            return list;
        }
        public string Add(Worker worker)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Insert into mst_worker " +
                        "(WorkerId, Workername,Email,MobileNo, WorkType ,Workprice, Address,City, State,Country, BloodGroup, JoiningDate) values" +
                        "(@WorkerId,@Workername,@Email,@MobileNo,@WorkType, @Workprice  ,@Address, @City, @State, @Country, @BloodGroup, @JoiningDate)";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_worker_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", worker.WorkerId);
                    cmd.Parameters.AddWithValue("@Workername", worker.Workername);
                    cmd.Parameters.AddWithValue("@Email", worker.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", worker.MobileNo);
                    cmd.Parameters.AddWithValue("@WorkType", worker.WorkType);
                    cmd.Parameters.AddWithValue("@Workprice", worker.WorkPrice);
                    cmd.Parameters.AddWithValue("@Address", worker.Address);
                    cmd.Parameters.AddWithValue("@City", worker.City);
                    cmd.Parameters.AddWithValue("@State", worker.State);
                    cmd.Parameters.AddWithValue("@Country", worker.Country);
                    cmd.Parameters.AddWithValue("@BloodGroup", worker.BloodGroup);
                    cmd.Parameters.AddWithValue("@JoiningDate", worker.JoiningDate);
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
        public string update(Worker worker)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Update mst_worker SET WorkerId=@WorkerId, Workername=@Workername , Email=@Email, MobileNo=@MobileNo,WorkType= @WorkType,@Workprice=Workprice  ,  Address=@Address, City=@City, State=@State,Country=@Country, BloodGroup=@BloodGroup,JoiningDate=@JoiningDate   where WorkerId=@WorkerId";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_worker_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", worker.WorkerId);
                    cmd.Parameters.AddWithValue("@Workername", worker.Workername);
                    cmd.Parameters.AddWithValue("@Email", worker.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", worker.MobileNo);
                    cmd.Parameters.AddWithValue("@WorkType", worker.WorkType);
                    cmd.Parameters.AddWithValue("@Workprice", worker.WorkPrice);
                    cmd.Parameters.AddWithValue("@Address", worker.Address);
                    cmd.Parameters.AddWithValue("@City", worker.City);
                    cmd.Parameters.AddWithValue("@State", worker.State);
                    cmd.Parameters.AddWithValue("@Country", worker.Country);
                    cmd.Parameters.AddWithValue("@BloodGroup", worker.BloodGroup);
                    cmd.Parameters.AddWithValue("@JoiningDate", worker.JoiningDate);
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
        public bool Delete(Guid WorkerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    /*string query = "Delete from mst_worker where WorkerId=@WorkerId";*/
                    SqlCommand cmd = new SqlCommand("Sp_mst_worker_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", WorkerId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            
            catch (Exception )
            {
                return false;
                //throw;
            }
        }

        public decimal Getprice(string WorkType)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                /*SqlCommand cmd = new SqlCommand("Select * from mst_WorkType where TypeName='" + WorkType + "'", con);*/
                SqlCommand cmd = new SqlCommand("Sp_mst_WorkType_GetpriceList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkType", WorkType);
              
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
                         
            decimal WorkPrice = Convert.ToDecimal(dt.Rows[0]["Price"]);
            return WorkPrice;
        }
    }
    
}