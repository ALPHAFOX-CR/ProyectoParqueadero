using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Parqueadero
    {

        public string Lugar { get; set; }
        public double HorasTotalesParqueo { get; set; }
        public double TarifaHora { get; set; }
        public double Descuento { get; set; }
        public double TotalPagar { get; set; }
        public double Total { get; set; }
        public string Placa { get; set; }
        public DateTime HoraSalida { get; set; }

        public List<Vehiculo> Vehiculos  { get; set; }
        public List<Persona> Personas { get; set; }

        public Parqueadero()
        {
            Vehiculos = new List<Vehiculo>();
            Personas = new List<Persona>();
        }

        public void CalcularValor()
        {
            Descuento = 0.2;
            TarifaHora = 2000;
            Total = (HorasTotalesParqueo * TarifaHora) * (Descuento);
            TotalPagar = (HorasTotalesParqueo * TarifaHora) - Total;
        }
    }
}
