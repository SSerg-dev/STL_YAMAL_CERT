﻿create view Privilege as select [Privilege_ID], [Privilege_Code], [Role_ID], [Entity], [EntityKey], [prvRead], [prvCreate], [prvUpdate], [prvDelete] from p_Privilege where RowStatus = 0