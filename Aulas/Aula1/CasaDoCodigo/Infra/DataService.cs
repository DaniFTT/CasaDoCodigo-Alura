using CasaDoCodigo.Infra;
using CasaDoCodigo.Infra.Repositories;
using CasaDoCodigo.Infra.Repositories.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext _context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDb()
        {
            _context.Database.Migrate();

            List<Livro> livros = GetLivros();
            _produtoRepository.SaveProdutos(livros);
        }


        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }

}
