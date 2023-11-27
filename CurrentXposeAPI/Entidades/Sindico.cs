using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXposeAPI.Entidades
{
    public class Sindico : BaseModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int condominio_id { get; set; }
        public Tipo_Relatorio nivel_relatorio { get; set; }

        public Sindico() { }
    }
}
