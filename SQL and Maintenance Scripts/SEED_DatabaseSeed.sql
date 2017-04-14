USE [ShufflepuffBang]

INSERT INTO Customer (Name, StreetAddress, City, State, Zip, Phone)
VALUES ('Alex Sabertooth', '123 Concord Lane', 'Brentwood', 'TN', '37027', '555-555-5555')

INSERT INTO Invoice (PaymentId)
VALUES (1)

INSERT INTO OrderLine (InvoiceId, ProductId, Quantity)
VALUES(1, 1, 1)

INSERT INTO Payment (Type, CustomerId, AccountNumber)
VALUES ('Visa', 1, 12345)

INSERT INTO Product (Name, Price)
VALUES ('Orange', '00.59')

