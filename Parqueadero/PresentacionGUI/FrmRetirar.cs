using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentacionGUI
{
    public partial class RetirarVehiculo : Form
    {
        public RetirarVehiculo()
        {
            InitializeComponent();
            var connectionString = ConfigConnection.connectionString;
            VehiculoServicio = new VehiculoServicio(connectionString);
            PersonaServicio = new PersonaServicio(connectionString);
            ParqueaderoServicio = new ParqueaderoServicio(connectionString);
        }

        VehiculoServicio VehiculoServicio;
        PersonaServicio PersonaServicio;
        ParqueaderoServicio ParqueaderoServicio;
        private void btAtras2_Click(object sender, EventArgs e)
        {
            RegistroUsuario registro = new RegistroUsuario();
            registro.Show();
            this.Hide();
        }


        private void RetirarVehiculo_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            List<Vehiculo> vehiculos = VehiculoServicio.Consultar();
            var datos = vehiculos.SelectMany(v => v.Personas, (v, p) => new
            {
                v.Placa,
                v.TipoVehiculo,
                v.Modelo,
                p.Nombre,
                p.Apellido,
                p.Cargo
            }
            ).ToList();

            ListaRegistro.DataSource = datos;
            ListaRegistro.Columns["Placa"].HeaderText = "Placa";
            ListaRegistro.Columns["TipoVehiculo"].HeaderText = "Tipo de vehiculo";
            ListaRegistro.Columns["Modelo"].HeaderText = "Modelo";
            ListaRegistro.Columns["Nombre"].HeaderText = "Nombre";
            ListaRegistro.Columns["Apellido"].HeaderText = "Apellido";
            ListaRegistro.Columns["Cargo"].HeaderText = "Cargo";
        }
        string total;
        private void textBuscar_TextChanged(object sender, EventArgs e)
        {            
            
        }
        private void btRetirar_Click(object sender, EventArgs e)
        {
            Retirar();
        }

        private void Retirar()
        {
            Vehiculo vehiculo = VehiculoServicio.BuscarVehiculo(textBuscar.Text);
            Persona persona = VehiculoServicio.BuscarPersona(textBuscar.Text);
            Parqueadero parqueadero = new Parqueadero
            {
                Placa = vehiculo.Placa,
                HorasTotalesParqueo = Convert.ToDouble(cbHora.SelectedItem.ToString()),
                Lugar = vehiculo.Lugar,
                HoraSalida = DateTime.Now
            };

            parqueadero.CalcularValor();
            if (vehiculo != null)
            {
                PersonaServicio.DeletePersona(persona);
                VehiculoServicio.DeleteVehiculo(vehiculo);
                ParqueaderoServicio.Guardar(parqueadero);
                MessageBox.Show("Vehiculo retirado");
            }
            else
            {
                MessageBox.Show("No se encontro la placa ingresada");
            }
            ActualizarTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = VehiculoServicio.BuscarVehiculo(textBuscar.Text);
            if (vehiculo != null)
            {
                textPlaca.Text = vehiculo.Placa;
            }
            else
            {
                MessageBox.Show("No se encontro la placa ingresada");
            }
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!textPlaca.Text.Equals(""))
            {
                double tarifa = 2000, descuento = 0.2;
                double Total = (Convert.ToDouble(cbHora.SelectedItem.ToString()) * tarifa) * (descuento);
                double TotalPagar = (Convert.ToDouble(cbHora.SelectedItem.ToString()) * tarifa) - Total;
                txtTotalPagar.Text = TotalPagar.ToString();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun coche", "Error");
            }
        }

        private void ListaRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = ListaRegistro.Rows[e.RowIndex].DataBoundItem as Parqueadero;
                if (fila != null)
                {
                    txtTotalPagar.Text = fila.TotalPagar.ToString();
                    textPlaca.Text = fila.Placa;
                }
            }
        }
    }
}
