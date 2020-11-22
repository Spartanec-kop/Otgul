CREATE TABLE [dbo].[User] (
    [id]            INT            NOT NULL,
    [idRole]        INT            NOT NULL,
    [tabel]         SMALLINT       NOT NULL,
    [firstName]     NVARCHAR (100) NOT NULL,
    [workStatus]    NVARCHAR (50)  NOT NULL,
    [idOtdel]       INT            NOT NULL,
    [idDepartament] INT            NOT NULL,
    [phone]         NVARCHAR (10)  NULL,
    [isDeleted]      BIT            NOT NULL,
    [lastName]      NVARCHAR (50)  NOT NULL,
    [middleName]    NVARCHAR (50)  NULL,
    [login] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_User_Department] FOREIGN KEY ([idDepartament]) REFERENCES [dbo].[Department] ([id]),
    CONSTRAINT [FK_User_Otdel] FOREIGN KEY ([idOtdel]) REFERENCES [dbo].[Otdel] ([id]),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([idRole]) REFERENCES [dbo].[Role] ([id]), 
    CONSTRAINT [AK_User_login] UNIQUE ([login])
);


GO
CREATE NONCLUSTERED INDEX [idDeportament]
    ON [dbo].[User]([id] ASC);

