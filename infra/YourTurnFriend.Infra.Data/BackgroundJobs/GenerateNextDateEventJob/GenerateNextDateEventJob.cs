using Microsoft.EntityFrameworkCore;
using Quartz;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.BackgroundJobs.GenerateNextTurnJob;

public sealed class GenerateNextDateEventJob
(
    ApplicationDbContext context
) : IJob
{
    private readonly ApplicationDbContext _context = context;

    public async Task Execute(IJobExecutionContext context)
    {
        var eventsToGenerateNextDate = await _context.Events.Where(e => e.DateOfNextEvent.Date.AddDays(1) == DateTime.Now.Date)
                                                        .Include(e => e.Members)
                                                        .ToListAsync(context.CancellationToken);

        foreach (var eventToUpdateNextDate in eventsToGenerateNextDate)
        {
            eventToUpdateNextDate.GenerateNextEventDate();
        }

        await _context.SaveChangesAsync(context.CancellationToken);
    }
}