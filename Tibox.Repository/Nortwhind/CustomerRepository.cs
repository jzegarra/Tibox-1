using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Dapper.Contrib.Extensions;

namespace Tibox.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public Customer SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Customer>().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            }
        }
    }
}
