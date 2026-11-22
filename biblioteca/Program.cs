using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca.Models;
using biblioteca.Services;

class Program
{
    // ==========================================
    // CAPA DE SERVICIOS (EV08)
    // ==========================================
    static readonly LibroService libroService = new LibroService();
    static readonly UsuarioService usuarioService = new UsuarioService();
    static readonly PrestamoService prestamoService = new PrestamoService(libroService, usuarioService);

    static void Main(string[] args)
    {
        CargarDatosIniciales();
        ShowMainMenu();
    }

    // ==========================================
    // DATOS INICIALES DE PRUEBA
    // ==========================================
    static void CargarDatosIniciales()
    {
        libroService.Registrar("Cien años de soledad", "Gabriel García Márquez", "Realismo mágico", 1967);
        libroService.Registrar("La vorágine", "José Eustasio Rivera", "Novela de la selva", 1924);
        libroService.Registrar("María", "Jorge Isaacs", "Romanticismo", 1867);
        libroService.Registrar("El olvido que seremos", "Héctor Abad Faciolince", "Memoria", 2006);
        libroService.Registrar("Satanás", "Mario Mendoza", "Novela negra", 2002);

        usuarioService.Registrar("Carlos", "Gómez", "1039485721", "3001234567");
        usuarioService.Registrar("María", "López", "1012938475", "3109876543");
        usuarioService.Registrar("Juan", "Ramírez", "1002345678", "3123456789");

        Libro? libro1 = libroService.ObtenerPorId("L001");
        Libro? libro2 = libroService.ObtenerPorId("L002");
        Libro? libro3 = libroService.ObtenerPorId("L003");
        Usuario? usuario1 = usuarioService.ObtenerPorId("U001");
        Usuario? usuario2 = usuarioService.ObtenerPorId("U002");

        if (libro1 is not null && usuario1 is not null)
        {
            libroService.MarcarPrestado(libro1.Id);
            prestamoService.Agregar(new Prestamo
            {
                Id = prestamoService.GenerarId(),
                LibroPrestado = libro1,
                UsuarioPrestatario = usuario1,
                FechaPrestamo = DateTime.Now.AddDays(-5),
                Estado = EstadoPrestamo.Activo
            });
        }

        if (libro2 is not null && usuario2 is not null)
        {
            libroService.MarcarPrestado(libro2.Id);
            prestamoService.Agregar(new Prestamo
            {
                Id = prestamoService.GenerarId(),
                LibroPrestado = libro2,
                UsuarioPrestatario = usuario2,
                FechaPrestamo = DateTime.Now.AddDays(-30),
                Estado = EstadoPrestamo.Activo
            });
        }

        if (libro3 is not null && usuario1 is not null)
        {
            prestamoService.Agregar(new Prestamo
            {
                Id = prestamoService.GenerarId(),
                LibroPrestado = libro3,
                UsuarioPrestatario = usuario1,
                FechaPrestamo = DateTime.Now.AddDays(-40),
                FechaDevolucion = DateTime.Now.AddDays(-10),
                Estado = EstadoPrestamo.Devuelto
            });
        }
    }

    // ==========================================
    // UTILIDADES DE CONSOLA
    // ==========================================
    static void Titulo(string texto)
    {
        Console.Clear();
        Console.WriteLine($"--- {texto} ---");
    }

    static string LeerTexto(string etiqueta, bool obligatorio = true)
    {
        while (true)
        {
            Console.Write(etiqueta);
            string valor = (Console.ReadLine() ?? string.Empty).Trim();

            if (!obligatorio || valor.Length > 0)
            {
                return valor;
            }

            Console.WriteLine("Este dato es obligatorio. Intente de nuevo.");
        }
    }

