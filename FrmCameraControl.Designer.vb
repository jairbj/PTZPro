<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCameraControl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCameraControl))
        Me.btConnectDisconnect = New System.Windows.Forms.Button()
        Me.imgIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.pnPtz = New System.Windows.Forms.Panel()
        Me.btCenter = New System.Windows.Forms.Button()
        Me.btDownRight = New System.Windows.Forms.Button()
        Me.btDown = New System.Windows.Forms.Button()
        Me.btDownLeft = New System.Windows.Forms.Button()
        Me.btRight = New System.Windows.Forms.Button()
        Me.btLeft = New System.Windows.Forms.Button()
        Me.btUpRight = New System.Windows.Forms.Button()
        Me.btUpLeft = New System.Windows.Forms.Button()
        Me.btUp = New System.Windows.Forms.Button()
        Me.trkPTSpeed = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.statusPan = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusTilt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusFocus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.trkZoomSpeed = New System.Windows.Forms.TrackBar()
        Me.btZoomPlus = New System.Windows.Forms.Button()
        Me.btZoomMinus = New System.Windows.Forms.Button()
        Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.btSavePreset = New System.Windows.Forms.Button()
        Me.ctxMenuPresets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditPresetNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatePresetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePresetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstvPresets = New System.Windows.Forms.ListView()
        Me.lblCamera = New System.Windows.Forms.Label()
        Me.lblCameraTitle = New System.Windows.Forms.Label()
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btChckFocusLock = New System.Windows.Forms.CheckBox()
        Me.pnPtz.SuspendLayout()
        CType(Me.trkPTSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        CType(Me.trkZoomSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuPresets.SuspendLayout()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'btConnectDisconnect
        '
        resources.ApplyResources(Me.btConnectDisconnect, "btConnectDisconnect")
        Me.btConnectDisconnect.Name = "btConnectDisconnect"
        Me.btConnectDisconnect.UseVisualStyleBackColor = True
        '
        'imgIcons
        '
        Me.imgIcons.ImageStream = CType(resources.GetObject("imgIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIcons.Images.SetKeyName(0, "up.png")
        Me.imgIcons.Images.SetKeyName(1, "down.png")
        Me.imgIcons.Images.SetKeyName(2, "left.png")
        Me.imgIcons.Images.SetKeyName(3, "right.png")
        Me.imgIcons.Images.SetKeyName(4, "up_left.png")
        Me.imgIcons.Images.SetKeyName(5, "up_right.png")
        Me.imgIcons.Images.SetKeyName(6, "down_left.png")
        Me.imgIcons.Images.SetKeyName(7, "down_right.png")
        Me.imgIcons.Images.SetKeyName(8, "zoom_plus.png")
        Me.imgIcons.Images.SetKeyName(9, "zoom_minus.png")
        Me.imgIcons.Images.SetKeyName(10, "center.png")
        '
        'pnPtz
        '
        Me.pnPtz.Controls.Add(Me.btCenter)
        Me.pnPtz.Controls.Add(Me.btDownRight)
        Me.pnPtz.Controls.Add(Me.btDown)
        Me.pnPtz.Controls.Add(Me.btDownLeft)
        Me.pnPtz.Controls.Add(Me.btRight)
        Me.pnPtz.Controls.Add(Me.btLeft)
        Me.pnPtz.Controls.Add(Me.btUpRight)
        Me.pnPtz.Controls.Add(Me.btUpLeft)
        Me.pnPtz.Controls.Add(Me.btUp)
        resources.ApplyResources(Me.pnPtz, "pnPtz")
        Me.pnPtz.Name = "pnPtz"
        '
        'btCenter
        '
        resources.ApplyResources(Me.btCenter, "btCenter")
        Me.btCenter.ImageList = Me.imgIcons
        Me.btCenter.Name = "btCenter"
        Me.btCenter.UseVisualStyleBackColor = True
        '
        'btDownRight
        '
        resources.ApplyResources(Me.btDownRight, "btDownRight")
        Me.btDownRight.ImageList = Me.imgIcons
        Me.btDownRight.Name = "btDownRight"
        Me.btDownRight.UseVisualStyleBackColor = True
        '
        'btDown
        '
        resources.ApplyResources(Me.btDown, "btDown")
        Me.btDown.ImageList = Me.imgIcons
        Me.btDown.Name = "btDown"
        Me.btDown.UseVisualStyleBackColor = True
        '
        'btDownLeft
        '
        resources.ApplyResources(Me.btDownLeft, "btDownLeft")
        Me.btDownLeft.ImageList = Me.imgIcons
        Me.btDownLeft.Name = "btDownLeft"
        Me.btDownLeft.UseVisualStyleBackColor = True
        '
        'btRight
        '
        resources.ApplyResources(Me.btRight, "btRight")
        Me.btRight.ImageList = Me.imgIcons
        Me.btRight.Name = "btRight"
        Me.btRight.UseVisualStyleBackColor = True
        '
        'btLeft
        '
        resources.ApplyResources(Me.btLeft, "btLeft")
        Me.btLeft.ImageList = Me.imgIcons
        Me.btLeft.Name = "btLeft"
        Me.btLeft.UseVisualStyleBackColor = True
        '
        'btUpRight
        '
        resources.ApplyResources(Me.btUpRight, "btUpRight")
        Me.btUpRight.ImageList = Me.imgIcons
        Me.btUpRight.Name = "btUpRight"
        Me.btUpRight.UseVisualStyleBackColor = True
        '
        'btUpLeft
        '
        resources.ApplyResources(Me.btUpLeft, "btUpLeft")
        Me.btUpLeft.ImageList = Me.imgIcons
        Me.btUpLeft.Name = "btUpLeft"
        Me.btUpLeft.UseVisualStyleBackColor = True
        '
        'btUp
        '
        resources.ApplyResources(Me.btUp, "btUp")
        Me.btUp.ImageList = Me.imgIcons
        Me.btUp.Name = "btUp"
        Me.btUp.UseVisualStyleBackColor = True
        '
        'trkPTSpeed
        '
        resources.ApplyResources(Me.trkPTSpeed, "trkPTSpeed")
        Me.trkPTSpeed.Maximum = 24
        Me.trkPTSpeed.Minimum = 1
        Me.trkPTSpeed.Name = "trkPTSpeed"
        Me.trkPTSpeed.Value = 1
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusPan, Me.statusTilt, Me.statusZoom, Me.statusFocus})
        resources.ApplyResources(Me.statusBar, "statusBar")
        Me.statusBar.Name = "statusBar"
        '
        'statusPan
        '
        Me.statusPan.Name = "statusPan"
        resources.ApplyResources(Me.statusPan, "statusPan")
        '
        'statusTilt
        '
        Me.statusTilt.Name = "statusTilt"
        resources.ApplyResources(Me.statusTilt, "statusTilt")
        '
        'statusZoom
        '
        Me.statusZoom.Name = "statusZoom"
        resources.ApplyResources(Me.statusZoom, "statusZoom")
        '
        'statusFocus
        '
        Me.statusFocus.Name = "statusFocus"
        resources.ApplyResources(Me.statusFocus, "statusFocus")
        '
        'trkZoomSpeed
        '
        resources.ApplyResources(Me.trkZoomSpeed, "trkZoomSpeed")
        Me.trkZoomSpeed.Maximum = 7
        Me.trkZoomSpeed.Name = "trkZoomSpeed"
        '
        'btZoomPlus
        '
        resources.ApplyResources(Me.btZoomPlus, "btZoomPlus")
        Me.btZoomPlus.ImageList = Me.imgIcons
        Me.btZoomPlus.Name = "btZoomPlus"
        Me.btZoomPlus.UseVisualStyleBackColor = True
        '
        'btZoomMinus
        '
        resources.ApplyResources(Me.btZoomMinus, "btZoomMinus")
        Me.btZoomMinus.ImageList = Me.imgIcons
        Me.btZoomMinus.Name = "btZoomMinus"
        Me.btZoomMinus.UseVisualStyleBackColor = True
        '
        'tmrStatus
        '
        Me.tmrStatus.Interval = 1000
        '
        'btSavePreset
        '
        resources.ApplyResources(Me.btSavePreset, "btSavePreset")
        Me.btSavePreset.Name = "btSavePreset"
        Me.btSavePreset.UseVisualStyleBackColor = True
        '
        'ctxMenuPresets
        '
        Me.ctxMenuPresets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditPresetNameToolStripMenuItem, Me.UpdatePresetToolStripMenuItem, Me.DeletePresetToolStripMenuItem})
        Me.ctxMenuPresets.Name = "ctxMenuPresets"
        resources.ApplyResources(Me.ctxMenuPresets, "ctxMenuPresets")
        '
        'EditPresetNameToolStripMenuItem
        '
        Me.EditPresetNameToolStripMenuItem.Name = "EditPresetNameToolStripMenuItem"
        resources.ApplyResources(Me.EditPresetNameToolStripMenuItem, "EditPresetNameToolStripMenuItem")
        '
        'UpdatePresetToolStripMenuItem
        '
        Me.UpdatePresetToolStripMenuItem.Name = "UpdatePresetToolStripMenuItem"
        resources.ApplyResources(Me.UpdatePresetToolStripMenuItem, "UpdatePresetToolStripMenuItem")
        '
        'DeletePresetToolStripMenuItem
        '
        Me.DeletePresetToolStripMenuItem.Name = "DeletePresetToolStripMenuItem"
        resources.ApplyResources(Me.DeletePresetToolStripMenuItem, "DeletePresetToolStripMenuItem")
        '
        'lstvPresets
        '
        resources.ApplyResources(Me.lstvPresets, "lstvPresets")
        Me.lstvPresets.ContextMenuStrip = Me.ctxMenuPresets
        Me.lstvPresets.HideSelection = False
        Me.lstvPresets.MultiSelect = False
        Me.lstvPresets.Name = "lstvPresets"
        Me.lstvPresets.UseCompatibleStateImageBehavior = False
        Me.lstvPresets.View = System.Windows.Forms.View.List
        '
        'lblCamera
        '
        resources.ApplyResources(Me.lblCamera, "lblCamera")
        Me.lblCamera.Name = "lblCamera"
        '
        'lblCameraTitle
        '
        resources.ApplyResources(Me.lblCameraTitle, "lblCameraTitle")
        Me.lblCameraTitle.Name = "lblCameraTitle"
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        resources.ApplyResources(Me.mainMenu, "mainMenu")
        Me.mainMenu.Name = "mainMenu"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'btChckFocusLock
        '
        resources.ApplyResources(Me.btChckFocusLock, "btChckFocusLock")
        Me.btChckFocusLock.Name = "btChckFocusLock"
        Me.btChckFocusLock.UseVisualStyleBackColor = True
        '
        'FrmCameraContol
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btChckFocusLock)
        Me.Controls.Add(Me.lblCamera)
        Me.Controls.Add(Me.lblCameraTitle)
        Me.Controls.Add(Me.lstvPresets)
        Me.Controls.Add(Me.btSavePreset)
        Me.Controls.Add(Me.btZoomMinus)
        Me.Controls.Add(Me.btZoomPlus)
        Me.Controls.Add(Me.trkZoomSpeed)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.mainMenu)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trkPTSpeed)
        Me.Controls.Add(Me.pnPtz)
        Me.Controls.Add(Me.btConnectDisconnect)
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "FrmCameraContol"
        Me.pnPtz.ResumeLayout(False)
        CType(Me.trkPTSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        CType(Me.trkZoomSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuPresets.ResumeLayout(False)
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btConnectDisconnect As Button
    Friend WithEvents imgIcons As ImageList
    Friend WithEvents pnPtz As Panel
    Friend WithEvents btDownRight As Button
    Friend WithEvents btDown As Button
    Friend WithEvents btDownLeft As Button
    Friend WithEvents btRight As Button
    Friend WithEvents btLeft As Button
    Friend WithEvents btUpRight As Button
    Friend WithEvents btUpLeft As Button
    Friend WithEvents btUp As Button
    Friend WithEvents trkPTSpeed As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents statusBar As StatusStrip
    Friend WithEvents statusPan As ToolStripStatusLabel
    Friend WithEvents statusTilt As ToolStripStatusLabel
    Friend WithEvents statusZoom As ToolStripStatusLabel
    Friend WithEvents trkZoomSpeed As TrackBar
    Friend WithEvents btZoomPlus As Button
    Friend WithEvents btZoomMinus As Button
    Friend WithEvents tmrStatus As Timer
    Friend WithEvents btSavePreset As Button
    Friend WithEvents ctxMenuPresets As ContextMenuStrip
    Friend WithEvents UpdatePresetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeletePresetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lstvPresets As ListView
    Friend WithEvents EditPresetNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btCenter As Button
    Friend WithEvents lblCamera As Label
    Friend WithEvents lblCameraTitle As Label
    Friend WithEvents mainMenu As MenuStrip
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents statusFocus As ToolStripStatusLabel
    Friend WithEvents btChckFocusLock As CheckBox
End Class
