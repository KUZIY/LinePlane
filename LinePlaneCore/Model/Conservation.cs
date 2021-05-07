using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Model.Server
{
    public class Conservation
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }

        [Required]
        public string _Picture { get; set; }

        [Required]
        public string _IdUser { get; set; }

        [ForeignKey(nameof(_IdUser))]
        public User _User { get; set; }

        [Required]
        public string _FurnitureName { get; set; }
    }
}
