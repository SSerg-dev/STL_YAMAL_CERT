create procedure TestExeption as
begin
	raiserror ('Blah-blah-Blaaaaaah', 0,1) with nowait
end
