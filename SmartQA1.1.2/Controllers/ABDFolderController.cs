using Newtonsoft.Json;
using SmartQA1._1._2.DB;
using System.Collections.Generic;
using System.Web.Mvc;
using SmartQA1._1._2.Models.Login;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Controllers
{
    public class ABDFolderController : Controller
    {
		//1st - show the page itself
        [Authorize]
		public ActionResult ShowPage(string ABDFinalFolder_ID)
        {
            ViewBag.ABDFinalFolder_ID = ABDFinalFolder_ID;
            return View();
        }
		//2nd - let the user choose the Set
		public JsonResult getABDFinalSetList()
		{
			System.Diagnostics.Debug.WriteLine("getABDFinalSetList");
			return Json(new ABDFinalSetList().fill(null), JsonRequestBehavior.AllowGet);
		}
		//3d - when user chose the Set, fill up the title of the Set and give it back
		public JsonResult getABDFinalSetProperties()
		{
			System.Diagnostics.Debug.WriteLine("getABDFinalSet");
			System.Diagnostics.Debug.WriteLine("Properties required of set: "+ Request["ABDFinalSet_ID"]);
			ABDFinalSet AFS = new ABDFinalSet();
			return Json(AFS.getABDFinalSetHeadBySetId(Request["ABDFinalSet_ID"]), JsonRequestBehavior.AllowGet);
		}
		//4th - give the user the list of all Folders in the Set
		public JsonResult getABDFinalFolderListBySet()
		{
			System.Diagnostics.Debug.WriteLine("getABDFinalFolderList");
			ABDFinalFolderList AF = new ABDFinalFolderList();
			System.Diagnostics.Debug.WriteLine("getABDFinalFolder: The requsted Set ID: " + Request["ABDFinalSet_ID"]);
			return Json(AF.getABDFinalFolderListBySet(Request["ABDFinalSet_ID"]), JsonRequestBehavior.AllowGet);
		}
		//5th - give the user the list of all Contragents - moved to SharedController

		////6th - when user selected folder give him all documents in folder specification:
		//public JsonResult getABDFinalFolderDocuments()
		//{
		//	System.Diagnostics.Debug.WriteLine("getABDFinalFolder");
		//	ABDDocumentList ABDL = new ABDDocumentList();
		//	return Json(ABDL.fill(Request["ABDFinalFolder_ID"]), JsonRequestBehavior.AllowGet);
		//}
		//7th - also with the previous step the client will ask for the contragent of the FinalFolder
		public JsonResult getContragentByFolder()
		{
			System.Diagnostics.Debug.WriteLine("getContragentByFolder");
			var CT = new p_Contragent();
			return Json(CT.getContragetByABDFinalFolderId(Request["ABDFinalFolder_ID"]), JsonRequestBehavior.AllowGet);
		}
		public JsonResult updateEditFinalFolder()
		{
            throw new System.NotImplementedException();
		}
		/*But if the user has chosen a folder for editing you need to retrieve ABDFinalSet_ID
		and proceed to the steps 3 and 6*/
		public JsonResult getABDFinalSetByFolder()
		{
			System.Diagnostics.Debug.WriteLine("Getting ABDFinalSet by Folder");
			ABDFinalSetList AFS = new ABDFinalSetList();
			return Json(AFS.getABDFinalSetByFolder(Request["ABDFinalFolder_ID"]));
		}
    }
}
 
 
 
 
 
 
 
 