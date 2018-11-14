using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models
{
    public class Entity
    {
        [Display(Name = "Creado")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "Actualizado")]
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
