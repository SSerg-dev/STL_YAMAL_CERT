﻿CREATE TABLE [dbo].[p_WorkProgressPipingQuantity] (
    [WorkProgressPipingQuantity_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_WorkProgressPipingQuantity_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                     UNIQUEIDENTIFIER NULL,
    [LogID]                         NVARCHAR (50)    NULL,
    [WorkPackage_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]                UNIQUEIDENTIFIER NULL,
    [Marka_ID]                      UNIQUEIDENTIFIER NULL,
    [Line_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [Design_Area]                   NVARCHAR (255)   NULL,
    [Sheet]                         NVARCHAR (10)    NULL,
    [ISO_ID]                        UNIQUEIDENTIFIER NOT NULL,
    [Shop_Weld_RegNum]              NVARCHAR (255)   NULL,
    [Shop_Weld_AD_cur_State]        NVARCHAR (255)   NULL,
    [Shop_Weld_Issued_SCTR]         FLOAT (53)       NULL,
    [Shop_Weld_Accepted_CPY]        FLOAT (53)       NULL,
    [Field_Weld_RegNum]             NVARCHAR (255)   NULL,
    [Field_Weld_AD_cur_State]       NVARCHAR (255)   NULL,
    [Field_Weld_Issued_SCTR]        FLOAT (53)       NULL,
    [Field_Weld_Accepted_CPY]       FLOAT (53)       NULL,
    [AKZ_Shop_RegNum]               NVARCHAR (255)   NULL,
    [AKZ_Shop_AD_cur_State]         NVARCHAR (255)   NULL,
    [AKZ_Shop_Issued_SCTR]          FLOAT (53)       NULL,
    [AKZ_Shop_Accepted_CPY]         FLOAT (53)       NULL,
    [AKZ_Weld_RegNum]               NVARCHAR (255)   NULL,
    [AKZ_Weld_AD_cur_State]         NVARCHAR (255)   NULL,
    [AKZ_Weld_Issued_SCTR]          FLOAT (53)       NULL,
    [AKZ_Weld_Accepted_CPY]         FLOAT (53)       NULL,
    [GW_RegNum_RegNum]              NVARCHAR (255)   NULL,
    [GW_AD_cur_State]               NVARCHAR (255)   NULL,
    [GW_Issued_SCTR]                FLOAT (53)       NULL,
    [GW_Accepted_CPY]               FLOAT (53)       NULL,
    [Insulation_RegNum]             NVARCHAR (255)   NULL,
    [Insulation_AD_cur_State]       NVARCHAR (255)   NULL,
    [Insulation_Issued_SCTR]        FLOAT (53)       NULL,
    [Insulation_Accepted_CPY]       FLOAT (53)       NULL,
    [Test_Density_Strength]         NVARCHAR (255)   NULL,
    [Test_Leak]                     NVARCHAR (255)   NULL,
    [Certificate_Installation]      NVARCHAR (255)   NULL,
    [Row_Status]                    INT              NOT NULL,
    [Insert_DTS]                    DATETIME2 (7)    NOT NULL,
    [Update_DTS]                    DATETIME2 (7)    NOT NULL,
    [Source_File]                   NVARCHAR (500)   NULL,
    CONSTRAINT [PK_p_WorkProgressPipingQuantity] PRIMARY KEY CLUSTERED ([WorkProgressPipingQuantity_ID] ASC)
);

