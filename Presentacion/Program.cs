using AutoMapper;
using Presentacion.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mapperConfig = new MapperConfiguration(cfg =>
{
    //cfg.AddProfile<MappingProfile>();
});

IMapper mapper = new Mapper(mapperConfig);
builder.Services.AddSingleton(mapper);

var configuration = builder.Configuration;

builder.Services.AgregarDependencias(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
