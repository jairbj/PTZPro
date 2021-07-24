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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txbVmixUrl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txbVmixUsername = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txbVmixPassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numInputNumber = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numInputNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name"
        '
        'txbName
        '
        Me.txbName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbName.Location = New System.Drawing.Point(100, 7)
        Me.txbName.Name = "txbName"
        Me.txbName.Size = New System.Drawing.Size(379, 22)
        Me.txbName.TabIndex = 0
        '
        'txbIP
        '
        Me.txbIP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbIP.Location = New System.Drawing.Point(100, 36)
        Me.txbIP.Name = "txbIP"
        Me.txbIP.Size = New System.Drawing.Size(379, 22)
        Me.txbIP.TabIndex = 1
        '
        'txbPort
        '
        Me.txbPort.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbPort.Location = New System.Drawing.Point(100, 65)
        Me.txbPort.Name = "txbPort"
        Me.txbPort.Size = New System.Drawing.Size(379, 22)
        Me.txbPort.TabIndex = 2
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
        Me.cmbProtocol.Size = New System.Drawing.Size(379, 24)
        Me.cmbProtocol.TabIndex = 3
        '
        'btSave
        '
        Me.btSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSave.Location = New System.Drawing.Point(100, 277)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(274, 23)
        Me.btSave.TabIndex = 5
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.numInputNumber)
        Me.GroupBox1.Controls.Add(Me.txbVmixPassword)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txbVmixUsername)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txbVmixUrl)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 147)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vmix Integration (leave blank for deactivate)"
        '
        'txbVmixUrl
        '
        Me.txbVmixUrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbVmixUrl.Location = New System.Drawing.Point(167, 21)
        Me.txbVmixUrl.Name = "txbVmixUrl"
        Me.txbVmixUrl.Size = New System.Drawing.Size(277, 22)
        Me.txbVmixUrl.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Web Controller URL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Input Number"
        '
        'txbVmixUsername
        '
        Me.txbVmixUsername.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbVmixUsername.Location = New System.Drawing.Point(167, 80)
        Me.txbVmixUsername.Name = "txbVmixUsername"
        Me.txbVmixUsername.Size = New System.Drawing.Size(277, 22)
        Me.txbVmixUsername.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Username (if needed)"
        '
        'txbVmixPassword
        '
        Me.txbVmixPassword.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbVmixPassword.Location = New System.Drawing.Point(167, 108)
        Me.txbVmixPassword.Name = "txbVmixPassword"
        Me.txbVmixPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbVmixPassword.Size = New System.Drawing.Size(277, 22)
        Me.txbVmixPassword.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 16)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Password (if needed)"
        '
        'numInputNumber
        '
        Me.numInputNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numInputNumber.Location = New System.Drawing.Point(167, 49)
        Me.numInputNumber.Name = "numInputNumber"
        Me.numInputNumber.Size = New System.Drawing.Size(139, 22)
        Me.numInputNumber.TabIndex = 1
        '
        'FrmCameraConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 311)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numInputNumber, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents numInputNumber As NumericUpDown
    Friend WithEvents txbVmixPassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txbVmixUsername As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txbVmixUrl As TextBox
    Friend WithEvents Label5 As Label
End Class
