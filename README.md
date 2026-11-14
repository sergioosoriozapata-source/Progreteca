# Progreteca - Sistema de Gestión Bibliotecaria (SENA ADSO)

Proyecto de consola en C# (.NET) desarrollado para las evidencias del programa **Tecnólogo en Análisis y Desarrollo de Software (ADSO)** del SENA:

- **220501097-04-AA1 – EV06 – Aplicación de la sintaxis básica de C# - Funciones (Parte 1).**
- **220501097-04-AA1 – EV07 – Definición de clases y objetos base del sistema de biblioteca (POO).**

---

## Descripción del Proyecto

Menú interactivo 100% funcional con navegación real entre menús y submenús, lectura y validación básica de entradas, y opciones de volver / confirmar / salir. Cada opción invoca funciones estáticas que simulan las acciones mediante mensajes descriptivos por consola.

En la EV07 se incorporaron los modelos del dominio (`Models/`) y una opción de menú que crea objetos de prueba, muestra sus resúmenes, detalles y validaciones.

---

## Estructura

```
biblioteca/
├── Program.cs                  # Menu principal, submenus y funciones estaticas (EV06)
├── biblioteca.csproj
└── Models/
    ├── EstadoPrestamo.cs       # enum: Activo, Devuelto, Vencido
    ├── Libro.cs                # propiedades, constructores, ResumenCorto/DetalleCompleto
    ├── Usuario.cs              # propiedades, constructores, ResumenCorto/DetalleCompleto
    └── Prestamo.cs             # DateTime, EstadoPrestamo, EstaVencido, DiasTranscurridos
```

---

## Menú del Sistema

- **Menú principal:**
  1. Libros (Registrar, Listar todos/disponibles/prestados, Ver detalle, Actualizar título/autor/año, Eliminar con validación de préstamo).
  2. Usuarios (Registrar, Listar, Ver detalle, Actualizar nombre/contacto/estado, Eliminar con validación de préstamos activos).
  3. Préstamos (Crear con validaciones, Listar todos/activos/cerrados, Ver detalle, Registrar devolución, Eliminar).
  4. Búsquedas y reportes (Buscar libro, Buscar usuario, Reportes por usuario, por libro, vencidos y resumen).
  5. Guardar / Cargar datos (Guardar, Cargar y Reiniciar datos con confirmación S/N).
  6. Pruebas de Modelos (EV07 POO): crea 2 libros, 2 usuarios y 1 préstamo y muestra resúmenes, detalles y validaciones.
  7. Salir (Confirmación de guardado antes de salir S/N).

---

## Git Flow

El desarrollo se estructuró con **Git Flow**, una rama `feature/` por funcionalidad, integradas a `develop` mediante `merge --no-ff` y luego a `main`:

| Rama | Contenido |
| --- | --- |
| `feature/main-menu-navigation` | Navegación del menú principal, validación y `switch` de submenús |
| `feature/books-menu` | Módulo de libros y sus submenús |
| `feature/users-menu` | Módulo de usuarios y activar/desactivar |
| `feature/loans-menu` | Módulo de préstamos, devolución y listados |
| `feature/search-reports-menu` | Búsquedas y reportes (usuario, libro, vencidos, resumen) |
| `feature/persistence-menu` | Guardar / cargar / reiniciar datos con confirmación S/N |
| `feature/exit-flow` | Flujo de salida con confirmación de guardado |
| `feature/models-enum-estado-prestamo` | `EstadoPrestamo` (EV07) |
| `feature/models-libro` | `Libro` (EV07) |
| `feature/models-usuario` | `Usuario` (EV07) |
| `feature/models-prestamo` | `Prestamo` (EV07) |
| `feature/models-testing-objetos` | Demo de objetos con 2 libros, 2 usuarios y 1 préstamo |

### Convención de commits

- `feat: ...` nueva funcionalidad
- `fix: ...` corrección
- `docs: ...` documentación
- `chore: ...` tareas de mantenimiento

---

## Instrucciones de Ejecución

Requiere el **SDK de .NET** instalado.

```bash
dotnet run --project biblioteca/biblioteca.csproj
```
