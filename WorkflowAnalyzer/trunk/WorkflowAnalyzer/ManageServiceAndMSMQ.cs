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
using System.Management.Automation;
using System.ServiceProcess;
namespace WorkflowAnalyzer
{
    class ManageServiceAndMSMQ
    {
        public string checkServiceAndMSMQStatus()
        {
                      var msg = "";
            ServiceController sc = new ServiceController();
            sc.MachineName = ConfigurationManager.AppSettings["NRTServiceMachine"].ToString();
            sc.ServiceName = ConfigurationManager.AppSettings["NRTServiceName"].ToString();
            try
            {
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        msg = "Running";
                        break;
                    case ServiceControllerStatus.Stopped:
                        msg = "Stopped";
                        break;
                    case ServiceControllerStatus.Paused:
                        msg = "Paused";
                        break;
                    case ServiceControllerStatus.StopPending:
                        msg = "Stopping";
                        break;
                    case ServiceControllerStatus.StartPending:
                        msg = "Starting";
                        break;
                    default:
                        msg = "Status Changing";
                        break;
                }

                return msg;
            }
            catch (Exception e)
            {
                
                throw e;
            }
            

   
        }//endofemthod

    }//endofclass
}
