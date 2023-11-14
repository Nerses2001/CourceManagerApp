using BusinessLayer.IService;
using BusinessLayer.Service;
using DataLayer;
using DataLayer.IRepository;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Extansions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataBaseAppContext>(options =>
options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    ));
builder.Services.AddRouting();


builder.Services.AddScoped<ICustomIdentityUserRepository, CustomIdentityUserRepository>();

builder.Services.AddTransient<ICustomIdentityUserService, CustomIdentityUserService>();


builder.Services.AddControllers();
builder.Services.AddIdentityServer();
builder.Services.AddAutoMapperService();
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
