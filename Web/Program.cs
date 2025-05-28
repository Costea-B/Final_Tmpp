using App.Abstraction;
using App.ChainOfResponsibility;
using App.Facede;
using App.Factory;
using App.NotificationDecorator;
using App.Services;
using App.Strategy;
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
builder.Services.AddScoped<NotificationService>(); // Serviciul de baz?
builder.Services.AddScoped<SimpleAllocationStrategy>();
builder.Services.AddScoped<VipAllocationStrategy>();
builder.Services.AddScoped<EventAllocationStrategy>();

builder.Services.AddScoped<ReservationFactory>();
builder.Services.AddScoped<IReservationFactory>(sp =>
     new ReservationFactory(sp));



builder.Services.AddScoped<INotificationService>(sp =>
{
     var baseService = sp.GetRequiredService<NotificationService>();
     var withLogging = new LoggingNotificationDecorator(baseService);
     var withRetry = new RetryNotificationDecorator(withLogging);
     return withRetry;
});

builder.Services.AddScoped<ReservationServices>();
builder.Services.AddScoped<ReservationFacade>();
builder.Services.AddReservationRepository(); // Adaugat ReservationRepository
builder.Services.AddScoped<App.Services.ReservationStateService>();
builder.Services.AddScoped<Infrastructure.Abstraction.ITableRepository, Infrastructure.Repository.TableRepository>();
builder.Services.AddScoped<App.Abstraction.IPrototypeTemplate, App.Templates.TemplatePrototype>();
builder.Services.AddScoped<App.Services.ReservationQueryService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

// Chain of Responsibility handlers registration
builder.Services.AddScoped<GuestsValidationHandler>();
builder.Services.AddScoped<DateValidationHandler>();
builder.Services.AddScoped<RestaurantValidationHandler>();

// Chain builder for ReservationValidationService
builder.Services.AddScoped<ReservationValidationService>(sp =>
{
    var guestsHandler = sp.GetRequiredService<GuestsValidationHandler>();
    var dateHandler = sp.GetRequiredService<DateValidationHandler>();
    var restaurantHandler = sp.GetRequiredService<RestaurantValidationHandler>();
    guestsHandler.SetNext(dateHandler);
    dateHandler.SetNext(restaurantHandler);
    return new ReservationValidationService(guestsHandler);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(option =>
{
     option.AddPolicy("Policy", builder =>
     {
          builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
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

app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
