@ECHO OFF

echo.
echo.
echo ***************BV Proxy XSD, XSLT and C# Class Comparison******************

REM DATE
for /F "tokens=1-4 delims=/ " %%i in ('date /t') do (
   set DayOfWeek=%%i
   set Month=%%j
   set Day=%%k
   set Year=%%l
   set Date=%%i %%j/%%k/%%l
   set str=%%l%%j%%k
)

REM TIME
for /F "tokens=1-4 delims=: " %%i in ('time /t') do (
   set HH=%%i
   set MM=%%j

   set str=%str%_%%i%%j
)


REM ******************************************************
REM ******************************************************
REM ****************Modify Settings Below***************** 
REM ******************************************************


REM set Solution Root
set SOL_ROOT_DIR=E:\Projects\visual studio 2012\Projects\BVProxy.root

REM Set location of directory path (off of root) that contains Target Generated files(XSLT, XSD, XSLTClass)
set GENERATED_TARGET_ROOT_PATH=\CreateSchema\Target

REM Set location of directory containing batch files.
set BATCHFILE_DIR=E:\Projects\visual studio 2012\Projects\BatchCompare

REM Set location of directory for resulting output from executing comparison
set BATCHFILE_RESULT_PATH=\Results


REM SET BVPROXY Deployed Root
set BVPROXY_DEPLOYED_ROOT_DIR=E:\Projects\visual studio 2012\Projects\BVProxy.root\BVWebService

REM SET SAPROXY Deployed Root
set SAPROXY_DEPLOYED_ROOT_DIR=E:\Projects\visual studio 2012\Projects\BVProxy.root\SAWebService





REM ******************************************************
REM ******************************************************

call "%BATCHFILE_DIR%\Compare_All_rdmPBSAuthorization.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSAuthorization.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSDeadlineNotification.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSDeadlineNotification.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSDeal.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSDeal.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSGetLookup.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSGetLookup.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSGetMasterDeal.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSGetMasterDeal.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSManageAppliesToRange.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSManageAppliesToRange.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSManageTable.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSManageTable.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSMediaInventory.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSMediaInventory.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSProgram.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSProgram.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSProgramCreator.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSProgramCreator.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSRemedy.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSRemedy.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSSearch.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" "%SAPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSSearch.result.txt"
call "%BATCHFILE_DIR%\Compare_All_rdmPBSTalent.bat" "%SOL_ROOT_DIR%%GENERATED_TARGET_ROOT_PATH%" "%BVPROXY_DEPLOYED_ROOT_DIR%" > "%BATCHFILE_DIR%%BATCHFILE_RESULT_PATH%\%str%_Compare_All_rdmPBSTalent.result.txt"



echo.
echo.
echo ***************Comparison Completed.  Review logs for results.******************

pause


:FINISH
