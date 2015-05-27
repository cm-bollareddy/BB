(**

  Purpose: Avid Hook Memo Frame

  Copyright© 2001-2009, BroadView Software Inc. All rights reserved.
*)
unit AvidHookMemoFra;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, AvidPopupHookIniIXM, AvidHookBaseFra;

type
  TAvidHookMemoFrame = class(TAvidHookBaseFrame)
    pnlMemoTop: TPanel;
    pnlMemoMain: TPanel;
    lblMemoCaption: TLabel;
  private
    FMemo: TMemo;
  protected
    function GetIDValue: string; override;
    function GetTextValue: string; override;
    function GetValue: Variant; override;
    procedure SetTextValue(aValue: string); override;
    procedure SetValue(const aValue: Variant); override;
  public
    constructor Create(AOwner: TComponent); override;
    procedure ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var vTop: Integer);
  end;

implementation

{$R *.dfm}

constructor TAvidHookMemoFrame.Create(AOwner: TComponent);
begin
  inherited;
  
  FMemo := nil;
end;

procedure TAvidHookMemoFrame.ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var vTop: Integer);
const
  C_MEMOFRAME_HEIGHT = 70;
begin
  FControlID := Trim(aXMLControl.ControlID);
  Self.Parent := (AOwner as TWinControl);
  Self.Top := vTop;
  Self.Align := alTop;
  Self.Height := C_MEMOFRAME_HEIGHT;
  Self.lblMemoCaption.Caption := aXMLControl.Label_;
  FMemo := TMemo.Create(AOwner);
  FMemo.Parent := pnlMemoMain;
  FMemo.Align := alClient;
  FMemo.ScrollBars := ssVertical;
  vTop := Self.Top + Self.Height;
end;

function TAvidHookMemoFrame.GetIDValue: string;
begin
  Result := '';
end;

function TAvidHookMemoFrame.GetTextValue: string;
begin
  if Assigned(FMemo) then begin
    Result := Trim(FMemo.Text);
  end
  else begin
    Result := '';
  end;
end;

function TAvidHookMemoFrame.GetValue: Variant;
var
  vStr: string;
begin
  vStr := GetTextValue;
  if (vStr <> '') then begin
    Result := vStr;
  end
  else begin
    Result := NULL;
  end;
end;

procedure TAvidHookMemoFrame.SetTextValue(aValue: string);
begin
  if Assigned(FMemo) then begin
    FMemo.Text := aValue;
  end;
end;

procedure TAvidHookMemoFrame.SetValue(const aValue: Variant);
begin
  SetTextValue(VarToStrDef(aValue, ''));
end;

end.

