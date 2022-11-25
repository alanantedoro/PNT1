using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1.Models;
using PNT1.ViewModels;

namespace PNT1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemRepositorio _itemRepositorio;

        public ItemsController(IItemRepositorio itemRepositorio)
        {
            _itemRepositorio = itemRepositorio;
        }

        // GET: Items/List
        public IActionResult List()
        {
            var itemListViewModel = new ItemListViewModel();
            itemListViewModel.Items = _itemRepositorio.GetAllItems; 

            return View(itemListViewModel);
        }

        public IActionResult Details(int id)
        {
            var item = _itemRepositorio.GetItemById(id);
            if(item == null)
            {
                return NotFound();
            } else
            {
                return View(item);
            }
        }
    }
}
