using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace BVPGenerationHealthCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList oArrayList = new ArrayList();

            List<TrafficData> oTrafficDataList = new List<TrafficData>();

            PBSLogger.Logger.LogInfo("Start");

            try
            {

                System.Collections.Specialized.NameValueCollection nvsh = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection("SQLConnections");
                string sHourOffsetKey = "";
                for (int i = 0; i < nvsh.Count; i++)
                {
                    DataSet ds = new DataSet();

                    sHourOffsetKey = nvsh.Keys[i] + "HourOffset";
                    
                    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter("PBS.HealthCheck", nvsh[i].ToString());
                    oSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@pi_HoursOffset", ConfigurationManager.AppSettings[sHourOffsetKey].ToString());
                    oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    oSqlDataAdapter.Fill(ds);

                    using (EnterpriseAppsEntities context = new EnterpriseAppsEntities())
                    {
                        TrafficData oTrafficData = new TrafficData();
                        oTrafficData.DBServer = oSqlDataAdapter.SelectCommand.Connection.DataSource;
                        oTrafficData.DataBaseName = oSqlDataAdapter.SelectCommand.Connection.Database;
                        oTrafficData.TableName = "P_Generation";
                        oTrafficData.RecordCounts = ds.Tables[0].Rows.Count;
                        oTrafficData.LastChecked = DateTime.Now;
                        oTrafficData.HourOFfset = int.Parse(ConfigurationManager.AppSettings[sHourOffsetKey].ToString());

                        context.TrafficDatas.Add(oTrafficData);
                        context.SaveChanges();

                        oTrafficDataList.Add(oTrafficData);

                    }
                }

                var vRec = oTrafficDataList.Where(x => x.RecordCounts == 0).ToList();

                string sMessage = "";
                if (vRec.Count > 0)
                {
                    sMessage = "The BV/TrafficData SYNC is not working in all environments.\r\n\r\n";
                    foreach (var item in vRec)
                    {
                        sMessage = sMessage + "We did not receive any data for: \r\nDatabase Server:" + item.DBServer + "\r\nDatabase: " + item.DataBaseName + " \r\nTable: " + item.TableName + "\r\nRecord Count: " + item.RecordCounts + "\r\nThe timespan was minus " + item.HourOFfset + " hours.\r\n\r\n";
                    }


                    PBSLogger.Logger.LogError(sMessage);
                }
                else
                {
                    sMessage = "TrafficData from BV sync is working!.\r\n\r\n";

                    foreach (var item in oTrafficDataList)
                    {
                        sMessage = sMessage + "We RECEIVED data for: \r\nDatabase Server:" + item.DBServer + "\r\nDatabase: " + item.DataBaseName + " \r\nTable: " + item.TableName + "\r\nRecord Count: " + item.RecordCounts + "\r\nThe timespan was minus " + item.HourOFfset + " hours.\r\n\r\n";
                    }

                    PBSLogger.Logger.LogInfo(sMessage);

                }

                vRec = oTrafficDataList.Where(x => x.DataBaseName != "TrafficData-SystemTest").ToList();
                if (vRec.Count == 2)
                {
                    if (vRec[0].RecordCounts != vRec[1].RecordCounts)
                    {
                        sMessage = "The Traffic Data on Database TrafficData on DB19 and DB19-UAT is out of sync! \r\n\r\n";
                        sMessage = sMessage + "Data on\r\n" + vRec[0].DBServer + "\r\n" + vRec[0].DataBaseName + "\r\n" + vRec[0].RecordCounts + "\r\n" + vRec[0].HourOFfset + "\r\n\r\n" + vRec[1].DBServer + "\r\n" + vRec[1].DataBaseName + "\r\n" + vRec[1].RecordCounts + "\r\n" + vRec[1].HourOFfset;

                        PBSLogger.Logger.LogError(sMessage);
                    }
                    else
                    {
                        sMessage = "The Traffic Data on Database TrafficData on DB19 and DB19-UAT is IN sync! \r\n\r\n";
                        sMessage = sMessage + "Data on\r\nDB Server: " + vRec[0].DBServer + "\r\nDatabase: " + vRec[0].DataBaseName + "\r\nRecord Count: " + vRec[0].RecordCounts + "\r\nHour Offset: " + vRec[0].HourOFfset + "\r\n\r\nData on\r\nDB Server: " + vRec[1].DBServer + "\r\nDatabase: " + vRec[1].DataBaseName + "\r\nRecord Count: " + vRec[1].RecordCounts + "\r\nHour Offset: " + vRec[1].HourOFfset;

                        PBSLogger.Logger.LogInfo(sMessage);

                    }
                }



            }
            catch(Exception _e)
            {
                PBSLogger.Logger.LogError("There was an error with the BVPGenerationHealthCheck. The ERROR is: " + _e.Message + " The STACK trace is: " + _e.StackTrace);
            }

            PBSLogger.Logger.LogInfo("Finish");
        }
    }

    public class Errors
    {
        public Errors()
        {

        }

        public string  DBServer { get; set; }
        public string DBName { get; set; }

    }
}
