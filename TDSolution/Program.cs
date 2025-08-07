using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TDSolution.Common;
using TDSolution.Models;
using TDSolution.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Additional function

#region Autofac

// Using AutoFac for setup Interface depend to Service auto
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//setup sqlite
builder.Services.AddDbContext<TDSolutionEntities>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlite("Data Source=db_order.db");
});

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    var assembly = Assembly.GetExecutingAssembly();

    container.RegisterGeneric(typeof(Repository<>))
             .As(typeof(IRepository<>))
             .InstancePerLifetimeScope();

    ///Repository & Services
    container.RegisterAssemblyTypes(assembly)
        .Where(t => t.Namespace != null &&
                   (t.Namespace.Contains("Services") || t.Namespace.Contains("Repositories")))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
});

#endregion Autofac

#region Mapper

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

#endregion Mapper

#region Authen JWT

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Issuer",
            ValidAudience = "Audience",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("my_hardcoded_super_secret_key_12345"))
        };
    });

#endregion Authen JWT

#endregion Additional function

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Thêm security definition
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token vào đây theo format: **Bearer &lt;your_token&gt;**"
    });

    // Gắn security requirement cho toàn bộ API
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();