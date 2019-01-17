CREATE TABLE [dbo].[obj_variables] (
    [obj_name]   NVARCHAR (100) NULL,
    [obj_type]   NVARCHAR (100) NULL,
    [var_name]   NVARCHAR (100) NULL,
    [var_value]  NVARCHAR (500) NULL,
    [Row_status] INT            NULL,
    [Insert_DTS] DATETIME2 (7)  NULL,
    [Update_DTS] DATETIME2 (7)  NULL
);

