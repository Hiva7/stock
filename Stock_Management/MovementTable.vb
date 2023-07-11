Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson

Public Class MovementTable
    Private ReadOnly Table As New DataTable()
    Private Sub Table_Movement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Load the data from the collection
        Dim documents As List(Of BsonDocument) = collection.Find(New BsonDocument()).ToList()

        ' Create columns in the DataTable
        Table.Columns.Add("MovementID", GetType(Integer))
        Table.Columns.Add("Type", GetType(String))
        Table.Columns.Add("Quantity", GetType(Integer))
        Table.Columns.Add("Date", GetType(String))
        Table.Columns.Add("ItemID", GetType(Integer))
        Table.Columns.Add("StockID", GetType(Integer))

        ' Add rows to the DataTable
        For Each document As BsonDocument In documents
            Dim row As DataRow = Table.NewRow()
            row("MovementID") = document.GetValue("MovementID").AsInt32
            row("Type") = document.GetValue("Type").AsString
            row("Quantity") = document.GetValue("Quantity").AsInt32
            row("Date") = document.GetValue("Date").AsString()
            row("ItemID") = document.GetValue("ItemID").AsInt32
            row("StockID") = document.GetValue("StockID").AsInt32
            Table.Rows.Add(row)
        Next

        ' Update the Guna2DataGridView1 control
        Guna2DataGridView1.DataSource = Table
    End Sub

    Public Sub ReloadData()
        ' Clear the existing data
        Table.Clear()

        ' Reload the data from the database "Stock_Management_System"
        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Load the data from the collection
        Dim documents As List(Of BsonDocument) = collection.Find(New BsonDocument()).ToList()

        ' Add rows to the DataTable
        For Each document As BsonDocument In documents
            Dim row As DataRow = Table.NewRow()
            row("MovementID") = document.GetValue("MovementID").AsInt32
            row("Type") = document.GetValue("Type").AsString
            row("Quantity") = document.GetValue("Quantity").AsInt32
            row("Date") = document.GetValue("Date").AsString()
            row("ItemID") = document.GetValue("ItemID").AsInt32
            row("StockID") = document.GetValue("StockID").AsInt32
            Table.Rows.Add(row)
        Next

        ' Update the Guna2DataGridView1 control
        Guna2DataGridView1.DataSource = Table
    End Sub
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        MovementAdd.Show()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        MovementEdit.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        MovementDelete.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If String.IsNullOrEmpty(search.Text) Then
            ReloadData()
            Return
        End If

        ' Clear the existing data
        Table.Clear()

        ' Reload the data from the database "Stock_Management_System"
        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Load the data from the collection
        Dim filter As BsonDocument = New BsonDocument()
        If search.Text.StartsWith("ID: ") Then
            filter.Add("MovementID", Integer.Parse(search.Text.Substring(4)))
        ElseIf search.Text.StartsWith("Type: ") Then
            filter.Add("Type", search.Text.Substring(6))
        ElseIf search.Text.StartsWith("Quantity: ") Then
            filter.Add("Quantity", Integer.Parse(search.Text.Substring(10)))
        ElseIf search.Text.StartsWith("Date: ") Then
            filter.Add("Date", search.Text.Substring(6))
        ElseIf search.Text.StartsWith("ItemID: ") Then
            filter.Add("ItemID", Integer.Parse(search.Text.Substring(8)))
        ElseIf search.Text.StartsWith("StockID: ") Then
            filter.Add("StockID", Integer.Parse(search.Text.Substring(9)))
        Else
            MessageBox.Show("Invalid search format. Please enter a search query in the format 'Attribute: Value'.")
            Return
        End If

        Dim documents As List(Of BsonDocument) = collection.Find(filter).ToList()

        ' Add rows to the DataTable
        For Each document As BsonDocument In documents
            Dim row As DataRow = Table.NewRow()
            row("MovementID") = document.GetValue("MovementID").AsInt32
            row("Type") = document.GetValue("Type").AsString
            row("Quantity") = document.GetValue("Quantity").AsInt32
            row("Date") = document.GetValue("Date").AsString()
            row("ItemID") = document.GetValue("ItemID").AsInt32
            row("StockID") = document.GetValue("StockID").AsInt32
            Table.Rows.Add(row)
        Next

        ' Update the Guna2DataGridView1 control
        Guna2DataGridView1.DataSource = Table
    End Sub


End Class
