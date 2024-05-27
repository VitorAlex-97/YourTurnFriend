using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aggregate = YourTurnFriend.Domain.Entities.Event;

namespace YourTurnFriend.Infra.Data.Mappings.Event;

public class EventMapping : IEntityTypeConfiguration<Aggregate.Event>
{
    public void Configure(EntityTypeBuilder<Aggregate.Event> builder)
    {
        builder.ToTable("YTF_EVENT");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever()
            .HasConversion(
                value => value.ToString().ToLower(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TITLE");

        builder.Property(x => x.IdOwner)
            .IsRequired()
            .HasColumnName("ID_OWNER")
            .HasConversion(
                value => value.ToString().ToLower(),
                valueDb => Guid.Parse(valueDb)
            );

        builder.Property(x => x.DateOfNextEvent)
            .HasColumnName("DATE_NEXT_EVENT")
            .HasConversion(
                value => value.ToString(),
                valueDb => DateTime.Parse(valueDb)
            );

        builder.Property(x => x.DateOfLastEvent)
            .HasColumnName("DATE_LAST_EVENT")
            .HasConversion(
                value => value.ToString(),
                valueDb => !string.IsNullOrEmpty(valueDb) 
                            ? DateTime.Parse(valueDb)
                            : null
            );

        builder.Property(x => x.Frequence)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.IdOfNextMemberInTurn)
            .HasColumnName("ID_NEXT_MEMBER_IN_TURN")
            .HasConversion(
                value => value != null 
                            ? value.Value.ToString().ToLower()
                            : null,
                valueDb => valueDb != null 
                            ? Guid.Parse(valueDb)
                            : null
            );;
    }
}