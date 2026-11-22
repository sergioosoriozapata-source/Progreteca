using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca.Models;

namespace biblioteca.Services
{
    /// <summary>
    /// Capa de servicios para la gestión de libros usando List&lt;Libro&gt;.
    /// Centraliza las operaciones de registro, consulta, actualización,
    /// búsqueda y eliminación de libros.
    /// </summary>
    public class LibroService
    {
        private readonly List<Libro> _libros = new List<Libro>();
        private int _consecutivo = 1;

        public IReadOnlyList<Libro> Libros => _libros;
        public int Total => _libros.Count;
        public int TotalDisponibles => _libros.Count(l => l.Disponible);
        public int TotalPrestados => _libros.Count(l => !l.Disponible);

        public string GenerarId()
        {
            return $"L{_consecutivo++:D3}";
        }

        /// <summary>Registra un libro nuevo y devuelve el objeto creado.</summary>
        public Libro Registrar(string titulo, string autor, string categoria, int anio)
        {
            Libro libro = new Libro
            {
                Id = GenerarId(),
                Titulo = titulo.Trim(),
                Autor = autor.Trim(),
                Categoria = categoria.Trim(),
                Anio = anio,
                Disponible = true
            };

            _libros.Add(libro);
            return libro;
        }

        /// <summary>Agrega un libro ya construido (usado para la carga inicial de datos).</summary>
        public Libro Agregar(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Id))
            {
                libro.Id = GenerarId();
            }

            _libros.Add(libro);
            return libro;
        }

        public Libro? ObtenerPorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return _libros.FirstOrDefault(l =>
                string.Equals(l.Id, id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public List<Libro> ObtenerTodos()
        {
            return _libros.ToList();
        }

        public List<Libro> ObtenerDisponibles()
        {
            return _libros.Where(l => l.Disponible).ToList();
        }

        public List<Libro> ObtenerPrestados()
        {
            return _libros.Where(l => !l.Disponible).ToList();
        }

        /// <summary>Busca por ID/ISBN, título, autor o categoría.</summary>
        public List<Libro> Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return new List<Libro>();
            }

            string c = criterio.Trim();
            return _libros.Where(l =>
                l.Id.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                l.Titulo.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                l.Autor.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                l.Categoria.Contains(c, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public (bool exito, string mensaje) ActualizarTitulo(string id, string nuevoTitulo)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null)
            {
                return (false, "No existe un libro con ese ID/ISBN.");
            }

            if (string.IsNullOrWhiteSpace(nuevoTitulo))
            {
                return (false, "El título no puede estar vacío.");
            }

            libro.Titulo = nuevoTitulo.Trim();
            return (true, $"Título actualizado a '{libro.Titulo}'.");
        }

        public (bool exito, string mensaje) ActualizarAutor(string id, string nuevoAutor)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null)
            {
                return (false, "No existe un libro con ese ID/ISBN.");
            }

            if (string.IsNullOrWhiteSpace(nuevoAutor))
            {
                return (false, "El autor no puede estar vacío.");
            }

            libro.Autor = nuevoAutor.Trim();
            return (true, $"Autor actualizado a '{libro.Autor}'.");
        }

        public (bool exito, string mensaje) ActualizarAnioCategoria(string id, int nuevoAnio, string nuevaCategoria)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null)
            {
                return (false, "No existe un libro con ese ID/ISBN.");
            }

            if (nuevoAnio <= 0)
            {
                return (false, "El año debe ser mayor que cero.");
            }

            libro.Anio = nuevoAnio;
            if (!string.IsNullOrWhiteSpace(nuevaCategoria))
            {
                libro.Categoria = nuevaCategoria.Trim();
            }

            return (true, $"Año/categoría actualizados: {libro.Anio} - {libro.Categoria}.");
        }

        public (bool exito, string mensaje) Eliminar(string id)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null)
            {
                return (false, "No existe un libro con ese ID/ISBN.");
            }

            if (!libro.Disponible)
            {
                return (false, "No se puede eliminar: el libro está prestado actualmente.");
            }

            _libros.Remove(libro);
            return (true, $"Libro '{libro.Titulo}' eliminado correctamente.");
        }

        public bool MarcarPrestado(string id)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null || !libro.Disponible)
            {
                return false;
            }

            libro.Disponible = false;
            return true;
        }

        public bool MarcarDisponible(string id)
        {
            Libro? libro = ObtenerPorId(id);
            if (libro is null)
            {
                return false;
            }

            libro.Disponible = true;
            return true;
        }

        public void Limpiar()
        {
            _libros.Clear();
            _consecutivo = 1;
        }
    }
}
