using VitaminBad.Data;
using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Data.Repository;
using VitaminBad.Domain.Entity;
using VitaminBad.Service.Interfaces;
using VitaminBad.Service.Implements;
using Microsoft.AspNetCore.Authentication.OAuth;


var builder = WebApplication.CreateBuilder(args);

var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(con));

builder.Services.AddScoped<IBaseRepository<Drugs>, DrugRepository>();
builder.Services.AddScoped<IBaseRepository<InteractionType>, InteractionTypeRepository>();
builder.Services.AddScoped<IBaseRepository<Food>, FoodRepository>();
builder.Services.AddScoped<IBaseRepository<Ingredients>, IngredientsRepository>();
builder.Services.AddScoped<IBaseRepository<Heabs>, HeabsRepostitory>();
builder.Services.AddScoped<IBaseRepository<Interaction>, InteractionRepository>();
builder.Services.AddScoped<IInteractionService, InteractionService>();
builder.Services.AddScoped<IImportExcel, ImportExcel>();
builder.Services.AddScoped<IDrugService, DrugService>();
builder.Services.AddScoped<IHeabsService, HeabsService>();
var auth = builder.Configuration.GetSection("Auth");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builderr =>
        {
            builderr.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        );
});

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

app.UseCors();
app.Run();
