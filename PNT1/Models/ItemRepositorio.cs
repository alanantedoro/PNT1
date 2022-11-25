using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models.Models
{
    public class ItemRepositorio : IItemRepositorio
    {
        private readonly Context.PNT1DatabaseContext _DbContext;

        public ItemRepositorio(Context.PNT1DatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<Item> GetAllItems => _DbContext.Item.Include(c => c);

        public Item GetItemById(int itemId)
        {
            return _DbContext.Item.FirstOrDefault(c => c.Id == itemId);
        }
    }
}