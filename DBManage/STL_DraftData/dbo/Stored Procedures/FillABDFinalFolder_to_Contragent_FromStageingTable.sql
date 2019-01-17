CREATE procedure [dbo].[FillABDFinalFolder_to_Contragent_FromStageingTable]
(
	 @DraftData		nvarchar(100)
	,@MainData		nvarchar(100)
)
as begin
	set nocount on
	declare @SQL nvarchar(max) = N''
	-- select ниже - это элегантная и быстрая замена Unpivot, когда нужно сделать маппинг имен колонок на другие алиасы
	-- для добавления контрагента: внести новую колонку в табличку s_Final_ABD_Compilation_LOG, сделать  мапинг в VALUES
	select @SQL = '
		insert into '+@MainData+N'.dbo.p_ABDFinalFolder_to_Contragent
		(
			 ABDFinalFolder_to_Contragent_ID
			,Insert_DTS
			,Update_DTS
			,Row_Status
			,ABDFinalFolder_ID
			,Contragent_ID
		)
		select 
			 newid()
			,getdate()
			,getdate()
			,0
			,f.ABDFinalFolder_ID
			,c.Contragent_ID 
		from
		(
			select distinct a.Folder, z.Contragent
			from '+@DraftData+N'.dbo.s_Final_ABD_Compilation_LOG a
			cross apply 
			( 
				values
				 (C_YAM	 , ''YAM'')
				,(C_VEL	 , ''VEL'')
				,(C_ZPGS , ''ZPGS'')
				,(C_KXM	 , ''KXM'')
				,(C_REGA , ''REGA'')
				,(C_NOVA , ''NOVA'')
				,(C_SNEMA, ''SNEMA'')
				,(C_PSIS, ''PSIS'')
			) z (x, Contragent)
			where z.x is not null and ltrim(rtrim(z.x)) <> ''''
		) a
		left join '+@MainData+N'.dbo.p_ABDFinalFolder f ON a.Folder = f.ABDFinalFolder_Name
		left join '+@MainData+N'.dbo.p_Contragent c ON a.Contragent = c.Code'
	exec (@SQL)
end