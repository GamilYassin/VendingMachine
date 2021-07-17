CREATE TABLE [dbo].[InsideBalanceTable]
(
	[Id]                INT IDENTITY (1, 1) NOT NULL,
    [VendingMachineId]  INT NOT NULL,
    [CentCount]         INT NOT NULL,
    [NickelCount]       INT NOT NULL,
    [DimeCount]         INT NOT NULL,
    [QuarterCount]      INT NOT NULL,
    [DollarCount]       INT NOT NULL,
    [FiveDollarCount]   INT NOT NULL,
    [TenDollarCount]    INT NOT NULL,
    [TwentyDollarCount] INT NOT NULL,
)
