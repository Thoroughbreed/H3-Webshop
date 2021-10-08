IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [Category] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Cities] (
    [PostNumber] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([PostNumber])
);
GO

CREATE TABLE [PriceDiscounts] (
    [PriceDiscountID] int NOT NULL IDENTITY,
    [DiscountCode] nvarchar(max) NULL,
    [DiscountValue] int NOT NULL,
    CONSTRAINT [PK_PriceDiscounts] PRIMARY KEY ([PriceDiscountID])
);
GO

CREATE TABLE [Vendors] (
    [VendorID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY ([VendorID])
);
GO

CREATE TABLE [Customers] (
    [CustomerID] int NOT NULL IDENTITY,
    [FName] nvarchar(max) NOT NULL,
    [LName] nvarchar(max) NOT NULL,
    [RoadName] nvarchar(max) NOT NULL,
    [RoadNumber] int NOT NULL,
    [PostNumber] int NOT NULL,
    [PhoneMain] nvarchar(max) NULL,
    [PhoneMobile] nvarchar(max) NULL,
    [OrderAmount] int NULL DEFAULT (0),
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID]),
    CONSTRAINT [FK_Customers_Cities_PostNumber] FOREIGN KEY ([PostNumber]) REFERENCES [Cities] ([PostNumber]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [Price] decimal(8,2) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [SKU] nvarchar(max) NOT NULL,
    [PriceDiscountID] int NULL,
    [CategoryID] int NOT NULL,
    [VendorID] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_PriceDiscounts_PriceDiscountID] FOREIGN KEY ([PriceDiscountID]) REFERENCES [PriceDiscounts] ([PriceDiscountID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Products_Vendors_VendorID] FOREIGN KEY ([VendorID]) REFERENCES [Vendors] ([VendorID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [CustomerID] int NOT NULL,
    [PurchaseDate] datetime2 NOT NULL,
    [OrderGuid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderItems] (
    [OrderID] int NOT NULL,
    [ProductID] int NOT NULL,
    [Amount] int NOT NULL,
    [LinePrice] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderID], [ProductID]),
    CONSTRAINT [FK_OrderItems_Orders_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItems_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'Category') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([CategoryID], [Category])
VALUES (1, N'Kød & pålæg'),
(2, N'Drikke'),
(3, N'Slik & chokolade'),
(4, N'Snacks, kiks & kage'),
(5, N'Nødder & bælgfrugter'),
(7, N'Glutenfri'),
(8, N'Bønner, frø & linser'),
(9, N'Frisk frugt & grønt');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'Category') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostNumber', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
    SET IDENTITY_INSERT [Cities] ON;
INSERT INTO [Cities] ([PostNumber], [Name])
VALUES (2400, N'København NV'),
(6300, N'Sønderborg'),
(6200, N'Aabenraa'),
(6270, N'Tønder'),
(6000, N'Kolding');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PostNumber', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
    SET IDENTITY_INSERT [Cities] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PriceDiscountID', N'DiscountCode', N'DiscountValue') AND [object_id] = OBJECT_ID(N'[PriceDiscounts]'))
    SET IDENTITY_INSERT [PriceDiscounts] ON;
INSERT INTO [PriceDiscounts] ([PriceDiscountID], [DiscountCode], [DiscountValue])
VALUES (1, NULL, 0),
(2, N'Vegan10', 10),
(3, NULL, 50),
(4, N'GrandOpening', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PriceDiscountID', N'DiscountCode', N'DiscountValue') AND [object_id] = OBJECT_ID(N'[PriceDiscounts]'))
    SET IDENTITY_INSERT [PriceDiscounts] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'VendorID', N'Name') AND [object_id] = OBJECT_ID(N'[Vendors]'))
    SET IDENTITY_INSERT [Vendors] ON;
