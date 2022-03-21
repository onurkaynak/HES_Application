using FluentValidation.AspNetCore;

namespace CovidApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<Program>();
            });

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<CovidAppDbContext>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<INotifyRepository, NotifyRepository>();
            builder.Services.AddScoped<INotifyService, NotifyService>(); //ViolationType Repository bunun içinde olacak
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>(); //Passport Repository bunun içinde
            builder.Services.AddScoped<IVaccinationInformationRepository, VaccinationInformationRepository>();
            builder.Services.AddScoped<IVaccinationInformationService, VaccinationInformationService>();
            builder.Services.AddScoped<IPassportRepository, PassportRepository>();
            builder.Services.AddScoped<IViolationTypeRepository,ViolationTypeRepository>();
            
            builder.Services.AddScoped<IRiskMapService, RiskMapService>();
            builder.Services.AddScoped<IViolationTypeRepository, ViolationTypeRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMiddleware<JwtMiddleware>();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}