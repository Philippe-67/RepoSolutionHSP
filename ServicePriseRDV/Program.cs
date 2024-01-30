using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServicePriseRDV.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ServicePriseRDVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServicePriseRDVContext") ?? throw new InvalidOperationException("Connection string 'ServicePriseRDVContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

///authentification bearer :
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5002";  //5002=is2

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
///sce authorisation
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "apiRDV");
    });
});

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
app.UseRouting();
app.UseAuthentication();// en paralèlle avec JWT BEarer
app.UseAuthorization();
app.MapControllers().RequireAuthorization("ApiScope");

app.UseEndpoints(endpoints =>
   { endpoints.MapControllers();
   });


app.Run();
