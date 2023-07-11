Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Media

Public Class SignIn
    Private Sub Button_Enter(sender As Object, e As EventArgs)
        Dim button As Control = DirectCast(sender, Control)
        button.BackColor = Color.LightBlue
    End Sub

    Private Sub Button_Leave(sender As Object, e As EventArgs)
        Dim button As Control = DirectCast(sender, Control)
        button.BackColor = SystemColors.Control
    End Sub

    Public Sub SetTabOrder(form As Form)
        Dim textBoxes As New List(Of Control)
        For Each control As Control In form.Controls
            If TypeOf control Is TextBox OrElse TypeOf control Is Guna.UI2.WinForms.Guna2TextBox Then
                textBoxes.Add(control)
            Else
                control.TabStop = False
            End If
        Next

        textBoxes.Sort(Function(a, b) a.Top.CompareTo(b.Top))

        Dim tabIndex As Integer = 1
        For Each textBox As Control In textBoxes
            textBox.TabIndex = tabIndex
            tabIndex += 1
        Next

        For Each control As Control In form.Controls
            If TypeOf control Is Button OrElse TypeOf control Is Guna.UI2.WinForms.Guna2Button Then
                AddHandler control.Enter, AddressOf Button_Enter
                AddHandler control.Leave, AddressOf Button_Leave
                control.BackColor = SystemColors.Control
                control.TabStop = True
                control.TabIndex = tabIndex
                tabIndex += 1
            End If
        Next
    End Sub


    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_center(Me)
        password.PasswordChar = "•"
        SetTabOrder(Me)
    End Sub

    Public Sub Form_center(ByVal frm As Form, Optional ByVal parent As Form = Nothing)

        Dim x As Integer
        Dim y As Integer
        Dim r As Rectangle

        If parent IsNot Nothing Then
            r = parent.ClientRectangle
            x = r.Width - frm.Width + parent.Left
            y = r.Height - frm.Height + parent.Top
        Else
            r = Screen.PrimaryScreen.WorkingArea
            x = r.Width - frm.Width
            y = r.Height - frm.Height
        End If

        x = CInt(x / 2)
        y = CInt(y / 2)

        frm.StartPosition = FormStartPosition.Manual
        frm.Location = New Point(x, y)
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged
    End Sub

    Private Sub Checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox.CheckedChanged
        If checkbox.Checked Then
            password.PasswordChar = ""
        Else
            password.PasswordChar = "•"
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles button.Click
        If CheckLogin(username.Text, password.Text) Then
            SystemSounds.Asterisk.Play()
            successfully.Show()
            Dashboard.Show()
            Dashboard.SwitchPanel(Table_Info)
            Me.Hide()
        ElseIf password.Text = "" And username.Text = "" Then
            SystemSounds.Beep.Play()
            notemptyusernameorpassword.Show()
            username.Focus()
        ElseIf username.Text = "" Then
            SystemSounds.Beep.Play()
            notemptyusername.Show()
            username.Focus()
        ElseIf password.Text = "" Then
            SystemSounds.Beep.Play()
            notemptypassword.Show()
            password.Focus()

        Else
            SystemSounds.Beep.Play()
            incrrect.Show()
            username.Clear()
            password.Clear()
            username.Focus()

        End If
    End Sub

    'function checkLogin
    Private Function CheckLogin(username As String, password As String) As Boolean
        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("users")

        ' Create a filter to find the document with the specified username and password
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.And(Builders(Of BsonDocument).Filter.Eq(Of String)("username", username), Builders(Of BsonDocument).Filter.Eq(Of String)("password", password))

        ' Count the number of documents that match the filter
        Dim count As Long = collection.CountDocuments(filter)

        Return (count = 1)
    End Function

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click

    End Sub
End Class
