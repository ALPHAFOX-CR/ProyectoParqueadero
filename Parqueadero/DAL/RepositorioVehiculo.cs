using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DAL
{
    public class RepositorioVehiculo
    {
        SqlConnection _connection;
        public RepositorioVehiculo(ConnectionManager connection)
        {
            _connection = connection.connection;
        }
        public string Insert(Vehiculo vehiculo)
        {
            using (var Comando = _connection.CreateCommand())
            {
                Comando.CommandText = "Insert Into Vehiculo (Placa,Modelo,TipoVehiculo,Lugar,HoraLlegada)" +
                " values (@Placa,@Modelo,@TipoVehiculo,@Lugar,@HoraLlegada)";
                Comando.Parameters.Add("Placa", SqlDbType.VarChar).Value = vehiculo.Placa;
                Comando.Parameters.Add("Modelo", SqlDbType.VarChar).Value = vehiculo.Modelo;
                Comando.Parameters.Add("TipoVehiculo", SqlDbType.VarChar).Value = vehiculo.TipoVehiculo;
                Comando.Parameters.Add("Lugar", SqlDbType.VarChar).Value = vehiculo.Lugar;
                Comando.Parameters.AddWithValue("@HoraLlegada", vehiculo.HoraLlegada);
                Comando.ExecuteNonQuery();
            }
            return "Guardado";
        }

        public string InsertHistorial(Vehiculo vehiculo)
        {
            using (var Comando = _connection.CreateCommand())
            {
                Comando.CommandText = "Insert Into VehiculoHistorial (Placa,Modelo,TipoVehiculo,Lugar,HoraLlegada)" +
                " values (@Placa,@Modelo,@TipoVehiculo,@Lugar,@HoraLlegada)";
                Comando.Parameters.Add("Placa", SqlDbType.VarChar).Value = vehiculo.Placa;
                Comando.Parameters.Add("Modelo", SqlDbType.VarChar).Value = vehiculo.Modelo;
                Comando.Parameters.Add("TipoVehiculo", SqlDbType.VarChar).Value = vehiculo.TipoVehiculo;
                Comando.Parameters.Add("Lugar", SqlDbType.VarChar).Value = vehiculo.Lugar;
                Comando.Parameters.AddWithValue("@HoraLlegada", vehiculo.HoraLlegada);
                Comando.ExecuteNonQuery();
            }
            return "Guardado";
        }


        public List<Vehiculo> Consultar()
        {
            List<Vehiculo> Vehiculos = new List<Vehiculo>();
            using (var command = new SqlCommand())
            {
                var comando = _connection.CreateCommand();
                comando.CommandText = "SELECT v.Placa, v.Modelo, v.TipoVehiculo, v.Lugar, v.HoraLlegada, " +
                    "p.Nombre, p.Apellido, p.Cargo, p.Placa " +
                    "FROM Vehiculo v INNER JOIN Persona p " +
                    "ON v.Placa = p.Placa";
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Placa = (string)lector["Placa"];
                    vehiculo.Modelo = (string)lector["Modelo"];
                    vehiculo.TipoVehiculo = (string)lector["TipoVehiculo"];
                    vehiculo.Lugar = (string)lector["Lugar"];
                    vehiculo.HoraLlegada = (DateTime)lector["HoraLlegada"];

                    Persona persona = new Persona();
                    persona.Nombre = (string)lector["Nombre"];
                    persona.Apellido = (string)lector["Apellido"];
                    persona.Cargo = (string)lector["Cargo"];
                    persona.Placa = (string)lector["Placa"];

                    vehiculo.Personas.Add(persona);

                    Vehiculos.Add(vehiculo);
                }
                return Vehiculos;
            }
        }

        private Vehiculo MapperToVehiculo(SqlDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Placa = dataReader.GetString(0);
            vehiculo.Modelo = dataReader.GetString(1);
            vehiculo.TipoVehiculo = dataReader.GetString(2);
            vehiculo.Lugar = dataReader.GetString(3);

            return vehiculo;
        }

        public Vehiculo BuscarVehiculo(string placa)
        {
            using(var comando = new SqlCommand())
            {
                var command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Vehiculo WHERE Placa =@Placa";
                command.Parameters.AddWithValue("@Placa", placa);
                SqlDataReader lector = command.ExecuteReader();
                lector.Read();
                Vehiculo vehiculo = MapperToVehiculo(lector);
                return vehiculo;
            }

            return null;
        }
        

        public void Delete(Vehiculo vehiculo)
        {
            using (var comando = new SqlCommand())
            {
                var command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM Vehiculo WHERE Placa =@Placa";
                command.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                command.ExecuteNonQuery();
            }
        }

    }
}
