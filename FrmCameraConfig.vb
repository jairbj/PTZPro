Imports System.IO

Public Class FrmCameraConfig
    Private modeAdd As Boolean
    Private fileName As String

    Public Enum FormMode
        Add = True
        Edit = False
    End Enum
    Public Sub New(mode As FormMode, fileName As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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
        If txbVmixUrl.Text = "" Then
            numInputNumber.Value = 0
            txbVmixUsername.Text = ""
            txbVmixPassword.Text = ""
        Else
            Dim validatedUri As Uri = Nothing
            If Not Uri.TryCreate(txbVmixUrl.Text, UriKind.Absolute, validatedUri) Then
                MsgBox("Please fill a valid Vmix URL")
                Return
            End If
            If numInputNumber.Value = 0 Then
                MsgBox("Vmix input number cannot be zero")
                Return
            End If
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
        Dim camera As New Camera(fileName)

        camera.name = txbName.Text
        camera.ip = txbIP.Text
        camera.port = txbPort.Text
        Select Case cmbProtocol.Text
            Case "VISCA TCP"
                camera.protocol = Camera.ProtocolType.ViscaTCP
        End Select
        camera.vmixApiUrl = txbVmixUrl.Text
        camera.vmixInputNumber = numInputNumber.Value
        camera.vmixUsername = txbVmixUsername.Text
        camera.vmixPassword = txbVmixPassword.Text

        camera.SaveSettings()
    End Sub

    Private Sub loadData()
        Dim camera As New Camera(fileName)
        txbName.Text = camera.name
        txbIP.Text = camera.ip
        txbPort.Text = camera.port
        If camera.protocol = Camera.ProtocolType.ViscaTCP Then
            cmbProtocol.Text = "VISCA TCP"
        End If
        txbVmixUrl.Text = camera.vmixApiUrl
        numInputNumber.Value = camera.vmixInputNumber
        txbVmixUsername.Text = camera.vmixUsername
        txbVmixPassword.Text = camera.vmixPassword

    End Sub

    Private Sub FrmCameraConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class