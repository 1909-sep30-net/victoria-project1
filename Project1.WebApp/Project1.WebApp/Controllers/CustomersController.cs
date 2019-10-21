using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BusinessLogic;
using Project1.DataAccess;
using Project1.DataAccess.Entities;
using Project1.DataAccess.Interfaces;
using Project1.DataAccess.Repos;
using Project1.WebApp.Models;

namespace Project1.WebApp.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ICustRepo _repository;

        public CustomersController(ICustRepo repository)
        {
            _repository = repository;
        }

        
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customer = _repository.GetAllCustomers();

            var viewModel = customer.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            });

            return View(viewModel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        { 

            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                var newCust = new BusinessLogic.Customer
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                _repository.AddNewCustomer(newCust);

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View(viewModel);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(CustomerViewModel customer)
        {

            try
            {

                List<Customer> cust = _repository.GetCustomerByFirstName(customer.FirstName);

                var viewModel = cust.Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName
                });

                // _repository.GetCustomerByFirstName(viewModel);

                return View("Results", viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            };
            //List<Customer> cust = _repository.GetCustomerByFirstName(search);

           
            //ViewData["SearchName"] = search;


            //return View(viewModel);
        }

        public ActionResult PlaceOrder(int id)
        {
            List<Store> stores = _repository.GetAllStores();

            OrderViewModel orderViewModel = new OrderViewModel
            {
                CustomerId = id,

                AllStores = stores.Select(s => new StoreViewModel

                {
                    StoreId = s.StoreId,
                    City = s.City
                }).ToList()

            };
            return View(orderViewModel);
        }

        //public ActionResult PlaceOrder(OrderViewModel orderViewModel)
        //{

        //    return View();
        //}


    }
}