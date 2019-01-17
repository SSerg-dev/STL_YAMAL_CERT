
create view [dbo].[HIFGroup] as select [HIFGroup_ID], [HIFGroup_Code], [Description_Rus] from p_HIFGroup where RowStatus < 100