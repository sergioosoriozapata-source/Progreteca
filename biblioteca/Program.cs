using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
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
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
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
                    case 6: salir = ConfirmExitAndSave(); break;
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
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE LIBROS ---");
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
        Console.Clear();
        Console.WriteLine("--- 1.1 REGISTRAR LIBRO ---");
        Console.WriteLine("[Función] Registrando nuevo libro en el sistema... (Simulado)");
        Console.Write("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    static void ListBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- 1.2 LISTAR LIBROS ---");
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
        Console.WriteLine("\n[Función ListBooksAll] Mostrando todos los libros registrados... (Simulado)");
        Console.ReadKey();
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine("\n[Función ListBooksAvailable] Mostrando libros disponibles... (Simulado)");
        Console.ReadKey();
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine("\n[Función ListBooksBorrowed] Mostrando libros prestados... (Simulado)");
        Console.ReadKey();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 1.3 VER DETALLE DE LIBRO ---");
        Console.WriteLine("[Función ViewBookDetail] Viendo detalle de libro por ID/ISBN... (Simulado)");
        Console.ReadKey();
    }

    static void UpdateBookMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- 1.4 ACTUALIZAR LIBRO ---");
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
        Console.WriteLine("\n[Función EditBookTitle] Editando título del libro... (Simulado)");
        Console.ReadKey();
    }

    static void EditBookAuthor()
    {
        Console.WriteLine("\n[Función EditBookAuthor] Editando autor del libro... (Simulado)");
        Console.ReadKey();
    }

    static void EditBookYearCategory()
    {
        Console.WriteLine("\n[Función EditBookYearCategory] Editando año / categoría del libro... (Simulado)");
        Console.ReadKey();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("--- 1.5 ELIMINAR LIBRO ---");
        Console.WriteLine("[Función DeleteBook] Validando: No permitir eliminar si el libro está prestado.");
        Console.ReadKey();
    }

    // ==========================================
    // 2. MENÚ USUARIOS (ShowUsersMenu)
    // ==========================================
    static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE USUARIOS ---");
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
        Console.Clear();
        Console.WriteLine("--- 2.1 REGISTRAR USUARIO ---");
        Console.WriteLine("[Función RegisterUser] Registrando nuevo usuario... (Simulado)");
        Console.ReadKey();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("--- 2.2 LISTAR USUARIOS ---");
        Console.WriteLine("[Función ListUsers] Mostrando lista de usuarios... (Simulado)");
        Console.ReadKey();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 2.3 VER DETALLE DE USUARIO ---");
        Console.WriteLine("[Función ViewUserDetail] Viendo detalle de usuario por ID/documento... (Simulado)");
        Console.ReadKey();
    }

    static void UpdateUserMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- 2.4 ACTUALIZAR USUARIO ---");
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
        Console.WriteLine("\n[Función EditUserName] Editando nombre de usuario... (Simulado)");
        Console.ReadKey();
    }

    static void EditUserContact()
    {
        Console.WriteLine("\n[Función EditUserContact] Editando contacto de usuario... (Simulado)");
        Console.ReadKey();
    }

    static void ToggleUserActiveStatus()
    {
        Console.WriteLine("\n[Función ToggleUserActiveStatus] Cambiando estado activo/inactivo de usuario... (Simulado)");
        Console.ReadKey();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("--- 2.5 ELIMINAR USUARIO ---");
        Console.WriteLine("[Función DeleteUser] Validando: No permitir si tiene préstamos activos.");
        Console.ReadKey();
    }

    // ==========================================
    // 3. MENÚ PRÉSTAMOS (ShowLoansMenu)
    // ==========================================
    static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE PRÉSTAMOS ---");
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
        Console.Clear();
        Console.WriteLine("--- 3.1 CREAR PRÉSTAMO ---");
        Console.WriteLine("[Función CreateLoan] Validaciones sugeridas:");
        Console.WriteLine("- Validar que el usuario esté activo.");
        Console.WriteLine("- Validar que el libro esté disponible.");
        Console.WriteLine("- Validar límite de préstamos por usuario.");
        Console.ReadKey();
    }

    static void ListLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- 3.2 LISTAR PRÉSTAMOS ---");
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
        Console.WriteLine("\n[Función ListLoansAll] Listando todos los préstamos... (Simulado)");
        Console.ReadKey();
    }

    static void ListLoansActive()
    {
        Console.WriteLine("\n[Función ListLoansActive] Listando préstamos activos... (Simulado)");
        Console.ReadKey();
    }

    static void ListLoansClosed()
    {
        Console.WriteLine("\n[Función ListLoansClosed] Listando préstamos cerrados... (Simulado)");
        Console.ReadKey();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.WriteLine("--- 3.3 VER DETALLE DE PRÉSTAMO ---");
        Console.WriteLine("[Función ViewLoanDetail] Viendo detalle de préstamo por ID... (Simulado)");
        Console.ReadKey();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("--- 3.4 REGISTRAR DEVOLUCIÓN ---");
        Console.WriteLine("[Función RegisterReturn] Marcando préstamo como devuelto + libro disponible... (Simulado)");
        Console.ReadKey();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("--- 3.5 ELIMINAR PRÉSTAMO ---");
        Console.WriteLine("[Función DeleteLoan] Aplicando reglas sugeridas para eliminar préstamo... (Simulado)");
        Console.ReadKey();
    }

    // ==========================================
    // 4. BÚSQUEDAS Y REPORTES (ShowSearchReportsMenu)
    // ==========================================
    static void ShowSearchReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- BÚSQUEDAS Y REPORTES ---");
            Console.WriteLine("1. Buscar libro (título / autor / ID / categoría)");
            Console.WriteLine("2. Buscar usuario (nombre / ID)");
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
        Console.Clear();
        Console.WriteLine("--- 4.1 BUSCAR LIBRO ---");
        Console.WriteLine("[Función SearchBook] Buscando libro por título, autor, ID o categoría... (Simulado)");
        Console.ReadKey();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("--- 4.2 BUSCAR USUARIO ---");
        Console.WriteLine("[Función SearchUser] Buscando usuario por nombre o ID... (Simulado)");
        Console.ReadKey();
    }

    static void ReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- 4.3 REPORTES ---");
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
        Console.WriteLine("\n[Función ReportByUser] Generando reporte por usuario... (Simulado)");
        Console.ReadKey();
    }

    static void ReportByBook()
    {
        Console.WriteLine("\n[Función ReportByBook] Generando reporte por libro... (Simulado)");
        Console.ReadKey();
    }

    static void ReportOverdue()
    {
        Console.WriteLine("\n[Función ReportOverdue] Generando reporte de préstamos vencidos... (Simulado)");
        Console.ReadKey();
    }

    static void ReportSummary()
    {
        Console.WriteLine("\n[Función ReportSummary] Generando resumen general... (Simulado)");
        Console.ReadKey();
    }

    // ==========================================
    // 5. GUARDAR / CARGAR DATOS (ShowPersistenceMenu)
    // ==========================================
    static void ShowPersistenceMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GUARDAR / CARGAR DATOS ---");
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
        Console.Clear();
        Console.WriteLine("--- 5.1 GUARDAR DATOS ---");
        Console.WriteLine("[Función SaveData] Guardando datos del sistema... (Simulado)");
        Console.ReadKey();
    }

    static void LoadData()
    {
        Console.Clear();
        Console.WriteLine("--- 5.2 CARGAR DATOS ---");
        Console.WriteLine("[Función LoadData] Cargando datos del sistema... (Simulado)");
        Console.ReadKey();
    }

    static void ResetData()
    {
        Console.Clear();
        Console.WriteLine("--- 5.3 REINICIAR DATOS ---");
        Console.Write("¿Está seguro de reiniciar los datos? (S/N): ");
        string? confirm = Console.ReadLine();
        if (confirm?.ToUpper() == "S")
        {
            Console.WriteLine("Datos reiniciados con éxito.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
        Console.ReadKey();
    }

    // ==========================================
    // 6. FLUJO DE SALIDA (ConfirmExitAndSave)
    // ==========================================
    static bool ConfirmExitAndSave()
    {
        Console.Clear();
        Console.WriteLine("--- SALIR ---");
        Console.Write("¿Desea guardar los cambios antes de salir? (S/N): ");
        string? respuesta = Console.ReadLine();
        if (respuesta?.ToUpper() == "S")
        {
            Console.WriteLine("Guardando datos...");
        }
        Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
        Console.ReadKey();
        return true;
    }
}
