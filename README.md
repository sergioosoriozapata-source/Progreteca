# Prograteca - Sistema de Gestión Bibliotecaria (EV06)

Proyecto de consola en C# (.NET) desarrollado para la evidencia **220501097-04-AA1 – EV06 – Aplicación de la sintaxis básica de C# - Funciones Proyecto sintaxis en C# - Parte 1** del programa **Tecnólogo en Análisis y Desarrollo de Software (ADSO)** del SENA.

---

## Descripción del Proyecto

Implementa un menú interactivo 100% funcional con navegación real entre menús y submenús, lectura y validación básica de entradas, y opciones de volver / confirmar / salir. Cada opción invoca funciones estáticas que simulan las acciones mediante mensajes descriptivos por consola (sin POO, sin colecciones reales, sin persistencia real).

---

## Menú y Estructura a Implementar

- **Menú principal:**
  1. Libros (Registrar, Listar todos/disponibles/prestados, Ver detalle, Actualizar título/autor/año, Eliminar con validación de préstamo).
  2. Usuarios (Registrar, Listar, Ver detalle, Actualizar nombre/contacto/estado, Eliminar con validación de préstamos activos).
  3. Préstamos (Crear con lista de validaciones, Listar todos/activos/cerrados, Ver detalle, Registrar devolución, Eliminar).
  4. Búsquedas y reportes (Buscar libro, Buscar usuario, Reportes por usuario, por libro, vencidos y resumen).
  5. Guardar / Cargar datos (Guardar, Cargar y Reiniciar datos con confirmación S/N).
  6. Salir (Confirmación de guardado antes de salir S/N).

---

## Gestión de Versiones y Git Flow

El desarrollo se ha estructurado siguiendo el modelo **Git Flow** con ramas `feature/` para cada módulo:
- `feature/project-bootstrap`
- `feature/main-menu-navigation`
- `feature/books-menu`
- `feature/users-menu`
- `feature/loans-menu`
- `feature/search-reports-menu`
- `feature/persistence-menu`
- `feature/exit-flow`

### Convención de Commits:
- `feat: add books submenu`
- `fix: handle invalid menu input`
- `docs: update README with git flow`

---

## Instrucciones de Ejecución

Asegúrese de tener instalado el **SDK de .NET**.

Para ejecutar el proyecto de la biblioteca:
```bash
dotnet run --project biblioteca/biblioteca.csproj
```
