CREATE TABLE [dbo].OtgulRecords (
    [id]          BIGINT            IDENTITY (1, 1) NOT NULL,
    [userId]      INT            NOT NULL,
    [action]      BIT  NOT NULL,
    [minutCount]  INT            NOT NULL,
    [initiatorId] INT            NOT NULL,
    [date]        DATETIME       NOT NULL,
    [guideId]     INT            NOT NULL,
    [eventDate]   DATETIME       NOT NULL,
    [comment]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OtgulRecords] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OtgulRecords_Guides] FOREIGN KEY ([guideId]) REFERENCES [dbo].[Guides] ([id]),
    CONSTRAINT [FK_OtgulRecords_Users] FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([id])
);

