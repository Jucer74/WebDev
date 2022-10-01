# Autenticacion con Json Web Token (JWT)
para facilitar el proceso de autenticacion utilizaremos la libreria de json-server que permite crear un servidor virtual que soporte todos los metodos de tipo REST.

## Pasos
Utilizando una ventana de consola o terminal ejecutaremos los siguietnes pasos:

1. Crearemos el Directorio **Server** e ingresaremos a el

```
mkdir Server
cd Server
```

2. Ininializaremos un proyecto de tipo node ejecutanto el comando init

```
npm init
```

Ingresando los siguientes datos:

- package name: webapi-server
- version: 1.0.0
- description: Simulacion de Web Api
- entry point: server.js
- test command: [NO INGRESA NADA]
- git repository: [NO INGRESA NADA]
- author:  [Su Nombre]
- license: MIT

Esto generara el archivo **package.json** con el siguiente contenido

```json
{
  "name": "webapi-server",
  "version": "1.0.0",
  "description": "Simulacion de Web Api",
  "main": "server.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "author": "Julio Robles",
  "license": "MIT"
}
```
3. Podemos generar un achivo de tipo json como nuestra base de datos principal. En este caso utilizaremos el archivo **EmployeesDB.json** y lo copiaremos dentro del directorio **Server**.

4. Instalamos nuestro servicios para simular el servidor **json-server**.

```
npm install json-server --save
```

5. Ejecute el comando **Fix** par completar las dependencias de los modulos utilizados y referenciados por el archivo **package.json** asi:

```
npm audit fix --force
```

6. Probemos que el servicio basico funciona, ejecutando el comando siguiente:

```
json-server --watch EmployeesDB.json
```

al ejecutar este comando debe obtener uns respuesta similar a esta

```
  \{^_^}/ hi!

  Loading EmployeesDB.json
  Done

  Resources
  http://localhost:3000/Employees

  Home
  http://localhost:3000

  Type s + enter at any time to create a snapshot of the database
  Watching...

```

7. Utilice Postman o cualquier otra herramienta para realizar peticiones a la API, en este punto puede ejecutar el siguiente comando **en otra ventna nueva de consola o terminal**:

```
curl http://localhost:3000/Employees
```
para este llamado debe obetener una erspuesta similar a la siguiente:

```
StatusCode        : 200
StatusDescription : OK
Content           : [
                      {
                        "id": 1,
                        "firstName": "Solomon",
                        "lastName": "Garland",
                        "hireDate": "03-10-2002",
                        "department": "Audit"
                      },
                      {
                        "id": 2,
                        "firstName": "Angy",
                        "lastName": "Couch"...
RawContent        : HTTP/1.1 200 OK
                    Vary: Origin, Accept-Encoding
                    Access-Control-Allow-Credentials: true
                    Pragma: no-cache
                    X-Content-Type-Options: nosniff
                    Connection: keep-alive
                    Keep-Alive: timeout=5
                    Content-Length...
Forms             : {}
Headers           : {[Vary, Origin, Accept-Encoding], [Access-Control-Allow-Credentials, true], [Pragma, no-cache],
                    [X-Content-Type-Options, nosniff]...}
Images            : {}
InputFields       : {}
Links             : {}
ParsedHtml        : mshtml.HTMLDocumentClass
RawContentLength  : 13316

```

## Funcionalides adicionales

### Paginacion de Datos
Puede consultar datos paginados agregando el parámetro de página **_page**. Por ejemplo:

```
curl -X GET "http://localhost:3000/Employees?_page=1"
```
Esto enviará una solicitud GET para leer la primera página.

### Filtrar Datos
También puede agregar filtros para obtener datos filtrados simplemente agregando los filtros. Por ejemplo:

```
curl -X GET "http://localhost:3000/Employes?firstName=Julio&lastName=Robles"
```
Si utiliza el caracter ampersand (&) puede adicionar y combinar multiples filtros.


### Ordenar Datos
Usted puede obtner los datos ordenados usando el comando **_sort** y **_order**. Por ejemplo:

```
curl -X GET "http://localhost:3000/Employees?_sort=lastName&order=DESC"
```

8. Detenga el servicio en la ventan del servidor presionando las taclas **CTRL+C**

# Autenticacion

1. Instalamos las librerias necesarias para generar e interpretar el **Bearer** Token.

```
npm install body-parser --save
npm install jsonwebtoken --save
```

2. Cree el archivo de usuarios **users.json** con los datos de usuarios registrads que pueden autenticarse, con el siguiente contenido:

```json
{
  "users": [
    {
      "id": 1,
      "fistName": "System",
      "lastName": "Administator",
      "email": "admin@email.com",
      "password": "P4ssw0rd*01"
    },
    {
      "id": 1,
      "fistName": "Julio",
      "lastName": "Robles",
      "email": "jrobles@email.com",
      "password": "1234567890"
    }
  ]
}
```

3. Creamos un nuevo archivo llamado **server.js** e iremos adicionadole las instrucciones necesarias para activar el servidor json-server con autentication.

4. Primero, comienza solicitando los módulos que necesitará usar, incluidos jsonwebtoken y json-server.

```js
const fs = require('fs')
const bodyParser = require('body-parser')
const jsonServer = require('json-server')
const jwt = require('jsonwebtoken')
```

5. A continuación, utilice el método create() para devolver un servidor Express

```js
const server = jsonServer.create()
```

6. Llame al método router() para devolver un enrutador Express

```js
const router = jsonServer.router('./EmployeesDB.json')
```

7. Ahora necesita leer y analizar el archivo de usarios (users.json) Este archivo actúa como una tabla para usuarios registrados.

```
const userdb = JSON.parse(fs.readFileSync('./users.json', 'UTF-8'))
```

8. A continuación, defina algunas constantes: **SECRET_KEY** se usa para firmar las cargas útiles y **expiresIn** para configurar el tiempo de vencimiento de los tokens de acceso JWT.

```
const SECRET_KEY = '123456789'
const expiresIn = '1h'
```

9. O también puede agregar su propia configuración. (en este caso utilizaremos sonlo el paso anterior de default)

```
server.use(bodyParser.urlencoded({extended: true}))
server.use(bodyParser.json())
```

10. A continuación, establezca middlewares predeterminados (registrador, estática, cors y sin caché)

```
server.use(jsonServer.defaults());
```

11. Adicione las siguietnes funciones

```
```

12. a