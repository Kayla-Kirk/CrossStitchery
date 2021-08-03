using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Data
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(Pattern))]
        public int PatternId { get; set; }
        public virtual Pattern Pattern { get; set; }
        [ForeignKey(nameof(Floss))]
        //public List<FlossNeeded> FlossNeeded { 
        //    get
        //        var flossneeded = Pattern.Floss
        //        set; }
        public virtual Floss Floss { get; set; }
        [ForeignKey(nameof(Aida))]
        public int AidaHoleCount { get; set; }
        public virtual Aida Aida { get; set; }
    }
}
