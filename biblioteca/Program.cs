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
        Console.Clear();
        Console.WriteLine("--- GESTIÓN DE LIBROS ---");
        Console.WriteLine("[Módulo en construcción] Se implementará en la rama feature/books-menu.");
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
