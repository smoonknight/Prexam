using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;
using Prexam.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DevelopmentConnection")));

// Services
builder.Services.AddScoped<IService<Exam, ExamRequest>, ExamService>();
builder.Services.AddScoped<IService<Collection, CollectionRequest>, CollectionService>();
builder.Services.AddScoped<IService<User, UserRequest>, UserService>();
builder.Services.AddScoped<IService<ExamSession, ExamSessionRequest>, ExamSessionService>();
builder.Services.AddScoped<IExamSessionAnswerService, ExamSessionAnswerService>();

// Repositories
builder.Services.AddScoped<IRepository<Exam>, ExamRepository>();
builder.Services.AddScoped<IRepository<Collection>, CollectionRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<ExamSession>, ExamSessionRepository>();
builder.Services.AddScoped<IExamSessionAnswerRepository, ExamSessionAnswerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();