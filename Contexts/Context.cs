using ExpensesManagementApi.EntityConfigurations;
using ExpensesManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExpensesManagementApi.Contexts
{
    public class Context : DbContext
    {
        public Context() { }

        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PersonConfiguration)));
        }
    }
}
