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

9. Adicione un nuevo controlador haciendo click derecho sobre el folder de **Controllers**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-09.png)

10. Seleccione la plantilla **MVC Controller with read/write actions**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-10.png)

11. Asigne el nombre **UsersController.cs** a la nueva clase que se genera.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-11.png)

12. Adicione el llamado al nuevo controlador modificando la clase **Startup**, adicionando un nuevo **EndPoint** con las siguientes lineas en la function **Configure**.

```csharp
// Users
endpoints.MapControllerRoute(
  name: "Users",
  pattern: "{controller=Users}/{action=Index}/{id?}");
```
De esta forma se establece que la accion inicial para el controlador de **Users** es **Index**.

Así nos queda el la funcion **Configure**. 
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  if (env.IsDevelopment())
  {
    app.UseDeveloperExceptionPage();
  }
  else
  {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
  }
  app.UseHttpsRedirection();
  app.UseStaticFiles();

  app.UseRouting();

  app.UseAuthorization();

  app.UseEndpoints(endpoints =>
  {
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
	// Users
    endpoints.MapControllerRoute(
      name: "Users",
      pattern: "{controller=Users}/{action=Index}/{id?}");
  });
}
```

13. Volvemos al controlador y hacemos click derecho sobre Action **Index** para que adicionemos la vista correspondiente, seleccionando la opcion **Add View...**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-12.png)

14. Seleccionamos el tipo **Razor View**

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-13.png)

15. Complete los datos:
	- **View name:** UserListView
	- **Template:** List
	- **Model class:** User (WebDev.Application.Models)  

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-14.png)

Esta accion adiciona un nuevo folder llamado **Users** dentro del nodo de **Views** e internamente se crea la vista definida **UserListView.cshtml**.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-15.png)

16. Volvemos al Controlador y vamos a simular la respuesta para validar nuestra ejecución, así:

a. Adiciones los las librerias para manejo de lista y para el uso del modelo

```csharp
using System.Collections.Generic;
using WebDev.Application.Models;
```

b. Modifique la acción **Index** estableciendo el tipo de metodo a **HttpGet**,  tambien simule la respuesta adicionando una lista de Users y establezca la vista y asigne el objeto del modelo a la vista, así: 

```csharp
// GET: UsersController
[HttpGet]
public ActionResult Index()
{
  // Mock User List Response
  List<User> userList = new List<User>()
  {
    new User{Id=1, Email="Julio.Robles@email.com", Name="Julio Robles", Username="jrobles", Password="Password"},
    new User{Id=2, Email="Pilar.Lopez@email.com", Name="Pilar Lopez", Username="plopez", Password="Password"},
    new User{Id=3, Email="Felipe.Daza@email.com", Name="Felipe Daza", Username="fdaza", Password="Password"},
  };

  // Set the View and the Object Model
  return View("UserListView", userList);
}
```
c. Ejecute la aplicación presionando **F5** y valide los resultados, redireccionando la ruta a **/Users**.

![MVC](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-04/MVC-16.png)

En este punto podemos aplicar los cambios aprendidos en la sesión anterior y mejorar nuestra vista.








  

















