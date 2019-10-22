using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BusinessLogic;
using Project1.DataAccess;
using Project1.WebApp.Models;

namespace Project1.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICustRepo _repository;

        public OrdersController(ICustRepo repository)
        {
            _repository = repository;
        }

        // GET: Orders
        public ActionResult CustomerOrders(int id)
        {
            
            List<Order> orders = _repository.GetOrdersByCustId(id);

            List<OrderViewModel> orderViewModels = orders.Select(o => new OrderViewModel
            {
                CustomerId = o.CustomerId,
                OrderId = o.OrderId,
                OrderDate = o.DateOfOrder,
                Total = o.OrderTotal,
                StoreId = o.StoreId
            }).ToList();

            return View("CustomerOrders", orderViewModels);
           
        }

       
        


        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
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

       
        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
    }
}