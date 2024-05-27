using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aggregate = YourTurnFriend.Domain.Entities.Event;

namespace YourTurnFriend.Infra.Data.Mappings.Event;

public class MemberMapping : IEntityTypeConfiguration<Aggregate.Member>
{
    public void Configure(EntityTypeBuilder<Aggregate.Member> builder)
    {
        builder.ToTable("YTF_MEMBER");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever()
            .HasConversion(
                value => value.ToString(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.Property(m => m.Name)
            .HasMaxLength(20)
            .HasColumnName("NAME");

        builder.Property(m => m.IdEvent)
            .IsRequired()
            .HasColumnName("ID_EVENT")
            .HasConversion(
                value => value.ToString(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.HasOne<Aggregate.Event>()
            .WithMany(e => e.Members)
            .HasForeignKey(m => m.IdEvent)
            .OnDelete(DeleteBehavior.Cascade);
    }
}