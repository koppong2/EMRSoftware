using EMRSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace EMRSoftware.Controllers
{
    public class AccountsController : Controller
    {
        EMRSoftwareModel db = new EMRSoftwareModel();
        // GET: Receipt
        public ActionResult ReceiptIndex(string searching, int? page, string sortby)
        {
            ViewBag.SortReceiptIDParameter = string.IsNullOrEmpty(sortby) ? "ID desc" : "";  // sorts list by asc Receipt ID by default
            ViewBag.SortPatientIdParameter = sortby == "Hosp. No" ? "Hosp. No desc" : "Hosp ID"; // sorts Hosp No. column
            ViewBag.SortPurposeParameter = sortby == "Purpose" ? "Purpose desc" : "Purpose"; // sorts Purpose column
            ViewBag.SortReceiptDateParameter = sortby == "Date" ? "Date desc" : "Date"; // sorts ReceiptDate column
            ViewBag.SortWorkingDayIDParameter = sortby == "Working Day" ? "Working Day desc" : "WorkingDayID";   // sorts WorkingDayID column
            ViewBag.SortWorkingMonthIDParameter = sortby == "Working Month" ? "Working Month desc" : "WorkingMonthID";   // sorts WorkingMonthID column
            ViewBag.SortWorkingYearIDParameter = sortby == "Working Year" ? "Working Year desc" : "WorkingYearID";   // sorts WorkingYearID column

            var recs = db.Receipts.AsQueryable();
            try
            {
                if (searching != null)
                    searching = searching.Trim();

                switch (sortby)
                {
                    case "ID desc":
                        recs = recs.OrderByDescending(x => x.ReceiptID);
                        break;
                    case "Hosp. No desc":
                        recs = recs.OrderByDescending(x => x.PatientID);
                        break;
                    case "Hosp. No":
                        recs = recs.OrderBy(x => x.PatientID);
                        break;
                    case "Purpose desc":
                        recs = recs.OrderByDescending(x => x.Purpose);
                        break;
                    case "Purpose":
                        recs = recs.OrderBy(x => x.Purpose);
                        break;
                    case "Date":
                        recs = recs.OrderBy(x => x.ReceiptDate);
                        break;
                    case "Date desc":
                        recs = recs.OrderByDescending(x => x.ReceiptDate);
                        break;
                    case "Working Day":
                        recs = recs.OrderBy(x => x.WorkingDayID);
                        break;
                    case "Working Day desc":
                        recs = recs.OrderByDescending(x => x.WorkingDayID);
                        break;
                    case "Working Month desc":
                        recs = recs.OrderByDescending(x => x.WorkingMonthID);
                        break;
                    case "Working Month":
                        recs = recs.OrderBy(x => x.WorkingMonthID);
                        break;
                    case "Working Year desc":
                        recs = recs.OrderByDescending(x => x.WorkingYearID);
                        break;
                    case "Working Year":
                        recs = recs.OrderBy(x => x.WorkingYearID);
                        break;
                    default:
                        recs = recs.OrderBy(x => x.ReceiptID);
                        break;
                }

                return View(recs.Where(x => x.ReceiptID.Contains(searching) || x.WorkingMonthID.Contains(searching) || x.WorkingDayID.Contains(searching) ||
                x.WorkingYearID.Contains(searching) ||
                searching == null || x.PatientID.StartsWith(searching) || x.PatientID.Contains(searching)
                || x.Purpose.Contains(searching)).ToList().ToPagedList(page ?? 1, 25));    // limit entries to user inputted search parameter

            }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            return View();
            }

        // GET: Accounts/ReceiptDetails/5
        public ActionResult ReceiptDetails(string id)
        {
            Receipt receipt = db.Receipts.Find(id);

                var patientbill = db.PatientBills.Where(x => x.ReceiptID == receipt.ReceiptID).ToList();
                if (patientbill != null)
                {
                    ViewBag.PatientBill = patientbill;
                }
            
            if (receipt == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(receipt);
            }
        }

        // GET: Accounts/ReceiptCreate
        public ActionResult ReceiptCreate()
        {
            ViewBag.ReceiptTypeIDList= new SelectList(db.ReceiptTypes, "ReceiptTypeID", "ReceiptTypeName");
            ViewBag.NewReceiptNo = GetNextReceiptNumber();
            return View();
        }

        // POST: Accounts/ReceiptCreate
        [HttpPost]
        public ActionResult ReceiptCreate(FormCollection collection,Receipt rec)
        { var month = "";
          var year = "";
          var day = "";
            try
            {
                if (rec.ReceiptName == "" || rec.ReceiptName == null)
                {
                    rec.ReceiptName = rec.PatientID.Split('[')[1].Trim().Split(']')[0].Trim();
                }

                if (rec.PatientID.Contains('['))
                {
                    rec.PatientID = rec.PatientID.Split('[')[0].Trim();
                }

                year = DateTime.Now.Year.ToString();
                if (DateTime.Now.Month.ToString().Length == 1) month = "0" + DateTime.Now.Month.ToString();
                else month = DateTime.Now.Month.ToString();

                if (DateTime.Now.Day.ToString().Length == 1) day = "0" + DateTime.Now.Month.ToString();
                else day = DateTime.Now.Day.ToString();

                rec.WorkingDayID = "Day" + year + month + day;            // TODO: Add insert logic here
                rec.WorkingMonthID = "MTH" + year + month;
                rec.WorkingYearID = "YRS" + year;
                rec.ReceiptDate = DateTime.Now;
                rec.ReceiptAmt1 = rec.ReceiptAmount;
                rec.ReceiptAmt2 = "0.00";
                rec.ReceiptAmt3 = rec.ReceiptAmount;
                rec.ReceiptDate1 = rec.ReceiptDate;
                rec.ReceiptDate2 = rec.ReceiptDate;
                rec.ReceiptStatusID = "R001";

                db.Receipts.Add(rec);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                ModelState.Clear();
            return RedirectToAction("ReceiptIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/ReceiptEdit/5
        public ActionResult ReceiptEdit(string id)
        {
            // TODO: Add update logic here
            Receipt rec = db.Receipts.Find(id);
            if (rec == null)
            {
                return View("View Not Found");
            }
            else
            {
                ViewBag.ReceiptTypeIDList = new SelectList(db.ReceiptTypes, "ReceiptTypeID", "ReceiptTypeName");
                ViewBag.ReceipStatusIDList = new SelectList(db.ReceiptStatus, "ReceiptStatusID", "ReceiptStatusName");
                return View(rec);
            }
        }

        // POST: Accounts/ReceiptEdit/5
        [HttpPost]
        public ActionResult ReceiptEdit(string id, FormCollection collection,Receipt receipt)
        {
            try
            {
                // TODO: Add update logic her
                if (receipt == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.ReceiptTypeIDList = new SelectList(db.ReceiptTypes, "ReceiptTypeID", "ReceiptTypeName");
                        ViewBag.ReceipStatusIDList = new SelectList(db.ReceiptStatus, "ReceiptStatusID", "ReceiptStatusName");

                        if (receipt.PatientID.Contains("["))
                        {
                            var holdPatID = receipt.PatientID.Split('[')[0].Trim().ToString();
                            var holdPatName = receipt.PatientID.Split('[')[1].Split(']')[0].Trim().ToString();
                            if (receipt.PatientID.Contains('['))
                            {
                                if (receipt.PatientID.Contains("P1"))
                                {
                                    receipt.PatientID = holdPatID;
                                }
                                else
                                {
                                    receipt.PatientID = holdPatID;
                                    receipt.ReceiptName = holdPatName;
                                }
                            }
                        }

                       db.Entry(receipt).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("ReceiptIndex");
                }

            }
            catch
            {
                return View();
            }

        }

        // GET: Accounts/Delete/5
        public ActionResult ReceiptDelete(string id)
        {
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(receipt);
            }
        }

        // POST: Accounts/ReceiptDelete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Receipt receipt = db.Receipts.Find(id);
            if (receipt.ReceiptID != null)
            {
                var patientbills = db.PatientBills.Where(x => x.ReceiptID == receipt.ReceiptID).ToList();
                if (patientbills.Count() > 0)
                {
                    foreach(var patbill in patientbills)
                    {
                        db.PatientBills.Remove(patbill);
                        db.SaveChanges();
                    }

                }
                db.Receipts.Remove(receipt);
                db.SaveChanges();
            }
            return RedirectToAction("ReceiptIndex");

        }


        public String GetNextReceiptNumber()
        { string receiptNo = "", last_receiptNo="";
            var receiptInfo = db.Receipts.OrderByDescending(x => x.ReceiptID).Take(1).ToList();
            if (receiptInfo != null && receiptInfo.Count() > 0)
            {
                foreach (var x in receiptInfo)
                {
                    last_receiptNo = x.ReceiptID;
                    var hold = last_receiptNo.Substring(2);
                    if (Int32.TryParse(hold, out int result))
                    {
                        var holdNum = Int32.Parse(hold);
                        holdNum = holdNum + 1;
                        switch (holdNum.ToString().Trim().Length)
                        {
                            case 1:
                                receiptNo = "R1" + "00000" + holdNum;
                                break;
                            case 2:
                                receiptNo = "R1" + "0000" + holdNum;
                                break;
                            case 3:
                                receiptNo = "R1" + "000" + holdNum;
                                break;
                            case 4:
                                receiptNo = "R1" + "00" + holdNum;
                                break;
                            case 5:
                                receiptNo = "R1" + "0" + holdNum;
                                break;
                            case 6:
                                receiptNo = "R1" + holdNum;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
                receiptNo = "R1000001";

            return receiptNo;
        }


    }
}
