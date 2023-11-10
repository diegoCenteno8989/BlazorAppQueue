using BlazorApp.Server.Models;
using BlazorApp.Server.Services;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppBlazorTest
{
    
    public class ColaServiceTest
    {
        [Fact]
        public void ObtenerPersonasCola_DebeEliminarPersonasAtendidas()
        {
            // Arrange
            var opciones = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new DatabaseContext(opciones))
            {
                var service = new ColaService(dbContext);

                // Agregamos una persona a la cola con tiempo de finalización pasado
                var persona = new Persona { ColaId = 1, TiempoRegistro = DateTime.Now.AddMinutes(-5) };
                dbContext.Persona.Add(persona);
                dbContext.SaveChanges();

                // Act
                service.ObtenerColaAsync(1);

                // Assert
                Assert.Empty(dbContext.Persona.ToList());
            }
        }
    }
}
