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
        Console.Clear();
        Console.WriteLine("--- GESTIÓN DE USUARIOS ---");
        Console.WriteLine("[Módulo en construcción] Se implementará en la rama feature/users-menu.");
        Console.ReadKey();
    }
    // ==========================================
    // 3. MENÚ PRÉSTAMOS (ShowLoansMenu)
    // ==========================================
    static void ShowLoansMenu()
    {
        Console.Clear();
        Console.WriteLine("--- GESTIÓN DE PRÉSTAMOS ---");
        Console.WriteLine("[Módulo en construcción] Se implementará en la rama feature/loans-menu.");
        Console.ReadKey();
    }
    // ==========================================
    // 4. BÚSQUEDAS Y REPORTES (ShowSearchReportsMenu)
    // ==========================================
    static void ShowSearchReportsMenu()
    {
        Console.Clear();
        Console.WriteLine("--- BÚSQUEDAS Y REPORTES ---");
        Console.WriteLine("[Módulo en construcción] Se implementará en la rama feature/search-reports-menu.");
        Console.ReadKey();
    }
    // ==========================================
    // 5. GUARDAR / CARGAR DATOS (ShowPersistenceMenu)
    // ==========================================
    static void ShowPersistenceMenu()
    {
        Console.Clear();
        Console.WriteLine("--- GUARDAR / CARGAR DATOS ---");
        Console.WriteLine("[Módulo en construcción] Se implementará en la rama feature/persistence-menu.");
        Console.ReadKey();
    }
    // ==========================================
    // 6. FLUJO DE SALIDA (ConfirmExitAndSave)
    // ==========================================
    static bool ConfirmExitAndSave()
    {
        Console.WriteLine("Saliendo del sistema...");
        return true;
    }
}
