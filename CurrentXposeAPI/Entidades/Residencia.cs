using CurrentXposeAPI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Residencia : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string numero { get; set; }
        public string andar { get; set; }
        public int predio_id { get; set; }

        public Residencia() { }
    }
}
