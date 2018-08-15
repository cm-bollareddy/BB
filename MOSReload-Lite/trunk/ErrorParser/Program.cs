using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ErrorParser
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ytseytlin\Desktop\0813main.log");

            // Display the file contents by using a foreach loop.
            string sRecord = "";
            string sMessage = "";
            bool bNewRecord = true;
            DateTime? dRecordDate = new DateTime(1900, 1, 1);
            string WarningType = "";


            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].IndexOf('[') == 0)
                {
                    bNewRecord = true;
                    dRecordDate = DateTime.Parse(lines[i].Substring(1, 23));
                    WarningType = lines[i].Substring(27, lines[i].IndexOf(']', 27) - 27);

                    sMessage = lines[i].Substring(lines[i].IndexOf("default -"));

                    if (i + 1 < lines.Count())
                    {
                        if (lines[i + 1].IndexOf('[') == 0)
                        {
                            using (var Context = new RLEntities())
                            {
                                LogTracker oLogTracker = new LogTracker();
                                oLogTracker.DateCreated = dRecordDate;
                                oLogTracker.MessageType = WarningType;

                                if (WarningType.ToUpper() == "ERROR")
                                {
                                    if (sMessage.LastIndexOf("{\"message\"") > 0)
                                    {
                                        oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("{\"message\"") - 10).Trim();
                                        oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("{\"message\"") - 10).Trim();
                                    }
                                    else
                                    {
                                        if (sMessage.LastIndexOf("with error retry 0 with error Error:") > 0)
                                        {
                                            oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("with error Error:") - 30).Trim();
                                            oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("with error Error:") + 11).Trim();
                                        }
                                        else
                                        {
                                            oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    oLogTracker.Message = sMessage.Replace("default -", "").Trim();
                                }

                                Context.LogTrackers.Add(oLogTracker);

                                Context.SaveChanges();

                            }

                            //Reaady To insert new record
                            sMessage = "";
                            dRecordDate = new DateTime(1900, 1, 1);
                            WarningType = "";

                        }
                    }
                    else
                    {
                        using (var Context = new RLEntities())
                        {
                            LogTracker oLogTracker = new LogTracker();
                            oLogTracker.DateCreated = dRecordDate;
                            oLogTracker.MessageType = WarningType;


                            if (WarningType.ToUpper() == "ERROR")
                            {
                                if (sMessage.LastIndexOf("{\"message\"") > 0)
                                {
                                    oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("{\"message\"") - 10).Trim();
                                    oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("{\"message\"") - 10).Trim();
                                }
                                else
                                {
                                    if (sMessage.LastIndexOf("with error retry 0 with error Error:") > 0)
                                    {
                                        oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("with error Error:") - 30).Trim();
                                        oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("with error Error:") + 11).Trim();
                                    }
                                    else
                                    {
                                        oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim();
                                    }
                                }
                            }
                            else
                            {
                                oLogTracker.Message = sMessage.Replace("default -", "").Trim();
                            }

                            Context.LogTrackers.Add(oLogTracker);

                            Context.SaveChanges();

                        }

                        //Reaady To insert new record
                        sMessage = "";
                        dRecordDate = new DateTime(1900, 1, 1);
                        WarningType = "";
                    }
                }
                else
                {
                    bNewRecord = false;

                    sMessage = sMessage.Trim() + "\r\n" +  lines[i].Trim();

                    if (i + 1 < lines.Count())
                    {
                        if (lines[i + 1].IndexOf('[') == 0)
                        {

                            using (var Context = new RLEntities())
                            {
                                LogTracker oLogTracker = new LogTracker();
                                oLogTracker.DateCreated = dRecordDate;
                                oLogTracker.MessageType = WarningType;

                                if (WarningType.ToUpper() == "ERROR")
                                {
                                    if (sMessage.LastIndexOf("{\"message\"") > 0)
                                    {
                                        oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("{\"message\"") - 10).Trim();
                                        oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("{\"message\"") - 10).Trim();
                                    }
                                    else
                                    {
                                        if (sMessage.LastIndexOf("with error retry 0 with error Error:") > 0)
                                        {
                                            oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("with error Error:") - 30).Trim();
                                            oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("with error Error:") + 11).Trim();
                                        }
                                        else
                                        {
                                            oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    oLogTracker.Message = sMessage.Replace("default -", "").Trim();
                                }

                                Context.LogTrackers.Add(oLogTracker);

                                Context.SaveChanges();

                            }
                            //Reaady To insert new record
                            sMessage = "";
                            dRecordDate = dRecordDate = new DateTime(1900, 1, 1);
                            WarningType = "";

                        }
                    }
                    else
                    {
                        using (var Context = new RLEntities())
                        {
                            LogTracker oLogTracker = new LogTracker();
                            oLogTracker.DateCreated = dRecordDate;
                            oLogTracker.MessageType = WarningType;

                            if (WarningType.ToUpper() == "ERROR")
                            {
                                if (sMessage.LastIndexOf("{\"message\"") > 0)
                                {
                                    oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("{\"message\"") - 10);
                                    oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("{\"message\"") -10);
                                }
                                else
                                {
                                        if (sMessage.LastIndexOf("with error retry 0 with error Error:") > 0)
                                        {
                                            oLogTracker.Message = sMessage.Replace("default -", "").Trim().Substring(0, sMessage.IndexOf("with error Error:") - 30).Trim();
                                            oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim().Substring(sMessage.IndexOf("with error Error:") + 10).Trim();
                                        }
                                        else
                                        {
                                             oLogTracker.ErrorMessage = sMessage.Replace("default -", "").Trim();
                                        }                                }
                            }
                            else
                            {
                                oLogTracker.Message = sMessage.Replace("default -", "").Trim();
                            }

                            Context.LogTrackers.Add(oLogTracker);

                            Context.SaveChanges();

                        }
                        //Reaady To insert new record
                        sMessage = "";
                        dRecordDate = dRecordDate = new DateTime(1900, 1, 1);
                        WarningType = "";
                    }
                }
            }
        }
    }
}
