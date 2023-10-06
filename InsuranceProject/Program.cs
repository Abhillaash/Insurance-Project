

global using InsuranceProject.Exceptions;
using InsuranceProject.Middleware;
using InsuranceProject.Model;
using InsuranceProject.Repository;
using InsuranceProject.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ModelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(Entityrepository<>));


builder.Services.AddTransient<IClaimService, ClaimService>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IInsurancePlanService, InsurancePlanService>();
builder.Services.AddTransient<IInsuranceSchemeService, InsuranceSchemeService>();
builder.Services.AddTransient<IInsurancePolicyService, InsurancePolicyService>();
builder.Services.AddTransient<ISchemeDetailsService, SchemeDetailsService>();
builder.Services.AddTransient<IQueryService, QueryService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IAgentService, AgentService>();

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
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
