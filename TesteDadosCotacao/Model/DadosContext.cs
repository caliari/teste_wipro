using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDadosCotacao.Model
{
    public class DadosContext : DbContext
    {
        public DadosContext(DbContextOptions<DadosContext> options)
            : base(options)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }
    }
}
