export class LangPack{
    constructor(langCode) //either rus or eng
    {
        if(langCode=='rus'){
            this.TotalSheets = "Всего страниц";
            this.SelectSet="Выберите номер комплекта";
            this.Drawing = "ГОСТ / PID";
            this.ABDDocument_IssueDate = "Дата выдачи документа";
            this.NoFolderCreatedYet="В данном комплекте еще не создано папок";
            this.Document="Документ";
            this.Title="Титул";
            this.Marka="Марка";
            this.Loading="Загрузка";
            this.ABDFinalFolder_Name="Номер папки";
            this.ABDDocument_Number = "Номер документа";
            this.ABDDocument_Name = "Наименование документа";
            this.CTR_RESP="Ответственный";
            this.SCTR_RESP="Ответственный от субподрядчика";
            this.StartDate="Начало комплектации";
            this.TargetDate="Конец комплектации";
            this.ListCount="Кол-во страниц";
            this.RowNum="Номер строки";
            this.OpenFolder="Открыть папку";
            this.OpenNewTab="Открыть в новом окне";
            this.NotSelected="Не выбрано";
            this.notSelected = 'не выбрано';
            this.NumberInFolder="Номер в папке";
            this.Structure="Сооружение";
            this.Remark = "Примечания";
            this.SheetFolderNumber = "Номер страницы";
            this.Selected = "Выбрано: ";
            this.mustBeFilled = 'Поле должно быть заполненным';
            this.notContainedByDictionary='Отсутствует в словаре';
            this.valueAlreadyExists = 'Данное значение уже существует';
            this.nothingSelected = 'Ничего не выбрано';
            this.noSuchPair = "Данная пара отсутствует в словаре";
            this.Status = 'Статус';
            this.Package = 'Пакет';
            this.SCTR_Resp = 'Отвественный от субподрядчика';
            this.ABDStatusDate = 'Текущая дата статуса';
            this.CNT_Date = 'Дата подписания';
            this.WorkDesc = 'Описание работ';
            this.Phase = 'Фаза';
            this.ProcessPhase = 'Технологическая фаза';
            this.Register_Number = 'Номер реестра';
            this.Register_Open = 'Открыть реестр';
            this.Select_All = 'Выбрать все';
            this.Deselect_All = 'Отменить все';
            this.StatusDate = 'Дата изменения статуса: ';
            this.StatusModifiedBy = 'ответственный: ';
            this.WorkPackage = 'Пакет работ';
            this.ReportOrder = 'Порядок в Отчетах';
            this.Description = 'Описание';
            this.Description_Rus = 'Описание (RUS)';
            this.Description_Eng = 'Описание (ENG)';
            this.CodeMark = 'Код марки';
            this.DrawingType = 'Тип чертежа';
            this.DrawingType_Eng = 'Тип чертежа (RUS)';
            this.DrawingType_Rus = 'Тип чертежа (ENG)';
            this.isPriority = 'Приоритетная';
            this.isUsedInMatrix = 'В матрице';
            this.Open = 'Открыть';
            this.endOfTable = 'Конец таблицы';
            this.EditMarka='Редактировать марку';
            this.EditTitleObject = 'Редактировать Титульный объект';
            this.EditRegister = 'Редактировать реестр';
            this.ReportColor='Цвет отчетов';
            this.First='Первый';
            this.ReportOrderAfter = 'Порядок после';
            this.EmptyMarkaName = 'Поле "Имя марки" не может быть пустым';
            this.StageOfConstruction = "Стадия возведения";
            this.ParentObject = 'Родительский объект';
            this.TitleObject_for_ABDFinalSet = 'Обозначение в комплектах ИД';
            this.CantChangeParent='Невозможно поменять раздел т.к. данный объект содержит подразделы';
            this.CantChangeColorParent='Цвет отчетов определяется родительским объектом';
            this.EmptyTitleObjecName = 'Поле "Имя титульного объекта" не может быть пустым';
            this.ReportColorRequired = "Необходимо выбрать цвет для отчетов";
            this.PhaseRequired = "Необходимо выбрать фазу";
            this.OnlyLatinSymbolsAndNumbersAreAllowedInTitleName = 'Только заглавные латинские буквы и цифры и разделитель - точку разрешено использовать в названии титульного объекта';
            this.HomeButton = 'Главное меню';
            this.LastWriteTime = 'Изменено';
            this.ABD = 'Исполнительная документация';
            this.FoldersAndSets = 'Папки и комплекты';
            this.Registers = 'Реестры';
            this.Markas = 'Марки';
            this.TitleObjects = 'Титульные объекты';
            this.IPD = 'Разрешительная документация';
            this.ReferenceDocumentation = 'Справочная документация';
            this.Documents = 'Документы';
            this.AnnulledRegister = 'Реестр аннулирован';
            this.ForLine = ' по линии: ';
            this.LineIsoDictionary = 'Линии и Изометрии';
            this.Search = 'Поиск';
            this.CreatedBy = 'Кем создано';
            this.CreationDate = 'Дата создания';
            this.ModifiedDate = 'Дата изменения';
            this.Edit = 'Редактировать';
            this.SelectGost = 'Выбрать ГОСТ';
            this.SelectPid = 'Выбрать PID';
            this.DocumentFiles = 'файлы документа';
            this.NoResults = 'Нет результатов';

            //ABDDOCUMENT BLOCK
            this.CreateABDDocument = 'Создать документ';
            this.ABDDocumentName = 'Имя документа';
            this.ABDDocumentNumber = 'Номер';
            this.OfDocuments = 'документов';
            this.EditABDDocument = 'Редактировать документ: ';
            this.CreateABDDocument  ='Создать документ';
            this.ViewABDDocument = 'Только чтение: '
            this.DocumentNumber = 'Номер документа';
            this.PagesNumber = 'Кол-во страниц';
            this.GOST = 'ГОСТ';
            this.PID = 'PID';
            this.SureQuitDocument = 'Вы уверены, что хотите выйти из редактирования данного документа? Все несохраненные измения будут утеряны.'
            this.SavedABDDocument = 'Документ сохранен';
            this.DeletedABDDocument = 'Документ удален';

            //CREATE BLOCK
            this.Create = 'Создать';
            this.CreateMarka = 'Создать марку';
            this.CreateNewMarka = 'Создать новую марку';
            this.CreateNewTitleObject = 'Создать новый Титульный объект';
            this.CreateRegister="Создать новый реестр";
            this.CreateLine = 'Создать новую линию';
            this.CreateIso = 'Создать изометрию';

            //ISO BLOCK
            this.Isos = 'Изометрии';
            this.DesignAreaType_Name = 'Зона проектирования';
            this.Iso_Number = 'Номер изометрии';
            this.IsoNotBelongs = 'Данная изометрия не принадлежит ни одной изометрии';
            this.IsosFound = 'Изометрий найдено: ';
            this.IsoEdit = 'Редактировать изометрию';
            this.IsoNumberCantBeEmpty = "Номер изометрии не может быть пустым";

            //LINE BLOCK
            this.Line = 'Линия';
            this.Lines = 'Линии';
            this.LineEdit = 'Редактировать линию';
            this.LineNumber = 'Номер линии';
            this.Location_From = 'Начало';
            this.Location_To = 'Конец';
            this.Fluid_Name_Eng = 'Среда ENG';
            this.Fluid_Name_Rus = 'Среда RUS';
            this.Fluid_Danger_Code_By_Gost = 'Класс опасности вещества';
            this.Fluid_Fire_Aand_Explosive_Hazard = 'Показатель пожаровзрывоопасности вещества';
            this.Fluid_Group_By_TP_TC_032_2013 = 'Группа среды по ТР ТС 032/2013'
            this.Fluid_Group_By_GOST_32569_2013 = 'Группа среды по ГОСТ 32569-2013';
            this.Pipeline_Category_By_TP_TC_032_2013 = 'Категория трубопровода по ТР ТС 032/2013';
            this.Pipeline_Category_By_GOST_32569_2013 = 'Категория трубопровода по ГОСТ 32569-2013';
            this.Insert_DTS = 'Дата создания записи';
            this.Update_DTS = 'Дата обновления записи';
            this.LinesFound = 'Линий найдено: ';
            this.LineNumberCantBeEmpty = "Номер линии не может быть пустым";

            //SAVING BLOCK
            this.Save = "Сохранить";
            this.SavedRegister = 'Реестр сохранён';
            this.SavingMarka = 'Сохранение марки ';
            this.SavedMarka = 'Марка сохранена';
            this.SavingTitleObject = 'Сохранение титульного объекта';
            this.SavedTitleObject = 'Титульный объект сохранен';
            this.SavedIso = 'Изометрия сохранена';
            this.SavedLine = 'Линия сохранена';

            //DELETING BLOCK
            this.Delete = "Удалить";
            this.Deleting = 'Удаление';
            this.DeletingMarka = 'Удаление марки';
            this.DeletedMarka = 'Марка удалена';
            this.DeletingTitleObject = 'Удаление титульного объекта';
            this.DeletedTitleObject = 'Титульный объект удален';
            this.DeletedRegister = 'Реестр удален';
            this.DeleteSureLine = 'Вы уверены, что хотите удалить линию ';
            this.DeleteSureIso = 'Вы уверены, что хотите удалить изометрию ';
            this.DeletedIso = 'Изометрия была удалена';
            this.DeletedLine = 'Линия удалена';

            //ERROR BLOCK
            this.Error = 'Ошибка';
            this.ErrorSaved = 'Ошибка сохранения';
            this.ErrorDelete = 'Ошибка удаления';
            this.ErrorServer = 'Ошибка сервера';
            this.ErrorServerConnection = 'Соединение с сервером утеряно';
            this.ErrorApplication = 'Ошибка приложения';
            this.ErrorsInConsole = 'Ошибки выводятся в консоли';
            this.ErrorLogin = "Ошибка аутентификации";
            this.ErrorRegistration = "Ошибка регистрации";
            this.ErrorUpload = 'Ошибка загрузки';

            //FILES BLOCK
            this.UploadFiles = "Загрузить файл(ы)";
            this.File_Open = 'Открыть файл';
            this.UploadFilesSuccess = "Успешная загрузка файлов";
            this.UploadFilesError = "Ошибка загрузки файлов";
            this.SearchInFiles = "Найти файлы, содержащие";
            this.ChooseFilters = 'Выбрать фильтры';
            this.ApplyFilters = 'Применить фильтры';
            this.OpenFileForPreview = 'Открыть предпросмотр';
            this.FileName = 'Имя';
            this.FileStatus = 'Статус';
            this.FileSize = 'Размер';
            this.FilesNotSelected = 'Файлы не выбраны';
            this.FilesNotUploaded = 'Файлы не загружены';
            this.FilesNotAttached = 'Файлы не прикреплены';

            //AUTHORIZATION BLOCK
            this.LoginUserProfile = 'Вход в профиль';
            this.Login = 'Логин:';
            this.Password = 'Пароль:';
            this.Important = 'Важно:';
            this.CheckYourUrl = 'Перед вводом пароля всегда проверяйте URL адрес в командной строке своего браузера';
            this.EnterTheSystem = 'Войти в систему';
            this.ExitTheSystem = 'Выйти из системы';
            this.User = 'Пользователь:';
            this.UnAuthorisedUser = 'Неавторизованный пользователь';
            this.MustEnterTheSystem = 'Необходимо войти в систему';
            this.FillAllFieldsForAuth = 'Заполните все поля, необходимые для авторизации';
            this.NotValidUserCredentials = 'Неправильные данные пользователя';
            this.AlreadyLoggedOut = 'Пользователь уже вышел из системы';
            this.Register = 'Зарегистрировать';

            //FILTRATION AND SORTING BLOCK
            this.Contains="содержит";
            this.NotContains="не содержит";
            this.Equals="равно";
            this.NotEquals="не равно";
            this.After="после";
            this.Between="в период";
            this.Before="до";
            this.OrderByDesc = 'Сортировать по убыванию';
            this.OrderByAsc = 'Сортировать по возрастанию';
            this.TotalFound = 'Всего найдено: ';
            this.OfRegisters = 'реестров';
            this.OfFolders = 'папок';
            this.OfFiles = 'файлов';

            //TABLES BLOCK
            this.lineBefore="Вставить строку сверху";
            this.lineAfter="Вставить строку снизу";
            this.lineDelete="Удалить строку";
            this.ChoseColumns = 'Выбрать колонки таблицы';

            //COMMON
            this.Success = 'Успешно';
            this.Ok = 'Ок';
            this.Yes = 'Да';
            this.No = 'Нет';
            this.Cancel = 'Отмена';
            this.Warning = 'Внимание';
        }           
        if(langCode=='eng'){
            this.TotalSheets = "Total number of sheets";
            this.SelectSet="Select Set number";
            this.Drawing = "Gost / PID";
            this.ABDDocument_IssueDate = "ABD Document issue date";
            this.NoFolderCreatedYet="No folder's created yet in the set";
            this.Document="Document";
            this.Title="Title";
            this.Marka="Marka";
            this.Loading="Loading";
            this.ABDFinalFolder_Name="ABD Final folder number";
            this.ABDDocument_Number = "ABD Document number";
            this.ABDDocument_Name = "ABD Document name";
            this.CTR_RESP="Responsible from Contractor";
            this.SCTR_RESP="Responsible from Subcontractor";
            this.StartDate="Compilation Start Date";
            this.TargetDate="Compilation Target Date";
            this.ListCount="Quantity of pages";
            this.RowNum="Row number";
            this.OpenFolder="Open folder";
            this.OpenNewTab="Open in new tab";
            this.NotSelected="Not selected";
            this.notSelected = 'not selected';
            this.NumberInFolder="Number in folder";
            this.Structure="Structure";
            this.Remark = "Remarks";
            this.SheetFolderNumber = "Folder sheet number";
            this.Selected = "Selected: ";
            this.mustBeFilled = 'The field must be filled';
            this.notContainedByDictionary='No such object in the dictionary';
            this.valueAlreadyExists = 'This value already exists';
            this.nothingSelected = 'Nothing is selected';
            this.noSuchPair = "There's no such pair in the dictionary";
            this.Status = 'Status';
            this.Package = 'Package';
            this.SCTR_Resp = 'Responsible from Subcontractor';
            this.ABDStatusDate = 'ABD Status Date';
            this.CNT_Date = 'Date of signing';
            this.WorkDesc = 'Work description';
            this.Phase = 'Phase';
            this.ProcessPhase = 'Process phase';
            this.Register_Number = 'Register number';
            this.Register_Open = 'Open register';
            this.Select_All = 'Select all';
            this.Deselect_All = 'Deselect all';
            this.StatusDate = 'Date of ABD Status change: ';
            this.StatusModifiedBy = 'responsible: ';
            this.WorkPackage = 'Work package';
            this.ReportOrder = 'Report order';
            this.Description = 'Description';
            this.Description_Rus = 'Description (RUS)';
            this.Description_Eng = 'Desctiption (ENG)';
            this.CodeMark = 'Code Mark ';
            this.DrawingType = 'Drawing type';
            this.DrawingType_Eng = 'Drawing type (RUS)';
            this.DrawingType_Rus = 'Drawing type (ENG)';
            this.isPriority = 'is Priority';
            this.isUsedInMatrix = 'is Used in Matrix';
            this.Open = 'Open';
            this.endOfTable = 'End of table';
            this.EditMarka='Edit marka';
            this.EditTitleObject = 'Edit Title object';
            this.EditRegister = 'Edit register';
            this.ReportColor='Report color';
            this.First='Firsts';
            this.ReportOrderAfter = 'Report order after';
            this.EmptyMarkaName = 'Marka Name” cant be empty';
            this.StageOfConstruction = "Stage of construction";
            this.ParentObject = 'Parent object';
            this.TitleObject_for_ABDFinalSet = 'Designation in ABD Final Sets';
            this.CantChangeParent="Can't change parent object: current object has child objects";
            this.CantChangeColorParent='Report color is determined by the parent object';
            this.EmptyTitleObjecName = "Title object name can't be empty";
            this.ReportColorRequired = "Choosing Report color is required";
            this.PhaseRequired = "Choosing Phase is required";
            this.OnlyLatinSymbolsAndNumbersAreAllowedInTitleName = 'Only Latin Capital letters, numerals and single dividing element – dot - are allowed symbols to be used within Title Object Name';
            this.HomeButton = 'Main menu';
            this.LastWriteTime = 'Last write time';
            this.ABD = 'As-built documentation';
            this.FoldersAndSets = 'Sets and folders';
            this.Registers = 'Registers';
            this.Markas = 'Marka dictionary';
            this.TitleObjects = 'Title object dictionary';
            this.IPD = 'Permission documentation';
            this.ReferenceDocumentation = 'Reference documentation';
            this.Documents = "Documents";
            this.AnnulledRegister = 'Annuled register'
            this.ForLine = ' for line: ';
            this.LineIsoDictionary = 'Lines and Isometrics';
            this.Search = 'Search';
            this.CreatedBy = 'Created by';
            this.CreationDate = 'Date created';
            this.ModifiedDate = 'Date modified';
            this.Edit = 'Edit';
            this.SelectGost = 'Select GOST';
            this.SelectPid = 'Select PID';
            this.NoResults = 'No results';

            //ABDDOCUMENT BLOCK
            this.CreateABDDocument = 'Create document';
            this.ABDDocumentName = 'Document name';
            this.ABDDocumentNumber = 'Number';
            this.DocumentNumber = 'Document number';
            this.OfDocuments = 'documents';
            this.EditABDDocument = 'Edit ABD document: ';
            this.CreateABDDocument  ='Create ABD document';
            this.ViewABDDocument = 'Readonly: ';
            this.PagesNumber = 'Pages number';
            this.GOST = 'GOST';
            this.PID = 'PID';
            this.DocumentFiles = 'Document files';
            this.SureQuitDocument = 'Are you sure to quit editing this document? All unsaved changes will be discarded.'
            this.SavedABDDocument = 'Saved document';
            this.DeletedABDDocument = 'Deleted document';

            //CREATE BLOCK
            this.Create = 'Create';
            this.CreateMarka = 'Create Marka';
            this.CreateNewMarka = 'Creat new Marka';
            this.CreateNewTitleObject = 'Create new Title object';
            this.CreateRegister="Create new register";
            this.CreateLine = 'Create new line';
            this.CreateIso = 'Create isometrics';

            //ISO BLOCK
            this.Iso = 'Isometric';
            this.Isos = 'Isometrics';
            this.DesignAreaType_Name = 'Design area';
            this.Iso_Number = 'Isometric number';
            this.IsoNotBelongs = "!These isometric doesn't belong to any line: ";
            this.IsosFound = 'Isometrics found: ';
            this.IsoEdit = 'Edit isometrics';
            this.IsoNumberCantBeEmpty = "Isometrics number can't be empty";

            //LINE BLOCK
            this.Line = 'Line';
            this.Lines = 'Lines';
            this.LineNumber = 'Line number';
            this.LineEdit = 'Edit line';
            this.Location_From = 'Line location from';
            this.Location_To = 'Line location to';
            this.Fluid_Name_Eng = 'Fluid name (ENG)';
            this.Fluid_Name_Rus = 'Fluid name (RUS)';
            this.Fluid_Danger_Code_By_Gost = 'Fluid danger code by gost';
            this.Fluid_Fire_Aand_Explosive_Hazard = 'Fluid fire and explosive hazard';
            this.Fluid_Group_By_TP_TC_032_2013 = 'Fluid group by TR CU 032/2013'
            this.Fluid_Group_By_GOST_32569_2013 = 'Fluid group by Gost 32569-2013';
            this.Pipeline_Category_By_TP_TC_032_2013 = 'Pipeline category by TR CU 032/2013';
            this.Pipeline_Category_By_GOST_32569_2013 = 'Pipeline category by Gost 32569-2013';
            this.Insert_DTS = 'Insert date';
            this.Update_DTS = 'Update date';
            this.LinesFound = 'Lines found: ';
            this.LineNumberCantBeEmpty = "Line number can't be empty";

            //SAVING BLOCK
            this.Save = "Save";
            this.SavedRegister = "Register's saved";
            this.SavingMarka = 'Saving Marka ';
            this.SavedMarka = "Marka's saved";
            this.SavingTitleObject = 'Saving Title object';
            this.SavedTitleObject = 'Title object is saved';
            this.SavedIso = 'Isometric has been saved';
            this.SavedLine = 'Line has been saved';

            //DELETING BLOCK
            this.Delete = "Delete";
            this.Deleting = 'Deleting';
            this.DeletingMarka = 'Deleting Marka';
            this.DeletedMarka = 'Deleted Marka';
            this.DeletingTitleObject = 'Deleting Title object';
            this.DeletedTitleObject = 'Title object is deleted';
            this.DeletedRegister = 'Register is deleted';
            this.DeleteSureLine = 'Are you sure, you want to delete Line ';
            this.DeleteSureIso = 'Are your sure, you want to delete Isometric ';
            this.DeletedIso = 'Isometric has been deleted';
            this.DeletedLine = 'Line has been deleted';
            
            //ERROR BLOCK
            this.Error = 'Error';
            this.ErrorSaved = 'Error of saving';
            this.ErrorDelete = 'Error while deleting';
            this.ErrorServer = 'Server error';
            this.ErrorServerConnection = 'Connection with server lost';
            this.ErrorApplication = 'Application error';
            this.ErrorsInConsole = 'Errors are shown in Error console';
            this.ErrorLogin = "Error of authentification";
            this.ErrorRegistration = "Registration error";
            this.ErrorUpload = 'Upload error';

            //FILES BLOCK
            this.UploadFiles = "Upload files";
            this.File_Open = 'Open file';
            this.UploadFilesSuccess = "Successful file upload";
            this.UploadFilesError = "File uploading error";
            this.SearchInFiles = "Search inside files";
            this.OpenFileForPreview = 'Open for preview';
            this.FileName = 'Name';
            this.FileStatus = 'Status';
            this.FileSize = 'Size';
            this.FilesNotSelected = 'No files selected';
            this.FilesNotUploaded = 'No files uploaded';
            this.FilesNotAttached = 'No files attached';
            this.TheFile = 'The file';
            this.FileAlredyAttached = 'is already attached';

            //AUTHORIZATION BLOCK
            this.LoginUserProfile = 'Log in';
            this.Login = 'User:';
            this.Password = 'Password:';
            this.Important = 'Importang:';
            this.CheckYourUrl = 'Before entering password, always check URL address in your browser command line';
            this.EnterTheSystem = 'Log in';
            this.ExitTheSystem = 'Log out';
            this.User = 'User:';
            this.UnAuthorisedUser = 'Unauthentificated';
            this.MustEnterTheSystem = 'Authentification is required';
            this.FillAllFieldsForAuth = 'Fill all the fields necessary for authentification';
            this.NotValidUserCredentials = 'Not valid user credentials';
            this.AlreadyLoggedOut = 'User has already logged out';
            this.Register = 'Register user';

            //FILTRATION AND SORTING BLOCK
            this.Contains="contains";
            this.NotContains="not contains";
            this.Equals="equals";
            this.NotEquals="not equals";
            this.After="after";
            this.Between="between";
            this.Before="before";
            this.OrderByDesc = 'Order by desc';
            this.OrderByAsc = 'Order by asc';
            this.TotalFound = 'Total found: ';
            this.OfRegisters = 'registers';
            this.OfFolders = 'folders';
            this.OfFiles = 'files';
            this.ChooseFilters = 'Choose filters';
            this.ApplyFilters = 'Apply filters';

            //TABLES BLOCK
            this.lineBefore="Insert row above";
            this.lineAfter="Insert row below";
            this.lineDelete="Delete row";
            this.ChoseColumns = 'Choose table columns';

            //COMMON
            this.Success = 'Success';
            this.Ok = 'Ok';
            this.Yes = 'Yes';
            this.No = 'No';
            this.Cancel = 'Cancel';
            this.Warning = 'Warning';
        }           
    }
}
