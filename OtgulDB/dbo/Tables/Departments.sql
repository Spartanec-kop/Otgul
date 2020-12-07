CREATE TABLE [dbo].[Departments] (
    [id]    INT          IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (60) NOT NULL,
    [chief] VARCHAR (60) NOT NULL,
    [departmentCode] INT NOT NULL, 
    CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED ([id] ASC)
);

