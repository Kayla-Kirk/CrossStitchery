using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Data
{
    public class Aida
    {
        [Key]
        public int AidaId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int AidaHoleCount
        {
            get
            {
                int heightCount = Count * Height;
                int widthCount = Count * Width;
                return heightCount + widthCount;
            }
        }
    }
}
