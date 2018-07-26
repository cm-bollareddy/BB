function New-Logger
{
#Write-Host "BEGIN: New-Logger"
<#
.SYNOPSIS
      This function creates a log4net logger instance already configured
.OUTPUTS
      The log4net logger instance ready to be used
#>
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