CREATE TABLE [dbo].[p_WorkPackage] (
    [WorkPackage_ID]    UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_Name]  NVARCHAR (50)    NOT NULL,
    [Site_Russia_Yard]  NVARCHAR (100)   NULL,
    [Location_Of_Works] NVARCHAR (100)   NULL,
    [Scope_Of_Work]     NVARCHAR (1000)  NULL,
    [Area_Of_Work]      NVARCHAR (1000)  NULL,
    [Row_Status]        INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_p_WorkPackage] PRIMARY KEY CLUSTERED ([WorkPackage_ID] ASC),
    CONSTRAINT [FK_p_WorkPackage_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_WorkPackage] UNIQUE NONCLUSTERED ([WorkPackage_Name] ASC)
);

