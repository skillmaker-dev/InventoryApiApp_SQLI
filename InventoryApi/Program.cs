using Application;
using Infrastructure;
using InventoryApi;

/*
 * 
 * Inventory API for CRUD Operations.
 * Created by Anas Chahid as part of the E-Challenge 2023 test made by SQLI.
 * 
 */
var builder = WebApplication.CreateBuilder(args);


// Register services.

builder.Services.AddPresentation()
                .AddInfrastructure()
                .AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enforcing api to use https.
app.UseHttpsRedirection();

// Enabling authorization capabilities.
app.UseAuthorization();

// Adding endpoints for controller actions.
app.MapControllers();

// Running the application
app.Run();
