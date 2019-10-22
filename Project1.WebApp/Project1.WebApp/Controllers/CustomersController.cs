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

        public ActionResult PlaceOrder2(OrderViewModel orderViewModel)
        {
            Dictionary<Product, int> dic2 = _repository.GetInventoryByStoreId(orderViewModel.StoreId);

            Order2ViewModel o2 = new Order2ViewModel
            {
                CustomerId = orderViewModel.CustomerId,
                StoreId = orderViewModel.StoreId,
                
                Inventory = dic2.Select(d => new ProductViewModel
                {
                    Name = d.Key.Name,
                    Price = d.Key.Price,
                    ProductId = d.Key.ProductId,
                    ProductQuant = 0,
                    MaxQuant = d.Value,
                    InventoryId = d.Key.InventoryId,
                
                }).ToList()
            };
            return View(o2);
        }

        public ActionResult PlaceOrder3(Order2ViewModel order2)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();


            Order order = new Order
            {
                CustomerId = order2.CustomerId,
                StoreId = order2.StoreId,
                DateOfOrder = DateTime.Now,
                cart = new Dictionary<Product, int>()

            };
            foreach (var item in order2.Inventory)
                {
                    if (item.ProductQuant != 0)
                    {
                    Product product = new Product
                    {
                        ProductId = item.ProductId,
                        Name = item.Name,
                        Price = item.Price
                    };

                    //orderDetails.Add(new OrderDetails
                    //{ 
                    //    OrderDeatailId = 0,
                    //    ProductId = item.ProductId,
                    //    ProductQuant = item.ProductQuant,    
                    //})

                    BusinessLogic.Inventory inv = new BusinessLogic.Inventory
                    {
                        InventoryId = item.InventoryId,
                        StoreId = order2.StoreId,
                        ProductId = item.ProductId,
                        Quantity = item.MaxQuant - item.ProductQuant
                    };

                    _repository.UpdateInventory(inv);
                    
                    order.cart[product] = item.ProductQuant;
                     }

                 }
            _repository.AddNewOrder(order);



            return RedirectToAction(nameof(Index));
        }



    }
}