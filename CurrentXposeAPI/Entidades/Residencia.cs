﻿using CurrentXpose.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXpose.Domain.Entidades
{
    public class Residencia
    {
        [Key]
        public int id { get; set; }
        public string numero { get; set; }
        public string andar { get; set; }
        public Predio predio { get; set; }

        public Residencia() { }
    }
}
