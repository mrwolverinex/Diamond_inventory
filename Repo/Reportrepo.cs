using DiamondInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiamondInventory.Repo
{
    public class Reportrepo
    {


        string strConString = @"Data Source=sql5101.site4now.net;Initial Catalog=db_a6b32d_diamondinventory;User ID=db_a6b32d_diamondinventory_admin;Password=Diamond@123";

        public List<ReportVM> GetReportVM(string StartDate, string EndDate)
        {
            List<ReportVM> list = new List<ReportVM>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_report_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", (StartDate));
                cmd.Parameters.AddWithValue("@EndDate", (EndDate));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
                list.Add(new ReportVM()
                {

                    qty = dt.Rows[i]["qty"].ToString(),
                    Work_Date = dt.Rows[i]["Work_Date"].ToString(),
                    WorkerName = dt.Rows[i]["Workername"].ToString(),
                    Workprice = dt.Rows[i]["Workprice"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    MobileNo = dt.Rows[i]["MobileNo"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    BloodGroup = dt.Rows[i]["BloodGroup"].ToString(),
                    WorkType = dt.Rows[i]["worktype"].ToString(),
                    price = dt.Rows[i]["orignalprice"].ToString()

                });
            return list;
        }

    }
}