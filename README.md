```markdown
# MiniCore2025

Sistema básico de gestión de ventas y cálculo de comisiones para vendedores, basado en reglas personalizadas. Este proyecto fue desarrollado con arquitectura en capas y tecnología .NET 9, utilizando Entity Framework Core y una API RESTful.

## 🚀 Características Principales

- Gestión de **vendedores**, **ventas** y **reglas de comisión**.
- Cálculo dinámico de comisiones por vendedor en un rango de fechas determinado.
- API construida con ASP.NET Core y conectada a base de datos PostgreSQL.
- Migraciones y seeding de datos iniciales.
- Arquitectura modular dividida en 3 capas: API, Domain y Persistence.

## 🧱 Estructura del Proyecto

```

juandiego-sc-minicore2025/
├── API/                # Proyecto de capa de presentación (API REST)
├── Domain/             # Entidades del dominio (Seller, Sale, Rule)
├── Persistence/        # Acceso a datos y DbContext
└── MiniCore2025.sln    # Archivo de solución de Visual Studio

````

## 🧩 Entidades Principales

- **Seller**: Vendedor, contiene nombre y comisión acumulada.
- **Sale**: Venta realizada, con valor total, fecha, y referencias a vendedor y regla.
- **Rule**: Regla de comisión, contiene el porcentaje aplicado y el monto mínimo requerido.

## 🧮 Lógica de Cálculo

El cálculo de comisiones se realiza mediante el servicio `CalculateCommissionsService`, el cual:
1. Filtra las ventas entre fechas dadas.
2. Aplica la regla correspondiente a cada venta.
3. Suma las comisiones por vendedor.

## ⚙️ Requisitos Técnicos

- .NET 9.0 SDK
- PostgreSQL
- Visual Studio 2022 o superior
- Entity Framework Core 9.0

## 🔧 Configuración

1. Clonar el repositorio:
   ```bash
   git clone https://tu-repo-url.com/juandiego-sc-minicore2025.git
   cd juandiego-sc-minicore2025
````

2. Configurar cadena de conexión en `API/appsettings.Development.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Port=5432;Database=MiniCore2025DB;User Id=postgres;Password=toor;"
   }
   ```

3. Aplicar migraciones y seed de datos al iniciar el API.

4. Ejecutar el proyecto:

   ```bash
   dotnet run --project API
   ```

## 🧪 Endpoints Principales

* `GET /api/commissions/calculate?startDate=...&endDate=...`: Calcula comisiones por vendedor.
* `GET /api/sales`: Lista todas las ventas.
* `GET /api/rules`: Lista todas las reglas.

## 🧱 Migraciones

Las migraciones se generan con:

```bash
dotnet ef migrations add NombreMigration --project Persistence --startup-project API
```

## 📦 Semilla de Datos

Automáticamente se insertan registros de ejemplo para:

* 4 vendedores
* 4 reglas de comisión
* 6 ventas variadas

## 📄 Licencia

Este proyecto es parte de un ejercicio académico y no tiene fines comerciales. Uso libre con atribución.

---
