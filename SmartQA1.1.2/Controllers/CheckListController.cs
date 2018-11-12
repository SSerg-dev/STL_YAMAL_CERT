using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Models;
using SmartQA1._1._2.Models.Register;

namespace SmartQA1._1._2.Controllers
{
    public class CheckListController : Controller
    {
        //MAIN VIEW
        public ActionResult GetCheckLists()
        {
            var currentRegister = (Register)System.Web.HttpContext.Current.Session["register"];
            return PartialView("CheckListMainView", currentRegister);
        }
        //CHECK ITEM EDIT FORM
        public ActionResult CheckItemEditForm(Guid? CheckItem_ID, CheckType checkType) //null Guid for new CheckItem
        {
            var register = (Register) System.Web.HttpContext.Current.Session["register"];

            CheckItem model = register.GetCheckItem(CheckItem_ID, checkType);

            ViewData["checkType"] = checkType;
            ViewData["checkItem"] = model;

            System.Web.HttpContext.Current.Session["checkItem"] = model.Clone(); //cloning the CheckItem so the user won't affect the initials

            return PartialView("CheckItemEditForm", model);
        }
        //CHECK ITEM GRID
        //[ValidateInput(false)]
        public ActionResult CheckItemGridPartial(CheckType checkType, Guid? checkItem_ID)
        {
            var register = (Register)System.Web.HttpContext.Current.Session["register"];

            var id = checkItem_ID;
            if(id!=null) register.CheckFixedItem(checkType, (Guid)checkItem_ID);

            CheckListWrapper model = register.GetCheckListWrapper(checkType);
            ViewData["EditError"] = null;
            return PartialView("_CheckItemGridPartial", model);
        }
        //[HttpPost, ValidateInput(false)]
        public ActionResult CheckItemGridPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CheckItem item, CheckType checkType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var register = (Register)System.Web.HttpContext.Current.Session["register"];
                    register.SaveCheckItem(item, checkType);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_CheckItemGridPartial", null);
        }
        //[HttpPost, ValidateInput(false)]
        public ActionResult CheckItemGridPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CheckItem checkItem, CheckType checkType, string command)
        {
            var register = (Register)System.Web.HttpContext.Current.Session["register"];
            var checkListWrapper = register.GetCheckListWrapper(checkType);
            
            var sessionCheckItem = (CheckItem)System.Web.HttpContext.Current.Session["checkItem"];
            sessionCheckItem.CopyEditableFields(checkItem);
            var result = sessionCheckItem.Update(command);

            ViewData["checkItem"] = sessionCheckItem;
            ViewData["EditError"] = "Status succesfully changed";

            return PartialView("_CheckItemGridPartial", checkListWrapper);
        }
        //[HttpPost, ValidateInput(false)]
        public ActionResult CheckItemGridPartialDelete(Guid CheckItem_ID, CheckType checkType)
        {
            if (CheckItem_ID != null)
            {
                try
                {

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            throw new NotImplementedException();
            return PartialView("_CheckItemGridPartial", null);
        }

        [ValidateInput(false)]
        public ActionResult CheckRespGrid([ModelBinder(typeof(DevExpressEditorsBinder))] CheckType checkType, Guid? CheckList_ID, string command)
        {
            var register = (Register)System.Web.HttpContext.Current.Session["register"];
            if (CheckList_ID != null && command != null)
            {
                var result = register.UpdateCheckListStatus(checkType, (Guid)CheckList_ID, command);
                if (!result.isValid) ViewData["EditError"] = result.ToString();
            }

            var model = register.GetCheckListWrapper(checkType);
            return PartialView("CheckRespGrid", model);
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult CheckListUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CheckList checkList, CheckType checkType)
        //{
        //    var register = (Register)System.Web.HttpContext.Current.Session["register"];

        //    var result = register.UpdateCheckListStatus(checkList, checkType);
        //    if (!result.isValid) ViewData["EditError"] = result.ToString();

        //    var model = register.GetCheckListWrapper(checkType);
        //    return PartialView("CheckRespGrid", model);
        //}

        //CHECK ITEM STATUS CHANGE action methods
        public ActionResult SendCheckItem([ModelBinder(typeof(DevExpressEditorsBinder))] Guid CheckItem_ID, CheckType checkType)
        {
            var checkItem = (CheckItem)System.Web.HttpContext.Current.Session["checkItem"];

            checkItem.State.SendButtonPressed();
            ViewData["checkType"] = checkType;

            var register = (Register)System.Web.HttpContext.Current.Session["register"];
            var model = register.GetCheckListWrapper(checkType);

            return PartialView("CheckItemEditForm", checkItem);
        }
    }
}