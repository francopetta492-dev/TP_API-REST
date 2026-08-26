# TP_API-REST

En este proyecto hice el desarrollo de una API REST realizada en C# utilizando ASP.NET Core y .NET 8. El objetivo es crear una API sencilla que permita administrar información sobre mascotas, en este caso perros y gatos.
La aplicación trabaja con una clase base `Mascota`, de la cual se desprenden los tipos `Perro` y `Gato`. Todas las mascotas cuentan con un ID, nombre y edad. Los perros además tienen una raza y los gatos tienen un color.
La API permite consultar todas las mascotas registradas y también buscar una mascota específica utilizando su ID. Además, se pueden realizar búsquedas según la edad, obteniendo las mascotas que sean mayores a la edad indicada, y filtrar la lista para mostrar solamente perros o gatos.
También se implementaron operaciones para agregar nuevas mascotas. Se pueden registrar perros y gatos mediante peticiones POST enviando los datos correspondientes. Para modificar información existente se utilizan peticiones PUT, diferenciando entre perros y gatos. Por último, se pueden eliminar mascotas utilizando su ID mediante una petición DELETE.
Al iniciar el proyecto se encuentran cargadas algunas mascotas de ejemplo, lo que permite probar los distintos endpoints sin necesidad de agregar datos previamente.
Para ejecutar el proyecto se debe abrir una terminal dentro de la carpeta del proyecto y utilizar el comando `dotnet run`. Una vez iniciado, se puede acceder a la API desde la dirección indicada por la consola. Los diferentes endpoints pueden probarse utilizando Swagger, Postman o el navegador en el caso de las peticiones GET.
Este trabajo tiene como finalidad practicar la creación y utilización de una API REST, el manejo de diferentes métodos HTTP (`GET`, `POST`, `PUT` y `DELETE`) y el trabajo con clases y herencia en C#.
