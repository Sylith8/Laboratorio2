var builder = WebApplication.CreateBuilder(args);

// Agrega soporte para controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Accede a /Mascota/Registrar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mascota}/{action=Index}/{id?}");

app.Run();