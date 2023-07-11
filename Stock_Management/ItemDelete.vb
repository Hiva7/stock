Imports System.Media
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson

Public Class ItemDelete
    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub ItemDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        ' Get the value from the Guna2TextBox
        Dim id As Integer = Integer.Parse(Guna2TextBox1.Text)

        ' Create a connection to the database
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")

        ' Create a filter to find the document to delete
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", id)

        ' Check if the document exists in the collection
        Dim count As Long = collection.CountDocuments(filter)
        If count = 0 Then
            ' The document does not exist, so display an error message and return without deleting anything
            MessageBox.Show("No record was found with this ID. Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Delete the document from the collection
        collection.DeleteOne(filter)
        ' Reload the data in the ItemTable form
        ItemTable.ReloadData()
        MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ReloadInfo
        Table_Info.ReloadInfo()
        Me.Close()
    End Sub

End Class
