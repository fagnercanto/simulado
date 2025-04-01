using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=simulado.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simulado API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simulado API V1");
    });
}

app.MapGet("/pessoas", async (AppDbContext db) =>
    await db.Pessoas.ToListAsync());

app.MapGet("/pessoas/{id}", async (int id, AppDbContext db) =>
    await db.Pessoas.FindAsync(id)
        is Pessoa pessoa
            ? Results.Ok(pessoa)
            : Results.NotFound());

app.MapPost("/pessoas", async ([FromBody] Pessoa pessoa, AppDbContext db) =>
{
    pessoa.DataCriacao = DateTime.UtcNow;
    pessoa.DataAtualizacao = DateTime.UtcNow;
    db.Pessoas.Add(pessoa);
    await db.SaveChangesAsync();
    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

app.MapPut("/pessoas/{id}", async (int id, [FromBody] Pessoa pessoaAtualizada, AppDbContext db) =>
{
    var pessoa = await db.Pessoas.FindAsync(id);
    if (pessoa is null) return Results.NotFound();

    pessoa.Nome = pessoaAtualizada.Nome;
    pessoa.CpfCnpj = pessoaAtualizada.CpfCnpj;
    pessoa.Tipo = pessoaAtualizada.Tipo;
    pessoa.DataAtualizacao = DateTime.UtcNow;

    await db.SaveChangesAsync();
    return Results.Ok(pessoa);
});

app.MapDelete("/pessoas/{id}", async (int id, AppDbContext db) =>
{
    var pessoa = await db.Pessoas.FindAsync(id);
    if (pessoa is null) return Results.NotFound();

    db.Pessoas.Remove(pessoa);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string Tipo { get; set; } = "FISICA";
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
}