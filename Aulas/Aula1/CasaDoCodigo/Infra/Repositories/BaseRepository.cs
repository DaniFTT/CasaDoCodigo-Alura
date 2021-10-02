using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Infra.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbset;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }
    }
}
