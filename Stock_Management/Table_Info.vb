Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization
Public Class Table_Info

    Private Sub Table_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Date
        Dim currentDate As DateTime = DateTime.Now
        Dim formattedDate As String = currentDate.ToString("dddd dd MMMM yyyy", CultureInfo.InvariantCulture)
        Guna2HtmlLabel1.Text = formattedDate

        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")

        ' Count documents in Stock collection
        Dim stockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")
        Dim stockCount As Long = stockCollection.CountDocuments(New BsonDocument())
        Label1.Text = stockCount.ToString()

        ' Count documents in Item collection
        Dim itemCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")
        Dim itemCount As Long = itemCollection.CountDocuments(New BsonDocument())
        Label2.Text = itemCount.ToString()

        ' Count documents in Movement_Stock collection
        Dim movementStockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")
        Dim movementStockCount As Long = movementStockCollection.CountDocuments(New BsonDocument())
        Label4.Text = movementStockCount.ToString()
    End Sub

    Public Sub ReloadInfo()
        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")

        ' Count documents in Stock collection
        Dim stockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")
        Dim stockCount As Long = stockCollection.CountDocuments(New BsonDocument())
        Label1.Text = stockCount.ToString()

        ' Count documents in Item collection
        Dim itemCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")
        Dim itemCount As Long = itemCollection.CountDocuments(New BsonDocument())
        Label2.Text = itemCount.ToString()

        ' Count documents in Movement_Stock collection
        Dim movementStockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")
        Dim movementStockCount As Long = movementStockCollection.CountDocuments(New BsonDocument())
        Label4.Text = movementStockCount.ToString()
    End Sub
End Class
