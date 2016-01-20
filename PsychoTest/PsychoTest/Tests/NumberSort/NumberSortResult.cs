using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychoTest.Tests.NumberSort
{
    public class NumberSortResult
    {
        [Key]
        public int ResultId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Double Time { get; set; }
        public int ErrorCount { get; set; }
    }
}
