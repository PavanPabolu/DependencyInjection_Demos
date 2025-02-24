using DI.KeyServices.WebAPI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<INotificationService, EmailNotificationService>();
//builder.Services.AddScoped<INotificationService, SMSNotificationService>();

builder.Services.AddKeyedScoped<INotificationService, EmailNotificationService>(NotificationType.Email); //"email"
builder.Services.AddKeyedScoped<INotificationService, SMSNotificationService>(NotificationType.SMS);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGet("notifications/email", (INotificationService service) =>
//{
//    return service.Send();
//});

app.MapGet("notifications/email", ([FromKeyedServices(NotificationType.Email)] INotificationService service) =>
{
    return service.Send();
});

app.MapGet("notifications/sms", ([FromKeyedServices(NotificationType.SMS)] INotificationService service) =>
{
    return service.Send();
});


app.Run();
