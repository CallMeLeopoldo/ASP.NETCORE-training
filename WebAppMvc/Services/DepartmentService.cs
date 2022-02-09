using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Models;

namespace WebAppMvc.Services
{
    public class DepartmentService
    {
        private readonly WebAppMvcContext _context;

        public DepartmentService(WebAppMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
