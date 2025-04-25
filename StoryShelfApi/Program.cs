using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Context;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Impl.Validation;
using StoryShelfApi.Mapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<BookValidator>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new MapperConfiguration(x => x.AddProfile(new MapperConfig())).CreateMapper());
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateBookCommand).GetTypeInfo().Assembly));


builder.Services.AddDbContext<StoryShelfDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLServer")));
builder.Services.AddScoped<IStoryShelfDbContext>(provider => provider.GetService<StoryShelfDbContext>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}
app.Run();
