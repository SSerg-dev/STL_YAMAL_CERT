CREATE TABLE [dbo].[p_Status] (
    [Status_ID]        UNIQUEIDENTIFIER CONSTRAINT [DF_Status_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Status_Code]      NVARCHAR (255)   NOT NULL,
    [StatusEntity]     NVARCHAR (255)   NULL,
    [Description_Eng]  NVARCHAR (255)   NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    [EntityLocked]     BIT              NULL,
    [ReportColor]      NVARCHAR (255)   NULL,
    [ReportOrder]      INT              NULL,
    CONSTRAINT [PK_p_Status] PRIMARY KEY CLUSTERED ([Status_ID] ASC),
    CONSTRAINT [FK_p_Status_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Status_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Status_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Status] UNIQUE NONCLUSTERED ([Status_Code] ASC)
);



