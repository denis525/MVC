using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSRtri.Models;

namespace DSRtri.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Registration_1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration_1(Registracija reg)
        {
            Registracija user = new Registracija
            {
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                DateOfBirth = reg.DateOfBirth,
                Age = reg.Age,
                Emso = reg.Emso
            };

            if (ModelState.IsValid)
            {
                TempData["UserData"] = user;
                return RedirectToAction("Registration_2");
            }
            else
            {
                return View(reg);
            }
        }

        [HttpGet]
        public ActionResult Registration_2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration_2(Registracija reg)
        {
            Registracija user = (Registracija)TempData["UserData"];
            user.Address = reg.Address;
            user.PostArea = reg.PostArea;
            user.PostalCode = reg.PostalCode;
            user.Country = reg.Country;

            TempData["UserData"] = user;

            if (ModelState.IsValid && TempData["UserData"] != null)
            {
                return RedirectToAction("Registration_3");
            }
            else
            {
                return View(reg);
            }
        }

        [HttpGet]
        public ActionResult Registration_3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration_3(Registracija reg)
        {
            Registracija user = (Registracija)TempData["UserData"];
            user.Email = reg.Email;
            user.Password = reg.Password;     
            user.ConfirmedPassword = reg.ConfirmedPassword;

            TempData["UserData"] = user;

            if (ModelState.IsValid && TempData["UserData"] != null)
            {
                return RedirectToAction("Registration_4");
            }
            else
            {
                return View(reg);
            }
        }

        [HttpGet]
        public ActionResult Registration_4()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration_4(Registracija reg)
        {
            Registracija user = (Registracija)TempData["UserData"];

            TempData["UserData"] = user;

            if (ModelState.IsValid && TempData["UserData"] != null)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return View(reg);
            }
        }
    }
}