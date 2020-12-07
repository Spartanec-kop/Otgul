CREATE TABLE [dbo].[Guides] (
    [id]   INT          IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (60) NOT NULL,
    CONSTRAINT [PK_Guides] PRIMARY KEY CLUSTERED ([id] ASC)
);

