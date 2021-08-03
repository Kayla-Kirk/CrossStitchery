using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Models
{
    public class FlossDetail
    {
        public int FlossId { get; set; }
        [Display(Name = "Color Number")]
        public string ColorNumber { get; set; }
        [Display(Name = "Color Name")]
        public string ColorName { get; set; }
        [Display(Name = "Bobbin Amount")]
        public int BobbinAmount { get; set; }
        //[Display(Name = "In Stock?")]
        //public bool InStock
        //{
        //    set
        //    {
        //        if (BobbinAmount >= 1)
        //            return;
        //    }
        //}
    }
}
