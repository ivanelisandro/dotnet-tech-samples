using MiddlewarePipelineSample;

var builder = WebApplication.CreateBuilder(args);

// Configure to listen on HTTP only for simplicity.
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5294); // HTTP only
});

var app = builder.Build();

app.Use(SecurityLogMiddleware.Log);
app.Use(SecurityEnforcementMiddleware.Execute);

app.Use(InputValidationMiddleware.Verify);
app.Use(ShortCircuitMiddleware.TryAccess);
app.Use(AuthenticationSimulationMiddleware.Verify);
app.Use(AsyncSimulationMiddleware.Execute);

app.Run(FinalMiddleware.Finish);

app.Run();
