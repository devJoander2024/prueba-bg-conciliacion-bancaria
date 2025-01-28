namespace WebAPI_Walther_Olivo.Entities
{
    public class RegistroContable
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }

    public class MovimientoBancario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Edad { get; set; }

    }

    public class DiscrepanciaResuelta
    {
        public int Id { get; set; }
        public int RegistroId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public bool Resuelta { get; set; } = true; // Este campo indica que ya está resuelta.
    }


}
