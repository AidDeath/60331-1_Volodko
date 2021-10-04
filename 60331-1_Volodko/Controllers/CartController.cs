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
        IRepository<Sweet> repository;

        public CartController(IRepository<Sweet> repo)
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
        public ActionResult Index(Cart cart, string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(cart);
        }

        [Authorize]
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(Cart cart,int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
            {
                cart.AddItem(item);
                TempData["addedСar"] = item.SweetsName + " " + item.Manufacturer.ManufacturerName;
            }

            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(Cart cart, string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(cart);
        }

        [Authorize]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Sweet sweet = repository.Get(id);
            if (sweet != null)
            {
                TempData["removedСar"] = sweet.SweetsName +" "+ sweet.Manufacturer.ManufacturerName;
                TempData["returnUrl"] = returnUrl;
                cart.RemoveItem(sweet);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}