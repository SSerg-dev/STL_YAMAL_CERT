
CREATE view [dbo].[FileShareTable] as
select 
	 Stream_Id			= stream_id
	,Path_ID			= cast(hashbytes('MD5',cast([path_locator] as nvarchar(max))) as varbinary(16))
	,PathDefault		= file_stream.GetFileNamespacePath()
	,PathNonDefault		= file_stream.GetFileNamespacePath(1, 2) 
	,[FileName]			= [name]
	,FileType			= file_type			
	,CreationTime 		= cast(creation_time as datetime2(7))		
	,LastWriteTime		= cast(last_write_time  as datetime2(7))	
	,LastAccessTime		= cast(last_access_time	 as datetime2(7))	
	,IsDirectory		= Is_directory		
	,IsOffline			= Is_offline			
	,IsHidden			= Is_hidden			
	,IsReadonly			= Is_readonly		
	,IsArchive			= Is_archive			
	,IsSystem			= Is_system			
	,IsTemporary		= Is_temporary		
from p_FileShareTable
