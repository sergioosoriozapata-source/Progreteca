using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca.Models;

namespace biblioteca.Services
{
    /// <summary>
    /// Capa de servicios para la gestión de préstamos usando List&lt;Prestamo&gt;.
    /// Se apoya en LibroService y UsuarioService para validar las reglas de negocio:
    /// usuario existente y activo, libro existente y disponible, y límite de préstamos activos.
    /// </summary>
    public class PrestamoService
    {
        public const int MaxPrestamosActivosPorUsuario = 3;
        public const int DiasPlazo = 14;

        private readonly List<Prestamo> _prestamos = new List<Prestamo>();
        private readonly LibroService _libroService;
        private readonly UsuarioService _usuarioService;
        private int _consecutivo = 1;

        public PrestamoService(LibroService libroService, UsuarioService usuarioService)
        {
            _libroService = libroService ?? throw new ArgumentNullException(nameof(libroService));
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        public IReadOnlyList<Prestamo> Prestamos => _prestamos;
        public int Total => _prestamos.Count;
        public int TotalActivos => _prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        public int TotalCerrados => _prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        public int TotalVencidos => _prestamos.Count(EsVencido);

        public string GenerarId()
        {
            return $"P{_consecutivo++:D3}";
        }

        /// <summary>
        /// Crea un préstamo aplicando todas las validaciones de negocio.
        /// </summary>
        public (bool exito, string mensaje, Prestamo? prestamo) Crear(string idLibro, string idUsuarioODocumento)
        {
            Libro? libro = _libroService.ObtenerPorId(idLibro);
            if (libro is null)
            {
                return (false, "El libro no existe. Verifique el ID/ISBN.", null);
            }

            Usuario? usuario = _usuarioService.ObtenerPorIdODocumento(idUsuarioODocumento);
            if (usuario is null)
            {
                return (false, "El usuario no existe. Verifique el ID o el documento.", null);
            }

            if (!usuario.Activo)
            {
                return (false, $"El usuario {usuario.Nombre} {usuario.Apellido} está inactivo y no puede recibir préstamos.", null);
            }

            if (!libro.Disponible)
            {
                return (false, $"El libro '{libro.Titulo}' no está disponible en este momento.", null);
            }

            int activos = _prestamos.Count(p =>
                p.UsuarioPrestatario.Id == usuario.Id && p.Estado == EstadoPrestamo.Activo);

            if (activos >= MaxPrestamosActivosPorUsuario)
            {
                return (false, $"El usuario alcanzó el máximo de {MaxPrestamosActivosPorUsuario} préstamos activos.", null);
            }

            Prestamo prestamo = new Prestamo
            {
                Id = GenerarId(),
                LibroPrestado = libro,
                UsuarioPrestatario = usuario,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = null,
                Estado = EstadoPrestamo.Activo
            };

            _prestamos.Add(prestamo);
            _libroService.MarcarPrestado(libro.Id);

            return (true, $"Préstamo {prestamo.Id} creado correctamente. Devolver antes del {prestamo.FechaPrestamo.AddDays(DiasPlazo):dd/MM/yyyy}.", prestamo);
        }

        /// <summary>Agrega un préstamo ya construido (usado para la carga inicial de datos).</summary>
        public Prestamo Agregar(Prestamo prestamo)
        {
            if (string.IsNullOrWhiteSpace(prestamo.Id))
            {
                prestamo.Id = GenerarId();
            }

            _prestamos.Add(prestamo);
            return prestamo;
        }

        public Prestamo? ObtenerPorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return _prestamos.FirstOrDefault(p =>
                string.Equals(p.Id, id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public List<Prestamo> ObtenerTodos()
        {
            return _prestamos.ToList();
        }

        public List<Prestamo> ObtenerActivos()
        {
            return _prestamos.Where(p => p.Estado == EstadoPrestamo.Activo).ToList();
        }

        public List<Prestamo> ObtenerCerrados()
        {
            return _prestamos.Where(p => p.Estado == EstadoPrestamo.Devuelto).ToList();
        }

        public List<Prestamo> ObtenerVencidos()
        {
            return _prestamos.Where(EsVencido).ToList();
        }

        public List<Prestamo> ObtenerPorUsuario(string idUsuarioODocumento)
        {
            Usuario? usuario = _usuarioService.ObtenerPorIdODocumento(idUsuarioODocumento);
            if (usuario is null)
            {
                return new List<Prestamo>();
            }

            return _prestamos.Where(p => p.UsuarioPrestatario.Id == usuario.Id).ToList();
        }

        public List<Prestamo> ObtenerPorLibro(string idLibro)
        {
            Libro? libro = _libroService.ObtenerPorId(idLibro);
            if (libro is null)
            {
                return new List<Prestamo>();
            }

            return _prestamos.Where(p => p.LibroPrestado.Id == libro.Id).ToList();
        }

        /// <summary>Marca el préstamo como devuelto y libera el libro.</summary>
        public (bool exito, string mensaje) RegistrarDevolucion(string id)
        {
            Prestamo? prestamo = ObtenerPorId(id);
            if (prestamo is null)
            {
                return (false, "No existe un préstamo con ese ID.");
            }

            if (prestamo.Estado == EstadoPrestamo.Devuelto)
            {
                return (false, "Ese préstamo ya fue devuelto.");
            }

            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            _libroService.MarcarDisponible(prestamo.LibroPrestado.Id);

            return (true, $"Devolución registrada para el préstamo {prestamo.Id}. El libro '{prestamo.LibroPrestado.Titulo}' quedó disponible.");
        }

        /// <summary>Solo permite eliminar préstamos cerrados (devueltos).</summary>
        public (bool exito, string mensaje) Eliminar(string id)
        {
            Prestamo? prestamo = ObtenerPorId(id);
            if (prestamo is null)
            {
                return (false, "No existe un préstamo con ese ID.");
            }

            if (prestamo.Estado == EstadoPrestamo.Activo)
            {
                return (false, "No se puede eliminar un préstamo activo. Primero registre la devolución.");
            }

            _prestamos.Remove(prestamo);
            return (true, $"Préstamo {prestamo.Id} eliminado correctamente.");
        }

        /// <summary>Indica si un préstamo está vencido sin modificar su estado.</summary>
        public bool EsVencido(Prestamo prestamo)
        {
            if (prestamo.Estado == EstadoPrestamo.Vencido)
            {
                return true;
            }

            return prestamo.Estado == EstadoPrestamo.Activo &&
                   prestamo.DiasTranscurridos() > DiasPlazo;
        }

        public void Limpiar()
        {
            _prestamos.Clear();
            _consecutivo = 1;
        }
    }
}
