using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services
{
    public class ColaService : IColaService
    {
        private readonly DatabaseContext _dbContext;

        public ColaService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AgregarPersona(Persona persona)
        {
            int tiempoAtencionCola1 = 2; // Tiempo de atención en minutos para la cola 1
            int tiempoAtencionCola2 = 3; // Tiempo de atención en minutos para la cola 2

            DateTime tiempoFinCola1 = ObtenerTiempoFinCola(1, tiempoAtencionCola1);
            DateTime tiempoFinCola2 = ObtenerTiempoFinCola(2, tiempoAtencionCola2);

            if (tiempoFinCola1 <= tiempoFinCola2)
            {
                persona.ColaId = 1;
                persona.TiempoRegistro = tiempoFinCola1;
            }
            else
            {
                persona.ColaId = 2;
                persona.TiempoRegistro = tiempoFinCola2;
            }

            try
            {
                _dbContext.Persona.Add(persona);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw new System.NotImplementedException();
            }
        }

        private DateTime ObtenerTiempoFinCola(int colaId, int tiempoAtencion)
        {
            var ultimaPersonaEnCola = _dbContext.Persona
            .Where(p => p.ColaId == colaId)
            .OrderByDescending(p => p.TiempoRegistro)
            .FirstOrDefault();

            if (ultimaPersonaEnCola == null)
            {
                return DateTime.Now.AddMinutes(tiempoAtencion);
            }

            return ultimaPersonaEnCola.TiempoRegistro.AddMinutes(tiempoAtencion);
        }        

        public async Task<List<Persona>> ObtenerColaAsync(int colaId)
        {

            VerificarYEliminarPersonasAtendidas(colaId);

            var tiempoLimite = DateTime.Now.AddMinutes(colaId == 1 ? 2 : 3);
            var personasEnCola = await _dbContext.Persona
                .Where(p => p.ColaId == colaId && p.TiempoRegistro <= tiempoLimite)
                .ToListAsync();

            return personasEnCola;
        }

        private void VerificarYEliminarPersonasAtendidas(int colaId)
        {
            var tiempoActual = DateTime.Now;

            // Filtra las personas en la cola y las elimina si ya fueron atendidas
            var personasEnCola = _dbContext.Persona
                .Where(p => p.ColaId == colaId)
                .ToList();

            foreach (var persona in personasEnCola)
            {
                var tiempoFinAtencion = persona.TiempoRegistro.AddMinutes(colaId == 1 ? 2 : 3);

                // Comparamos directamente con el tiempo actual
                if (tiempoFinAtencion <= tiempoActual)
                {
                    _dbContext.Persona.Remove(persona);
                }
            }

            _dbContext.SaveChanges();
        }


    }
}
