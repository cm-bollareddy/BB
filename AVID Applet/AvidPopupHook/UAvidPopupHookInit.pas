(**

  Purpose: Avid Popup Hook Init Unit

  Copyright© 2001-2009, BroadView Software Inc. All rights reserved.
*)
unit UAvidPopupHookInit;

interface

uses Controls;

procedure InitAppletForm(AOwner: TControl; const aIniFilePath: string; var aXMLVersion: Integer);
procedure DoCreateControls(AOwner: TControl; const aFileName, aIniXMLText: string; var aXMLVersion: Integer);
function GetParamsAsText(AOwner: TControl; const aXMLVersion: Integer): string;
procedure SetParamsAsText(AOwner: TControl; aValue: string; const aXMLVersion: Integer);

implementation

uses
  AvidPopupHookIniIXM, SysUtils, ActiveX, Dialogs, AvidHookComboBozFra, Windows,
  AvidHookRadioGroupFra, AvidHookMemoFra, AvidHookBaseFra, IdGlobal,
  IdHashMessageDigest, Classes, StrUtils, IdHash, AvidHookCheckBoxFra, Math, System.UITypes;

const
  CNTRL_COMBOBOX = 1;
  CNTRL_RADIOGROUP = 2;
  CNTRL_MEMO = 3;
  CNTRL_CHECKBOX = 4;

function GetHashCRC_AsHexString(const aStr: string): string;

  function _ConvertToResult_3b(aValue: Cardinal): Cardinal;
  begin
    Result := (aValue and $FFFFFF) + ((aValue and $FF000000) shr 3);
    Result := (Result and $FFFFFF) + ((Result and $FF000000) shr 3);
    Result := Result and $FFFFFF;
  end;

var
  vHash: TIdHashMessageDigest5;
  i: Integer;
  vHashBytes : TIdBytes;
  vPackedBytes : packed array [0..15] of byte;
  v4x4: T4x4LongWordRecord absolute vPackedBytes;
  vResult: Cardinal;
begin
  vHash := TIdHashMessageDigest5.Create;
  try

    vHashBytes := vHash.HashString(aStr);

    for i := 0 to Min(Length(vHashBytes) - 1, 15) do begin
      vPackedBytes[i] := vHashBytes[i];
    end;
    for i := Length(vHashBytes) to 15 do begin
      vPackedBytes[i] := 0;
    end;

    // now we have v4x4 values defined - do the math

    vResult := 0;
    for i := 3 downto 0 do begin
      vResult := _ConvertToResult_3b(vResult + _ConvertToResult_3b(v4x4[i]));
    end;
    Result := UpperCase(IntToHex(vResult, 6));

  finally
    vHash.Free;
  end;

end;

procedure Tmp_SaveIniFile(aFileName: string);
var
  vIniXMLSchema: IXMLTPBSApplet;
  vControl: IXMLTFraControl;
  vValue: IXMLTValue;
begin
  vIniXMLSchema := NewPBSApplet;
  try
    vIniXMLSchema.XML_Version := 1;
    vControl := vIniXMLSchema.Add;

    vControl.ControlArea := 1;
    vControl.ControlType := 1;
    vControl.Label_ := 'Cut Type';

    vValue := vControl.Add;
    vValue.ID := 111;
    vValue.Text := 'Type 1111';

    vValue := vControl.Add;
    vValue.ID := 222;
    vValue.Text := 'Type 2222';

    vValue := vControl.Add;
    vValue.ID := 333;
    vValue.Text := 'Type 3333';

    vValue := vControl.Add;
    vValue.ID := 444;
    vValue.Text := 'Type 4444';


    vControl := vIniXMLSchema.Add;

    vControl.ControlArea := 2;
    vControl.ControlType := 2;
    vControl.Label_ := '';

    vValue := vControl.Add;
    vValue.ID := 701;
    vValue.Text := '4:3';

    vValue := vControl.Add;
    vValue.ID := 702;
    vValue.Text := 'Letterbox';

    vValue := vControl.Add;
    vValue.ID := 703;
    vValue.Text := '16:9';


    vControl := vIniXMLSchema.Add;

    vControl.ControlArea := 3;
    vControl.ControlType := 3;
    vControl.Label_ := 'Comment:';

    vValue := vControl.Add;
    vValue.ID := 0;
    vValue.Text := '';

    vIniXMLSchema.OwnerDocument.SaveToFile(aFileName);
  finally
    vIniXMLSchema := nil;
  end;
