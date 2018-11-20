using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models
{
    public class AngusInspect : Inspect
    {
        public int AngusInspectId { get; set; }
        public bool MarmoreoApto { get; set; }
        
        /// <summary>
        /// Este método indica si un garrón cumple con las condiciones para ser Angus,
        /// En este caso la validación depende de si el marmoreo es apto o no
        /// </summary>
        /// <returns>Valor booleano del marmoreo</returns>
        public override bool Aprueba()
        {
            return MarmoreoApto;
        }
    }
}
