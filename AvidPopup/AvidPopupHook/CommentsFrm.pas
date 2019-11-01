unit CommentsFrm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TCommentsForm = class(TForm)
    pnlButtons: TPanel;
    OkButton: TButton;
    CancelButton: TButton;
    pnlMain222: TPanel;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormCreate(Sender: TObject);
  private
    FXMLVersion: Integer;
    function GetFormMonitorByPosition: Integer;
    procedure ReadFormPosition;
    procedure WriteFormPosition;
  public
    function GetAsText : String;
    procedure SetAsText(const Text: String);
  end;

var
  CommentsForm: TCommentsForm;

implementation

uses
  UAvidPopupHookInit, AvidHookMemoFra, Registry;

{$R *.dfm}

const
  REGKEY_BVS_AVIDPOPUPHOOK = '\Software\BroadViewSoftware Inc\BVS AvidPopupHook';
  REGVALUE_LEFT = 'Left';
  REGVALUE_TOP = 'Top';
//  REGVALUE_WIDTH = 'Width';
//  REGVALUE_HEIGHT = 'Height';
  REGVALUE_MONITOR = 'Monitor';
//  FORM_MINWIDTH = 250;
//  FORM_MINHEIGHT = 380;
//  FORM_MAXWIDTH = 2 * FORM_MINWIDTH;
//  FORM_MAXHEIGHT = 2 * FORM_MINHEIGHT;

procedure TCommentsForm.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  WriteFormPosition;
end;

procedure TCommentsForm.FormCreate(Sender: TObject);
begin
  InitAppletForm(pnlMain222, ExtractFilePath(Application.ExeName), FXMLVersion);
  ReadFormPosition;
end;

function TCommentsForm.GetAsText : String;
begin
  Result := GetParamsAsText(pnlMain222, FXMLVersion);
end;

function TCommentsForm.GetFormMonitorByPosition: Integer;
var
  i: Integer;
begin
  Result := 0;
  for i := 0 to Screen.MonitorCount - 1 do
    if (Self.Left >= Screen.Monitors[i].Left) and (Self.Left <= Screen.Monitors[i].Left + Screen.Monitors[i].Width) and
      (Self.Top >= Screen.Monitors[i].Top) and (Self.Top <= Screen.Monitors[i].Top + Screen.Monitors[i].Height) then begin
      Result := i;
      Break;
    end;
end;

procedure TCommentsForm.ReadFormPosition;

  function _ReadInteger(aReg: TRegistry; aValue: string): Integer;
  var
    vRegDataType: TRegDataType;
  begin
    vRegDataType := aReg.GetDataType(aValue);
    if vRegDataType = rdInteger then begin
      Result := aReg.ReadInteger(aValue)
    end
    else begin
      Result := -1;
    end;
  end;

var
  vReg: TRegistry;
  vLeft, vTop, vMonitor: Integer;
//  vWidth, vHeight: Integer;
begin
  vLeft := 0;
  vTop := 0;
//  vWidth := FORM_MINWIDTH;
//  vHeight := FORM_MINHEIGHT;
  vMonitor := 0;
  vReg := nil;
  try
    vReg := TRegistry.Create(KEY_QUERY_VALUE);
    vReg.RootKey := HKEY_CURRENT_USER;
    if vReg.OpenKeyReadOnly(REGKEY_BVS_AVIDPOPUPHOOK) then begin
      try
        vLeft := _ReadInteger(vReg, REGVALUE_LEFT);
        vTop := _ReadInteger(vReg, REGVALUE_TOP);
//        vWidth := _ReadInteger(vReg, REGVALUE_WIDTH);
//        vHeight := _ReadInteger(vReg, REGVALUE_HEIGHT);
        vMonitor := _ReadInteger(vReg, REGVALUE_MONITOR);
      except
        vReg.CloseKey;
      end;
      vReg.CloseKey;
    end;
  except
    vReg.Free;
  end;
  vReg.Free;

  if (vMonitor <> -1) then begin

//    if (vWidth < FORM_MINWIDTH) then
//      vWidth := FORM_MINWIDTH;
//    if (vWidth > FORM_MAXWIDTH) then
//      vWidth := FORM_MAXWIDTH;
//    if (vHeight < FORM_MINHEIGHT) then
//      vHeight := FORM_MINHEIGHT;
//    if (vHeight > FORM_MAXHEIGHT) then
//      vHeight := FORM_MAXHEIGHT;
//
//    Self.Width := vWidth;
//    Self.Height := vHeight;

    if (vMonitor >= Screen.MonitorCount) then begin
      vMonitor := Screen.MonitorCount - 1;
    end;
    if (vLeft < Screen.Monitors[vMonitor].WorkareaRect.Left) then begin
      vLeft := Screen.Monitors[vMonitor].WorkareaRect.Left;
    end
    else if ((vLeft + Self.Width) > Screen.Monitors[vMonitor].WorkareaRect.Right) then begin
      vLeft := Screen.Monitors[vMonitor].WorkareaRect.Right - Self.Width;
    end;
    if (vTop < Screen.Monitors[vMonitor].WorkareaRect.Top) then begin
      vTop := Screen.Monitors[vMonitor].WorkareaRect.Top;
    end
    else if ((vTop + Self.Height) > Screen.Monitors[vMonitor].WorkareaRect.Bottom) then begin
      vTop := Screen.Monitors[vMonitor].WorkareaRect.Bottom - Self.Height;
    end;
    Self.Left := vLeft;
    Self.Top := vTop;

  end;
end;

procedure TCommentsForm.SetAsText(const Text : String);
begin
  SetParamsAsText(pnlMain222, Text, FXMLVersion);
end;

procedure TCommentsForm.WriteFormPosition;
var
  vReg: TRegistry;
begin
  vReg := TRegistry.Create(KEY_WRITE);
  try
    vReg.RootKey := HKEY_CURRENT_USER;
    if vReg.OpenKey(REGKEY_BVS_AVIDPOPUPHOOK, True) then begin
      try
        vReg.WriteInteger(REGVALUE_LEFT, Self.Left);
        vReg.WriteInteger(REGVALUE_TOP, Self.Top);
//        vReg.WriteInteger(REGVALUE_WIDTH, Self.Width);
//        vReg.WriteInteger(REGVALUE_HEIGHT, Self.Height);
        vReg.WriteInteger(REGVALUE_MONITOR, GetFormMonitorByPosition);
      except
        vReg.CloseKey;
      end;
      vReg.CloseKey;
    end;
  finally
    vReg.Free;
  end;
end;

end.
