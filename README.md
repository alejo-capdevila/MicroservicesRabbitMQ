<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <style>
        img {
            display: block;
            margin: 0 auto; /* Esto centra la imagen horizontalmente */
        }
    </style>
</head>
<body>
    <h1>¡Bienvenido a esta mini implementacion de microservicios en ASP.NET y RabbitMQ</h1>
    <p>Esta aplicación está diseñada como un ejemplo de una implementación basica de microservicios con un publisher y un consumer. En este caso hipotetico es una mini-app bancaria. La misma corre en .NET Core 6 utilizando RabbitMQ para la comunicación entre dos microservicios: Banking y Transfer.</p>
    <h2>Características Principales</h2>
    <h3>Implementación de dos microservicios: Banking y Transfer.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/2fcdd2b5-5bbc-4020-89a3-172ddb0b1de5" alt="Microservicios">
    <h3>Uso de RabbitMQ para la comunicación asíncrona entre los microservicios.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/166d2486-bb35-49bd-9d9c-0a6db9d00fcf" alt="RabbitMQ">
    <h3>Bases de datos independientes para cada microservicio, ambas utilizando SQL Server.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/0fd03057-1f22-4778-b870-a3fec39ac362" alt="SQL Server">
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/c6c7ce6f-ee88-4967-83cc-5d8bade4b5f1" alt="SQL Server">
    <h3>Las bases de datos y RabbitMQ se ejecutan en contenedores Docker para facilitar el despliegue y la gestión.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/17a1b9fe-5a07-4bd2-b456-2a0a8e174516" alt="Docker">
    <h3>Utiliza Entity Framework Migrations para manejar la creación y actualización de la base de datos.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/a449bb9d-aa41-4dcc-b5c3-fa094767770a" alt="SQL Server">
    <h3>Configuración de CORS para permitir todas las solicitudes durante el desarrollo y hay un template con configuraciones mas restrictivas para usar en caso sea necesario en prod o en otro ambiente.</h3>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/0044b386-0278-497b-84cb-42169d4f3d73" alt="CORS">
    <h2>Estructura del Proyecto</h2>
    <p>Microservicio Banking: Implementa las funcionalidades bancarias principales.</p>
    <p>Microservicio Transfer: Maneja las transferencias entre cuentas bancarias.</p>
    <p>Proyectos Data: Contienen los DbContexts y migrations para las bases de datos de cada microservicio.</p>
    <h2>Próximos Pasos</h2>
    <ul>
        <li>Implementar la autenticación JWT para validar credenciales en los endpoints.</li>
        <li>Agregar un frontend para interactuar con la aplicación de manera más amigable.</li>
    </ul>
    <h2>Configuración</h2>
    <p>Para levantar este repositorio tenes que:</p>
    <ul>
        <li>Clonarlo, abrirlo en visual Studio.</li>
        <li>Tener levantados los dos containers necesarios y asegurarte de que las bases tengan las tablas necesarias (correr los migrations).</li>
        <li>Asegurarte de que los appsettings de las APIs tengan toda la informacion necesaria (datasource, credenciales, usuario de rabbit, etc).</li>
    </ul>
    <h2>Comandos útiles y recomendaciones</h2>
    <p>Levantar una instancia de SQL Server en el puerto 1433:</p>
    <code>docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD={TuPassword}" -p 1433:1433 --name "{container_name}" -d mcr.microsoft.com/mssql/server</code>
    <p>Para conectarte a la base desde el MSQLS Management Studio redacta de esta manera la direccion : 127.0.0.1\{container_name},1433</p>
    <img src="https://github.com/alejo-capdevila/MicroservicesRabbitMQ/assets/72323676/ad11464b-e10e-4bdf-be92-7b4ee6706a58" alt="MSQLS Management Studio">
    <h3>Entity Framework Commands</h3>
    <code>Add-Migration "Initial Migration" -Context BankingDbContext</code> => crea migration<br>
    <code>Update-Database -Context {Entity}DbContext</code> => corre migration
    <h2>Uso del Repositorio</h2>
    <p>Este repositorio es público y está disponible para que cualquiera lo utilice con cualquier propósito. No es necesario dar crédito, pero siempre es bien recibido saber si este proyecto te fue útil.</p>
    <p>Si decides utilizar este proyecto o parte de él en tus propios proyectos, ¡me encantaría saber si te fue útil!</p>
    <h2>Contacto</h2>
    <p>Si tienes alguna pregunta, sugerencia, o comentario no dudes en ponerte en contacto conmigo.</p>
</body>
</html>
