using System;

namespace biblioteca.Models
{
    public class Libro
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Anio { get; set; }
        public bool Disponible { get; set; } = true;

        // Constructor vacío
        public Libro()
        {
            Disponible = true;
        }

        // Constructor completo
        public Libro(string id, string titulo, string autor, string categoria, int anio)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            Anio = anio;
            Disponible = true;
        }

        public string ResumenCorto()
        {
            return $"[{Id}] {Titulo} - {Autor} ({Anio}) | Disponible: {Disponible}";
        }

        public string DetalleCompleto()
        {
            return $"Libro ID: {Id}\nTítulo: {Titulo}\nAutor: {Autor}\nCategoría: {Categoria}\nAño: {Anio}\nEstado Disponible: {Disponible}";
        }

        public override string ToString()
        {
            return $"{Titulo} por {Autor} [{Anio}]";
        }
    }
}
