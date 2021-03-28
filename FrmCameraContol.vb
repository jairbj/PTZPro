
Imports System.Net.Sockets
Imports System.Text
Public Class FrmCameraContol
    Dim tcpClient As System.Net.Sockets.TcpClient
    Dim networkStream As NetworkStream
    Dim visca As Visca = New Visca(1)
    Dim camera As Camera

    Dim isUpdatingPosition As Boolean = False

    Public Sub New(camera As Camera)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.camera = camera
        tcpConnect()
    End Sub

    Private Sub tcpConnect()
        btConnectDisconnect.Enabled = False
        Try
            tcpClient = New System.Net.Sockets.TcpClient()
            tcpClient.Connect(camera.ip, camera.port)
            networkStream = tcpClient.GetStream()
            ' Sets 500ms timeout
            networkStream.ReadTimeout = 500
            btConnectDisconnect.Text = "Disconnect"
            lblStatus.Text = "Connected"
            tmrStatus.Start()
            focusAuto()
        Catch ex As Exception
            lblStatus.Text = "Error"
        End Try
        btConnectDisconnect.Enabled = True
    End Sub

    Private Sub tcpDisconnect()
        tmrStatus.Stop()
        btConnectDisconnect.Enabled = False
        If tcpClient.Connected Then
            networkStream.Close()
            tcpClient.Close()
        End If
        lblStatus.Text = "Disconnected"
        btConnectDisconnect.Text = "Connect"
        btConnectDisconnect.Enabled = True
    End Sub
    Private Sub btConnectDisconnect_Click(sender As Object, e As EventArgs) Handles btConnectDisconnect.Click
        If tcpClient.Connected Then
            tcpDisconnect()
        Else
            tcpConnect()
        End If
    End Sub

    Private Sub moveDirection(sender As Object, e As MouseEventArgs) Handles _
            btUp.MouseDown, btDown.MouseDown, btLeft.MouseDown, btRight.MouseDown,
            btUpLeft.MouseDown, btUpRight.MouseDown,
            btDownLeft.MouseDown, btDownRight.MouseDown

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
    End Sub


    Private Sub stopMove(sender As Object, e As MouseEventArgs) Handles _
            btUp.MouseUp, btDown.MouseUp, btLeft.MouseUp, btRight.MouseUp,
            btUpLeft.MouseUp, btUpRight.MouseUp,
            btDownLeft.MouseUp, btDownRight.MouseUp

        networkWriter(visca.PTStop)
    End Sub

    Private Sub FrmCameraContol_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tcpDisconnect()
        End
    End Sub

    Private Sub zoomMove(sender As Object, e As MouseEventArgs) Handles _
        btZoomPlus.MouseDown, btZoomMinus.MouseDown

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
    End Sub

    Private Sub zoomStop(sender As Object, e As MouseEventArgs) Handles _
        btZoomPlus.MouseUp, btZoomMinus.MouseUp

        networkWriter(visca.ZoomStop())
    End Sub

    Private Sub networkWriter(data As Byte())
        If tcpClient.Connected Then
            networkStream.Write(data, 0, data.Length)
        End If
    End Sub

    Private Sub tmrStatus_Tick(sender As Object, e As EventArgs) Handles tmrStatus.Tick
        UpdatePosition()
    End Sub

    Private Sub UpdatePosition()
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
        If Not tcpClient.Connected() Then
            Return
        End If

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
        networkWriter(visca.SetPreset(presetId))
        LoadPresets()
    End Sub

    Private Sub UpdatePresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePresetToolStripMenuItem.Click
        If Not tcpClient.Connected() Then
            Return
        End If

        UpdatePosition()

        Dim preset As CameraPreset = lstvPresets.SelectedItems(0).Tag
        preset.pan = camera.panPosition
        preset.tilt = camera.tiltPosition
        preset.zoom = camera.zoomPosition

        camera.UpdatePreset(preset)
        networkWriter(visca.SetPreset(preset.id))
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
        focusAuto()
        If My.Computer.Keyboard.ShiftKeyDown Then
            networkWriter(visca.PTHome)
        Else
            networkWriter(visca.PTStop())
        End If
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
