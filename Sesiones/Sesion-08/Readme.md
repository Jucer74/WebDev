# React - CRUD
Al igual que en la version de MVC veremos la impelmentacion del CRUD, para la creacion, actualizacion y eliminacion de registros.

# Creación de Usuarios
1. Mueva la definicion de la **baseUrl**  por fuera de la función.

2. Adicione a las librerias actuales el llamado a los componentes Modales de la libreria **reactstrap** así:

```js
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
```

2. Cree la función **CreateUser** para mostrar una ventana Modal que permita capturar los datos de los usuarios y enviarlos a la API en el metodo **POST**.





