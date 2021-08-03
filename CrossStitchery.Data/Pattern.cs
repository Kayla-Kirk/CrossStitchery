using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Data
{
    public class Pattern
    {
        [Key]
        public int PatternId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AidaCount { get; set; }
        [Required]
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
        //private Collection<ColorsNeeded> colorsNeeded;
        //public Collection<ColorsNeeded>{
        //    get
        //    {
        //        if(this.ColorNumber != null)
        //        {
        //            this.ColorNumber = new List<ColorsNeeded>();
        //        }
        //    }
        public string Level { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
        public bool Backstitching { get; set; }
        public int AidaHoleCount
        {
            get
            {
                int heightCount = AidaCount * Height;
                int widthCount = AidaCount * Width;
                return heightCount + widthCount;
            }
        }
    }
}
