using CurrentXposeAPI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Predio : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int total_de_andares { get; set; }
        public int condominio_id { get; set; }

        public Predio() { }
    }
}
