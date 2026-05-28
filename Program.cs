using ExceptionHandlerAndSerilog.WebAPI;
using ExceptionHandlerAndSerilog.WebAPI.Services;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddSerilog();
builder.Services.AddTransient<UserService>();
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();//bununla exceptionları yakala  ve addproblemdetails ile hataları daha da detaylı işle //dependency injection için

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
builder.Host.UseSerilog();
var app = builder.Build();
app.MapDefaultEndpoints();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseExceptionHandler();//her api isteğinde instance ve hata olursa bunu çalıştır
app.MapGet("/", (int age,UserService user) =>
{
    //if (age < 18)
    //{
    //    return Results.BadRequest(new
    //    {
    //        Message = "Kullanıcnın yaşı 18 den büyük olmalı"
    //    });
    //}
    var result = user.Create(age);
    return result.Item1 ? Results.Ok() : Results.BadRequest(result.Item2);
});


app.Run();
