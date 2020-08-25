Imports System.IO

Public Class FrmCameraConfig
    Private modeAdd As Boolean
    Private fileName As String

    Public Enum FormMode
        Add = True
        Edit = False
    End Enum
    Public Sub New(mode As FormMode, fileName As String)
        InitializeComponent()
        Me.modeAdd = mode
        Me.fileName = fileName

        If Not modeAdd Then
            loadData()
        End If
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If txbName.Text = "" Then
            MsgBox("Please fill a name for your camera")
            Return
        End If
        If txbIP.Text = "" Then
            MsgBox("Please fill your camera IP")
            Return
        End If
        If txbPort.Text = "" Then
            MsgBox("Please fill your camera port")
            Return
        End If
        If Not IsNumeric(txbPort.Text) Then
            MsgBox("Your camera ip should be a number")
            Return
        End If
        If cmbProtocol.Text = "" Then
            MsgBox("Please select your camera protocol")
            Return
        End If

        If modeAdd Then
            createFile()
        End If
        saveConfig()
        Dispose()
    End Sub

    Public Sub createFile()
        Dim fileCreated As Boolean = False
        Do Until fileCreated
            Dim rand = New System.Random().Next(100000, 999999)
            fileName = frmMain.dataDir & "\Camera_" & rand & ".ini"
            If Not File.Exists(fileName) Then
                File.Create(fileName).Close()
                fileCreated = True
            End If
        Loop
    End Sub

    Public Sub saveConfig()
        Dim ini As New IniFile

        ini.Load(fileName)

        Dim section = ini.AddSection("CAMERA")
        section.AddKey("Name").Value = txbName.Text
        section.AddKey("IP").Value = txbIP.Text
        section.AddKey("Port").Value = txbPort.Text
        section.AddKey("Protocol").Value = cmbProtocol.Text

        ini.Save(fileName)
    End Sub

    Private Sub loadData()
        Dim camera As New Camera(fileName)
        txbName.Text = camera.name
        txbIP.Text = camera.ip
        txbPort.Text = camera.port
        If camera.protocol = Camera.ProtocolType.ViscaTCP Then
            cmbProtocol.Text = "VISCA TCP"
        End If
    End Sub
End Class