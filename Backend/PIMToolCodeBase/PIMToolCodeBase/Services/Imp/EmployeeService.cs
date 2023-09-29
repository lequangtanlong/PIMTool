using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Repositories;

namespace PIMToolCodeBase.Services.Imp
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Get(decimal id)
        {
            return _employeeRepository.Get(id);
        }

        public IEnumerable<Employee> Get(string src)
        {
            return _employeeRepository.Get().Where(p => String.IsNullOrEmpty(src) || p.Visa.ToLower().Contains(src.ToLower()) || p.FirstName.ToLower().Contains(src.ToLower())|| p.LastName.ToLower().Contains(src.ToLower())).ToList();
        }

        public IEnumerable<Employee> Get(params decimal[] ids)
        {
            return _employeeRepository.GetByIds(ids);
        }
    }
}
