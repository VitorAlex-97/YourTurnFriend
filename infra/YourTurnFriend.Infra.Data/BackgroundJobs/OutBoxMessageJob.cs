using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using YourTurnFriend.Domain.DomainEvents;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.BackgroundJobs;

[DisallowConcurrentExecution]
public sealed class OutBoxMessageJob
(
    ApplicationDbContext context,
    IPublisherDomainEvent publisher
) : IJob
{
    private readonly ApplicationDbContext _context = context;
    private readonly IPublisherDomainEvent _publisher = publisher;

    public async Task Execute(IJobExecutionContext context)
    {
        var outBoxMessages = await _context
                                    .OutBoxMessages
                                    .Where(x => x.ProcessedOn == null)
                                    .Take(20)
                                    .ToListAsync(context.CancellationToken);

        foreach (var outBoxMessage in outBoxMessages)
        {
            var domainEvent = JsonConvert
                                .DeserializeObject<IDomainEvent>(
                                    outBoxMessage.Content,
                                    new JsonSerializerSettings 
                                    {
                                        TypeNameHandling = TypeNameHandling.All
                                    });
            
            if (domainEvent is null) 
            {
                continue;
            }

            await _publisher.Publish(domainEvent, context.CancellationToken);
        }
    }
}