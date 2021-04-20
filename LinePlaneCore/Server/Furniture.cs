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
        public int Id { get; set; }
        [Required]
        public string _Picture { get; set; }
        [Required]
        public string _Link { get; set; }
        [Required]
        public int _Price { get; set; }
        [Required]
        public int _IdMeasurements { get; set; }
        [ForeignKey(nameof(_IdMeasurements))]
        public Measurements _Measurements { get; set; }

    }
}