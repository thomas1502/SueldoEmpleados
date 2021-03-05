using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SueldoEmpleados
{
    class EmpleadoSueldo
    {
        int noEmpleado;
        string nombreEmpleado;
        float sueldoMes;
        string mes;

        public int NoEmpleado { get => noEmpleado; set => noEmpleado = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public float SueldoMes { get => sueldoMes; set => sueldoMes = value; }
        public string Mes { get => mes; set => mes = value; }
    }
}
