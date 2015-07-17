using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using System.Net.Mail;
using FirebirdSql.Data.FirebirdClient;



namespace WorkflowAnalyzer
{
    class Program
    {
        public static Stopwatch stopwatch;

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            try
            {
                stopwatch = new Stopwatch();

                log.Debug("Start");
                stopwatch.Start();

                BatchBulkCopy();

                processAlertRecords();

                stopwatch.Stop();
                log.Debug("Finish");
            }
            catch(Exception _e)
            {
                log.Error("There was an error: " + _e.Message + " Stack Trace: " + _e.StackTrace);
            }

        }

        public static void BatchBulkCopy()
        {
            processgetMOC_BPMWEBDB();
        }

        public static void processgetMOC_BPMWEBDB()
        {
            DataTable dtInsertRows;
            try
            {
                log.Debug("processgetMOC_BPMWEBDB: Before Get");
                dtInsertRows = getMOC_BPMWEBDBRecords();
                log.Debug("processgetMOC_BPMWEBDB: After Get");

                if (dtInsertRows.Rows.Count > 0)
                {
                    

                    using (SqlConnection oSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FileMoverDBConnectionString"].ToString()))
                    {
                        oSqlConnection.Open();
                        SqlCommand oSqlCommand;
                        oSqlCommand = new SqlCommand("truncate table dbo.BV_AS03_MESSAGEtmp");
                        oSqlCommand.Connection = oSqlConnection;
                        oSqlCommand.ExecuteNonQuery();

                        using (SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["FileMoverDBConnectionString"].ToString(), SqlBulkCopyOptions.KeepIdentity))
                        {
                            sbc.BulkCopyTimeout = 3600;
                            sbc.DestinationTableName = "BV_AS03_MESSAGEtmp";

                            // Number of records to be processed in one go
                            sbc.BatchSize = 10000;

                            // Map the Source Column from DataTabel to the Destination Columns in SQL Server 2005 Person Table
                            // sbc.ColumnMappings.Add("ID", "ID");
                            sbc.ColumnMappings.Add("MESSAGEID", "MESSAGEID");
                            sbc.ColumnMappings.Add("MESSAGETYPECODE", "MESSAGETYPECODE");
                            sbc.ColumnMappings.Add("TRANSCODEPROFILE", "TRANSCODEPROFILE");
                            sbc.ColumnMappings.Add("PROGRAMSLATE", "PROGRAMSLATE");
                            sbc.ColumnMappings.Add("PACKAGEID", "PACKAGEID");
                            sbc.ColumnMappings.Add("PACKAGECODE", "PACKAGECODE");
                            sbc.ColumnMappings.Add("PACKAGETYPE", "PACKAGETYPE");
                            sbc.ColumnMappings.Add("TRANSCODETYPEID", "TRANSCODETYPEID");
                            sbc.ColumnMappings.Add("TRANSCODETYPECODE", "TRANSCODETYPECODE");
                            sbc.ColumnMappings.Add("SOURCEMEDIA", "SOURCEMEDIA");
                            sbc.ColumnMappings.Add("DURATION", "DURATION");
                            sbc.ColumnMappings.Add("SOM", "SOM");
                            sbc.ColumnMappings.Add("CLOSEDCAPTIONS", "CLOSEDCAPTIONS");
                            sbc.ColumnMappings.Add("AFDCODE", "AFDCODE");
                            sbc.ColumnMappings.Add("ISSAP", "ISSAP");
                            sbc.ColumnMappings.Add("ISDVI", "ISDVI");
                            sbc.ColumnMappings.Add("FILENAME", "FILENAME");
                            sbc.ColumnMappings.Add("MEDIATYPE", "MEDIATYPE");
                            sbc.ColumnMappings.Add("MEDIATYPEVIDEO", "MEDIATYPEVIDEO");
                            sbc.ColumnMappings.Add("MEDIATYPEAUDIO", "MEDIATYPEAUDIO");
                            sbc.ColumnMappings.Add("AUDIOTRACKID", "AUDIOTRACKID");
                            sbc.ColumnMappings.Add("TITLE", "TITLE");
                            sbc.ColumnMappings.Add("RATINGVCHIP", "RATINGVCHIP");
                            sbc.ColumnMappings.Add("SOMEOMDURATIONPAIRS", "SOMEOMDURATIONPAIRS");
                            sbc.ColumnMappings.Add("LANGUAGECODE", "LANGUAGECODE");
                            sbc.ColumnMappings.Add("BATON_FILENAME_PASS", "BATON_FILENAME_PASS");
                            sbc.ColumnMappings.Add("BATON_FILENAME_FAIL", "BATON_FILENAME_FAIL");
                            sbc.ColumnMappings.Add("MSG_RECEIVED_DT", "MSG_RECEIVED_DT");
                            sbc.ColumnMappings.Add("PRIMARY_MSG", "PRIMARY_MSG");
                            sbc.ColumnMappings.Add("NRTNextAirDateTime", "NRTNextAirDateTime");
                            sbc.ColumnMappings.Add("RTNextAirDateTime", "RTNextAirDateTime");
                            sbc.ColumnMappings.Add("MSG_DT", "MSG_DT");
                            sbc.ColumnMappings.Add("RAW_XML_MESSAGE", "RAW_XML_MESSAGE");
                            sbc.ColumnMappings.Add("RAW_BVSU_XML_MESSAGE", "RAW_BVSU_XML_MESSAGE");
                            sbc.ColumnMappings.Add("NRTPriorityAirDate", "NRTPriorityAirDate");
                            sbc.ColumnMappings.Add("NIELSEN_SID", "NIELSEN_SID");
                            sbc.ColumnMappings.Add("NIELSEN_TICSTART", "NIELSEN_TICSTART");
                            sbc.ColumnMappings.Add("NIELSEN_TICEND", "NIELSEN_TICEND");
                            sbc.ColumnMappings.Add("NIELSEN_WATERMARKSTARTDATETIME", "NIELSEN_WATERMARKSTARTDATETIME");
                            sbc.ColumnMappings.Add("NIELSEN_WATERMARKMETADATAXML", "NIELSEN_WATERMARKMETADATAXML");
                            sbc.ColumnMappings.Add("ISLIVE", "ISLIVE");
                            sbc.ColumnMappings.Add("ISPACKAGE", "ISPACKAGE");

                            // Finally write to server
                            log.Debug("processgetMOC_BPMWEBDB: Before Insert");
                            sbc.WriteToServer(dtInsertRows);
                            log.Debug("processgetMOC_BPMWEBDB: After Insert");
                            sbc.Close();

                            oSqlConnection.Close();
                        }
                    }
                }
            }
            catch (Exception _e)
            {
                log.Error("Error with processgetMOC_BPMWEBDB: " + _e.Message);
                throw _e;
            }
        }

