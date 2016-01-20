using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychoTest.Tests.ConfusedLines
{
    public class ConfusedLinesTestResult
    {
        [Key]
        public int ResultId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ErrorsCount { get; set; }
        public double Time { get; set; }
        public string Result { get; set; }
    }
}
