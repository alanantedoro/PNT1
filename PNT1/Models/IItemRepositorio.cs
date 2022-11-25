using PNT1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public interface IItemRepositorio
    {
        IEnumerable<Item> GetAllItems { get; }
        Item GetItemById(int itemId);
    }
}