using Microsoft.AspNetCore.Mvc;
using PNT1.Models;
using PNT1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Controllers
{
    public class CarritoController : Controller

    {
        private readonly IItemRepositorio _itemRepositorio;
        private readonly Carrito _carrito;


        public CarritoController(IItemRepositorio itemRepositorio, Carrito carrito)
        {
            _itemRepositorio = itemRepositorio;
            _carrito = carrito;

        }
        public ViewResult Index()
        {
            _carrito.carritoItems = _carrito.GetCarritoItems();

            var carritoViewModel = new CarritoViewModel
            {
                Carrito = _carrito,
                CarritoTotal = _carrito.GetTotalCarrito()
            };

            return View(carritoViewModel);
        }

        public RedirectToActionResult AgregarAlCarrito(int itemId)
        {
            var itemSeleccionado = _itemRepositorio.GetAllItems.FirstOrDefault(c => c.Id == itemId);

            if(itemSeleccionado != null)
            {
                _carrito.AgregarAlCarrito(itemSeleccionado, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult BorrarDelCarrito(int itemId)
        {
            var itemSeleccionado = _itemRepositorio.GetAllItems.FirstOrDefault(c => c.Id == itemId);

            if (itemSeleccionado != null)
            {
                _carrito.BorrarDelCarrito(itemSeleccionado);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            return View();
        }


    }
}
