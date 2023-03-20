using eTicket.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        public readonly ShoppingCart _shoppingCart; //injecting the class

        public ShoppingCartSummary(ShoppingCart shoppingCart) //constructor initialization
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
