using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BusinessLogic;
using Project1.DataAccess.Interfaces;
using Project1.WebApp.Models;

namespace Project1.WebApp.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreRepo _repository;

        public StoresController(IStoreRepo repository)
        {
            _repository = repository;
        }

        // GET: Stores
        public ActionResult Stores()
        {
            IEnumerable<BusinessLogic.Store> store = _repository.GetAllStores();

            var viewModel = store.Select(s => new StoreViewModel
            {
                StoreId = s.StoreId,
                City = s.City
            });

            return View(viewModel);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stores/Edit/5
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

        // GET: Stores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stores/Delete/5
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

        public ActionResult StoreOrders(int id)
        {

            List<Order> orders = _repository.GetOrdersByStoreId(id);

            List<OrderViewModel> storeViewModels = orders.Select(o => new OrderViewModel
            {
                CustomerId = o.CustomerId,
                OrderId = o.OrderId,
                OrderDate = o.DateOfOrder,
                Total = o.OrderTotal,
                StoreId = o.StoreId
            }).ToList();

            return View(storeViewModels);

        }

        public ActionResult SeeInventory(OrderViewModel orderViewModel)
        {

            Dictionary<Product, int> dic = _repository.GetInventoryByStoreId(orderViewModel.StoreId);

            orderViewModel.Inventory = dic.Select(p => new ProductViewModel
            {
                ProductId = p.Key.ProductId,
                ProductQuant = p.Value,
                Price = p.Key.Price,
                Name = p.Key.Name

            }).ToList();

            return View(orderViewModel);

        }
    }
}