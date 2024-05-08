using DoacaoViva.Application.Auth;
using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Auth;
using DoacaoViva.Infrastructure.GraphQL;
using DoacaoViva.Infrastructure.Microservices;
using DoacaoViva.Infrastructure.Notification.Entitys;
using DoacaoViva.Infrastructure.Notification.Services;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DoacaoVivaContext>(contextOptions => contextOptions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<JwtAuth>(builder.Configuration.GetSection(nameof(JwtAuth))); 
builder.Services.Configure<NotificationSetings>(builder.Configuration.GetSection(nameof(NotificationSetings)));

//builder.Services
//    .AddGraphQLServer()
//    .AddQueryType<Query>()
//    .AddMutationType<Mutation>()
//.AddSubscriptionType<Subscription>();

//Inject Dependence
builder.Services.AddScoped<IDonations, DonationsServices>();
builder.Services.AddScoped<IDonator, DonatorServices>();
builder.Services.AddScoped<IRequest, RequestServices>();
builder.Services.AddScoped<ISuport, SuportServices>();
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IUsers, UsersServices>();
builder.Services.AddScoped<ICampaign, CampaignServices>();
builder.Services.AddScoped<INotification, NotificationServices>();

builder.Services.AddControllers().AddJsonOptions(configure =>
configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => {
    option.SwaggerDoc("v1",new() {
        Title = "Doacao Viva API",
        Version = "v1",
        Description ="API para a aplicação de doação de sangue",
        Contact = new() {
            Name = "Manuel João",
            Email = "manuel115@live.com.pt",
        },
        License = new() { 
            Name = "MIT", 
            Url=new Uri("https://example.com/license") 
        }
    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
}); 

var app = builder.Build();

//app.MapGraphQL();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
