USE Eventify;



CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Venues (
    VenueID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    City NVARCHAR(50) NOT NULL,
    Capacity INT NOT NULL CHECK (Capacity > 0)
);


CREATE TABLE Events (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    EventDate DATETIME NOT NULL,
    VenueID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Events_Venues
        FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)
);


CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Pending','Paid','Cancelled')),

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE TABLE Tickets (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    EventID INT NOT NULL,
    SeatNumber NVARCHAR(10) NOT NULL,

    CONSTRAINT FK_Tickets_Events
        FOREIGN KEY (EventID) REFERENCES Events(EventID),

    CONSTRAINT UQ_Tickets_Event_Seat
        UNIQUE (EventID, SeatNumber)
);


CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    Method NVARCHAR(30) NOT NULL,

    CONSTRAINT FK_Payments_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);


CREATE TABLE OrderRows (
    OrderRowID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    TicketID INT NOT NULL,
    PriceAtPurchase DECIMAL(10,2) NOT NULL CHECK (PriceAtPurchase >= 0),

    CONSTRAINT FK_OrderRows_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),

    CONSTRAINT FK_OrderRows_Tickets
        FOREIGN KEY (TicketID) REFERENCES Tickets(TicketID),

    CONSTRAINT UQ_OrderRows_Order_Ticket
        UNIQUE (OrderID, TicketID)
);