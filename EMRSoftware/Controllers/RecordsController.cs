using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMRSoftware.Models;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace EMRSoftware.Controllers
{
    public class RecordsController : Controller
    {
        //   EMRSoftwareModel db = new EMRSoftwareModel();
        EMRSoftwareModel db = new EMRSoftwareModel();
        // GET: Patient
        public ActionResult PatientIndex(string searching,int? page,string sortby)
        {
            ViewBag.SortIDParameter = string.IsNullOrEmpty(sortby) ? "ID desc":"";  // sorts list by asc PatientId by default
            ViewBag.SortNameParameter = sortby== "PatientName"? "PatientName desc" : "PatientName"; // sorts Patient name column
            ViewBag.SortPhoneNoParameter = sortby == "PatientNo" ? "PatientNo desc" : "PatientNo"; // sorts Patient No column
            ViewBag.SortDobParameter = sortby == "Dob" ? "Dob desc" : "Dob";   // sorts Dob column

            var pat = db.Patients.AsQueryable();
            var patients = db.Patients.AsQueryable();

            try
            {
                if (searching != null)
                    searching = searching.Trim();

                switch(sortby)
                {
                    case "ID desc":
                        patients = patients.OrderByDescending(x => x.PatientID);
                        break;
                    case "PatientName desc":
                        patients = patients.OrderByDescending(x => x.PatientName);
                        break;
                    case "PatientName":
                        patients = patients.OrderBy(x => x.PatientName);
                        break;
                    case "PatientNo desc":
                        patients = patients.OrderByDescending(x => x.PhoneNo);
                        break;
                    case "PatientNo":
                        patients = patients.OrderBy(x => x.PhoneNo);
                        break;
                    case "Dob":
                        patients = patients.OrderBy(x => x.dob);
                        break;
                    case "Dob desc":
                        patients = patients.OrderByDescending(x => x.dob);
                        break;
                    default:
                        patients = patients.OrderBy(x=>x.PatientID);
                        break;
                }
                
                return View(patients.Where(x => x.PatientName.Contains(searching) ||
                searching == null || x.PatientName.StartsWith(searching)||x.PatientID.Contains(searching)
                ||x.PatientID.StartsWith(searching)).ToList().ToPagedList(page ?? 1,25));    // limit entries to user inputted search parameter

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return View();
            }
            
            
        }

        // GET: Patient/Details/5
        public ActionResult PatientDetails(string id)
        {
            Patient newpatient = db.Patients.Find(id);
            if(newpatient == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(newpatient);
            }
        }

        // GET: Patient/Create
        public ActionResult PatientCreate()
        {
            string holdPatientId = "";
            ViewBag.Dropdownlist = new SelectList(db.Genders, "GenderID", "GenderName");
            try
            {
                var lastpatientrecord = db.Patients.OrderByDescending(x => x.PatientID).Take(1).ToList();
           
            foreach(var r in lastpatientrecord)
            {
                holdPatientId = r.PatientID.ToString();  
            }
            ViewBag.PatientId = GetNewPatientId(holdPatientId);
            }
            catch (Exception e)
            {
                Debug.WriteLine("PatientCreate Error >>>>"+e.Message);
            }

            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult PatientCreate(Patient patient, HttpPostedFileBase ImageFile)
        {
            try
            {
                ViewBag.Dropdownlist = new SelectList(db.Genders, "GenderID", "GenderName");
                // TODO: Add insert logic here
                string filename = "";
                string extension = "";


               if (ImageFile != null && ImageFile.ContentLength>0)
                {
                    filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    extension = Path.GetExtension(ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssffff") + extension;
                    patient.ImagePath = "~/Image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);   // gets filename from file upload
                    ImageFile.SaveAs(filename);
                }
                else
                {
                    patient.ImagePath = "~/Image/male.JPG";    //if no file is uploaded, set default pic
                }
             
                using (EMRSoftwareModel db = new EMRSoftwareModel())
                {
                    db.Patients.Add(patient);
                    BillingGroup billGrp = new BillingGroup();
                    billGrp.PatientID = patient.PatientID;
                    billGrp.BillingGroupID = patient.PatientID + "-01";
                    billGrp.RelationID = "R001";
                    billGrp.SponsorCategoryID = "NONE";
                    billGrp.SponsorID = "Cash";
                    billGrp.StatusID = "ST002";
                    billGrp.InitialDependantID = "NONE";
                    billGrp.SubSponsorID = "NONE";
                    db.BillingGroups.Add(billGrp);
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
                }
                ModelState.Clear();
                return RedirectToAction("PatientIndex");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "" + e.Message;
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult PatientEdit(string id)
        {
                // TODO: Add update logic here
                Patient newPatient = db.Patients.Find(id);
                if (newPatient == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    ViewBag.Dropdownlist = new SelectList(db.Genders, "GenderID", "GenderName");
                    if (newPatient.ImagePath == null)
                    {
                        newPatient.ImagePath = "~/Image/male.JPG";
                    }
                    ViewBag.ImagePath = newPatient.ImagePath;
                    return View(newPatient);
                }
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult PatientEdit(string id, Patient newpatient, HttpPostedFileBase ImageFile)
        {
            try
            {
                // TODO: Add update logic her
                if (newpatient == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    if (ModelState.IsValid)
                    { 
                    ViewBag.Dropdownlist = new SelectList(db.Genders, "GenderID", "GenderName");
                    ViewBag.ImagePath = newpatient.ImagePath;
                    if(newpatient.ImagePath == null && ImageFile == null && ImageFile.ContentLength==0)
                    {
                       newpatient.ImagePath = "~/Image/male.JPG";
                    }
                    else if(ImageFile != null && ImageFile.ContentLength>0)
                    {
                        string filename = "", extension = "";
                        filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        extension = Path.GetExtension(ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssffff") + extension;
                        newpatient.ImagePath = "~/Image/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Image/"), filename);   // gets filename from file upload
                        ImageFile.SaveAs(filename);                            
                    }
                     db.Entry(newpatient).State = EntityState.Modified;
                     db.SaveChanges();
                    }
                    return RedirectToAction("PatientIndex");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult PatientDelete(string id)
        {
            Patient newpatient = db.Patients.Find(id);
            return View(newpatient);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult PatientDelete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Patient newpatient = db.Patients.Find(id);
                db.Patients.Remove(newpatient);
                db.SaveChanges();
                return RedirectToAction("PatientIndex");               
            }
            catch
            {
                return View();
            }
        }


        private string GetNewPatientId(String patID)
        {
            int patIDLen = 0,result =0;
            string newPatID = "";
            
            try
            {
                patID = patID.TrimStart(new char[] { '0' }); // TrimStart takes out leading zeros
                 result = int.Parse(patID) + 1;  
                patIDLen= (result+"").Trim().Length;
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error trying to converting to Int:::: string = "+patID);
            }

            switch (patIDLen)
            {
                case 1:
                    newPatID = "000000" + result;
                    break;
                case 2:
                    newPatID = "00000" + result;
                    break;
                case 3:
                    newPatID = "0000" + result;
                    break;
                case 4:
                    newPatID = "000" + result;
                    break;
                case 5:
                    newPatID = "00" + result;
                    break;
                case 6:
                    newPatID = "0" + result;
                    break;
                default:
                    newPatID = ("" + result).Trim();
                    break;
            }
            return newPatID;
        }

        public JsonResult AutoCompletePatientId(string term)
        {
            try
            {
                //retrieve all matching folders
                var result = (from e in db.Patients
                              orderby e.PatientID
                              where e.PatientID.StartsWith(term) || e.PatientName.Contains(term)||e.PatientID.Contains(term)
                              select new
                              {
                                  FolderID = e.PatientID,
                                  PatientFolderName = e.PatientID + " [" + e.PatientName + " ]"
                              })
                          .Take(20).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var result = "";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        /************    Start of BillingGroup Code **********************/
        // GET: Patient/Index
        public ActionResult BillingGroupIndex(string searching, int? page, string sortby)
        {
            ViewBag.SortIDParameter = string.IsNullOrEmpty(sortby) ? "ID desc" : "";  // sorts list by asc BillingGroupId by default
            ViewBag.SortPatientIdParameter = sortby == "Hosp. No" ? "Hosp. No desc" : "Hosp. No"; // sorts Hosp No. column
            ViewBag.SortSponsorNameParameter = sortby == "Sponsor Name" ? "Sponsor Name desc" : "Sponsor Name"; // sorts Sponsor name column
            ViewBag.SortStatusNameParameter = sortby == "Status Name" ? "Status Name desc" : "Status Name"; // sorts Status Name column
            ViewBag.SortInitialDependantParameter = sortby == "Initial Dependant ID" ? "Initial Dependant ID desc" : "Initial Dependant ID";   // sorts Initial Dependant column

            var billinggrps = db.BillingGroups.AsQueryable();
            try
            {
                if (searching != null)
                    searching = searching.Trim();

                switch (sortby)
                {
                    case "ID desc":
                        billinggrps = billinggrps.OrderByDescending(x => x.BillingGroupID);
                        break;
                    case "Hosp. No desc":
                        billinggrps = billinggrps.OrderByDescending(x => x.PatientID);
                        break;
                    case "Hosp. No":
                        billinggrps = billinggrps.OrderBy(x => x.PatientID);
                        break;
                    case "Sponsor Name desc":
                        billinggrps = billinggrps.OrderByDescending(x => x.Sponsor.SponsorName);
                        break;
                    case "Sponsor Name":
                        billinggrps = billinggrps.OrderBy(x => x.Sponsor.SponsorName);
                        break;
                    case "Status Name":
                        billinggrps = billinggrps.OrderBy(x => x.Status.StatusName);
                        break;
                    case "Status Name desc":
                        billinggrps = billinggrps.OrderByDescending(x => x.Status.StatusName);
                        break;
                    case "Initial Dependant ID":
                        billinggrps = billinggrps.OrderBy(x => x.InitialDependantID);
                        break;
                    case "Initial Dependant ID desc":
                        billinggrps = billinggrps.OrderByDescending(x => x.InitialDependantID);
                        break;
                    default:
                        billinggrps = billinggrps.OrderBy(x => x.BillingGroupID);
                        break;
                }

                return View(billinggrps.Where(x => x.BillingGroupID.Contains(searching) ||
                searching == null || x.PatientID.StartsWith(searching) || x.PatientID.Contains(searching)
                || x.Sponsor.SponsorName.Contains(searching)).ToList().ToPagedList(page ?? 1, 50));    // limit entries to user inputted search parameter

            }
            catch (Exception e)
            {
                Console.WriteLine("BillingInded >>>>> " + e.Message);
                return View();
            }

        }

        // GET: BillingGroup/Create
        public ActionResult BillingGroupCreate(string initialdepID, string sponID, string subsponID)
        {
            ViewBag.RelationIdDropDownList = new SelectList(db.Relations, "RelationId", "RelationName");
            ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
            ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
            ViewBag.SponsorCategoryIdList = new SelectList(db.SponsorCategories, "SponsorCategoryId", "SponsorCategoryName");
            if (initialdepID != "" && initialdepID != null)
            {
                ViewBag.InitialDependantId = initialdepID;
            }
            if (sponID != "" && sponID != null)
            {
                ViewBag.SponsorId = sponID;
            }
            if (subsponID != "" && subsponID != null)
            {
                ViewBag.SubSponId = subsponID;
            }
            return View();
        }


        // POST: BillingCreate/Create
        [HttpPost]
        public ActionResult BillingGroupCreate(BillingGroup billingGroup)
        {
            try
            {
                ViewBag.RelationIdDropDownList = new SelectList(db.Relations, "RelationId", "RelationName");
                ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
                ViewBag.SponsorCategoryIdList = new SelectList(db.SponsorCategories, "SponsorCategoryId", "SponsorCategoryName");
                // TODO: Add insert logic here

                using (EMRSoftwareModel db = new EMRSoftwareModel())
                {
                    if (billingGroup.RelationID == "R001")
                    {
                        billingGroup.InitialDependantID = "NONE";
                    }

                    if (billingGroup.PatientID.Contains("["))
                    {
                        var holdPatID = billingGroup.PatientID.Split('[');
                        billingGroup.PatientID = holdPatID[0].Trim();
                    }


                    if (billingGroup.SponsorID.Contains("["))
                    {
                        var holdSponID = billingGroup.SponsorID.Split('[');
                        billingGroup.SponsorID = holdSponID[0].Trim();
                    }

                    db.BillingGroups.Add(billingGroup);
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
                }
                ModelState.Clear();
                return RedirectToAction("BillingGroupIndex");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                return View();
            }
        }

        // GET: BillingGroup/Edit/5
        public ActionResult BillingGroupEdit(string id)
        {
            // TODO: Add update logic here
            BillingGroup billingGrp = db.BillingGroups.Find(id);
            if (billingGrp == null)
            {
                return View("View Not Found");
            }
            else
            {
                ViewBag.RelationIdDropDownList = new SelectList(db.Relations, "RelationId", "RelationName");
                ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
                ViewBag.SponsorCategoryIdList = new SelectList(db.SponsorCategories, "SponsorCategoryId", "SponsorCategoryName");

                return View(billingGrp);
            }
        }

        // POST: BillingGroup/Edit/5
        [HttpPost]
        public ActionResult BillingGroupEdit(string id, BillingGroup billingGrp)
        {
            try
            {
                // TODO: Add update logic her
                if (billingGrp == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    if (ModelState.IsValid)
                    {

                        ViewBag.RelationIdDropDownList = new SelectList(db.Relations, "RelationId", "RelationName");
                        ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                        ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
                        ViewBag.SponsorCategoryIdList = new SelectList(db.SponsorCategories, "SponsorCategoryId", "SponsorCategoryName");

                        if (billingGrp.RelationID == "R001")
                        {
                            billingGrp.InitialDependantID = "NONE";
                        }

                        if (billingGrp.PatientID.Contains("["))
                        {
                            var holdPatID = billingGrp.PatientID.Split('[');
                            billingGrp.PatientID = holdPatID[0].Trim();
                        }

                        if (billingGrp.SponsorID.Contains("["))
                        {
                            var holdSponID = billingGrp.SponsorID.Split('[');
                            billingGrp.SponsorID = holdSponID[0].Trim();
                        }
                        db.Entry(billingGrp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("BillingGroupIndex");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: BillingGroup/Details/5
        public ActionResult BillingGroupDetails(string id)
        {
            BillingGroup billingGrp = db.BillingGroups.Find(id);

            if (billingGrp.InitialDependantID == "NONE")
            {
                var dependantsBillGrp = db.BillingGroups.Where(x => x.InitialDependantID == billingGrp.BillingGroupID).ToList();
                if (dependantsBillGrp != null)
                {
                    ViewBag.DependantBillGrp = dependantsBillGrp;
                }
            }
            if (billingGrp == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(billingGrp);
            }
        }

        // GET: BillingGroup/Delete/5
        public ActionResult BillingGroupDelete(string id)
        {
            BillingGroup billingGrp = db.BillingGroups.Find(id);
            return View(billingGrp);
        }

        // POST: BillingGroup/Delete/5
        [HttpPost]
        public ActionResult BillingGroupDelete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BillingGroup billingGrp = db.BillingGroups.Find(id);
                if(billingGrp.RelationID== "R001")
                {
                    var dependants = db.BillingGroups.Where(x => x.InitialDependantID == billingGrp.BillingGroupID).ToList();
                    if (dependants.Count() > 0)
                    {
                        ViewBag.HaveDependants = "Cannot delete Billing Group because there are/is " + dependants.Count() + "  dependant(s).Kindly delete " +
                            "dependant(s) first";
                        return View(billingGrp);
                    }
                }
                db.BillingGroups.Remove(billingGrp);
                db.SaveChanges();
                return RedirectToAction("BillingGroupIndex");

            }
            catch
            {
                return View();
            }
        }

        public JsonResult AutoCompleteSponsorId(string term)
        {
            try
            {
                //retrieve all matching folders
                var result = (from e in db.Sponsors
                              orderby e.SponsorID
                              where e.SponsorID.StartsWith(term) || e.SponsorName.Contains(term)
                              select new
                              {
                                  SponsorId = e.SponsorID,
                                  SponsorName = e.SponsorID + " [" + e.SponsorName + "]"
                              })
                          .Take(20).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var result = "";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public String FetchInsuredPatientId(string number1)
        {
            String insuredpatID = "";
            try { 
                var mylist = db.BillingGroups.Where(x => x.PatientID.Equals(number1.Trim())).
                    OrderByDescending(x => x.BillingGroupID).Take(1).ToList();

                if (!(mylist.Count == 0))
                {
                    foreach (var e in mylist)
                    {
                        insuredpatID = GetNextBillingGrpID(e.BillingGroupID);
                    }
                    Console.WriteLine("" + insuredpatID);
                }
                else
                {
                    insuredpatID = number1.Trim() + "-01";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(""+e.Message);
                
            }
            return insuredpatID;
        }

        public JsonResult GetSubSponsorList(string SponsorId)
        { /// Generate a list of SubSponsors based on a chosen SponsorId
            db.Configuration.ProxyCreationEnabled = false;
            if (SponsorId.Contains('['))
            {
                SponsorId = SponsorId.Split('[')[0].Trim();
            }
            List<SubSponsor> subsponsors = db.SubSponsors.Where(x => x.SponsorID == SponsorId).ToList();
            return Json(subsponsors,JsonRequestBehavior.AllowGet);
        }

        public string GetNextBillingGrpID(string billGroupID) // function gets next billing group ID
        {
            String temp;
            String retStr = "";
            try
            {
                var tempArr = billGroupID.Split('-');     
                temp = tempArr[1];   // Gets the string after '-' character 
                int tempInt = Convert.ToInt32(temp);
                tempInt = tempInt + 1;
                if (tempInt < 10) temp = "0" + tempInt;
                else temp = ("" + tempInt).Trim();

                retStr = tempArr[0] + "-" + temp;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retStr;
        }

        /**********************   Sponsor ******************************/

        public ActionResult SponsorIndex(string searching, int? page, string sortby)
        {
           // var sponsors = db.Sponsors.ToList();
           // return View(sponsors);
            ViewBag.SortIDParameter = string.IsNullOrEmpty(sortby) ? "Sponsor ID desc" : "";  // sorts list by asc SponsorId by default
            ViewBag.SortSponsorNameParameter = sortby == "Sponsor Name" ? "Sponsor Name desc" : "Sponsor Name"; // sorts Sponsor Name column
            ViewBag.SortInsuranceTypeParameter = sortby == "Insurance Type" ? "Insurance Type desc" : "Insurance Type"; // sorts Insurance Type column
            ViewBag.SortStatusNameParameter = sortby == "Status Name" ? "Status Name desc" : "Status Name"; // sorts Status Name column


            // var sponsors = db.Sponsors.AsQueryable();
            var sponsors = db.Sponsors.AsQueryable();
            try
            {
                if (searching != null)
                    searching = searching.Trim();

                switch (sortby)
                {
                    case "Sponsor ID desc":
                        sponsors = sponsors.OrderByDescending(x => x.SponsorID);
                        break;
                    case "Sponsor Name desc":
                        sponsors = sponsors.OrderByDescending(x => x.SponsorName);
                        break;
                    case "Sponsor Name":
                        sponsors = sponsors.OrderBy(x => x.SponsorName);
                        break;
                    case "Insurance Type desc":
                        sponsors = sponsors.OrderByDescending(x => x.InsuranceType.InsuranceTypeName);
                        break;
                    case "Insurance Type":
                        sponsors = sponsors.OrderBy(x => x.InsuranceType.InsuranceTypeName);
                        break;
                    case "Status Name":
                        sponsors = sponsors.OrderBy(x => x.Status.StatusName);
                        break;
                    case "Status Name desc":
                        sponsors = sponsors.OrderByDescending(x => x.Status.StatusName);
                        break;
                    default:
                        sponsors = sponsors.OrderBy(x => x.SponsorID);
                        break;
                }

                return View(sponsors.Where(x => x.SponsorID.Contains(searching) ||
                searching == null || x.SponsorID.StartsWith(searching) || x.SponsorName.StartsWith(searching)
                || x.SponsorName.Contains(searching)).ToList().ToPagedList(page ?? 1, 50));    // limit entries to user inputted search parameter

            }
            catch (Exception e)
            {

                return View();
            }
            
        }

        // GET: Sponsor/Create
        public ActionResult SponsorCreate(string initialdepID)
        {
           ViewBag.RegionIDDropDownList = new SelectList(db.Regions, "RegionID", "RegionName");
            ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
            ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");
           // ViewBag.SponsorCategoryIdList = new SelectList(db.SponsorCategories, "SponsorCategoryId", "SponsorCategoryName");

            return View();
        }

        // POST: SponsorCreate/Create
        [HttpPost]
        public ActionResult SponsorCreate(Sponsor sponsor)
        {
            try
            {
                ViewBag.RegionIDDropDownList = new SelectList(db.Regions, "RegionID", "RegionName");
                ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");
                // TODO: Add insert logic here

                using (EMRSoftwareModel db = new EMRSoftwareModel())
                {
                
                    db.Sponsors.Add(sponsor);
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
                }
                ModelState.Clear();
                return RedirectToAction("SponsorIndex");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                return View();
            }
        }

        // GET: Sponsor/Delete/5
        public ActionResult SponsorDelete(string id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            return View(sponsor);
        }

        // POST: Sponsor/Delete/5
        [HttpPost]
        public ActionResult SponsorDelete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Sponsor spon = db.Sponsors.Find(id);
                db.Sponsors.Remove(spon);
                db.SaveChanges();
                return RedirectToAction("SponsorIndex");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.Message);
                return View(e.InnerException.Message + " :::: " + e.Message);
            }
        }

        // GET: Sponsor/Details/5
        public ActionResult SponsorDetails(string id)
        {
            Sponsor spons = db.Sponsors.Find(id);

            if (spons == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(spons);
            }
        }


        // GET: Sponsor/Edit/5
        public ActionResult SponsorEdit(string id)
        {
            // TODO: Add update logic here
            Sponsor spon = db.Sponsors.Find(id);
            if (spon == null)
            {
                return View("View Not Found");
            }
            else
            {
                ViewBag.RegionIDDropDownList = new SelectList(db.Regions, "RegionID", "RegionName");
                ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");

                return View(spon);
            }
        }

        // POST: Sponsor/Edit/5
        [HttpPost]
        public ActionResult SponsorEdit(string id, Sponsor spon)
        {
            try
            {
                // TODO: Add update logic her
                if (spon == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    if (ModelState.IsValid)
                    {

                        ViewBag.RegionIDDropDownList = new SelectList(db.Regions, "RegionID", "RegionName");
                        ViewBag.StatusIdDropDownList = new SelectList(db.Status, "StatusId", "StatusName");
                        ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");

                        db.Entry(spon).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("SponsorIndex");
                }

            }
            catch
            {
                return View();
            }
        }

        /******************************************* Visitation *****************************************/
        public ActionResult VisitationIndex(string searching, int? page, string sortby)
        {
              ViewBag.SortIDParameter = string.IsNullOrEmpty(sortby) ? "ID desc" : "";  // sorts list by asc VisitationId by default
              ViewBag.SortPatientNameParameter = sortby == "Patient Name" ? "Patient Name desc" : "Patient Name"; // sorts Patient Name column
              ViewBag.SortPatientIdParameter = sortby == "Hosp. No" ? "Hosp. No desc" : "Hosp. No"; // sorts Hosp No column
              ViewBag.SortWorkingMonthParameter = sortby == "Working Month" ? "Working Month desc" : "Working Month"; // sorts Working Month column
              ViewBag.SortVisitDateParameter = sortby == "VisitDate" ? "VisitDate desc" : "VisitDate";   // sorts VisitDate column

                var visits = db.Visitations.AsQueryable(); 
                try
                {
                    if (searching != null)
                        searching = searching.Trim();

                    switch (sortby)
                    {
                        case "ID desc":
                            visits = visits.OrderByDescending(x => x.VisitationID);
                            break;
                        case "Patient Name desc":
                            visits = visits.OrderByDescending(x => x.VisitationName);
                            break;
                        case "Patient Name":
                            visits = visits.OrderBy(x => x.VisitationName);
                            break;
                        case "Hosp. No desc":
                            visits = visits.OrderByDescending(x => x.BillingGroup.PatientID);
                            break;
                        case "Hosp. No":
                            visits = visits.OrderBy(x => x.BillingGroup.PatientID);
                            break;
                        case "Working Month":
                            visits = visits.OrderBy(x => x.WorkingMonth.WorkingMonthName);
                            break;
                        case "Working Month desc":
                            visits = visits.OrderByDescending(x => x.WorkingMonth.WorkingMonthName);
                            break;
                        case "VisitDate":
                            visits = visits.OrderBy(x => x.VisitDate);
                            break;
                        case "VisitDate desc":
                            visits = visits.OrderByDescending(x => x.VisitDate);
                            break;
                    default:
                            visits = visits.OrderBy(x => x.VisitationID);
                            break;
                    }

                    return View(visits.Where(x => x.VisitationID.Contains(searching) ||
                    searching == null || x.PatientID.StartsWith(searching) || x.PatientID.Contains(searching)
                    || x.VisitationName.Contains(searching)).ToList().ToPagedList(page ?? 1, 50));    // limit entries to user inputted search parameter

                }
                catch (Exception e)
                {

                    return View();
                } 
            //var visits = db.Visitations.ToList();
           // return View(visits);

        }

        // GET: Visitation/Create
        public ActionResult VisitationCreate()
        { 
          //  ViewBag.VisitTypeIdList = new SelectList(db.VisitTypes, "VisitTypeID", "VisitTypeName");
            ViewBag.VisitTypeIDList = new SelectList(db.VisitTypes, "VisitTypeID", "VisitTypeName");
            ViewBag.SponsorIdList = new SelectList(db.Sponsors, "SponsorId", "SponsorName");
            ViewBag.PatientIdList = new SelectList(db.Patients, "PatientId", "PatientName");
            ViewBag.SpecialtyIdList = new SelectList(db.Specialties, "SpecialtyId", "SpecialtyName");
            ViewBag.ConsultationIdList = new SelectList(db.Consultations, "ConsultationId", "ConsultationName");
            ViewBag.AgeGroupIdList = new SelectList(db.AgeGroups, "AgeGroupId ", "AgeGroupName");
            ViewBag.DoctorIdList = new SelectList(db.Doctors,"DoctorId","DoctorName");
            ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes,"InsuranceTypeId","InsuranceTypeName");
            ViewBag.InsuranceValIdList = new SelectList(db.InsuranceVals, "InsuranceValId", "InsuranceValName");
           // ViewBag.VisitStatusIdList = new SelectList(db.VisitStatus, "VisitStatusId", "VisitStatusName");
            ViewBag.RevenueCenterIdList = new SelectList(db.RevenueCenters, "RevenueCenterId", "RevenueCenterName");
            ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
            ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");
            ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
            ViewBag.BillingGroupIdList = new SelectList(db.BillingGroups, "BillingGroupId", "BillingGroupId");
            ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");

            ViewBag.VisitationId = GetNextVisitNumber();
            //ViewBag.VisitDate = DateTime.Now;
            return View();
        }

        // POST: VisitationCreate/Create
        [HttpPost]
        public ActionResult VisitationCreate(Visitation visit)
        {
          //  ViewBag.VisitTypeIdList = new SelectList(db.VisitTypes, "VisitTypeID", "VisitTypeName");
            ViewBag.VisitTypeIDList = new SelectList(db.VisitTypes, "VisitTypeID", "VisitTypeName");
            ViewBag.SponsorIdList = new SelectList(db.Sponsors, "SponsorId", "SponsorName");
            ViewBag.PatientIdList = new SelectList(db.Patients, "PatientId", "PatientName");
            ViewBag.SpecialtyIdList = new SelectList(db.Specialties, "SpecialtyId", "SpecialtyName");
            ViewBag.ConsultationIdList = new SelectList(db.Consultations, "ConsultationId", "ConsultationName");
            ViewBag.AgeGroupIdList = new SelectList(db.AgeGroups, "AgeGroupId ", "AgeGroupName");
            ViewBag.DoctorIdList = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");
            ViewBag.InsuranceValIdList = new SelectList(db.InsuranceVals, "InsuranceValId", "InsuranceValName");
            // ViewBag.VisitStatusIdList = new SelectList(db.VisitStatus, "VisitStatusId", "VisitStatusName");
            ViewBag.RevenueCenterIdList = new SelectList(db.RevenueCenters, "RevenueCenterId", "RevenueCenterName");
            ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
            ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");
            ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
            ViewBag.BillingGroupIdList = new SelectList(db.BillingGroups, "BillingGroupId", "BillingGroupId");
            ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");


            try
            {
                if (visit != null)
                { string month = "", year = "", day = "";
                    month = DateTime.Now.Month.ToString();
                    if (DateTime.Now.Month < 10) month = "0" + month;
                    year = DateTime.Now.Year.ToString();
                    day = DateTime.Now.Day.ToString();
                    if (DateTime.Now.Day < 10) day = "0" + day;
                    visit.VisitDate = DateTime.Now;
                    var bID = visit.BillingGroupID.Split('[')[0].Trim();
                    //visit.Age = (DateTime.Now.Year-visit.Patient.Dob.Year).ToString();
                    //var billgrp = db.BillingGroups.Where(x => x.BillingGroupID == bID.ToString()).ToList();
                    var billgrp = db.BillingGroups.Where(x => x.BillingGroupID == bID.ToString()).ToList();
                    foreach (var x in billgrp)
                    {
                        visit.InsuranceTypeID = x.Sponsor.InsuranceTypeID;
                        visit.InsuranceValID = x.Sponsor.InsuranceType.InsuranceValID;
                        visit.PatientID = x.PatientID;
                        visit.BillingGroupID = x.BillingGroupID;
                    }
                    visit.WorkingDayID = "Day" + year + month + day;
                    visit.WorkingMonthID = "MTH" + year + month;
                    visit.WorkingYearID = "YRS" + year;
                    visit.VisitStatusID = "VS001";

                    if (Int32.Parse(visit.Age) <= 18)
                    {
                        visit.AgeGroupID  = "AG01";
                    }
                    else {
                        visit.AgeGroupID  = "AG02";
                    }
                }
                using (EMRSoftwareModel db = new EMRSoftwareModel())
                {

                    db.Visitations.Add(visit);
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
                }
                ModelState.Clear();
                return RedirectToAction("VisitationIndex");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.InnerException.Message);
                return View();
            }
        }


        // GET: Visitation/Edit/5
        public ActionResult VisitationEdit(string id)
        {
            // TODO: Add update logic here
            Visitation visit = db.Visitations.Find(id);
            if (visit == null)
            {
                return View("View Not Found");
            }
            else
            {
                ViewBag.VisitTypeIdList = new SelectList(db.VisitTypes, "VisitTypeID", "VisitTypeName");
                ViewBag.SponsorIdList = new SelectList(db.Sponsors, "SponsorId", "SponsorName");
                ViewBag.PatientIdList = new SelectList(db.Patients, "PatientId", "PatientName");
                ViewBag.SpecialtyIdList = new SelectList(db.Specialties, "SpecialtyId", "SpecialtyName");
                ViewBag.ConsultationIdList = new SelectList(db.Consultations, "ConsultationId", "ConsultationName");
                ViewBag.DoctorIdList = new SelectList(db.Doctors, "DoctorId", "DoctorName");
                ViewBag.AgeGroupIdList = new SelectList(db.AgeGroups, "AgeGroupId ", "AgeGroupName");
                ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");
                ViewBag.InsuranceValIdList = new SelectList(db.InsuranceVals, "InsuranceValId", "InsuranceValName");
                // ViewBag.VisitStatusIdList = new SelectList(db.VisitStatus, "VisitStatusId", "VisitStatusName");
                ViewBag.RevenueCenterIdList = new SelectList(db.RevenueCenters, "RevenueCenterId", "RevenueCenterName");
                ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
                ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");
                ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
                ViewBag.BillingGroupIdList = new SelectList(db.BillingGroups, "BillingGroupId", "BillingGroupId");
                ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
                ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
                ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
                ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");
                ViewBag.VisitStatusIdList = new SelectList(db.VisitStatus, "VisitStatusId", "VisitStatusName");
                return View(visit);
            }
        }

        // POST: Visitation/Edit/5
        [HttpPost]
        public ActionResult VisitationEdit(string id, Visitation visit)
        {
            try
            {
               
                ViewBag.VisitTypeIdList = new SelectList(db.VisitTypes, "VisitTypeId", "VisitTypeName");
               // ViewBag.SponsorIdList = new SelectList(db.Sponsors, "SponsorId", "SponsorName");
                ViewBag.PatientIdList = new SelectList(db.Patients, "PatientId", "PatientName");
                ViewBag.SpecialtyIdList = new SelectList(db.Specialties, "SpecialtyId", "SpecialtyName");
                ViewBag.ConsultationIdList = new SelectList(db.Consultations, "ConsultationId", "ConsultationName");
                ViewBag.DoctorIdList = new SelectList(db.Doctors, "DoctorId", "DoctorName");
                ViewBag.AgeGroupIdList = new SelectList(db.AgeGroups, "AgeGroupId ", "AgeGroupName");
                ViewBag.InsuranceTypeIdList = new SelectList(db.InsuranceTypes, "InsuranceTypeId", "InsuranceTypeName");
                ViewBag.InsuranceValIdList = new SelectList(db.InsuranceVals, "InsuranceValId", "InsuranceValName");
                ViewBag.VisitStatusIdList = new SelectList(db.VisitStatus, "VisitStatusId", "VisitStatusName");
                ViewBag.RevenueCenterIdList = new SelectList(db.RevenueCenters, "RevenueCenterId", "RevenueCenterName");
                //ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
                //ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");
                //ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
                ViewBag.BillingGroupIdList = new SelectList(db.BillingGroups, "BillingGroupId", "BillingGroupName");
                //ViewBag.SubSponsorIdList = new SelectList(db.SubSponsors, "SubSponsorId", "SubSponsorName");
                ViewBag.WorkingYearIdList = new SelectList(db.WorkingYears, "WorkingYearId", "WorkingYearName");
                ViewBag.WorkingMonthIdList = new SelectList(db.WorkingMonths, "WorkingMonthId", "WorkingMonthName");
                ViewBag.WorkingDayIdList = new SelectList(db.WorkingDays, "WorkingDayId", "WorkingDayName");


                // TODO: Add update logic her
                if (visit == null)
                {
                    return View("View Not Found");
                }
                else
                {
                    var visitgrp = db.Visitations.Find(id);
                    var x = visit;
                    var old_billgrpid = visitgrp.BillingGroupID;
                    var new_billgrpid = x.BillingGroupID;
                    if (visit != null)
                    {
                        Console.WriteLine("Age >>> "+ x.Age);
                        Console.WriteLine("AgeGroupId  >>> " + x.AgeGroupID );
                        Console.WriteLine("New BillingGroupId >>> " + x.BillingGroupID);
                        Console.WriteLine("old BillingGroupId >>> " + visitgrp.BillingGroupID);
                        Console.WriteLine("PatientId >>> " + x.PatientID);
                        Console.WriteLine("SponsorId >>> " + x.SponsorID);
                        Console.WriteLine("SubSponsorId >>> " + x.SubSponsorID);
                        if (old_billgrpid != new_billgrpid) {
                            if (x.BillingGroupID.Contains("["))
                               {
                                x.BillingGroupID = x.BillingGroupID.Split('[')[0].Trim();
                                x.PatientID = x.BillingGroupID.Split('-')[0].Trim();
                               }
                            var billgrplist = db.BillingGroups.Where(k => k.BillingGroupID == x.BillingGroupID).ToList();
                            foreach(var bill in billgrplist)
                            {
                                x.SponsorID = bill.SponsorID;
                                x.SubSponsorID = bill.SubSponsorID;
                            }                            
                        }
                        Console.WriteLine("BillingGroupId >>> " + x.BillingGroupID);
                        Console.WriteLine("PatientId >>> " + x.PatientID);
                        Console.WriteLine("SponsorId >>> " + x.SponsorID);
                        Console.WriteLine("SubSponsorId >>> " + x.SubSponsorID);
                        Console.WriteLine("ConsultationId >>> " + x.ConsultationID);
                        Console.WriteLine("CopayAmt >>> " + x.copayAmt);
                        Console.WriteLine("Cost >>> " + x.Cost);
                        Console.WriteLine("InsuranceTypeId >>> " + x.InsuranceTypeID);
                        Console.WriteLine("DoctorId >>> " + x.DoctorID);
                        Console.WriteLine("InsuranceValId >>> " + x.InsuranceValID);
                        Console.WriteLine("RevenueCenterId >>> " + x.RevenueCenterID);
                        Console.WriteLine("SpecialtyId >>> " + x.SpecialtyID);
                        Console.WriteLine("VisitationId >>> " + x.VisitationID);
                        Console.WriteLine("VisitationName >>> " + x.VisitationName);
                        Console.WriteLine("VisitDate >>> " + x.VisitDate);
                        Console.WriteLine("VisitStatusId >>> " + x.VisitStatusID);
                        Console.WriteLine("VisitTypeId >>> " + x.VisitTypeID);                        
                    }
                    if (ModelState.IsValid)
                    {
                        var local = db.Set<Visitation>().Local.FirstOrDefault(f => f.VisitationID == visit.VisitationID);
                        if (local != null) 
                        {
                            db.Entry(local).State = EntityState.Detached; //this code prevents attaching duplicate primary keys which throws an error
                        }
                        db.Entry(visit).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("VisitationIndex");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Visit Edit >>>>>> " + e.Message);
                return View();
            }
        }


        // GET: Visitation/Details/5
        public ActionResult VisitationDetails(string id)
        {
            Visitation visit = db.Visitations.Find(id);

            if (visit == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(visit);
            }
        }


        public JsonResult AutoCompleteBillingGroupId(string term)
        {
            try
            {
                if (term.Contains('['))
                {
                    term = term.Split('[')[0].Trim().ToString();
                }
                //retrieve all matching folders
                var result = (from e in db.BillingGroups
                              orderby e.BillingGroupID
                              where e.BillingGroupID.StartsWith(term) || e.BillingGroupID.Contains(term) || e.Patient.PatientName.Contains(term)
                              select new
                              {
                                  BillGroupID = e.BillingGroupID,
                                  BillGroupName = e.BillingGroupID +" [" + e.Patient.PatientName + " ]",
                                  PatientAge = (DateTime.Now.Year - e.Patient.dob.Year).ToString(),
                                  PatientName = e.Patient.PatientName,
                                  SponsorID = e.SponsorID,
                                  SubSponsorID = e.SubSponsorID
                              })
                          .Take(20).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var result = "";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetConsultationList(string SpecialtyId)
        { /// Generate a list of SubSponsors based on a chosen SponsorId
            db.Configuration.ProxyCreationEnabled = false;
            List<Consultation> consultations = db.Consultations.Where(x => x.SpecialtyID == SpecialtyId && x.StatusID== "ST002").ToList();


            return Json(consultations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDoctorList(string SpecialtyId)
        { /// Generate a list of SubSponsors based on a chosen SponsorId
            db.Configuration.ProxyCreationEnabled = false;
            List<Doctor> doctors = db.Doctors.Where(x => x.SpecialtyID == SpecialtyId).ToList();
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }

        public string GetVisitCost(string vtypeid,string consultid,string billgrpID)
        { /// Get the Cost of a visit
           // db.Configuration.ProxyCreationEnabled = false;
            if(billgrpID.Contains("["))
                billgrpID = billgrpID.Split('[')[0].Trim();
            var totalCost = 0.00;
            bool isNum = false, isNum1 = false, isNum2 = false,isNum3=false;
            string markup = "",regcost="",consultcost="",reviewcost="";
            var billgrplist = db.BillingGroups.Where(x => x.BillingGroupID == billgrpID).Select(o => new {
                o.Sponsor.InsuranceType.InsuranceVal.Visitation
            });
            foreach(var x in billgrplist) {
                markup = x.Visitation;
            }

            var  conslist= db.Consultations.Where(x => x.ConsultationID == consultid).Select(o=>new {
                o.RegistrationCost
            }); // get registration cost
            foreach (var x in conslist)
            {
                regcost = x.RegistrationCost;
            }

            var consultcostlist = db.Consultations.Where(x => x.ConsultationID == consultid).Select(o => new {
              o.ConsultationCost
            }); // get consultation cost
            foreach (var x in consultcostlist)
            {
                consultcost = x.ConsultationCost;
            }

            var reviewcostlist = db.Consultations.Where(x => x.ConsultationID == consultid).Select(o => new {
                o.ReviewCost
            });   // get review cost
            foreach (var x in reviewcostlist)
            {
                reviewcost = x.ReviewCost;
            }

            isNum = float.TryParse(regcost, out float result);
            isNum1 = float.TryParse(consultcost, out float result2);
            isNum2 = float.TryParse(reviewcost, out float result3);
            isNum3 = float.TryParse(markup,out float result4);
            if (vtypeid == "VT001") {
                if(isNum && isNum1)
                {
                    totalCost = float.Parse(regcost) + float.Parse(consultcost);
                }
                    }
            else if(vtypeid== "VT002")
            {
                if (isNum1)
                {
                    totalCost = float.Parse(consultcost);
                }
            }
            else
            {
                if (isNum2) totalCost = float.Parse(reviewcost);
            }

            if (isNum3)
            {
                totalCost = (totalCost * float.Parse(markup))/100;
            }

            return totalCost.ToString(); 
        }

        public String GetNextVisitNumber()
        {
            string visitID = "";
            string old_wrkingdayid = "", month="",day="";
            month = DateTime.Now.Month.ToString();
            if (DateTime.Now.Month<10) month = "0"+ DateTime.Now.Month.ToString();

            day = DateTime.Now.Day.ToString();
            if (DateTime.Now.Day < 10) day = "0" + DateTime.Now.Day.ToString();

            string current_wrkingdayid = "Day" + DateTime.Now.Year + month + day;

            var visitations = db.Visitations.OrderByDescending(x => x.VisitationID).Take(1).ToList();
            if (!(visitations.Count == 0))
            {
                foreach (var visit in visitations)
                {
                    visitID = visit.VisitationID;
                    old_wrkingdayid = visit.WorkingDayID;
                }

                if (old_wrkingdayid == current_wrkingdayid)
                {
                    var hold_index = visitID.Substring(8);
                    if (Int32.TryParse(hold_index, out int result))
                    {
                        var index = Int32.Parse(hold_index);
                        index = index + 1;
                        hold_index = index.ToString();
                        switch (hold_index.Length)
                        {
                            case 1:
                                hold_index = "00" + hold_index;
                                break;
                            case 2:
                                hold_index = "0" + hold_index;
                                break;
                            case 3:
                                break;
                        }
                    }
                    visitID = "V1" + DateTime.Now.Year.ToString().Substring(2) + month + day + hold_index;
                }
                else
                {
                    visitID = "V1" + DateTime.Now.Year.ToString().Substring(2) + month + day + "001";
                }

            }
            else
            {
               /* var month ="" ;
                var day = "";
                if (DateTime.Now.Month < 10) month = "0" + DateTime.Now.Month;
                else month = DateTime.Now.Month.ToString();
                if (DateTime.Now.Day < 10) day = "0" + DateTime.Now.Day;
                else day = DateTime.Now.Day.ToString(); */
                visitID = "V1" + DateTime.Now.Year.ToString().Substring(2) + month+ day + "001";
            }
            return visitID;
        }


        // GET: Visitation/Delete/5
        public ActionResult VisitationDelete(string id)
        {
            Visitation newvisit = db.Visitations.Find(id);
            return View(newvisit);
        }

        // POST: Visitation/Delete/5
        [HttpPost]
        public ActionResult VisitationDelete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Visitation newvisit = db.Visitations.Find(id);
                db.Visitations.Remove(newvisit);
                db.SaveChanges();
                return RedirectToAction("VisitationIndex");

            }
            catch
            {
                return View();
            }
        }

    }
}
