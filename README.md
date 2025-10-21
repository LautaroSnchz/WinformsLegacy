# WinFormsContacts

CRUD de contactos en **Windows Forms** con **SQL Server (ADO.NET)**, diseñado con
**arquitectura por capas** y prácticas de *Clean Code*.

## 🚀 Stack
- .NET (WinForms)
- SQL Server (LocalDB o SQL Express)
- ADO.NET (SqlConnection/SqlCommand con parámetros)

## 🧱 Arquitectura

### Principios y buenas prácticas aplicadas
- **SRP (Single Responsibility Principle):** cada capa tiene una única razón de cambio.
- **Separación de capas:** UI no conoce SQL; DataAccess no conoce controles.
- **ADO.NET parametrizado:** evita inyección SQL y problemas de formato.
- **Manejo de recursos:** `try/finally` y `using` para abrir/cerrar conexiones.
- **Nombres expresivos** y métodos pequeños.
- **Configuración externa:** cadena de conexión en `App.config` (opcional).

## ⚙️ Requisitos
- SQL Server (LocalDB o SQLEXPRESS)
- Visual Studio 2022+

## 🗄️ Base de datos
```sql
CREATE DATABASE WinFormsContacts;
GO
USE WinFormsContacts;

CREATE TABLE Contacts (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  FirstName NVARCHAR(100),
  LastName  NVARCHAR(100),
  Phone     NVARCHAR(50),
  Address   NVARCHAR(200)
);
