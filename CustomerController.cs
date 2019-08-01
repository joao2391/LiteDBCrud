using System;
using System.Linq;
using Exemplo_LiteDB.Common;
using Exemplo_LiteDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Exemplo_LiteDB
{
    public class CustomerController : Controller
    {
        private readonly IOptions<MyConfig> _config;
        private readonly LiteDbContext _context;

        public CustomerController(IOptions<MyConfig> config)
        {
             _config = config;
            _context = new LiteDbContext(config);
            
        }

        // GET: Customer
        public ActionResult Index()
        {   
            return View(_context.GetAll());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        { 
           return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                
                _context.Insert(customer);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var erro = ex.Message;
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {               
                _context.Update(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = _context.GetAll().Where(x => x.Id == id).SingleOrDefault();

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}