using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Models.Pattern
{
    public class PatternDetail
    {
        public int PatternId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number Of Colors")]
        public int NumberOfColors { get; set; }
        public int ColorNumber { get; set; }
        public int ColorNumber2 { get; set; }
        public int ColorNumber3 { get; set; }
        public int ColorNumber4 { get; set; }
        public int ColorNumber5 { get; set; }
        public int ColorNumber6 { get; set; }
        public int ColorNumber7 { get; set; }
        public int ColorNumber8 { get; set; }
        public int ColorNumber9 { get; set; }
        public int ColorNumber10 { get; set; }
        [Display(Name = "Level Of Difficulty")]
        public string Level { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool Backstitching { get; set; }
        //public string Category { get; set; }
    }
}
