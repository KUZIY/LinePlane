using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    public class Measurements
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string _Length { get; set; }
        [Required]
        public string _Width { get; set; }
        
        [Required]
        public int _IdFurniture { get; set; }
        [ForeignKey(nameof(_IdFurniture))]
        public TipeFurniture _Furniture { get; set; }
    }
}
