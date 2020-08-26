<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCameraContol
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCameraContol))
        Me.btConnectDisconnect = New System.Windows.Forms.Button()
        Me.imgIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.pnPtz = New System.Windows.Forms.Panel()
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
        Me.trkZoomSpeed = New System.Windows.Forms.TrackBar()
        Me.btZoomPlus = New System.Windows.Forms.Button()
        Me.btZoomMinus = New System.Windows.Forms.Button()
        Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.pnPtz.SuspendLayout()
        CType(Me.trkPTSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        CType(Me.trkZoomSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btConnectDisconnect
        '
        Me.btConnectDisconnect.Enabled = False
        Me.btConnectDisconnect.Location = New System.Drawing.Point(237, 10)
        Me.btConnectDisconnect.Margin = New System.Windows.Forms.Padding(4)
        Me.btConnectDisconnect.Name = "btConnectDisconnect"
        Me.btConnectDisconnect.Size = New System.Drawing.Size(100, 28)
        Me.btConnectDisconnect.TabIndex = 0
        Me.btConnectDisconnect.Text = "Connect"
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
        '
        'pnPtz
        '
        Me.pnPtz.Controls.Add(Me.btDownRight)
        Me.pnPtz.Controls.Add(Me.btDown)
        Me.pnPtz.Controls.Add(Me.btDownLeft)
        Me.pnPtz.Controls.Add(Me.btRight)
        Me.pnPtz.Controls.Add(Me.btLeft)
        Me.pnPtz.Controls.Add(Me.btUpRight)
        Me.pnPtz.Controls.Add(Me.btUpLeft)
        Me.pnPtz.Controls.Add(Me.btUp)
        Me.pnPtz.Location = New System.Drawing.Point(17, 60)
        Me.pnPtz.Name = "pnPtz"
        Me.pnPtz.Size = New System.Drawing.Size(189, 184)
        Me.pnPtz.TabIndex = 5
        '
        'btDownRight
        '
        Me.btDownRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btDownRight.ImageIndex = 7
        Me.btDownRight.ImageList = Me.imgIcons
        Me.btDownRight.Location = New System.Drawing.Point(121, 117)
        Me.btDownRight.Name = "btDownRight"
        Me.btDownRight.Size = New System.Drawing.Size(50, 50)
        Me.btDownRight.TabIndex = 8
        Me.btDownRight.UseVisualStyleBackColor = True
        '
        'btDown
        '
        Me.btDown.ImageIndex = 1
        Me.btDown.ImageList = Me.imgIcons
        Me.btDown.Location = New System.Drawing.Point(70, 117)
        Me.btDown.Name = "btDown"
        Me.btDown.Size = New System.Drawing.Size(50, 50)
        Me.btDown.TabIndex = 7
        Me.btDown.UseVisualStyleBackColor = True
        '
        'btDownLeft
        '
        Me.btDownLeft.ImageIndex = 6
        Me.btDownLeft.ImageList = Me.imgIcons
        Me.btDownLeft.Location = New System.Drawing.Point(19, 117)
        Me.btDownLeft.Name = "btDownLeft"
        Me.btDownLeft.Size = New System.Drawing.Size(50, 50)
        Me.btDownLeft.TabIndex = 6
        Me.btDownLeft.UseVisualStyleBackColor = True
        '
        'btRight
        '
        Me.btRight.ImageIndex = 3
        Me.btRight.ImageList = Me.imgIcons
        Me.btRight.Location = New System.Drawing.Point(121, 66)
        Me.btRight.Name = "btRight"
        Me.btRight.Size = New System.Drawing.Size(50, 50)
        Me.btRight.TabIndex = 5
        Me.btRight.UseVisualStyleBackColor = True
        '
        'btLeft
        '
        Me.btLeft.ImageIndex = 2
        Me.btLeft.ImageList = Me.imgIcons
        Me.btLeft.Location = New System.Drawing.Point(19, 66)
        Me.btLeft.Name = "btLeft"
        Me.btLeft.Size = New System.Drawing.Size(50, 50)
        Me.btLeft.TabIndex = 3
        Me.btLeft.UseVisualStyleBackColor = True
        '
        'btUpRight
        '
        Me.btUpRight.ImageIndex = 5
        Me.btUpRight.ImageList = Me.imgIcons
        Me.btUpRight.Location = New System.Drawing.Point(121, 15)
        Me.btUpRight.Name = "btUpRight"
        Me.btUpRight.Size = New System.Drawing.Size(50, 50)
        Me.btUpRight.TabIndex = 2
        Me.btUpRight.UseVisualStyleBackColor = True
        '
        'btUpLeft
        '
        Me.btUpLeft.ImageIndex = 4
        Me.btUpLeft.ImageList = Me.imgIcons
        Me.btUpLeft.Location = New System.Drawing.Point(19, 15)
        Me.btUpLeft.Name = "btUpLeft"
        Me.btUpLeft.Size = New System.Drawing.Size(50, 50)
        Me.btUpLeft.TabIndex = 1
        Me.btUpLeft.UseVisualStyleBackColor = True
        '
        'btUp
        '
        Me.btUp.ImageIndex = 0
        Me.btUp.ImageList = Me.imgIcons
        Me.btUp.Location = New System.Drawing.Point(70, 15)
        Me.btUp.Name = "btUp"
        Me.btUp.Size = New System.Drawing.Size(50, 50)
        Me.btUp.TabIndex = 0
        Me.btUp.UseVisualStyleBackColor = True
        '
        'trkPTSpeed
        '
        Me.trkPTSpeed.Location = New System.Drawing.Point(17, 255)
        Me.trkPTSpeed.Maximum = 24
        Me.trkPTSpeed.Minimum = 1
        Me.trkPTSpeed.Name = "trkPTSpeed"
        Me.trkPTSpeed.Size = New System.Drawing.Size(321, 45)
        Me.trkPTSpeed.TabIndex = 10
        Me.trkPTSpeed.Value = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Status:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(86, 13)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(100, 20)
        Me.lblStatus.TabIndex = 12
        Me.lblStatus.Text = "Connecting"
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusPan, Me.statusTilt, Me.statusZoom})
        Me.statusBar.Location = New System.Drawing.Point(0, 297)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(349, 22)
        Me.statusBar.TabIndex = 13
        Me.statusBar.Text = "StatusStrip1"
        '
        'statusPan
        '
        Me.statusPan.Name = "statusPan"
        Me.statusPan.Size = New System.Drawing.Size(14, 17)
        Me.statusPan.Text = "P"
        '
        'statusTilt
        '
        Me.statusTilt.Name = "statusTilt"
        Me.statusTilt.Size = New System.Drawing.Size(13, 17)
        Me.statusTilt.Text = "T"
        '
        'statusZoom
        '
        Me.statusZoom.Name = "statusZoom"
        Me.statusZoom.Size = New System.Drawing.Size(14, 17)
        Me.statusZoom.Text = "Z"
        '
        'trkZoomSpeed
        '
        Me.trkZoomSpeed.Location = New System.Drawing.Point(293, 60)
        Me.trkZoomSpeed.Maximum = 7
        Me.trkZoomSpeed.Name = "trkZoomSpeed"
        Me.trkZoomSpeed.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkZoomSpeed.Size = New System.Drawing.Size(45, 184)
        Me.trkZoomSpeed.TabIndex = 14
        '
        'btZoomPlus
        '
        Me.btZoomPlus.ImageIndex = 8
        Me.btZoomPlus.ImageList = Me.imgIcons
        Me.btZoomPlus.Location = New System.Drawing.Point(228, 101)
        Me.btZoomPlus.Name = "btZoomPlus"
        Me.btZoomPlus.Size = New System.Drawing.Size(50, 50)
        Me.btZoomPlus.TabIndex = 9
        Me.btZoomPlus.UseVisualStyleBackColor = True
        '
        'btZoomMinus
        '
        Me.btZoomMinus.ImageIndex = 9
        Me.btZoomMinus.ImageList = Me.imgIcons
        Me.btZoomMinus.Location = New System.Drawing.Point(228, 157)
        Me.btZoomMinus.Name = "btZoomMinus"
        Me.btZoomMinus.Size = New System.Drawing.Size(50, 50)
        Me.btZoomMinus.TabIndex = 15
        Me.btZoomMinus.UseVisualStyleBackColor = True
        '
        'tmrStatus
        '
        Me.tmrStatus.Interval = 1000
        '
        'FrmCameraContol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 319)
        Me.Controls.Add(Me.btZoomMinus)
        Me.Controls.Add(Me.btZoomPlus)
        Me.Controls.Add(Me.trkZoomSpeed)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trkPTSpeed)
        Me.Controls.Add(Me.pnPtz)
        Me.Controls.Add(Me.btConnectDisconnect)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmCameraContol"
        Me.Text = "PTZPro - Camera Control"
        Me.pnPtz.ResumeLayout(False)
        CType(Me.trkPTSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        CType(Me.trkZoomSpeed, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
