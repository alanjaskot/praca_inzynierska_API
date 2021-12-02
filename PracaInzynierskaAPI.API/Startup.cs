using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.DataBase.Repository.Author;
using PracaInzynierskaAPI.DataBase.Repository.Book;
using PracaInzynierskaAPI.DataBase.Repository.Book_Author;
using PracaInzynierskaAPI.DataBase.Repository.Book_User;
using PracaInzynierskaAPI.DataBase.Repository.Category;
using PracaInzynierskaAPI.DataBase.Repository.Comment;
using PracaInzynierskaAPI.DataBase.Repository.ImageCover;
using PracaInzynierskaAPI.DataBase.Repository.Language;
using PracaInzynierskaAPI.DataBase.Repository.NLog;
using PracaInzynierskaAPI.DataBase.Repository.Publisher;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierska.Application.Services.Book;
using PracaInzynierska.Application.Services.Author;
using PracaInzynierska.Application.Services.Book_Author;
using PracaInzynierska.Application.Services.Book_User;
using PracaInzynierska.Application.Services.Category;
using PracaInzynierska.Application.Services.Comment;
using PracaInzynierska.Application.Services.ImageCover;
using PracaInzynierska.Application.Services.Language;
using PracaInzynierska.Application.Services.NLog;
using PracaInzynierska.Application.Services.Publisher;
using PracaInzynierska.Application.Services.User;
using PracaInzynierska.Application.Services.UserPermission;
using PracaInzynierska.Application.Mapper;
using Microsoft.EntityFrameworkCore;
using PracaInzynierskaAPI.DataBase.Repository.User;
using PracaInzynierskaAPI.DataBase.Repository.UserPermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Collections.Generic;
using PracaInzynierskaAPI.API.JWT;
using System;
using Autofac;
using System.Reflection;

namespace PracaInzynierskaAPI.API
{
    public class Startup
    {
        public static IContainer Container { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PInzDataBaseContext>(options => options
            .UseNpgsql("Host=localhost;Port=1511;Database=p_inz;Username=admin;Password=postgres "));

            services.AddSingleton(AutoMapperConfig.InitMap());

            services.AddScoped<IPInzDataBaseContext, PInzDataBaseContext>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBook_AuthorRepository, Book_AuthorRepository>();
            services.AddScoped<IBook_UserRepository, Book_UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IImageCoverRepository, ImageCoverRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<INLogRepository, NLogRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBook_AuthorService, Book_AuthorService>();
            services.AddScoped<IBook_UserService, Book_UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IImageCoverService, ImageCoverService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<INLogService, NLogService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:5001")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Praca Inzynierska API",
                    Description = "Api do pracy in¿ynierskiej",
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' (space) and then your token in the text input below.\r\n\r\nExample: \"Bearer tokenValue\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddJwt();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
             PInzDataBaseContext dataBaseContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PracaInzynierskaAPI.API v1"));
            }
            
            app.UseStaticFiles();
            app.UseForwardedHeaders();
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Console.WriteLine("Migration start");
            dataBaseContext.Database.Migrate();
            Console.WriteLine("Migration end");

            var builder = new ContainerBuilder();

            var assembliy = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembliy)
                  .AsImplementedInterfaces();

            builder
                .RegisterType<PInzDataBaseContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserPermissionService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();



            Container = builder.Build();

        }
    }
}
