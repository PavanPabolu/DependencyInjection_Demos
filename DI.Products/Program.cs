using DI.Basic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//In real-time scenarios:
//builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.AddScoped<ILoggingService, LoggingService>();
//builder.Services.AddSingleton<ICacheProvider, CacheProvider>();

builder.Services.AddTransient<IProductService, AmazonProductService>();


/*
//In a scenario where a service is the Production and other is in testing phase which needs to replace in future.
IWebHostEnvironment env = builder.Environment;
if (env.IsProduction())
    builder.Services.AddTransient<IProductService, EbayProductService>();
else
    builder.Services.AddTransient<IProductService, AmazonProductService>();
*/




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
