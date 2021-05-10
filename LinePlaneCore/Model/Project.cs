using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Model.Server
{
    public class Project
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }

        [Required]
        public int _IdConservation { get; set; }
        [ForeignKey(nameof(_IdConservation))]
        public Conservations _Conservation { get; set; }

        public int _IdFurniture { get; set; }
        [ForeignKey(nameof(_IdFurniture))]
        public Furniture _Furniture { get; set; }

        public int _IdСoordinates { get; set; }
        [ForeignKey(nameof(_IdСoordinates))]
        public Сoordinates _Сoordinates { get; set; }
    }
}
