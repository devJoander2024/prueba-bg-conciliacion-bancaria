using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Walther_Olivo.Context;
using WebAPI_Walther_Olivo.Dtos;
using WebAPI_Walther_Olivo.Entities;

namespace WebAPI_Walther_Olivo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConciliacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConciliacionController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Consultar registros contables y movimientos bancarios
        [HttpGet("registros")]
        public IActionResult GetRegistros()
        {
            var registros = _context.RegistrosContables.ToList();
            return Ok(registros);
        }

        [HttpGet("movimientos")]
        public IActionResult GetMovimientos([FromQuery] string date)
        {
            var movimientos = _context.MovimientosBancarios.ToList().Where(rc => rc.Fecha == DateTime.Parse(date));
            return Ok(movimientos);
        }

        // 2. Realizar la conciliación bancaria
        [HttpPost("conciliacion")]
        public IActionResult Conciliar()
        {
            var registros = _context.RegistrosContables.ToList();
            var movimientos = _context.MovimientosBancarios.ToList();

            // Identificar las discrepancias entre los registros contables y los movimientos bancarios
            var discrepancias = registros
                .Where(rc => !movimientos.Any(mb =>
                    mb.Fecha == rc.Fecha &&
                    mb.Monto == rc.Monto &&
                    mb.Descripcion == rc.Descripcion))
                .ToList();

            // Agregar las discrepancias a la tabla de Discrepancias Resueltas
            foreach (var discrepancia in discrepancias)
            {
                _context.DiscrepanciasResueltas.Add(new DiscrepanciaResuelta
                {
                    RegistroId = discrepancia.Id,
                    Descripcion = discrepancia.Descripcion,
                    Fecha = discrepancia.Fecha,
                    Monto = discrepancia.Monto
                });
            }

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            return Ok(discrepancias);
        }

        // 3. Marcar discrepancias como resueltas (sin eliminar registros)
        [HttpPost("resolver")]
        public IActionResult ResolverDiscrepancia([FromBody] int id)
        {
            var registro = _context.RegistrosContables.FirstOrDefault(r => r.Id == id);
            if (registro != null)
            {
                // Al resolver la discrepancia, la agregamos a la tabla de Discrepancias Resueltas
                _context.DiscrepanciasResueltas.Add(new DiscrepanciaResuelta
                {
                    RegistroId = registro.Id,
                    Descripcion = registro.Descripcion,
                    Fecha = registro.Fecha,
                    Monto = registro.Monto
                });

                // Guardar los cambios en la base de datos
                _context.SaveChanges();

                return Ok("Discrepancia resuelta.");
            }

            return NotFound("Registro no encontrado.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.UsernameOrEmail) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest(new { message = "Username/Email and Password are required" });
            }

            // Busca el usuario por username o email
            var user = _context.Usuarios
                .FirstOrDefault(u =>
                    (u.Username == loginRequest.UsernameOrEmail || u.Email == loginRequest.UsernameOrEmail)
                    && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username, email or password" });
            }

            return Ok(new { message = "Login successful", user = new { user.Id, user.Nombre, user.Apellido, user.Email } });
        }
    }
}
