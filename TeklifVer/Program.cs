using TeklifVer.Business.DependencyResolvers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIOC(builder.Configuration.GetConnectionString("MSSQLConnection"));
builder.Services.MappingDependencies();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Cache-Control header'ý ayarlama
        ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=600");
    }
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();
