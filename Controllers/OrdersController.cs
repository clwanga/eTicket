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
        private readonly IOrdersService _ordersService;

        //constructor
        public OrdersController(IMoviesService service, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _service = service;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = string.Empty;
            var allOrders = await _ordersService.GetOrdersByIdAsync(userId);

            return View(allOrders);

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

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var userId = string.Empty;
            var emailAddress = string.Empty;

            await _ordersService.StoreOrderAsync(items, userId, emailAddress); //store
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");


        }
    }
}
