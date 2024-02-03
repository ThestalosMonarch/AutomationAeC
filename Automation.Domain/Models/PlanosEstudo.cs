using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Models
{
    internal class PlanosEstudo
    {
        public DateOnly UltimaAtualizacao { get; private set; }
        public string CriadoPor { get; set; }
        public string Conteudo { get; set;}
    }
}
