﻿using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Interfaces
{
    public interface IColaService
    {
        void AgregarPersona(Persona persona);
        Task<List<Persona>> ObtenerColaAsync(int colaId);
    }
}
