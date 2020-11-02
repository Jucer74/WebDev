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

# 