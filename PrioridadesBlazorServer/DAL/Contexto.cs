using Microsoft.EntityFrameworkCore;
using PrioridadesBlazorServer.Models;

namespace PrioridadesBlazorServer.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Prioridades> Prioridades { get; set; }
        public Contexto(DbContextOptions <Contexto> options) : base(options) 
        {
        }
    }
}
