using FinalProject;
using FinalProject.Managers;
using FinalProject.Repositories;
using Microsoft.IdentityModel.Tokens; 
using Microsoft.EntityFrameworkCore;
using FinalProject.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinalProjectContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<FinalProjectContext>();

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
