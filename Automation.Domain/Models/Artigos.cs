using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Models
{
    internal class Artigos:AluraContent
    {
        public DateOnly DataCriada { get; private set; }
    }
}
