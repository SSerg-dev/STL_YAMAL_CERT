using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.Models;
using SmartQA1._1._2.Models.Dictionaries;
using Newtonsoft.Json;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB.StoredProcedures;

namespace SmartQA1._1._2.Controllers 
{
    public class DictionaryController : Controller
    {
        [Authorize]
        public ActionResult MarkaDictionaryCore()
        {
            return View("MarkaDictionary");
        }
        public JsonResult getMarkaDictionaryList()
        {
            return Json((new MarkaListDictionary()).fill(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult saveMarka(MarkaDictionary marka)
        {
            var saveResult = marka.Save();
            return saveResult != null ?
                Json(saveResult.Serialize(), JsonRequestBehavior.AllowGet) :null;
        }
        public JsonResult deleteMarka(MarkaDictionary marka)
        {
            var deleteResult = marka.Delete();
            return deleteResult !=null?
                Json(deleteResult.Serialize(), JsonRequestBehavior.AllowGet) :null;
        }
        //TITLE
        [Authorize]
        public ActionResult TitleObjectDictionaryCore()
        {
            return View("TitleObjectDictionary");
        }
        public JsonResult getTitleObjectDictionaryList()
        {
            return Json((new TitleObjectListDictionary()).fill(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult saveTitleObject(TitleObjectDictionary title)
        {
            var saveResult = title.Save();
            return saveResult != null ?
                Json(saveResult.Serialize(), JsonRequestBehavior.AllowGet) : null;
        }
        public JsonResult deleteTitleObject(TitleObjectDictionary title)
        {
            var deleteResult = title.Delete();
            return deleteResult != null ?
                Json(deleteResult.Serialize(), JsonRequestBehavior.AllowGet) : null;
        }
        public JsonResult getTitleObjectDictionaryById(Guid? id)
        {
            using (var context = new Entities())
            {
                return Json((new TitleObjectDictionary()).getTitleObjectDictionaryById(id, context), JsonRequestBehavior.AllowGet);
            }
        }
        //SHOW LINEISO DICTIONARY
        [Authorize]
        public ActionResult LineIsoDictionaryCore()
        {
            return View("LineIsoDictionary");
        }

        //LINE
        public JsonResult getLineListDictionary(List<Filter> inputFilters)
        {
            LineListDictionary lld = new LineListDictionary();
            lld.fill(inputFilters);
            return Json(lld, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getLineByIso(Guid? isoGuid)
        {
            LineListDictionary lld = new LineListDictionary();
            lld.getLineByIso(isoGuid);
            return Json(lld, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getLineById(Guid? lineId)
        {
            return Json(new LineListDictionary().getLineById(lineId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult saveLine(LineDictionary inputLine)
        {
            var result = inputLine.Save();
            if (result != null)
                return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else
                return null;
        }

        public JsonResult deleteLine(LineDictionary inputLine)
        {
            var result = inputLine.Delete();
            if (result != null)
                return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else
                return null;
        }
        //ISO
        public JsonResult getIsoListDictionary(List<Filter> inputFilters)
        {
            IsoListDictionary ild = new IsoListDictionary();
            ild.fill(inputFilters);
            return Json(ild, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getIsosByLine(Guid? lineGuid)
        {
            IsoListDictionary ild = new IsoListDictionary();
            ild.getIsosByLine(lineGuid);
            return Json(ild, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getIsoById(Guid? isoId)
        {
            return Json(new IsoListDictionary().getIsoById(isoId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult saveIso(IsoDictionary inputIso)
        {
            var result = inputIso.Save();
            if (result != null)
                return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else
                return null;
        }

        public JsonResult deleteIso(IsoDictionary inputIso)
        {
            var result = inputIso.Delete();
            if (result != null)
                return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else
                return null;
        }
    }
}