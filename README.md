# Progreteca - Sistema de Gestión Bibliotecaria (SENA ADSO)

Proyecto de consola en C# (.NET) desarrollado para las evidencias del programa **Tecnólogo en Análisis y Desarrollo de Software (ADSO)** del SENA:

- **220501097-04-AA1 – EV06 – Aplicación de la sintaxis básica de C# - Funciones (Parte 1).**
- **220501097-04-AA1 – EV07 – Definición de clases y objetos base del sistema de biblioteca (POO).**
- **220501097-04-AA1 – EV08 – Gestión de colecciones con `List<T>` y capa `Services`.**
- **Proyecto Final V1.**

---

## Descripción del Proyecto

Aplicación de consola con menú interactivo, navegación real entre menús y submenús, validación de entradas y una **capa de servicios** que administra las colecciones en memoria.

- **EV06:** menú y funciones estáticas (submenús, confirmaciones, mensajes).
- **EV07:** modelos del dominio en `Models/` y prueba de objetos.
- **EV08:** colecciones `List<T>` encapsuladas en `Services/`, con reglas de negocio, búsquedas y reportes reales.

---

## Estructura

```
biblioteca/
├── Program.cs                        # Menús y orquestación (consume los Services)
├── biblioteca.csproj
├── Models/
│   ├── EstadoPrestamo.cs             # enum: Activo, Devuelto, Vencido
│   ├── Libro.cs
│   ├── Usuario.cs
│   └── Prestamo.cs
└── Services/
    ├── LibroService.cs               # List<Libro> + CRUD + búsqueda + disponibilidad
    ├── UsuarioService.cs             # List<Usuario> + CRUD + estado + documento único
    └── PrestamoService.cs            # List<Prestamo> + validaciones + devolución + reportes
```

---

## Capa Services (EV08)

### `LibroService`
`List<Libro>` interno con: `Registrar`, `ObtenerPorId`, `ObtenerTodos`, `ObtenerDisponibles`, `ObtenerPrestados`, `Buscar` (ID/ISBN, título, autor, categoría), `ActualizarTitulo`, `ActualizarAutor`, `ActualizarAnioCategoria`, `Eliminar` (bloquea si está prestado), `MarcarPrestado`, `MarcarDisponible`, `Limpiar`.

### `UsuarioService`
`List<Usuario>` interno con: `Registrar` (documento único), `ObtenerPorId`, `ObtenerPorDocumento`, `ObtenerPorIdODocumento`, `ObtenerTodos`, `Buscar`, `ActualizarNombre`, `ActualizarContacto`, `CambiarEstado` (activo/inactivo), `Eliminar`, `Limpiar`.

### `PrestamoService`
`List<Prestamo>` interno con reglas de negocio: `Crear` (usuario existente y activo, libro existente y disponible, máximo 3 préstamos activos), `RegistrarDevolucion` (libera el libro), `Eliminar` (solo cerrados), `ObtenerTodos/Activos/Cerrados/Vencidos`, `ObtenerPorUsuario`, `ObtenerPorLibro`, `EsVencido` (plazo de 14 días), `Limpiar`.

---

## Menú del Sistema

1. **Libros** — registrar, listar (todos / disponibles / prestados), ver detalle, actualizar (título, autor, año/categoría), eliminar.
2. **Usuarios** — registrar, listar, ver detalle, actualizar (nombre, contacto, activar/desactivar), eliminar (bloquea con préstamos activos).
3. **Préstamos** — crear con validaciones, listar (todos / activos / cerrados), ver detalle, registrar devolución, eliminar.
4. **Búsquedas y reportes** — buscar libro, buscar usuario, reportes por usuario, por libro, vencidos y resumen general.
5. **Guardar / Cargar datos** — guardar, cargar y reiniciar (limpia las colecciones) con confirmación S/N.
6. **Pruebas de Modelos (EV07 POO)** — objetos de prueba con resúmenes, detalles y validaciones.
7. **Salir** — confirmación de guardado S/N.

Al iniciar, el sistema carga datos de prueba (5 libros, 3 usuarios y 3 préstamos: 2 activos y 1 cerrado) para poder probar listados y reportes de inmediato.

---

## Git Flow

Cada funcionalidad se desarrolló en su rama `feature/`, integrada a `develop` con `merge --no-ff` y luego a `main`.

### EV06
| Rama | Contenido |
| --- | --- |
| `feature/main-menu-navigation` | Navegación del menú principal, validación y `switch` de submenús |
| `feature/books-menu` | Módulo de libros y submenús |
| `feature/users-menu` | Módulo de usuarios |
| `feature/loans-menu` | Módulo de préstamos |
| `feature/search-reports-menu` | Búsquedas y reportes |
| `feature/persistence-menu` | Guardar / cargar / reiniciar |
| `feature/exit-flow` | Salida con confirmación |

### EV07
| Rama | Contenido |
| --- | --- |
| `feature/models-enum-estado-prestamo` | `EstadoPrestamo` |
| `feature/models-libro` | `Libro` |
| `feature/models-usuario` | `Usuario` |
| `feature/models-prestamo` | `Prestamo` |
| `feature/models-testing-objetos` | Demo de objetos |

### EV08
| Rama | Contenido |
| --- | --- |
| `feature/services-libro` | `LibroService` con `List<Libro>` |
| `feature/services-usuario` | `UsuarioService` con `List<Usuario>` |
| `feature/services-prestamo` | `PrestamoService` con `List<Prestamo>` y validaciones |
| `feature/services-integracion-menus` | Menús conectados a Services + datos iniciales |

### Convención de commits

- `feat: ...` nueva funcionalidad
- `fix: ...` corrección
- `docs: ...` documentación
- `chore: ...` mantenimiento

---

## Instrucciones de Ejecución

Requiere el **SDK de .NET** instalado.

```bash
dotnet run --project biblioteca/biblioteca.csproj
```
