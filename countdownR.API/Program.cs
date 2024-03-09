using countdownR.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCustomSwaggerOptions();

builder.Services.AddCustomDatabase(builder.Configuration)
    .AddMappers()
    .AddRepositories();

builder.Services.AddRequestsValidators();

builder.Services.AddCustomAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
