CREATE TABLE [abd].[p_EntityType] (
    [EntityType_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_p_EntityType] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NOT NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NOT NULL,
    [EntityType_Name] NVARCHAR (300)   NOT NULL,
    [Entity]          NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_p_EntityType] PRIMARY KEY CLUSTERED ([EntityType_ID] ASC),
    CONSTRAINT [FK_p_EntityType_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UN_EntityType] UNIQUE NONCLUSTERED ([EntityType_Name] ASC)
);

