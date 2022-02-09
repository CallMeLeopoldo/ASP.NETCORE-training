using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Models;
using WebAppMvc.Models.Enums;


namespace WebAppMvc.Data
{
    public class SeedingService
    {
        private WebAppMvcContext _context;

        public SeedingService(WebAppMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SalesRecord.Any())
            {
                return; //DB is not empty, so DB is already seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bobby Brown", "bob@gmail.com", 1000.0, new DateTime(1998, 4, 21));
            Seller s2 = new Seller(2, "Mark Brown", "mark@gmail.com", 1160.0, new DateTime(1997, 6, 3));
            Seller s3 = new Seller(3, "Abby Brown", "abby@gmail.com", 1200.0, new DateTime(1992, 11, 26));

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 23), 2000.0, SaleStatus.BILLED);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 05, 11), 2000.0, SaleStatus.BILLED);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 12, 8), 2000.0, SaleStatus.BILLED);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 12, 28), 2000.0, SaleStatus.BILLED);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 07, 10), 2000.0, SaleStatus.BILLED);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3);

            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5);

            _context.SaveChanges();

        }
    }
}
