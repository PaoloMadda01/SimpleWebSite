using ProgettoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgettoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //Metodo per leggere dal database e inviare i dati alla classe
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
