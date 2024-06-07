using RedSocial.Application.UseCases;
using RedSocial.Core.Interfaces;
using RedSocial.Core.Services;
using RedSocial.Infrastructure.Repositories;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
        .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<IPostRepository, InMemoryPostRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<PostService>();
        services.AddScoped<CreatePostUseCase>();
        services.AddScoped<FollowUserUseCase>();
        services.AddScoped<GetDashboardUseCase>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}