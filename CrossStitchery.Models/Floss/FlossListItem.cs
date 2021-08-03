using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Models
{
    public class FlossListItem
    {
        public int FlossId { get; set; }
        [Display(Name = "Color Number")]
        public string ColorNumber { get; set; }
        [Display(Name = "Color Name")]
        public string ColorName { get; set; }
    }
}
