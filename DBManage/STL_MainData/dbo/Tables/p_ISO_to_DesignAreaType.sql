CREATE TABLE [dbo].[p_ISO_to_DesignAreaType] (
    [ISO_to_DesignAreaType_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ISO_to_DesignAreaType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ISO_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [DesignAreaType_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]               INT              NULL,
    [Insert_DTS]               DATETIME2 (7)    NULL,
    [Update_DTS]               DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO_to_DesignAreaType] PRIMARY KEY CLUSTERED ([ISO_to_DesignAreaType_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_DesignAreaType_DesignAreaType_ID_p_DesignAreaType] FOREIGN KEY ([DesignAreaType_ID]) REFERENCES [dbo].[p_DesignAreaType] ([DesignAreaType_ID]),
    CONSTRAINT [FK_p_ISO_to_DesignAreaType_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_DesignAreaType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_DesignAreaType] UNIQUE NONCLUSTERED ([DesignAreaType_ID] ASC, [ISO_ID] ASC)
);

