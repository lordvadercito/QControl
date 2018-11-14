using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models
{
    public class AngusInspect : Inspect
    {
        public bool MarmoreoApto { get; set; }

        public override bool Aprueba()
        {
            return MarmoreoApto;
        }
    }
}
