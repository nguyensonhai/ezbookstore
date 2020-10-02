CREATA DATABASE BookStoreDB
USE BookStoreDB

CREATE TABLE [Book] (
    [Id]          BIGINT   IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (50)  NULL,
    [Author]      VARCHAR (50)  NULL,
    [Genre]       VARCHAR (50)  NULL,
	[Language]    VARCHAR (50)  NULL,
	[Price]       INT			NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [Member] (
    [Id]			BIGINT   IDENTITY (1, 1) NOT NULL,
    [FirstName]     VARCHAR (50)  NULL,
    [LastName]      VARCHAR (50)  NULL,
    [DateOfBirth]   DATETIME	  NULL,
	[Phone]			INT			  NULL,
	[Email]			VARCHAR (50)  NULL,
	[Address]       VARCHAR (50)  NULL,
	[DateJoined]    DATETIME	  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO