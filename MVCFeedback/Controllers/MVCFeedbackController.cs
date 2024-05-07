using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFeedback.Models;
namespace MVCFeedback.Controllers
{
    public class MVCFeedbackController : Controller
    {
        // GET: MVCFeedback
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MVCFeedbackIndex()
        {
            return View();
        }
        public ActionResult DetailsIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult Savereg(MVCFeedbackModel model)
        {
            try
            {
                return Json(new { Message = new MVCFeedbackModel().Savereg(model)}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMVCFeedbackList()
        {
            try
            {
                return Json(new { model = new MVCFeedbackModel().GetMVCFeedbackList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deleteMVCFeedback(int Id)
        {
            try
            {
                return Json(new { model = new MVCFeedbackModel().deleteMVCFeedback(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getMVCFeedbackbyId(int Id)
        {
            try
            {
                return Json(new { model = new MVCFeedbackModel().getMVCFeedbackbyId(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}