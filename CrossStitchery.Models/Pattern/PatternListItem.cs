using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Models.Pattern
{
    public class PatternListItem
    {
        public int PatternId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
