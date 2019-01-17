USE <DataBase_Name, sysname, WEB_MainData>
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>(
	<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_ID uniqueidentifier NOT NULL,
	RowStatus int NOT NULL,
	Insert_DTS datetime2(7) NOT NULL,
	Update_DTS datetime2(7) NOT NULL,
	Created_User_ID uniqueidentifier NOT NULL,
	Modified_User_ID uniqueidentifier NOT NULL,
	<TableA, sysname, TableA>_ID uniqueidentifier NOT NULL,
	<TableB, sysname, TableB>_ID uniqueidentifier NOT NULL,
 CONSTRAINT PK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> PRIMARY KEY CLUSTERED 
(
	<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT UQ_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> UNIQUE NONCLUSTERED 
(
	<TableA, sysname, TableA>_ID ASC,
	<TableB, sysname, TableB>_ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> ADD  CONSTRAINT DF_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_ID  DEFAULT (newsequentialid()) FOR <TableA, sysname, TableA>_to_<TableB, sysname, TableB>_ID
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  WITH CHECK ADD  CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_Created_User_ID_p_AppUser FOREIGN KEY(Created_User_ID)
REFERENCES dbo.p_AppUser (AppUser_ID)
GO
ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> CHECK CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_Created_User_ID_p_AppUser
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  WITH CHECK ADD  CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_Modified_User_ID_p_AppUser FOREIGN KEY(Modified_User_ID)
REFERENCES dbo.p_AppUser (AppUser_ID)
GO
ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> CHECK CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_Modified_User_ID_p_AppUser
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  WITH CHECK ADD  CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_<TableA, sysname, TableA>_ID_p_<TableA, sysname, TableA> FOREIGN KEY(<TableA, sysname, TableA>_ID)
REFERENCES <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA> (<TableA, sysname, TableA>_ID)
GO
ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB> CHECK CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_<TableA, sysname, TableA>_ID_p_<TableA, sysname, TableA>
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  WITH CHECK ADD  CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_<TableB, sysname, TableB>_ID_p_<TableB, sysname, TableB> FOREIGN KEY(<TableB, sysname, TableB>_ID)
REFERENCES <Schema_Name, sysname, dbo>.p_<TableB, sysname, TableB> (<TableB, sysname, TableB>_ID)
GO
ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  CHECK CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_<TableB, sysname, TableB>_ID_p_<TableB, sysname, TableB>
GO

ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>   WITH CHECK ADD  CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_RowStatus_p_RowStatus FOREIGN KEY(RowStatus)
REFERENCES <Schema_Name, sysname, dbo>.p_RowStatus (RowStatus_ID)
GO
ALTER TABLE <Schema_Name, sysname, dbo>.p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>  CHECK CONSTRAINT FK_p_<TableA, sysname, TableA>_to_<TableB, sysname, TableB>_RowStatus_p_RowStatus
GO



