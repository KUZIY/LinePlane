using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    public class Furniture:DbContext

    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }
        public string _Picture { get; set; }
        [Required]
        public string _Link { get; set; }
        [Required]
        public int _Price { get; set; }
        
        [Required]
        public string _FurnitureName { get; set; }
        
        [Required]
        public int _IdTipeFurniture { get; set; }
        [ForeignKey(nameof(_IdTipeFurniture))]
        public TipeFurniture _TipeFurniture { get; set; }
        

    }
}