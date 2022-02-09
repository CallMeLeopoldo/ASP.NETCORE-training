using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Salary { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, double salary, DateTime date, Department dep)
        {
            Id = id;
            Name = name;
            Email = email;
            Salary = salary;
            BirthDate = date;
            Department = dep;
        }

        public void AddSale(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSale(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(s => s.Date > initial && s.Date < final).Sum(s => s.Ammount);
        }


    }
}
