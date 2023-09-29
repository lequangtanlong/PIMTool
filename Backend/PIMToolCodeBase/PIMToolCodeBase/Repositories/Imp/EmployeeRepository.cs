using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Database;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Repositories.Imp
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PimContext pimContext) : base(pimContext)
        {
        }

        public IEnumerable<Employee> GetByIds(params decimal[] ids)
        {
            return Set.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
