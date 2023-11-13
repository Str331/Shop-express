// read database configuration (database provider + database connection) from environment variables
using ChaikaTest.Application.Card.Create;
using ChaikaTest.Application.Card.Delete;
using ChaikaTest.Application.Card.Read;
using ChaikaTest.Application.Image.Create;
using ChaikaTest.Application.Image.Delete;
using ChaikaTest.Application.Image.Read;
using ChaikaTest.Application.Image.Update;
using ChaikaTest.Application.Transaction.Create;
using ChaikaTest.Application.Transaction.Delete;
using ChaikaTest.Application.Transaction.Query;
using ChaikaTest.Application.Transaction.Read;
using ChaikaTest.Infrastructure;
using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using ChaikaTest.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

        //builder.Services.AddInfrastructureServices(_config);
        #region Mediatr
        builder.Services.AddTransient<IRequestHandler<CreateCardRequestDTO, CreateCardResponseDTO>, CreateCardHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteCardRequestDTO, Unit>, DeleteCardHandler>();
        builder.Services.AddTransient<IRequestHandler<ReadCardRequestDTO, ReadCardResponseDTO>, ReadCardHandler>();

        builder.Services.AddTransient<IRequestHandler<CreateImageRequestDTO, CreateImageResponseDTO>, CreateImageHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteImageRequestDTO, Unit>, DeleteImageHandler>();
        builder.Services.AddTransient<IRequestHandler<ReadImageRequestDTO, ReadImageResponseDTO>, ReadImageHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateImageRequestDTO, UpdateImageResponseDTO>, UpdateImageHandler>();

        builder.Services.AddTransient<IRequestHandler<CreateTransactionRequestDTO, CreateTransactionResponseDTO>, CreateTransactionHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteTransactionRequestDTO, Unit>, DeleteTransactionHandler>();
        builder.Services.AddTransient<IRequestHandler<ReadTransactionRequestDTO, ReadTransactionResponseDTO>, ReadTransactionHandler>();
        builder.Services.AddTransient<IRequestHandler<QueryTransactionListRequestDTO, QueryTransactionListResponseDTO>, QueryTransactionListHandler>();

        builder.Services.AddTransient<IMD5ChecksumService, MD5ChecksumService>();
        #endregion
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