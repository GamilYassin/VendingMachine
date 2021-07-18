CREATE TABLE [dbo].[UserTable]
(
	[Id]           INT           NOT NULL PRIMARY KEY IDENTITY,
    [UserName]     NVARCHAR (50) NOT NULL,
    [UserPassword] NVARCHAR (50) NULL,
    [Privilege]    NVARCHAR (50) NOT NULL,
)