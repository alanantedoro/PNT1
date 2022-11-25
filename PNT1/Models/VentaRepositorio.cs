using PNT1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly PNT1DatabaseContext _DbContext;
        private readonly Carrito _carrito;

        public VentaRepositorio(PNT1DatabaseContext DbContext, Carrito carrito)
        {
            _DbContext = DbContext;
            _carrito = carrito;
        }
        public void CrearVenta(Venta venta)
        {
            venta.Fecha = DateTime.Now;
            venta.VentaTotal = _carrito.GetTotalCarrito();

            _DbContext.Venta.Add(venta);
            _DbContext.SaveChanges();

            var carritoItems = _carrito.GetCarritoItems();

            foreach( var carritoItem in carritoItems)
            {
                var ventaDetalle = new VentaDetalle
                {
                    Valor = carritoItem.Item.Valor,
                    ItemId = carritoItem.Item.Id,
                    VentaId = venta.VentaId
                };

                _DbContext.VentaDetalle.Add(ventaDetalle);
            }
            _DbContext.SaveChanges();
        }
    }
}
