// Creates the app builder, incl. config, logging, ASP.NET Core's DI container. `args` for any CLI args passed.
var builder = WebApplication.CreateBuilder(args);

// Register Database as a Singleton in the DI container.
builder.Services.AddSingleton<Database>();

// Register Hot Chocolate as the GraphQL server, add `Query` as query-type.
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

// Allow Vite in CORS config
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173") // Vite dev server
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Finalize builder and create the runnable app
var app = builder.Build();

app.UseCors();
app.MapGraphQL();

app.Run();