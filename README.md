# NEXUS | Sistema de Gestión Web

### Desarrollo de Servicios Web I — Evaluación T1

Este proyecto fue desarrollado como parte de la evaluación T1 del curso Desarrollo de Servicios Web I de Cibertec.

El objetivo fue poner en práctica los conocimientos adquiridos durante las clases, principalmente el desarrollo de aplicaciones web con ASP.NET Core MVC, la conexión con SQL Server y el uso de Entity Framework Core.

Además de cumplir con los ejercicios solicitados, decidí trabajar un poco más en la presentación de la aplicación, buscando que tenga una interfaz moderna, ordenada y fácil de utilizar. De esta manera nació **NEXUS**, un sistema que reúne los diferentes módulos desarrollados durante la evaluación.

## Tecnologías utilizadas

Para el desarrollo utilicé las siguientes tecnologías:

- **C# y ASP.NET Core MVC (.NET 10):** desarrollo de la aplicación web.
- **Entity Framework Core:** conexión y acceso a la base de datos.
- **SQL Server:** almacenamiento de clientes y pedidos.
- **HTML, CSS y Razor:** construcción de las vistas.
- **JavaScript:** interacciones, animaciones y búsqueda en tablas.
- **Bootstrap:** apoyo para los componentes y el diseño adaptable.
- **Git y GitHub:** control de versiones y publicación del código.

## Funcionalidades desarrolladas

### 1. Cálculo de llamadas telefónicas

Este módulo permite ingresar la duración de una llamada y obtener automáticamente el importe que corresponde pagar.

El cálculo considera una tarifa de $10 por los primeros cinco minutos y $2 por cada minuto adicional.

### 2. Membresías de gimnasio

Permite calcular el costo de una membresía según la edad del cliente y los meses contratados.

Se consideran las tarifas establecidas para cada rango de edad y los descuentos correspondientes a los periodos de contratación.

### 3. Gestión de clientes

En este apartado se implementó un mantenimiento conectado a la base de datos `EmpresaDB`.

Permite visualizar los clientes registrados, agregar nuevos clientes y actualizar sus datos.

### 4. Gestión de pedidos

Este módulo permite registrar pedidos asociados a los clientes existentes, consultar sus montos, fechas y estados, además de modificar la información de los pedidos registrados.

Para estas operaciones se utilizaron procedimientos almacenados de SQL Server.

### 5. Panel principal

También incorporé una pantalla de inicio que permite acceder fácilmente a todos los módulos.

El panel muestra información general obtenida de la base de datos, como la cantidad de clientes, los pedidos registrados, los pedidos pendientes y el monto acumulado.

## Organización del proyecto

Para mantener el código organizado, trabajé con el patrón MVC y una separación adicional mediante Repository y Service.

- **Models:** contienen las entidades y modelos utilizados por la aplicación.
- **Views:** presentan los formularios, las tablas y los resultados.
- **Controllers:** reciben las solicitudes y coordinan las operaciones.
- **Data:** contiene el contexto de Entity Framework Core.
- **Interfaces:** definen los métodos que utilizan los servicios y repositorios.
- **Repositories:** se encargan del acceso a los datos.
- **Services:** permiten organizar las operaciones utilizadas por los controladores.
- **wwwroot:** contiene los archivos CSS, JavaScript y demás recursos visuales.

Esta estructura me permitió separar mejor las responsabilidades y mantener un código más ordenado.

## Base de datos

La aplicación utiliza la base de datos `EmpresaDB`, compuesta por las tablas `Clientes` y `Pedidos`, relacionadas mediante el identificador del cliente.

También se implementaron seis procedimientos almacenados para realizar las operaciones de listado, registro y actualización de ambas tablas.

El archivo **`EmpresaDB_Completo.sql`** se encuentra incluido en el repositorio y permite preparar la base de datos necesaria para ejecutar el proyecto.

## Cómo ejecutar el proyecto

1. Clonar o descargar este repositorio.
2. Abrir la solución `DSWI_T1_INDIVIDUAL02.slnx` en Visual Studio.
3. Verificar que se tenga instalado el SDK de .NET 10 y SQL Server.
4. Ejecutar `EmpresaDB_Completo.sql` desde SQL Server Management Studio.
5. Revisar la cadena de conexión de `appsettings.json` y adaptarla al nombre de la instancia local de SQL Server.
6. Restaurar los paquetes NuGet y ejecutar la aplicación desde Visual Studio.

La aplicación se abrirá en el navegador mediante una dirección local HTTPS.

## Diseño de la interfaz

Para la parte visual busqué alejarme un poco del diseño predeterminado de ASP.NET Core MVC.

Utilicé CSS y JavaScript para implementar una interfaz inspirada en el estilo *Liquid Glass*, con transparencias, degradados, animaciones suaves y un menú que permite navegar entre los módulos.

Mi intención fue mantener una presentación agradable sin dejar de lado la funcionalidad y los requisitos del examen.

## Pruebas realizadas

Durante el desarrollo realicé pruebas de los cálculos de llamadas y membresías, así como de las operaciones de consulta, registro y actualización de clientes y pedidos.

También comprobé la conexión con SQL Server, la ejecución de los procedimientos almacenados y la visualización de los datos desde el navegador.

## Información académica

**Institución:** Cibertec  
**Curso:** Desarrollo de Servicios Web I  
**Evaluación:** T1  
**Proyecto:** DSWI_T1_INDIVIDUAL02  
**Herramienta principal:** Visual Studio 2026

---

Este proyecto me permitió reforzar los conocimientos del curso y comprender mejor cómo se relacionan los controladores, las vistas, los servicios y el acceso a los datos dentro de una aplicación web.

También aproveché la evaluación para experimentar con algunas mejoras de diseño y organizar el código de una forma que pueda seguir utilizando y mejorando en futuros proyectos.
