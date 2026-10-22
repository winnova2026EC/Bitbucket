# Sistema de Packing List y Despacho de Exportación --- Grupo 4

Aplicación web desarrollada en C# con ASP.NET Core MVC para gestionar
vendedores, Packing Lists, inspecciones temporales de lotes y el resumen
del despacho de exportación.

## Requisitos

-   Windows con Visual Studio instalado, o una terminal compatible.
-   SDK de .NET compatible con el `TargetFramework` definido en
    `Grupo4.csproj` (el proyecto actual se ejecuta con .NET 10).
-   Navegador web actualizado.

## Abrir en Visual Studio

1.  Descarga o clona el repositorio del proyecto.
2.  Abre la solución `Grupo4.sln` en Visual Studio. Si no hay archivo de
    solución, abre `Grupo4.csproj`.
3.  Espera a que Visual Studio restaure las dependencias de NuGet.
4.  En el Explorador de soluciones, confirma que el proyecto `Grupo4`
    esté establecido como proyecto de inicio.
5.  Ejecuta con el botón verde **https** o pulsa `F5`.

## Ejecutar desde la terminal

Abre una terminal en la carpeta que contiene `Grupo4.csproj` y ejecuta:

``` bash
dotnet restore
dotnet build
dotnet run
```

La consola mostrará las direcciones locales en las que se inició la
aplicación, por ejemplo `https://localhost:7033` o
`http://localhost:5016`. Abre en el navegador la dirección HTTPS que
aparezca en tu consola; los puertos pueden variar según la
configuración.

Para detener la aplicación, vuelve a la terminal y pulsa `Ctrl + C`.

## Módulos principales

-   **Vendedor:** registro de información comercial.
-   **Packing List:** registro de datos del envío y su destino.
-   **Inspección temporal:** cálculo de antigüedad y clasificación del
    lote.
-   **Despacho de exportación:** resumen de inspecciones y control de
    capacidad configurada.
-   **Inicio:** menú de navegación entre módulos.

## Estructura del proyecto

``` text
Grupo4/
├── Controllers/
├── Models/
├── Services/
├── Views/
├── Program.cs
├── appsettings.json
└── Grupo4.csproj
```

## Consideraciones importantes

-   La aplicación usa actualmente un servicio en memoria para compartir
    registros durante la ejecución.
-   Los datos registrados se pierden al detener o reiniciar la
    aplicación.
-   La persistencia en una base de datos no está implementada en esta
    versión.
-   La compilación correcta no sustituye las pruebas funcionales. Antes
    de una demostración, recorre el flujo completo: registrar un Packing
    List, asociar una inspección y consultar el despacho.
-   Los umbrales de clasificación temporal deben verificarse contra los
    requisitos de negocio aplicables al producto exportado.

## Comandos útiles

  Objetivo                 Comando
  ------------------------ ----------------------------------------
  Restaurar dependencias   `dotnet restore`
  Compilar el proyecto     `dotnet build`
  Ejecutar la aplicación   `dotnet run`
  Ejecutar y reconstruir   `dotnet run` (compila si es necesario)
  Detener la ejecución     `Ctrl + C`
