# Usando React
En esta sesión veremos la implementación de nuestros formularios utilizando la libreriá de REACT-JS y trabajaremos el CRUD de Usuarios tal como se realizo en el proyecto anterior pero ahora con este nuevo framework.

## Requisitos
1. Primero que todo necesitamos instalar [NodeJS](https://nodejs.org/es/).
2. Creamos una carpeta nueva, llamada **ReactWeb**, al mismo nivel de donde esta nuestro proyecto de **API**.

![ReactWeb](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-07/ReactWeb-01.png)

3. En una terminal o ventana de comandos navegamos hasta esta carpeta (ReactWeb) y ejecutamos el siguiente comando para crear nuestra aplicación React.

```
npx create-react-app usermanagerapp 
```

**NOTA: ** Tenga presente ue esta operación puede tardar varios minutos.

4. Ingresamos a la carpeta de nuestro proyecto y abrimos el proyecto en Visual Studio Code, para ellos podemos ejecutar el comando **Code .** en la sesión actual.

```
cd usermanagerapp
code .
```
5. Dentro de Visual Studio Code, abrimos una nueva terminal , para ello vamos a la opción **Terminal** del menu y escogemos la opción de **New Terminal**.

![ReactWeb](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-07/ReactWeb-02.png)

6. En esta nueva ventana ejecutamos el comando **npm start** para iniciar nuestra aplicación 

![ReactWeb](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-07/ReactWeb-03.png)

7. si todo quedo funcionando corectamente usted podra ver una ventana con el logo de React, con una aplicación ejecutandose sobre **http://localhost:3000**.

![ReactWeb](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-07/ReactWeb-04.png)

**Nota:**
Puede consultar mas información sobre la creación de una aplicacion react enel proyecto [create-react-app](https://github.com/facebook/create-react-app).

En este punto puede cerrar el navegador para continuar.

8. Ahora dentro de la consola de VS Code vamos instalar los paquetes necesarios para nuestra applicación:
 
Para los Estilos y los componentes

```
npm install -save bootstrap 
npm install -save react-bootstrap
```

Para las Ventanas Modales

``` 
npm install -save reactstrap
```
 
Para el redireccionamiento del Menu
```
npm install -save react-router-dom

```

Para los llamados a la API
``` 
npm install -save axios
```

Para los Iconos usaremos Font Awesome

```
npm install -save @fortawesome/fontawesome-svg-core
npm install -save @fortawesome/free-solid-svg-icons
npm install -save @fortawesome/react-fontawesome
```

Para el manejo de las tablas usaremos Datatables

```
npm install -save datatables.net-dt
npm install -save jquery
```


# Iniciemos el Proyecto
Nuestro proyecto inicia con el componente **App** que se define en el archivo **App.js**, por lo cual pasaremos a editarlo para incluir lo que necesitamos para nuestra aplicación.

Iniciaremos importando las librerias y los componentes necesarios para construir  el menú.

Esta definición de componentes las puede obtener en el sitio [react-Bootsrap](https://react-bootstrap.github.io/)

## El Menu
1. Adicione las librerias de Bootstrap y los componentes de NavBar

```js
import React from 'react';
import './App.css';
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container, Image, Navbar, Nav } from 'react-bootstrap';
```

2. Modifique el contenido de la función **App** para incluir el menú de nuestra aplicación. para ello puede incluir la seccion **nav** desde el archivo **NavBar.html** que se encuentra en el directorio de **plantillas** de este repositorio o buscar el componente dentro de las librerias de react-bootstrap así:




