using ExceptionHandlerAndSerilog.WebAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<UserService>();

builder.Services.AddOpenApi();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

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
