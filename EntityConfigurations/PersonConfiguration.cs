using ExpensesManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesManagementApi.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Transactions).WithOne(x => x.Person).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.PersonId);
        }
    }
}
