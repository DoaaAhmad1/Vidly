using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models ;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private MyContext _context;

        public CustomerController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        // GET: Customer

        public ActionResult GetCustomers()
        {

            #region WithoutEF
            //var customers = new List<Customer>
            //{
            //    new Customer { Name="Ali" , Id=1 },
            //    new Customer { Name="Nader" , Id=2}
            //};
            //var RandomViewModel = new RandomViewModel()
            //{

            //    customers = customers
            //};
            //return View(RandomViewModel);
            #endregion

            #region QueryObjects

            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customers);

            #endregion



        }

        public ActionResult ShowCustomerById(int id)
        {

            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

    }
}