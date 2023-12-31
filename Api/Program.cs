using Api.Services;
using Api.Services.Interfaces;
using API.Persistence;
using API.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<Program>();
    fv.DisableDataAnnotationsValidation = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PhoneBook api",
        Version = "v1",
        Description = "New Developer Competency Test � FMS"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder
                .AllowAnyOrigin() // ��������� ������� � ����� �������
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.GetRequiredService<IDatabaseContext>().Database.Migrate();
}

app.UseCors("AllowAnyOrigin");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
    }
    else
    {
        await next();
    }
});

app.Run();
