using Microsoft.EntityFrameworkCore;
using job_candidates.Data;
using CandidateApi.Services;
using CandidateApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

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

            app.Run();
        }
    }
}