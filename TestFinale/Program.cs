using Microsoft.EntityFrameworkCore;
using TestFinale.DataSource;
using TestFinale.Repository;
using TestFinale.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UtentiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnPostres")));

builder.Services.AddScoped<UtentiContext, UtentiContext>();
builder.Services.AddScoped<IUtentiRepository, UtentiRepository>();
builder.Services.AddScoped<IUtentiServices, UtentiServices>();

var myPolicy="MyPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy, policy =>
    {
        policy.WithOrigins("http://localhost");
          
        
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
