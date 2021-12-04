Imports System.Net
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Public Class Onvif
    Dim mediaClient As OnvifMedia10.MediaClient
    Dim ptzClient As OnvifPTZService.PTZClient
    Dim profile As OnvifMedia10.Profile
    Dim ptzSpeed As OnvifPTZService.PTZSpeed
    Dim ptzVector As OnvifPTZService.PTZVector
    Dim options As OnvifPTZService.PTZConfigurationOptions
    Dim configs As OnvifPTZService.PTZConfiguration()

    Dim relative As Boolean = True
    Public Property initialised As Boolean = False

    Dim presets As OnvifPTZService.PTZPreset()

    Public Property StreamURI As String
    Public Property ErrorMessage As String

    Public Const MIN_SPEED = 1
    Public Const MAX_SPEED = 10


    Function Initialise(cameraAddress As String, port As String, userName As String, password As String) As Boolean
        Dim result As Boolean = False

        Try
            Dim messageElement As New TextMessageEncodingBindingElement()
            messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)

            Dim httpBinding As New HttpTransportBindingElement()
            httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest

            Dim bind As New CustomBinding(messageElement, httpBinding)
            bind.OpenTimeout = New TimeSpan(0, 0, 5)
            bind.SendTimeout = New TimeSpan(0, 0, 5)
            bind.ReceiveTimeout = New TimeSpan(0, 0, 5)

            mediaClient = New OnvifMedia10.MediaClient(bind,
                    New EndpointAddress($"http://{cameraAddress}:{port}/onvif/Media"))
            mediaClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel =
                    System.Security.Principal.TokenImpersonationLevel.Impersonation
            mediaClient.ClientCredentials.HttpDigest.ClientCredential.UserName = userName
            mediaClient.ClientCredentials.HttpDigest.ClientCredential.Password = password
            ptzClient = New OnvifPTZService.PTZClient(bind,
                      New EndpointAddress($"http://{cameraAddress}:{port}/onvif/PTZ"))
            ptzClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel =
                      System.Security.Principal.TokenImpersonationLevel.Impersonation
            ptzClient.ClientCredentials.HttpDigest.ClientCredential.UserName = userName
            ptzClient.ClientCredentials.HttpDigest.ClientCredential.Password = password

            Dim profs = mediaClient.GetProfiles()
            profile = mediaClient.GetProfile(profs(0).token)

            configs = ptzClient.GetConfigurations()

            options = ptzClient.GetConfigurationOptions(configs(0).token)

            'Initialise ptzSpeed
            ptzSpeed = New OnvifPTZService.PTZSpeed()
            ptzSpeed.PanTilt = New OnvifPTZService.Vector2D()
            ptzSpeed.Zoom = New OnvifPTZService.Vector1D()
            ptzSpeed.PanTilt.x = 0
            ptzSpeed.PanTilt.y = 0
            ptzSpeed.PanTilt.space = options.Spaces.ContinuousPanTiltVelocitySpace(0).URI
            ptzSpeed.Zoom = New OnvifPTZService.Vector1D()
            ptzSpeed.Zoom.x = 0
            ptzSpeed.Zoom.space = options.Spaces.ContinuousZoomVelocitySpace(0).URI


            'Initialise ptzVector
            ptzVector = New OnvifPTZService.PTZVector()
            ptzVector.PanTilt = New OnvifPTZService.Vector2D()
            ptzVector.PanTilt.x = 0
            ptzVector.PanTilt.y = 0
            ptzVector.PanTilt.space = options.Spaces.RelativePanTiltTranslationSpace(0).URI


            Dim streamSetup As New OnvifMedia10.StreamSetup
            streamSetup.Transport = New OnvifMedia10.Transport
            streamSetup.Transport.Protocol = OnvifMedia10.TransportProtocol.RTSP

            StreamURI = mediaClient.GetStreamUri(streamSetup, profile.token).Uri

            ErrorMessage = ""
            result = True
            initialised = True

        Catch ex As Exception
            ErrorMessage = ex.Message
        End Try

        Return result
    End Function

    Enum MoveDirection
        Up
        Down
        Left
        Right
        UpLeft
        UpRight
        DownLeft
        DownRight
    End Enum

    Sub Move(direction As MoveDirection, speed As Single)
        speed = speed * 0.1
        If initialised Then
            ptzSpeed.PanTilt.x = 0
            ptzSpeed.PanTilt.y = 0
            ptzSpeed.Zoom.x = 0

            Select Case direction
                Case MoveDirection.Up
                    ptzSpeed.PanTilt.y = speed
                Case MoveDirection.Down
                    ptzSpeed.PanTilt.y = -speed
                Case MoveDirection.Left
                    ptzSpeed.PanTilt.x = -speed
                Case MoveDirection.Right
                    ptzSpeed.PanTilt.x = speed
                Case MoveDirection.UpLeft
                    ptzSpeed.PanTilt.x = -speed
                    ptzSpeed.PanTilt.y = speed
                Case MoveDirection.UpRight
                    ptzSpeed.PanTilt.x = speed
                    ptzSpeed.PanTilt.y = speed
                Case MoveDirection.DownLeft
                    ptzSpeed.PanTilt.x = -speed
                    ptzSpeed.PanTilt.y = -speed
                Case MoveDirection.DownRight
                    ptzSpeed.PanTilt.x = speed
                    ptzSpeed.PanTilt.y = -speed
            End Select
            ptzClient.ContinuousMoveAsync(profile.token, ptzSpeed, "1")
        End If
    End Sub
    Sub ZoomIn(speed As Single)
        If initialised Then
            ptzSpeed.PanTilt.x = 0
            ptzSpeed.PanTilt.y = 0
            ptzSpeed.Zoom.x = speed

            ptzClient.ContinuousMoveAsync(profile.token, ptzSpeed, "1")
        End If
    End Sub

    Sub ZoomOut(speed As Single)
        If initialised Then
            ptzSpeed.PanTilt.x = 0
            ptzSpeed.PanTilt.y = 0
            ptzSpeed.Zoom.x = -speed

            ptzClient.ContinuousMoveAsync(profile.token, ptzSpeed, "1")
        End If
    End Sub

    Sub StopMotion()
        If initialised Then
            ptzClient.Stop(profile.token, True, True)
        End If
    End Sub

    Public Function GetPresets() As List(Of String)
        Dim presetsList As New List(Of String)

        presets = ptzClient.GetPresets(profile.token)
        For Each preset In presets
            presetsList.Add(preset.Name)
        Next

        Return presetsList
    End Function

    Public Sub SetPreset(index As Integer, name As String)
        GetPresets()
        ptzClient.SetPreset(profile.token, name, presets(index).token)
    End Sub

    Public Sub MoveToPreset(index As Integer, speed As Single)
        GetPresets()
        speed = speed * 0.1

        ptzSpeed.PanTilt.x = speed
        ptzSpeed.PanTilt.y = speed
        ptzSpeed.Zoom.x = speed

        ptzClient.GotoPresetAsync(profile.token, presets(index).token, ptzSpeed)
    End Sub
End Class
