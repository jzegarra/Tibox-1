using System;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.UnitOfWork
{
    public class TiboxUnitOfWork : IUnitOfWork,IDisposable  
    {
        public TiboxUnitOfWork()
        {
            Customers = new Repository<Customer>();
            Orders = new Repository<Order>();
            OrderItems = new Repository<OrderItem>();
            Products = new Repository<Product>();
            Suppliers = new Repository<Supplier>();
        }
        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
