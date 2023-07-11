Imports System.Windows
Imports System.Media

Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Forms.SignIn.Form_center(Me)
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Close()
        SignIn.Close()
    End Sub
    Private Sub Guna2GradientButton7_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton7.Click
        Me.Close()
        SignIn.Close()
    End Sub

    Private Sub Guna2GradientButton6_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton6.Click
        SystemSounds.Beep.Play()
        Dim result As DialogResult = SignOutMessage.Show()

        If result = DialogResult.Yes Then
            SignIn.Show()
            SignIn.username.Text = ""
            SignIn.password.Text = ""
            SignIn.username.Focus()
            Me.Hide()
        End If
    End Sub
    Sub SwitchPanel(ByVal panel As Form)
        panelStockManagementSystem.Controls.Clear()
        panel.TopLevel = False
        panelStockManagementSystem.Controls.Add(panel)
        panel.Size = panelStockManagementSystem.Size
        panel.Show()
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        SwitchPanel(StockTable)
    End Sub

    Private Sub Guna2GradientButton4_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton4.Click
        SwitchPanel(ItemTable)
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        SwitchPanel(Table_Info)
    End Sub

    Private Sub Guna2GradientButton5_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton5.Click
        SwitchPanel(StockTable)
        SwitchPanel(MovementTable)
    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs)

    End Sub
End Class
