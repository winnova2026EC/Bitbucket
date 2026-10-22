
var builder = WebApplication.CreateBuilder(args);

// Registrar servicios MVC
builder.Services.AddControllersWithViews();

// Registrar el servicio compartido de exportación
builder.Services.AddSingleton<Grupo4.Services.RegistroExportacionService>();

var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Ruta principal del sistema
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}"
);

app.Run();
