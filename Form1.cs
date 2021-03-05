using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SueldoEmpleados
{
    public partial class Form1 : Form
    {
        // Crear listas
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        List<EmpleadoSueldo> empleadosueldo = new List<EmpleadoSueldo>();

        // Funciones propias
        private void GuardarEmpleado()
        {
            FileStream stream = new FileStream("Empleados.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in empleados)
            {
                writer.WriteLine(p.Codigo);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.SueldoHora);
            }

            writer.Close();
        }
        private void GuardarAsistencia()
        {
            FileStream stream = new FileStream("Asistencia.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in asistencias)
            {
                writer.WriteLine(p.Codigo);
                writer.WriteLine(p.HorasMes);
                writer.WriteLine(p.Mes);
            }

            writer.Close();
        }
        private void LeerEmpleado()
        {
            FileStream stream = new FileStream("Empleados.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleado empleadoTemp = new Empleado();
                empleadoTemp.Codigo = int.Parse(reader.ReadLine());
                empleadoTemp.Nombre = reader.ReadLine();
                empleadoTemp.SueldoHora = float.Parse(reader.ReadLine());

                empleados.Add(empleadoTemp);
            }
            reader.Close();
        }
        private void LeerAsistencia()
        {
            FileStream stream = new FileStream("Asistencia.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Asistencia asistenciaTemp = new Asistencia();
                asistenciaTemp.Codigo = int.Parse(reader.ReadLine());
                asistenciaTemp.HorasMes = int.Parse(reader.ReadLine());
                asistenciaTemp.Mes = reader.ReadLine();

                asistencias.Add(asistenciaTemp);
            }
            reader.Close();

        }
        // Funciones de botones
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            LeerEmpleado();
            LeerAsistencia();

            // Mostrar listado de empleados
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();

            // Mostrar listado de asistencia
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = asistencias;
            dataGridView2.Refresh();

            // Cargar ComboBox con el No. de empleados
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = null;
            comboBox1.DataSource = empleados;
            comboBox1.Refresh();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Agregar a la lista Empleado
            Empleado empleadoTemp = new Empleado();

            empleadoTemp.Codigo = Convert.ToInt32(txtCodigo.Text);
            empleadoTemp.Nombre = txtNombre.Text;
            empleadoTemp.SueldoHora = float.Parse(txtSueldoHora.Text);
            empleados.Add(empleadoTemp);
            GuardarEmpleado();

            // Agregar a la lista Asistencia
            Asistencia asistenciaTemp = new Asistencia();

            asistenciaTemp.Codigo = Convert.ToInt32(txtCodigo.Text);
            asistenciaTemp.HorasMes = Convert.ToInt32(txtHorasMes.Text);
            asistenciaTemp.Mes = txtMes.Text;
            asistencias.Add(asistenciaTemp);
            GuardarAsistencia();

            // Dejar listo para un nuevo ingreso
            txtCodigo.Clear();
            txtNombre.Clear();
            txtSueldoHora.Clear();
            txtHorasMes.Clear();
            txtMes.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {            
            // Agregar a la lista Empleado
            
            for(int x = 0; x < empleados.Count;x++)
            {
                for(int y = 0; y < asistencias.Count;y++)
                {
                    if(empleados[x].Codigo == asistencias[y].Codigo)
                    {
                        EmpleadoSueldo empleadoSueldoTemp = new EmpleadoSueldo();
                        empleadoSueldoTemp.NoEmpleado = empleados[x].Codigo;
                        empleadoSueldoTemp.NombreEmpleado = empleados[x].Nombre;
                        empleadoSueldoTemp.SueldoMes = empleados[x].SueldoHora * asistencias[y].HorasMes;
                        empleadoSueldoTemp.Mes = asistencias[y].Mes;

                        empleadosueldo.Add(empleadoSueldoTemp);
                    }
                }
            }
            // Mostrar en el dataGriedView
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = empleadosueldo;
            dataGridView3.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int noEmpleado = Convert.ToInt32(comboBox1.SelectedValue);
            EmpleadoSueldo EmpleadoSueldo = empleadosueldo.Find(s => s.NoEmpleado == noEmpleado);

            labelNombre.Text = EmpleadoSueldo.NombreEmpleado;
            labelSueldo.Text = EmpleadoSueldo.SueldoMes.ToString();
            labelMes.Text = EmpleadoSueldo.Mes;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
