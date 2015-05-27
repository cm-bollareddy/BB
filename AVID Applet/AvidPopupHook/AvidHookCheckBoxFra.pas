(**

  Purpose: Avid Hook Check Box Frame

  Copyright© 2001-2010, BroadView Software Inc. All rights reserved.
*)
unit AvidHookCheckBoxFra;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, 
  Dialogs, StdCtrls, AvidPopupHookIniIXM, AvidHookBaseFra;

type
  TAvidHookCheckBoxFrame = class(TAvidHookBaseFrame)
    chkControl: TCheckBox;
  protected
    function GetIDValue: string; override;
    function GetTextValue: string; override;
    function GetValue: Variant; override;
    procedure SetIDValue(aValue: string); override;
    procedure SetValue(const aValue: Variant); override;
  public
    procedure ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var aTop: Integer);
  end;

implementation

{uses
  UFunctions;}

{$R *.dfm}

procedure TAvidHookCheckBoxFrame.ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var aTop: Integer);
begin
  FControlID := Trim(aXMLControl.ControlID);
  Self.Parent := (AOwner as TWinControl);
  Self.Top := aTop;
  Self.Align := alTop;
  Self.chkControl.Caption := aXMLControl.Label_;
  aTop := Self.Top + Self.Height;
end;

function TAvidHookCheckBoxFrame.GetIDValue: string;
begin
  if (chkControl.Checked) then begin
    Result := '1';
  end
  else begin
    Result := '0';
  end;
end;

function TAvidHookCheckBoxFrame.GetTextValue: string;
begin
  Result := '';
end;

function TAvidHookCheckBoxFrame.GetValue: Variant;
begin
  Result := StrToIntDef(GetIDValue, 0);
end;

procedure TAvidHookCheckBoxFrame.SetIDValue(aValue: string);
begin
  chkControl.Checked := (aValue = '1');
end;

procedure TAvidHookCheckBoxFrame.SetValue(const aValue: Variant);
begin
  SetIDValue(IntToStr(VarToIntDef(aValue, 0)));
end;

end.
