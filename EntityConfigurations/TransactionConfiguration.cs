using Microsoft.EntityFrameworkCore;
using ExpensesManagementApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpensesManagementApi.Enums;

namespace ExpensesManagementApi.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).HasConversion(x => x.ToString(), x => (TransactionType)Enum.Parse(typeof(TransactionType), x));
            builder.HasOne(x => x.Person).WithMany(x => x.Transactions).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id);
        }
    }
}
