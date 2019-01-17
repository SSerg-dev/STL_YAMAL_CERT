CREATE view UserError as select [Error_Message], [Error_Number], [ErrorDescription_ENG], [ErrorDescription_RUS], [UserError_ID] from p_UserError where row_status < 100
