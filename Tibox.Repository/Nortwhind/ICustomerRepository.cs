using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer SearchByNames(string firstName, string lastName);
        
    }
}
