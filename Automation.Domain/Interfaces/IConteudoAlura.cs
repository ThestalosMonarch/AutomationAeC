using Automation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Interfaces
{
    public interface IConteudoAlura
    {
        void SaveCursos(List<Cursos> cursos);
    }
}
