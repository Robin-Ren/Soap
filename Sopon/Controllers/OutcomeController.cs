using Sopon.DBAccess;
using Sopon.Library;
using Sopon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            rec.Amout = Convert.ToInt32(amount);
            rec.GoodsUnitPrice = Convert.ToDouble(unitPrice);
            rec.GoodsCount = Convert.ToInt32(count);
            rec.CreatedDate = DateTime.Parse(date);
            rec.OutcomeDesc = desc;

            DatabaseAccess dba = new DatabaseAccess();

            var result = dba.AddNewOutcomeRecord(rec);

            return Redirect("OutcomeView");
        }

        public ActionResult AddOutcomeView()
        {
            return View();
        }

    }
}
