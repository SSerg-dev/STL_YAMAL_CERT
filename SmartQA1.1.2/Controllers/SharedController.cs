using System.Web.Mvc;
using SmartQA1._1._2.DB.WebDb;
using System.Text;
using SmartQA1._1._2.BusinessModels;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Controllers
{
    public class SharedController : Controller
    {
		//PID
		public JsonResult getPidList()
		{
			var PL = new PID();
			return Json(PL.fill(null), "application/json", Encoding.UTF8,  JsonRequestBehavior.AllowGet);
		}
		//Gost
		public JsonResult getGostList()
		{
			var GL = new GOST();
			return Json(GL.fill(null), JsonRequestBehavior.AllowGet);
		}
        //Structure
        public JsonResult getStructureList()
        {
            var SL = new R_Structure();
            return Json(SL.fill(null), JsonRequestBehavior.AllowGet);
        }
        //CONTRAGENT
        public JsonResult getContragentsList()
        {
            var CL = new p_Contragent();
            return Json(CL.fill(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMarkaList()
        {
            MarkaList ML = new MarkaList();
            return Json(ML.fill(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getTitleObjectList()
        {
            TitleObjectList TOL = new TitleObjectList();
            return Json(TOL.fill(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPhaseList()
        {
            return Json((new Phase()).fill(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProcessPhaseList()
        {
            return Json((new ProcessPhase()).fill(null), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getWorkPackageList()
        {
            return Json(new WorkPackage().fill(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDesignAreaTypeList()
        {
            return Json((new DesignAreaType()).fill(null), JsonRequestBehavior.AllowGet);
        }
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return new JsonResult()
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding,
				JsonRequestBehavior = behavior,
				MaxJsonLength = 10000000
			};
		}
	}
}