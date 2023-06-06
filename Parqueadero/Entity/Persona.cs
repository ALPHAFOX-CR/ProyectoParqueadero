using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Placa { get; set; }

        public override string ToString()
        {
            return $"{Nombre};{Apellido};{Cargo};{Placa}";
        }
    }
}
