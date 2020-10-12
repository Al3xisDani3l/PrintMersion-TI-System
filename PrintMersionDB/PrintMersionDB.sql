use master;
go

if (exists (select name from master.dbo.sysdatabases where [name] = 'PrintMersionDB'))
drop database PrintMersionDB;

go

create database PrintMersionDB;
go
use PrintMersionDB;
go


if object_id('Product') is not null
drop table Product;

if object_id('Catalogs') is not null
drop table Catologs;

if object_id('Orders') is not null
drop table Orders;

if object_id('Customers') is not null
drop table Customers;

if object_id('Administers') is not null
drop table Administers;

if object_id('Pictures') is not null
drop table Pictures;

if object_id('Tools') is not null
drop table Tools;

if object_id('Address') is not null
drop table [Address];

if object_id('LogsTools') is not null
drop table LogsTools;


CREATE TABLE Products(
Id int not null IDENTITY(1, 1) unique,
[Name] varchar(20) not null,
Category varchar(16) not null,
[Description] varchar(max),
[Price] float not null,
Constraint pk_Products primary key (Id)
)

CREATE TABLE Catalogs(
Id int not null IDENTITY(1, 1) unique,
[Name] varchar(64) not null,
[Description] varchar(max),
Constraint pk_Catalogs primary key (Id)
)



CREATE TABLE Pictures(
Id Int not null IDENTITY(1, 1) unique,
Metadata varchar(max),
DataRaw varchar,
constraint pk_Pictures primary key (Id)
)





CREATE TABLE Orders(
Id int not null IDENTITY(1, 1) unique,
OrderDate datetime not null,
DeliveryDate datetime not null,
[Address] int,
Subtotal float not null,
Total float not null,
DeliveryMethod varchar(16) not null,
DetailedInformation varchar(max),
Tracking UNIQUEIDENTIFIER default NEWID() NOT NULL,
[Status] varchar(16) not null,
PaymentMethod varchar(16) not null,
IdCustomer int not null,
IdAdminister int,
constraint pk_Orders primary key (Id))


CREATE TABLE Customers(
Id int not null IDENTITY(1, 1) unique,
FirstName varchar(20) not null,
LastName varchar(32) not null,
Email varchar(64) not null,
IdAddress int,
Phone varchar(10),
constraint pk_Custumers primary key (Id))

CREATE TABLE Administers(
Id Int not null IDENTITY(1, 1) unique,
FirstName varchar(20) not null,
LastName varchar(32) not null,
Email varchar(64) not null,
Phone varchar(10),
UserName varchar(6) not null,
[Password] varchar(64) not null,
constraint pk_Administers primary key (Id))

CREATE TABLE [Address](
Id int not null IDENTITY(1, 1) unique,
Street varchar(64) not null,
InteriorNumber varchar(6),
ExteriorNumber varchar(6),
ZipCode varchar(6),
city varchar(20),
[State] varchar(20),
Country varchar(20),
constraint pk_Address primary key (Id))

CREATE TABLE Tools(
Id int not null IDENTITY(1, 1) unique,
[Name] varchar(20) not null,
Model varchar(32) not null,
[Description] varchar(Max),
[Status] varchar(16) not null,
[Type] varchar(16) not null,
constraint pk_Tools primary key (Id))


Create table LogsTools(
Id int not null IDENTITY(1, 1) unique,
IdTool int not null,
IdAdminister int not null,
StartUse datetime not null,
EndUse DateTime not null,
constraint pk_LogsTools primary key (Id))

go

--Creacion de las relacion uno a muchos

ALTER TABLE Orders add constraint fk_Orders_Customers foreign key (IdCustomer) references Customers(Id);

ALTER TABLE Orders add constraint fk_Orders_Administers foreign key (IdAdminister) references Administers(Id);
 
ALTER TABLE Customers add constraint fk_Customers_Address foreign key (IdAddress)  references [Address](Id);

ALTER TABLE LogsTools add constraint fk_LogsTools_Tool foreign key (IdTool)  references Tools(Id);

ALTER TABLE LogsTools add constraint fk_LogsTools_Administers foreign key (IdAdminister)  references Administers(Id);


go


--Creacion de las relaciones muchos a muchos

CREATE TABLE Products_Pictures(
IdProduct int not null,
IdPicture int not null,
constraint fk_Products_Pictures_Products foreign key (IdProduct) references Products(Id),
constraint fk_Products_Pictures_Pictures foreign key (IdPicture) references Pictures(Id)
)

CREATE TABLE Catalogs_Pictures(
IdCatalog int not null,
IdPicture int not null,
constraint fk_Catalogs_Pictures_Catalogs foreign key (IdCatalog) references Catalogs(Id),
constraint fk_Catalogs_Pictures_Pictures foreign key (IdPicture) references Pictures(Id)
)

CREATE TABLE Customers_Pictures(
IdCustomer int not null,
IdPicture int not null,
constraint fk_Customers_Pictures_Customers foreign key (IdCustomer) references Customers(Id),
constraint fk_Customers_Pictures_Pictures foreign key (IdPicture) references Pictures(Id)
)

CREATE TABLE Administers_Pictures(
IdAdministers int not null,
IdPicture int not null,
constraint fk_Administers_Pictures_Administers foreign key (IdAdministers) references Administers(Id),
constraint fk_Administers_Pictures_Pictures foreign key (IdPicture) references Pictures(Id)
)

CREATE TABLE Tools_Pictures(
IdTools int not null,
IdPicture int not null,
constraint fk_Tools_Pictures_Tools foreign key (IdTools) references Tools(Id),
constraint fk_Tools_Pictures_Pictures foreign key (IdPicture) references Pictures(Id)
)

CREATE TABLE Catalogs_Products(
IdProduct int not null,
IdCatalog int not null,
constraint fk_Catalogs_Products_Products foreign key (IdProduct) references Products(Id),
Constraint fk_Catalogs_Products_Catalogs foreign key (IdCatalog) references Catalogs(Id)
)




