using QuarterControl.Controllers.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models
{
    /// <summary>
    /// Este modelo es el que se pasa a la vista 
    /// </summary>
    public class DisplayInitial
    {
        public bool networkStatus { get; set; }

        [RegularExpression(@"\d{14}", ErrorMessage = @"El codbar debe tener el siguiente formato: 13612345678910 (14 dígitos)")]
        public string Codbar { get; set; }
        public Repository repository { get; set; }
    }
}
