<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ECIDForm
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
        Me.ECIDNumLabel = New System.Windows.Forms.Label()
        Me.ECIDTextBox = New System.Windows.Forms.TextBox()
        Me.ECIDIntroductionLabel = New System.Windows.Forms.Label()
        Me.ECIDConfirmBtn = New System.Windows.Forms.Button()
        Me.WorkBar = New System.Windows.Forms.ProgressBar()
        Me.Worklabel = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.DeviceChecker = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ECIDNumLabel
        '
        Me.ECIDNumLabel.AutoSize = True
        Me.ECIDNumLabel.Location = New System.Drawing.Point(12, 69)
        Me.ECIDNumLabel.Name = "ECIDNumLabel"
        Me.ECIDNumLabel.Size = New System.Drawing.Size(35, 13)
        Me.ECIDNumLabel.TabIndex = 0
        Me.ECIDNumLabel.Text = "ECID:"
        '
        'ECIDTextBox
        '
        Me.ECIDTextBox.Location = New System.Drawing.Point(99, 66)
        Me.ECIDTextBox.Name = "ECIDTextBox"
        Me.ECIDTextBox.Size = New System.Drawing.Size(206, 20)
        Me.ECIDTextBox.TabIndex = 1
        Me.ECIDTextBox.Visible = False
        '
        'ECIDIntroductionLabel
        '
        Me.ECIDIntroductionLabel.AutoSize = True
        Me.ECIDIntroductionLabel.Location = New System.Drawing.Point(12, 9)
        Me.ECIDIntroductionLabel.Name = "ECIDIntroductionLabel"
        Me.ECIDIntroductionLabel.Size = New System.Drawing.Size(278, 26)
        Me.ECIDIntroductionLabel.TabIndex = 2
        Me.ECIDIntroductionLabel.Text = "Please, insert your ECID in the box below. (You can insert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ECIDs in their decima" & _
    "l, hexadecimal or base64 mode)."
        Me.ECIDIntroductionLabel.Visible = False
        '
        'ECIDConfirmBtn
        '
        Me.ECIDConfirmBtn.Location = New System.Drawing.Point(12, 119)
        Me.ECIDConfirmBtn.Name = "ECIDConfirmBtn"
        Me.ECIDConfirmBtn.Size = New System.Drawing.Size(293, 23)
        Me.ECIDConfirmBtn.TabIndex = 3
        Me.ECIDConfirmBtn.Text = "OK"
        Me.ECIDConfirmBtn.UseVisualStyleBackColor = True
        Me.ECIDConfirmBtn.Visible = False
        '
        'WorkBar
        '
        Me.WorkBar.Location = New System.Drawing.Point(12, 69)
        Me.WorkBar.Name = "WorkBar"
        Me.WorkBar.Size = New System.Drawing.Size(293, 17)
        Me.WorkBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.WorkBar.TabIndex = 4
        Me.WorkBar.Visible = False
        '
        'Worklabel
        '
        Me.Worklabel.AutoSize = True
        Me.Worklabel.Location = New System.Drawing.Point(85, 35)
        Me.Worklabel.Name = "Worklabel"
        Me.Worklabel.Size = New System.Drawing.Size(130, 26)
        Me.Worklabel.TabIndex = 5
        Me.Worklabel.Text = "Elaborating your request..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please Wait"
        Me.Worklabel.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Enabled = False
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 88)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(290, 26)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Connect an iOS device and Beehind will automatically dump" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "its ECID"
        '
        'DeviceChecker
        '
        Me.DeviceChecker.Enabled = True
        Me.DeviceChecker.Interval = 2000
        '
        'ECIDForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 149)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Worklabel)
        Me.Controls.Add(Me.WorkBar)
        Me.Controls.Add(Me.ECIDConfirmBtn)
        Me.Controls.Add(Me.ECIDIntroductionLabel)
        Me.Controls.Add(Me.ECIDTextBox)
        Me.Controls.Add(Me.ECIDNumLabel)
        Me.Name = "ECIDForm"
        Me.Text = "ECIDForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ECIDNumLabel As System.Windows.Forms.Label
    Friend WithEvents ECIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ECIDIntroductionLabel As System.Windows.Forms.Label
    Friend WithEvents ECIDConfirmBtn As System.Windows.Forms.Button
    Friend WithEvents WorkBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Worklabel As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DeviceChecker As System.Windows.Forms.Timer
End Class
