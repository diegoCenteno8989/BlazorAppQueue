using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManejoColaController : ControllerBase
    {
        private readonly IColaService _colaService;

        public ManejoColaController(IColaService colaService)
        {
            _colaService = colaService;
        }

        [HttpPost]
        public IActionResult AgregarPersona([FromBody] PersonaViewModel personaViewModel)
        {
            var persona = new Persona
            {
                Id = personaViewModel.Id,
                Nombre = personaViewModel.Nombre,
                ColaId = personaViewModel.ColaId,
                TiempoRegistro = DateTime.Now
            };

            _colaService.AgregarPersona(persona);
            return Ok();
        }

        [HttpGet("manejocola/{colaId}")]
        public IActionResult ObtenerCola(int colaId)
        {
            var personasEnCola = _colaService.ObtenerCola(colaId);
            return Ok(personasEnCola);
        }
    }
}
