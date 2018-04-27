using _60331_1_Volodko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _60331_1_Volodko.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;

        public MenuController()
        {
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог", Controller="Car", Action="List", Active=string.Empty},
                new MenuItem{Name = "Администрирование",Controller = "Admin",  Action = "Index", Active = string.Empty}
            };
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            var item = items.Where(m => m.Controller == c);
            if (item.Count()!=0)
            {
                item.First().Active = "active";
            }
            //items.First(m => m.Controller == c).Active = "active";
            return PartialView(items);
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Basket()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            return PartialView();
        }
        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}