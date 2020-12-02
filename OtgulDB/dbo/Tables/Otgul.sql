CREATE TABLE [dbo].[OtgulRecord] (
    [id]          INT            NOT NULL,
    [idUser]      INT            NOT NULL,
    [action]      NVARCHAR (50)  NOT NULL,
    [minutCount]  INT            NOT NULL,
    [idInitiator] INT            NOT NULL,
    [data]        DATETIME       NOT NULL,
    [idGuide]     INT            NOT NULL,
    [eventData]   DATETIME       NOT NULL,
    [comment]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OtgulRecord] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OtgulRecord_Guide] FOREIGN KEY ([idGuide]) REFERENCES [dbo].[Guide] ([id]),
    CONSTRAINT [FK_OtgulRecord_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([id])
);

