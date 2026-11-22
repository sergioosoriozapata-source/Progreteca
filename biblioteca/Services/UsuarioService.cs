using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca.Models;

namespace biblioteca.Services
{
    /// <summary>
    /// Capa de servicios para la gestión de usuarios usando List&lt;Usuario&gt;.
    /// Centraliza registro, consulta, actualización, activación/desactivación,
    /// búsqueda y eliminación de usuarios.
    /// </summary>
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();
        private int _consecutivo = 1;

        public IReadOnlyList<Usuario> Usuarios => _usuarios;
        public int Total => _usuarios.Count;
        public int TotalActivos => _usuarios.Count(u => u.Activo);
        public int TotalInactivos => _usuarios.Count(u => !u.Activo);

        public string GenerarId()
        {
            return $"U{_consecutivo++:D3}";
        }

        /// <summary>Registra un usuario nuevo y devuelve el objeto creado.</summary>
        public (bool exito, string mensaje, Usuario? usuario) Registrar(string nombre, string apellido, string documento, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                return (false, "Nombre y apellido son obligatorios.", null);
            }

            if (string.IsNullOrWhiteSpace(documento))
            {
                return (false, "El documento es obligatorio.", null);
            }

            if (ObtenerPorDocumento(documento) is not null)
            {
                return (false, $"Ya existe un usuario con el documento {documento}.", null);
            }

            Usuario usuario = new Usuario
            {
                Id = GenerarId(),
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                Documento = documento.Trim(),
                Telefono = telefono.Trim(),
                Activo = true
            };

            _usuarios.Add(usuario);
            return (true, $"Usuario registrado con ID {usuario.Id}.", usuario);
        }

        /// <summary>Agrega un usuario ya construido (usado para la carga inicial de datos).</summary>
        public Usuario Agregar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Id))
            {
                usuario.Id = GenerarId();
            }

            _usuarios.Add(usuario);
            return usuario;
        }

        public Usuario? ObtenerPorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return _usuarios.FirstOrDefault(u =>
                string.Equals(u.Id, id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public Usuario? ObtenerPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                return null;
            }

            return _usuarios.FirstOrDefault(u =>
                string.Equals(u.Documento, documento.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Busca un usuario por ID o por documento.</summary>
        public Usuario? ObtenerPorIdODocumento(string valor)
        {
            return ObtenerPorId(valor) ?? ObtenerPorDocumento(valor);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios.ToList();
        }

        public List<Usuario> Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return new List<Usuario>();
            }

            string c = criterio.Trim();
            return _usuarios.Where(u =>
                u.Id.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                u.Documento.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                u.Nombre.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                u.Apellido.Contains(c, StringComparison.OrdinalIgnoreCase) ||
                $"{u.Nombre} {u.Apellido}".Contains(c, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public (bool exito, string mensaje) ActualizarNombre(string id, string nuevoNombre, string nuevoApellido)
        {
            Usuario? usuario = ObtenerPorId(id);
            if (usuario is null)
            {
                return (false, "No existe un usuario con ese ID.");
            }

            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                return (false, "El nombre no puede estar vacío.");
            }

            usuario.Nombre = nuevoNombre.Trim();
            if (!string.IsNullOrWhiteSpace(nuevoApellido))
            {
                usuario.Apellido = nuevoApellido.Trim();
            }

            return (true, $"Nombre actualizado a '{usuario.Nombre} {usuario.Apellido}'.");
        }

        public (bool exito, string mensaje) ActualizarContacto(string id, string nuevoTelefono)
        {
            Usuario? usuario = ObtenerPorId(id);
            if (usuario is null)
            {
                return (false, "No existe un usuario con ese ID.");
            }

            if (string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                return (false, "El teléfono no puede estar vacío.");
            }

            usuario.Telefono = nuevoTelefono.Trim();
            return (true, $"Contacto actualizado a '{usuario.Telefono}'.");
        }

        public (bool exito, string mensaje) CambiarEstado(string id)
        {
            Usuario? usuario = ObtenerPorId(id);
            if (usuario is null)
            {
                return (false, "No existe un usuario con ese ID.");
            }

            usuario.Activo = !usuario.Activo;
            string estado = usuario.Activo ? "ACTIVO" : "INACTIVO";
            return (true, $"El usuario {usuario.Nombre} {usuario.Apellido} ahora está {estado}.");
        }

        public (bool exito, string mensaje) Eliminar(string id)
        {
            Usuario? usuario = ObtenerPorId(id);
            if (usuario is null)
            {
                return (false, "No existe un usuario con ese ID.");
            }

            _usuarios.Remove(usuario);
            return (true, $"Usuario '{usuario.Nombre} {usuario.Apellido}' eliminado correctamente.");
        }

        public void Limpiar()
        {
            _usuarios.Clear();
            _consecutivo = 1;
        }
    }
}