end;

procedure DoCreateControls(AOwner: TControl; const aFileName, aIniXMLText: string; var aXMLVersion: Integer);
var
  vIniXMLPBSApplet: IXMLTPBSApplet;
  i, k, ii: Integer;
  vComboBoxFra: TAvidHookComboBozFrame;
  vRadioGroupFra: TAvidHookRadioGroupFrame;
  vMemoFra: TAvidHookMemoFrame;
  vChkFra: TAvidHookCheckBoxFrame;
  vTop: Integer;
  vSortedArray: array of Integer;
  vFound: Boolean;
begin
  if (aIniXMLText <> '') then begin
    vIniXMLPBSApplet := NewPBSApplet;
    vIniXMLPBSApplet.OwnerDocument.XML.Text := aIniXMLText;
    vIniXMLPBSApplet := GetPBSApplet(vIniXMLPBSApplet.OwnerDocument);
  end
  else begin
    vIniXMLPBSApplet := LoadPBSApplet(aFileName);
  end;
  try
    aXMLVersion := vIniXMLPBSApplet.XML_Version;
    SetLength(vSortedArray, vIniXMLPBSApplet.Count);
    for i := 0 to vIniXMLPBSApplet.Count - 1 do begin
      vSortedArray[i] := 9999;
      for k := 0 to vIniXMLPBSApplet.Count - 1 do begin
        vFound := False;
        for ii := 0 to i - 1 do begin
          if (vSortedArray[ii] = k) then begin
            vFound := True;
            Break;
          end;
        end;

        if (not vFound) and ((vSortedArray[i] = 9999) or
          (vIniXMLPBSApplet.Items[vSortedArray[i]].ControlArea > vIniXMLPBSApplet.Items[k].ControlArea)) then begin
          vSortedArray[i] := k;
        end;
      end;
    end;

    vTop := 0;
    vMemoFra := nil;
    for i := 0 to vIniXMLPBSApplet.Count - 1 do begin
      k := vSortedArray[i];
      if (vIniXMLPBSApplet.Items[k].ControlIsVisible = 1) then begin
        case vIniXMLPBSApplet.Items[k].ControlType of
          CNTRL_COMBOBOX: begin
              vComboBoxFra := TAvidHookComboBozFrame.Create(AOwner);
              vComboBoxFra.Name := vComboBoxFra.Name + IntToStr(k);
              vComboBoxFra.ActivateFrame(AOwner, vIniXMLPBSApplet.Items[k], vTop);
            end;
          CNTRL_RADIOGROUP: begin
              vRadioGroupFra := TAvidHookRadioGroupFrame.Create(AOwner);
              vRadioGroupFra.Name := vRadioGroupFra.Name + IntToStr(k);
              vRadioGroupFra.ActivateFrame(AOwner, vIniXMLPBSApplet.Items[k], vTop);
            end;
          CNTRL_MEMO: begin
              vMemoFra := TAvidHookMemoFrame.Create(AOwner);
              vMemoFra.Name := vMemoFra.Name + IntToStr(k);
              vMemoFra.ActivateFrame(AOwner, vIniXMLPBSApplet.Items[k], vTop);
            end;
          CNTRL_CHECKBOX: begin
              vChkFra := TAvidHookCheckBoxFrame.Create(AOwner);
              vChkFra.Name := vChkFra.Name + IntToStr(k);
              vChkFra.ActivateFrame(AOwner, vIniXMLPBSApplet.Items[k], vTop);
            end;
        else begin
            MessageDlg('Unsupported Control Type ' + IntToStr(vIniXMLPBSApplet.Items[k].ControlType) + '.', mtError, [mbOK], 0);
          end;
        end;
      end;
    end;
    if Assigned(vMemoFra) then begin
      vMemoFra.Align := alClient;
    end;

  finally
    vIniXMLPBSApplet := nil;
  end;
