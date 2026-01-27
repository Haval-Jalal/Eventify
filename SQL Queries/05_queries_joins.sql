-- Query 1 – Alla ordrar med kundinfo (JOIN)

SELECT 
    o.OrderID,
    o.OrderDate,
    o.Status,
    c.FirstName,
    c.LastName,
    c.Email
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID;

-- Query 2 – Alla biljetter med event + venue (JOIN)

SELECT 
    t.TicketID,
    t.SeatNumber,
    e.Title AS EventTitle,
    e.EventDate,
    v.Name AS Venue,
    v.City
FROM Tickets t
JOIN Events e ON t.EventID = e.EventID
JOIN Venues v ON e.VenueID = v.VenueID;


-- Query 3 – Alla orderrader med totalsumma per rad (JOIN)

SELECT 
    o.OrderID,
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


-- Query 4 – Senaste 10 ordrar (WHERE + ORDER BY)
SELECT TOP 10 *
FROM Orders
ORDER BY OrderDate DESC;

-- Query 5 – Antal sålda biljetter per event (GROUP BY)

SELECT 
    e.Title,
    COUNT(r.OrderRowID) AS TicketsSold
FROM OrderRows r
JOIN Tickets t ON r.TicketID = t.TicketID
JOIN Events e ON t.EventID = e.EventID
GROUP BY e.Title;

-- Query 6 – Total omsättning per event (GROUP BY)

SELECT 
    e.Title,
    SUM(r.PriceAtPurchase) AS TotalRevenue
FROM OrderRows r
JOIN Tickets t ON r.TicketID = t.TicketID
JOIN Events e ON t.EventID = e.EventID
GROUP BY e.Title;


-- Query 7 – Top 5 kunder med flest köp (Rapport)

SELECT TOP 5
    c.FirstName,
    c.LastName,
    COUNT(o.OrderID) AS TotalOrders
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.FirstName, c.LastName
ORDER BY TotalOrders DESC;


-- Query 8 – Senaste 20 köphändelser (Rapport)

SELECT TOP 20
    o.OrderID,
    c.FirstName,
    c.LastName,
    o.OrderDate,
    o.Status
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
ORDER BY o.OrderDate DESC;


