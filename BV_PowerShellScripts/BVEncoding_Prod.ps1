<#

.Synopsis
Script change encoding and add Byte Order Mark (BOM) and copies the message from a temp queue to NRTMSMQ_BPMtoBV.
.Description
Script reads xml message from source Queue ($sourcequeueName), replaces the utf-16 header with utf-16 and adds a BOM
and writes the xml message to destination Queue ($destqueueName).
SetUpTest(): Reads a xml file from the disk and writes a utf16 encoded message to temp queue
WriteToDestination(): Reads Messages from temp queue and writes them to the destination queue with UTF16-encoding.
#>
Param([parameter(Mandatory=$true,

       HelpMessage="Path to file")] 

       $path)
#If log file does not exit create it.       
if (!(Test-Path $Path)) { 
      Write-Verbose "Creating $Path." 
       $NewLogFile = New-Item $Path -Force -ItemType File 
     } 
[Reflection.Assembly]::LoadWithPartialName("System.IO");
[Reflection.Assembly]::LoadWithPartialName("System.Text");
[Reflection.Assembly]::LoadWithPartialName("System.Messaging");
#[System.AppDomain]::CurrentDomain.GetAssemblies();

$msmq = [System.Messaging.MessageQueue]
$currentDate = Get-Date -format G

Write-Output "$(Get-Date -Format "yyyy-MM-dd HH:mm:ss") INFO: Script Started: **********" | Out-File -FilePath $Path -Append 

#********************************************************************
 function global:WriteToDestinationTrans{
     $tempqueueREAD = New-Object System.Messaging.MessageQueue $sourcequeueName;
     $tempqueueTrans = New-Object System.Messaging.MessageQueueTransaction;  
     try{
     #$tempqueueTrans.Begin();
     $queue = New-Object System.Messaging.MessageQueue $destqueueName;
     $msgs = $tempqueueREAD.GetAllMessages(); 
     
     if ( $msgs.Count -ge 1  )
     {
         foreach ( $msg in $msgs )
    {
      write-output "Reading messages" | Out-File -FilePath $Path -Append 
      $tempqueueTrans.Begin();
     $msg = $tempqueueREAD.Receive(); 
    
        if($msg.BodyStream.Length -gt 0)
        {    
            [System.Text.UnicodeEncoding] $utf16 = New-Object System.Text.UnicodeEncoding;
            [System.IO.StreamReader] $sr = New-Object System.IO.StreamReader($msg.BodyStream,$utf16);
            
            [System.IO.MemoryStream] $destStream = New-Object System.IO.MemoryStream;
            [System.IO.StreamWriter] $sw = New-Object System.IO.StreamWriter($destStream,$utf16);
            $xml = $sr.ReadToEnd();
            $sw.Write($xml);
            $sw.Flush();
            #write-output $xml;   
            #for each message  write to the destination queue with utf16 encoding.
            #[System.IO.MemoryStream] $ms = new-object System.IO.MemoryStream; 
            [System.Text.UnicodeEncoding] $utf16 = New-Object System.Text.UnicodeEncoding;
            [System.Messaging.Message] $destmsg = New-Object System.Messaging.Message;
            #$destmsg.BodyStream = $msg.BodyStream;
            $destmsg.BodyStream = $destStream;
            $queue.Send($destmsg,$msg.Label,$tempqueueTrans);
            $sw.Close();
            Write-Output "$(Get-Date -Format "yyyy-MM-dd HH:mm:ss") INFO: Successfully Wrote the message to Destination Queue." | Out-File -FilePath $Path -Append 
        }   
        $tempqueueTrans.Commit();   
     }
    }

 
    }catch{
        write-Output "Exception Occured in WriteToDestinationTrans Function." | Out-File -FilePath $Path -Append 
        write-Output  $_.Exception|format-list -force | Out-File -FilePath $Path -Append 
        $tempqueueTrans.Abort();
    }

   }#endofmethod.



#********************************************************************


