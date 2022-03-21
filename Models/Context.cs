using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo3.Models
{
    // Essa classe é meu "Banco de Dados"
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) //esse options é onde está a string de conexão com o BD, buscando as config de conexão com o BD. Ele precisa disso pra saber com qual BD vai se conectar
            : base (options)
        {
        }
        //td q for DBSet é uma tabela q vai ser criada no meu BD
        public DbSet<Produto> Produtos { get; set; }//conjunto de dados do tipo Produto q se constituirá em uma tabela no BD
        public DbSet<Fabricante> Fabricantes { get; set; }

    }
}
    

