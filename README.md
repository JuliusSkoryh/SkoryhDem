INSERT INTO Suppliers (Id, Name, Type, TIN)
VALUES 
  (NEWID(), 'Supplier 1', 'Type A', '123456789012'),
  (NEWID(), 'Supplier 2', 'Type B', '987654321098');

  INSERT INTO Materials (Id, Name, Type, QuantityInPackaging, Measurement, Image, Cost, QuantityInStorage, SupplierId)
VALUES 
  (NEWID(), 'Material 1', 'Type 1', 10, 'kg', NULL, 100.50, 100, (SELECT Id FROM Suppliers WHERE Name = 'Supplier 1')),
  (NEWID(), 'Material 2', 'Type 2', 20, 'm', NULL, 200.75, 200, (SELECT Id FROM Suppliers WHERE Name = 'Supplier 2'));

  INSERT INTO Partners (Id, Type, Name, Director, Email, Phone, LegalAddress, TIN, Rating, Logo)
VALUES 
  (NEWID(), 'Type A', 'Partner 1', 'Director 1', 'partner1@email.com', '123-456-7890', 'Address 1', '123456789012', 1, NULL),
  (NEWID(), 'Type B', 'Partner 2', 'Director 2', 'partner2@email.com', '987-654-3210', 'Address 2', '987654321098', 2, NULL);
