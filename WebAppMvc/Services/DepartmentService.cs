using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppMvc.Services
{
    public class DepartmentService
    {
        private readonly WebAppMvcContext _context;

        public DepartmentService(WebAppMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
