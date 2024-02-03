using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Models
{
    internal class Cursos : AluraContent
    {
        public string Professor { get; private set; }
        public string Carga_Horaria { get; private set; }

    }
}
