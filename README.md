Mini App Bancaria - .NET Core 6
¡Bienvenido a la Mini App Bancaria! Esta aplicación está diseñada como un ejemplo de una implementacion de una app bancaria en .NET Core 6 con utilizando RabbitMQ para la comunicación entre dos microservicios: Banking y Transfer.

Características Principales
Implementación de dos microservicios: Banking y Transfer.
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/2fcdd2b5-5bbc-4020-89a3-172ddb0b1de5)

Uso de RabbitMQ para la comunicación asíncrona entre los microservicios.
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/166d2486-bb35-49bd-9d9c-0a6db9d00fcf)

Bases de datos independientes para cada microservicio, ambas utilizando SQL Server (actualmente corren localmente en el mismo contenedor, por una cuestion de comodidad, pero cada API, tiene su DbContext y su appsettings. Con el DbContext podes generar mgirations para la base que quieras, solo tenes que modificar el appsettings.
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/a449bb9d-aa41-4dcc-b5c3-fa094767770a)
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/0fd03057-1f22-4778-b870-a3fec39ac362)
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/c6c7ce6f-ee88-4967-83cc-5d8bade4b5f1)

Las bases de datos y RabbitMQ se ejecutan en contenedores Docker para facilitar el despliegue y la gestión. En la captura podes ver las imagenes que utilice, eso te sirve para crear las tuyas.
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/17a1b9fe-5a07-4bd2-b456-2a0a8e174516)

Utiliza Entity Framework Migrations para manejar la creación y actualización de la base de datos. Mas abajo hay ejemplos de los comandos que hay que correr para crear y para correr los migrations contra la BBDD.

Configuración de CORS para permitir todas las solicitudes durante el desarrollo, con plantillas para configuraciones más restrictivas en producción.
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/0044b386-0278-497b-84cb-42169d4f3d73)


Estructura del Proyecto
Microservicio Banking: Implementa las funcionalidades bancarias principales.
Microservicio Transfer: Maneja las transferencias entre cuentas bancarias.
Proyectos Data : Contienen los DbContexts y migrations para las bases de datos de cada microservicio. Como usa entity, se pueden modificar las entidades en base a lo que necesites y volver a generarlos. Es importante recordar que el appsettings del repositorio es uno de ejemplo, modificalo para conectarse a tu base de datos local.

Próximos Pasos
Implementar la autenticación JWT para validar credenciales en los endpoints.
Agregar un frontend para interactuar con la aplicación de manera más amigable.
Configuración 
Para levantar este repositorio tenes que clonarlo, abrirlo en visual Studio.
Tener levantados los dos containers necesarios

Comandos utiles y recomendaciones: 
Levantar una instancia de sql server en el puerto 1433
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD={TuPassword}" -p 1433:1433 --name "{container_name}" -d mcr.microsoft.com/mssql/server

Para conectarte a la base desde el MSQLS Management Studio redacta de esta manera la direccion : 127.0.0.1\{container_name},1433
![image](https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/ad11464b-e10e-4bdf-be92-7b4ee6706a58)


EF cmds
Add-Migration "Initial Migration" -Context BankingDbContext => creates migration

Update-Database -Context {Entity}DbContext = > runs migration
Accede a los endpoints proporcionados por cada microservicio para interactuar con la aplicación.

## Uso del Repositorio

Este repositorio es público y está disponible para que cualquiera lo utilice con cualquier propósito. Lo hice para una entrevista tecnica. No es necesario dar crédito, pero siempre es bien recibido saber si este proyecto te fue útil.

Si decides utilizar este proyecto o parte de él en tus propios proyectos, ¡me encantaría saber si te fue util!

Contacto
Si tienes alguna pregunta, sugerencia, o comentario no dudes en ponerte en contacto conmigo.


