using Microsoft.Extensions.Configuration;
using KrishnyanAstro.Shared;
using System.Data;
using KrishnyanAstro.Shared.Extensions;
using static System.Net.Mime.MediaTypeNames;
using KrishnyanAstro.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAdoNetHelper(builder.Configuration);


var app = builder.Build();

async Task PerformStartupDatabaseCheck(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var adoNetHelper = scope.ServiceProvider.GetRequiredService<AdoNetHelper>();

    try
    {
        var result = await adoNetHelper.ExecuteScalarAsync(
            "SELECT COUNT(*) FROM Test",
            System.Data.CommandType.Text
        );
        Console.WriteLine($"User count: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during startup database check: {ex.Message}");
        // Optionally, you could throw an exception here to prevent the application from starting
        // throw;
    }


    var (users, orders) = await adoNetHelper.ExecuteReaderMultipleResultsAsync<List<Test>, List<Test>>(
                "SELECT * FROM Test;SELECT * FROM Test;",
                CommandType.Text,
                reader =>
                {
                    var users = new List<Test>();
                    while (reader.Read())
                    {
                        users.Add(new Test
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1) 
                        });
                    }
                    return users;
                },
                reader =>
                {
                    var orders = new List<Test>();
                    while (reader.Read())
                    {
                        orders.Add(new Test
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }
                    return orders;
                }
            );
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

await PerformStartupDatabaseCheck(app.Services);

app.Run();
