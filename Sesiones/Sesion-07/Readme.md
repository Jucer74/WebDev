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

8. Ahora dentro de la consola de VS Code vamos ejecutar el siguiente comando: 

```
npm i bootstrap react-bootstrap reactstrap axios
```

Con esto podemos instalar los paquetes necesarios para nuestra applicación:

- **Bootstrap**: Para el manejo de nuestros estilos y front de la aplicación.
- **React-Bootstrap**: Para los componentes bootstrap dentro de React 
- **Reactstrap**: Para el Uso de Ventanas Modales.
- **Axios**: Para el llamado asincronico de nuestra **API**.


# Iniciemos el Proyecto
Nuestro proyecto inicia con el componente **App** que se define en el archivo **App.js**, por lo cual pasaremos a editarlo para incluir lo que necesitamos para nuestra aplicación.

Iniciaremos importando las librerias y los componentes necesarios para construir  el menú.

Esta definición de componentes las puede obtener en el sitio [react-Bootsrap](https://react-bootstrap.github.io/)

## El Menu
1. Adicione las librerias de Bootstrap y los componentes de NavBar

```js
import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstap.min.css';

```


2.
