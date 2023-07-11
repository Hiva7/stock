Imports System.Media
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization

Public Class MovementEdit
    ' Declare a MovementID property to hold the ID of the movement being edited
    Public Property MovementID As Integer

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub MovementEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Check if the ID field is empty
        If String.IsNullOrWhiteSpace(Guna2TextBox1.Text) Then
            ' The ID field is empty, so display an error message and return without updating the document
            MessageBox.Show("Please enter an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the ID from the Guna2TextBox1 control (this should never be empty)
        Dim id As Integer = Integer.Parse(Guna2TextBox1.Text)

        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")

        ' Get the Movement collection
        Dim movementCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Get the document with the specified MovementID
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("MovementID", id)
        Dim movementDocument As BsonDocument = movementCollection.Find(filter).FirstOrDefault()

        ' Check if the document was found
        If movementDocument Is Nothing Then
            ' The document was not found, so display an error message and return without updating the document
            MessageBox.Show("MovementID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the original values from the movement document
        Dim originalType As String = movementDocument("Type").AsString
        Dim originalQuantity As Integer = movementDocument("Quantity").AsInt32
        Dim originalDate As String = movementDocument("Date").AsString
        Dim originalItemId As Integer = movementDocument("ItemID").AsInt32
        Dim originalStockId As Integer = movementDocument("StockID").AsInt32

        ' Get the values from the Guna2TextBoxes (use the original values as defaults if the fields are empty)
        Dim type As String = If(String.IsNullOrWhiteSpace(Guna2TextBox2.Text), originalType, Guna2TextBox2.Text)
        Dim quantity As Integer = If(String.IsNullOrWhiteSpace(Guna2TextBox3.Text), originalQuantity, Integer.Parse(Guna2TextBox3.Text))
        Dim [date] As String = If(String.IsNullOrWhiteSpace(Guna2TextBox4.Text), originalDate, Guna2TextBox4.Text)
        Dim itemId As Integer = If(String.IsNullOrWhiteSpace(Guna2TextBox5.Text), originalItemId, Integer.Parse(Guna2TextBox5.Text))
        Dim stockId As Integer = If(String.IsNullOrWhiteSpace(Guna2TextBox6.Text), originalStockId, Integer.Parse(Guna2TextBox6.Text))

        ' Check if all fields are empty
        If String.IsNullOrWhiteSpace(Guna2TextBox2.Text) AndAlso String.IsNullOrWhiteSpace(Guna2TextBox3.Text) AndAlso String.IsNullOrWhiteSpace(Guna2TextBox4.Text) AndAlso String.IsNullOrWhiteSpace(Guna2TextBox5.Text) AndAlso String.IsNullOrWhiteSpace(Guna2TextBox6.Text) Then
            ' All fields are empty, so display an error message and return without updating the document
            MessageBox.Show("Please enter at least one value to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the type is valid ("In" or "Out")
        If type <> "In" AndAlso type <> "Out" Then
            ' The type is not valid, so display an error message and return without updating the document
            MessageBox.Show("Type must be either ""In"" or ""Out"".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the ItemID exists in the Item collection and get its price (for both original and new ItemIDs)
        Dim itemCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")
        Dim itemFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", itemId)
        Dim itemDocument As BsonDocument = itemCollection.Find(itemFilter).FirstOrDefault()
        If itemDocument Is Nothing Then
            ' The ItemID does not exist, so display an error message and return without updating the document
            MessageBox.Show("ItemID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the price of the item as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
        Dim itemPriceString As String = itemDocument("Price").AsString
        Dim itemPrice As Decimal = Decimal.Parse(itemPriceString.Substring(1))

        ' Get the price of the original item as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
        itemFilter = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", originalItemId)
        itemDocument = itemCollection.Find(itemFilter).FirstOrDefault()
        If itemDocument Is Nothing Then
            ' The original ItemID does not exist, so display an error message and return without updating the document
            MessageBox.Show("Original ItemID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim originalItemPriceString As String = itemDocument("Price").AsString
        Dim originalItemPrice As Decimal = Decimal.Parse(originalItemPriceString.Substring(1))

        ' Check if the StockID exists in the Stock collection and get its price and quantity (for both original and new StockIDs)
        Dim stockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")
        Dim stockFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("StockID", stockId)
        Dim stockDocument As BsonDocument = stockCollection.Find(stockFilter).FirstOrDefault()
        If stockDocument Is Nothing Then
            ' The StockID does not exist, so display an error message and return without updating the document
            MessageBox.Show("StockID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Calculate the total value of the movement (item price * quantity)
        Dim movementValue As Decimal = itemPrice * quantity

        ' Revert the changes to the stock collection based on the original values in the movement document
        stockFilter = Builders(Of BsonDocument).Filter.Eq(Of Integer)("StockID", originalStockId)
        stockDocument = stockCollection.Find(stockFilter).FirstOrDefault()
        If stockDocument Is Nothing Then
            ' The original StockID does not exist, so display an error message and return without updating the document
            MessageBox.Show("Original StockID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim stockPriceString As String = stockDocument("Price").AsString
        Dim stockPrice As Decimal = Decimal.Parse(stockPriceString.Substring(1))
        Dim stockQuantity As Integer = stockDocument("Quantity").AsInt32

        If originalType = "In" Then
            stockPrice -= originalItemPrice * originalQuantity
            stockQuantity -= originalQuantity
        Else ' originalType is "Out"
            stockPrice += originalItemPrice * originalQuantity
            stockQuantity += originalQuantity
        End If

        ' Check if the resulting stockQuantity is less than 0
        If (stockQuantity - quantity) < 0 AndAlso type = "Out" Then
            ' The resulting stockQuantity is less than 0, so display an error message and return without updating the Stock collection
            MessageBox.Show("Error: The resulting stock quantity cannot be less than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Format the updated stock price as a currency value with a dollar sign (for updating the Stock collection later)
        Dim format As NumberFormatInfo = CType(CultureInfo.InvariantCulture.NumberFormat.Clone(), NumberFormatInfo)
        format.CurrencySymbol = "$"
        Dim formattedStockPrice As String = stockPrice.ToString("C2", format)

        ' Update only one stock (the old one) in Stock collection based on newly edited values (using only new StockID).
        Dim update = Builders(Of BsonDocument).Update.Set(Of String)("Price", formattedStockPrice).Set(Of Integer)("Quantity", stockQuantity)
        stockCollection.UpdateOne(stockFilter, update)

        ' Update only one stock (the new one) in Stock collection based on newly edited values (using only new StockID).
        If type = "In" Then
            stockPrice += movementValue
            stockQuantity += quantity
        Else ' type is "Out"
            stockPrice -= movementValue
            stockQuantity -= quantity
        End If

        ' Format the updated stock price as a currency value with a dollar sign (for updating the Stock collection later)
        format = CType(CultureInfo.InvariantCulture.NumberFormat.Clone(), NumberFormatInfo)
        format.CurrencySymbol = "$"
        formattedStockPrice = stockPrice.ToString("C2", format)

        ' Create an update definition to update the document with the new values
        update = Builders(Of BsonDocument).Update _
        .Set(Of String)("Type", type) _
        .Set(Of Integer)("Quantity", quantity) _
        .Set(Of String)("Date", [date]) _
        .Set(Of Integer)("ItemID", itemId) _
        .Set(Of Integer)("StockID", stockId)

        ' Update the document in the Movement collection
        movementCollection.UpdateOne(filter, update)

        ' Update only one stock (the new one) in Stock collection based on newly edited values (using only new StockID).
        stockFilter = Builders(Of BsonDocument).Filter.Eq(Of Integer)("StockID", stockId)
        update = Builders(Of BsonDocument).Update.Set(Of String)("Price", formattedStockPrice).Set(Of Integer)("Quantity", stockQuantity)
        stockCollection.UpdateOne(stockFilter, update)

        ' Reload data in MovementTable and StockTable forms.
        MovementTable.ReloadData()
        StockTable.ReloadData()

        SystemSounds.Asterisk.Play()
        MessageBox.Show("Movement updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Closes the form
        Me.Close()
    End Sub
End Class