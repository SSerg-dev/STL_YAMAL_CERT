if (select count(*) from sys.messages where message_id = 50101) > 0 EXEC sp_dropmessage @msgnum = 	50101, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50101, @severity = 16, @msgtext = N'Parameter [%s] does not allows nulls.', @lang = 'us_english';  
EXEC sp_addmessage @msgnum = 50101, @severity = 16, @msgtext = N'Параметр [%1!] не может быть пустым.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50102) > 0 EXEC sp_dropmessage @msgnum = 	50102, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50102, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a number.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50102, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть числом.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50103) > 0 EXEC sp_dropmessage @msgnum = 	50103, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50103, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a string.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50103, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть строкой.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50104) > 0 EXEC sp_dropmessage @msgnum = 	50104, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50104, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a date with format "YYYY-MM-DD".', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50104, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть датой в формате "ГГГГ-ММ-ДД".', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50105) > 0 EXEC sp_dropmessage @msgnum = 	50105, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50105, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a datetime with format "YYYY-MM-DD hh:mm:ss".', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50105, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть датой со временем в формате "ГГГГ-ММ-ДД чч:мм:сс".', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50106) > 0 EXEC sp_dropmessage @msgnum = 	50106, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50106, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be an integer.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50106, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть челым цислом.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50107) > 0 EXEC sp_dropmessage @msgnum = 	50107, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50107, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a float numeric.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50107, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть дробным числом.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50108) > 0 EXEC sp_dropmessage @msgnum = 	50108, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50108, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a correct GUID.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50108, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть корректным GUID.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50109) > 0 EXEC sp_dropmessage @msgnum = 	50109, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50109, @severity = 16, @msgtext = N'Incorrect format for the parameter [%s], the value "%s" should be a boolean.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50109, @severity = 16, @msgtext = N'Неверный формат параметра [%1!], значение "%2!" должно быть логическим типом (bit).', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50111) > 0 EXEC sp_dropmessage @msgnum = 	50111, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50111, @severity = 16, @msgtext = N'User "%s" do not have permission on table [%s] for "%s".', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50111, @severity = 16, @msgtext = N'Пользователю "%1!" не достаточно прав на таблицу [%2!] для выполнения действия "%3!".', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50112) > 0 EXEC sp_dropmessage @msgnum = 	50112, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50112, @severity = 16, @msgtext = N'Role not found.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50112, @severity = 16, @msgtext = N'Роль не найдена.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50113) > 0 EXEC sp_dropmessage @msgnum = 	50113, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50113, @severity = 16, @msgtext = N'User "%s" not found.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50113, @severity = 16, @msgtext = N'Пользователь "%1!" не найден.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50121) > 0 EXEC sp_dropmessage @msgnum = 	50121, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50121, @severity = 16, @msgtext = N'Table [%s] does not exists.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50121, @severity = 16, @msgtext = N'Таблица [%1!] не найдена.', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50122) > 0 EXEC sp_dropmessage @msgnum = 	50122, @lang = 'all'; 
EXEC sp_addmessage @msgnum = 50122, @severity = 16, @msgtext = N'Table [%s] does not contain record with GUID "%s".', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50122, @severity = 16, @msgtext = N'Запись с GUID "%2!" в таблице [%1!]  не найдена.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50123) > 0 EXEC sp_dropmessage @msgnum = 	50123, @lang = 'all';
EXEC sp_addmessage @msgnum = 50123, @severity = 16, @msgtext = N'The item named [%s] already exists in [%s].', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50123, @severity = 16, @msgtext = N'Запись [%1!] уже стуществует в [%2]!', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50124) > 0 EXEC sp_dropmessage @msgnum = 	50124, @lang = 'all';
EXEC sp_addmessage @msgnum = 50124, @severity = 16, @msgtext = N'Login [%s] does not exists.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50124, @severity = 16, @msgtext = N'Логин [%1!] не найден.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50125) > 0 EXEC sp_dropmessage @msgnum = 	50125, @lang = 'all';
EXEC sp_addmessage @msgnum = 50125, @severity = 16, @msgtext = N'Period Start Date less then End Date.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50125, @severity = 16, @msgtext = N'Дата начала действия периода больше чем дата его окончания.', @lang = 'russian';  

if (select count(*) from sys.messages where message_id = 50126) > 0 EXEC sp_dropmessage @msgnum = 	50126, @lang = 'all';
EXEC sp_addmessage @msgnum = 50126, @severity = 16, @msgtext = N'Сhanging to this status denied.', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50126, @severity = 16, @msgtext = N'Переход на этот статус запрещен.', @lang = 'russian';

if (select count(*) from sys.messages where message_id = 50127) > 0 EXEC sp_dropmessage @msgnum = 	50127, @lang = 'all';
EXEC sp_addmessage @msgnum = 50127, @severity = 16, @msgtext = N'More then one Template found with given name [%s].', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50127, @severity = 16, @msgtext = N'В таблице документов найдено несколько записей для Шаблона [%1!].', @lang = 'russian'; 

if (select count(*) from sys.messages where message_id = 50128) > 0 EXEC sp_dropmessage @msgnum = 	50128, @lang = 'all';
EXEC sp_addmessage @msgnum = 50128, @severity = 16, @msgtext = N'More then one Template Attribute found. Template [%s], Attribute [%s].', @lang = 'us_english'; 
EXEC sp_addmessage @msgnum = 50128, @severity = 16, @msgtext = N'Для Шаблона [%1!] найдено несколько записей атрибута [%2!].', @lang = 'russian';  