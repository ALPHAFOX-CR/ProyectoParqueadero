using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entity;

namespace DAL
{
    public class RepositorioParqueadero
    {
        #region CodigoArchivoPlano
        //    private string RutaParqueadero = "parqueadero.txt";
        //    private string RutaPersona = "persona.txt";
        //    private string RutaVehiculo = "vehiculo.txt";
        //    public string AgregarPersona(Persona persona)
        //    {
        //        StreamWriter streamWriter = new StreamWriter(RutaPersona, true);
        //        streamWriter.WriteLine(persona.ToString());
        //        streamWriter.Close();
        //        return $"\nDato almacenado\n";
        //    }

        //    public string AgregarVehiculo(Vehiculo vehiculo)
        //    {
        //        StreamWriter streamWriter = new StreamWriter(RutaVehiculo, true);
        //        streamWriter.WriteLine(vehiculo.ToString());
        //        streamWriter.Close();
        //        return $"\nDato almacenado\n";
        //    }

        //    public string AgregarParqueadero(Parqueadero parqueadero)
        //    {
        //        StreamWriter streamWriter = new StreamWriter(RutaParqueadero, true);
        //        streamWriter.WriteLine(parqueadero.ToString());
        //        streamWriter.Close();

        //        return $"\nDato almacenado\n";
        //    }
        //    public List<Persona> ConsultarPersonas()
        //    {
        //        List<Persona> personas = new List<Persona>();

        //        StreamReader sr = new StreamReader(RutaPersona);
        //        while (!sr.EndOfStream)
        //        {
        //            personas.Add(MapeadorPersonas(sr.ReadLine()));
        //        }
        //        sr.Close();
        //        return personas;
        //    }

        //    public Persona MapeadorPersonas(string contacto)
        //    {
        //        try
        //        {
        //            Persona persona = new Persona();
        //            String[] strings = contacto.Split(';');

        //            persona.Nombre = strings[0];
        //            persona.Apellido = strings[1];
        //            persona.Cargo = strings[2];
        //            persona.Placa = strings[3];
        //            return persona;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }

        //    public List<Vehiculo> ConsultarVehiculos()
        //    {
        //        List<Vehiculo> vehiculo = new List<Vehiculo>();

        //        StreamReader sr = new StreamReader(RutaVehiculo);
        //        while (!sr.EndOfStream)
        //        {
        //            vehiculo.Add(MapeadorVehiculos(sr.ReadLine()));
        //        }
        //        sr.Close();
        //        return vehiculo;
        //    }

        //    public Vehiculo MapeadorVehiculos(string contacto)
        //    {
        //        try
        //        {
        //            Vehiculo vehiculo = new Vehiculo();
        //            String[] strings = contacto.Split(';');

        //            vehiculo.Placa = strings[0];
        //            vehiculo.Modelo = strings[1];
        //            vehiculo.TipoVehiculo = strings[2];
        //            return vehiculo;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }

        //    public List<Parqueadero> ConsultarParqueadero()
        //    {
        //        List<Parqueadero> personas = new List<Parqueadero>();

        //        StreamReader sr = new StreamReader(RutaParqueadero);
        //        while (!sr.EndOfStream)
        //        {
        //            personas.Add(MapeadorParqueadero(sr.ReadLine()));
        //        }
        //        sr.Close();
        //        return personas;
        //    }

        //    public Parqueadero MapeadorParqueadero(string contacto)
        //    {
        //        try
        //        {
        //            Parqueadero parqueadero = new Parqueadero();
        //            String[] strings = contacto.Split(';');

        //            parqueadero.Lugar = strings[0];
        //            parqueadero.HorasTotalesParqueo = Convert.ToDouble(strings[1]);
        //            parqueadero.TarifaHora = Convert.ToDouble(strings[2]);
        //            parqueadero.Descuento = Convert.ToDouble(strings[3]);
        //            parqueadero.TotalPagar = Convert.ToDouble(strings[4]);
        //            parqueadero.Total = Convert.ToDouble(strings[5]);
        //            return parqueadero;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }

        //    public List<Vehiculo> BuscarVehiculo(string placa)
        //    {
        //        return ConsultarVehiculos().Where(p => p.Placa.Contains(placa)).ToList();
        //    }

        //    public void EliminarVehiculo(string placa)
        //    {
        //        List<Vehiculo> vehiculos;
        //        vehiculos = ConsultarVehiculos();
        //        FileStream file = new FileStream(RutaVehiculo, FileMode.Create);
        //        file.Close();
        //        foreach (var item in vehiculos)
        //        {
        //            if (!Encontrar(Convert.ToString(item.Placa), placa))
        //            {
        //                AgregarVehiculo(item);
        //            }
        //        }
        //    }

        //    public void EliminarPersona(string placa)
        //    {
        //        List<Persona> personas;
        //        personas = ConsultarPersonas();
        //        FileStream file = new FileStream(RutaPersona, FileMode.Create);
        //        file.Close();
        //        foreach (var item in personas)
        //        {
        //            if (!Encontrar(Convert.ToString(item.Placa), placa))
        //            {
        //                AgregarPersona(item);
        //            }
        //        }
        //    }

        //    public Persona Buscar(string placa)
        //    {
        //        List<Persona> personas = ConsultarPersonas();
        //        foreach (var item in personas)
        //        {
        //            if (Encontrar(Convert.ToString(item.Placa), placa))
        //            {
        //                return item;
        //            }
        //        }
        //        return null;
        //    }

