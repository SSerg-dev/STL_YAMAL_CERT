USE <DataBase_Name, sysname, WEB_MainData>
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name>(
	<Table_Name, sysname, Table_Name>_ID uniqueidentifier NOT NULL,
	RowStatus int NOT NULL,
	Insert_DTS datetime2(7) NOT NULL,
	Update_DTS datetime2(7) NOT NULL,
	Created_User_ID uniqueidentifier NOT NULL,
	Modified_User_ID uniqueidentifier NOT NULL,
	<Table_Name, sysname, Table_Name>_Code nvarchar(255) NOT NULL,
 CONSTRAINT PK_p_<Table_Name, sysname, Table_Name> PRIMARY KEY CLUSTERED 
(
	<Table_Name, sysname, Table_Name>_ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT UQ_p_<Table_Name, sysname, Table_Name> UNIQUE NONCLUSTERED 
(
	<Table_Name, sysname, Table_Name>_Code ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> ADD  CONSTRAINT DF_<Table_Name, sysname, Table_Name>_ID  DEFAULT (newsequentialid()) FOR <Table_Name, sysname, Table_Name>_ID
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> WITH CHECK ADD  CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_Created_User_ID_p_AppUser FOREIGN KEY(Created_User_ID)
REFERENCES dbo.p_AppUser (AppUser_ID)
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> CHECK CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_Created_User_ID_p_AppUser
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> WITH CHECK ADD  CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_Modified_User_ID_p_AppUser FOREIGN KEY(Modified_User_ID)
REFERENCES dbo.p_AppUser (AppUser_ID)
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> CHECK CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_Modified_User_ID_p_AppUser
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> WITH CHECK ADD  CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_RowStatus_p_RowStatus FOREIGN KEY(RowStatus)
REFERENCES <Schema_Name, sysname, dbo>.p_RowStatus (RowStatus_ID)
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<Table_Name, sysname, Table_Name> CHECK CONSTRAINT FK_p_<Table_Name, sysname, Table_Name>_RowStatus_p_RowStatus
GO



