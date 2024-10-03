using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  class EamRepository:IEamRepository
    {
        private readonly EAMDbcontext context;
        public EamRepository(EAMDbcontext _context)
        {
            context = _context;
        }
        public IEnumerable<Employee> Read()
        {
            try
            {
                return (IEnumerable<Employee>)context.Employees.Include(e => e.Attendance).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
