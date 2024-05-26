using Microsoft.Extensions.Options;
using Quartz;

namespace YourTurnFriend.Infra.Data.BackgroundJobs;

public class OutBoxMessageJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create(nameof(OutBoxMessageJob));

        options.AddJob<OutBoxMessageJob>(jobKEyBuilder => jobKEyBuilder.WithIdentity(jobKey))
                .AddTrigger(trigger =>
                    trigger.ForJob(jobKey)
                            .WithSimpleSchedule(
                                schedule => schedule.WithIntervalInSeconds(10).RepeatForever()));
    }
}