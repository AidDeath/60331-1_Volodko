using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60331_1_Volodko.DAL;

namespace _60331_1_Volodko.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository<Car> repository;

        public AdminController(IRepository<Car> repo)
        {
            repository = repo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Car());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    car.Image = new byte[count];
                    imageUpload.InputStream.Read(car.Image, 0, (int)count);
                    car.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(car);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(car);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Car car, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    car.Image = new byte[count];
                    imageUpload.InputStream.Read(car.Image, 0, (int)count);
                    car.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(car);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(car);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
