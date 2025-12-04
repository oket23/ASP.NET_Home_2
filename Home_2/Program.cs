using Home_2.Interfaces.Repositories;
using Home_2.Interfaces.Services;
using Home_2.Repositories;
using Home_2.Services;

namespace Home_2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<IValidationService, ValidationService>();
        builder.Services.AddSingleton<IAuthorsRepository, AuthorsRepository>();
        builder.Services.AddSingleton<IAuthorsService, AuthorsService>();
        builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
        builder.Services.AddSingleton<IBooksService, BooksService>();
        
        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}

//TODO
//Написати контроллери