end;

procedure InitAppletForm(AOwner: TControl; const aIniFilePath: string; var aXMLVersion: Integer);
var
  vFileName: string;
  vFNameArray: array[0..MAX_PATH] of char;
begin
  CoInitialize(nil);
  try
    FillChar(vFNameArray, sizeof(vFNameArray), #0);
    Windows.GetModuleFileName(hInstance, vFNameArray, sizeof(vFNameArray));
    vFileName := ChangeFileExt(vFNameArray, '.ini');
    if not FileExists(vFileName) then begin
      vFileName := aIniFilePath + ChangeFileExt(ExtractFileName(vFNameArray), '.ini');
    end;
    // Tmp_SaveIniFile(vFileName);
    DoCreateControls(AOwner, vFileName, '', aXMLVersion);
  finally
    CoUninitialize;
  end;
end;

const
  PARAM_SEPARATOR_MAIN = '|';

function GetParamsAsText(AOwner: TControl; const aXMLVersion: Integer): string;

  procedure _AddToResult(aStr: string; var aResult: string);
  begin
    if (aResult <> '') then begin
      aResult := aResult + PARAM_SEPARATOR_MAIN;
    end;
    aResult := aResult + aStr;
  end;

var
  i: Integer;
begin
  Result := '';
  if Assigned(AOwner) then begin
    for i := 0 to AOwner.ComponentCount - 1 do begin
      if (AOwner.Components[i] is TAvidHookBaseFrame) then begin
        _AddToResult((AOwner.Components[i] as TAvidHookBaseFrame).GetParamsAsText, Result);
      end;
    end;

    _AddToResult(IntToStr(aXMLVersion), Result);

    _AddToResult(GetHashCRC_AsHexString(Result), Result);
  end;
end;

procedure SetParamsAsText(AOwner: TControl; aValue: string; const aXMLVersion: Integer);

  function _GetRightPortion(var aStr: string): string;
  var
    i: Integer;
  begin
    i := Length(aStr);
    while i > 0 do begin
      if (PARAM_SEPARATOR_MAIN = aStr[i]) then begin
        Break;
      end;
      Dec(i);
    end;
    if (i > 0) then begin
      Result := Copy(aStr, i + 1, Length(aStr) - i);
      Delete(aStr, i, Length(aStr) - i + 1);
    end
    else begin
      Result := aStr;
      aStr := '';
    end;
  end;

var
  vStr, vSubStr: string;
  i: Integer;
  vApplied: Boolean;
  vCRCValid, vXMLVersionValid: Boolean;
begin
  vStr := Trim(aValue);

  vSubStr := _GetRightPortion(vStr);
  vCRCValid := (vSubStr = GetHashCRC_AsHexString(vStr));

  vSubStr := _GetRightPortion(vStr);
  vXMLVersionValid := (vSubStr = IntToStr(aXMLVersion));

  if (vStr <> '') then begin

    if not vCRCValid then begin
      MessageDlg('Checksum does not match.', mtWarning, [mbOk], 0);
    end;

    if not vXMLVersionValid then begin
      MessageDlg('XML Version is differ. (Expected: ' + IntToStr(aXMLVersion) + '; Current: ' + vSubStr + ')', mtWarning, [mbOk], 0);
    end;

    if Assigned(AOwner) then begin
      while (vStr <> '') do begin
        vSubStr := _GetRightPortion(vStr);
        if (vSubStr <> '') then begin
          vApplied := False;
          for i := 0 to AOwner.ComponentCount - 1 do begin
            if (AOwner.Components[i] is TAvidHookBaseFrame) and
              (AOwner.Components[i] as TAvidHookBaseFrame).SetParamsAsText(vSubStr) then begin
              vApplied := True;
              Break;
            end;
          end;
          if (not vApplied) then begin
            MessageDlg('Component not found. ("' + vSubStr + '")', mtWarning, [mbOk], 0);
          end;
        end;
      end;
    end;
  end;
end;

end.

