using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60331_1_Volodko.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SelectList Colors = new SelectList(
                Enum.GetValues(typeof(System.Drawing.KnownColor)));

            ViewBag.Colors = Colors;
            ViewBag.Caption = Request.QueryString["Colors"] ?? "Лабораторная работа №2";

            return View();
        }
    }
}