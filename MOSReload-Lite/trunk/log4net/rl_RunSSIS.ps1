
<#
[void][Reflection.Assembly]::LoadFile("E:\PBS Projects\SSIS\MOSReload-RLLight\log4net\log4net.dll");
[log4net.LogManager]::ResetConfiguration();
 
#Example of File Appender initialization
$FileApndr = new-object log4net.Appender.FileAppender(([log4net.Layout.ILayout](new-object log4net.Layout.PatternLayout('[%date{yyyy-MM-dd HH:mm:ss.fff} (%utcdate{yyyy-MM-dd HH:mm:ss.fff})] [%level] [%message]%n')),('E:\logs\LogOutputInConsoleAndFile.log'),$True));
$FileApndr.Threshold = [log4net.Core.Level]::All;
[log4net.Config.BasicConfigurator]::Configure($FileApndr);
 
#Example of Colored Console Appender initialization
$ColConsApndr = new-object log4net.Appender.ColoredConsoleAppender(([log4net.Layout.ILayout](new-object log4net.Layout.PatternLayout('[%date{yyyy-MM-dd HH:mm:ss.fff}] %message%n'))));
$ColConsApndrDebugCollorScheme=new-object log4net.Appender.ColoredConsoleAppender+LevelColors; $ColConsApndrDebugCollorScheme.Level=[log4net.Core.Level]::Debug; $ColConsApndrDebugCollorScheme.ForeColor=[log4net.Appender.ColoredConsoleAppender+Colors]::Green;
$ColConsApndr.AddMapping($ColConsApndrDebugCollorScheme);
$ColConsApndrInfoCollorScheme=new-object log4net.Appender.ColoredConsoleAppender+LevelColors; $ColConsApndrInfoCollorScheme.level=[log4net.Core.Level]::Info; $ColConsApndrInfoCollorScheme.ForeColor=[log4net.Appender.ColoredConsoleAppender+Colors]::White;
$ColConsApndr.AddMapping($ColConsApndrInfoCollorScheme);
$ColConsApndrWarnCollorScheme=new-object log4net.Appender.ColoredConsoleAppender+LevelColors; $ColConsApndrWarnCollorScheme.level=[log4net.Core.Level]::Warn; $ColConsApndrWarnCollorScheme.ForeColor=[log4net.Appender.ColoredConsoleAppender+Colors]::Yellow;
$ColConsApndr.AddMapping($ColConsApndrWarnCollorScheme);
$ColConsApndrErrorCollorScheme=new-object log4net.Appender.ColoredConsoleAppender+LevelColors; $ColConsApndrErrorCollorScheme.level=[log4net.Core.Level]::Error; $ColConsApndrErrorCollorScheme.ForeColor=[log4net.Appender.ColoredConsoleAppender+Colors]::Red;
$ColConsApndr.AddMapping($ColConsApndrErrorCollorScheme);
$ColConsApndrFatalCollorScheme=new-object log4net.Appender.ColoredConsoleAppender+LevelColors; $ColConsApndrFatalCollorScheme.level=[log4net.Core.Level]::Fatal; $ColConsApndrFatalCollorScheme.ForeColor=([log4net.Appender.ColoredConsoleAppender+Colors]::HighIntensity -bxor [log4net.Appender.ColoredConsoleAppender+Colors]::Red);
$ColConsApndr.AddMapping($ColConsApndrFatalCollorScheme);
$ColConsApndr.ActivateOptions();
$ColConsApndr.Threshold = [log4net.Core.Level]::All;
[log4net.Config.BasicConfigurator]::Configure($ColConsApndr);
 
$Log=[log4net.LogManager]::GetLogger("root");
 
#Debug
#Info
#Warn
#Error
#Fatal
 
$Log.Debug('Debug message.');
$Log.Info('Info message.');
$Log.Warn('Warn message.');
$Log.Error('Error message.');
$Log.Fatal('Fatal message.');
 
[log4net.LogManager]::ResetConfiguration();

#>
$log = New-Logger -Configuration "E:\PBS Projects\SSIS\MOSReload-RLLight\log4net\log4net.config" -DLL "E:\PBS Projects\SSIS\MOSReload-RLLight\log4net\log4net.dll"
$log.InfoFormat("Start");


Add-Type -AssemblyName "Microsoft.SqlServer.ManagedDTS, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" 
$ssisApplication = New-Object "Microsoft.SqlServer.Dts.Runtime.Application" 
$ssisPackagePath = "E:\PBS Projects\SSIS\MOSReload-RLLight\MOSReload\RightslineLoad.dtsx" 
$ssisPackage = $ssisApplication.LoadPackage($ssisPackagePath,$null) 

$log.InfoFormat("Running Package: " + $ssisPackagePath )
 


$log.InfoFormat("Before Package Start")

$result = $ssisPackage.Execute();

$log.InfoFormat("After Package Complete")
$log.InfoFormat("Execution Status:" + $ssisPackage.ExecutionStatus)


