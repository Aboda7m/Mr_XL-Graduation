using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Add this for Entity Framework Core
using Mr_XL_Graduation.Services; // Ensure this using directive is present
using Mr_XL_Graduation.Data; // Add this for your Data (DbContext)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<UserService>(); // Change from Singleton to Scoped

// Register the DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the timeout as needed
    options.Cookie.HttpOnly = true; // The cookie should be accessible only via HTTP requests
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

// Optionally, you can add database migration services like this:
// builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // This can help in development to show database-related exceptions
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session before the endpoints
app.UseSession(); // Add this line to enable session

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
