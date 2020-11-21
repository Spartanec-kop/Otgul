CREATE TABLE [dbo].[UserRights] (
    [idUser]  INT NOT NULL,
    [idRight] INT NOT NULL,
    CONSTRAINT [FK_userRights_Rights] FOREIGN KEY ([idRight]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_userRights_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([id])
);

