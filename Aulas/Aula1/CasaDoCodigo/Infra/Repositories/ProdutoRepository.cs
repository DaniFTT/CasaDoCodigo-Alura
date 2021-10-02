using CasaDoCodigo.Infra.Repositories.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Infra.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbset.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {

                if (!dbset.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbset.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            _context.SaveChanges();
        }
    }


    public struct Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
