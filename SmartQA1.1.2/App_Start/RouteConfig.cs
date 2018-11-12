using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartQA1._1._2
{
    public class RouteConfig
    {
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		    routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                name: "Permission",
                url: "Permission",
                defaults: new { controller = "Permission", action = "ShowMainView" }
            );
            routes.MapRoute(
                name: "TestFormLayout",
                url: "TestFormLayout",
                defaults: new {controller = "Test", action = "ShowMainView" }
            );
		    routes.MapRoute(
		        name: "Registers",
                url: "Registers",
		        defaults: new { controller = "Register", action = "Index" }
		    );
            routes.MapRoute(
		        name: "Documents",
		        url: "Documents",
		        defaults: new { controller = "Document", action = "Index" }
		    );
            routes.MapRoute(
                name: "SearchGost",
                url: "SearchGost",
                defaults: new { controller = "Service", action = "SearchGost" }
            );
            routes.MapRoute(
                name: "SearchPid",
                url: "SearchPid",
                defaults: new { controller = "Service", action = "SearchPid" }
            );
            routes.MapRoute(
                name: "ABDDocuments",
                url: "ABDDocuments",
                defaults: new { controller = "ABDDocument", action = "ShowPage" }
            );
            routes.MapRoute(
                name: "DeleteABDDocument",
                url: "DeleteABDDocument",
                defaults: new { controller = "ABDDocument", action = "DeleteABDDocument" }
            );
            routes.MapRoute(
                name: "SaveABDDocument",
                url: "SaveABDDocument",
                defaults: new { controller = "ABDDocument", action = "SaveABDDocument" }
            );
            routes.MapRoute(
                name: "GetDocumentFiles",
                url: "GetDocumentFiles",
                defaults: new { controller = "ABDDocument", action = "GetDocumentFiles" }
            );
            routes.MapRoute(
                name: "GetABDDocumentById",
                url: "GetABDDocumentById",
                defaults: new { controller = "ABDDocument", action = "GetABDDocumentById" }
            );
            routes.MapRoute(
                name: "GetABDDocumentList",
                url: "GetABDDocumentList",
                defaults: new { controller = "ABDDocument", action = "GetABDDocumentList" }
            );
            routes.MapRoute(
                name: "ABDDocumentDeleteFile",
                url: "ABDDocumentDeleteFile",
                defaults: new { controller = "ABDDocument", action = "DeleteFile" }
            );
            routes.MapRoute(
                name: "ABDDocumentUploadFile",
                url: "ABDDocumentUploadFile",
                defaults: new { controller = "ABDDocument", action = "UploadFile" }
            );
            routes.MapRoute(
                name: "ABDDocumentDisposeUploadedFiles",
                url: "ABDDocumentDisposeUploadedFiles",
                defaults: new { controller = "ABDDocument", action = "DisposeUploadedFiles" }
            );
            routes.MapRoute(
                name: "LineIsoDictionary",
                url: "LineIsoDictionary",
                defaults: new { controller = "Dictionary", action = "LineIsoDictionaryCore" }
            );
            routes.MapRoute(
                name: "getLineById",
                url: "getLineById",
                defaults: new { controller = "Dictionary", action = "getLineById" }
            );
            routes.MapRoute(
                name: "deleteLine",
                url: "deleteLine",
                defaults: new { controller = "Dictionary", action = "deleteLine" }
            );
            routes.MapRoute(
                name: "saveLine",
                url: "saveLine",
                defaults: new { controller = "Dictionary", action = "saveLine" }
            );
            routes.MapRoute(
                name: "deleteIso",
                url: "deleteIso",
                defaults: new { controller = "Dictionary", action = "deleteIso" }
            );
            routes.MapRoute(
                name: "saveIso",
                url: "saveIso",
                defaults: new { controller = "Dictionary", action = "saveIso" }
            );
            routes.MapRoute(
                name: "getIsoById",
                url: "getIsoById",
                defaults: new { controller = "Dictionary", action = "getIsoById" }
            );
            routes.MapRoute(
                name: "getIsosByLine",
                url: "getIsosByLine",
                defaults: new { controller = "Dictionary", action = "getIsosByLine" }
            );
            routes.MapRoute(
                name: "getLineByIso",
                url: "getLineByIso",
                defaults: new { controller = "Dictionary", action = "getLineByIso" }
            );
            routes.MapRoute(
                name: "getIsoListDictionary",
                url: "getIsoListDictionary",
                defaults: new { controller = "Dictionary", action = "getIsoListDictionary" }
            );
            routes.MapRoute(
                name: "getLineListDictionary",
                url: "getLineListDictionary",
                defaults: new { controller = "Dictionary", action = "getLineListDictionary" }
            );
            routes.MapRoute(
                name: "registerNewUser",
                url: "registerNewUser",
                defaults: new { controller = "Login", action = "Register" }
            );
            routes.MapRoute(
                name: "logout",
                url: "logout",
                defaults: new { controller = "Login", action = "Logout" }
            );
            routes.MapRoute(
                name: "login",
                url: "login",
                defaults: new { controller = "Login", action = "Login" }
            );
            routes.MapRoute(
                name: "checkLogin",
                url: "checkLogin",
                defaults: new { controller = "Login", action = "checkLogin" }
            );
            routes.MapRoute(
                name: "getRSAPublicKeyPassword",
                url: "getRSAPublicKeyPassword",
                defaults: new { controller = "Login", action = "getRSAPublicKeyPassword" }
            );
            routes.MapRoute(
                name: "TitleObjectDictionary",
                url: "TitleObjectDictionary",
                defaults: new { controller = "Dictionary", action = "TitleObjectDictionaryCore" }
            );
            routes.MapRoute(
                name: "MarkaDictionary",
                url: "MarkaDictionary",
                defaults: new { controller = "Dictionary", action = "MarkaDictionaryCore" }
            );
            routes.MapRoute(
                name: "getTitleObjectDictionaryById",
                url: "getTitleObjectDictionaryById",
                defaults: new { controller = "Dictionary", action = "getTitleObjectDictionaryById" }
            );
            routes.MapRoute(
                name: "deleteTitleObject",
                url: "deleteTitleObject",
                defaults: new { controller = "Dictionary", action = "deleteTitleObject" }
            );
            routes.MapRoute(
                name: "saveTitleObject",
                url: "saveTitleObject",
                defaults: new { controller = "Dictionary", action = "saveTitleObject" }
            );
            routes.MapRoute(
                name: "getTitleObjectDictionaryList",
                url: "getTitleObjectDictionaryList",
                defaults: new { controller = "Dictionary", action = "getTitleObjectDictionaryList" }
            );
            routes.MapRoute(
                name: "deleteMarka",
                url: "deleteMarka",
                defaults: new { controller = "Dictionary", action = "deleteMarka" }
            );
            routes.MapRoute(
                name: "saveMarka",
                url: "saveMarka",
                defaults: new { controller = "Dictionary", action = "saveMarka" }
            );
            routes.MapRoute(
                name: "getMarkaDictionaryList",
                url: "getMarkaDictionaryList",
                defaults: new { controller = "Dictionary", action = "getMarkaDictionaryList" }
            );
            routes.MapRoute(
                name: "getRegisterStatusList",
                url: "getRegisterStatusList",
                defaults: new { controller = "Register", action = "getRegisterStatusList"}
            );
            routes.MapRoute(
                name: "getRegisterStatusByRegisterId",
                url: "getRegisterStatusByRegisterId/{id}",
                defaults: new { controller = "Register", action = "getRegisterStatusByRegisterId", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "getRegisterByRegisterId",
                url: "getRegisterByRegisterId/{id}",
                defaults: new { controller = "Register", action = "getRegisterByRegisterId", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GetNewRegisterNumber",
                url: "GetNewRegisterNumber",
                defaults: new { controller = "Register", action = "GetNewRegisterNumber" }
            );
            routes.MapRoute(
                name: "SaveRegister",
                url: "SaveRegister",
                defaults: new { controller = "Register", action = "SaveRegister" }
            );
            routes.MapRoute(
                name: "DeleteRegister",
                url: "DeleteRegister",
                defaults: new { controller = "Register", action = "DeleteRegister" }
            );
            routes.MapRoute(
                name: "getRegisterList",
                url: "getRegisterList",
                defaults: new { controller = "Register", action = "getRegisterList" }
            );
            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Register", action = "ShowPageNew" }
            );
            routes.MapRoute(
                name: "getDesignAreaTypeList",
                url: "getDesignAreaTypeList",
                defaults: new { controller = "Shared", action = "getDesignAreaTypeList" }
            );
            routes.MapRoute(
				name: "getPidList",
				url: "getPidList",
				defaults: new { controller = "Shared", action = "getPidList" }
			);
            routes.MapRoute(
                name: "getGostList",
                url: "getGostList",
                defaults: new { controller = "Shared", action = "getGostList" }
            );
            routes.MapRoute(
				name: "getStructureList",
				url: "getStructureList",
				defaults: new { controller = "Shared", action = "getStructureList" }
			);
			routes.MapRoute(
				name: "getContragentsList",
				url: "getContragentsList",
				defaults: new { controller = "Shared", action = "getContragentsList" }
			);
			routes.MapRoute(
				name: "getTitleObjectList",
				url: "getTitleObjectList",
				defaults: new { controller = "Shared", action = "getTitleObjectList" }
			);
			routes.MapRoute(
				name: "getMarkaList",
				url: "getMarkaList",
				defaults: new { controller = "Shared", action = "getMarkaList" }
			);
            routes.MapRoute(
                name: "getPhaseList",
                url: "getPhaseList",
                defaults: new { controller = "Shared", action = "getPhaseList" }
            );
            routes.MapRoute(
                name: "GetProcessPhaseList",
                url: "GetProcessPhaseList",
                defaults: new { controller = "Shared", action = "GetProcessPhaseList" }
            );
            routes.MapRoute(
                name: "getWorkPackageList",
                url: "getWorkPackageList",
                defaults: new { controller = "Shared", action = "getWorkPackageList" }
            );
            routes.MapRoute(
                name: "getFinalFolderList",
                url: "getFinalFolderList",
                defaults: new { controller = "FinalFolderCore", action = "Index" }
            );
            routes.MapRoute(
				name: "getABDFinalFolderTypedFilteredList",
				url: "getABDFinalFolderTypedFilteredList",
				defaults: new { controller = "FinalFolderCore", action = "getABDFinalFolderTypedFilteredList" }
			);
            routes.MapRoute(
                name: "ABDFinalFolder",
                url: "ABDFinalFolder/{id}",
                defaults: new { controller = "ABDFolder", action = "ShowPage", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "getABDFinalSetList",
                url: "getABDFinalSetList",
                defaults: new { controller = "ABDFolder", action = "getABDFinalSetList" }
                );
            routes.MapRoute(
                name: "getABDFinalSetProperties",
                url: "getABDFinalSetProperties",
                defaults: new { controller = "ABDFolder", action = "getABDFinalSetProperties" }
                );
            routes.MapRoute(
                name: "getABDFinalFolderListBySet",
                url: "getABDFinalFolderListBySet",
                defaults: new { controller = "ABDFolder", action = "getABDFinalFolderListBySet" }
                );
            routes.MapRoute(
				name: "getABDFinalSetByFolder",
				url: "getABDFinalSetByFolder",
				defaults: new { controller = "ABDFolder", action = "getABDFinalSetByFolder" }
			);
            routes.MapRoute(
                name: "getABDFinalFolderDocuments",
                url: "getABDFinalFolderDocuments",
                defaults: new { controller = "ABDFolder", action = "getABDFinalFolderDocuments" }
            );
			routes.MapRoute(
				name: "getContragentByFolder",
				url: "getContragentByFolder",
				defaults: new { controller = "ABDFolder", action = "getContragentByFolder" }
			);
            routes.MapRoute(
                name: "updateEditFinalFolder",
                url: "updateEditFinalFolder",
                defaults: new { controller = "ABDFolder", action = "updateEditFinalFolder" }
            );
            routes.MapRoute(
                name: "FileStorage",
                url: "FileStorage",
                defaults: new { controller = "FileStorage", action = "ShowPage" }
            );
            routes.MapRoute(
                name: "GetPreviewFile",
                url: "GetPreviewFile",
                defaults: new { controller = "FileStorage", action = "GetPreviewFile" }
            );
            routes.MapRoute(
                name: "GetFileList",
                url: "GetFileList",
                defaults: new { controller = "FileStorage", action = "GetFileList" }
            );
            routes.MapRoute(
                name: "UploadFiles",
                url: "UploadFiles",
                defaults: new { controller = "FileStorage", action = "UploadFiles" }
            );
            routes.MapRoute(
                name: "DownloadFile",
                url: "DownloadFile/{id}",
                defaults: new { controller = "FileStorage", action = "DownloadFile", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GetPreview",
                url: "GetPreview/{id}",
                defaults: new { controller = "FileStorage", action = "GetPreview", id = UrlParameter.Optional }
            );

            routes.MapRoute(
				name: "lingerOnReadingFile",
				url: "lingerOnReadingFile",
				defaults: new { controller = "Test", action = "lingerOnReadingFile" }
				);

            // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
            routes.MapRoute(
                name: "mainMenuReact",
                url: "mainMenuReact",
                defaults: new { controller = "MainMenu", action = "showMainMenu" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
