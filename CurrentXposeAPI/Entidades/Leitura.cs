using CurrentXposeAPI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Leitura : BaseModel
    {
        [Key]
        public int id { get; set; }
        public DateTime data_da_leitura { get; set; }
        public double valor_da_leitura { get; set; }

        public Leitura() { }
    }
}
