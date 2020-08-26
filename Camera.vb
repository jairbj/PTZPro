Public Class Camera
    Public iniFileName As String
    Public name As String
    Public ip As String
    Public port As String
    Public protocol As ProtocolType

    Public panPosition As Int16
    Public tiltPosition As Int16
    Public zoomPosition As Int16

    Enum ProtocolType
        ViscaTCP = 1
    End Enum

    Public Sub New(iniFileName)
        Me.iniFileName = iniFileName
        LoadIni()
    End Sub

    Private Sub LoadIni()
        Dim ini As New IniFile

        ini.Load(iniFileName)
        Dim cameraSection = ini.GetSection("CAMERA")
        name = cameraSection.GetKey("Name").GetValue
        ip = cameraSection.GetKey("IP").GetValue
        port = cameraSection.GetKey("Port").GetValue
        If cameraSection.GetKey("Protocol").GetValue = "VISCA TCP" Then
            protocol = ProtocolType.ViscaTCP
        End If
    End Sub
End Class
