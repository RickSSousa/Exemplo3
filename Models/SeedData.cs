using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo3.Models
{
    public class SeedData
    {
        // classe apenas para povoar o banco de dados
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //associa os dados ao contexto
            Context context = app.ApplicationServices.GetRequiredService<Context>();
            //inserir os dados na entidades do contexto
            context.Database.Migrate();
            if(!context.Produtos.Any()) //se o cntexto estiver vazio
            {
                //inserir os produtos iniciais
                context.Produtos.AddRange(
                    new Produto { Nome = "Camiseta Oficial", Preco = 250, FabricanteID = 1 },//não foi colocado id do produto pois definimos como auto incremento
                    new Produto { Nome = "Short", Preco = 120, FabricanteID = 1 },
                    new Produto { Nome = "Tênis", Preco = 540, FabricanteID = 2 }
                    );
                context.Fabricantes.AddRange(
                    new Fabricante { Nome = "Adidas" },
                    new Fabricante { Nome = "Nike" }
                    );
                context.SaveChanges();
            }
        }
    }
}
