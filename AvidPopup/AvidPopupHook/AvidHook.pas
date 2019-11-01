unit AvidHook;

interface

uses Windows;

function GetAvidVersion : String;

implementation

uses SysUtils, Messages, ClipBrd, CommentsFrm, Controls, Forms, StrUtils,inifiles;

type
  TKeyStatus = (
    ksNormal,
    ksWasControlCRelease,
    ksInternalCC_Sent,
    ksInternalCC_CaughtFirst);

const
  ClipMarker = '$#$MARKER...';
  IDT_BV = 1982;

var
  gKeyStatusNames : array[TKeyStatus] of string =
    ('Normal', 'WasControlCRelease', 'InternalCC_Sent', 'InternalCC_CaughtFirst');
  gKeyStatus : TKeyStatus = ksNormal;
  gLoggingEnabled : Boolean = True;
  gLogFile : Text;
  gCommentsWindowHandle : HWND;
  vAvidWinHandle : HWND;
  gWindowTitle : String;
  gWindowClass : String;

procedure WriteDebugInfo(aText: string);
begin
  if gLoggingEnabled then
  begin
    Writeln(gLogFile, FormatDateTime('hh:nn:ss.zzz', Now) + ': ' + aText);
    Flush(gLogFile);
  end;
end;

function GetAvidVersion : String;
var
  vInfoSize, vWnd: DWORD;
  vVerBuf: Pointer;
  vFI: PVSFixedFileInfo;
  vVerSize: DWORD;
