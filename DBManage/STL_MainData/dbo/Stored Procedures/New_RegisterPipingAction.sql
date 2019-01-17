
-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-25
-- Description:	The procedure makes assosiation of the ISO and Register and PipingWorkType in table RegisterPipingAction
-- =============================================
Create PROCEDURE [dbo].[New_RegisterPipingAction] 
	-- Add the parameters for the stored procedure here
	 @i_Register_ID	varchar(250),
     @i_ISO_ID				varchar(250),
     @i_PipingWorkType_ID	varchar(250),  

	 @i_Row_Status			varchar(250),

	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output

AS
BEGIN
-- ===== Global variables ===========
Declare @x_Error_Status integer
Declare @Cur_Date datetime

Declare @x_Count bigint 
Declare @Error_ID int

-- ===== Local variables ===========


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0
SET @Cur_Date = getdate()

-- Input data preparation


	-- Input Data check 
	-- ======== Register =========================================================
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_Register] where Register_ID = Cast(@i_Register_ID as uniqueidentifier) and Row_Status = 0 

	IF @x_Count <> 1
	begin
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======== ISO =========================================================
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_ISO] where ISO_ID = Cast(@i_ISO_ID as uniqueidentifier) and Row_Status = 0  

	IF @x_Count <> 1
	begin
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======= Type of Work =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_PipingWorkType] where PipingWorkType_ID = cast(@i_PipingWorkType_ID as uniqueidentifier) and Row_Status = 0  

	IF @x_Count <> 1
	begin
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======= Data Consistency Check ========================

	IF @x_Error_Status = 0
	begin

		SET @x_Count = 0 
		SELECT @x_Count =count(*)
		FROM dbo.p_RegisterPipingAction ra
	    join dbo.p_Register r on r.Register_ID = ra.Register_ID
		where r.WorkPackage_ID = (select WorkPackage_ID 
								  from p_Register r1 
								  where r1.Register_ID = @i_Register_ID)
		  and ra.PipingWorkType_ID = @i_PipingWorkType_ID 
		  and ra.ISO_ID = @i_ISO_ID
		  and ra.Row_Status= 0;

		IF @x_Count > 0 
		begin
			SET @Error_ID = 40 -- Data Consistency Error 
			SET @x_Error_Status = @x_Error_Status + 1
		end
    end

	-- ==== Main data insert operation =======================

	IF @x_Error_Status = 0
	Begin
		
		Begin Transaction MainDataOperation;
		
		Begin try


		INSERT INTO [dbo].[p_RegisterPipingAction]
           ([RegisterPipingAction_ID]
           ,[Register_ID]
           ,[PipingWorkType_ID]
           ,[ISO_ID]
           ,[DTS_Strat]
           ,[DTS_End]
           ,[Row_Status]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_By]
           ,[Modified_By])
     VALUES
           (newid()
           ,cast(@i_Register_ID as uniqueidentifier)
           ,cast(@i_PipingWorkType_ID as uniqueidentifier)
           ,cast(@i_ISO_ID as uniqueidentifier)
           ,NULL
           ,NULL
           ,cast(@i_Row_Status as int)
           ,@Cur_Date
           ,@Cur_Date
           ,NULL
           ,NULL);

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
				ROLLBACK TRANSACTION MainDataOperation;  

		END CATCH; 

		IF @@TRANCOUNT > 0  
			COMMIT TRANSACTION MainDataOperation; 
	end;
	
	    -- Output parameters of the procedure 

	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'


END
