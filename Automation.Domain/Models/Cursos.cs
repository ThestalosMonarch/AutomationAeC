using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Models
{
    public class Cursos : AluraContent
    {
        public string Professor { get; set; }
        public string Carga_Horaria { get; set; }
        public Cursos(string title, string description, string professor, string cargaHoraria)
            : base(title, description)
        {
            Professor = professor;
            Carga_Horaria = cargaHoraria;
        }
    }
}

