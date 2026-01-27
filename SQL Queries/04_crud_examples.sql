-- CRUD Customers

INSERT INTO Customers (FirstName, LastName, Email, Phone)
VALUES ('Test', 'User', 'test.user@mail.se', '0701112233');

-- READ
SELECT * FROM Customers WHERE Email = 'test.user@mail.se';

-- UPDATE
UPDATE Customers
SET Phone = '0709998887'
WHERE Email = 'test.user@mail.se';

-- DELETE
DELETE FROM Customers
WHERE Email = 'test.user@mail.se';


-- CRUD Events

INSERT INTO Events (Title, EventDate, VenueID, Price)
VALUES ('Test Event', '2026-05-01', 1, 499);

-- READ
SELECT * FROM Events WHERE Title = 'Test Event';

-- UPDATE
UPDATE Events
SET Price = 599
WHERE Title = 'Test Event';

-- DELETE
DELETE FROM Events
WHERE Title = 'Test Event';


--CRUD ORDERS
-- CREATE

INSERT INTO Orders (CustomerID, Status)
VALUES (1, 'Pending');

-- READ
SELECT * FROM Orders WHERE CustomerID = 1;

-- UPDATE
UPDATE Orders
SET Status = 'Paid'
WHERE OrderID = SCOPE_IDENTITY();

-- DELETE
DELETE FROM Orders
WHERE OrderID = SCOPE_IDENTITY();