        public static DataTable getAlarmRecords()
        {
            DataSet ds = new DataSet();

            string sSQL = @"SELECT	c.name AS ClientName,
		                            a.WO_WoNum,
		                            a.WO_EXTID,
		                            a.WO_CLJNO,
		                            a.DATE_CREATED,
		                               CASE
			                              WHEN (LTRIM(b.stat)='0' and ltrim(b.statusex)='0') then 'MTR Impairment'
			                              WHEN (LTRIM(b.stat)='0' and ltrim(b.statusex)='1') then 'In-House Repack'
			                              WHEN LTRIM(b.stat)='1' then 'In Progress'
			                              WHEN LTRIM(b.stat)='2' then 'Cancelled'
			                              WHEN LTRIM(b.stat)='3' then 'Awaiting Scheduling'
			                              WHEN LTRIM(b.stat)='4' then 'New'
			                              WHEN (LTRIM(b.stat)='5' AND LTRIM(b.statUSEX)='0') then 'Completed Successfully'
			                              WHEN (LTRIM(b.stat)='5' AND LTRIM(b.statUSEX)='1') then 'Containerized'
			                              WHEN (LTRIM(b.stat)='5' AND LTRIM(b.statUSEX)='2') then 'Ready to be Reconciled'
			                              WHEN LTRIM(b.stat)='6' then 'Reconciled'
			                              WHEN LTRIM(b.stat)='7' then 'New Booking/Request'
			                              WHEN LTRIM(b.stat)='8' then 'Autocreated'
			                              WHEN LTRIM(b.stat)='9' then 'MTR Resolved'
			                              Else 'Fourth Hold'
		                               END AS WoStatus,
                                    CASE 
			                            WHEN d.DESCRIPT LIKE '%impair%' THEN 'YES'
			                            ELSE 'No'
			                        END AS Impaired
                            FROM	pbsfilemover.dbo.signiant_file_transfer_queue A
                            LEFT JOIN scheduallprod.schedwin.WO b ON b.EXTID = a.wo_extid
                            LEFT JOIN scheduallprod.schedwin.CLNT c ON rtrim(ltrim(c.cl_id)) = rtrim(ltrim(b.cl_id))
                            LEFT JOIN ScheduALLProd.schedwin.TRAIL d ON d.WONUM = a.WO_WoNum
                                AND d.DESCRIPT LIKE '%impair%'
                            where   a.WO_USER23 IN ( 'FLATTEN', 'TRAFFIC_FLATTEN' )
                            AND		NOT EXISTS
	                            (
		                            SELECT	1
		                            FROM	pbsfilemover.dbo.BV_AS03_MESSAGEtmp B
		                            WHERE	b.PACKAGECODE = a.WO_EXTID
	                            )
                            AND a.DATE_CREATED between @ThresholdDate and @ThresholdDateMinuteOffset";


            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, ConfigurationManager.ConnectionStrings["SchedWinDBConnectionString"].ToString());
            oSqlDataAdapter.SelectCommand.Parameters.AddWithValue("ThresholdDate", DateTime.Now.AddDays(-int.Parse(ConfigurationManager.AppSettings["ThresholdDays"].ToString())));
            oSqlDataAdapter.SelectCommand.Parameters.AddWithValue("ThresholdDateMinuteOffset", DateTime.Now.AddMinutes(-int.Parse(ConfigurationManager.AppSettings["ThresholdDateMinuteOffset"].ToString())));

