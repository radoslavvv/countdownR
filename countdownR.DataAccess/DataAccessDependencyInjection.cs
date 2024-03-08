//using countdownR.DataAccess.Configurations;
//using countdownR.DataAccess.Identity;
//using countdownR.DataAccess.Persistance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Identity;

//namespace countdownR.DataAccess;
//public class DataAccessDependencyInjection
//{
//    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
//    {
//        //services.AddDatabase(configuration);

//        //services.AddIdentity();

//        //services.AddRepositories();

//        return services;
//    }

//    private static void AddRepositories(this IServiceCollection services)
//    {
//        //services.AddScoped
//    }

//    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
//    {
//        //var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

//        //services.AddDbContext<DatabaseContext>(options =>
//        //{
//        //    options.UseSqlServer(configuration.GetConnectionString("");
//        //});
//    }

//    private static void AddIdentity(this IServiceCollection services)
//    {
//        //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn);
//    }
//}
