using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PNT1.Models;

namespace PNT1.Controllers
{
    [Authorize]
    public class VentaController : Controller
    {
        
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly Carrito _carrito;

        public VentaController(IVentaRepositorio ventaRepositorio, Carrito carrito)
        {
            _ventaRepositorio = ventaRepositorio;
            _carrito = carrito;

        }

        // Get
        public IActionResult Checkout()
        {
            return View();
        }

        // Post
        [HttpPost]
        public IActionResult Checkout(Venta venta)
        {
            _carrito.carritoItems = _carrito.GetCarritoItems();

            if(_carrito.carritoItems.Count == 0)
            {
                ModelState.AddModelError("","El carrito esta vacio");   
            }

            if (ModelState.IsValid)
            {
                _ventaRepositorio.CrearVenta(venta);
                _carrito.LimpiarCarrito();

                return RedirectToAction("CheckoutCompleto");
            }

            return View(venta);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.MensajeCheckout = "Gracias por tu compra!";

            return View();
        }
    }
}
