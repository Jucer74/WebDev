# Modelo Vista Controlador
El patrón de arquitectura de **Modelo-View-Controller** (MVC) divide una aplicación interactiva en tres partes.

1. El modelo:  Contiene los datos y la funcionalidad esencial.
2. Las vistas: Despliegan la información al usuario.
3. Los controladores: Manejan el input. 

Las vistas y los controladores juntos controlan la interfaz con el usuario. 
El mecanismo de cambio-propagación asegura la consistencia de la interfaz con el modelo.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-01.png)

Es importante tener en cuenta que la petición es recibida por el controlador, el cual realiza la demanda del modelo y obtiene los datos, los mezcla con la vista y la retorna al navegador.

En esta sesión vamos a trabajar con este concepto y utilizaremos las plantillas de .Net para facilitar la implementacion de esta arquitectura.

# Creamos nuestro Proyecto
Vamos a crear un nuevo proyecto de tipo MVC para enlazar el llamado a la API.

1. Abrimos Visual Studio y creamos un nuevo proyecto. En este caso seleccionaremos el tipo **Blank Solution**.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-02.png)

3. Seleccionamos el directorio (Proyecto) y llamaremos el proyecto como **WebDev**.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-03.png)

4. Adicionaremos un nuevo proyecto haciendo click derecho sobre la raiz de la solución.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-04.png)

5. Seleccionaremos el tipo **ASP .Net Core Web Application**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-05.png)

6. Le asignamos el nombre WebDev.Application

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-06.png)

7. Seleccionamos el template **Web Application (Model-View-Controller)**. 

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-07.png)

8. Adicionaremos un nuevo modelo que refleje los datos a utilizar. Para ello adicionaremos una clase llamada **User** a la carpeta Models, haciendo click derecho sobre dicho folder.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-08.png)

Ahora establecemos el modelo con los datos correspondientes así:

```csharp
namespace WebDev.Application.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
```
 
9. Cree u nuevo folder llamado **User** y adicione una nueva vista, haciendo click derecho sobre este folder.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-09.png)

10. Seleccionamos el tipo **Razor View**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-10.png)

11. Complete los datos:
	- **View name:** UserListView
	- **Template:** List
	- **Model class:** User (WebDev.Application.Models)  

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-11.png)

12. Adicione un nuevo controlador haciendo click derecho sobre el folder de **Controllers**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-12.png)

13. Seleccione la plantilla **MVC Controller with read/write actions**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-13.png)

14. Asigne el nombre **UsersController.cs** a la nueva clase que se genera.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-14.png)







  

















