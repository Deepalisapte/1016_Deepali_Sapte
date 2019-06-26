﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Data;
namespace student.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetAllStudents();
            return View("Home", dt);
        }

        public ActionResult Insert()
        {
            return View("Create");
        }

        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int status = model.InsertStudent(name, gender, age);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int StudentID)
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetStudentByID(StudentID);
            return View("Edit", dt);
        }

        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int id = Convert.ToInt32(frm["hdnID"]);
                int status = model.UpdateStudent(id, name, gender, age);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int StudentID)
        {
            CRUDModel model = new CRUDModel();
            model.DeleteStudent(StudentID);
            return RedirectToAction("Index");
        }
    }
}  


    
