
{*********************************************************************}
{                                                                     }
{                          XML Data Binding                           }
{                                                                     }
{         Generated on: 10/15/2009 2:16:45 PM                         }
{       Generated from: P:\TVSD6\AvidInterplay\AvidPopupHookIni.xsd   }
{                                                                     }
{*********************************************************************}

unit AvidPopupHookIniIXM;

interface

uses xmldom, XMLDoc, XMLIntf;

type

{ Forward Decls }

  IXMLTPBSApplet = interface;
  IXMLTFraControl = interface;
  IXMLTValue = interface;

{ IXMLTPBSApplet }

  IXMLTPBSApplet = interface(IXMLNodeCollection)
    ['{E8565254-58BC-4FB9-BAE1-9C6732F8C289}']
    { Property Accessors }
    function Get_XML_Version: Integer;
    function Get_Items(Index: Integer): IXMLTFraControl;
    procedure Set_XML_Version(Value: Integer);
    { Methods & Properties }
    function Add: IXMLTFraControl;
    function Insert(const Index: Integer): IXMLTFraControl;
    property XML_Version: Integer read Get_XML_Version write Set_XML_Version;
    property Items[Index: Integer]: IXMLTFraControl read Get_Items; default;
  end;

{ IXMLTFraControl }

  IXMLTFraControl = interface(IXMLNodeCollection)
    ['{C4C5A2A4-5EAE-49AA-A372-452D4B795A80}']
    { Property Accessors }
    function Get_ControlID: WideString;
    function Get_ControlFieldName: WideString;
    function Get_ControlIsVisible: Integer;
    function Get_ControlIsRequired: Integer;
    function Get_ControlType: Integer;
    function Get_ControlArea: Integer;
    function Get_Label_: WideString;
    function Get_Items(Index: Integer): IXMLTValue;
    procedure Set_ControlID(Value: WideString);
    procedure Set_ControlFieldName(Value: WideString);
    procedure Set_ControlIsVisible(Value: Integer);
    procedure Set_ControlIsRequired(Value: Integer);
    procedure Set_ControlType(Value: Integer);
    procedure Set_ControlArea(Value: Integer);
    procedure Set_Label_(Value: WideString);
    { Methods & Properties }
    function Add: IXMLTValue;
    function Insert(const Index: Integer): IXMLTValue;
    property ControlID: WideString read Get_ControlID write Set_ControlID;
    property ControlFieldName: WideString read Get_ControlFieldName write Set_ControlFieldName;
    property ControlIsVisible: Integer read Get_ControlIsVisible write Set_ControlIsVisible;
    property ControlIsRequired: Integer read Get_ControlIsRequired write Set_ControlIsRequired;
    property ControlType: Integer read Get_ControlType write Set_ControlType;
    property ControlArea: Integer read Get_ControlArea write Set_ControlArea;
    property Label_: WideString read Get_Label_ write Set_Label_;
    property Items[Index: Integer]: IXMLTValue read Get_Items; default;
  end;

{ IXMLTValue }

  IXMLTValue = interface(IXMLNode)
    ['{5246E569-C8C2-42B2-B5B4-63BA3B727436}']
    { Property Accessors }
    function Get_Text: WideString;
    function Get_ID: Integer;
    procedure Set_Text(Value: WideString);
    procedure Set_ID(Value: Integer);
    { Methods & Properties }
    property Text: WideString read Get_Text write Set_Text;
    property ID: Integer read Get_ID write Set_ID;
  end;

{ Forward Decls }

  TXMLTPBSApplet = class;
  TXMLTFraControl = class;
  TXMLTValue = class;

{ TXMLTPBSApplet }

  TXMLTPBSApplet = class(TXMLNodeCollection, IXMLTPBSApplet)
  protected
    { IXMLTPBSApplet }
    function Get_XML_Version: Integer;
    function Get_Items(Index: Integer): IXMLTFraControl;
    procedure Set_XML_Version(Value: Integer);
    function Add: IXMLTFraControl;
    function Insert(const Index: Integer): IXMLTFraControl;
  public
    procedure AfterConstruction; override;
  end;

{ TXMLTFraControl }

  TXMLTFraControl = class(TXMLNodeCollection, IXMLTFraControl)
  protected
    { IXMLTFraControl }
    function Get_ControlID: WideString;
    function Get_ControlFieldName: WideString;
    function Get_ControlIsVisible: Integer;
    function Get_ControlIsRequired: Integer;
    function Get_ControlType: Integer;
    function Get_ControlArea: Integer;
    function Get_Label_: WideString;
    function Get_Items(Index: Integer): IXMLTValue;
    procedure Set_ControlID(Value: WideString);
    procedure Set_ControlFieldName(Value: WideString);
    procedure Set_ControlIsVisible(Value: Integer);
    procedure Set_ControlIsRequired(Value: Integer);
    procedure Set_ControlType(Value: Integer);
    procedure Set_ControlArea(Value: Integer);
    procedure Set_Label_(Value: WideString);
    function Add: IXMLTValue;
    function Insert(const Index: Integer): IXMLTValue;
  public
    procedure AfterConstruction; override;
  end;

{ TXMLTValue }

  TXMLTValue = class(TXMLNode, IXMLTValue)
  protected
    { IXMLTValue }
    function Get_Text: WideString;
    function Get_ID: Integer;
    procedure Set_Text(Value: WideString);
    procedure Set_ID(Value: Integer);
  end;

