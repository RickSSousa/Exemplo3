using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo3.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int FabricanteID { get; set; }
        public Fabricante Fabricante { get; set; }//associação com a classe fabri... do tipo 1
    }
}
