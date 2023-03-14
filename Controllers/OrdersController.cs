using eTicket.Cart;
using eTicket.Data.Services;
using eTicket.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _service;
        private readonly ShoppingCart _shoppingCart;

        //constructor
        public OrdersController(IMoviesService service, ShoppingCart shoppingCart)
        {
            _service = service;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems(); //get a list of all shopping cart items

            _shoppingCart.ShoppingCartItems = items;

            return base.View(new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            });
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var movieItem = await _service.GetMoviesByIdAsync(id);

            if (movieItem != null)
            {
                _shoppingCart.AddItem(movieItem);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movieItem = await _service.GetMoviesByIdAsync(id);

            if (movieItem != null)
            {
                _shoppingCart.RemoveItemFromCart(movieItem);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
