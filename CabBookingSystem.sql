


create database CabBooking

use CabBooking

create table Location(
ID int primary key identity,
Name varchar(25)
)

create table Distance(
DistanceId int primary key identity,
FromLocation int  foreign key references Location(ID),
ToLocation int foreign key references Location(ID),
Distanceinkm float)

create table Cab(
Id int identity,
CabId AS 'C00' + CAST(Id as varchar(20)) persisted primary key,
Cabname varchar(20),
Cabtype varchar(20),
fareperkm float,
CurrentLocation int foreign key references Location(ID),
Isavailable bit
)

create table Customer(
Mobile bigint primary key,
Username varchar(20),
Password varchar(20),
Email varchar(20))

create table Driver(
mobile bigint primary key,
Username varchar(20),
Password varchar(20),
licenseno varchar(40),
cabid varchar(23) foreign key references Cab(CabId),
Isapproved bit,
)

create table Booking(
Bookingid int primary key,
mobileno bigint foreign key references Customer(Mobile),
cabid varchar(23) foreign key references Cab(CabId),
fare float,
Gst float,
DistanceId int foreign key references Distance(DistanceId),
Otp int,
TotalFare money,
Status varchar(20),
Rating float)

Create Table Admin(
Username varchar(50) primary key,
Password varchar(25) not null)







