## Requisitos

- **.NET Core SDK**: Asegúrate de tener instalado el SDK de .NET Core para poder ejecutar los comandos.
- **SQL Server**: Configura una instancia de SQL Server para la base de datos.

## Pasos de Configuración y Ejecución

### 1. Configuración de la conexión a SQL Server

1. Abre el archivo de configuración en la siguiente ruta: `/API/appsettings.json`.
2. Dentro del archivo, ubica la sección de configuración de la conexión a la base de datos y ajusta los parámetros de conexión (como `Server`, `Database`, `User Id`, `Password`) para que coincidan con tu instancia de SQL Server.

   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
   }
   ```

### 2. Actualización de la Base de Datos

1. Abre una terminal en la carpeta `/API`.
2. Ejecuta el siguiente comando para aplicar las migraciones de Entity Framework y actualizar la base de datos:

   ```bash
   dotnet ef database update
   ```

### 3. Ejecución de la API en Modo HTTPS

1. En la misma terminal, ejecuta el siguiente comando para iniciar la API en el perfil HTTPS:

   ```bash
   dotnet run --launch-profile https
   ```

   Esto iniciará la API en modo seguro (HTTPS).

## Notas Adicionales

- Asegúrate de que el puerto especificado en el perfil HTTPS no esté en uso por otros servicios.
- Si necesitas cambiar el perfil de lanzamiento o ajustar configuraciones adicionales, revisa el archivo `launchSettings.json` en la carpeta `/API/Properties`.
