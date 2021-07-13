using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoService.Models;
using VideoService.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoService.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public IActionResult Details (int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Content("NOT FOUND");
                //return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}