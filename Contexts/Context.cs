using ExpensesManagementApi.EntityConfigurations;
using ExpensesManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExpensesManagementApi.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PersonConfiguration)));
        }
    }
}
