Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmMain
    Public dataDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\JairJunior.net\PTZPro"
    Private camerasTable As New DataTable()


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        camerasTable.Columns.Add("CameraName", GetType(String))
        camerasTable.Columns.Add("FileName", GetType(Camera))
        lstbxCameras.DisplayMember = "CameraName"
        lstbxCameras.ValueMember = "FileName"
        lstbxCameras.DataSource = camerasTable

        checkDataDir()
        loadCameras()
    End Sub

    Private Sub checkDataDir()
        If Not Directory.Exists(dataDir) Then
            Directory.CreateDirectory(dataDir)
        End If
    End Sub

    Private Sub loadCameras()
        camerasTable.Rows.Clear()

        Dim regex = New Regex(".*?\\Camera_[0-9]{6}\.ini")

        For Each fileName As String In Directory.EnumerateFiles(dataDir)
            If regex.IsMatch(fileName) Then
                Dim camera As New Camera(fileName)
                camerasTable.Rows.Add(camera.name, camera)
            End If
        Next

        If lstbxCameras.Items.Count > 0 Then
            btStart.Enabled = True
            EditCameraSettingsToolStripMenuItem.Enabled = True
            DeleteCameraToolStripMenuItem.Enabled = True
        Else
            btStart.Enabled = False
            EditCameraSettingsToolStripMenuItem.Enabled = False
            DeleteCameraToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Dim selectedCamera As Camera = lstbxCameras.SelectedItem.Row.Item(1)
        Dim frmCameraControl As New FrmCameraControl(selectedCamera)
        frmCameraControl.Show()
        Me.Dispose()
    End Sub

    Private Sub AddCameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCameraToolStripMenuItem.Click
        Dim frmCameraConfig As New FrmCameraConfig(FrmCameraConfig.FormMode.Add, "")
        frmCameraConfig.ShowDialog()
        loadCameras()
    End Sub

    Private Sub EditCameraSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditCameraSettingsToolStripMenuItem.Click
        Dim selectedCamera As Camera = lstbxCameras.SelectedItem.Row.Item(1)
        Dim frmCameraConfig As New FrmCameraConfig(FrmCameraConfig.FormMode.Edit, selectedCamera.iniFileName)
        frmCameraConfig.ShowDialog()
        loadCameras()
    End Sub

    Private Sub DeleteCameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteCameraToolStripMenuItem.Click
        Dim selectedCamera As Camera = lstbxCameras.SelectedItem.Row.Item(1)
        File.Delete(selectedCamera.iniFileName)
        loadCameras()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
End Class