{ Global Functions }

function GetPBSApplet(Doc: IXMLDocument): IXMLTPBSApplet;
function LoadPBSApplet(const FileName: WideString): IXMLTPBSApplet;
function NewPBSApplet: IXMLTPBSApplet;

const
  TargetNamespace = '';

implementation

{ Global Functions }

function GetPBSApplet(Doc: IXMLDocument): IXMLTPBSApplet;
begin
  Result := Doc.GetDocBinding('PBSApplet', TXMLTPBSApplet, TargetNamespace) as IXMLTPBSApplet;
end;

function LoadPBSApplet(const FileName: WideString): IXMLTPBSApplet;
begin
  Result := LoadXMLDocument(FileName).GetDocBinding('PBSApplet', TXMLTPBSApplet, TargetNamespace) as IXMLTPBSApplet;
end;

function NewPBSApplet: IXMLTPBSApplet;
begin
  Result := NewXMLDocument.GetDocBinding('PBSApplet', TXMLTPBSApplet, TargetNamespace) as IXMLTPBSApplet;
end;

{ TXMLTPBSApplet }

procedure TXMLTPBSApplet.AfterConstruction;
begin
  RegisterChildNode('Items', TXMLTFraControl);
  ItemTag := 'Items';
  ItemInterface := IXMLTFraControl;
  inherited;
end;

function TXMLTPBSApplet.Get_XML_Version: Integer;
begin
  Result := AttributeNodes['XML_Version'].NodeValue;
end;

procedure TXMLTPBSApplet.Set_XML_Version(Value: Integer);
begin
  SetAttribute('XML_Version', Value);
end;

function TXMLTPBSApplet.Get_Items(Index: Integer): IXMLTFraControl;
begin
  Result := List[Index] as IXMLTFraControl;
end;

function TXMLTPBSApplet.Add: IXMLTFraControl;
begin
  Result := AddItem(-1) as IXMLTFraControl;
end;

function TXMLTPBSApplet.Insert(const Index: Integer): IXMLTFraControl;
begin
  Result := AddItem(Index) as IXMLTFraControl;
end;

{ TXMLTFraControl }

procedure TXMLTFraControl.AfterConstruction;
begin
  RegisterChildNode('Items', TXMLTValue);
  ItemTag := 'Items';
  ItemInterface := IXMLTValue;
  inherited;
end;

function TXMLTFraControl.Get_ControlID: WideString;
begin
  Result := AttributeNodes['ControlID'].Text;
end;

procedure TXMLTFraControl.Set_ControlID(Value: WideString);
begin
  SetAttribute('ControlID', Value);
end;

function TXMLTFraControl.Get_ControlFieldName: WideString;
begin
  Result := AttributeNodes['ControlFieldName'].Text;
end;

procedure TXMLTFraControl.Set_ControlFieldName(Value: WideString);
begin
  SetAttribute('ControlFieldName', Value);
end;

function TXMLTFraControl.Get_ControlIsVisible: Integer;
begin
  Result := AttributeNodes['ControlIsVisible'].NodeValue;
end;

procedure TXMLTFraControl.Set_ControlIsVisible(Value: Integer);
begin
  SetAttribute('ControlIsVisible', Value);
end;

function TXMLTFraControl.Get_ControlIsRequired: Integer;
begin
  Result := AttributeNodes['ControlIsRequired'].NodeValue;
end;

procedure TXMLTFraControl.Set_ControlIsRequired(Value: Integer);
begin
  SetAttribute('ControlIsRequired', Value);
end;

function TXMLTFraControl.Get_ControlType: Integer;
begin
  Result := AttributeNodes['ControlType'].NodeValue;
end;

procedure TXMLTFraControl.Set_ControlType(Value: Integer);
begin
  SetAttribute('ControlType', Value);
end;

function TXMLTFraControl.Get_ControlArea: Integer;
begin
  Result := AttributeNodes['ControlArea'].NodeValue;
end;

procedure TXMLTFraControl.Set_ControlArea(Value: Integer);
begin
  SetAttribute('ControlArea', Value);
end;

function TXMLTFraControl.Get_Label_: WideString;
begin
  Result := AttributeNodes['Label'].Text;
end;

procedure TXMLTFraControl.Set_Label_(Value: WideString);
begin
  SetAttribute('Label', Value);
end;

function TXMLTFraControl.Get_Items(Index: Integer): IXMLTValue;
begin
  Result := List[Index] as IXMLTValue;
end;

function TXMLTFraControl.Add: IXMLTValue;
begin
  Result := AddItem(-1) as IXMLTValue;
end;

function TXMLTFraControl.Insert(const Index: Integer): IXMLTValue;
begin
  Result := AddItem(Index) as IXMLTValue;
end;

{ TXMLTValue }

function TXMLTValue.Get_Text: WideString;
begin
  Result := AttributeNodes['Text'].Text;
end;

procedure TXMLTValue.Set_Text(Value: WideString);
begin
  SetAttribute('Text', Value);
end;

function TXMLTValue.Get_ID: Integer;
begin
  Result := AttributeNodes['ID'].NodeValue;
end;

procedure TXMLTValue.Set_ID(Value: Integer);
begin
  SetAttribute('ID', Value);
end;

end.