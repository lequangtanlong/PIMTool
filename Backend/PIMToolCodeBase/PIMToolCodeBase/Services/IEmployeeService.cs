using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Services
{
    public interface IEmployeeService
    {
        Employee Get(decimal id);

        IEnumerable<Employee> Get(string src);

        IEnumerable<Employee> Get(params decimal[] ids);
    }
}
