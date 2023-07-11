Imports System.Media
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization

Public Class MovementAdd
    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub MovementAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        ' Check if any of the fields are empty
        If String.IsNullOrWhiteSpace(Guna2TextBox2.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox3.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox4.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox5.Text) OrElse String.IsNullOrWhiteSpace(Guna2TextBox6.Text) Then
            ' One or more fields are empty, so display an error message and return without inserting a new document
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the values from the Guna2TextBoxes
        Dim type As String = Guna2TextBox2.Text
        Dim quantity As Integer = Integer.Parse(Guna2TextBox3.Text)
        Dim [date] As String = Guna2TextBox4.Text
        Dim itemId As Integer = Integer.Parse(Guna2TextBox5.Text)
        Dim stockId As Integer = Integer.Parse(Guna2TextBox6.Text)

        ' Check if the type is valid ("In" or "Out")
        If type <> "In" AndAlso type <> "Out" Then
            ' The type is not valid, so display an error message and return without inserting a new document
            MessageBox.Show("Type must be either ""In"" or ""Out"".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")

        ' Check if the ItemID exists in the Item collection and get its price
        Dim itemCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")
        Dim itemFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", itemId)
        Dim itemDocument As BsonDocument = itemCollection.Find(itemFilter).FirstOrDefault()
        If itemDocument Is Nothing Then
            ' The ItemID does not exist, so display an error message and return without inserting a new document
            MessageBox.Show("ItemID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the price of the item as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
        Dim itemPriceString As String = itemDocument("Price").AsString
        Dim itemPrice As Decimal = Decimal.Parse(itemPriceString.Substring(1))

        ' Check if the StockID exists in the Stock collection and get its price and quantity
        Dim stockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")
        Dim stockFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("StockID", stockId)
        Dim stockDocument As BsonDocument = stockCollection.Find(stockFilter).FirstOrDefault()
        If stockDocument Is Nothing Then
            ' The StockID does not exist, so display an error message and return without inserting a new document
            MessageBox.Show("StockID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the price of the stock as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
        Dim stockPriceString As String = stockDocument("Price").AsString
        Dim stockPrice As Decimal = Decimal.Parse(stockPriceString.Substring(1))

        ' Get the quantity of the stock as an integer value
        Dim stockQuantity As Integer = stockDocument("Quantity").AsInt32

        ' Calculate the total value of the movement (item price * quantity)
        Dim movementValue As Decimal = itemPrice * quantity

        ' Update the price and quantity of the stock based on the type of movement ("In" or "Out")
        If type = "In" Then
            stockPrice += movementValue
            stockQuantity += quantity
        Else ' type is "Out"
            stockPrice -= movementValue
            stockQuantity -= quantity
        End If

        ' Check if the resulting stockQuantity is less than 0
        If stockQuantity < 0 Then
            ' The resulting stockQuantity is less than 0, so display an error message and return without updating the Stock collection
            MessageBox.Show("Error: The resulting stock quantity cannot be less than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Format the updated stock price as a currency value with a dollar sign (for updating the Stock collection later)
        Dim format As NumberFormatInfo = CType(CultureInfo.InvariantCulture.NumberFormat.Clone(), NumberFormatInfo)
        format.CurrencySymbol = "$"
        Dim formattedStockPrice As String = stockPrice.ToString("C2", format)

        ' Get the Movement collection
        Dim movementCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Find the highest existing ID in the collection
        Dim sort As SortDefinition(Of BsonDocument) = Builders(Of BsonDocument).Sort.Descending("MovementID")
        Dim highestIdDocument As BsonDocument = movementCollection.Find(New BsonDocument()).Sort(sort).FirstOrDefault()
        Dim highestId As Integer = If(highestIdDocument Is Nothing, 0, highestIdDocument("MovementID").AsInt32)

        ' Set the ID of the new document to one more than the highest existing ID
        Dim id As Integer = highestId + 1

        ' Create a document to insert into the Movement collection
        Dim movementDocument As BsonDocument = New BsonDocument() _
            .Add("MovementID", id) _
            .Add("Type", type) _
            .Add("Quantity", quantity) _
            .Add("Date", [date]) _
            .Add("ItemID", itemId) _
            .Add("StockID", stockId)

        ' Update the price and quantity of the stock in the Stock collection
        Dim update As UpdateDefinition(Of BsonDocument) = Builders(Of BsonDocument).Update.Set(Of String)("Price", formattedStockPrice).Set(Of Integer)("Quantity", stockQuantity)
        stockCollection.UpdateOne(stockFilter, update)

        ' Insert the document into the Movement collection
        movementCollection.InsertOne(movementDocument)

        ' Reload the data in the MovementTable and StockTable forms
        MovementTable.ReloadData()
        StockTable.ReloadData()

        ' Play a sound and show a message to indicate that the record was added successfully
        SystemSounds.Asterisk.Play()
        MessageBox.Show("Movement added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ReloadInfo
        Table_Info.ReloadInfo()
        ' Close the form
        Me.Close()
    End Sub
End Class
