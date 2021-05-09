using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinePlaneCore
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }

        [Required]
        public string _Login { get; set; }
        [Required]
        public string _Password { get; set; }
        [Required]
        public string _Email { get; set; }
    }
}
