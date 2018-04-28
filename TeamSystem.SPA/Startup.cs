namespace TeamSystem.SPA
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TeamSystem.Data;
    using TeamSystem.Service.Match.Implementations;
    using TeamSystem.Service.Match.Interfaces;
    using TeamSystem.Service.News.Implementations;
    using TeamSystem.Service.News.Interfaces;
    using TeamSystem.Service.Player.Implementations;
    using TeamSystem.Service.Player.Intefaces;
    using TeamSystem.Service.PlayerRole.Implementations;
    using TeamSystem.Service.PlayerRole.Intefaces;
    using TeamSystem.Service.Team.Implementation;
    using TeamSystem.Service.Team.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TeamSystemDbContext>(options => options
              .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               o => o.UseRowNumberForPaging()));

            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IPlayerRoleService, PlayerRoleService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IMatchService, MatchService>();

            services.AddCors();
            services.AddRouting(routing => routing.LowercaseUrls = true);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://teamsystem.azurewebsites.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                );

            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
