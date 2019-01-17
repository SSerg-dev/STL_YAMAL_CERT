CREATE view dbo.WorkClass as
select
     WorkClass_ID
    ,WorkClass_PARENTID
    ,WorkClass_Name
    ,Description_Eng
    ,Description_Rus
    ,Unit
    ,Structure
from dbo.p_WorkClass
where row_status < 100
