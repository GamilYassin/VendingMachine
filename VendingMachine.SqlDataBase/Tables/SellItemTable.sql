﻿CREATE TABLE [dbo].[SellItemTable]
(
	[Id]              INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Name]            NVARCHAR (50) NOT NULL,
    [Price]           NVARCHAR (50) NOT NULL,
    [Barcode]         NVARCHAR (20) NOT NULL,
    [ItemType]        NVARCHAR (50) NOT NULL,
)
