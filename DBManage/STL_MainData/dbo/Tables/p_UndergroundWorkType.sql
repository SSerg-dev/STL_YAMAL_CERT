CREATE TABLE [dbo].[p_UndergroundWorkType] (
    [UndergroundWorkType_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_UndergroundWorkType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Row_Status]               INT              NOT NULL,
    [Insert_DTS]               DATETIME2 (7)    NOT NULL,
    [Update_DTS]               DATETIME2 (7)    NOT NULL,
    [Created_User_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [UndergroundWorkType_Code] NVARCHAR (255)   NOT NULL,
    [Description_Rus]          NVARCHAR (255)   NULL,
    [Description_Eng]          NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_UndergroundWorkType] PRIMARY KEY CLUSTERED ([UndergroundWorkType_ID] ASC),
    CONSTRAINT [FK_p_UndergroundWorkType_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundWorkType_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundWorkType_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_UndergroundWorkType] UNIQUE NONCLUSTERED ([UndergroundWorkType_Code] ASC)
);

