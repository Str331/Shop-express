// read database configuration (database provider + database connection) from environment variables
using ChaikaTest.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopTest.View.Task.Create;
using ShopTest.View.Task.Delete;
using ShopTest.View.Task.Query;
using ShopTest.View.Task.Read;
using ShopTest.View.Task.Update;
using System.Reflection;

public class Program
{
    private static readonly IConfiguration _config;
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer();
        });
        //builder.Services.AddAutoMapper(cfg=>cfg.GetType(Assembly));

        var config = new ConfigurationBuilder();
        config.SetBasePath(Directory.GetCurrentDirectory());
        config.AddJsonFile("appsettings.json");
        var buildConfig = config.Build();
        string connectionString = buildConfig.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        var options = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;

        #region MediatR
        builder.Services.AddTransient<IRequestHandler<CreateTaskRequestDTO, int>, CreateTaskHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteTaskRequestDTO, Unit>, DeleteTaskHandler>();
        builder.Services.AddTransient<IRequestHandler<QueryTasksRequestDTO, QueryTasksResponseDTO>, QueryTasksHandler>();
        builder.Services.AddTransient<IRequestHandler<ReadTaskRequestDTO, ReadTaskResponseDTO>, ReadTaskHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateTaskRequestDTO, int>, UpdateTaskHandler>();
        #endregion

        //builder.Services.AddInfrastructureServices(_config);

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
    }
}