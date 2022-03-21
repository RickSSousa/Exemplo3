using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo3.Models
{
    public class Fabricante
    {
        public int FabricanteID { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }// associação com a classe prod... do tipo "muitos (*)"
    }
}
