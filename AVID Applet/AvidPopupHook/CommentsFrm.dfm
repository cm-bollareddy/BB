object CommentsForm: TCommentsForm
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = ' BroadView Clip Comments'
  ClientHeight = 343
  ClientWidth = 293
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object pnlButtons: TPanel
    Left = 0
    Top = 302
    Width = 293
    Height = 41
    Align = alBottom
    TabOrder = 0
    DesignSize = (
      293
      41)
    object OkButton: TButton
      Left = 158
      Top = 9
      Width = 56
      Height = 25
      Anchors = [akRight, akBottom]
      Caption = '&OK'
      Default = True
      ModalResult = 1
      TabOrder = 0
    end
    object CancelButton: TButton
      Left = 223
      Top = 9
      Width = 57
      Height = 25
      Anchors = [akRight, akBottom]
      Cancel = True
      Caption = '&Cancel'
      ModalResult = 2
      TabOrder = 1
    end
  end
  object pnlMain222: TPanel
    Left = 0
    Top = 0
    Width = 293
    Height = 302
    Align = alClient
    BevelOuter = bvLowered
    TabOrder = 1
  end
end
