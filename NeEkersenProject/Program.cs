using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinesLayer.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

// Add services to the container.
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowOrgin",
//            builder => builder.WithOrigins("https://localhost:7031"));
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrgin",
        builder =>
        {
            builder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true);
        }
        );
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowOrgin");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
