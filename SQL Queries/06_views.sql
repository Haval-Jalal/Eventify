CREATE VIEW vw_PublicCustomers AS
SELECT 
    CustomerID,
    FirstName,
    LastName,
    CreatedAt
FROM Customers;
GO

CREATE VIEW vw_OrderReport AS
SELECT 
    o.OrderID,
    o.OrderDate,
    o.Status,
    c.FirstName,
    c.LastName,
    e.Title AS EventTitle,
    t.SeatNumber,
    r.PriceAtPurchase
FROM OrderRows r
JOIN Orders o ON r.OrderID = o.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Tickets t ON r.TicketID = t.TicketID
JOIN Events e ON t.EventID = e.EventID;
GO

SELECT * FROM vw_PublicCustomers;
SELECT * FROM vw_OrderReport;