CREATE TABLE [dbo].[p_RusLabStatus] (
    [RusLabStatus_ID]   UNIQUEIDENTIFIER NOT NULL,
    [RusLabStatus_Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_p_RusLabStatus] PRIMARY KEY CLUSTERED ([RusLabStatus_ID] ASC),
    CONSTRAINT [UQ_p_RusLabStatus] UNIQUE NONCLUSTERED ([RusLabStatus_Name] ASC)
);

