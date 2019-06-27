using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BOL;

namespace MVC_Crud.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password,string returnURL)
        {
            if(AccountManager.validate(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(returnURL ?? Url.Action("Msg", "Home"));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(int sid, string name, string password, string returnURL)
        {
            if(AccountManager.register(sid, name, password))
            {
                return Redirect(returnURL ?? Url.Action("test", "Account"));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int sid, string name, string password, string returnURL)
        {
            if(AccountManager.update(sid, name, password))
            {
                return Redirect(returnURL ?? Url.Action("UpdateTest", "Account"));
            }
            return View();
        }

        public ActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEmployee(Employee e)
        {
            if (AccountManager.registerEmployee(e))
            {
                return Redirect(Url.Action("UpdateEmployee", "Account"));
            }
            return View();
        }

        public ActionResult DisplayStudent()
        {
            var model = AccountManager.GetStudents();
            //this.ViewData["students"] = slist;
            return View(model);
        }
    }
}