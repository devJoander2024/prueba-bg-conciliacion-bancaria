using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_Walther_Olivo.Context;
using WebAPI_Walther_Olivo.Controllers;
using WebAPI_Walther_Olivo.Entities;
using Xunit;

namespace WebAPI_Walther_Olivo_Test
{
    public class ConciliacionControllerTests
    {
        private readonly AppDbContext _context;

        public ConciliacionControllerTests()
        {
            Console.WriteLine("Configuración del contexto en memoria");
            // Configuración del contexto en memoria
            // Usamos DbContextOptionsBuilder para configurar el DbContext con una base de datos en memoria:
            var options = new DbContextOptionsBuilder<AppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Base de datos única por prueba
                .Options;

            // Crear una instancia del contexto:

            _context = new AppDbContext(options);

            // Poblar datos iniciales para las pruebas
            // Estos datos solo viven en memoria y desaparecen al terminar la ejecución
            _context.RegistrosContables.AddRange(
                new RegistroContable { Id = 1, Descripcion = "Test Registro 1", Monto = 100, Fecha = DateTime.Parse("2023-01-01") },
                new RegistroContable { Id = 2, Descripcion = "Test Registro 2", Monto = 200, Fecha = DateTime.Parse("2023-01-02") }
            );

            _context.MovimientosBancarios.AddRange(
                new MovimientoBancario { Id = 1, Descripcion = "Movimiento 1", Monto = 100, Fecha = DateTime.Parse("2023-01-01") },
                new MovimientoBancario { Id = 2, Descripcion = "Movimiento 2", Monto = 300, Fecha = DateTime.Parse("2023-01-03") }
            );

            _context.SaveChanges();
        }

        [Fact]
        public void GetRegistros_ShouldReturnAllRegistros()
        {
            // Arrange
            var controller = new ConciliacionController(_context);

            // Act
            var result = controller.GetRegisstros() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var registros = result.Value as List<RegistroContable>;
            Assert.NotNull(registros);
            Assert.Equal(2, registros.Count); // Deben ser los 2 registros que añadimos
        }

        [Fact]
        public void GetMovimientos_ShouldReturnMovimientosByDate()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Base de datos única por prueba
       .Options;    

            using var context = new AppDbContext(options);

            // Poblar datos iniciales
            context.MovimientosBancarios.Add(new MovimientoBancario { Id = 1, Descripcion = "Movimiento 1", Fecha = DateTime.Parse("2023-01-01"), Monto = 100 });
            context.MovimientosBancarios.Add(new MovimientoBancario { Id = 2, Descripcion = "Movimiento 2", Fecha = DateTime.Parse("2023-01-02"), Monto = 200 });
            context.SaveChanges();

            // Arrange
            var controller = new ConciliacionController(_context);

            // Act
            var result = controller.GetMovimientos("2023-01-01") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var movimientos = result.Value as List<MovimientoBancario>;
            Assert.NotNull(movimientos);
            Assert.Single(movimientos); // Solo hay un movimiento para la fecha 2023-01-01
            Assert.Equal("Movimiento 1", movimientos[0].Descripcion); // Verificamos la descripción
        }
    }
}
