using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppMvc.Services
{
    public class SalesRecordService
    {
        private readonly WebAppMvcContext _context;

        public SalesRecordService(WebAppMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? min, DateTime? max)
        {
            var result = _context.SalesRecord.Select(x => x);

            if (min.HasValue)
            {
                result = result.Where(x => x.Date > min.Value);
            }

            if (max.HasValue)
            {
                result = result.Where(x => x.Date < max.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
