using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Data
{
    public class Floss
    {
        [Key]
        public int FlossId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ColorNumber { get; set; }
        [Required]
        public string ColorName { get; set; }
        public int BobbinAmount { get; set; }
        //[DefaultValue(false)]
        //public bool InStock
        //{
        //    get
        //    {
        //        if (BobbinAmount >= 1)
        //            return true;

        //    }
        //}
    }
}
