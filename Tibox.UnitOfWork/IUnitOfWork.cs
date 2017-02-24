using Tibox.Models;
using Tibox.Repository;

namespace Tibox.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }
}
