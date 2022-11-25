using Microsoft.AspNetCore.Mvc;
using PNT1.Models;
using PNT1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Components
{
    public class CarritoSummary : ViewComponent
    {
        private readonly Carrito _carrito;

        public CarritoSummary(Carrito carrito)
        {
            _carrito = carrito;
        }

        public IViewComponentResult Invoke()
        {
            _carrito.carritoItems = _carrito.GetCarritoItems();

            var carritoViewModel = new CarritoViewModel
            {
                Carrito = _carrito,
                CarritoTotal = _carrito.GetTotalCarrito()
            };

            return View(carritoViewModel);

        }
    }
}
