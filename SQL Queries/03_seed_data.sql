USE Eventify;

INSERT INTO Venues (Name, City, Capacity) VALUES
('Globen Arena', 'Stockholm', 13000),
('Scandinavium', 'Göteborg', 12000),
('Malmö Arena', 'Malmö', 15000),
('Kulturhuset', 'Stockholm', 500);

INSERT INTO Customers (FirstName, LastName, Email, Phone) VALUES
('Anna', 'Svensson', 'anna.svensson@mail.se', '0701234567'),
('Erik', 'Johansson', 'erik.j@mail.se', '0702345678'),
('Sara', 'Nilsson', 'sara.nilsson@mail.se', '0703456789'),
('Johan', 'Karlsson', 'johan.k@mail.se', '0704567890'),
('Elin', 'Larsson', 'elin.l@mail.se', '0705678901'),
('Oskar', 'Andersson', 'oskar.a@mail.se', '0706789012'),
('Maja', 'Persson', 'maja.p@mail.se', '0707890123'),
('Lucas', 'Berg', 'lucas.b@mail.se', '0708901234'),
('Nora', 'Hansen', 'nora.h@mail.se', '0709012345'),
('David', 'Lind', 'david.l@mail.se', '0700123456');

INSERT INTO Events (Title, EventDate, VenueID, Price) VALUES
('Rock Night', '2026-02-10', 1, 599),
('Jazz Evening', '2026-02-12', 4, 299),
('Tech Conference', '2026-03-05', 1, 1299),
('Standup Comedy', '2026-02-20', 2, 399),
('Pop Festival', '2026-03-15', 3, 799),
('Classical Concert', '2026-04-01', 4, 499);

INSERT INTO Orders (CustomerID, Status) VALUES
(1, 'Paid'),
(2, 'Paid'),
(3, 'Pending'),
(4, 'Paid'),
(5, 'Cancelled'),
(6, 'Paid'),
(7, 'Paid'),
(8, 'Pending'),
(9, 'Paid'),
(10, 'Paid');

INSERT INTO Tickets (EventID, SeatNumber) VALUES
(1,'A1'),(1,'A2'),(1,'A3'),(1,'A4'),(1,'A5'),
(2,'B1'),(2,'B2'),(2,'B3'),(2,'B4'),(2,'B5'),
(3,'C1'),(3,'C2'),(3,'C3'),(3,'C4'),(3,'C5'),
(4,'D1'),(4,'D2'),(4,'D3'),(4,'D4'),(4,'D5'),
(5,'E1'),(5,'E2'),(5,'E3'),(5,'E4'),(5,'E5'),
(6,'F1'),(6,'F2'),(6,'F3'),(6,'F4'),(6,'F5');


INSERT INTO OrderRows (OrderID, TicketID, PriceAtPurchase) VALUES
(1,1,599),(1,2,599),(1,3,599),
(2,4,599),(2,5,599),(2,6,299),
(3,7,299),(3,8,299),(3,9,299),
(4,10,299),(4,11,1299),(4,12,1299),
(5,13,1299),(5,14,1299),(5,15,1299),
(6,16,399),(6,17,399),(6,18,399),
(7,19,399),(7,20,399),
(8,21,799),(8,22,799),
(9,23,799),(9,24,799),
(10,25,799),(10,26,499),(10,27,499);


INSERT INTO Payments (OrderID, Amount, Method) VALUES
(1,1797,'Card'),
(2,1497,'Swish'),
(4,1598,'Card'),
(6,1197,'Swish'),
(7,798,'Card'),
(9,1598,'Swish'),
(10,1797,'Card');