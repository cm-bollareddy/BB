(**

  Purpose: Avid Hook Combo Box Frame

  Copyright© 2001-2009, BroadView Software Inc. All rights reserved.
*)
unit AvidHookComboBozFra;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, 
  Dialogs, StdCtrls, AvidPopupHookIniIXM, AvidHookBaseFra, DB;

type
  TAvidHookComboBozFrame = class(TAvidHookBaseFrame)
    lblCaption: TLabel;
    cmbControl: TComboBox;
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

{uses
  UFunctions;}

{$R *.dfm}

procedure TAvidHookComboBozFrame.ActivateFrame(AOwner: TControl; aXMLControl: IXMLTFraControl; var vTop: Integer);
var
  i: Integer;
begin
  FControlID := Trim(aXMLControl.ControlID);
  Self.Parent := (AOwner as TWinControl);
  Self.Top := vTop;
  Self.Align := alTop;
  SetLength(FIDArray, aXMLControl.Count);
  Self.lblCaption.Caption := aXMLControl.Label_;
  for i := 0 to aXMLControl.Count - 1 do begin
    Self.cmbControl.Items.Add(aXMLControl.Items[i].Text);
    FIDArray[i] := aXMLControl.Items[i].ID;
  end;
  if aXMLControl.Count > 0 then begin
    cmbControl.ItemIndex := 0;
  end;
  vTop := Self.Top + Self.Height;
end;

procedure TAvidHookComboBozFrame.AddValuesToDataSet(aDataSet: TDataSet; aKeyFName, aDescFName: string);
var
  vKeyIdx, vDescIdx, i: Integer;
begin
  vKeyIdx := aDataSet.FieldByName(aKeyFName).Index;
  vDescIdx := aDataSet.FieldByName(aDescFName).Index;
  for i := 0 to cmbControl.Items.Count - 1 do begin
    aDataSet.Append;
    aDataSet.Fields[vKeyIdx].AsInteger := FIDArray[i];
    aDataSet.Fields[vDescIdx].AsString := cmbControl.Items[i];
    aDataSet.Post;
  end;
end;

function TAvidHookComboBozFrame.GetIDValue: string;
begin
  if (cmbControl.ItemIndex >= 0) then begin
    Result := IntToStr(FIDArray[cmbControl.ItemIndex]);
  end
  else begin
    Result := '';
  end;
end;

function TAvidHookComboBozFrame.GetTextValue: string;
begin
  if (cmbControl.ItemIndex >= 0) then begin
    Result := cmbControl.Items[cmbControl.ItemIndex];
  end
  else begin
    Result := '';
  end;
end;

function TAvidHookComboBozFrame.GetValue: Variant;
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

procedure TAvidHookComboBozFrame.SetIDValue(aValue: string);
var
  vID, i: Integer;
begin
  vID := StrToIntDef(aValue, 0);
  if (vID <> 0) then begin
    for i := 0 to cmbControl.Items.Count - 1 do begin
      if (FIDArray[i] = vID) then begin
        cmbControl.ItemIndex := i;
        Break;
      end;
    end;
  end;
end;

procedure TAvidHookComboBozFrame.SetValue(const aValue: Variant);
begin
  SetIDValue(IntToStr(VarToIntDef(aValue, 0)));
end;

end.
