CREATE TABLE [dbo].[p_JointType] (
    [JointType_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_JointType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [JointType_Code]   NVARCHAR (255)   NOT NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_JointType] PRIMARY KEY CLUSTERED ([JointType_ID] ASC),
    CONSTRAINT [FK_p_JointType_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_JointType_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_JointType_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_JointType] UNIQUE NONCLUSTERED ([JointType_Code] ASC)
);

