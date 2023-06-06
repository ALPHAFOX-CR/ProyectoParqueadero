using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }
        public string Lugar { get; set; }
        public DateTime HoraLlegada { get; set; }

        public List<Persona> Personas { get; set; }
        public Vehiculo()
        {
            Personas = new List<Persona>();
        }


    }
}
