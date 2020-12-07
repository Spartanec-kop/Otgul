/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([id], [name], [chief], [departmentCode]) VALUES (1, N'первый департамент', N'Шеф первого департамента', 1001)
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Otdels] ON 
GO
INSERT [dbo].[Otdels] ([id], [codOtdela], [nameOtdela], [director]) VALUES (1, 101, N'Первый отдел', N'Дректор первого отдела')
GO
SET IDENTITY_INSERT [dbo].[Otdels] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([id], [name], [isDeleted]) VALUES (1, N'admin', 0)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([id], [roleId], [tabel], [firstName], [workStatus], [otdelId], [departmentId], [phone], [isDeleted], [lastName], [middleName], [login], [password]) VALUES (2, 1, 2001, N'Имя', N'workStatus1', 1, 1, N'7450', 0, N'Фамилия', N'Отчество', N'admin', N'123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Guides] ON 
GO
INSERT [dbo].[Guides] ([id], [name]) VALUES (1, N'первый гуид')
GO
SET IDENTITY_INSERT [dbo].[Guides] OFF
GO
SET IDENTITY_INSERT [dbo].[Rights] ON 
GO
INSERT [dbo].[Rights] ([Id], [name]) VALUES (1, N'первая привелегия')
GO
INSERT [dbo].[Rights] ([Id], [name]) VALUES (2, N'вторая привелегия')
GO
SET IDENTITY_INSERT [dbo].[Rights] OFF
GO
INSERT [dbo].[RoleRights] ([RoleId], [RightId]) VALUES (1, 2)
GO
INSERT [dbo].[UserRights] ([UserId], [RightId]) VALUES (2, 1)
GO
INSERT [dbo].[UserRights] ([UserId], [RightId]) VALUES (2, 2)
GO