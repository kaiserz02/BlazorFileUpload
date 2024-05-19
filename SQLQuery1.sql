USE TransactionDB;
GO
--CREATE TABLE Transactions (
--    ReferenceNumber NVARCHAR(20) NOT NULL UNIQUE,
--    Quantity INT NOT NULL,
--    Amount DECIMAL(18, 2) NOT NULL,
--    Name NVARCHAR(255) NOT NULL, 
--    TransactionDate DATETIME NULL, 
--    Symbol NVARCHAR(5) NOT NULL CHECK (LEN(Symbol) BETWEEN 3 AND 5), 
--    OrderSide NVARCHAR(4) CHECK (OrderSide IN ('Buy', 'Sell')),
--    OrderStatus NVARCHAR(9) CHECK (OrderStatus IN ('Open', 'Matched', 'Cancelled')) 
--);
Select * from Transactions

ALTER TABLE Transactions
DROP COLUMN TransactionDate;