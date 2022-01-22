using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RestaurantTemplate.BusinessLayer.Services.MenuServices;
using RestaurantTemplate.BusinessLayer.Services.ReviewServices;
using RestaurantTemplate.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSetting>(
    builder.Configuration.GetSection(nameof(DatabaseSetting)));

builder.Services.AddSingleton<IDatabaseSetting>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IMenuServices, MenuServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();