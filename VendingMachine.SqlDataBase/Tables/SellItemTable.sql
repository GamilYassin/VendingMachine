CREATE TABLE [dbo].[SellItemTable]
(
	[Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [Price]           NVARCHAR (50) NOT NULL,
    [Barcode]         NVARCHAR (20) NOT NULL,
    [ItemType]        NVARCHAR (50) NOT NULL,
    [GrandTotal]      INT           NOT NULL,
    [GrandSellAmount] NVARCHAR (50) NOT NULL,
)
