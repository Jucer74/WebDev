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

**NOTA:** Tenga presente ue esta operación puede tardar varios minutos.

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
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container, Image, Navbar, Nav } from 'react-bootstrap';
```

2. Modifique el contenido de la función **App** para incluir el menú de nuestra aplicación. para ello puede incluir la seccion **nav** desde el archivo **NavBar.html** que se encuentra en el directorio de **plantillas** de este repositorio o buscar el componente dentro de las librerias de react-bootstrap así:

```js
import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <nav class="navbar navbar-expand-sm navbar-dark bg-dark mb-3">
          <div class="container">
              <a class="navbar-brand" href="#">UserManagerApp</a>
              <div class="navbar-collapse">
                  <ul class="navbar-nav">
                      <li class="nav-item">
                          <a class="nav-link" href="#">Home</a>
                      </li>
                  </ul>
              </div>
              <div class="text-right">
                  <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Login</a>
                    </li>
                  </ul>
              </div>
          </div>
      </nav>
    </div>
  );
}

export default App;
```

3. Ejecute de nuevo la aplicación con **npm start** en la linea de comandos y verifique su funcionamiento.

![ReactWeb](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-07/ReactWeb-05.png)

Con esto vemos que podemos utilizar cualquier componente **HTML** que sea modifque con **Bootstrap** directamente en un aplicación **React**.

4. Ahora veremos como utlizar componentes **react-bootstrap** que combinan las mismas caracteristicas, para ellos incluiremos los componentes **Container**,   
**Navbar** y **Nav**.

```js
import { Container, Navbar, Nav } from 'react-bootstrap';
```

5. Reemplace la **Navbar** actual por los siguientes componentes **react-boostrap** así:

```js
function App() {
  return (
    <div className="App">
      <Container>
        <Navbar bg="dark" variant="dark" >
          <Navbar.Brand href="/">UserManagerApp</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav"/>
          <Navbar.Collapse id="basic-navbar-nav">        
            <Nav className="mr-auto">
              <Nav.Item><Nav.Link href="/Home">Home</Nav.Link></Nav.Item>
              <Nav.Item><Nav.Link href="/Users">Users</Nav.Link></Nav.Item>
            </Nav>
            <Nav alignment="right">
              <Nav.Item><Nav.Link href="/Login" >Login</Nav.Link></Nav.Item>
            </Nav>
          </Navbar.Collapse>        
        </Navbar>
      </Container>
    </div>
  );
}
```
## Los componentes
Ahora pasaremos a hacer cada uno de los componentes que reflejan las acciones del sistema.

1. Cree uno folder llamado **components** dentro de la carpeta de **src** y dentro de este crearemos las nuevas paginas.

### La página de Home
Cree un nuevo archivo llamado **Home.js** y asignele el siguiente contenido:

```js
import React from 'react';

export const Home = () => (
  <h1>Home</h1>
)
```

### La página de Login
Cree un nuevo archivo llamado **Login.js** y asignele el siguiente contenido:

```js
import React from 'react';

export const Login = () => (
  <h1>Login</h1>
)
```

### La página de Usuarios 
Cree un nuevo archivo llamado **Users.js** y asignele el siguiente contenido:

```js
import React from 'react';

export const Users = () => (
  <h1>Users</h1>
)
```

### La página de No coincidencias
Cree un nuevo archivo llamado **Users.js** y asignele el siguiente contenido:

```js
import React from 'react';

export const NoMatch = () => (
  <h1>No Match Found</h1>
)
```

### La barra de Navegación
Ahora pasaremos el contenido de la barra de navegación a un  nuevo archivo llamado **NavigationBar.js** así:

```js
import React from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';

export const NavigationBar = () => (
  <Container>
    <Navbar bg="dark" variant="dark" >
      <Navbar.Brand href="/">UserManagerApp</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav"/>
      <Navbar.Collapse id="basic-navbar-nav">        
        <Nav className="mr-auto">
          <Nav.Item><Nav.Link href="./Home">Home</Nav.Link></Nav.Item>
          <Nav.Item><Nav.Link href="/Users">Users</Nav.Link></Nav.Item>
        </Nav>
        <Nav alignment="right">
          <Nav.Item><Nav.Link href="/Login" >Login</Nav.Link></Nav.Item>
        </Nav>
      </Navbar.Collapse>        
    </Navbar>
  </Container>
)
```

## La pagina de Layout
Cree un nuevo archivo llamado **Layout.js** al mismo nivel del archivo **App.js** y asignele el siguiente contenido:

```js
import React from 'react';
import { Container } from 'react-bootstrap';

export const Layout = (props) => (
  <Container>
    {props.children}
  </Container>
)
```

Este nos permitira mostrar el contenido de las demás páginas o componentes renderizados dentro de este nuevo componente. 


## Integremos los componentes
Ahora en nuestro archivo de aplicacion (**App.js**)  vamos a realizar el manejo del enrutamiento de cada una de estas paginas o componentes, para ello utilizaremos la libreria de **react-router-dom**, e incluiremos cada uno de los componentes par que puedan ser utilizados en esta función.

1. Incluya el enrutador

```js
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
```
En este caso identifique el el componente **BrouwserRouter** se idndentificara ahora con el alias de **Router**, lo que lo hace mas sencillo de identificar.


2. Incluya el llamado a todos los componentes

```js
import { Layout } from './Layout';
import { NoMatch } from './components/NoMatch';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/Users';
import { NavigationBar } from './components/NavigationBar';
```

3. Utilice el componente **React.Fragment** para renderizar el codigo en su enterior.

4. Luego incluya el llamado al componentes de **Navigation Bar** para adicinar el menú, Tenga presente que aqui el componente se cierra asi mismo, es decir no requiere **Tag** de Inicio ni **Tag** de fin. solo el llamado al componente.

```js
<NavigationBar />
```

5. Ahora incluya en componente de **Layout** con tag de inicio y fin y dentro de el vamos a realizar el llamado a las rutas, así:

```js
<Router>
 <Switch> 
   <Route exact path="/" component={Home} />
   <Route path="/Home" component={Home} />
   <Route path="/Users" component={List} />
   <Route path="/Login" component={Login} />
   <Route component={NoMatch} />
 </Switch>
</Router>
```

- **Router**: Es el alias que se le dio a **BrowserRouter** y permite definir las rutas
- **Switch**: Permite intercambiar internamente su contenido con el valor de la ruta establecida.
- **Route**: Define el componente a renderizar según el **path** o ruta que redirecciona el **NavigationBar**.

Integrando todo tenemos lo siguiente:

```js
import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Layout } from './Layout';
import { NoMatch } from './components/NoMatch';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/Users';
import { NavigationBar } from './components/NavigationBar';


function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar />
        <Layout>
          <Router>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/Home" component={Home} />
              <Route path="/Users" component={Users} />
              <Route path="/Login" component={Login} />
              <Route component={NoMatch} />
            </Switch>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
```

Ahora ya podemos probrar cada una de las opciones del menú, y ver como nos cambia de página o mejor, como nos renderiza cada componente.

# Consumiento datos de la API
Ahora vamos a modificar la página de usuarios (**User.js**) para que podamos desplegar los datos de los usuarios.

1. 



## Habilitando CORS