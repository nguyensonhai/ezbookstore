CREATE TABLE [Book] (
    [Id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (50)  NULL,
    [Author]      VARCHAR (50)  NULL,
    [Genre]       VARCHAR (50)  NULL,
	[Language]    VARCHAR (50)  NULL,
	[Price]       INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);