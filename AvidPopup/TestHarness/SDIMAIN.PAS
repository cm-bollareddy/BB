unit SDIMAIN;

interface

uses Winapi.Windows, System.Classes, Vcl.Graphics, Vcl.Forms, Vcl.Controls,
  Vcl.Menus, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Buttons, Vcl.ExtCtrls, Vcl.ComCtrls,
  Vcl.ImgList, Vcl.StdActns, Vcl.ActnList, Vcl.ToolWin, System.ImageList,
  System.Actions,strUtils,Testform, Vcl.FileCtrl;

type
  TSDIAppForm = class(TForm)
    OpenDialog: TOpenDialog;
    SaveDialog: TSaveDialog;
    ToolBar1: TToolBar;
    ToolButton9: TToolButton;
    ToolButton1: TToolButton;
    ToolButton2: TToolButton;
    ToolButton3: TToolButton;
    ToolButton4: TToolButton;
    ToolButton5: TToolButton;
    ToolButton6: TToolButton;
    ActionList1: TActionList;
    FileNew1: TAction;
    FileOpen1: TAction;
    FileSave1: TAction;
    FileSaveAs1: TAction;
    FileExit1: TAction;
    EditCut1: TEditCut;
    EditCopy1: TEditCopy;
    EditPaste1: TEditPaste;
    HelpAbout1: TAction;
    StatusBar: TStatusBar;
    ImageList1: TImageList;
    MainMenu1: TMainMenu;
    File1: TMenuItem;
    FileNewItem: TMenuItem;
    FileOpenItem: TMenuItem;
    FileSaveItem: TMenuItem;
    FileSaveAsItem: TMenuItem;
    N1: TMenuItem;
    FileExitItem: TMenuItem;
    Edit1: TMenuItem;
    CutItem: TMenuItem;
    CopyItem: TMenuItem;
    PasteItem: TMenuItem;
    Help1: TMenuItem;
    HelpAboutItem: TMenuItem;
    Button1: TButton;
    ListBox1: TListBox;
    Label1: TLabel;
    Label2: TLabel;
    Memo1: TMemo;
    Label3: TLabel;
    Label4: TLabel;
    edtWindow: TEdit;
    OpenDialog1: TOpenDialog;
    Button2: TButton;
    procedure FileNew1Execute(Sender: TObject);
    procedure FileOpen1Execute(Sender: TObject);
    procedure FileSave1Execute(Sender: TObject);
    procedure FileExit1Execute(Sender: TObject);
    procedure HelpAbout1Execute(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    procedure WriteLog(msg : String);
  end;

var
  SDIAppForm: TSDIAppForm;
  chkValue:String;
  vAvidWinHandle :Thandle;
  vLibraryPath : String;
implementation

uses About;

{$R *.dfm}

function EnumWindowsProc(wHandle: HWND; lb: TListBox): BOOL; stdcall;
var
  Title, ClassName: array[0..255] of char;
  strclass : String;
begin
  GetWindowText(wHandle, Title, 255);
  GetClassName(wHandle, ClassName, 255);
  if IsWindowVisible(wHandle) then
   begin
    SetString(strclass,ClassName,Length(ClassName));
    if ( AnsiStartsText('AVID',Title) ) then
    begin
      lb.Items.Add(string(Title) + '-' + string(ClassName));
      vAvidWinHandle := wHandle;
    end;
   end;
  Result := True;
end;

procedure TSDIAppForm.WriteLog(msg : String);
begin
  Memo1.Lines.Add(msg);
end;

procedure TSDIAppForm.FileNew1Execute(Sender: TObject);
begin
  { Do nothing }
end;

procedure TSDIAppForm.FileOpen1Execute(Sender: TObject);
begin
  OpenDialog.Execute;
end;

procedure TSDIAppForm.FileSave1Execute(Sender: TObject);
begin
  SaveDialog.Execute;
end;

procedure TSDIAppForm.Button1Click(Sender: TObject);
var
   LibHandle: Thandle;
   vProcId : Cardinal;
   vName,processName: array[0..255] of char;
   avidForm: TAvid1;

begin
  WriteLog('Opening Test harness form..');
  avidForm := TAvid1.Create(self);
  avidForm.Show;

  chkValue := edtWindow.Text;
  ListBox1.Items.Clear;
  WriteLog('Enumerating windows..');
  EnumWindows(@EnumWindowsProc, LPARAM(ListBox1));


  WriteLog('finding process Name..');
  GetWindowThreadProcessId(vAvidWinHandle,vProcId);
  GetModuleFileName(vProcId,processName,100);
  GetClassName(vAvidWinHandle, vName, 256);

  WriteLog('Process Name: ' + processName);
  WriteLog('Class Name: ' + vName);

  { Attempt to load the DLL }
  WriteLog('Attempt to load library: ' + vLibraryPath );
  LibHandle := LoadLibrary(PChar(vLibraryPath));
   try
  { If the load failed, LibHandle will be zero.
   If this occurs, raise an exception. }
    if LibHandle = 0 then
       WriteLog('Unable to Load DLL');
   finally
    FreeLibrary(LibHandle); // Unload the DLL.
   end;

 end;

procedure TSDIAppForm.Button2Click(Sender: TObject);
begin
  OpenDialog1.Create(self);
  if OpenDialog1.Execute() then
  begin
    vLibraryPath := OpenDialog1.FileName;
    button1.Enabled := true;
   end;
end;

procedure TSDIAppForm.FileExit1Execute(Sender: TObject);
begin
  Close;
end;

procedure TSDIAppForm.HelpAbout1Execute(Sender: TObject);
begin
  AboutBox.ShowModal;
end;

end.
