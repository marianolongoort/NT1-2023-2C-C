﻿using System.Collections.Generic;

namespace Estacionamiento_C.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int DNI { get; set; }
        

        public List<Telefono> Telefonos { get; set; }

        public string Foto { get; set; }

    }
}
