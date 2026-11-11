using System;

namespace biblioteca.Models
{
    public class Prestamo
    {
        public string Id { get; set; } = string.Empty;
        public Libro LibroPrestado { get; set; } = new Libro();
        public Usuario UsuarioPrestatario { get; set; } = new Usuario();
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime? FechaDevolucion { get; set; } = null;
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

        // Constructor vacío
        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        // Constructor completo
        public Prestamo(string id, Libro libro, Usuario usuario, DateTime fechaPrestamo)
        {
            Id = id;
            LibroPrestado = libro;
            UsuarioPrestatario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        public bool EstaVencido()
        {
            // Consideramos vencido si han pasado más de 14 días y sigue Activo
            if (Estado == EstadoPrestamo.Activo && DiasTranscurridos() > 14)
            {
                Estado = EstadoPrestamo.Vencido;
                return true;
            }
            return Estado == EstadoPrestamo.Vencido;
        }

        public int DiasTranscurridos()
        {
            DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;
            return (fechaFinal - FechaPrestamo).Days;
        }

        public string ResumenCorto()
        {
            return $"Préstamo [{Id}] - Libro: {LibroPrestado.Titulo} | Usuario: {UsuarioPrestatario.Nombre} | Estado: {Estado}";
        }

        public string DetalleCompleto()
        {
            string devueltoStr = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente de devolución";
            return $"Préstamo ID: {Id}\nLibro: {LibroPrestado.ToString()}\nUsuario: {UsuarioPrestatario.ToString()}\nFecha Préstamo: {FechaPrestamo:dd/MM/yyyy}\nFecha Devolución: {devueltoStr}\nEstado: {Estado}\nDías transcurridos: {DiasTranscurridos()}\n¿Vencido?: {EstaVencido()}";
        }

        public override string ToString()
        {
            return $"Préstamo {Id} ({Estado}) - {LibroPrestado.Titulo} a {UsuarioPrestatario.Nombre}";
        }
    }
}
