CREATE TABLE `Address` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Street` varchar(64) NOT NULL,
    `InteriorNumber` varchar(6) NULL,
    `ExteriorNumber` varchar(6) NULL,
    `ZipCode` varchar(6) NULL,
    `city` varchar(20) NULL,
    `State` varchar(20) NULL,
    `Country` varchar(20) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Administers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(20) NOT NULL,
    `LastName` varchar(32) NOT NULL,
    `Email` varchar(64) NOT NULL,
    `Phone` varchar(20) NULL,
    `UserName` varchar(6) NOT NULL,
    `Password` varchar(64) NOT NULL,
    `Role` varchar(15) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Catalogs` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(64) NOT NULL,
    `Description` text NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Pictures` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Metadata` text NULL,
    `DataRaw` varchar(1) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Products` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(20) NOT NULL,
    `Category` varchar(16) NOT NULL,
    `Description` text NULL,
    `Price` double NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Tools` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(20) NOT NULL,
    `Model` varchar(32) NOT NULL,
    `Description` text NULL,
    `Status` varchar(16) NOT NULL,
    `Type` varchar(16) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Customers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(20) NOT NULL,
    `LastName` varchar(32) NOT NULL,
    `Email` varchar(64) NOT NULL,
    `IdAddress` int NULL,
    `Phone` varchar(10) NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `fk_Customers_Address` FOREIGN KEY (`IdAddress`) REFERENCES `Address` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Administers_Pictures` (
    `IdAdministers` int NOT NULL,
    `IdPicture` int NOT NULL,
    CONSTRAINT `fk_Administers_Pictures_Administers` FOREIGN KEY (`IdAdministers`) REFERENCES `Administers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Administers_Pictures_Pictures` FOREIGN KEY (`IdPicture`) REFERENCES `Pictures` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Catalogs_Pictures` (
    `IdCatalog` int NOT NULL,
    `IdPicture` int NOT NULL,
    CONSTRAINT `fk_Catalogs_Pictures_Catalogs` FOREIGN KEY (`IdCatalog`) REFERENCES `Catalogs` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Catalogs_Pictures_Pictures` FOREIGN KEY (`IdPicture`) REFERENCES `Pictures` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Catalogs_Products` (
    `IdProduct` int NOT NULL,
    `IdCatalog` int NOT NULL,
    CONSTRAINT `fk_Catalogs_Products_Catalogs` FOREIGN KEY (`IdCatalog`) REFERENCES `Catalogs` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Catalogs_Products_Products` FOREIGN KEY (`IdProduct`) REFERENCES `Products` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Products_Pictures` (
    `IdProduct` int NOT NULL,
    `IdPicture` int NOT NULL,
    CONSTRAINT `fk_Products_Pictures_Pictures` FOREIGN KEY (`IdPicture`) REFERENCES `Pictures` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Products_Pictures_Products` FOREIGN KEY (`IdProduct`) REFERENCES `Products` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `LogsTools` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IdTool` int NOT NULL,
    `IdAdminister` int NOT NULL,
    `StartUse` datetime NOT NULL,
    `EndUse` datetime NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `fk_LogsTools_Administers` FOREIGN KEY (`IdAdminister`) REFERENCES `Administers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_LogsTools_Tool` FOREIGN KEY (`IdTool`) REFERENCES `Tools` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Tools_Pictures` (
    `IdTools` int NOT NULL,
    `IdPicture` int NOT NULL,
    CONSTRAINT `fk_Tools_Pictures_Pictures` FOREIGN KEY (`IdPicture`) REFERENCES `Pictures` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Tools_Pictures_Tools` FOREIGN KEY (`IdTools`) REFERENCES `Tools` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Customers_Pictures` (
    `IdCustomer` int NOT NULL,
    `IdPicture` int NOT NULL,
    CONSTRAINT `fk_Customers_Pictures_Customers` FOREIGN KEY (`IdCustomer`) REFERENCES `Customers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Customers_Pictures_Pictures` FOREIGN KEY (`IdPicture`) REFERENCES `Pictures` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Orders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `OrderDate` datetime NOT NULL,
    `DeliveryDate` datetime NOT NULL,
    `Address` int NULL,
    `Subtotal` double NOT NULL,
    `Total` double NOT NULL,
    `DeliveryMethod` varchar(16) NOT NULL,
    `DetailedInformation` text NULL,
    `Tracking` varbinary(16) NOT NULL DEFAULT (newid()),
    `Status` varchar(16) NOT NULL,
    `PaymentMethod` varchar(16) NOT NULL,
    `IdCustomer` int NOT NULL,
    `IdAdminister` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `fk_Orders_Administers` FOREIGN KEY (`IdAdminister`) REFERENCES `Administers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `fk_Orders_Customers` FOREIGN KEY (`IdCustomer`) REFERENCES `Customers` (`Id`) ON DELETE RESTRICT
);

CREATE UNIQUE INDEX `UQ__Address__3214EC0650DF4974` ON `Address` (`Id`);

CREATE UNIQUE INDEX `UQ__Administ__3214EC06F23652DC` ON `Administers` (`Id`);

CREATE INDEX `IX_Administers_Pictures_IdAdministers` ON `Administers_Pictures` (`IdAdministers`);

CREATE INDEX `IX_Administers_Pictures_IdPicture` ON `Administers_Pictures` (`IdPicture`);

CREATE UNIQUE INDEX `UQ__Catalogs__3214EC069D79A489` ON `Catalogs` (`Id`);

CREATE INDEX `IX_Catalogs_Pictures_IdCatalog` ON `Catalogs_Pictures` (`IdCatalog`);

CREATE INDEX `IX_Catalogs_Pictures_IdPicture` ON `Catalogs_Pictures` (`IdPicture`);

CREATE INDEX `IX_Catalogs_Products_IdCatalog` ON `Catalogs_Products` (`IdCatalog`);

CREATE INDEX `IX_Catalogs_Products_IdProduct` ON `Catalogs_Products` (`IdProduct`);

CREATE UNIQUE INDEX `UQ__Customer__3214EC06F6258619` ON `Customers` (`Id`);

CREATE INDEX `IX_Customers_IdAddress` ON `Customers` (`IdAddress`);

CREATE INDEX `IX_Customers_Pictures_IdCustomer` ON `Customers_Pictures` (`IdCustomer`);

CREATE INDEX `IX_Customers_Pictures_IdPicture` ON `Customers_Pictures` (`IdPicture`);

CREATE UNIQUE INDEX `UQ__LogsTool__3214EC06BB600FAA` ON `LogsTools` (`Id`);

CREATE INDEX `IX_LogsTools_IdAdminister` ON `LogsTools` (`IdAdminister`);

CREATE INDEX `IX_LogsTools_IdTool` ON `LogsTools` (`IdTool`);

CREATE UNIQUE INDEX `UQ__Orders__3214EC068F9DCEBA` ON `Orders` (`Id`);

CREATE INDEX `IX_Orders_IdAdminister` ON `Orders` (`IdAdminister`);

CREATE INDEX `IX_Orders_IdCustomer` ON `Orders` (`IdCustomer`);

CREATE UNIQUE INDEX `UQ__Pictures__3214EC069D4153E6` ON `Pictures` (`Id`);

CREATE UNIQUE INDEX `UQ__Products__3214EC0658BFAAF7` ON `Products` (`Id`);

CREATE INDEX `IX_Products_Pictures_IdPicture` ON `Products_Pictures` (`IdPicture`);

CREATE INDEX `IX_Products_Pictures_IdProduct` ON `Products_Pictures` (`IdProduct`);

CREATE UNIQUE INDEX `UQ__Tools__3214EC06EEF22EC7` ON `Tools` (`Id`);

CREATE INDEX `IX_Tools_Pictures_IdPicture` ON `Tools_Pictures` (`IdPicture`);

CREATE INDEX `IX_Tools_Pictures_IdTools` ON `Tools_Pictures` (`IdTools`);




