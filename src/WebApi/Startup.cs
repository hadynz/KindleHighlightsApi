using ApplicationCore.DBContext;
using ApplicationCore.Repositories;
using ApplicationCore.Services;
using FileContextCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Mapper;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookContext>(opt => opt.UseFileContextDatabase());

            services.AddScoped<IBookHighlightsRepository, BookHighlightsRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IBookHighlightsService, BookHighlightsService>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IBookMapper, BookMapper>();
            services.AddScoped<IBookHighlightsMapper, BookHighlightsMapper>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