    static int LeerEntero(string etiqueta)
    {
        while (true)
        {
            Console.Write(etiqueta);
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Ingrese un número entero.");
        }
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void MostrarResultado(bool exito, string mensaje)
    {
        Console.WriteLine();
        Console.WriteLine(exito ? $"OK: {mensaje}" : $"ERROR: {mensaje}");
    }

    // ==========================================
    // MENÚ PRINCIPAL (ShowMainMenu)
    // ==========================================
    static void ShowMainMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA BIBLIOTECA - MENÚ PRINCIPAL ===");
            Console.WriteLine($"Libros: {libroService.Total} | Usuarios: {usuarioService.Total} | Préstamos: {prestamoService.Total}");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Pruebas de Modelos (EV07 POO)");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: ShowBooksMenu(); break;
                    case 2: ShowUsersMenu(); break;
                    case 3: ShowLoansMenu(); break;
                    case 4: ShowSearchReportsMenu(); break;
                    case 5: ShowPersistenceMenu(); break;
                    case 6: MostrarObjetosPruebaEV07(); break;
                    case 7: salir = ConfirmExitAndSave(); break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida. Por favor, ingrese un número. Presione cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }
    }

    // ==========================================
    // 1. MENÚ LIBROS (ShowBooksMenu)
    // ==========================================
    static void ShowBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("GESTIÓN DE LIBROS");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: RegisterBook(); break;
                    case 2: ListBooksMenu(); break;
                    case 3: ViewBookDetail(); break;
                    case 4: UpdateBookMenu(); break;
                    case 5: DeleteBook(); break;
                    case 6: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void RegisterBook()
    {
        Titulo("1.1 REGISTRAR LIBRO");
        string titulo = LeerTexto("Título: ");
        string autor = LeerTexto("Autor: ");
        string categoria = LeerTexto("Categoría: ");
        int anio = LeerEntero("Año: ");

        Libro libro = libroService.Registrar(titulo, autor, categoria, anio);

        Console.WriteLine($"\nOK: Libro registrado con ID {libro.Id}.");
        Console.WriteLine(libro.DetalleCompleto());
        Pausa();
    }

    static void ListBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("1.2 LISTAR LIBROS");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("4. Volver");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: ListBooksAll(); break;
                    case 2: ListBooksAvailable(); break;
                    case 3: ListBooksBorrowed(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void ListBooksAll()
    {
        Console.WriteLine();
        List<Libro> libros = libroService.ObtenerTodos();

        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine(libro.ResumenCorto());
            }
        }

        Console.WriteLine($"\nTotal: {libros.Count}");
        Pausa();
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine();
        List<Libro> libros = libroService.ObtenerDisponibles();

        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros disponibles.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine(libro.ResumenCorto());
            }
        }

        Console.WriteLine($"\nDisponibles: {libros.Count}");
        Pausa();
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine();
        List<Libro> libros = libroService.ObtenerPrestados();

        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros prestados.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine(libro.ResumenCorto());
            }
        }

        Console.WriteLine($"\nPrestados: {libros.Count}");
        Pausa();
    }

    static void ViewBookDetail()
    {
        Titulo("1.3 VER DETALLE DE LIBRO");
        string id = LeerTexto("Ingrese el ID/ISBN del libro: ");

        Libro? libro = libroService.ObtenerPorId(id);
        Console.WriteLine();

        if (libro is null)
        {
            Console.WriteLine("No se encontró un libro con ese ID/ISBN.");
        }
        else
        {
            Console.WriteLine(libro.DetalleCompleto());
        }

        Pausa();
    }

    static void UpdateBookMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("1.4 ACTUALIZAR LIBRO");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("4. Volver");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: EditBookTitle(); break;
                    case 2: EditBookAuthor(); break;
                    case 3: EditBookYearCategory(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void EditBookTitle()
    {
        Titulo("1.4.1 EDITAR TÍTULO");
        string id = LeerTexto("ID/ISBN del libro: ");
        string nuevoTitulo = LeerTexto("Nuevo título: ");

        (bool exito, string mensaje) = libroService.ActualizarTitulo(id, nuevoTitulo);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void EditBookAuthor()
    {
        Titulo("1.4.2 EDITAR AUTOR");
        string id = LeerTexto("ID/ISBN del libro: ");
        string nuevoAutor = LeerTexto("Nuevo autor: ");

        (bool exito, string mensaje) = libroService.ActualizarAutor(id, nuevoAutor);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void EditBookYearCategory()
    {
        Titulo("1.4.3 EDITAR AÑO / CATEGORÍA");
        string id = LeerTexto("ID/ISBN del libro: ");
        int nuevoAnio = LeerEntero("Nuevo año: ");
        string nuevaCategoria = LeerTexto("Nueva categoría: ");

        (bool exito, string mensaje) = libroService.ActualizarAnioCategoria(id, nuevoAnio, nuevaCategoria);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void DeleteBook()
    {
        Titulo("1.5 ELIMINAR LIBRO");
        string id = LeerTexto("ID/ISBN del libro a eliminar: ");

        (bool exito, string mensaje) = libroService.Eliminar(id);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    // ==========================================
    // 2. MENÚ USUARIOS (ShowUsersMenu)
    // ==========================================
    static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("GESTIÓN DE USUARIOS");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle (por ID/documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: RegisterUser(); break;
                    case 2: ListUsers(); break;
                    case 3: ViewUserDetail(); break;
                    case 4: UpdateUserMenu(); break;
                    case 5: DeleteUser(); break;
                    case 6: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void RegisterUser()
    {
        Titulo("2.1 REGISTRAR USUARIO");
        string nombre = LeerTexto("Nombre: ");
        string apellido = LeerTexto("Apellido: ");
        string documento = LeerTexto("Documento: ");
        string telefono = LeerTexto("Teléfono: ", false);

        (bool exito, string mensaje, Usuario? usuario) = usuarioService.Registrar(nombre, apellido, documento, telefono);
        MostrarResultado(exito, mensaje);

        if (exito && usuario is not null)
        {
            Console.WriteLine(usuario.DetalleCompleto());
        }

        Pausa();
    }

    static void ListUsers()
    {
        Titulo("2.2 LISTAR USUARIOS");
        List<Usuario> usuarios = usuarioService.ObtenerTodos();

        if (usuarios.Count == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
        }
        else
        {
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine(usuario.ResumenCorto());
            }
        }

        Console.WriteLine($"\nTotal: {usuarios.Count} (Activos: {usuarioService.TotalActivos} | Inactivos: {usuarioService.TotalInactivos})");
        Pausa();
    }

    static void ViewUserDetail()
    {
        Titulo("2.3 VER DETALLE DE USUARIO");
        string valor = LeerTexto("ID o documento del usuario: ");

        Usuario? usuario = usuarioService.ObtenerPorIdODocumento(valor);
        Console.WriteLine();

        if (usuario is null)
        {
            Console.WriteLine("No se encontró un usuario con ese ID o documento.");
        }
        else
        {
            Console.WriteLine(usuario.DetalleCompleto());
            List<Prestamo> prestamos = prestamoService.ObtenerPorUsuario(usuario.Id);
            Console.WriteLine($"Préstamos asociados: {prestamos.Count}");
        }

        Pausa();
    }

    static void UpdateUserMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("2.4 ACTUALIZAR USUARIO");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar usuario");
            Console.WriteLine("4. Volver");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: EditUserName(); break;
                    case 2: EditUserContact(); break;
                    case 3: ToggleUserActiveStatus(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void EditUserName()
    {
        Titulo("2.4.1 EDITAR NOMBRE");
        string id = LeerTexto("ID del usuario: ");
        string nombre = LeerTexto("Nuevo nombre: ");
        string apellido = LeerTexto("Nuevo apellido (opcional): ", false);

        (bool exito, string mensaje) = usuarioService.ActualizarNombre(id, nombre, apellido);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void EditUserContact()
    {
        Titulo("2.4.2 EDITAR CONTACTO");
        string id = LeerTexto("ID del usuario: ");
        string telefono = LeerTexto("Nuevo teléfono: ");

        (bool exito, string mensaje) = usuarioService.ActualizarContacto(id, telefono);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void ToggleUserActiveStatus()
    {
        Titulo("2.4.3 ACTIVAR / DESACTIVAR USUARIO");
        string id = LeerTexto("ID del usuario: ");

        (bool exito, string mensaje) = usuarioService.CambiarEstado(id);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void DeleteUser()
    {
        Titulo("2.5 ELIMINAR USUARIO");
        string id = LeerTexto("ID del usuario a eliminar: ");

        Usuario? usuario = usuarioService.ObtenerPorId(id);
        if (usuario is null)
        {
            MostrarResultado(false, "No existe un usuario con ese ID.");
            Pausa();
            return;
        }

        int activos = prestamoService.ObtenerPorUsuario(usuario.Id)
            .Count(p => p.Estado == EstadoPrestamo.Activo);

        if (activos > 0)
        {
            MostrarResultado(false, $"No se puede eliminar: el usuario tiene {activos} préstamo(s) activo(s).");
            Pausa();
            return;
        }

        (bool exito, string mensaje) = usuarioService.Eliminar(id);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    // ==========================================
    // 3. MENÚ PRÉSTAMOS (ShowLoansMenu)
    // ==========================================
    static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("GESTIÓN DE PRÉSTAMOS");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle de préstamo");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: CreateLoan(); break;
                    case 2: ListLoansMenu(); break;
                    case 3: ViewLoanDetail(); break;
                    case 4: RegisterReturn(); break;
                    case 5: DeleteLoan(); break;
                    case 6: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void CreateLoan()
    {
        Titulo("3.1 CREAR PRÉSTAMO");
        Console.WriteLine("Validaciones: usuario activo, libro disponible y máximo 3 préstamos activos.\n");

        string idLibro = LeerTexto("ID/ISBN del libro: ");
        string idUsuario = LeerTexto("ID o documento del usuario: ");

        (bool exito, string mensaje, Prestamo? prestamo) = prestamoService.Crear(idLibro, idUsuario);
        MostrarResultado(exito, mensaje);

        if (exito && prestamo is not null)
        {
            Console.WriteLine(prestamo.DetalleCompleto());
        }

        Pausa();
    }

    static void ListLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("3.2 LISTAR PRÉSTAMOS");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("4. Volver");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: ListLoansAll(); break;
                    case 2: ListLoansActive(); break;
                    case 3: ListLoansClosed(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void ListLoansAll()
    {
        Console.WriteLine();
        List<Prestamo> prestamos = prestamoService.ObtenerTodos();
        MostrarListaPrestamos(prestamos);
        Pausa();
    }

    static void ListLoansActive()
    {
        Console.WriteLine();
        List<Prestamo> prestamos = prestamoService.ObtenerActivos();
        MostrarListaPrestamos(prestamos);
        Pausa();
    }

    static void ListLoansClosed()
    {
        Console.WriteLine();
        List<Prestamo> prestamos = prestamoService.ObtenerCerrados();
        MostrarListaPrestamos(prestamos);
        Pausa();
    }

    static void MostrarListaPrestamos(List<Prestamo> prestamos)
    {
        if (prestamos.Count == 0)
        {
            Console.WriteLine("No hay préstamos para mostrar.");
            return;
        }

        foreach (Prestamo prestamo in prestamos)
        {
            string vencido = prestamoService.EsVencido(prestamo) ? " [VENCIDO]" : string.Empty;
            Console.WriteLine(prestamo.ResumenCorto() + vencido);
        }

        Console.WriteLine($"\nTotal: {prestamos.Count}");
    }

    static void ViewLoanDetail()
    {
        Titulo("3.3 VER DETALLE DE PRÉSTAMO");
        string id = LeerTexto("ID del préstamo: ");

        Prestamo? prestamo = prestamoService.ObtenerPorId(id);
        Console.WriteLine();

        if (prestamo is null)
        {
            Console.WriteLine("No se encontró un préstamo con ese ID.");
        }
        else
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine($"Plazo: {PrestamoService.DiasPlazo} días | Vencido: {prestamoService.EsVencido(prestamo)}");
        }

        Pausa();
    }

    static void RegisterReturn()
    {
        Titulo("3.4 REGISTRAR DEVOLUCIÓN");
        string id = LeerTexto("ID del préstamo a devolver: ");

        (bool exito, string mensaje) = prestamoService.RegistrarDevolucion(id);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    static void DeleteLoan()
    {
        Titulo("3.5 ELIMINAR PRÉSTAMO");
        string id = LeerTexto("ID del préstamo a eliminar: ");

        (bool exito, string mensaje) = prestamoService.Eliminar(id);
        MostrarResultado(exito, mensaje);
        Pausa();
    }

    // ==========================================
    // 4. BÚSQUEDAS Y REPORTES (ShowSearchReportsMenu)
    // ==========================================
    static void ShowSearchReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("BÚSQUEDAS Y REPORTES");
            Console.WriteLine("1. Buscar libro (título / autor / ID / categoría)");
            Console.WriteLine("2. Buscar usuario (nombre / ID / documento)");
            Console.WriteLine("3. Ver reportes");
            Console.WriteLine("4. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: SearchBook(); break;
                    case 2: SearchUser(); break;
                    case 3: ReportsMenu(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void SearchBook()
    {
        Titulo("4.1 BUSCAR LIBRO");
        string criterio = LeerTexto("Título, autor, ID o categoría: ");

        List<Libro> encontrados = libroService.Buscar(criterio);
        Console.WriteLine();

        if (encontrados.Count == 0)
        {
            Console.WriteLine("No se encontraron libros con ese criterio.");
        }
        else
        {
            foreach (Libro libro in encontrados)
            {
                Console.WriteLine(libro.ResumenCorto());
            }
        }

        Console.WriteLine($"\nCoincidencias: {encontrados.Count}");
        Pausa();
    }

    static void SearchUser()
    {
        Titulo("4.2 BUSCAR USUARIO");
        string criterio = LeerTexto("Nombre, ID o documento: ");

        List<Usuario> encontrados = usuarioService.Buscar(criterio);
        Console.WriteLine();

        if (encontrados.Count == 0)
        {
            Console.WriteLine("No se encontraron usuarios con ese criterio.");
        }
        else
        {
            foreach (Usuario usuario in encontrados)
            {
                Console.WriteLine(usuario.ResumenCorto());
            }
        }

        Console.WriteLine($"\nCoincidencias: {encontrados.Count}");
        Pausa();
    }

    static void ReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("4.3 REPORTES");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Reporte de préstamos vencidos");
            Console.WriteLine("4. Reporte resumen general");
            Console.WriteLine("5. Volver");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: ReportByUser(); break;
                    case 2: ReportByBook(); break;
                    case 3: ReportOverdue(); break;
                    case 4: ReportSummary(); break;
                    case 5: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void ReportByUser()
    {
        Titulo("4.3.1 REPORTE POR USUARIO");
        string valor = LeerTexto("ID o documento del usuario: ");

        Usuario? usuario = usuarioService.ObtenerPorIdODocumento(valor);
        if (usuario is null)
        {
            Console.WriteLine("\nNo se encontró el usuario.");
            Pausa();
            return;
        }

        List<Prestamo> prestamos = prestamoService.ObtenerPorUsuario(usuario.Id);
        Console.WriteLine($"\nUsuario: {usuario.ResumenCorto()}");
        Console.WriteLine($"Préstamos activos: {prestamos.Count(p => p.Estado == EstadoPrestamo.Activo)}");
        Console.WriteLine($"Préstamos cerrados: {prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto)}");
        Console.WriteLine($"Préstamos vencidos: {prestamos.Count(prestamoService.EsVencido)}");

        if (prestamos.Count > 0)
        {
            Console.WriteLine("\nHistorial:");
            foreach (Prestamo prestamo in prestamos)
            {
                Console.WriteLine($"  {prestamo.ResumenCorto()}");
            }
        }

        Pausa();
    }

    static void ReportByBook()
    {
        Titulo("4.3.2 REPORTE POR LIBRO");
        string id = LeerTexto("ID/ISBN del libro: ");

        Libro? libro = libroService.ObtenerPorId(id);
        if (libro is null)
        {
            Console.WriteLine("\nNo se encontró el libro.");
            Pausa();
            return;
        }

        List<Prestamo> historial = prestamoService.ObtenerPorLibro(libro.Id);
        Console.WriteLine($"\nLibro: {libro.ResumenCorto()}");
        Console.WriteLine($"Estado: {(libro.Disponible ? "DISPONIBLE" : "PRESTADO")}");
        Console.WriteLine($"Historial de préstamos: {historial.Count}");

        foreach (Prestamo prestamo in historial)
        {
            Console.WriteLine($"  {prestamo.ResumenCorto()}");
        }

        Pausa();
    }

    static void ReportOverdue()
    {
        Titulo("4.3.3 REPORTE DE PRÉSTAMOS VENCIDOS");
        List<Prestamo> vencidos = prestamoService.ObtenerVencidos();

        if (vencidos.Count == 0)
        {
            Console.WriteLine("No hay préstamos vencidos.");
        }
        else
        {
            foreach (Prestamo prestamo in vencidos)
            {
                Console.WriteLine($"{prestamo.ResumenCorto()} | Días: {prestamo.DiasTranscurridos()} | Límite: {PrestamoService.DiasPlazo}");
            }
        }

        Console.WriteLine($"\nTotal vencidos: {vencidos.Count}");
        Pausa();
    }

    static void ReportSummary()
    {
        Titulo("4.3.4 REPORTE RESUMEN GENERAL");
        Console.WriteLine($"Total libros registrados : {libroService.Total}");
        Console.WriteLine($"Libros disponibles       : {libroService.TotalDisponibles}");
        Console.WriteLine($"Libros prestados         : {libroService.TotalPrestados}");
        Console.WriteLine($"Total usuarios           : {usuarioService.Total}");
        Console.WriteLine($"Usuarios activos         : {usuarioService.TotalActivos}");
        Console.WriteLine($"Usuarios inactivos       : {usuarioService.TotalInactivos}");
        Console.WriteLine($"Total préstamos          : {prestamoService.Total}");
        Console.WriteLine($"Préstamos activos        : {prestamoService.TotalActivos}");
        Console.WriteLine($"Préstamos cerrados       : {prestamoService.TotalCerrados}");
        Console.WriteLine($"Préstamos vencidos       : {prestamoService.TotalVencidos}");
        Pausa();
    }

    // ==========================================
    // 5. GUARDAR / CARGAR DATOS (ShowPersistenceMenu)
    // ==========================================
    static void ShowPersistenceMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Titulo("GUARDAR / CARGAR DATOS");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("4. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: SaveData(); break;
                    case 2: LoadData(); break;
                    case 3: ResetData(); break;
                    case 4: volver = true; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void SaveData()
    {
        Titulo("5.1 GUARDAR DATOS");
        Console.WriteLine($"[Simulado] Guardando {libroService.Total} libros, {usuarioService.Total} usuarios y {prestamoService.Total} préstamos...");
        Console.WriteLine("Los datos permanecen en memoria durante la ejecución del programa.");
        Pausa();
    }

    static void LoadData()
    {
        Titulo("5.2 CARGAR DATOS");
        Console.WriteLine($"[Simulado] Cargando datos... Libros: {libroService.Total} | Usuarios: {usuarioService.Total} | Préstamos: {prestamoService.Total}");
        Console.WriteLine("La carga desde archivo se implementará en una próxima evidencia.");
        Pausa();
    }

    static void ResetData()
    {
        Titulo("5.3 REINICIAR DATOS");
        Console.Write("¿Está seguro de reiniciar los datos? (S/N): ");
        string? confirm = Console.ReadLine();

        if (confirm?.Trim().ToUpper() == "S")
        {
            prestamoService.Limpiar();
            libroService.Limpiar();
            usuarioService.Limpiar();
            Console.WriteLine("\nDatos reiniciados con éxito. El sistema quedó vacío.");
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }

        Pausa();
    }

    // ==========================================
    // EV07 - PRUEBAS DE OBJETOS Y MODELOS POO
    // ==========================================
    static void MostrarObjetosPruebaEV07()
    {
        Titulo("PRUEBAS DE MODELOS Y OBJETOS (EV07 POO)");

        Libro libro1 = new Libro("X001", "Cien años de soledad", "Gabriel García Márquez", "Realismo Mágico", 1967);
        Libro libro2 = new Libro("X002", "El coronel no tiene quien le escriba", "Gabriel García Márquez", "Novela", 1961);

        Usuario usuario1 = new Usuario("XU01", "Carlos", "Gómez", "1039485721", "3001234567");
        Usuario usuario2 = new Usuario("XU02", "María", "López", "1012938475", "3109876543");

        Prestamo prestamo1 = new Prestamo("XP01", libro1, usuario1, DateTime.Now.AddDays(-5));
        libro1.Disponible = false;

        Console.WriteLine("--- RESÚMENES ---");
        Console.WriteLine(libro1.ResumenCorto());
        Console.WriteLine(libro2.ResumenCorto());
        Console.WriteLine(usuario1.ResumenCorto());
        Console.WriteLine(usuario2.ResumenCorto());
        Console.WriteLine(prestamo1.ResumenCorto());

        Console.WriteLine("\n--- DETALLES COMPLETOS ---");
        Console.WriteLine(libro1.DetalleCompleto());
        Console.WriteLine("\n" + usuario1.DetalleCompleto());
        Console.WriteLine("\n" + prestamo1.DetalleCompleto());

        Console.WriteLine("\n--- VALIDACIONES ---");
        Console.WriteLine($"Libro 1 Disponible?: {libro1.Disponible}");
        Console.WriteLine($"Libro 2 Disponible?: {libro2.Disponible}");
        Console.WriteLine($"Usuario 1 Activo?: {usuario1.Activo}");
        Console.WriteLine($"Usuario 2 Activo?: {usuario2.Activo}");
        Console.WriteLine($"Estado del Préstamo: {prestamo1.Estado}");
        Console.WriteLine($"¿Préstamo Vencido?: {prestamo1.EstaVencido()}");
        Console.WriteLine($"Días Transcurridos en Préstamo: {prestamo1.DiasTranscurridos()}");

        Console.WriteLine("\nNota: estos objetos son de prueba y no afectan los datos de la capa Services.");
        Pausa();
    }

    // ==========================================
    // 6. FLUJO DE SALIDA (ConfirmExitAndSave)
    // ==========================================
    static bool ConfirmExitAndSave()
    {
        Titulo("SALIR");
        Console.Write("¿Desea guardar los cambios antes de salir? (S/N): ");
        string? respuesta = Console.ReadLine();

        if (respuesta?.Trim().ToUpper() == "S")
        {
            Console.WriteLine("Guardando datos...");
        }
        else
        {
            Console.WriteLine("Saliendo sin guardar...");
        }

        Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
        Console.ReadKey();
        return true;
    }
}
