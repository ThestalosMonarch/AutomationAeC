using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Models
{
    internal class Formacoes : Cursos
    {
        public Formacoes(string title, string description, string professor, string cargaHoraria) : base(title, description, professor, cargaHoraria)
        {
        }
    }
}
