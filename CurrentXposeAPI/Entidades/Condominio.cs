using CurrentXposeAPI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Condominio : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }

        public Condominio() { }
    }
}
