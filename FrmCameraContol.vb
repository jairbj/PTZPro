
Imports System.Net.Sockets
Imports System.Text
Public Class FrmCameraContol
    Dim tcpClient As System.Net.Sockets.TcpClient
    Dim networkStream As NetworkStream
    Dim visca As Visca = New Visca(1)
    Dim camera As Camera

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
            btConnectDisconnect.Text = "Disconnect"
            lblStatus.Text = "Connected"
        Catch ex As Exception
            lblStatus.Text = "Error"
        End Try
        btConnectDisconnect.Enabled = True
    End Sub

    Private Sub tcpDisconnect()
        btConnectDisconnect.Enabled = False
        networkStream.Close()
        tcpClient.Close()
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
        Debug.WriteLine(speed)
        Dim move = visca.PTMove(horizontalDirection, speed,
                                verticalDirection, speed)
        networkWriter(move)
    End Sub


    Private Sub stopMove(sender As Object, e As MouseEventArgs) Handles _
            btUp.MouseUp, btDown.MouseUp, btLeft.MouseUp, btRight.MouseUp,
            btUpLeft.MouseUp, btUpRight.MouseUp,
            btDownLeft.MouseUp, btDownRight.MouseUp

        networkWriter(visca.PTStop)
    End Sub

    Private Sub FrmCameraContol_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub zoomMove(sender As Object, e As MouseEventArgs) Handles _
        btZoomPlus.MouseDown, btZoomMinus.MouseDown

        Dim direction As Visca.ZoomDirection
        Dim speed As Int16
        If My.Computer.Keyboard.ShiftKeyDown Then
            speed = Visca.ZOOM_MAX_SPEED
        Else
            speed = trkZoomSpeed.Value
        End If

        Select Case True
            Case sender Is btZoomPlus
                direction = Visca.ZoomDirection.Plus
            Case sender Is btZoomMinus
                direction = Visca.ZoomDirection.Minus
        End Select

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
End Class