        //    public bool Encontrar(string placaRegistrada, string pacaBuscar)
        //    {
        //        return placaRegistrada == pacaBuscar;
        //    }
        //}
        #endregion

        SqlConnection _connection;
        public RepositorioParqueadero(ConnectionManager connection)
        {
            _connection = connection.connection;
        }


        public string Insert(Parqueadero parqueadero)
        {
            using (var Comando = _connection.CreateCommand())
            {
                Comando.CommandText = "Insert Into Parqueaderos (Lugar,HorasTotalesParqueo,TotalPagar,Placa,HoraSalida)" +
                " values (@Lugar,@HorasTotalesParqueo,@TotalPagar,@Placa,@HoraSalida)";
                Comando.Parameters.Add("Lugar", SqlDbType.VarChar).Value = parqueadero.Lugar;
                Comando.Parameters.Add("HorasTotalesParqueo", SqlDbType.Float).Value = parqueadero.HorasTotalesParqueo;
                Comando.Parameters.Add("TotalPagar", SqlDbType.Float).Value = parqueadero.TotalPagar;
                Comando.Parameters.Add("Placa", SqlDbType.VarChar).Value = parqueadero.Placa;
                Comando.Parameters.AddWithValue("@HoraSalida", parqueadero.HoraSalida);
                Comando.ExecuteNonQuery();
            }
            return "todo bien !!!";
        }

        public List<Parqueadero> Consultar()
        {
            List<Parqueadero> Parqueaderos = new List<Parqueadero>();
            using (var command = new SqlCommand())
            {
                var comando = _connection.CreateCommand();
                comando.CommandText = "SELECT p.Placa, p.Lugar, v.HoraLlegada, v.TipoVehiculo, pe.Nombre, pe.Apellido, " +
                    "p.HorasTotalesParqueo, p.TotalPagar, p.HoraSalida FROM Parqueaderos p " +
                    "JOIN VehiculoHistorial v ON p.Placa = v.Placa " +
                    "JOIN PersonaHistorial pe ON v.Placa = pe.Placa";
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Parqueadero parqueadero = new Parqueadero();
                    parqueadero.Lugar = (string)lector["Lugar"];
                    parqueadero.HorasTotalesParqueo = (double)lector["HorasTotalesParqueo"];
                    parqueadero.TotalPagar = (double)lector["TotalPagar"];
                    parqueadero.Placa = (string)lector["Placa"];
                    parqueadero.HoraSalida = (DateTime)lector["HoraSalida"];

                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Placa = (string)lector["Placa"];
                    vehiculo.TipoVehiculo = (string)lector["TipoVehiculo"];
                    //vehiculo.Modelo = (string)lector["Modelo"];
                    vehiculo.Lugar = (string)lector["Lugar"];
                    vehiculo.HoraLlegada = (DateTime)lector["HoraLlegada"];

                    Persona persona = new Persona();
                    persona.Nombre = (string)lector["Nombre"];
                    persona.Apellido = (string)lector["Apellido"];
                    persona.Placa = (string)lector["Placa"];

                    parqueadero.Vehiculos.Add(vehiculo);
                    parqueadero.Personas.Add(persona);
                    Parqueaderos.Add(parqueadero);
                }
            }
            
            return Parqueaderos;
        }

        public List<Parqueadero> FiltrarPorPlaca(string placa)
        {
            List<Parqueadero> Parqueaderos = new List<Parqueadero>();
            using (var command = new SqlCommand())
            {
                var comando = _connection.CreateCommand();
                comando.CommandText = "SELECT p.Placa, p.Lugar, v.HoraLlegada, v.TipoVehiculo, pe.Nombre, pe.Apellido, " +
                    "p.HorasTotalesParqueo, p.TotalPagar, p.HoraSalida FROM Parqueaderos p " +
                    "JOIN VehiculoHistorial v ON p.Placa = v.Placa " +
                    "JOIN PersonaHistorial pe ON v.Placa = pe.Placa " +
                    "Where p.Placa LIKE '%' + @Placa + '%'";
                comando.Parameters.AddWithValue("@Placa", placa);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Parqueadero parqueadero = RepositorioParqueadero.MapperToParqueadero(lector);

                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Placa = (string)lector["Placa"];
                    vehiculo.TipoVehiculo = (string)lector["TipoVehiculo"];
                    //vehiculo.Modelo = (string)lector["Modelo"];
                    vehiculo.Lugar = (string)lector["Lugar"];
                    vehiculo.HoraLlegada = (DateTime)lector["HoraLlegada"];

                    Persona persona = new Persona();
                    persona.Nombre = (string)lector["Nombre"];
                    persona.Apellido = (string)lector["Apellido"];
                    persona.Placa = (string)lector["Placa"];

                    parqueadero.Vehiculos.Add(vehiculo);
                    parqueadero.Personas.Add(persona);
                    Parqueaderos.Add(parqueadero);
                }
            }

            return Parqueaderos;
        }

        private static Parqueadero MapperToParqueadero(SqlDataReader lector)
        {
            Parqueadero parqueadero = new Parqueadero();
            parqueadero.Lugar = (string)lector["Lugar"];
            parqueadero.HorasTotalesParqueo = (double)lector["HorasTotalesParqueo"];
            parqueadero.TotalPagar = (double)lector["TotalPagar"];
            parqueadero.Placa = (string)lector["Placa"];
            parqueadero.HoraSalida = (DateTime)lector["HoraSalida"];
            return parqueadero;
        }

        

        public string Update(Parqueadero parqueadero)
        {
            throw new NotImplementedException();
        }
    }
}
