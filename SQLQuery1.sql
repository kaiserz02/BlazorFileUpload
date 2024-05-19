USE TransactionDB;
GO
--CREATE TABLE Transactions (
--    ReferenceNumber NVARCHAR(20) NOT NULL UNIQUE,
--    Quantity INT NOT NULL,
--    Amount DECIMAL(18, 2) NOT NULL,
--    Name NVARCHAR(255) NOT NULL, 
--    TransactionDate DATETIMEOFFSET NULL, 
--    Symbol NVARCHAR(5) NOT NULL CHECK (LEN(Symbol) BETWEEN 3 AND 5), 
--    OrderSide NVARCHAR(4) CHECK (OrderSide IN ('Buy', 'Sell')),
--    OrderStatus NVARCHAR(9) CHECK (OrderStatus IN ('Open', 'Matched', 'Cancelled')) 
--);
Select * from Transactions

ALTER TABLE Transactions
DROP COLUMN TransactionDate;

ALTER TABLE Transactions
ADD TransactionDate DATETIMEOFFSET NULL;

INSERT INTO Transactions (ReferenceNumber, Quantity, Amount, Name, TransactionDate, Symbol, OrderSide, OrderStatus)
VALUES 
    ('REF001', 10, 100.50, 'Product A', '2024-05-19T12:30:00+00:00', 'ABC', 'Buy', 'Matched'),
    ('REF002', 20, 200.75, 'Product B', '2024-05-20T09:45:00-07:00', 'XYZ', 'Sell', 'Open'),
    ('REF003', 15, 150.25, 'Product C', '2024-05-21T15:20:00+03:00', 'DEF', 'Buy', 'Matched');
