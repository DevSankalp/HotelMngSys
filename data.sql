CREATE TABLE Roles(
    RoleId INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(50)
) CREATE TABLE Users(
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50),
    PasswordHash NVARCHAR(200),
    RoleId INT,
    FOREIGN KEY(RoleId) REFERENCES Roles(RoleId)
) CREATE TABLE Rooms(
    RoomId INT PRIMARY KEY IDENTITY,
    RoomNumber NVARCHAR(10),
    RoomTypeId INT,
    TypeName NVARCHAR(50),
    Price DECIMAL(10, 2),
    Status NVARCHAR(20)
) CREATE TABLE Customers(
    CustomerId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
) CREATE TABLE Bookings(
    BookingId INT PRIMARY KEY IDENTITY,
    CustomerId INT,
    RoomId INT,
    CheckInDate DATETIME,
    CheckOutDate DATETIME,
    Status NVARCHAR(20),
    FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY(RoomId) REFERENCES Rooms(RoomId)
) CREATE TABLE Payments(
    PaymentId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    PaymentDate DATETIME,
    FOREIGN KEY(BookingId) REFERENCES Bookings(BookingId)
) CREATE TABLE Invoices(
    InvoiceId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    TotalAmount DECIMAL(10, 2),
    IssuedDate DATETIME,
    FOREIGN KEY(BookingId) REFERENCES Bookings(BookingId)
)