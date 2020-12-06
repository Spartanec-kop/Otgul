CREATE TABLE [dbo].[Users] (
    [id]            INT            NOT NULL,
    [roleId]        INT            NOT NULL,
    [tabel]         SMALLINT       NOT NULL,
    [firstName]     NVARCHAR (100) NOT NULL,
    [workStatus]    NVARCHAR (50)  NOT NULL,
    [otdelId]       INT            NOT NULL,
    [departmentId] INT            NOT NULL,
    [phone]         NVARCHAR (10)  NULL,
    [isDeleted]      BIT            NOT NULL,
    [lastName]      NVARCHAR (50)  NOT NULL,
    [middleName]    NVARCHAR (50)  NULL,
    [login] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Users_Departments] FOREIGN KEY ([departmentId]) REFERENCES [dbo].[Departments] ([id]),
    CONSTRAINT [FK_Users_Otdels] FOREIGN KEY ([otdelId]) REFERENCES [dbo].[Otdels] ([id]),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([roleId]) REFERENCES [dbo].[Roles] ([id]), 
    CONSTRAINT [AK_Users_logins] UNIQUE ([login])
);


GO
CREATE NONCLUSTERED INDEX [idDeportament]
    ON [dbo].[Users]([id] ASC);

