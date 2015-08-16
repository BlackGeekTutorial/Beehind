<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KloaderInjector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KloaderInjector))
        Me.DeviceChecker = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PwnDFUButton = New System.Windows.Forms.Button()
        Me.iBSSPathTextBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SSHConsole = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.iBSSFIleDialog = New System.Windows.Forms.OpenFileDialog()
        Me.IPLabel = New System.Windows.Forms.Label()
        Me.IPTextBox = New System.Windows.Forms.TextBox()
        Me.WiFiSSHBG = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DeviceChecker
        '
        Me.DeviceChecker.Enabled = True
        Me.DeviceChecker.Interval = 2000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No connected devices"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(749, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Welcome to Beehind's DFU Pwner for all 32-bit devices! This is possible thanks to" & _
    " @winocm kloader: an iOS utility that bootstraps an unencrypted IMG3 in an" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "iDev" & _
    "ice from userland"
        '
        'PwnDFUButton
        '
        Me.PwnDFUButton.Enabled = False
        Me.PwnDFUButton.Location = New System.Drawing.Point(12, 257)
        Me.PwnDFUButton.Name = "PwnDFUButton"
        Me.PwnDFUButton.Size = New System.Drawing.Size(739, 23)
        Me.PwnDFUButton.TabIndex = 3
        Me.PwnDFUButton.Text = "Enter Pwned DFU Mode"
        Me.PwnDFUButton.UseVisualStyleBackColor = True
        '
        'iBSSPathTextBox
        '
        Me.iBSSPathTextBox.Location = New System.Drawing.Point(9, 36)
        Me.iBSSPathTextBox.Name = "iBSSPathTextBox"
        Me.iBSSPathTextBox.ReadOnly = True
        Me.iBSSPathTextBox.Size = New System.Drawing.Size(664, 20)
        Me.iBSSPathTextBox.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(679, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 21)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.iBSSPathTextBox)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(739, 64)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose Custom iBSS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(630, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "The input must be an unencrypted IMG3 containing an ARM Image of a patched iBSS.T" & _
    "his will put your device in pwned DFU Mode"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(739, 120)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Instructions:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(694, 91)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'SSHConsole
        '
        Me.SSHConsole.Location = New System.Drawing.Point(12, 339)
        Me.SSHConsole.Name = "SSHConsole"
        Me.SSHConsole.ReadOnly = True
        Me.SSHConsole.Size = New System.Drawing.Size(739, 146)
        Me.SSHConsole.TabIndex = 8
        Me.SSHConsole.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 323)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Known events:"
        '
        'IPLabel
        '
        Me.IPLabel.AutoSize = True
        Me.IPLabel.Location = New System.Drawing.Point(12, 297)
        Me.IPLabel.Name = "IPLabel"
        Me.IPLabel.Size = New System.Drawing.Size(422, 13)
        Me.IPLabel.TabIndex = 10
        Me.IPLabel.Text = "Having problems with autoconnect? Manually insert your device's Wi-Fi IP and try " & _
    "again!"
        '
        'IPTextBox
        '
        Me.IPTextBox.Location = New System.Drawing.Point(440, 294)
        Me.IPTextBox.MaxLength = 15
        Me.IPTextBox.Name = "IPTextBox"
        Me.IPTextBox.Size = New System.Drawing.Size(127, 20)
        Me.IPTextBox.TabIndex = 9
        '
        'WiFiSSHBG
        '
        '
        'KloaderInjector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 497)
        Me.Controls.Add(Me.IPTextBox)
        Me.Controls.Add(Me.IPLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SSHConsole)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PwnDFUButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "KloaderInjector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KloaderInjector"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DeviceChecker As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PwnDFUButton As System.Windows.Forms.Button
    Friend WithEvents iBSSPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SSHConsole As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents iBSSFIleDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents IPLabel As System.Windows.Forms.Label
    Friend WithEvents IPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WiFiSSHBG As System.ComponentModel.BackgroundWorker
End Class
