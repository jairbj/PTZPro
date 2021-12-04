
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml

Public Class FrmCameraControl
    Dim tcpClient As System.Net.Sockets.TcpClient
    Dim networkStream As NetworkStream
    Dim visca As Visca = New Visca(1)
    Dim onvif As Onvif = Nothing
    Dim camera As Camera
    Dim vmixWebClient As New Net.WebClient()

    Dim isUpdatingPosition As Boolean = False

    Private Enum CameraStatus
        None = 0
        Preview = 1
        Active = 2
    End Enum

    Public Sub New(camera As Camera)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.camera = camera
        AddHandler vmixWebClient.DownloadStringCompleted, AddressOf CheckVmixActivePreview

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                trkPTSpeed.Maximum = Visca.PAN_MAX_SPEED
                trkZoomSpeed.Maximum = Visca.ZOOM_MAX_SPEED
            Case Camera.ProtocolType.Onvif
                trkPTSpeed.Maximum = Onvif.MAX_SPEED
                trkZoomSpeed.Maximum = Onvif.MAX_SPEED
                btChckFocusLock.Enabled = False
        End Select

        tcpConnect()
        tmrStatus.Start()
    End Sub

    Private Sub tcpConnect()
        btConnectDisconnect.Enabled = False
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                Try
                    tcpClient = New System.Net.Sockets.TcpClient()
                    tcpClient.Connect(camera.ip, camera.port)
                    networkStream = tcpClient.GetStream()
                    ' Sets 500ms timeout
                    networkStream.ReadTimeout = 500
                    focusAuto()
                    btConnectDisconnect.Text = "Disconnect"
                    lblStatus.Text = "Connected"
                    btConnectDisconnect.Enabled = True
                Catch ex As Exception
                    lblStatus.Text = "Error"
                End Try
            Case Camera.ProtocolType.Onvif
                onvif = New Onvif()
                If onvif.Initialise(camera.ip, camera.port, "admin", "") Then
                    btConnectDisconnect.Text = "Disconnect"
                    lblStatus.Text = "Connected"
                    btConnectDisconnect.Enabled = True
                Else
                    lblStatus.Text = onvif.ErrorMessage
                End If
        End Select

    End Sub

    Private Sub tcpDisconnect()
        btConnectDisconnect.Enabled = False
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                If tcpClient.Connected Then
                    networkStream.Close()
                    tcpClient.Close()
                End If
            Case Camera.ProtocolType.Onvif
                onvif = Nothing
                onvif = New Onvif()
        End Select
        lblStatus.Text = "Disconnected"
        btConnectDisconnect.Text = "Connect"
        btConnectDisconnect.Enabled = True
    End Sub
    Private Sub btConnectDisconnect_Click(sender As Object, e As EventArgs) Handles btConnectDisconnect.Click

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                If tcpClient.Connected Then
                    tcpDisconnect()
                Else
                    tcpConnect()
                End If
            Case Camera.ProtocolType.Onvif
                If onvif.initialised Then
                    tcpDisconnect()
                Else
                    tcpConnect()
                End If
        End Select

    End Sub

    Private Sub moveDirection(sender As Object, e As MouseEventArgs) Handles _
            btUp.MouseDown, btDown.MouseDown, btLeft.MouseDown, btRight.MouseDown,
            btUpLeft.MouseDown, btUpRight.MouseDown,
            btDownLeft.MouseDown, btDownRight.MouseDown

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                Dim horizontalDirection = Visca.PTHorizontalDirection.StopMove
                Dim verticalDirection = Visca.PTVerticalDirection.StopMove

                Dim speed As Int16
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Visca.PAN_MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Visca.PAN_MIN_SPEED
                Else
                    speed = trkPTSpeed.Value
                End If


                Select Case True
                    Case sender Is btUp
                        verticalDirection = Visca.PTVerticalDirection.Up
                    Case sender Is btDown
                        verticalDirection = Visca.PTVerticalDirection.Down
                    Case sender Is btLeft
                        horizontalDirection = Visca.PTHorizontalDirection.Left
                    Case sender Is btRight
                        horizontalDirection = Visca.PTHorizontalDirection.Right
                    Case sender Is btUpLeft
                        horizontalDirection = Visca.PTHorizontalDirection.Left
                        verticalDirection = Visca.PTVerticalDirection.Up
                    Case sender Is btUpRight
                        horizontalDirection = Visca.PTHorizontalDirection.Right
                        verticalDirection = Visca.PTVerticalDirection.Up
                    Case sender Is btDownLeft
                        horizontalDirection = Visca.PTHorizontalDirection.Left
                        verticalDirection = Visca.PTVerticalDirection.Down
                    Case sender Is btDownRight
                        horizontalDirection = Visca.PTHorizontalDirection.Right
                        verticalDirection = Visca.PTVerticalDirection.Down
                End Select

                focusAuto()
                'Debug.WriteLine(speed)
                Dim move = visca.PTMove(horizontalDirection, verticalDirection,
                                speed, speed)
                networkWriter(move)
            Case Camera.ProtocolType.Onvif
                If Not onvif.initialised Then
                    Return
                End If

                Dim speed As Int16
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Onvif.MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Onvif.MIN_SPEED
                Else
                    speed = trkPTSpeed.Value
                End If

                Select Case True
                    Case sender Is btUp
                        onvif.Move(Onvif.MoveDirection.Up, speed)
                    Case sender Is btDown
                        onvif.Move(Onvif.MoveDirection.Down, speed)
                    Case sender Is btLeft
                        onvif.Move(Onvif.MoveDirection.Left, speed)
                    Case sender Is btRight
                        onvif.Move(Onvif.MoveDirection.Right, speed)
                    Case sender Is btUpLeft
                        onvif.Move(Onvif.MoveDirection.UpLeft, speed)
                    Case sender Is btUpRight
                        onvif.Move(Onvif.MoveDirection.UpRight, speed)
                    Case sender Is btDownLeft
                        onvif.Move(Onvif.MoveDirection.DownLeft, speed)
                    Case sender Is btDownRight
                        onvif.Move(Onvif.MoveDirection.DownRight, speed)
                End Select
        End Select

    End Sub


    Private Sub stopMove(sender As Object, e As MouseEventArgs) Handles _
            btUp.MouseUp, btDown.MouseUp, btLeft.MouseUp, btRight.MouseUp,
            btUpLeft.MouseUp, btUpRight.MouseUp,
            btDownLeft.MouseUp, btDownRight.MouseUp

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                networkWriter(visca.PTStop)
            Case Camera.ProtocolType.Onvif
                onvif.StopMotion()
        End Select

    End Sub

    Private Sub FrmCameraContol_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tcpDisconnect()
        End
    End Sub

    Private Sub zoomMove(sender As Object, e As MouseEventArgs) Handles _
        btZoomPlus.MouseDown, btZoomMinus.MouseDown

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                Dim direction As Visca.ZoomDirection
                Dim speed As Int16
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Visca.ZOOM_MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Visca.ZOOM_MIN_SPEED
                Else
                    speed = trkZoomSpeed.Value
                End If

                Select Case True
                    Case sender Is btZoomPlus
                        direction = Visca.ZoomDirection.Plus
                    Case sender Is btZoomMinus
                        direction = Visca.ZoomDirection.Minus
                End Select

                focusAuto()
                Dim move = visca.ZoomMove(direction, speed)
                networkWriter(move)
            Case Camera.ProtocolType.Onvif
                Dim speed As Int16
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Onvif.MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Onvif.MIN_SPEED
                Else
                    speed = trkZoomSpeed.Value
                End If

                Select Case True
                    Case sender Is btZoomPlus
                        onvif.ZoomIn(speed)
                    Case sender Is btZoomMinus
                        onvif.ZoomOut(speed)
                End Select

        End Select

    End Sub

    Private Sub zoomStop(sender As Object, e As MouseEventArgs) Handles _
        btZoomPlus.MouseUp, btZoomMinus.MouseUp

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                networkWriter(visca.ZoomStop())
            Case Camera.ProtocolType.Onvif
                onvif.StopMotion()
        End Select

    End Sub

    Private Sub networkWriter(data As Byte())
        If tcpClient.Connected Then
            networkStream.Write(data, 0, data.Length)
        End If
    End Sub

    Private Sub tmrStatus_Tick(sender As Object, e As EventArgs) Handles tmrStatus.Tick
        If tcpClient IsNot Nothing Then
            UpdatePosition()
        End If
        If camera.vmixEnabled Then
            UpdateVmix()
        End If
    End Sub

    Private Sub UpdateVmix()
        Try
            If vmixWebClient.IsBusy Then
                Return
            End If

            vmixWebClient.Credentials = New Net.NetworkCredential(camera.vmixUsername, camera.vmixPassword)
            vmixWebClient.DownloadStringAsync(New Uri(camera.vmixApiUrl + "/api"))
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Private Sub CheckVmixActivePreview _
        (ByVal sender As Object,
         ByVal e As Net.DownloadStringCompletedEventArgs)
        Try
            If e.Error IsNot Nothing Then
                SetCameraStatusColor(CameraStatus.None)
                Return
            End If
            Dim xmlResponse As String = e.Result

            If xmlResponse = "" Then
                Return
            End If
            Dim xmlDoc As New XmlDocument()
            xmlDoc.LoadXml(xmlResponse)
            Dim preview = xmlDoc.DocumentElement.SelectNodes("/vmix/preview").Item(0).InnerText
            Dim active = xmlDoc.DocumentElement.SelectNodes("/vmix/active").Item(0).InnerText

            If camera.vmixInputNumber = active Then
                SetCameraStatusColor(CameraStatus.Active)
            ElseIf camera.vmixInputNumber = preview Then
                SetCameraStatusColor(CameraStatus.Preview)
            Else
                SetCameraStatusColor(CameraStatus.None)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            SetCameraStatusColor(CameraStatus.None)
        End Try
    End Sub

    Private Sub SetCameraStatusColor(cameraStatus As CameraStatus)
        Select Case cameraStatus
            Case CameraStatus.None
                lblCameraTitle.BackColor = Color.Transparent
                lblCameraTitle.ForeColor = Color.Black
            Case CameraStatus.Preview
                lblCameraTitle.BackColor = Color.Orange
                lblCameraTitle.ForeColor = Color.White
            Case CameraStatus.Active
                lblCameraTitle.BackColor = Color.Green
                lblCameraTitle.ForeColor = Color.White
        End Select

        lblCamera.BackColor = lblCameraTitle.BackColor
        lblCamera.ForeColor = lblCameraTitle.ForeColor
    End Sub

    Private Sub UpdatePosition()
        If camera.protocol = Camera.ProtocolType.Onvif Then
            Return
        End If
        If isUpdatingPosition Then
            Return
        End If
        isUpdatingPosition = True
        If tcpClient.Connected Then
            Dim response = inquireData(visca.InquirePanTiltPosition, 11)
            If Not response Is Nothing Then
                camera.panPosition = visca.parsePanPosition(response)
                camera.tiltPosition = visca.parseTiltPosition(response)
                'Debug.WriteLine(BitConverter.ToString(response))
            End If

            response = inquireData(visca.InquireZoomPosition, 7)
            If Not response Is Nothing Then
                'Debug.WriteLine(BitConverter.ToString(response).Replace("-", ""))
                camera.zoomPosition = visca.parseZoomPosition(response)
            End If

            response = inquireData(visca.InquireFocusMode, 4)
            If Not response Is Nothing Then
                If response(2) = Visca.FocusMode.Auto Then
                    camera.focusModeAuto = True
                Else
                    camera.focusModeAuto = False
                End If
            End If

            response = inquireData(visca.InquireFocusPos, 7)
            If Not response Is Nothing Then
                camera.focusPosition = visca.parseFocusPosition(response)
            End If

            statusPan.Text = "P:" & camera.panPosition
            statusTilt.Text = "T:" & camera.tiltPosition
            statusZoom.Text = "Z:" & camera.zoomPosition
            statusFocus.Text = "F:" & camera.focusPosition
            If camera.focusModeAuto Then
                statusFocus.Text = statusFocus.Text & " (Auto)"
            Else
                statusFocus.Text = statusFocus.Text & " (Manual)"
            End If

        End If
        isUpdatingPosition = False
    End Sub

    Private Function inquireData(data As Byte(), responseSize As Integer) As Byte()

        Dim bytes(tcpClient.ReceiveBufferSize) As Byte
        Try
            networkStream.Write(data, 0, data.Length)
            networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
        Catch ioex As IO.IOException

        End Try
        Return visca.getResponse(bytes, responseSize)
    End Function

    Private Sub trkPTSpeed_ValueChanged(sender As Object, e As EventArgs) Handles trkPTSpeed.ValueChanged
        camera.userPTSpeed = trkPTSpeed.Value
        camera.SaveSettings()
    End Sub
    Private Sub trkZoomSpeed_ValueChanged(sender As Object, e As EventArgs) Handles trkZoomSpeed.ValueChanged
        camera.userZoomSpeed = trkZoomSpeed.Value
        camera.SaveSettings()
    End Sub

    Private Sub FrmCameraContol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        trkPTSpeed.Value = camera.userPTSpeed
        trkZoomSpeed.Value = camera.userZoomSpeed
        lblCamera.Text = camera.name

        LoadPresets()
    End Sub

    Private Sub LoadPresets()
        lstvPresets.Clear()
        For Each preset In camera.presets
            If preset IsNot Nothing Then
                Dim li As New ListViewItem
                li.Tag = preset
                li.Text = preset.name
                lstvPresets.Items.Add(li)
            End If
        Next
    End Sub

    Private Sub ctxMenuPresets_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxMenuPresets.Opening
        ' Doesn't open the context menu if no item is selected
        e.Cancel = (lstvPresets.SelectedItems.Count < 1)
    End Sub

    Private Sub DeletePresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePresetToolStripMenuItem.Click
        Dim preset As CameraPreset = lstvPresets.SelectedItems(0).Tag
        camera.RemovePreset(preset.id)
        camera.SaveSettings()
        LoadPresets()
    End Sub

    Private Sub lstvPresets_DoubleClick(sender As Object, e As EventArgs) Handles lstvPresets.DoubleClick
        If lstvPresets.SelectedItems.Count < 1 Then
            Return
        End If

        Dim preset As CameraPreset = lstvPresets.SelectedItems(0).Tag

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                Dim speed As Byte
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Visca.PAN_MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Visca.PAN_MIN_SPEED
                Else
                    speed = trkPTSpeed.Value
                End If

                focusAuto()

                networkWriter(visca.PresetSpeed(speed))
                networkWriter(visca.GetPreset(preset.id))
            Case Camera.ProtocolType.Onvif
                Dim speed As Int16
                If My.Computer.Keyboard.ShiftKeyDown Then
                    speed = Onvif.MAX_SPEED
                ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                    speed = Onvif.MIN_SPEED
                Else
                    speed = trkPTSpeed.Value
                End If
                onvif.MoveToPreset(preset.id, speed)
        End Select

    End Sub

    Private Sub EditPresetNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPresetNameToolStripMenuItem.Click
        Dim newName As String = InputBox("New preset name",, "")
        If newName = "" Then
            MsgBox("Preset name can't be empty")
            Return
        End If

        Dim preset As CameraPreset = lstvPresets.SelectedItems(0).Tag
        preset.name = newName
        camera.UpdatePreset(preset)
        LoadPresets()
    End Sub

    Private Sub btSavePreset_Click(sender As Object, e As EventArgs) Handles btSavePreset.Click
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                If Not tcpClient.Connected() Then
                    Return
                End If
            Case Camera.ProtocolType.Onvif
                If Not onvif.initialised Then
                    Return
                End If
        End Select


        Dim name As String = InputBox("Set a preset name",, "")
        If name = "" Then
            MsgBox("Preset name can't be empty")
            Return
        End If

        UpdatePosition()

        Dim preset As New CameraPreset
        preset.name = name
        preset.pan = camera.panPosition
        preset.tilt = camera.tiltPosition
        preset.zoom = camera.zoomPosition

        Dim presetId = camera.AddPreset(preset)

        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                networkWriter(visca.SetPreset(presetId))
            Case Camera.ProtocolType.Onvif
                onvif.SetPreset(presetId, preset.name)
        End Select

        LoadPresets()
    End Sub

    Private Sub UpdatePresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePresetToolStripMenuItem.Click
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                If Not tcpClient.Connected() Then
                    Return
                End If
            Case Camera.ProtocolType.Onvif
                If Not onvif.initialised Then
                    Return
                End If
        End Select

        UpdatePosition()

        Dim preset As CameraPreset = lstvPresets.SelectedItems(0).Tag
        preset.pan = camera.panPosition
        preset.tilt = camera.tiltPosition
        preset.zoom = camera.zoomPosition

        camera.UpdatePreset(preset)
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                networkWriter(visca.SetPreset(preset.id))
            Case Camera.ProtocolType.Onvif
                onvif.SetPreset(preset.id, preset.name)
        End Select
        LoadPresets()
    End Sub

    Private Sub focusAuto(Optional setAuto As Boolean = True)
        If setAuto Then
            btChckFocusLock.Checked = False
        Else
            btChckFocusLock.Checked = True
        End If
    End Sub

    Private Sub btCenter_MouseDown(sender As Object, e As MouseEventArgs) Handles btCenter.MouseDown
        Select Case camera.protocol
            Case Camera.ProtocolType.ViscaTCP
                focusAuto()
                If My.Computer.Keyboard.ShiftKeyDown Then
                    networkWriter(visca.PTHome)
                Else
                    networkWriter(visca.PTStop())
                End If
            Case Camera.ProtocolType.Onvif
                onvif.StopMotion()
        End Select
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub btChckFocusLock_CheckedChanged(sender As Object, e As EventArgs) Handles btChckFocusLock.CheckedChanged
        If btChckFocusLock.Checked Then
            ' Focus Locked
            btChckFocusLock.Font = New Font(btChckFocusLock.Font.Name, btChckFocusLock.Font.Size, FontStyle.Bold)
            networkWriter(visca.FocusSetMode(Visca.FocusMode.Manual))
        Else
            ' Focus Auto
            btChckFocusLock.Font = New Font(btChckFocusLock.Font.Name, btChckFocusLock.Font.Size, FontStyle.Regular)
            networkWriter(visca.FocusSetMode(Visca.FocusMode.Auto))
        End If
    End Sub
End Class
