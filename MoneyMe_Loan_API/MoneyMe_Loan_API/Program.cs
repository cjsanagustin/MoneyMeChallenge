using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;
using MoneyMe_Loan_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
            options => options.UseCompatibilityLevel(110)), ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
                      policy =>
                      {
                          policy.WithOrigins((builder.Configuration.GetSection("AllowedThirdPartyDomains").Value + "").Split(","))
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });

    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

});

builder.Services.AddControllers();

#region Add Data Access Services
builder.Services.AddTransient<ISystemConfigurationService, SystemConfigurationService>();
builder.Services.AddTransient<ILoanApplicationService, LoanApplicationService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ILoanTypeService, LoanTypeService>();
builder.Services.AddTransient<IBlacklistedService, BlacklistedService>();
#endregion

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable the configured CORS policy
app.UseCors("AllowAll"); // Use the policy defined above

app.UseAuthorization();

app.MapControllers();

app.Run();
