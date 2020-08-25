<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCameraConfig
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txbName = New System.Windows.Forms.TextBox()
        Me.txbIP = New System.Windows.Forms.TextBox()
        Me.txbPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProtocol = New System.Windows.Forms.ComboBox()
        Me.btSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'txbName
        '
        Me.txbName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbName.Location = New System.Drawing.Point(100, 7)
        Me.txbName.Name = "txbName"
        Me.txbName.Size = New System.Drawing.Size(186, 22)
        Me.txbName.TabIndex = 4
        '
        'txbIP
        '
        Me.txbIP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbIP.Location = New System.Drawing.Point(100, 36)
        Me.txbIP.Name = "txbIP"
        Me.txbIP.Size = New System.Drawing.Size(186, 22)
        Me.txbIP.TabIndex = 5
        '
        'txbPort
        '
        Me.txbPort.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbPort.Location = New System.Drawing.Point(100, 65)
        Me.txbPort.Name = "txbPort"
        Me.txbPort.Size = New System.Drawing.Size(186, 22)
        Me.txbPort.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Protocol"
        '
        'cmbProtocol
        '
        Me.cmbProtocol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProtocol.FormattingEnabled = True
        Me.cmbProtocol.Items.AddRange(New Object() {"VISCA TCP"})
        Me.cmbProtocol.Location = New System.Drawing.Point(100, 94)
        Me.cmbProtocol.Name = "cmbProtocol"
        Me.cmbProtocol.Size = New System.Drawing.Size(186, 24)
        Me.cmbProtocol.TabIndex = 7
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(12, 130)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(274, 23)
        Me.btSave.TabIndex = 8
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'FrmCameraConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 165)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.cmbProtocol)
        Me.Controls.Add(Me.txbPort)
        Me.Controls.Add(Me.txbIP)
        Me.Controls.Add(Me.txbName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmCameraConfig"
        Me.Text = "PTZPro - Camera Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txbName As TextBox
    Friend WithEvents txbIP As TextBox
    Friend WithEvents txbPort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProtocol As ComboBox
    Friend WithEvents btSave As Button
End Class
