# FastAPI
En esta sesion Veremos como crear una API utlizando el framework de FastAPI, ademas de como ejecutarla para poder realizar las operaciones basicas de REST y asi interactuar con la base de datos.

# Requisitos
Al ser FastAPI un framework basado en Python, debemos instalar este lenguaje y sus utilitarios.

## Python
Realice la Instalacion personalizada, de [Python.org](https://www.python.org/downloads/) seleccionando todas las opciones.
Luego en una ventana de comenaod o de powershell ejecute el siguiente comando para validar el correcto funcionamiento:

```
python --version
```

Como resultado debe obtener la version actual de Python que se instalo.

Ahora instalemos el Framework y sus utilitarios:

## FastAPI
Para Instalar [FastAPI](https://fastapi.tiangolo.com/es/) puede utilizar el gestor de librerias de Python (pip) ejecutando, la siguiente instruccion en una ventana de comandos:

```
pip install fastapi
```

##  Uvicorn
Para desplegar la API que se genera, se utiliza el servicio de [Uvicorn](https://www.uvicorn.org/), que permite desplegar localmente la APi para que pueda ser consumida por cualquier cliente. para ello puede utilizar el gestor de librerias de Python (pip) ejecutando el siguiente comando:

```
pip install uvicorn
```

Modifique la variable de Ambiente PATH y adicione la tura de los scripts y precompilñados de Python, en mi caso y siendo que mi usuario es jrobles seria:

```
C:\Users\jrobles\AppData\Roaming\Python\Python311\Scripts
```

# Test Inicial
PAra validar que esta funcionando correctamente creamos un archivo llamado **main.py** con el siguietnte contenido:

```python
from fastapi import FastAPI
from typing import Union

app = FastAPI()


@app.get("/")
def read_root():
    return {"Hello": "World"}


@app.get("/items/{item_id}")
def read_item(item_id: int, q: Union[str, None] = None):
    return {"item_id": item_id, "q": q}

```

y en la terminal, situados en el mismo directorio donde esta el archivo ejecutamos el siguiente comando:

```
uvicorn main:app --reload
```

Se desplegara ua informacion corespondiente al Inicio del servicio , en eonde se mosstara una URL similar a la siguiente:

```
http://127.0.0.1:8000 
```

Copie dicha URL en un navegador y confirme que se depliega el mensaje esperado. en este caso seria :

```
{"Hello":"World"}
```

De igual forma puede obtener la documentacion interactiva que es desplegada usando la libreria de Swagger, usando la siguietne URL:

```
http://127.0.0.1:8000/docs
```

En este punto puede ver el contenido completo de todos los endpoint expuestos por la API y puede interactuar con ellos directamente.

