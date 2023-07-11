<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SignIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignIn))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.username = New Guna.UI2.WinForms.Guna2TextBox()
        Me.password = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.button = New Guna.UI2.WinForms.Guna2Button()
        Me.checkbox = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.successfully = New Guna.UI2.WinForms.Guna2MessageDialog()
        Me.incrrect = New Guna.UI2.WinForms.Guna2MessageDialog()
        Me.notemptyusername = New Guna.UI2.WinForms.Guna2MessageDialog()
        Me.notemptypassword = New Guna.UI2.WinForms.Guna2MessageDialog()
        Me.notemptyusernameorpassword = New Guna.UI2.WinForms.Guna2MessageDialog()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(124, 196)
        Me.Guna2PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(231, 231)
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'username
        '
        Me.username.BorderRadius = 8
        Me.username.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.username.DefaultText = ""
        Me.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.username.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!)
        Me.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.username.IconLeft = CType(resources.GetObject("username.IconLeft"), System.Drawing.Image)
        Me.username.Location = New System.Drawing.Point(666, 292)
        Me.username.Margin = New System.Windows.Forms.Padding(4)
        Me.username.Name = "username"
        Me.username.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.username.PlaceholderText = "Username"
        Me.username.SelectedText = ""
        Me.username.Size = New System.Drawing.Size(300, 50)
        Me.username.TabIndex = 1
        '
        'password
        '
        Me.password.BackColor = System.Drawing.Color.Wheat
        Me.password.BorderRadius = 8
        Me.password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.password.DefaultText = ""
        Me.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.password.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!)
        Me.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.password.IconLeft = CType(resources.GetObject("password.IconLeft"), System.Drawing.Image)
        Me.password.Location = New System.Drawing.Point(666, 404)
        Me.password.Margin = New System.Windows.Forms.Padding(4)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.password.PlaceholderText = "Password"
        Me.password.SelectedText = ""
        Me.password.Size = New System.Drawing.Size(300, 50)
        Me.password.TabIndex = 2
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(519, 685)
        Me.Guna2Panel1.TabIndex = 4
        '
        'button
        '
        Me.button.BorderRadius = 8
        Me.button.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.button.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.button.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button.ForeColor = System.Drawing.Color.White
        Me.button.Location = New System.Drawing.Point(728, 505)
        Me.button.Margin = New System.Windows.Forms.Padding(4)
        Me.button.Name = "button"
        Me.button.Size = New System.Drawing.Size(188, 52)
        Me.button.TabIndex = 8
        Me.button.Text = "Sign In"
        '
        'checkbox
        '
        Me.checkbox.AutoSize = True
        Me.checkbox.BackColor = System.Drawing.Color.Chartreuse
        Me.checkbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checkbox.CheckedState.BorderRadius = 0
        Me.checkbox.CheckedState.BorderThickness = 0
        Me.checkbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checkbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.checkbox.Location = New System.Drawing.Point(938, 423)
        Me.checkbox.Margin = New System.Windows.Forms.Padding(4)
        Me.checkbox.Name = "checkbox"
        Me.checkbox.Size = New System.Drawing.Size(18, 17)
        Me.checkbox.TabIndex = 6
        Me.checkbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.checkbox.UncheckedState.BorderRadius = 0
        Me.checkbox.UncheckedState.BorderThickness = 0
        Me.checkbox.UncheckedState.FillColor = System.Drawing.Color.ForestGreen
        Me.checkbox.UseVisualStyleBackColor = False
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe Print", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Lime
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(666, 97)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(407, 107)
        Me.Guna2HtmlLabel1.TabIndex = 8
        Me.Guna2HtmlLabel1.Text = "Login System"
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.Image = CType(resources.GetObject("Guna2PictureBox2.Image"), System.Drawing.Image)
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(1064, 5)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(52, 50)
        Me.Guna2PictureBox2.TabIndex = 9
        Me.Guna2PictureBox2.TabStop = False
        '
        'successfully
        '
        Me.successfully.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.successfully.Caption = "Log In Successful"
        Me.successfully.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
        Me.successfully.Parent = Me
        Me.successfully.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.successfully.Text = "Welcome to Stock Management System."
        '
        'incrrect
        '
        Me.incrrect.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.incrrect.Caption = "Sign In Error"
        Me.incrrect.Icon = Guna.UI2.WinForms.MessageDialogIcon.[Error]
        Me.incrrect.Parent = Me
        Me.incrrect.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.incrrect.Text = "Sorry, your username or password is incorrect. Please try again."
        '
        'notemptyusername
        '
        Me.notemptyusername.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.notemptyusername.Caption = "Warning!"
        Me.notemptyusername.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
        Me.notemptyusername.Parent = Me
        Me.notemptyusername.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.notemptyusername.Text = "Username cannot be null or empty."
        '
        'notemptypassword
        '
        Me.notemptypassword.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.notemptypassword.Caption = "Warning!"
        Me.notemptypassword.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
        Me.notemptypassword.Parent = Me
        Me.notemptypassword.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.notemptypassword.Text = "Password cannot be null or empty."
        '
        'notemptyusernameorpassword
        '
        Me.notemptyusernameorpassword.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        Me.notemptyusernameorpassword.Caption = "Warning"
        Me.notemptyusernameorpassword.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
        Me.notemptyusernameorpassword.Parent = Me
        Me.notemptyusernameorpassword.Style = Guna.UI2.WinForms.MessageDialogStyle.Light
        Me.notemptyusernameorpassword.Text = "Username or Password field cannot be null or empty"
        '
        'SignIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(1108, 681)
        Me.Controls.Add(Me.Guna2PictureBox2)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Controls.Add(Me.checkbox)
        Me.Controls.Add(Me.button)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.username)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SignIn"
        Me.Text = "Form1"
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents password As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents username As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents button As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents checkbox As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents successfully As Guna.UI2.WinForms.Guna2MessageDialog
    Friend WithEvents incrrect As Guna.UI2.WinForms.Guna2MessageDialog
    Friend WithEvents notemptyusername As Guna.UI2.WinForms.Guna2MessageDialog
    Friend WithEvents notemptypassword As Guna.UI2.WinForms.Guna2MessageDialog
    Friend WithEvents notemptyusernameorpassword As Guna.UI2.WinForms.Guna2MessageDialog
End Class
