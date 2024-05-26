using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.OutBox;

namespace YourTurnFriend.Infra.Data.Transactions;

public class ConvertDomainEventsToOutBoxMessagesInterceptor
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync
    (
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default
    )
    {
        var context = eventData.Context;

        if (context == null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);   
        }

        var domainEvents = context
            .ChangeTracker
            .Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot => 
            {
                var events = aggregateRoot.GetDomainEvents();

                aggregateRoot.ClearDomainEvents();

                return events;
            })
            .Select(domainEvent => new OutBoxMessage 
                {
                    Id = Guid.NewGuid(),
                    Type = domainEvent.GetType().Name,
                    OcurredOn = DateTime.Now,
                    ProcessedOn = null,
                    Content = JsonConvert.SerializeObject
                    (
                        domainEvent, 
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        }
                    )
                })
            .ToList();

        context.Set<OutBoxMessage>().AddRange(domainEvents);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}