using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _60331_1_Volodko.DAL;
using _60331_1_Volodko.Models;

namespace _60331_1_Volodko.Controllers
{
    public class SweetController : Controller
    {
        IRepository<Sweet> repository;
        int pageSize = 3;

        public SweetController(IRepository<Sweet> repo)
        {
            repository = repo;
        }

        // GET: Car
        public ActionResult List(string group, int page=1)
        {
            var lst = repository.GetAll().Where(d => group == null
                    || d.Category.CategoryName.Equals(group))
            .OrderBy(d => d.Category.CategoryName);
            var model = PageListViewModel<Sweet>.CreatePage(lst, page,pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }

            return View(model);
        }
        public PartialViewResult Side()
        {
            var groups = repository
            .GetAll()
            .Select(d => d.Category.CategoryName)
             .Distinct();
            return PartialView(groups);
        }

        public async Task<FileResult> GetImage(int id)
        {
            var car = await repository.GetAsync(id);
            if (car != null)
            {
                return new FileContentResult(car.Image, car.MimeType);
            }
            else return null;
        }
    }
}