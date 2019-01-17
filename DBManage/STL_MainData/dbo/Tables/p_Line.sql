CREATE TABLE [dbo].[p_Line] (
    [Line_ID]                              UNIQUEIDENTIFIER NOT NULL,
    [Line_Number]                          NVARCHAR (100)   NOT NULL,
    [Location_From]                        NVARCHAR (1000)  NULL,
    [Location_To]                          NVARCHAR (1000)  NULL,
    [Fluid_Name_Eng]                       NVARCHAR (1000)  NULL,
    [Fluid_Name_Rus]                       NVARCHAR (1000)  NULL,
    [Fluid_Danger_Code_By_Gost]            NVARCHAR (1000)  NULL,
    [Fluid_Fire_Aand_Explosive_Hazard]     NVARCHAR (1000)  NULL,
    [Fluid_Group_By_TP_TC_032_2013]        NVARCHAR (1000)  NULL,
    [Fluid_Group_By_GOST_32569_2013]       NVARCHAR (1000)  NULL,
    [Pipeline_Category_By_GOST_32569_2013] NVARCHAR (1000)  NULL,
    [Piprline_Category_By_TP_TC_032_2013]  NVARCHAR (1000)  NULL,
    [Row_Status]                           INT              NULL,
    [Insert_DTS]                           DATETIME2 (7)    NULL,
    [Update_DTS]                           DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Line] PRIMARY KEY CLUSTERED ([Line_ID] ASC),
    CONSTRAINT [FK_p_Line_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Line] UNIQUE NONCLUSTERED ([Line_Number] ASC)
);

