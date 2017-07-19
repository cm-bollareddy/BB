using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BVPGenerationHealthCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            PBSLogger.Logger.LogInfo("Start");

            try
            {
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter("PBS.HealthCheck", System.Configuration.ConfigurationManager.ConnectionStrings["TrafficDataConnection"].ToString());
                oSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@pi_HoursOffset", ConfigurationManager.AppSettings["HourOffset"].ToString());
                oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oSqlDataAdapter.Fill(ds);

                if (ds.Tables[0].Rows.Count < 1)
                {
                    PBSLogger.Logger.LogError("TrafficData from BV Sync may NOT be running. There are 0 records in the P_Generation table for the last " + ConfigurationManager.AppSettings["HourOffset"].ToString() + " hours.");
                }
                else
                {
                    PBSLogger.Logger.LogInfo("TrafficData from BV sync is working! We received " + ds.Tables[0].Rows.Count.ToString() + " Record(s))");
                }
            }
            catch(Exception _e)
            {
                PBSLogger.Logger.LogError("There was an error with the BVPGenerationHealthCheck. The ERROR is: " + _e.Message + " The STACK trace is: " + _e.StackTrace);
            }

            PBSLogger.Logger.LogInfo("Finish");
        }
    }
}
