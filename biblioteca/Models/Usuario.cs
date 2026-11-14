using System;

namespace biblioteca.Models
{
    public class Usuario
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Constructor vacío
        public Usuario()
        {
            Activo = true;
        }

        // Constructor completo
        public Usuario(string id, string nombre, string apellido, string documento, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Telefono = telefono;
            Activo = true;
        }

        public string ResumenCorto()
        {
            return $"[{Id}] {Nombre} {Apellido} - Doc: {Documento} | Activo: {Activo}";
        }

        public string DetalleCompleto()
        {
            return $"Usuario ID: {Id}\nNombre: {Nombre} {Apellido}\nDocumento: {Documento}\nTeléfono: {Telefono}\nEstado Activo: {Activo}";
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} (Doc: {Documento})";
        }
    }
}
