# 🚀 **Guía de Configuración y Ejecución de la API - TaskManagerBackendSmartTalent**

Este documento explica cómo configurar, ejecutar y probar la API de gestión de tareas, la cual está **desplegada en producción** en **Somee.com**, junto con la base de datos en **SQL Server**.

---

## 📦 **Requisitos previos**
Antes de comenzar, asegúrate de tener instalado lo siguiente:

- 📌 [**.NET 8 SDK**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- 📌 [**Docker**](https://www.docker.com/products/docker-desktop/) (para ejecutar la base de datos en local)  
- 📌 [**Postman**](https://www.postman.com/) o **Swagger** (para probar la API)  

---

## 🌍 **API en Producción**
🔹 La API está desplegada en **Somee.com** y puede accederse en:  
**`https://backend-smart.somee.com/api/tasks`**

🔹 Tanto el **backend** como la **base de datos SQL Server** están alojados en **Somee.com**.  

---

## 🏗️ **Configuración de la Base de Datos en Local (Opcional)**
Si deseas probar la API con una base de datos local en Docker, sigue estos pasos:

1️⃣ **Descargar la imagen de SQL Server**  
   ```sh
   docker pull mcr.microsoft.com/mssql/server:2022-latest
   ```

2️⃣ **Ejecutar el contenedor de SQL Server**  
   ```sh
   docker run -e "ACCEPT_EULA=Y" \
              -e "MSSQL_SA_PASSWORD=smartTalent123" \
              -p 1433:1433 \
              -d --name bd_crud_smart_talent \
              mcr.microsoft.com/mssql/server:2022-latest
   ```

3️⃣ **Verificar que el contenedor está en ejecución**  
   ```sh
   docker ps
   ```

   Si el contenedor no está corriendo, inícialo con:
   ```sh
   docker start bd_crud_smart_talent
   ```

---

## 🛠️ **Configurar la Conexión a la Base de Datos**
Si quieres conectar la API a la base de datos **en producción** en Somee.com, usa esta cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=backend-smart.somee.com;Database=TaskManagerDB;User Id=tu_usuario;Password=tu_contraseña;TrustServerCertificate=True;"
}
```

Si deseas usar **SQL Server en local**, usa:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=TaskManagerDB;User Id=sa;Password=smartTalent123;TrustServerCertificate=True;"
}
```

---

## 🚀 **Ejecución de la API en Desarrollo**

### 🔹 **1. Aplicar las migraciones** (Opcional si la base de datos ya está creada)  
Si estás trabajando con una base de datos local y necesitas aplicar migraciones, ejecuta:

```sh
dotnet restore
```


```sh
dotnet ef migrations add InitialCreate --project TaskManagerBackendSmartTalent.csproj
```

```sh
dotnet ef database update --project TaskManagerBackendSmartTalent.csproj
```

> ⚠️ **Nota:** Si estás usando **Somee.com**, la base de datos ya está en producción, por lo que no necesitas ejecutar migraciones.

---

### 🔹 **2. Iniciar la API**
Ejecuta el siguiente comando para iniciar la API en desarrollo:

```sh
dotnet run --project TaskManagerBackendSmartTalent.csproj
```

---

### 🔹 **3. Acceder a la API en Swagger**
Una vez que la API esté en ejecución, accede a Swagger en el navegador:

```
http://localhost:5068/swagger
```

Si el puerto es diferente, revisa la terminal donde se ejecutó `dotnet run`.

---

## 📌 **Lista de Endpoints Disponibles**

| Método  | Endpoint               | Descripción                        |
|---------|------------------------|------------------------------------|
| `GET`   | `/api/tasks`           | Obtener todas las tareas          |
| `GET`   | `/api/tasks/{id}`      | Obtener una tarea por ID          |
| `POST`  | `/api/tasks`           | Crear una nueva tarea             |
| `PUT`   | `/api/tasks/{id}`      | Actualizar una tarea por ID       |
| `DELETE` | `/api/tasks/{id}`     | Eliminar una tarea por ID         |

---

## ✅ **Pruebas con Postman**
Para probar la creación de una tarea (`POST /api/tasks`), usa el siguiente JSON en el **body**:

```json
{
  "title": "Tarea de prueba",
  "description": "Descripción opcional",
  "isCompleted": false
}
```

Si todo está configurado correctamente, la API debería responder con un código **201 Created** y devolver la nueva tarea creada.

---

## 🔹 **Generar Build de Producción**
Si deseas **publicar** la API para desplegarla en un servidor, ejecuta:

```sh
dotnet publish -c Release -o publish
```

Esto generará los archivos compilados en la carpeta **`publish/`**, listos para su despliegue.

---

## 📌 **Versión de .NET Utilizada**
```sh
dotnet --version
```
**Versión actual:** `8.0.403`

---

## 🔥 Autor
👨‍💻 **John Alexander Chicaiza**  
💼 Desarrollador Fullstack 🚀

📧 Contacto: [jachicaizal@outlook.com](mailto:jachicaizal@outlook.com)  
🌐 Portafolio: [jachicaiza.dev](https://portfolio-john-chicaiza.netlify.app/)  

¡Gracias por visitar este proyecto! ⭐

