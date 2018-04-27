using _60331_1_Volodko.DAL;
using _60331_1_Volodko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60331_1_Volodko.Controllers
{
    public class CartController : Controller
    {
        IRepository<Car> repository;

        public CartController(IRepository<Car> repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
                GetCart().AddItem(item);
            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}