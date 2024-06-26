using DoacaoViva.Application.Auth;
using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Auth;
using DoacaoViva.Infrastructure.Microservices;
using DoacaoViva.Infrastructure.Notification.Entitys;
using DoacaoViva.Infrastructure.Notification.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DoacaoVivaContext>(contextOptions => 
    contextOptions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));
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
        Description ="API para a aplica��o de doa��o de sangue",
        Contact = new() {
            Name = "Manuel Jo�o",
            Email = "manuel115@live.com.pt",
        },
        License = new() { 
            Name = "GNU General Public License v3.0", 
            Url=new Uri("https://github.com/manuel-joao2023/sistema-doacao-sangue/blob/main/LICENSE") 
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
