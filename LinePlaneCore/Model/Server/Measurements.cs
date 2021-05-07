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
        public int _Length { get; set; }
        [Required]
        public int _Width { get; set; }
        
        [Required]
        public int _IdFurniture { get; set; }
        [ForeignKey(nameof(_IdFurniture))]
        public Furniture _Furniture { get; set; }
    }
}
