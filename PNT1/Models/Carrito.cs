using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class Carrito    
    {
        private readonly Context.PNT1DatabaseContext _DbContext;
        public string CarritoId { get; set; }
        public List<CarritoItems> carritoItems { get; set; }

        public Carrito(Context.PNT1DatabaseContext dbContext)
        {
            _DbContext = dbContext;
        }

        public static Carrito getCarrito(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<Context.PNT1DatabaseContext>();
            string carritoId = session.GetString("CarritoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarritoId", carritoId);

            return new Carrito(context) { CarritoId = carritoId };
        }

        public void AgregarAlCarrito(Item item, int cantidad)
        {
            var carritoItem = _DbContext.CarritoItems.SingleOrDefault(s => s.Item.Id == item.Id && s.CarritoId == CarritoId);

            if (carritoItem == null)
            {
                carritoItem = new CarritoItems
                {
                    CarritoId = CarritoId,
                    Item = item,
                    Cantidad = cantidad
                };

                _DbContext.CarritoItems.Add(carritoItem);
            }

            _DbContext.SaveChanges();
        }

        public int BorrarDelCarrito(Item item)
        {
            var carritoItem = _DbContext.CarritoItems.SingleOrDefault(s => s.Item.Id == item.Id && s.CarritoId == CarritoId);

            var cantidadAux = 0;

            if (carritoItem != null)
            {
                if(carritoItem.Cantidad > 1)
                {
                    carritoItem.Cantidad--;
                    cantidadAux = carritoItem.Cantidad;
                }
                else
                {
                    _DbContext.CarritoItems.Remove(carritoItem);
                }

            }
            _DbContext.SaveChanges();

            return cantidadAux;
        }

        public List<CarritoItems> GetCarritoItems()
        {
            return carritoItems ?? (carritoItems = _DbContext.CarritoItems.Where(c => c.CarritoId == CarritoId).Include(s => s.Item).ToList());
        }

        public void LimpiarCarrito()
        {
            var carritoItems = _DbContext.CarritoItems.Where(c => c.CarritoId == CarritoId);

            _DbContext.CarritoItems.RemoveRange(carritoItems);
            _DbContext.SaveChanges();
        }

        public double GetTotalCarrito()
        {
            var total = _DbContext.CarritoItems.Where(c => c.CarritoId == CarritoId).Select(c => c.Item.Valor * c.Cantidad).Sum();

            return total;
        }

    }
}
