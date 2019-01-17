﻿CREATE TABLE [dbo].[p_Register] (
    [Register_ID]       UNIQUEIDENTIFIER CONSTRAINT [DF_Register_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Register_Code]     NVARCHAR (255)   NOT NULL,
    [Register_Date]     DATETIME2 (7)    NOT NULL,
    [Current_Iteration] INT              NOT NULL,
    [Customer_ID]       UNIQUEIDENTIFIER NULL,
    [Contractor_ID]     UNIQUEIDENTIFIER NULL,
    [Resp_Employee_ID]  UNIQUEIDENTIFIER NULL,
    [WorkPackage_ID]    UNIQUEIDENTIFIER NULL,
    [Comment]           NVARCHAR (255)   NULL,
    [SubContractor_ID]  UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Register] PRIMARY KEY CLUSTERED ([Register_ID] ASC),
    CONSTRAINT [FK_p_Register_Contractor_ID_p_Contragent] FOREIGN KEY ([Contractor_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_Register_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_Customer_ID_p_Contragent] FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_Register_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_Resp_Employee_ID_p_Employee] FOREIGN KEY ([Resp_Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID]),
    CONSTRAINT [FK_p_Register_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_Register_SubContractor_ID_p_Contragent] FOREIGN KEY ([SubContractor_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_Register_WorkPackage_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_Register] UNIQUE NONCLUSTERED ([Register_Code] ASC)
);









