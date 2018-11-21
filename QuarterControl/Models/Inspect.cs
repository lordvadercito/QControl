﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models
{
    public abstract class Inspect : Entity
    {
        public int GarronID { get; set; }

        public abstract bool Aprueba();
    }
}