$Q = "select distinct Series.*,RightsLine_Season.*, RightsLine_Episode_ParentSeason.*, Deal.*, RightsLine_Funders.* from   RightsLine_Series Series join   xref_SeriesToSeason  on Series.Item_BV_ID = xref_SeriesToSeason.ParentID join   RightsLine_Season on RightsLine_Season.Item_BV_ID = xref_SeriesToSeason.ChildID join   xref_SeasonToEpisode on xref_SeasonToEpisode.ParentID = xref_SeriesToSeason.ChildID join   xref_DealToEpisode  on xref_DealToEpisode.ChildID = xref_SeasonToEpisode.ass_id join   RightsLine_Episode_ParentSeason  on RightsLine_Episode_ParentSeason.Item_BV_ID = xref_SeasonToEpisode.ass_id join   ( select q.* from ( select  [contract_execution_date] ,contract_effective_date ,[entity_status] ,[financial_notes] ,Item_BV_ID as Item_BV_ID  ,[rights_and_restrictions_notes] ,[underwriting_notes] ,[WorkFlowStatus] ,[entity_title] ,[pbs_can_secure_underwriting] ,[standard_terms__conditions] ,[executed_status] ,NULL as [producer_can_secure_underwriting] ,NULL as [producerlicensor_shares_revenue_back_to_cpb] ,NULL as [programming_service] ,NULL as [total_budget] ,NULL as [cpb_funding] ,NULL as [fee] ,NULL as [expiration_date] from RightsLine_Deal_PBSPAA1 union select [contract_execution_date] ,[effective_date] ,[entity_status] ,[financial_notes] ,Item_BV_ID as Item_BV_ID  ,[rights_and_restrictions_notes] ,[underwriting_notes] ,[WorkFlowStatus] ,[entity_title] ,NULL as [pbs_can_secure_underwriting] ,NULL as [standard_terms_conditions] ,NULL as [executed_status] ,[producer_can_secure_underwriting] ,[producerlicensor_shares_revenue_back_to_cpb] ,[programming_service] ,[total_budget] ,[cpb_funding] ,[fee] ,[expiration_date] from RightsLine_Deal_ProductionAndAcquisition ) q ) as Deal on Deal.Item_BV_ID = xref_DealToEpisode.ParentID join xref_DealToUnderwriter on xref_DealToUnderwriter.ParentID = Deal.Item_BV_ID join   RightsLine_Funders on RightsLine_Funders.Item_BV_ID = xref_DealToUnderwriter.ChildID     and RightsLine_Funders.Dea_ID = xref_DealToUnderwriter.ParentID '"
$pwd = "NRu`$cr3s"
$ConnectionString = "Password=$pwd;Persist Security Info=True;User ID=TrafficDataReader; Initial Catalog = RightsLineETL-Light; Data Source=DB19-UAT;"
$File = "E:\data.csv"

$log.InfoFormat("Starting to generate CSV File")
$log.InfoFormat("CSV File to be generated: " + $File)
$log.InfoFormat("Query to be run:")
$log.InfoFormat($Q)

$log.InfoFormat("Before creating CSV file with filename: " + $File)
Export-TableToCsv $ConnectionString $File $Q


Send-MailMessage -from "no-reply-RightLine-PBS@pbs.org" `
                       -to "ytseytlin@pbs.org" `
                       -subject "RightsLine Data" `
                       -body "Attached Is the Spreadsheet for the RightsLine data confimration" `
                       -Attachment "E:\data.csv" -smtpServer smtp.pbs.org


$log.InfoFormat("CSV file " + $File + " generated")
$log.InfoFormat("Finish");

function Export-TableToCsv 
{
  Param
  (
  # An opened connection to a SQL database
  [Parameter(Mandatory = $true)]
  [String] $ConnectionString,
  
  # The folder where the file should be copied
  [Parameter(Mandatory = $true)]
  [String] $TargetPath,
  
  # The name of the database table to export
  [Parameter(Mandatory = $true)]
  [String] $in_QUERY
  )
   
  $ofs = ','
  $query = $in_QUERY
  
  $connection =  New-Object System.Data.SqlClient.SqlConnection
  try 
  {
    $connection.ConnectionString = $connectionString
    
    $command = New-Object System.Data.SqlClient.SqlCommand
    $command.CommandText = $query
    $command.Connection = $Connection
    
    $SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter
    $SqlAdapter.SelectCommand = $command
    $DataSet = New-Object System.Data.DataSet
    $SqlAdapter.Fill($DataSet)
    
    $DataSet.Tables[0] | Export-Csv "$TargetPath" -NoTypeInformation -Encoding UTF8
  }
  finally
  {
    $connection.Dispose()
  }
}


function New-Logger
{

     [CmdletBinding()]
     Param
     (
          [string]
          # Path of the configuration file of log4net
          $Configuration,
          [Alias("Dll")]
          [string]
          # Log4net dll path
          $log4netDllPath
     )
     Write-Verbose "[New-Logger] Logger initialization"
     $log4netDllPath = Resolve-Path $log4netDllPath -ErrorAction SilentlyContinue -ErrorVariable Err
     if ($Err)
     {
          throw "Log4net library cannot be found on the path $log4netDllPath"
     }
     else
     {
          Write-Verbose "[New-Logger] Log4net dll path is : '$log4netDllPath'"
          [Reflection.Assembly]::LoadFrom($log4netDllPath) | Out-Null
          # Log4net configuration loading
          $log4netConfigFilePath = Resolve-Path $Configuration -ErrorAction SilentlyContinue -ErrorVariable Err
          if ($Err)
          {
               throw "Log4Net configuration file $Configuration cannot be found"
          }
          else
          {
               Write-Verbose "[New-Logger] Log4net configuration file is '$log4netConfigFilePath' "
               $FileInfo = New-Object System.IO.FileInfo($log4netConfigFilePath)
               [log4net.Config.XmlConfigurator]::Configure($FileInfo)
               $script:MyCommonLogger = [log4net.LogManager]::GetLogger("root")
               Write-Verbose "[New-Logger] Logger is configured"
               return $MyCommonLogger
          }
     }
}