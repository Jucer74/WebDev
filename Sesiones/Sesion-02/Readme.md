# Creación de la API
Utilizando **Visual Studio 2019** vamos a crear la API para poder efectuar las acciones sobre la tabla de usuarios.

## Crear el proyecto
**1.** Seleccione crear nuevo proyecto.
**2.** En el lenguaje filtre por **C#**, en los tipos de proyectos filtre por **Web** y seleccione la pantilla **ASP.NET Core Web Application**.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-01.png)

**3.** Asigne el nombre **WebDev.Api** para el proyecto y en la ruta escoja el directorio **Proyecto/Api** y presione el boton de **Create**.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-02.png)

**4.** Seleccione el tipo de proyecto, en este caso **Web Application**

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-03.png)


## Sincronizar
En este punto puede sincronizar su rama con la rama de **develop** y abrir el proyecto en lugar de crearlo.


# El Modelo
Ahora vamos a pasar a referencia el Modelo, que es la representación de la tabla en una clase que podemos manipular dentro de .Net. Para ellos vamos a ejecutar los siguientes pasos:

**1.** A nivel del proyecto cree la carpeta **Model**, esto lo puede hacer seleccionado el nodo principal del proyecto **WebDeb.Api** y haciendo click derecho seleccionar **Add/Folder** del menú flotante.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-04.png)

**2.** En la Nueva carpeta **Model** haga click derecho y selecciona **Add/Class**.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-05.png)

**3.** Cambio el nombre de la clase a **User**, eneste cas en singular ya que va a hacer referencia a un elemento de la tabla de Users a la vez.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-06.png)

**4.** Complemente la clase de la siguiente forma:

```csharp
namespace WebDev.Api.Model
{
  using System.ComponentModel.DataAnnotations;

  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Username { get; set; }
  }
}
```
Se debe terne presente que el nombre de los campos deben ser exactamente iguales a como aparecen en la tabla de la base de datos, es decir nombre y tipo.

# El Contexto
Ahora adicionemos el contexto que es la representacion de lo que podria ser la base de datos, es decir se crean estructuras se Set de datos de los tipos definidos en el modelo, ademas de identificar la cadena de conexión y el tipo de base de datos que vamos usar. para ello ejecutemos los siguientes pasos:

**1.** Adicionemos uns nueva carpeta llamada Context a nuestro proyecto, de igual forma como hicimos la del modelo.
![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-07.png)

**2.** Sobre esta nueva carpeta adicionamos una nueva clase 
![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-08.png)

**3.** Le asignamos el nombre de **AppDbContext**.
![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-09.png)

**4.** En este punto y antes de entrar a complementar el Contexto vamos a instalar el Entity Framework Core, que es la libreria que nos permite mapear de forma directa el modelo con los objetos de la base de datos. Para ello ejecutaremos los siguientes pasos:

**a.** Sobre el Proyecto en la sección de **Dependencies** hacemos click derecho y en el menú flotante seleccionamos la opción **Manage NuGet Packages...**

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-10.png)

**b.** En el administrador seleccionamos la opcion **Browse** y en la barra de busqueda escribimos **Entity Framework Core**. en los resultados de la busqueda seleccionamos la opción correspondiente en el panel derecho presionamos el botón de **install**. 

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-11.png)

**c.** Confirme la lista de componentes a descargar e instalar.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-12.png)

**d.** Acepte la licencia Open Source de instalación y espere a que el proceso finalice.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-13.png)

**e.** Al finalizar debe obtener una respuesta similar a esta, sin reporte de errores, para garantizar que todo quedo bien instalado.

![Proyecto](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-02/Proyecto-14.png)

**5.** Ahora procedemos a complementar la clase AppDbContext de la siguiente manera:



