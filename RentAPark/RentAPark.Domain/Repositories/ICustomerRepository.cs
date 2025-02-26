using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomersByName(string name);
        List<Customer> GetCustomersByIds(List<int> reservationId);
    }
}
