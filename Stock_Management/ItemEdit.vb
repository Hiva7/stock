Imports System.Media
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization

Public Class ItemEdit
    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ItemEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Check if ID field is empty
        If String.IsNullOrWhiteSpace(Guna2TextBox1.Text) Then
            ' Fields is empty, so display an error message and return without updating the document
            MessageBox.Show("Please enter ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the values from the Guna2TextBoxes
        Dim id As Integer = Integer.Parse(Guna2TextBox1.Text)
        Dim name As String = Guna2TextBox2.Text
        Dim price As String = Guna2TextBox5.Text
        Dim category As String = Guna2TextBox3.Text
        Dim description As String = Guna2TextBox4.Text

        ' Check if all fields are empty
        If String.IsNullOrWhiteSpace(name) AndAlso String.IsNullOrWhiteSpace(price) AndAlso String.IsNullOrWhiteSpace(category) AndAlso String.IsNullOrWhiteSpace(description) Then
            ' All fields are empty, so display an error message and return without updating the document
            MessageBox.Show("Please enter at least one value to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Format the price as a currency value with a dollar sign if it is not empty
        Dim formattedPrice As String = Nothing
        If Not String.IsNullOrWhiteSpace(price) Then
            Dim format As NumberFormatInfo = CType(CultureInfo.InvariantCulture.NumberFormat.Clone(), NumberFormatInfo)
            format.CurrencySymbol = "$"
            formattedPrice = Decimal.Parse(price).ToString("C2", format)
        End If

        ' Create a connection to the database
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")

        ' Create a filter to find the document to update
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", id)

        ' Create an update definition to specify the changes to make to the document
        Dim updateBuilder As UpdateDefinitionBuilder(Of BsonDocument) = Builders(Of BsonDocument).Update
        Dim update As UpdateDefinition(Of BsonDocument) = Nothing

        If Not String.IsNullOrWhiteSpace(name) Then
            update = updateBuilder.Set(Of String)("ItemName", name)
        End If

        If Not String.IsNullOrWhiteSpace(formattedPrice) Then
            update = If(update Is Nothing, updateBuilder.Set(Of String)("Price", formattedPrice), update.Set(Of String)("Price", formattedPrice))
        End If

        If Not String.IsNullOrWhiteSpace(category) Then
            update = If(update Is Nothing, updateBuilder.Set(Of String)("Category", category), update.Set(Of String)("Category", category))
        End If

        If Not String.IsNullOrWhiteSpace(description) Then
            update = If(update Is Nothing, updateBuilder.Set(Of String)("Description", description), update.Set(Of String)("Description", description))
        End If
        ' Update the document in the collection if at least one field is not empty
        If update IsNot Nothing Then
            collection.UpdateOne(filter, update)
            ' Reload the data in the ItemTable form
            ItemTable.ReloadData()
            MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub Guna2PictureBox1_Click_1(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub
End Class
