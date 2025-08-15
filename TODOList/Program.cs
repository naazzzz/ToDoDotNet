using DotNetEnv;
using DotNetEnv.Configuration;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TODOList.Configurations;
using TODOList.Extension;
using TODOList.Mappings.User;
using TODOList.Validators;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.AddDotNetEnv("../.env", LoadOptions.TraversePath()).Build();

builder.Services.AddControllers().
    AddFluentValidation(fv => 
        fv.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>()).
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(configuration.GetValue<string>("POSTGRES_CONNECTION_STRING")));
builder.Services.AddServicesWithAttribute();
builder.Services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddEndpointsApiExplorer();
    
SwaggerConfiguration.AddSwaggerOptions(builder);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    SwaggerConfiguration.AddDevelopSwaggerOptions(builder, app);
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseAuthorization();

app.MapStaticAssets();

app.Run();
