using FinalProject;
using FinalProject.Managers;
using FinalProject.Repositories;
using Microsoft.IdentityModel.Tokens; 
using Microsoft.EntityFrameworkCore;
using FinalProject.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
});

c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name="Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()
                    }
    });
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinalProjectContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });


builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.SaveToken = true;
                    var secret = builder.Configuration.GetSection("Jwt").GetSection("SecretKey").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("BasicUser", policy => policy.RequireRole("BasicUser").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
    opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

});
builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddTransient<IConcertsRepository, ConcertsRepository>();
builder.Services.AddTransient<IConcertsManager, ConcertsManager>();

builder.Services.AddTransient<IOrganizersRepository, OrganizersRepository>();
builder.Services.AddTransient<IOrganizersManager, OrganizersManager>();

builder.Services.AddTransient<IObiectsRepository, ObiectsRepository>();
builder.Services.AddTransient<IObiectsManager, ObiectsManager>();

builder.Services.AddTransient<IGiftsRepository, GiftsRepository>();
builder.Services.AddTransient<IGiftsManager, GiftsManager>();

builder.Services.AddTransient<ISongsRepository, SongsRepository>();
builder.Services.AddTransient<ISongsManager, SongsManager>();

builder.Services.AddTransient<IStudentsRepository, StudentsRepository>();
builder.Services.AddTransient<IStudentsManager, StudentsManager>();

builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddTransient<ITokenManager, TokenManager>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<FinalProjectContext>();

//Database connection
//builder.Services.AddDbContext<FinalProjectContext>(options => 
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//
//});

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
