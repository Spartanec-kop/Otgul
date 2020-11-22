CREATE TABLE [dbo].[UserRights] (
    [idUser]  INT NOT NULL,
    [idRights] INT NOT NULL,
    CONSTRAINT [FK_userRights_Rights] FOREIGN KEY ([idRights]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_userRights_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([id])
);

