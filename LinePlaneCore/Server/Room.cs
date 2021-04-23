using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    public class Room
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }
        [Required]
        public string _NameRoom { get; set; }
        [Required]
        public int _IdTipeFurniture { get; set; } 
        [ForeignKey(nameof(_IdTipeFurniture))]
        public TipeFurniture _TipeFurniture { get; set; }


    }
}
