# Services
En esta sección veremos como desacoplar nuestra aplicacion, delegando la responsabilidad del llamado del a API a una libreria de servicos que se encargara de dicha operacion. Para entender mejor este concepto miremos la siguiente imagen.

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-01.png)

# Librería de Servicios
1. Seleccionamos el icono de la solución y hacemos click derecho. en el menú flotante escogemos la opción Add y luego **New Project**.

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-02.png)

2. Cambiamos el tipo por **Library** y filtramos usando las palabras **Class Library** y del listado seleccionamos la que referencia a **Class Library .Net Core**

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-03.png)

Asegurse de que sea **.Net Core** para evitar incompatibilidades

3. Asignele el Nombre de **WebDev.Services** y segurese de estarlo creando en el mismo directorio donde esta toda la aplicación.

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-04.png)

4. Cambie el Nombre del archivo Class1,cs a **ServiceManager.cs**, haciendo click derecho sobre el archivo y selecionando renombrar (Rename)

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-05.png)

5. Ahora vamos a adicionar cambios en la configuracion de nuestro Sitio web para poder configurar la Url de nuestra API de Usuarios. para ellos vamos a agregar una nueva seccion en el archivo de **appsettings.json** asi:

```json
{
   "Logging": {
      "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
      }
   },
   "AllowedHosts": "*",
   "ApiConfiguration": {
      "ApiUsersUrl": "http://loacalhost:432598/api/Users",
      "ApiLoginUrl": "http://loacalhost:432598/api/Login",
   }
}
```

6. Adicionamos una nueva clase al folder de Models llamada **ApiConfiguration.cs**, para poder almacenar ahi los datos de esta nueva Seccion, y le asinamos el siguiente contenido:

```csharp
namespace WebDev.Application.Models
{
  public class ApiConfiguration
  {
    public string ApiUsersUrl { get; set; }
    public string ApiLoginUrl { get; set; }
  }
}
```
Dejamos preparados los servicios necesarios para cargar las Url de nuestra API.

7. Ahora adicionaremos la lectura de la nueva sección, haciendo llamado al servicio de Configure en la clase **Startup**, en el método de **ConfigureServices** , para ello necesitamos incluir el llamado al modelo y luego la carga de la configuración, asi que ejecutaremos los siguientes pasos:

- Adicione el Namespace de los modelos a la lista de los Using al inicio de la clase asi:

```csharp
using WebDev.Application.Models;
```

- Adicione el llamado de la configuración

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddControllersWithViews();
  services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));
}
```
Estos pasos nos habilitan la lectura del archivo de configuración de nuestro proyecto y obtiene el contenido de la sección **ApiConfiguration** y su resultado lo asigna a nuestro modelo del mismo nombre, esto permite que esta configuración pueda ser inyectada a culquier otro objeto, como por ejemplo el controlador de Usuarios de nuestro mismo proyecto.

8. En nuestro controladore de usuarios vamos a adicionar el llamado de la configuración inyectada por nuestra clase StartUp asi:

- Adicione el namespace que maneja las configuracion en la sección de los using:

```csharp
using Microsoft.Extensions.Options;
```
- Incluya la creacion de l variable de configuración local

```csharp
private readonly IOptions<ApiConfiguration> _apiConfiguration;
```

- Modifique el contructor del controlador para recibir la configuración que inyecta la clase **StartUp**.

```csharp
public UsersController(IOptions<ApiConfiguration> apiConfiguration)
```

- Asigne el valor del parámetro que se inyecta a la vlbe de la clase

```csharp
_apiConfiguration = apiConfiguration;
```
- Adicione un punto d einterrupción en esta ultima linea y ejecute de nuevo el proyecto para ver el contenido de las variables que recibe el controlador, esto lo puede hacer presionando la tecla F9 en esta linea, y de igual forma puede eliminar el punto de interrupción.

![Services](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-05/Services-06.png)

   


  