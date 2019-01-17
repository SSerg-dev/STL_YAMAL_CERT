
CREATE procedure [dbo].[User_FormType_Get] 
(
	 @i_User_ID				nvarchar(250)
	,@o_Role_Code			nvarchar(250)	output
	,@o_Division_ID			nvarchar(250)	output
	,@o_Division_Name		nvarchar(250)	output
	,@o_Person_ShortName	nvarchar(250)	output
	,@o_IsError				bit				output
) as
begin
	set nocount on
	declare @u_User_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_User_ID)) as uniqueidentifier	)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N'', @Row_Status nvarchar(10) = '200'
	-------------
	------------- Check
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_User_ID is null ) select Id=50113, Msg=formatmessage(50113, 'Empty_User_Name');set @e=@e+@@rowcount
		select @CntParam = N'AppUser_ID="'+try_cast(@i_User_ID as nvarchar(max))+N'"', @Cnt=-1
		--exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50113, Msg=formatmessage(50113, 'AppUser_ID', try_cast(@i_User_ID as nvarchar(250))); set @e=@e+@@rowcount
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'User_FormType_Get', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	if (@e = 0) begin try
		select @o_Role_Code = ''
		if @o_Role_Code is not null begin
			--select @o_RoleName = 'Administrator'
			select @o_Role_Code = max(c.Role_Code) 
			from p_AppUser a
			join p_AppUser_to_Role b on a.[AppUser_ID] = b.[AppUser_ID]
			join p_Role c on b.Role_ID = c.Role_ID
			where a.[AppUser_ID] = @u_User_ID
			group by a.[AppUser_ID]

			select 
				 @o_Division_ID			= cast(max(c.Division_ID) as nvarchar(36))
				,@o_Division_Name		= cast(max(c.Division_Name) as nvarchar(250))
				,@o_Person_ShortName	= cast(max(d.ShortName) as nvarchar(250))
			from p_Employee a 
			left join p_Position b on a.Position_ID = b.Position_ID  
			left join p_Division c on b.Division_ID = c.Division_ID
			left join p_Person d on a.Person_ID = d.Person_ID
			where a.AppUser_ID = @u_User_ID
			group by a.[AppUser_ID]
		end
		if isnull(@o_Role_Code,'') = '' select Id=50101, Msg=formatmessage(50112, '');set @e=@e+@@rowcount
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'User_FormType_Get', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
