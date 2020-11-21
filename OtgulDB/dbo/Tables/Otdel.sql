CREATE TABLE [dbo].[Otdel] (
    [id]         INT           NOT NULL,
    [codOtdela]  INT           NOT NULL,
    [nameOtdela] NVARCHAR (60) NOT NULL,
    [director]   NVARCHAR (60) NOT NULL,
    CONSTRAINT [PK_unit] PRIMARY KEY CLUSTERED ([id] ASC)
);

