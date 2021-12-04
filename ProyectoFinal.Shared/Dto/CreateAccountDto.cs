﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Shared.Dto
{
    public class CreateAccountDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public CreateAccountDto(string nombres, string apellidos, string correo, string clave)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Correo = correo;
            Clave = clave;
        }
    }
}
