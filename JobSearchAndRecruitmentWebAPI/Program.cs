using BusinessObject.Models;
using BusinessObject;
using DataAccess.DAO;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Service.IRepository;
using Service.Repository;

namespace JobSearchAndRecruitmentWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            static IEdmModel GetEdmModel()
            {
                ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
                builder.EntitySet<JobSeeker>("JobSeeker");
                builder.EntitySet<Employer>("Employer");
                builder.EntitySet<Job>("Job");
                builder.EntitySet<JobApplicant>("JobApplicant").EntityType.HasKey(j => j.JobApplicationId);
                builder.EntitySet<SavedJobs>("SavedJobs").EntityType.HasKey(s => s.SavedJobId);
                builder.EntitySet<Notifications>("Notifications").EntityType.HasKey(n => n.NotificationId);
                builder.EntitySet<Resume>("Resume").EntityType.HasKey(re => re.ResumeId);
                builder.EntitySet<RatingsAndReviews>("RatingsAndReviews").EntityType.HasKey(ra => ra.RatingId);

                return builder.GetEdmModel();
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();

            builder.Services.AddControllers();
            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            builder.Services.AddControllers().AddOData(options =>
            {
                options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100);

                options.EnableQueryFeatures();
                var routeOptions = options.AddRouteComponents("odata", GetEdmModel()).RouteOptions;

                routeOptions.EnableQualifiedOperationCall = true;
                routeOptions.EnableKeyInParenthesis = false;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();

            builder.Services.AddDbContext<PRN231_ProjectDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

            builder.Services.AddScoped<JobSeekerDAO>();
            builder.Services.AddScoped<EmployerDAO>();
            builder.Services.AddScoped<JobDAO>();

            builder.Services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
            builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseCors();
            app.UseODataBatching();
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}