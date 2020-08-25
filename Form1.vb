
Imports System.Net.Sockets
Imports System.Text
Public Class Form1
    Dim tcpClient As New System.Net.Sockets.TcpClient()
    Dim networkStream As NetworkStream
    Dim visca As Visca = New Visca(1)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        tcpClient.Connect("192.168.1.17", 5678)

        networkStream = tcpClient.GetStream()
        If networkStream.CanWrite And networkStream.CanRead Then
            ' executa apenas uma escrita
            Dim sendBytes As [Byte]() = New Byte() {129, 9, 6, 18, 255}
            networkStream.Write(sendBytes, 0, sendBytes.Length)
            ' Le o NetworkStream em um buffer
            Dim bytes(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
            ' exibe os dados recebidos do host no console
            Dim returndata As String = BitConverter.ToString(bytes)
            Debug.WriteLine(("Host retornou : " + returndata))
        Else
            If Not networkStream.CanRead Then
                Debug.WriteLine("Não é possível enviar dados para este stream")
                tcpClient.Close()
            Else
                If Not networkStream.CanWrite Then
                    Debug.WriteLine("Não é possivel ler dados deste stream")
                    tcpClient.Close()
                End If
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim visca As Visca = New Visca(1)
        Debug.WriteLine(BitConverter.ToString(visca.InquireZoomPosition))


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        networkStream.Write(visca.PTStop, 0, visca.PTStop.Length)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim move = visca.PTMove(Visca.PTHorizontalDirection.Left, 20)
        networkStream.Write(move, 0, move.Length)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button5_MouseDown(sender As Object, e As MouseEventArgs) Handles Button5.MouseDown
        Dim move = visca.PTMove(Visca.PTHorizontalDirection.Right, 20)
        networkStream.Write(move, 0, move.Length)
    End Sub

    Private Sub Button5_MouseUp(sender As Object, e As MouseEventArgs) Handles Button5.MouseUp
        networkStream.Write(visca.PTStop, 0, visca.PTStop.Length)
    End Sub
End Class
