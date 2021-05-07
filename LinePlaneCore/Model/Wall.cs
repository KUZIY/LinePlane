using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinePlaneCore
{
    public class Wall
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }
        [Required]
        public int _X1 { get; set; }
        [Required]
        public int _Y1 { get; set; }
        [Required]
        public int _X2 { get; set; }
        [Required]
        public int _Y2 { get; set; }
    }
}
