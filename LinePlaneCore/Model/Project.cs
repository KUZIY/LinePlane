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
        public int Id { get; set; }

        [Required]
        public int _IdConservation { get; set; }
        [ForeignKey(nameof(_IdConservation))]
        public Save _Conservation { get; set; }

        public int _IdFurniture { get; set; }
        [ForeignKey(nameof(_IdFurniture))]
        public Furniture _Furniture { get; set; }

        public int _IdMeasurements { get; set; }
        [ForeignKey(nameof(_IdMeasurements))]
        public Measurements _Measurements { get; set; }

        public int _IdWall { get; set; }
        [ForeignKey(nameof(_IdWall))]
        public Wall _Wall { get; set; }
    }
}
