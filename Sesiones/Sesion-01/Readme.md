# Creación de la base de datos
Usando Microsoft **SQL Server Management Studio (SSMS)**, creamos una nueva base de datos  así:

**1.** Haga click derecho sobre el nodo de databases y seleccione la opción **New Database...**

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-01.png)

**2.** Asigne el nombre **UsersDB** a la base de datos.

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-02.png)

**3.** Expanda la base de datos **UsersDB**, luego haga click derecho sobre el nodo **Tables** y escoja la opcion **New** y ahi la opción **Table...**.

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-03.png)

**4.** Llene los campos ssgún la siguiente especificación:

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-04.png)

	Id			: 	int				Not Null
	Email		:	Varchar(255)	Not Null
	Name		:	Varchar(255)	Not Null
	Password	:	Varchar(255)	Not Null
	Username	:	Varchar(255)	Not Null
 
**6.** Seleccione el campo **Id** y en las propiedades escoja la propiedad **Identity Especification** y en el campo **(IsIdentity)** escoja la opción **True**.

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-05.png)

**7.** Seleccione el campo **Id** y haciendo click derecho escoja la opción **Set Primary Key**

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-06.png)

**8.** Guarde los cambios presionando las teclas **CTRL + S** o haga click en el disquete para guardar la base de datos y darle un nombre.

**9.** Asigne el nombre **User** para la tabla.

![New Database](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-01/Database-07.png)

**10.** Por último presione la tecla **F5** para refrescar los datos y ver la tabla creada.


# Insertar Datos

**1.** Abra el archivo **Ins_Users.sql** presionando las teclas **CTRL + O** y ejecute el script.

**2.** Luego presione las teclas **CTRL + N** y ejecute el siguiente script para mostrar los usuarios.

```SQL
SELECT * FROM [User]
GO
```

