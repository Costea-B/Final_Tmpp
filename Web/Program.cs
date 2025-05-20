using App.Abstraction;
using App.Templates;
using App.User;
using Infrastructure.Abstraction;
using Infrastructure.DbContext;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddSingleton<ILoggerService>(_ => LoggerService.Instance);
builder.Services.AddScoped<ILoginServices, LoginService>();
builder.Services.Decorate<ILoginServices, LoginServiceProxy>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<ITemplatesServices, TemplatesServices>();
builder.Services.AddScoped<ITemplatesRepository, TemplatesRepository>();


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
