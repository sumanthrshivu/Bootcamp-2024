using JWTLoginAPI.Interface;
using JWTLoginAPI.Services;

namespace JWTLoginAPI
{
    public static  class Config
    {
        public static  void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped(typeof(IUserService<>), typeof(UserService<>));

 
            services.AddCors(options =>
            {
                options.AddPolicy("JWTLoginCors", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

    }
}
