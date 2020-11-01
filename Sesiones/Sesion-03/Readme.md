# Introducción a Boostrap
Bootstrap es un framework Front-End, compuesto de librerias Javascript, estilos CSS y componentes HTML que pemirten diseñar facilmente y dimanera dinámica, paginas web. En esta sesión veremos algunas des sus principales características y aprenderemos a utilizarlas.

## Requisitos
Necesitamos tener instalado 

- [Bootstrap](https://getbootstrap.com/)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Node JS](https://nodejs.org/en/download/)

### Extensiones VS Code
- Autoclose tag
- Beautify
- Bracket Pair Colorizer
- ES7 React/Redux/GraphQL/React-Native snippets
- GitLens
- GitHistory
- JavaScript (ES6) code snippets
- Live Server
- npm
- path intellisense
- TSLint
- Prettier
- vscode-icons

# Manos a la Obra
Vamos a crear un directorio al nivel del proyecto para que realicemos nuestras plantillas.

![Bootstrap](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-03/Bootstrap-01.png)

Ahora iniciamos **Visual Studio Code** y abrimos ese folder como nuestro diectorio principal.

![Bootstrap](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-03/Bootstrap-02.png)

Seleccionamos nuevo archivo y le asignamos el nombre **Index.html**

![Bootstrap](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-03/Bootstrap-03.png)

En la session de Edicion escribimos el signo de exclamacion **!** y presionamos dos veces la tecla **Tab**. Esto nos genera automáticamente la plantilla inicial del codigo HTML así:

![Bootstrap](https://github.com/Jucer74/WebDev/blob/main/Sesiones/Sesion-03/Bootstrap-04.png)

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    
</body>
</html>
```

Ahora comencemos vamos a incluir Bootstrap.

En la página de Bootstrap obtenemos los links para cada uno de los componentes necesarios para incluir sus elementos.

### CSS
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">

### JS / Bundle
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>

 

