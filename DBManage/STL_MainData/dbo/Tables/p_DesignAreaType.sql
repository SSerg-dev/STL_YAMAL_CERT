CREATE TABLE [dbo].[p_DesignAreaType] (
    [DesignAreaType_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DesignAreaType_Name] NVARCHAR (50)    NOT NULL,
    [Row_Status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Description_Eng]     NVARCHAR (255)   NULL,
    [Description_Rus]     NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_DesignAreaType] PRIMARY KEY CLUSTERED ([DesignAreaType_ID] ASC),
    CONSTRAINT [FK_p_DesignAreaType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_DesignAreaType] UNIQUE NONCLUSTERED ([DesignAreaType_Name] ASC)
);

