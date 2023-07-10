using Empresa.Data;
using Empresa.Repositorios;
using Empresa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Empresa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDBcontex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
                builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
                var app = builder.Build();
                if (app.Environment.IsDevelopment())
                 {
                  app.UseSwagger();
                  app.UseSwaggerUI();
                 }
                  app.UseHttpsRedirection();
                  app.UseAuthorization();
                  app.MapControllers();
                  app.Run();
            }
        }
    }
}