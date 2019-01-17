CREATE TABLE [dbo].[p_RowStatus] (
    [RowStatus_ID]    INT            NOT NULL,
    [Status_Name_Eng] NVARCHAR (100) NOT NULL,
    [Status_Name_Rus] NVARCHAR (100) NOT NULL,
    [Description_Eng] NVARCHAR (255) NULL,
    [Description_Rus] NVARCHAR (255) NULL,
    CONSTRAINT [PK_p_RowStatus] PRIMARY KEY CLUSTERED ([RowStatus_ID] ASC)
);

