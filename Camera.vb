Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Public Class Camera
    Private ini As New IniFile
    Private Const MAX_PRESETS = 126

    Public iniFileName As String
    Public name As String
    Public ip As String
    Public port As String
    Public protocol As ProtocolType

    Public panPosition As Int16
    Public tiltPosition As Int16
    Public zoomPosition As Int16

    Public focusModeAuto As Boolean
    Public focusPosition As Int16

    Public userPTSpeed As Integer = Visca.PAN_MIN_SPEED
    Public userZoomSpeed As Integer = Visca.ZOOM_MIN_SPEED

    Public presets(MAX_PRESETS) As CameraPreset


    Enum ProtocolType
        ViscaTCP = 1
    End Enum

    Public Sub New(iniFileName)
        Me.iniFileName = iniFileName
        LoadIni()
    End Sub

    Private Sub LoadIni()
        ini.Load(iniFileName)

        Dim cameraSection = ini.GetOrAddSection("CAMERA")
        name = cameraSection.GetKey("Name", "").GetValue
        ip = cameraSection.GetKey("IP", "").GetValue
        port = cameraSection.GetKey("Port", "").GetValue
        protocol = cameraSection.GetKey("Protocol", ProtocolType.ViscaTCP).GetValue

        Dim userConfSection = ini.GetOrAddSection("USER_CONF")
        userPTSpeed = userConfSection.GetKey("PTSpeed", Visca.PAN_MIN_SPEED).Value()
        userZoomSpeed = userConfSection.GetKey("ZoomSpeed", Visca.ZOOM_MIN_SPEED).Value()

        LoadPresets()
    End Sub

    Private Sub SaveIni()
        Dim cameraSection = ini.AddSection("CAMERA")
        cameraSection.AddKey("Name").Value = name
        cameraSection.AddKey("IP").Value = ip
        cameraSection.AddKey("Port").Value = port
        cameraSection.AddKey("Protocol").Value = protocol

        Dim userConfSection = ini.AddSection("USER_CONF")
        userConfSection.AddKey("PTSpeed").Value = userPTSpeed
        userConfSection.AddKey("ZoomSpeed").Value = userZoomSpeed

        SavePresets()

        ini.Save(iniFileName)
    End Sub

    Public Sub SaveSettings()
        SaveIni()
    End Sub

    Public Sub LoadPresets()
        For i As Integer = 0 To MAX_PRESETS
            Dim presetSection = ini.GetSection("PRESET_" & i)

            If presetSection IsNot Nothing Then
                Dim cameraPreset As New CameraPreset
                cameraPreset.id = i
                cameraPreset.name = presetSection.GetKey("Name", "Preset " & i).Value
                cameraPreset.pan = presetSection.GetKey("P", 0).Value
                cameraPreset.tilt = presetSection.GetKey("T", 0).Value
                cameraPreset.zoom = presetSection.GetKey("Z", 0).Value
                presets(i) = cameraPreset
            End If
        Next
    End Sub

    Private Sub SavePresets()
        For i As Integer = 0 To MAX_PRESETS
            If presets(i) IsNot Nothing Then
                Dim presetSection = ini.GetOrAddSection("PRESET_" & i)
                Dim cameraPreset = presets(i)

                presetSection.AddKey("Name").Value = cameraPreset.name
                presetSection.AddKey("P").Value = cameraPreset.pan
                presetSection.AddKey("T").Value = cameraPreset.tilt
                presetSection.AddKey("Z").Value = cameraPreset.zoom
            End If
        Next
    End Sub

    Public Function AddPreset(preset As CameraPreset) As Integer
        For i As Integer = 0 To MAX_PRESETS
            If presets(i) Is Nothing Then
                preset.id = i
                presets(i) = preset
                SaveSettings()
                Return i
            End If
        Next
        Return Nothing
    End Function

    Public Sub UpdatePreset(preset As CameraPreset)
        presets(preset.id) = preset
        SaveSettings()
    End Sub

    Public Sub RemovePreset(id As Integer)
        ini.RemoveSection("PRESET_" & presets(id).id)
        presets(id) = Nothing
        SaveSettings()
    End Sub
End Class
