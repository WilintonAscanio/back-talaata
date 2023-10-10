using System.Numerics;

namespace backTalaata.Models
{
    public class Employee
    {
        public int employeeID { get; set; }

        public int Documento { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;

    }

}
