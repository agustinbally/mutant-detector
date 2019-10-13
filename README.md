# Mutant Detector (API - REST)

Mutant Detector es una api-rest que recibe una cadena de ADN y determina si la cadena recibida pertenece a un mutante.

Las cadenas de ADN se representan como una matriz de NxN, las cuales sólo pueden contener como elementos los siguientes caracteres A, T, C, G (que representan cada base nitrogenada del ADN).

Para que una cadena de ADN se determine como perteneciente a un mutante debe tener **más de una secuencia de cuatro letras iguales**, de forma oblicua, horizontal o vertical.

Ejemplos:

|||||||
|--|--|--|--|--|--|
|A|T|G|C|G|A|
|C|A|G|T|G|C|
|T|T|A|T|T|T|
|A|G|A|C|G|G|
|G|C|G|T|C|A|
|T|C|A|C|T|G|

No pertenece a un mutante

|||||||
|--|--|--|--|--|--|
|**A**|T|G|C|**G**|A|
|C|**A**|G|T|**G**|C|
|T|T|**A**|T|**G**|T|
|A|G|A|**A**|**G**|G|
|**C**|**C**|**C**|**C**|T|A|
|T|C|A|C|T|G|

Pertenece a un mutante

### Consideraciones
- Se tienen en cuenta secuencias de forma horizontal, vertical y oblicuas. En el caso de oblicuas serán tenidas en cuenta diagonales desde abajo hacia arriba como también desde arriba hacia abajo
- Si hay dos secuencias de cuatro letras iguales del mismo caracter también se lo considera como mutante.
- Las letras pertenecientes a una secuencia detectada, no serán tenidas en cuenta para otra secuencia en el mismo sentido.


## Modo de uso
La api-rest consta de 2 endpoints, uno para evaluar si un ADN pertenece o no a un mutante, y el otro para obtener estadísticas sobre los ADN evaluados.

*¿Cómo evaluar si un ADN pertenece a un mutante?*

    POST → URI_BASE/mutant/
    {
         "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
    }

Donde el ADN se representa como un array de Strings que representan cada fila de la matriz.

Recibiendo como respuesta:

    HTTP 200-OK --> para los mutantes
    403-Forbidden --> para los no mutantes
    404-BadRequest --> para casos de ADNs inválidos

*¿Cómo obtener las estadísticas sobre los casos evaluados?*

    GET → URI_BASE/stats/

Recibiendo como respuesta el siguiente json:

    {
      “count_mutant_dna”:40, 
      “count_human_dna”:100: 
      “ratio”:0.4
	}


## Secuencia básica de la evaluación

![Alt text](https://github.com/agustinbally/mutant-detector/blob/master/secuencia.PNG?raw=true "secuencia-basica")

## Detalles de la solución

La solución se desarrolló como una webapi de .net core, compuesta por las siguientes capas:
- Api: contiene los controllers que atienten las solicitudes http
- Aplication: orquesta servicios de dominio y persistencia de datos en el caso de la evaluación de ADN.
- Dominio: contiene entidades de dominio y servicios necesarios para evaluar ADNs.
- Infraestructure: contiene repositorio y conector con dynamodb

### Despliegue

La api-rest se hostea en Google Cloup Platform.
La base de datos es un mongodb, utilizando MongoDb Atlas.

### Tests
Se agregaron tests de las capas  api y domain (que contiene toda la lógica de evaluación)

*¿Cómo ejecutar los tests?*

En el directorio raiz de la solución, compilar y luego correr los tests con los siguientes comandos.:

    $ dotnet build 
    $ dotnet test

También se agregaron tests de integración utilizando collections de postman, los mismos se pueden ejecutar desde [Postman](https://www.getpostman.com/), o usando [newman](https://www.npmjs.com/package/newman) para correrlos desde una terminal.

    $ npm install -g newman
    $ newman run Mutant.Api.postman_collection.json -e IntegrationTests/magnetoapp.postman_environment.json

Para ejecutar correctamente los tests de integración hay que editar el environment utilizado (magnetoapp.postman_environment.json) haciendo que todas lar urls utilicen la url base donde está hosteada la api-rest.

# Mutant Detector (Programa)
El programa que evalúa si un ADN es mutante es parte de la misma solución .net core.

Para ejecutar el mismo hay que seguir los siguientes pasos desde la raíz del proyecto.


    # compilo
    dotnet build -c Release
    
    # ejecucion caso mutante
    dotnet MutantDetector.Program/bin/Release/netcoreapp2.2/MutantDetector.Program.dll ATGCGA CAGTGC TTATGT AGAAGG CCCCTA TCACTG
    
    # ejecucion caso no mutante
    dotnet MutantDetector.Program/bin/Release/netcoreapp2.2/MutantDetector.Program.dll ATGCGA CCGTGC TTATGT AGAAGG TACGTA TCACTG

Siguiendo la secuencia:

    donet path_programa/nombre_programa.dll string_array_adn