            oSqlDataAdapter.Fill(ds);

            return (ds.Tables[0]);

        }

        public static DataTable getMOC_BPMWEBDBRecords()
        {
            DataSet ds = new DataSet();

            string sSQL = @"SELECT  MESSAGEID ,
                                    MESSAGETYPECODE ,
                                    TRANSCODEPROFILE ,
                                    PROGRAMSLATE ,
                                    PACKAGEID ,
                                    PACKAGECODE ,
                                    PACKAGETYPE ,
                                    TRANSCODETYPEID ,
                                    TRANSCODETYPECODE ,
                                    SOURCEMEDIA ,
                                    DURATION ,
                                    SOM ,
                                    CLOSEDCAPTIONS ,
                                    AFDCODE ,
                                    ISSAP ,
                                    ISDVI ,
                                    FILENAME ,
                                    MEDIATYPE ,
                                    MEDIATYPEVIDEO ,
                                    MEDIATYPEAUDIO ,
                                    AUDIOTRACKID ,
                                    TITLE ,
                                    RATINGVCHIP ,
                                    SOMEOMDURATIONPAIRS ,
                                    LANGUAGECODE ,
                                    BATON_FILENAME_PASS ,
                                    BATON_FILENAME_FAIL ,
                                    MSG_RECEIVED_DT ,
                                    PRIMARY_MSG ,
                                    NRTNextAirDateTime ,
                                    RTNextAirDateTime ,
                                    MSG_DT ,
                                    RAW_XML_MESSAGE ,
                                    RAW_BVSU_XML_MESSAGE ,
                                    NRTPriorityAirDate ,
                                    NIELSEN_SID ,
                                    NIELSEN_TICSTART ,
                                    NIELSEN_TICEND ,
                                    NIELSEN_WATERMARKSTARTDATETIME ,
                                    NIELSEN_WATERMARKMETADATAXML ,
                                    ISLIVE ,
                                    ISPACKAGE
                            FROM    dbo.BV_AS03_MESSAGE";


            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, ConfigurationManager.ConnectionStrings["MOCBPMWEBDBConnectionString"].ToString());

            oSqlDataAdapter.Fill(ds);

            return (ds.Tables[0]);

        }

        public static string getPackageStatus(string sPackage)
        {
            string sStatus = "";
            DataSet ds = new DataSet();

            string sSQL = @"select
                                ver.ver_packagehouse
                                ,sl1.slu_desc as PBSMediaStatus
                                ,sl2.slu_desc as PBSPackageStatus
                                from    version ver
                                join    asset               ass on (ass.ass_id = ver.ver_ass_id)
                                join    versiontype         vet on vet.vet_id = ver.ver_vet_id
                                left    join syslookup      sl1 on sl1.slu_id = ver.ver_slu_id_pbsmediastatus
                                left    join syslookup      sl2 on sl2.slu_id = ver.ver_slu_id_packagestatus
                                where   ver.ver_packagehouse = '" + sPackage + "'";

            FbDataAdapter oFbDataAdapter = new FbDataAdapter(sSQL, ConfigurationManager.ConnectionStrings["BroadViewDBConnectionString"].ToString());

            oFbDataAdapter.Fill(ds);


            if (ds.Tables[0].Rows.Count.Equals(1))
            {
                sStatus = ds.Tables[0].Rows[0]["PBSMediaStatus"].ToString();
            }

            return sStatus;
        }

        public static void processAlertRecords()
        {
            try
            {
                log.Debug("Before getAlarmRecords Get");
                DataTable dtRecords = getAlarmRecords();
                log.Debug("After getAlarmRecords Get");

                log.Debug("We got " + dtRecords.Rows.Count.ToString() + " AlarmRecords");

                StringBuilder sb = new StringBuilder();

                if (dtRecords.Rows.Count > 0)
                {
                    sb.Append("There are issue with certain workflow items<br><br>");
                    sb.Append("With a THRESHOLD of " + ConfigurationManager.AppSettings["ThresholdDays"].ToString() + " days, the following work orders don't have records in MOC_BPMWEBDB: BV_AS03_MESSAGE<br><br>");
                    sb.Append("<table border=1><tr><td>WO Num</td><td>P#</td><td>NOLA</td><td>Date Completed</td><td>Package Status</td><td>WO Status</td><td>ClientName</td><td>Impaired?</td></tr>");
                    for (int i = 0; i < dtRecords.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + dtRecords.Rows[i]["WO_WoNum"].ToString() + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["WO_EXTID"].ToString() + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["WO_CLJNO"].ToString() + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["Date_Created"].ToString() + "</td>");
                        sb.Append("<td>" + getPackageStatus(dtRecords.Rows[i]["WO_EXTID"].ToString()) + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["WoStatus"].ToString() + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["ClientName"].ToString() + "</td>");
                        sb.Append("<td>" + dtRecords.Rows[i]["Impaired"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");

                    sb.Append("<br><br>Thank you.");

                    log.Debug("Before Send Email");
                    sendNotification(sb.ToString());
                    log.Debug("After Send Email");
                }
            }
            catch (Exception _e)
            {
                log.Error("There is an error with the transcode workflow. The error is: " + _e.Message + " The Stack Trace is: " + _e.StackTrace);
            }


        }

        public static void sendNotification(string sBody)
        {
            MailMessage mail = new MailMessage();

            string[] strEamils = ConfigurationManager.AppSettings["EmailTo"].ToString().Split(',');
            foreach (var item in strEamils)
            {
                mail.To.Add(item);
            }

            mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"].ToString());
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = ConfigurationManager.AppSettings["smtpServer"].ToString();
            mail.Subject = ConfigurationManager.AppSettings["Subject"].ToString();
            mail.Body = sBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
    }
}
