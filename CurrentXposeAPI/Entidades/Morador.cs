﻿using CurrentXposeAPI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Morador : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string  login { get; set; }
        public string senha { get; set; }
        public int residencia_id { get; set; }

        public Morador() { }
    }
}
