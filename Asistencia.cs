﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SueldoEmpleados
{
    class Asistencia
    {
        int codigo;
        int horasMes;
        String mes;

        public int Codigo { get => codigo; set => codigo = value; }
        public int HorasMes { get => horasMes; set => horasMes = value; }
        public string Mes { get => mes; set => mes = value; }
    }
}
