(**

  Purpose: Avid Hook Radio Group Frame

  Copyright© 2001-2009, BroadView Software Inc. All rights reserved.
*)
unit AvidHookRadioGroupFra;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, 
  Dialogs, StdCtrls, ExtCtrls, AvidPopupHookIniIXM, AvidHookBaseFra, DB;

type
  TAvidHookRadioGroupFrame = class(TAvidHookBaseFrame)
    pnlRadioGroup: TPanel;
    rgrRadioGroup: TRadioGroup;
  private
    FIDArray: Array of Integer;
  protected
    function GetIDValue: string; override;
    function GetTextValue: string; override;
    function GetValue: Variant; override;
    procedure SetIDValue(aValue: string); override;
    procedure SetValue(const aValue: Variant); override;
  public
    procedure ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var vTop: Integer);
    procedure AddValuesToDataSet(aDataSet: TDataSet; aKeyFName, aDescFName: string);
  end;

implementation

uses
  Math{, UFunctions};

{$R *.dfm}

procedure TAvidHookRadioGroupFrame.ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var vTop: Integer);
var
  i: Integer;
begin
  FControlID := Trim(aXMLControl.ControlID);
  Self.Parent := (AOwner as TWinControl);
  Self.Top := vTop;
  Self.Align := alTop;
  Self.Height := Max(35, Min(300, aXMLControl.Count * 23 + Self.Height - Self.rgrRadioGroup.ClientHeight));
  SetLength(FIDArray, aXMLControl.Count);
  Self.rgrRadioGroup.Caption := aXMLControl.Label_;
  for i := 0 to aXMLControl.Count - 1 do begin
    Self.rgrRadioGroup.Items.Add(aXMLControl.Items[i].Text);
    FIDArray[i] := aXMLControl.Items[i].ID;
  end;
  if aXMLControl.Count > 0 then begin
    rgrRadioGroup.ItemIndex := 0;
  end;
  vTop := Self.Top + Self.Height;
end;

procedure TAvidHookRadioGroupFrame.AddValuesToDataSet(aDataSet: TDataSet; aKeyFName, aDescFName: string);
var
  vKeyIdx, vDescIdx, i: Integer;
begin
  vKeyIdx := aDataSet.FieldByName(aKeyFName).Index;
  vDescIdx := aDataSet.FieldByName(aDescFName).Index;
  for i := 0 to rgrRadioGroup.Items.Count - 1 do begin
    aDataSet.Append;
    aDataSet.Fields[vKeyIdx].AsInteger := FIDArray[i];
    aDataSet.Fields[vDescIdx].AsString := rgrRadioGroup.Items[i];
    aDataSet.Post;
  end;
end;

function TAvidHookRadioGroupFrame.GetIDValue: string;
begin
  if (rgrRadioGroup.ItemIndex >= 0) then begin
    Result := IntToStr(FIDArray[rgrRadioGroup.ItemIndex]);
  end
  else begin
    Result := '';
  end;
end;

function TAvidHookRadioGroupFrame.GetTextValue: string;
begin
  if (rgrRadioGroup.ItemIndex >= 0) then begin
    Result := rgrRadioGroup.Items[rgrRadioGroup.ItemIndex];
  end
  else begin
    Result := '';
  end;
end;

function TAvidHookRadioGroupFrame.GetValue: Variant;
var
  vID: Integer;
begin
  vID := StrToIntDef(GetIDValue, 0);
  if (vID <> 0) then begin
    Result := vID;
  end
  else begin
    Result := NULL;
  end;
end;

procedure TAvidHookRadioGroupFrame.SetIDValue(aValue: string);
var
  vID, i: Integer;
begin
  vID := StrToIntDef(aValue, 0);
  if (vID <> 0) then begin
    for i := 0 to rgrRadioGroup.Items.Count - 1 do begin
      if (FIDArray[i] = vID) then begin
        rgrRadioGroup.ItemIndex := i;
        Break;
      end;
    end;
  end;
end;

procedure TAvidHookRadioGroupFrame.SetValue(const aValue: Variant);
begin
  SetIDValue(IntToStr(VarToIntDef(aValue, 0)));
end;

end.
