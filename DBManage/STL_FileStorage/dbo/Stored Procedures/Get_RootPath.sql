CREATE procedure [dbo].[Get_RootPath]
(
	@FileTable nvarchar(120)
) as 
begin
	begin try
		select FullPath = FileTableRootPath(@FileTable,2)
	end try
	begin catch
		select FullPath = null
	end catch
end