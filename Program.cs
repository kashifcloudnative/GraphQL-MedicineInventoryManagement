using GraphQLPOC.Data;
using GraphQLPOC.Repository;
using MedicineGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework with In-Memory Database (This will now work!)
builder.Services.AddDbContext<MedicineDbContext>(options =>
    options.UseInMemoryDatabase("MedicineDB"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repository
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();

// Add GraphQL services
// Add GraphQL services using Hot Chocolate (No more obsolete warnings!)
builder.Services
    .AddGraphQLServer()
    .AddQueryType<MedicineQuery>()
    .AddMutationType<MedicineMutation>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
// Create and seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MedicineDbContext>();
    context.Database.EnsureCreated();
}

app.UseCors();
// Map GraphQL endpoint with http:localhost4200/graphql
app.MapGraphQL();


app.Run();
