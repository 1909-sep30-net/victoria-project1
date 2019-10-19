using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess
{
    public class Mapper
    {
        //convert DB Stores to BL Store 
        public static BusinessLogic.Store MapStore(Entities.Stores stores)

        {

            return new BusinessLogic.Store

            {

                StoreId = stores.StoreId,

                City = stores.City

            };
        }

        internal static Store MapStore(object p)
        {
            throw new NotImplementedException();
        }


        //Convert BL Store into DB Stores
        public static Project1.DataAccess.Entities.Stores MapDbStores(BusinessLogic.Store store)

        {

            return new Project1.DataAccess.Entities.Stores

            {

                StoreId = store.StoreId,

                City = store.City
            };

        }


        //converts DB Products to  BL Product 
        public static BusinessLogic.Product MapShirt(Entities.Products products)
        {
            return new BusinessLogic.Product

            {

                Name = products.Name,

                Price = products.Price,

                ProductId = products.ProductId


            };
        }


        //converting BL Product to DB Products  
        public static Project1.DataAccess.Entities.Products MapDbProduct(Product product)
        {

            return new Project1.DataAccess.Entities.Products

            {

                Name = product.Name,

                Price = product.Price,

                ProductId = product.ProductId


            };

        }


        // converts  DB customers to BL customer 
        public static BusinessLogic.Customer MapCustomer(Entities.Customers customers)
        {
            return new BusinessLogic.Customer

            {

                FirstName = customers.FirstName,

                LastName = customers.LastName,

                Id = customers.CustomerId


            };
        }


        //converts BL customer into DB customers
        public static Project1.DataAccess.Entities.Customers MapDbCustomer(Customer customer)
        {
            return new Project1.DataAccess.Entities.Customers
            {
                FirstName = customer.FirstName,

                LastName = customer.LastName,

                CustomerId = customer.Id
            };
        }



        //Convert DB Orders to BL Order  
        public static BusinessLogic.Order MapOrder(Orders orders)
        {
            return new BusinessLogic.Order

            {

                OrderId = orders.OrderId,

                DateOfOrder = orders.OrderDate,

                OrderTotal = orders.Total,

                StoreId = orders.StoreId,

                CustomerId = orders.CustomerId,

               

                //cart = MapCart()? map orderdetailID?


            };

        }


        //Convert BL Order to DB Orders 
        public static Project1.DataAccess.Entities.Orders MapDbOrders(Order order)
        {

            return new Project1.DataAccess.Entities.Orders

            {

                OrderId = order.OrderId,

                OrderDate = order.DateOfOrder,

                Total = order.OrderTotal,

                StoreId = order.StoreId,

                CustomerId = order.CustomerId,



            };
        }

        //convert DB Inventory to BL Inventory

        public static BusinessLogic.Inventory MapInventory(Entities.Inventory inventory)
        {
            return new BusinessLogic.Inventory
            {
                InventoryId = inventory.InventoryId,

                ProductId = inventory.ProductId,

                Quantity = inventory.Quantity,

                StoreId = inventory.StoreId
            };
        }


        //convert BL Inventory to DB Inventory

        public static Project1.DataAccess.Entities.Inventory MapDbInventory(BusinessLogic.Inventory inventory)
        {
            return new Project1.DataAccess.Entities.Inventory
            {
                InventoryId = inventory.InventoryId,

                ProductId = inventory.ProductId,

                Quantity = inventory.Quantity,

                StoreId = inventory.StoreId

            };
        }

        // map order cart to order details
        public static BusinessLogic.Order MapCart(IEnumerable<OrderDetail> orderDetail)
        {


            Dictionary<Product, int> dic2 = new Dictionary<Product, int>();

            foreach (OrderDetail od in orderDetail)
            {
                dic2.Add(new Product(od.Product.Name, od.Product.Price, od.Product.ProductId), od.ProductQuant);
            }

            return new BusinessLogic.Order
            {
                OrderId = orderDetail.Single().OrderDetailId,

                cart = dic2
            };



        }

        //convert BL Od to DB od
        public static Project1.DataAccess.Entities.OrderDetail MapDbOrderDetail(BusinessLogic.OrderDetails orderDetails)
        {
            return new Project1.DataAccess.Entities.OrderDetail
            {
                OrderDetailId = orderDetails.OrderDetailId,

                ProductId = orderDetails.ProductId,

                ProductQuant = orderDetails.ProductQuant,

                OrderId = orderDetails.OrderId

            };
        }

        //convert DB Od to BL Od
        public static Project1.BusinessLogic.OrderDetails MapOrderDetail(Project1.DataAccess.Entities.OrderDetail orderDetail)
        {
            return new Project1.BusinessLogic.OrderDetails
            {
                OrderDetailId = orderDetail.OrderDetailId,

                ProductId = orderDetail.ProductId,

                ProductQuant = orderDetail.ProductQuant,

                OrderId = orderDetail.OrderId

            };
        }

    }
}
