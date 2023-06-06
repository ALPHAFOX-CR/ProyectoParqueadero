using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ingresar();
        }



        public static void RegistrarIngreso()
        {
            ParqueaderoServicio parqueaderoServicio = new ParqueaderoServicio();
            Persona persona = new Persona();
            Parqueadero parqueadero = new Parqueadero();
            Vehiculo vehiculo = new Vehiculo();
            Console.WriteLine("REGISTRAR INGRESO: ");
            Console.WriteLine("");
            Console.WriteLine("Ingrese los datos: ");
            Console.WriteLine("");
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            var apellido = Console.ReadLine();
            Console.Write("Cargo: ");
            var cargo = Console.ReadLine();
            Console.Write("Lugar de Parqueadero: ");
            var lugarParqueadero = Console.ReadLine();
            Console.Write("Tipo de vehículo: ");
            var tipoVehiculo = Console.ReadLine();
            Console.Write("Modelo: ");
            var Modelo = Console.ReadLine();
            Console.Write("Placa: ");
            var placa = Console.ReadLine();




            persona.Nombre = nombre;
            persona.Apellido = apellido;
            persona.Cargo = cargo;
            parqueadero.Lugar = lugarParqueadero;
            vehiculo.TipoVehiculo = tipoVehiculo;
            vehiculo.Modelo = Modelo;
            vehiculo.Placa = placa;
            parqueaderoServicio.Guardar(vehiculo, parqueadero, persona);
        }

        public static void RegistrarSalidaVehiculo()
        {
            Parqueadero parqueadero = new Parqueadero();
            Console.WriteLine("     REGISTRAR SALIDA: ");
            Console.WriteLine("");
            Console.Write("Ingrese placa del vehículo: ");
            var placa = Console.ReadLine();
            Console.Write("Ingrese horas totales: ");
            double horasTotales = Convert.ToDouble(Console.ReadLine());
            parqueadero.HorasTotalesParqueo = horasTotales;
            //parqueadero.CalcularValor();

            Console.WriteLine("Descuento : " + parqueadero.Total);
            Console.WriteLine("Horas : " + horasTotales);
            Console.WriteLine("El Total a pagar es: " + parqueadero.TotalPagar);
            Console.ReadKey();

        }

        public static void Ingresar()
        {
            var opcion = "";
            do
            {
                Console.WriteLine("               MENÚ           ");
                Console.WriteLine("");
                Console.WriteLine("1. Registrar ingreso de vehículo.");
                Console.WriteLine("2. Registrar salida de vehículo.");
                Console.WriteLine("3. Salir.");
                Console.WriteLine("");
                Console.Write("Seleccione una opción: ");

                opcion = Console.ReadLine();
                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        RegistrarIngreso();
                        Console.Clear();
                        break;
                    case "2":
                        RegistrarSalidaVehiculo();
                        Console.Clear();
                        break;
                    default:
                        Console.Write("sistema finalizado");
                        break;

                }
                Console.Clear();
            } while (opcion != "3");

        }
    }
}