begin
  Result := '';
  vInfoSize := GetFileVersionInfoSize('AvidMediaComposer.exe', vWnd);
  if vInfoSize <> 0 then
  begin
    GetMem(vVerBuf, vInfoSize);
    try
      if GetFileVersionInfo('AvidMediaComposer.exe', vWnd, vInfoSize, vVerBuf) then
        if VerQueryValue(vVerBuf, '\', Pointer(vFI), vVerSize) then
          Result :=
            IntToStr(HIWORD(vFI.dwFileVersionMS))+'.'+
            IntToStr(LOWORD(vFI.dwFileVersionMS))+'.'+
            IntToStr(HIWORD(vFI.dwFileVersionLS))+'.'+
            IntToStr(LOWORD(vFI.dwFileVersionLS));
    finally
      FreeMem(vVerBuf);
    end;
  end;
end;

procedure SendStringToApp(Keys : String; ToggleControl : Boolean);
var
  vInputs : array[0..10] of TInput;
  I, J : Integer;
begin
  WriteDebugInfo('SendStringToApp: ''' + Keys +
    ''', toggleControl=' + IfThen(ToggleControl, 'True', 'False'));

  I := 0;

  if ToggleControl then begin
    vInputs[I].Itype := INPUT_KEYBOARD;
    vInputs[I].ki.wVk := VK_CONTROL;
    vInputs[I].ki.wScan := 0;
    vInputs[I].ki.dwFlags := 0;
    vInputs[I].ki.time := 0;
    vInputs[I].ki.dwExtraInfo := 0;
    Inc(I);
  end;

  for J := 1 to length(Keys) do begin
    vInputs[I].Itype := INPUT_KEYBOARD;
    vInputs[I].ki.wVk := ord(Keys[J]);
    vInputs[I].ki.wScan := 0;
    vInputs[I].ki.dwFlags := 0;
    vInputs[I].ki.time := 0;
    vInputs[I].ki.dwExtraInfo := 0;
    Inc(I);

    vInputs[I].Itype := INPUT_KEYBOARD;
    vInputs[I].ki.wVk := ord(Keys[J]);
    vInputs[I].ki.wScan := 0;
    vInputs[I].ki.dwFlags := KEYEVENTF_KEYUP;
    vInputs[I].ki.time := 0;
    vInputs[I].ki.dwExtraInfo := 0;
    Inc(I);
  end;

  if ToggleControl then begin
    vInputs[I].Itype := INPUT_KEYBOARD;
    vInputs[I].ki.wVk := VK_CONTROL;
    vInputs[I].ki.wScan := 0;
    vInputs[I].ki.dwFlags := KEYEVENTF_KEYUP;
    vInputs[I].ki.time := 0;
    vInputs[I].ki.dwExtraInfo := 0;
    Inc(I);
  end;

  Windows.SendInput(I, vInputs[0], sizeof(TInput));
end;

procedure SetKeyStatus(NewStatus : TKeyStatus);
begin
  WriteDebugInfo('SetKeyStatus old=' + gKeyStatusNames[gKeyStatus] +
    ', new=' + gKeyStatusNames[NewStatus]);
  gKeyStatus := NewStatus;
end;

procedure ShowCommentsForm;

//  procedure _wmCopy;
//  var
//    vFocusedHandle: HWND;
//  begin
//    WriteDebugInfo('_wmCopy: GetFocus');
//    vFocusedHandle := GetFocus;
//    WriteDebugInfo('_wmCopy: GetFocus '+ IntToStr(vFocusedHandle));
//
//    SendMessage(vFocusedHandle, EM_SETSEL, 0, -1);
//    Windows.SendMessage(vFocusedHandle, WM_COPY, 0, 0);
//  end;
//
//  procedure _wmPaste;
//  var
//    vFocusedHandle: HWND;
//  begin
////    Windows.SetFocus(AvidWinHandle);
//
//    WriteDebugInfo('_wmPaste: GetFocus');
//    vFocusedHandle := GetFocus;
//    WriteDebugInfo('_wmPaste: GetFocus '+ IntToStr(vFocusedHandle));
//    Windows.SendMessage(vFocusedHandle, WM_PASTE, 0, 0);
//    SendMessage(vFocusedHandle, EM_SETSEL, -1, -1);
//  end;

var
  vClipboardText : String;
  vCommentsForm: TCommentsForm;
begin
//  _wmCopy;
  vCommentsForm := TCommentsForm.Create(nil);
  try
    vClipboardText := Clipboard.AsText;

    vCommentsForm.SetAsText(vClipboardText);
    if vCommentsForm.ShowModal = mrOk then
    begin
      WriteDebugInfo('Have in clipboard ''' + Clipboard.AsText + '''');

      vClipboardText := vCommentsForm.GetAsText;

      WriteDebugInfo('Put to clipboard ''' + vClipboardText + '''');

      Clipboard.AsText := vClipboardText;
      SendStringToApp('V', True);
//      _wmPaste;
    end;
  finally
    vCommentsForm.Free;
  end;
end;


function MessageProc(nCode : Integer;
  wParam : WPARAM; lParam : LPARAM) : LRESULT; stdcall;
var
  vMess : PMsg;
begin
  // Our hook doesn't handle PeekMessage/PM_NOREMOVE keyboard processing
  if (nCode < 0) then
  begin
    Result := CallNextHookEx(WH_GETMESSAGE, nCode, wParam, lParam);
    exit;
  end;

  vMess := PMsg(lParam);
  if (gKeyStatus = ksInternalCC_CaughtFirst) and
    (vMess.message = WM_TIMER) and (vMess.wParam = IDT_BV)
  then
  begin
    KillTimer(gCommentsWindowHandle,IDT_BV);
    SetKeyStatus(ksNormal);
    ShowCommentsForm;
  end;
  Result := CallNextHookEx(WH_GETMESSAGE, nCode, wParam, lParam);
end;

function KeyboardProc(nCode : Integer;
  wParam : WPARAM; lParam : LPARAM) : LRESULT; stdcall;
var
  vWindowNameBuffer : String;
  vClassNameBuffer : String;
  vBufferLength : Integer;
  vActiveWindowHandle : HWND;
  vTransitionStateFlag: boolean;
begin
  // Our hook doesn't handle PeekMessage/PM_NOREMOVE keyboard processing
  if (nCode < 0) then
  begin
    Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
    exit;
  end;

  vTransitionStateFlag := (lParam and (1 shl 31)) <> 0;

  WriteDebugInfo(
    'KeyBoardProc: ' +
      //IfThen(lParam >= 0, 'PRESSED', 'RELEASED') + ':' + IntToStr(lParam) + '; ' + inttostr(ord(vTransitionStateFlag)) + ' key ' +
      IfThen(not vTransitionStateFlag, 'PRESSED', 'RELEASED') + ' key ' +
      IfThen((wParam >= ord('A')) and (wParam <= ord('Z')),
       '''' + chr(wParam)+ '''', IntToStr(wParam)) +
       ', clip=''' + Clipboard.AsText + '''');

  try
    // Also bail out quickly if Control key is not pressed
    if (wParam <> ord('C')) or
      (GetKeyState(VK_CONTROL) >= 0) or // Control IS NOT pressed
      (GetKeyState(VK_MENU) < 0) or // Alt is pressed
      (GetKeyState(VK_SHIFT) < 0) // Shift is pressed
    then
    begin
      if not (gKeyStatus in
        [ksNormal, ksInternalCC_Sent, ksInternalCC_CaughtFirst]) then
      begin
        SetKeyStatus(ksNormal);
      end;
      Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
      exit;
    end;

    vActiveWindowHandle := GetActiveWindow;

    // Check if we are in the right window
    SetLength(vWindowNameBuffer, 100);
    vBufferLength :=
      GetWindowText(vActiveWindowHandle, PChar(vWindowNameBuffer), length(vWindowNameBuffer));
    SetLength(vWindowNameBuffer, vBufferLength);

    SetLength(vClassNameBuffer, 100);
    vBufferLength :=
      GetClassName(vActiveWindowHandle, PChar(vClassNameBuffer), length(vClassNameBuffer));
    SetLength(vClassNameBuffer, vBufferLength);

    WriteDebugInfo('window=' + vWindowNameBuffer + ', classname=' + vClassNameBuffer);

// !!!!!!! MC: changes for testing
    if (vWindowNameBuffer <> gWindowTitle) or
      (vClassNameBuffer <> gWindowClass) then
//    if (vWindowNameBuffer <> 'Comments') or
      //(vClassNameBuffer <> '_ASI_THREED_') then
//      (vClassNameBuffer <> 'QWidget') then
    begin
      if gKeyStatus <> ksNormal then
        SetKeyStatus(ksNormal);
      Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
      exit;
    end;

    gCommentsWindowHandle := vActiveWindowHandle;

    // At this point we know we are in the right window,
    // and either pressing or releasing Control-C

    //if (lParam >= 0) and // Key is being pressed
    if (not vTransitionStateFlag) and // Key is being pressed
      (gKeyStatus = ksWasControlCRelease)
    then
    begin
      // Select all text in Window, and copy it to Clipboard
      SetKeyStatus(ksInternalCC_Sent);

      Clipboard.AsText := ClipMarker;

      Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
//      SendStringToApp('AC', False);

      exit;
    end;

    //if (lParam < 0) then // Key released
    if (vTransitionStateFlag) then // Key released
    begin
      if gKeyStatus = ksWasControlCRelease
      then
      begin
        // Select all text in Window, and copy it to Clipboard
        SetKeyStatus(ksInternalCC_Sent);

        Clipboard.AsText := ClipMarker;

        Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
//        SendStringToApp('AC', False);
        //SendControlKeyToApp('C', False);

        exit;
      end
      else
      if gKeyStatus = ksInternalCC_Sent then
      begin
        SetKeyStatus(ksInternalCC_CaughtFirst);

        // Give 50 ms for the Composer to process the selection
        SetTimer(vActiveWindowHandle, IDT_BV, 100, nil);
      end
      else
      if gKeyStatus = ksNormal then
        SetKeyStatus(ksWasControlCRelease);
    end
    else
    begin
      if not (gKeyStatus in
        [ksNormal, ksInternalCC_Sent, ksInternalCC_CaughtFirst]) then
      begin
        SetKeyStatus(ksNormal);
      end;
    end;

    Result := CallNextHookEx(WH_KEYBOARD, nCode, wParam, lParam);
  finally
    WriteDebugInfo('KeyBoardProc: END');
  end;
end;

function EnumWindowsProc(wHandle: HWND; lb: String): BOOL; stdcall;
var
  Title, ClassName: array[0..255] of char;
  strclass : String;
begin
  GetWindowText(wHandle, Title, 255);
  GetClassName(wHandle, ClassName, 255);
  if IsWindowVisible(wHandle) then
   begin
    SetString(strclass,ClassName,Length(ClassName));
    if ( AnsiStartsText(lb,Title) ) then
    begin
      vAvidWinHandle := wHandle;
      WriteDebugInfo(Format('Found matching window. Class: %s ,Title: %s ,Handle: %d',[ClassName,Title,vAvidWinHandle]));
      WriteDebugInfo('SearchText : ' + lb);
    end;
   end;
  Result := True;
end;

procedure InstallAvidHook;
var
  vThreadId : DWORD;
  vHook1, vHook2 : HHOOK;
  vError : Cardinal;
  vLogFilePath,vIniFileName : String;
  vName: array[0..255] of char;
  vMediaNameChar: array[0..255] of Char;
  vMediaName : String;
  vIniMediaName : TIniFile;
begin
  vLogFilePath := GetEnvironmentVariable('AVIDHOOK_DEBUG');

  gLoggingEnabled := vLogFilePath <> '';

  if gLoggingEnabled then
  begin
    AssignFile(gLogFile, vLogFilePath);
    Rewrite(gLogFile);
  end;

  WriteDebugInfo('Plugin starting. Avid Media Composer version: ' + GetAvidVersion);

  vIniFileName := 'C:\PBSAvidPopupWindow.ini';
  WriteDebugInfo('Trying to load Ini file : ' + vIniFileName);
  vIniMediaName := TIniFile.Create(vIniFileName);
  vMediaName := vIniMediaName.ReadString('Window','Name','');
  gWindowTitle := vIniMediaName.ReadString('Window','Title','');
        gWindowClass := vIniMediaName.ReadString('Window','Class','');
  if (vMediaName <> '' ) then
  begin

    WriteDebugInfo('Window name from INI: ' + vMediaName);
  end
  else
  begin
       vMediaName :=   'Avid Media Composer';
       WriteDebugInfo('Cannot find INI file for Enumerating window name. Using default value:' + vMediaName);
  end;

  StrPLCopy(vMediaNameChar,vMediaName,High(vMediaNameChar));

  // 4/30/2015 - MRajendran Code Commented to use EnumWindows
  // !!!!!!! MC: changes for testing
  //  vAvidWinHandle := FindWindow('TAvidPopupHook_TestForm', nil{'Avid Media Composer '});
  //TODO vAvidWinHandle := FindWindow('AvidEditorMainWndClass', nil{'Avid Media Composer '});

  //vAvidWinHandle := FindWindow(nil, vMediaNameChar);
  EnumWindows(@EnumWindowsProc,LPARAM(PChar(vMediaName)));

  if (vAvidWinHandle <> 0) and gLoggingEnabled then begin
    GetClassName(vAvidWinHandle, vName, 256);
    WriteDebugInfo('Avid Media Composer class name: ' + vName);
    //vAvidWinHandle := 0;
  end;


  if (vAvidWinHandle = 0) and gLoggingEnabled then
  begin
    WriteDebugInfo('Avid Media Composer is not running');
    exit;
  end;

  vThreadId := GetWindowThreadProcessId(vAvidWinHandle);

  vHook1 := SetWindowsHookEx(
    WH_GETMESSAGE,
    @MessageProc,
    0,
    vThreadId
    );

  if (vHook1 = 0) and gLoggingEnabled then
  begin
    vError := GetLastError;
    WriteDebugInfo('Cannot install message queue hook. Error: ' + IntToStr(vError));
    exit;
  end;

  vHook2 := SetWindowsHookEx(
    WH_KEYBOARD,
    @KeyboardProc,
    0,
    vThreadId
    );

  if (vHook2 = 0) and gLoggingEnabled then
  begin
    vError := GetLastError;
    WriteDebugInfo('Cannot install keyboard hook. Error: ' + IntToStr(vError));
    UnhookWindowsHookEx(vHook1);
    exit;
  end;

  // Increment library use count to prevent unloading
// !!!!!!! MC: changes for testing
//  LoadLibrary('AvidPopupHook_Test.avx');
  LoadLibrary('AvidPopupHook.avx');
end;

initialization
  InstallAvidHook;
end.
