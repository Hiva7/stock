Imports System.Media
Imports Guna.UI2.WinForms
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports System.Globalization

Public Class MovementDelete
    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub MovementDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SignIn.Form_center(Me)
        SignIn.SetTabOrder(Me)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Get the ID from the Guna2TextBox1 control
        Dim id As Integer = Integer.Parse(Guna2TextBox1.Text)

        ' Create a connection to the database "Stock_Management_System"
        Dim connectionString As String = "mongodb+srv://Hiva:Mister69420@final.yqeghak.mongodb.net/?retryWrites=true&w=majority"
        Dim client As MongoClient = New MongoClient(connectionString)
        Dim database As IMongoDatabase = client.GetDatabase("Stock_Management_System")

        ' Get the Movement collection
        Dim movementCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Movement")

        ' Find the document with the specified MovementID
        Dim movementFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("MovementID", id)
        Dim movementDocument As BsonDocument = movementCollection.Find(movementFilter).FirstOrDefault()

        ' Check if the document was found
        If movementDocument Is Nothing Then
            ' The document was not found, so display an error message and return without deleting the document
            MessageBox.Show("Movement not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the values from the movement document
        Dim type As String = movementDocument("Type").AsString
        Dim quantity As Integer = movementDocument("Quantity").AsInt32
        Dim itemId As Integer = movementDocument("ItemID").AsInt32
        Dim stockId As Integer = movementDocument("StockID").AsInt32

        ' Check if the ItemID exists in the Item collection and get its price
        Dim itemCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Item")
        Dim itemFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("ItemID", itemId)
        Dim itemDocument As BsonDocument = itemCollection.Find(itemFilter).FirstOrDefault()
        If itemDocument Is Nothing Then
            ' The ItemID does not exist, so display an error message and return without deleting the document
            MessageBox.Show("ItemID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the price of the item as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
        Dim itemPriceString As String = itemDocument("Price").AsString
        Dim itemPrice As Decimal = Decimal.Parse(itemPriceString.Substring(1))

        ' Check if the StockID exists in the Stock collection and get its price and quantity (if it exists)
        Dim stockCollection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("Stock")
        Dim stockFilter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of Integer)("StockID", stockId)
        Dim stockDocument As BsonDocument = stockCollection.Find(stockFilter).FirstOrDefault()

        If stockDocument IsNot Nothing Then
            ' The StockID exists, so get its price and quantity and update them based on the type of movement ("In" or "Out")
            ' Get the price of the stock as a decimal value (remove the dollar sign and parse the remaining string as a decimal)
            Dim stockPriceString As String = stockDocument("Price").AsString
            Dim stockPrice As Decimal = Decimal.Parse(stockPriceString.Substring(1))

            ' Get the quantity of the stock as an integer value
            Dim stockQuantity As Integer = stockDocument("Quantity").AsInt32

            ' Calculate the total value of the movement (item price * quantity)
            Dim movementValue As Decimal = itemPrice * quantity

            ' Update the price and quantity of the stock based on the type of movement ("In" or "Out")
            If type = "In" Then
                stockPrice -= movementValue
                stockQuantity -= quantity
            Else ' type is "Out"
                stockPrice += movementValue
                stockQuantity += quantity
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

            ' Update the price and quantity of the stock in the Stock collection
            Dim update As UpdateDefinition(Of BsonDocument) = Builders(Of BsonDocument).Update.Set(Of String)("Price", formattedStockPrice).Set(Of Integer)("Quantity", stockQuantity)
            stockCollection.UpdateOne(stockFilter, update)
        End If

        ' Delete the document from the Movement collection
        movementCollection.DeleteOne(movementFilter)

        ' Reload the data in the MovementTable and StockTable forms
        MovementTable.ReloadData()
        StockTable.ReloadData()

        ' Play a sound and show a message to indicate that the record was deleted successfully
        SystemSounds.Asterisk.Play()
        MessageBox.Show("Movement deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ReloadInfo
        Table_Info.ReloadInfo()
        ' Close the form
        Me.Close()
    End Sub
End Class