$sourcequeueName =".\Private$\tempEnterpriseApps"# Original message will be sent to the temp queue.
#$sourcequeueName =".\private$\tempEnterpriseAppsNT"
$destqueueName =".\Private$\nrtmsmq_bpmtobv"#After changing the header message will be sent to NRTMSMQ_BPMtoBV queue.
try{
if([string]::IsNullOrEmpty($sourcequeueName)){
    throw "Must Set Source Queue Name";
    }
    if([string]::IsNullOrEmpty($destqueueName)){
    throw "Must Set Destination Queue Name";
    }
   
    If ($msmq::Exists($sourcequeueName))
    {
      
     Write-Output  ($sourcequeueName + " queue exists") | Out-File -FilePath $Path -Append 

     
    }else{
        throw $sourcequeueName + ": queue does not exist";
    }
    If ($msmq::Exists($sourcequeueName))
    {
      
         Write-Output  ($destqueueName + " queue exists") | Out-File -FilePath $Path -Append 
    }else{
        throw $destqueueName + ": queue does not exist";
    }
   



#Set up Test code only for development environment
#ReadTempQueue;
#ReadTempQueueTrans;
#Read Messages from Temp Queue and send them to destination queue.
#WriteToDestination;
WriteToDestinationTrans;

}catch{
        write-Output "Caught an exception:" | Out-File -FilePath $Path -Append 
        write-Output  $_.Exception|format-list -force | Out-File -FilePath $Path -Append 
    }finally{

        Write-Output "$(Get-Date -Format "yyyy-MM-dd HH:mm:ss") INFO: Script Ended: ********** `r`n" | Out-File -FilePath $Path -Append 

    }


    function global:WriteToDestination{
     $tempqueueREAD = New-Object System.Messaging.MessageQueue $sourcequeueName;
   


     $queue = New-Object System.Messaging.MessageQueue $destqueueName;
     $msgs = $tempqueueREAD.GetAllMessages(); 
     
    foreach ( $msg in $msgs )
    {
    
        if($msg.BodyStream.Length -gt 0)
        {
           
            #for each message  write to the destination queue with utf16 encoding.
            #[System.IO.MemoryStream] $ms = new-object System.IO.MemoryStream; 
            [System.Text.UnicodeEncoding] $utf16 = New-Object System.Text.UnicodeEncoding;
            [System.Messaging.Message] $destmsg = New-Object System.Messaging.Message;
            $destmsg.BodyStream = $msg.BodyStream;
            $queue.Send($destmsg);
            
        }      

    }


   }#endofmethod.

  #use this method for non-transaction queue.
    function global:ReadTempQueue{


    [System.Text.UnicodeEncoding] $utf16 = New-Object System.Text.UnicodeEncoding;
    [System.IO.StreamReader] $sr = New-Object System.IO.StreamReader("C:\Pbs_Scripts\test.xml",$utf16);

    [System.IO.MemoryStream] $destStream = New-Object System.IO.MemoryStream;
    [System.IO.StreamWriter] $sw = New-Object System.IO.StreamWriter($destStream,$utf16);
    $xml = $sr.ReadToEnd();
    $sw.Write($xml);
    $sw.Flush();
    write-output $deststream;
    
    $tempqueue = New-Object System.Messaging.MessageQueue $sourcequeueName;  
    #$tempqueueTrans = New-Object System.Messaging.MessageQueueTransaction;  

    #$tempqueueTrans.Begin();
	    [System.Messaging.Message] $msg = New-Object System.Messaging.Message;
	    $msg.BodyStream = $destStream;
	    $tempqueue.Send($msg);
    #$tempqueueTrans.Commit();
    #$tempqueue.close();
    $sw.Close();
	
	
    }

   function global:ReadTempQueueTrans{
    [System.Text.UnicodeEncoding] $utf16 = New-Object System.Text.UnicodeEncoding;
    [System.IO.StreamReader] $sr = New-Object System.IO.StreamReader("C:\Pbs_Scripts\test.xml");

    [System.IO.MemoryStream] $destStream = New-Object System.IO.MemoryStream;
    [System.IO.StreamWriter] $sw = New-Object System.IO.StreamWriter($destStream,$utf16);
    $xml = $sr.ReadToEnd();
    $sw.Write($xml);
    $sw.Flush();
   #write-output $xml;
    
    $tempqueue = New-Object System.Messaging.MessageQueue $sourcequeueName;  
    $tempqueueTrans = New-Object System.Messaging.MessageQueueTransaction;  
    $tempqueueTrans.Begin();
	    [System.Messaging.Message] $msg = New-Object System.Messaging.Message;
	    $msg.BodyStream = $destStream;
	    $tempqueue.Send($msg,$tempqueueTrans);
    $tempqueueTrans.Commit();
    $tempqueue.close();
    $sw.Close();
	
    }


   