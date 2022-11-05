using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddLocalization(options => options.ResourcesPath = "BlazorSchoolResources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // You can set the default language using the following method:
    // options.SetDefaultCulture("fr");
    options.AddSupportedCultures(new[] { "en", "fr" });
    options.AddSupportedUICultures(new[] { "en", "fr" });
    options.RequestCultureProviders = new List<IRequestCultureProvider>() { new CookieRequestCultureProvider() };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();