INSERT INTO [Vendors] ([VendorID], [Name])
VALUES (7, N'Nutty Vegan'),
(1, N'Urtekram'),
(2, N'Naturli'),
(3, N'Dryk'),
(4, N'Veganz'),
(5, N'Happy Reindeer'),
(6, N'Wally and Whiz'),
(8, N'Vantastic Foods');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'VendorID', N'Name') AND [object_id] = OBJECT_ID(N'[Vendors]'))
    SET IDENTITY_INSERT [Vendors] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'CategoryID', N'Name', N'Price', N'PriceDiscountID', N'SKU', N'VendorID') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([ProductID], [CategoryID], [Name], [Price], [PriceDiscountID], [SKU], [VendorID])
VALUES (29, 9, N'Frugtkassen (min. 4 kg)', 165.0, 1, N'', NULL),
(3, 1, N'Naturel tofu', 19.95, 1, N'', 8),
(2, 1, N'Røget tofu', 19.95, 1, N'', 8),
(1, 1, N'Tunno - Vegansk tun', 32.95, 1, N'', 7),
(19, 3, N'Cosmopolitan Cube (vingummi)', 59.0, 1, N'', 6),
(18, 3, N'Mojito Cube (vingummi)', 59.0, 1, N'', 6),
(17, 3, N'Cosmopolitan Flowpack (vingummi)', 5.5, 1, N'', 6),
(16, 3, N'Mojito Flowpack (vingummi)', 5.5, 1, N'', 6),
(15, 3, N'Lakridshyl', 12.5, 1, N'', 5),
(14, 3, N'Finsk lakrids', 28.0, 1, N'', 5),
(26, 7, N'Hørfrømel', 19.95, 1, N'', 4),
(25, 7, N'Soya pasta', 30.95, 1, N'', 4),
(23, 4, N'Tang chips - sweet soy & sea salt', 12.95, 1, N'', 4),
(20, 3, N'Nuttercups - almonds (fyldte chokolader)', 14.95, 1, N'', 8),
(22, 4, N'Sour cream and onion linsechips', 28.95, 1, N'', 4),
(5, 1, N'Jackfruit confit', 22.0, 1, N'', 4),
(4, 1, N'Seitan med karry', 26.95, 1, N'', 4),
(11, 2, N'Vegansk Iskaffe', 17.95, 1, N'', 3),
(10, 2, N'Havrekakao', 19.95, 1, N'', 2),
(9, 2, N'Havredrik Barista Edition', 20.95, 1, N'', 2),
(8, 2, N'Havredrik (natural)', 19.95, 1, N'', 2),
(7, 2, N'Instant cappuccino pulpver', 69.0, 1, N'', 2),
(28, 7, N'Shirataki ris', 18.95, 1, N'', 1),
(27, 7, N'Shirataki nudler', 16.95, 1, N'', 1),
(13, 3, N'Candy Kittens - cherry flavour', 32.0, 1, N'', 1),
(12, 3, N'Veganske trøfler i gaveæske (salted caramel)', 55.0, 1, N'', 1),
(6, 2, N'Økologisk kokosmælk', 19.95, 1, N'', 1),
(21, 4, N'Sour cream and onion kartoffelchips', 28.95, 1, N'', 4),
(24, 4, N'Veganske flæskevær', 19.95, 1, N'', 8);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'CategoryID', N'Name', N'Price', N'PriceDiscountID', N'SKU', N'VendorID') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

CREATE INDEX [IX_Customers_PostNumber] ON [Customers] ([PostNumber]);
GO

CREATE INDEX [IX_OrderItems_ProductID] ON [OrderItems] ([ProductID]);
GO

CREATE INDEX [IX_Orders_CustomerID] ON [Orders] ([CustomerID]);
GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);
GO

CREATE INDEX [IX_Products_PriceDiscountID] ON [Products] ([PriceDiscountID]);
GO

CREATE INDEX [IX_Products_VendorID] ON [Products] ([VendorID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211007190911_DataSeeding', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'PurchaseDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Orders] ADD DEFAULT (getdate()) FOR [PurchaseDate];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderGuid');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Orders] ADD DEFAULT (newid()) FOR [OrderGuid];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211007200207_AddingDefaultValues', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211007200908_Non-mapped orderSum', N'5.0.10');
GO

COMMIT;
GO

