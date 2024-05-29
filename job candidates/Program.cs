using Microsoft.EntityFrameworkCore;
using job_candidates.Data;
using CandidateApi.Services;
using CandidateApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;

namespace job_candidates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICandidateService, CandidateService>();

            // Register FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<CandidateDtoValidator>();
            builder.Services.AddFluentValidationAutoValidation();


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
            using var scope = app.Services.CreateScope();
            var servicces = scope.ServiceProvider;
            try
            {
                var context = servicces.GetRequiredService<ApplicationDbContext>();
                context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = servicces.GetService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during migration");
            }
            app.Run();
        }
    }
}