

-- =============================================
-- Author:		Ruslan
-- Create date: 2017-09-19
-- Description:	the procedure shows 
-- Changed by : RAlizade 2018-07-16 (Changes from p_Register_to_Status to p_Register_to_ABDStatus)
-- =============================================
--************************************************
CREATE PROCEDURE [dbo].[Change_Reg_Status]
	-- Add the parameters for the stored procedure here
	@Reg_ID				uniqueidentifier, 
	@Status_ID			uniqueidentifier, 
	@Error_ID			bigint output,
	@Error_Mesage_Eng	varchar(Max) output,
	@Error_Mesage_Rus	varchar(Max) output
AS
BEGIN

Declare @Reg_to_status_ID uniqueidentifier
Declare @New_ID uniqueidentifier
Declare @Status_ID_old uniqueidentifier
Declare @x_DTS datetime 
Declare @x_status_count integer
Declare @Action_way integer
Declare @x_reg_count integer

Declare @x_execution bigint
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Initialization of varuiables
	SET @Reg_to_status_ID = NULL;
	SET @x_execution = 0;
	SET @Action_way = 0;

	SET @Error_ID = 0
	SET @Error_Mesage_Eng = 'OK'
	SET @Error_Mesage_Rus = 'OK'

	----------------------------------

	Select @Reg_to_status_ID = Register_to_ABDStatus_ID, @Status_ID_old = ABDSTATUS_ID from p_Register_to_ABDStatus where Register_ID = @Reg_ID and Row_status = 0 -- ID of the current row. That row should be modified
	Select @x_status_count = count(*) from [dbo].[p_ABDStatus] where ABDStatus_ID = @Status_ID and Row_status = 0
	Select @x_reg_count    = count(*) from [dbo].[p_Register] where Register_ID = @Reg_ID and Row_status = 0

	IF (@Reg_to_status_ID) is null and @x_reg_count = 1 
	begin 
		SET @Action_way = 1 -- New entry of the register 
	end

	IF (@Status_ID = @Status_ID_old) and @Reg_to_status_ID is not null
	begin 
		SET @x_execution = @x_execution + 1 
		SET @Error_ID = 12
		SET @Error_Mesage_Eng = 'Statuses are match!'
		SET @Error_Mesage_Rus = 'Статусы совпадают!' 
	end

	IF (@x_status_count <> 1)
	begin 
		SET @x_execution = @x_execution + 1 
		SET @Error_ID = 14
		SET @Error_Mesage_Eng = 'Status is Wrong!'
		SET @Error_Mesage_Rus = 'Ошибка статуса!' 
	end

		IF (@x_reg_count <> 1)
	begin 
		SET @x_execution = @x_execution + 1 
		SET @Error_ID = 16
		SET @Error_Mesage_Eng = 'Register refernce Error!'
		SET @Error_Mesage_Rus = 'Ошибка состояния справичника реестров - Дубль записи!' 
	end

	IF (@x_execution = 0) and @Action_way = 0 -- Modification of the existing row 
	begin
	 
	 SET @New_ID = newid() 
	 SET @x_DTS = getdate()
	 

	 Begin Transaction MainDataModification;
		
		Begin try

			Update p_Register_to_ABDStatus 
			set Row_status = 120, -- Status of Historical Rows
		    DTS_END = @x_DTS,
			Modified_By = user  
			where Register_to_ABDStatus_ID = @Reg_to_status_ID;

		END TRY 
		 
		BEGIN CATCH  
			SELECT   
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION MainDataModification;  
				GOTO Tran_MainDataModification_Rejected;
				END;
		END CATCH; 

		Begin try

			Insert Into p_Register_to_ABDStatus
			(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, ABDStatus_ID, Created_By)
			Values
			(@New_ID, @Reg_to_status_ID, @x_DTS, 0, @Reg_ID, @Status_ID, user)

		END TRY 
		
		BEGIN CATCH 
			SELECT   
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION MainDataModification;  
				GOTO Tran_MainDataModification_Rejected;
				END;

		END CATCH; 		

Tran_MainDataModification_Rejected: --all catched errors in MainDataModification transaction lead here	

		IF @@TRANCOUNT > 0 
			COMMIT TRANSACTION MainDataModification; 
	end;


	IF (@x_execution = 0) and @Action_way = 1 -- New entry  
	begin
	 
	 SET @New_ID = newid() 
	 SET @x_DTS = getdate()
	 
	 Begin Transaction MainDataInsertion;
		
		Begin try

		Insert Into p_Register_to_ABDStatus
		(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, ABDStatus_ID, Modified_By)
		Values
		(@New_ID, NULL, @x_DTS, 0, @Reg_ID, @Status_ID, user)

		END TRY 
		 
		BEGIN CATCH  
			SELECT   
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  

			IF @@TRANCOUNT > 0  
				ROLLBACK TRANSACTION MainDataInsertion;  
		
		END CATCH; 

		IF @@TRANCOUNT > 0 
			COMMIT TRANSACTION MainDataInsertion; 

	end 

	 --old code based on old tables 22-10-2017 ASmirnov
/*
	 begin Transaction   


		Update p_Register_to_ABDStatus 
		set Row_status = 120, -- Status of Historical Rows
		    DTS_END = @x_DTS 
		where Register_to_ABDStatus_ID = @Reg_to_status_ID

		Insert Into p_Register_to_ABDStatus
		(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, Status_ID, Modified_By)
		Values
		(@New_ID, @Reg_to_status_ID, @x_DTS, 0, @Reg_ID, @Status_ID, user)

	 Commit

	end 


	IF (@x_execution = 0) and @Action_way = 1 -- New entry  
	begin
	 
	 SET @New_ID = newid() 
	 SET @x_DTS = getdate()
	 
	 begin Transaction 

		Insert Into p_Register_to_ABDStatus
		(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, Status_ID, Modified_By)
		Values
		(@New_ID, NULL, @x_DTS, 0, @Reg_ID, @Status_ID, user)

	 Commit
*/
	

    -- Insert statements for procedure here
	-- SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	-- Select user;

	Select @Error_ID,  @Error_Mesage_Eng,  @Error_Mesage_Rus
	

END
