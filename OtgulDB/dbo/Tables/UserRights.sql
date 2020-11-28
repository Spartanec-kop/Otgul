CREATE TABLE [dbo].[UserRights] (
    [UserId]  INT NOT NULL,
    [RightsId] INT NOT NULL,
    CONSTRAINT [FK_userRights_Rights] FOREIGN KEY ([RightsId]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_userRights_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([id])
);

