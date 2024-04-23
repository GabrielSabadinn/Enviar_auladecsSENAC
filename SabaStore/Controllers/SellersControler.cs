using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabaStore.Data;
using SabaStore.Models;

namespace SabaStore.Controllers
{
    public class SellersControler : Controller
    {
        private readonly SabaStoreContext _context;

        public SellersControler(SabaStoreContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var sellers = _context.Seller.Include("Departament").ToList();
            return View();
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public IActionResult Create(Seller seller)
        {
            if (seller == null)
            {
                return NotFound();
            }
            seller.DepartamentId = _context.Departament.FirstOrDefault().Id;

            _context.Add(seller); 
            
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}