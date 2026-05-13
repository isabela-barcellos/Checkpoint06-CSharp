using HelpDesk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HelpDesk.Data
{
    public class HelpDeskContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Tecnico> Tecnicos { get; set; }

        public DbSet<Chamado> Chamados { get; set; }

        public DbSet<Equipamento> Equipamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                "server=localhost;database=HelpDeskDb;user=root;password=fiap;";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
}