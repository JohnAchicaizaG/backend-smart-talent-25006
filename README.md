# 🚀 Configuración y Ejecución de la API - TaskManagerBackendSmartTalent

Este documento explica cómo ejecutar la API de gestión de tareas utilizando **.NET** y **SQL Server en Docker**.

---

## 📦 **Requisitos previos**
Antes de comenzar, asegúrate de tener instalado:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop/) (para la base de datos)
- [Postman](https://www.postman.com/) o Swagger (para probar la API)

---

## 🏗️ **Pasos para levantar la base de datos**

1️⃣ **Descargar la imagen de SQL Server**
```sh
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

2️⃣ **Ejecutar el contenedor de SQL Server**
```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=smartTalent123" -p 1433:1433 -d --name bd_crud_smart_talent mcr.microsoft.com/mssql/server:2022-latest
```

3️⃣ **Verificar que el contenedor está corriendo**
```sh
docker ps
```
Si el contenedor no está corriendo, inicia con:
```sh
docker start bd_crud_smart_talent
```

---

## 🛠️ **Configurar la conexión a la base de datos**
Asegúrate de que `appsettings.json` tenga la siguiente configuración:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=TaskManagerDB;User Id=sa;Password=smartTalent123;TrustServerCertificate=True;"
}
```

---

## 🚀 **Ejecutar la API**

1️⃣ **Aplicar las migraciones** (solo la primera vez o si hay cambios en la BD):
```sh
dotnet ef migrations add InitialCreate --project TaskManagerBackendSmartTalent.csproj
```
```sh
dotnet ef database update --project TaskManagerBackendSmartTalent.csproj
```

2️⃣ **Ejecutar la API**
```sh
dotnet run --project TaskManagerBackendSmartTalent.csproj
```

3️⃣ **Acceder a la API en Swagger**
Abre en tu navegador:
```
http://localhost:5068/swagger
```

---

## 📌 **Lista de Endpoints**

| Método | Endpoint               | Descripción                        |
|--------|------------------------|------------------------------------|
| `GET`  | `/api/tasks`           | Obtener todas las tareas          |
| `GET`  | `/api/tasks/{id}`      | Obtener una tarea por ID          |
| `POST` | `/api/tasks`           | Crear una nueva tarea             |
| `PUT`  | `/api/tasks/{id}`      | Actualizar una tarea por ID       |
| `DELETE` | `/api/tasks/{id}`    | Eliminar una tarea por ID         |

---

## ✅ **Pruebas en Postman**
Para probar el `POST /api/tasks`, usa este JSON en el body:
```json
{
  "title": "Tarea de prueba",
  "description": "Descripción opcional",
  "isCompleted": false
}
```

🚀 ¡Tu API ya debería estar corriendo correctamente! 🎉

