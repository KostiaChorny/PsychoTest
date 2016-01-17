using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychoTest.Tests.Strup
{
    public class StrupResult
    {
        [Key]
        public int ResultId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual ICollection<PartResult> Parts { get; set; } = new List<PartResult>();
    }

    public class PartResult
    {
        [Key]
        public int PartResultId { get; set; }
        public int Part { get; set; }
        public double Time { get; set; }
        public int QuestionsCount { get; set; }
        public int ErrorsCount { get; set; }
        public int StrupResult_ResultId { get; set; }
    }
}
