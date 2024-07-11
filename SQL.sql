CREATE DATABASE HotelManagement;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Facilities')
	CREATE TABLE Facilities (
		facility_id INT IDENTITY(1, 1) NOT NULL,
		facility_name NVARCHAR(100) NOT NULL,		
		CONSTRAINT PK_Facilities_facility_id PRIMARY KEY (facility_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Rooms')
	CREATE TABLE dbo.Rooms (
		room_id INT IDENTITY(1, 1) NOT NULL,
		room_number INT NOT NULL,
		room_type NVARCHAR(50) NOT NULL,
		price_per_night INT NOT NULL,
		availability NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_Rooms_room_id PRIMARY KEY (room_id)		
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'RoomsToFacilities')
	CREATE TABLE dbo.RoomsToFacilities (
		room_id INT  NOT NULL,
		facility_id INT NOT NULL,		
		CONSTRAINT PK_RoomsToFacilities_room_id PRIMARY KEY (room_id),

		CONSTRAINT FK_RoomsToFacilities_facility_id
			FOREIGN KEY (facility_id) REFERENCES dbo.Facilities (facility_id),
		CONSTRAINT FK_RoomsToFacilities_room_id
			FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id)
	);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Customers')
	CREATE TABLE dbo.Customers (
		customer_id INT IDENTITY(1, 1) NOT NULL,
		first_name NVARCHAR(100) NOT NULL,
		last_name NVARCHAR(100) NOT NULL,
		email NVARCHAR(100) NOT NULL,
		phone_number NVARCHAR(30) NOT NULL,
		CONSTRAINT PK_Customers_customer_id PRIMARY KEY (customer_id)
	);
	
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Bookings')
	CREATE TABLE dbo.Bookings (
		booking_id INT IDENTITY(1, 1) NOT NULL,
		customer_id INT NOT NULL,
		room_id INT NOT NULL,
		check_in_date DATE NOT NULL,
		check_out_date DATE NOT NULL,
		CONSTRAINT PK_Bookings_booking_id PRIMARY KEY (booking_id),

		CONSTRAINT FK_Bookings_customer_id
			FOREIGN KEY (customer_id) REFERENCES dbo.Customers (customer_id),
		CONSTRAINT FK_Bookings_room_id
			FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id)
	);

INSERT INTO dbo.Facilities (facility_name)
VALUES
	('WI-FI'),
	('Air conditioner'),
	('Mini bar'),
	('TV'),
	('Safe'),
	('Telephone');

INSERT INTO dbo.Rooms(room_number, room_type, price_per_night, availability)
VALUES
	(125, 'Single', 2500, 'Free'),
	(135, 'Double', 3500, 'Free'),
	(145, 'Double', 3500, 'Busy'),
	(126, 'Single', 2500, 'Busy'),
	(155, 'Triple', 5500, 'Free'),
	(157, 'Triple', 5500, 'Busy');

INSERT INTO dbo.RoomsToFacilities(room_id, facility_id)
VALUES
	(1, 2),
	(2, 1),
	(3, 3),
	(4, 6),
	(5, 4),
	(6, 5);

INSERT INTO dbo.Customers(first_name, last_name, email, phone_number)
VALUES
	('Alexey', 'Dimitrov', 'alexdim@mail.ru', '+79515465845'),
	('Maksim', 'Severov', 'makssev@mail.ru', '+78526548435'),
	('Alina', 'Ivanova', 'alinivano@mail.ru', '+79685466543');

INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date)
VALUES
	(1, 3, '2024-07-10', '2024-07-28'),
	(2, 4, '2024-07-9', '2024-07-25'),
	(3, 6, '2024-07-11', '2024-07-29');

/*Find all available rooms to book today*/
SELECT * FROM dbo.Rooms
WHERE availability = 'Free';

/*Find all clients whose last names begin with a letter "S"*/
SELECT * FROM dbo.Customers
WHERE last_name LIKE 'S%';

/*Find all bookings for a specific customer (by name or email)*/
SELECT * FROM dbo.Bookings B
JOIN dbo.Customers C
ON B.customer_id = C.customer_id
WHERE C.first_name = 'Alexey';

/*Find all bookings for a specific room*/
SELECT * FROM dbo.Bookings B
JOIN dbo.Rooms R
ON B.room_id = R.room_id
WHERE R.room_number = 145;

/*Find all rooms that are not booked for a specific date*/
SELECT * FROM dbo.Rooms R
JOIN dbo.Bookings B
ON R.room_id = B.room_id
WHERE ('2024-07-15' < B.check_in_date) OR (B.check_out_date > '2024-07-15');
