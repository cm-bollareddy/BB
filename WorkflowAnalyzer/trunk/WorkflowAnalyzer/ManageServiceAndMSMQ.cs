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
using System.Messaging;
namespace WorkflowAnalyzer
{
    class ManageServiceAndMSMQ
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string ServiceStatus { get; set; }
        public string MSMQStatus { get; set; }
        public void checkServiceAndMSMQStatus()
        {
           this.CheckServiceStatus();
            this.CheckMSMQStatus();
           
           
        }//endofemthod

        private void CheckServiceStatus()
        {
            var msg = "Service Status: ";
            ServiceController sc = new ServiceController();
            sc.MachineName = ConfigurationManager.AppSettings["NRTServiceMachine"].ToString();
            sc.ServiceName = ConfigurationManager.AppSettings["NRTServiceName"].ToString();
            try
            {
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        msg += "Running";
                        break;
                    case ServiceControllerStatus.Stopped:
                        msg += "Stopped";
                        break;
                    case ServiceControllerStatus.Paused:
                        msg += "Paused";
                        break;
                    case ServiceControllerStatus.StopPending:
                        msg += "Stopping";
                        break;
                    case ServiceControllerStatus.StartPending:
                        msg += "Starting";
                        break;
                    default:
                        msg += "Status Changing";
                        break;
                }

            }
            catch (Exception _e)
            {
                log.Error("There was an error: " + _e.Message + " Stack Trace: " + _e.StackTrace);
            }

            ServiceStatus = msg;
        }

        private void CheckMSMQStatus() {
           // string queueName = "FormatName:DIRECT=OS:bpmweb-dev\\private$\\tempenterpriseapps";
            string queueName = ConfigurationManager.AppSettings["NRTQueuePath"].ToString();
           //string prodQueueName = "FormatName:DIRECT=OS:pbva3\\private$\\nrtmsmq_bvtobpm";
            try
            { 
                  MessageQueue remoteQ = new MessageQueue(queueName);
                  var allMessages = remoteQ.GetAllMessages();
                  int count = allMessages.Count();
                  MSMQStatus = "The Queue Name: "+queueName+ " has " + System.Convert.ToString(count) + " Messages.";        
            }
            catch (Exception e)
            {
                
                throw e;
            }
           

        }
    }//endofclass
}
