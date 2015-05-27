(**

  Purpose: Avid Hook Base Frame Class

  Copyright© 2001-2009, BroadView Software Inc. All rights reserved.
*)
unit AvidHookBaseFra;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;

type
  TAvidHookBaseFrame = class(TFrame)
  protected
    FControlID: string;
    function GetTextValue: string; virtual;
    function GetIDValue: string; virtual;
    function GetValue: Variant; virtual;
    procedure SetTextValue(aValue: string); virtual;
    procedure SetIDValue(aValue: string); virtual;
    procedure SetValue(const aValue: Variant); virtual;
  public
    function GetParamsAsText: string;
    function SetParamsAsText(aValue: string): Boolean;
    property Value: Variant read GetValue write SetValue;
  end;

const PARAM_SEPARATOR = '~';
function VarToIntDef(const aVar: Variant; const aInt: Integer = 0): Integer;

implementation

{$R *.dfm}

function TAvidHookBaseFrame.GetIDValue: string;
begin
  Result := '';
end;

function TAvidHookBaseFrame.GetParamsAsText: string;
begin
  Result := FControlID + PARAM_SEPARATOR + GetTextValue + PARAM_SEPARATOR + GetIDValue;
end;

function TAvidHookBaseFrame.GetTextValue: string;
begin
  Result := '';
end;

function TAvidHookBaseFrame.GetValue: Variant;
begin
  Result := NULL;
end;

procedure TAvidHookBaseFrame.SetIDValue(aValue: string);
begin

end;

function TAvidHookBaseFrame.SetParamsAsText(aValue: string): Boolean;

  function _GetLeftPortion(var aStr: string): string;
  var
    i: Integer;
  begin
    i := Pos(PARAM_SEPARATOR, aStr);
    if (i > 0) then begin
      Result := Copy(aStr, 1, i - 1);
      Delete(aStr, 1, i);
    end
    else begin
      Result := aStr;
      aStr := '';
    end;
  end;

var
  vStr, vSubStr: string;
begin
  vStr := aValue;

  vSubStr := Trim(_GetLeftPortion(vStr));
  if (SameText(vSubStr, FControlID)) then begin

    vSubStr := _GetLeftPortion(vStr);
    SetTextValue(vSubStr);

    vSubStr := _GetLeftPortion(vStr);
    SetIDValue(vSubStr);

    Result := True;
  end
  else begin
    Result := False;
  end;
end;

procedure TAvidHookBaseFrame.SetTextValue(aValue: string);
begin

end;

procedure TAvidHookBaseFrame.SetValue(const aValue: Variant);
begin
  //
end;

function VarToIntDef(const aVar: Variant; const aInt: Integer = 0): Integer;
begin
  if VarIsNumeric(aVar) then
    Result := Round(aVar)
  else
    Result := aInt;
end;

end.
