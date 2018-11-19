using GH.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Extensions
{
    public interface IDbContextFactory
    {
      DbContext GetContext();

      void Dispose();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private PreguntasContext _context;

        public DbContextFactory(PreguntasContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
