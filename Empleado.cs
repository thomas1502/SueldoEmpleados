﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SueldoEmpleados
{
    class Empleado
    {
        int codigo;
        String nombre;
        float sueldoHora;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float SueldoHora { get => sueldoHora; set => sueldoHora = value; }
    }
}
