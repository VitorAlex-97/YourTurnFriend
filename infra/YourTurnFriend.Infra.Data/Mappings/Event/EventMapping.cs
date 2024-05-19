using Microsoft.EntityFrameworkCore;
using Aggregate = YourTurnFriend.Domain.Entities.Event;

namespace YourTurnFriend.Infra.Data.Mappings.Event;

public class EventMapping : IEntityTypeConfiguration<Aggregate.Event>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Aggregate.Event> builder)
    {
        builder.ToTable("YTF_EVENT");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("TITLE");

        builder.Property(x => x.IdOwner)
            .IsRequired()
            .HasColumnName("ID_OWNER");;

        builder.Property(x => x.DateOfLastEvent)
            .HasColumnName("DATE_LAST_EVENT");

        builder.Property(x => x.Frequence)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.IdOfNextMemberInTurn)
            .HasColumnName("ID_NEXT_MEMBER_IN_TURN");

        builder.HasMany(x => x.Members)
            .WithOne()
            .HasForeignKey("EventId") // Assuming you have a navigation property EventId in the Member class
            .OnDelete(DeleteBehavior.Cascade);
    }
}