using Sopon.DBAccess;
using Sopon.Library;
using Sopon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Sopon.Controllers
{
    public class OutcomeController : Controller
    {
        public ActionResult Outcome()
        {
            DatabaseAccess dba = new DatabaseAccess();
            var outcomes = dba.GetAllOutcomeDetails();

            return View("OutcomeView", new OutcomeModel(outcomes));
        }

        public ActionResult GoToAddNewOutcomeRecordPage(OutCome newRecord)
        {
            return Redirect("AddOutcomeView");
        }

        public ActionResult HandleAddNewOutcomeRecord(string name, string amount, string unitPrice,
            string count, string date, string desc)
        {
            OutCome rec = new OutCome();
            rec.OutcomeName = name;
            rec.Amout = string.IsNullOrEmpty(amount) ? 0 : Convert.ToInt32(amount);
            rec.GoodsUnitPrice = string.IsNullOrEmpty(unitPrice) ? 0 : Convert.ToDouble(unitPrice);
            rec.GoodsCount = string.IsNullOrEmpty(count) ? 0 : Convert.ToInt32(count);
            rec.CreatedDate = string.IsNullOrEmpty(date) ? DateTime.Now.ToString("yyyy-MM-dd") : date;
            rec.OutcomeDesc = desc;

            DatabaseAccess dba = new DatabaseAccess();

            var result = dba.AddNewOutcomeRecord(rec);
            var outcomes = dba.GetAllOutcomeDetails();

            return View("OutcomeView", new OutcomeModel(outcomes));
        }

        public ActionResult HandleModifyOutcomeRecord(string id, string name, string amount, string unitPrice,
                                                         string count, string date, string desc)
        {
            OutCome rec = new OutCome();
            rec.ID = Convert.ToInt32(id);
            rec.OutcomeName = name;
            rec.Amout = Convert.ToInt32(amount);
            rec.GoodsUnitPrice = Convert.ToDouble(unitPrice);
            rec.GoodsCount = Convert.ToInt32(count);
            rec.CreatedDate = date;
            rec.OutcomeDesc = desc;

            DatabaseAccess dba = new DatabaseAccess();

            var result = dba.UpdateOutcomeRecord(rec);

            var outcomes = dba.GetAllOutcomeDetails();

            return View("OutcomeView", new OutcomeModel(outcomes));
        }

        public ActionResult AddOutcomeView()
        {
            return View();
        }

        public ActionResult UpdateOutcomeView(int id)
        {
            DatabaseAccess dba = new DatabaseAccess();

            var outcome = dba.GetOutcomeBySID(id);

            return View("UpdateOutcomeView", new UpdateOutComeModel(outcome));
        }

        public ActionResult HandleDeleteOutcome(string id)
        {
            DatabaseAccess dba = new DatabaseAccess();

            var res = dba.DeleteOutcomeBySID(id);

            var outcomes = dba.GetAllOutcomeDetails();

            return View("OutcomeView", new OutcomeModel(outcomes));
        }

        [HttpGet]
        public ActionResult Outcome(string outcomeName, string outcomeDesc, string fromDate, string toDate)
        {
            DatabaseAccess dba = new DatabaseAccess();

            var res = dba.GetOutcomeBySearchConditions(outcomeName, outcomeDesc, fromDate, toDate);

            // Clear the ModelState
            ModelState.Clear();

            return View("OutcomeView", new OutcomeModel(res));
        }
    }
}
