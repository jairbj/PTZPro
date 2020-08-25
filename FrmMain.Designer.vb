<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.AddCameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCameraSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstbxCameras = New System.Windows.Forms.ListBox()
        Me.btStart = New System.Windows.Forms.Button()
        Me.menuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddCameraToolStripMenuItem, Me.EditCameraSettingsToolStripMenuItem, Me.DeleteCameraToolStripMenuItem})
        resources.ApplyResources(Me.menuMain, "menuMain")
        Me.menuMain.Name = "menuMain"
        '
        'AddCameraToolStripMenuItem
        '
        Me.AddCameraToolStripMenuItem.Name = "AddCameraToolStripMenuItem"
        resources.ApplyResources(Me.AddCameraToolStripMenuItem, "AddCameraToolStripMenuItem")
        '
        'EditCameraSettingsToolStripMenuItem
        '
        resources.ApplyResources(Me.EditCameraSettingsToolStripMenuItem, "EditCameraSettingsToolStripMenuItem")
        Me.EditCameraSettingsToolStripMenuItem.Name = "EditCameraSettingsToolStripMenuItem"
        '
        'DeleteCameraToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteCameraToolStripMenuItem, "DeleteCameraToolStripMenuItem")
        Me.DeleteCameraToolStripMenuItem.Name = "DeleteCameraToolStripMenuItem"
        '
        'lstbxCameras
        '
        resources.ApplyResources(Me.lstbxCameras, "lstbxCameras")
        Me.lstbxCameras.FormattingEnabled = True
        Me.lstbxCameras.Name = "lstbxCameras"
        '
        'btStart
        '
        resources.ApplyResources(Me.btStart, "btStart")
        Me.btStart.Name = "btStart"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.lstbxCameras)
        Me.Controls.Add(Me.menuMain)
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "frmMain"
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menuMain As MenuStrip
    Friend WithEvents AddCameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditCameraSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteCameraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lstbxCameras As ListBox
    Friend WithEvents btStart As Button
End Class
