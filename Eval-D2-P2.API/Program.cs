using Eval_D2_P2.DAL;
using Eval_D2_P2.Repository;
using Eval_D2_P2.Repository.Contracts;
using Eval_D2_P2.Service;
using Eval_D2_P2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<EvalDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Eval-D2-P2;Trusted_Connection=True;TrustServerCertificate=true;");
        });

        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEventRepository, EventRepository>();
    })
    .Build();

host.Run();
