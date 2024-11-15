using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Risktrack.Security;
using RiskTrack.Data;
using RiskTrack.Util;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

var RiskTrackFE = "_riskTrackFE";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: RiskTrackFE,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RiskDBConn")));
builder.Services.AddScoped<IProviderRepo, ProviderRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);
builder.Services.AddControllers();
builder.Services.AddTransient<Scraper>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors(RiskTrackFE);
app.UseAuthentication();
app.UseAuthorization();
PrepDB.PrepPopulate(app, builder.Environment.IsProduction());  
app.Run();


