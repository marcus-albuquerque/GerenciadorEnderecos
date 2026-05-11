using Microsoft.EntityFrameworkCore;
using GerenciadorEnderecos.Data;
using GerenciadorEnderecos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=GerenciadorEnderecos.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

    using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    
    // Garante que o banco e as tabelas existam
    context.Database.EnsureCreated();

    // Verifica se o usuário mockado já existe
    if (!context.Usuarios.Any(u => u.Id == 1))
    {
        context.Usuarios.Add(new Usuario 
        { 
            Id = 1, 
            Nome = "Usuário Teste", 
            Login = "testeAec", 
            Senha = "aec" 
        });
        context.SaveChanges();
    }
}


app.Run();
