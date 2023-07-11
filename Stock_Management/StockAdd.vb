Imports System.Collections.ObjectModel
Imports System.Media
Imports System.Web.UI.WebControls
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization

Public Class StockAdd
    Private Sub AddStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click


        ' Check if any of the fields are empty
        If String.IsNullOrWhiteSpace(Guna2TextBox2.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox3.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox4.Text) Then
            ' One or more fields are empty, so display an error message and return without inserting a new document
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the values from the Guna2TextBoxes
        Dim name As String = Guna2TextBox2.Text
        Dim quantity As Integer = Integer.Parse(Guna2TextBox3.Text)
        Dim price As Decimal = Decimal.Parse(Guna2TextBox4.Text)


        ' Format the price as a currency value with a dollar sign
        Dim format As NumberFormatInfo = CType(CultureInfo.InvariantCulture.NumberFormat.Clone(), NumberFormatInfo)
        format.CurrencySymbol = "$"
        Dim formattedPrice As String = price.ToString("C2", format)


        ' Create a connection to the database
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")

        ' Find the highest existing ID in the collection
        Dim sort As SortDefinition(Of BsonDocument) = Builders(Of BsonDocument).Sort.Descending("StockID")
        Dim highestIdDocument As BsonDocument = collection.Find(New BsonDocument()).Sort(sort).FirstOrDefault()
        Dim highestId As Integer = If(highestIdDocument Is Nothing, 0, highestIdDocument("StockID").AsInt32)

        ' Set the ID of the new document to one more than the highest existing ID
        Dim id As Integer = highestId + 1

        ' Create a document to insert into the collection
        Dim document As BsonDocument = New BsonDocument() _
            .Add("StockID", id) _
            .Add("StockName", name) _
            .Add("Quantity", quantity) _
            .Add("Price", formattedPrice)

        ' Insert the document into the collection
        collection.InsertOne(document)
        StockTable.ReloadData()

        ' Play a sound and show a message to indicate that the record was added successfully
        SystemSounds.Asterisk.Play()
        MessageAdded.Show()
        'ReloadInfo
        Table_Info.ReloadInfo()
        ' Close the form
        Me.Close()
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub
End Class
