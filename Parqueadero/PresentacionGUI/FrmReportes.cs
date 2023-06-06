using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;
using Entity;

namespace PresentacionGUI
{
    public partial class ReporteSistemas : Form
    {
        public ReporteSistemas()
        {
            InitializeComponent();
            var connectionString = ConfigConnection.connectionString;
            ParqueaderoServicio = new ParqueaderoServicio(connectionString);
        }

        ParqueaderoServicio ParqueaderoServicio;

        private void btAtras1_Click(object sender, EventArgs e)
        {
            RegistroUsuario registro = new RegistroUsuario();
            registro.Show();
            this.Hide();
        }

        private void ReporteSistemas_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            List<Parqueadero> parqueadero = ParqueaderoServicio.Consultar();
            var datos = parqueadero.SelectMany(p => p.Vehiculos, (p, v) => new
            {
                p.Placa,
                p.Lugar,
                p.HorasTotalesParqueo,
                p.TotalPagar,
                p.HoraSalida,
                v.TipoVehiculo,
                v.HoraLlegada,
                Nombre = p.Personas.Select(persona => persona.Nombre).FirstOrDefault(),
                Apellido = p.Personas.Select(persona => persona.Apellido).FirstOrDefault(),
            }).ToList();

            LlenarDGV(datos);
        }

        private void Filtrar(string placa)
        {
            List<Parqueadero> parqueadero = ParqueaderoServicio.FiltrarPorPlaca(placa);
            var datos = parqueadero.SelectMany(p => p.Vehiculos, (p, v) => new
            {
                p.Placa,
                p.Lugar,
                p.HorasTotalesParqueo,
                p.TotalPagar,
                p.HoraSalida,
                v.TipoVehiculo,
                v.HoraLlegada,
                Nombre = p.Personas.Select(persona => persona.Nombre).FirstOrDefault(),
                Apellido = p.Personas.Select(persona => persona.Apellido).FirstOrDefault(),
            }).ToList();

            LlenarDGV(datos);
        }

        private void LlenarDGV<T>(List<T> datos)
        {
            {
                dataGridView1.DataSource = datos;

                dataGridView1.Columns["Placa"].DisplayIndex = 0;
                dataGridView1.Columns["TipoVehiculo"].DisplayIndex = 1;
                dataGridView1.Columns["Lugar"].DisplayIndex = 2;
                dataGridView1.Columns["HorasTotalesParqueo"].DisplayIndex = 3;
                dataGridView1.Columns["HoraLlegada"].DisplayIndex = 4;
                dataGridView1.Columns["HoraSalida"].DisplayIndex = 5;
                dataGridView1.Columns["TotalPagar"].DisplayIndex = 6;
                dataGridView1.Columns["Nombre"].DisplayIndex = 7;
                dataGridView1.Columns["Apellido"].DisplayIndex = 8;

                dataGridView1.Columns["Placa"].HeaderText = "Placa";
                dataGridView1.Columns["Lugar"].HeaderText = "Lugar";
                dataGridView1.Columns["HorasTotalesParqueo"].HeaderText = "Horas de parqueo";
                dataGridView1.Columns["TotalPagar"].HeaderText = "Total a Pagar";
                dataGridView1.Columns["HoraLlegada"].HeaderText = "Hora de llegada";
                dataGridView1.Columns["HoraSalida"].HeaderText = "Hora de salida";
                dataGridView1.Columns["TipoVehiculo"].HeaderText = "Tipo de Vehículo";
                dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
                dataGridView1.Columns["Apellido"].HeaderText = "Apellido";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {

                Filtrar(textBox1.Text);
            }
            else
            {
                Consultar();
            }
        }
    }
}
