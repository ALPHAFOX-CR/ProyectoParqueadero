using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioPersona
    {
        SqlConnection _connection;
        public RepositorioPersona(ConnectionManager connection)
        {
            _connection = connection.connection;
        }
        public void DeleteP(Persona persona)
        {
            using (var comando = new SqlCommand())
            {
                var command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM Persona WHERE Placa =@Placa";
                command.Parameters.AddWithValue("@Placa", persona.Placa);
                command.ExecuteNonQuery();
            }
        }
        public List<Persona> GetAll()
        {
            List<Persona> Personas = new List<Persona>();
            var comando = _connection.CreateCommand();
            comando.CommandText = "select * from Persona";
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Personas.Add(MapperToPersona(lector));
            }
            return Personas;
        }

        private Persona MapperToPersona(SqlDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Nombre = dataReader.GetString(1);
            persona.Apellido = dataReader.GetString(2);
            persona.Cargo = dataReader.GetString(3);
            persona.Placa = dataReader.GetString(4);
            return persona;
        }

        public string Insert(Persona persona)
        {
            using (var Comando = _connection.CreateCommand())
            {
                Comando.CommandText = "Insert Into Persona (Nombre,Apellido,Cargo,Placa)" +
                "values (@Nombre,@Apellido,@Cargo,@Placa)";
                Comando.Parameters.Add("Nombre", SqlDbType.VarChar).Value = persona.Nombre;
                Comando.Parameters.Add("Apellido", SqlDbType.VarChar).Value = persona.Apellido;
                Comando.Parameters.Add("Cargo", SqlDbType.VarChar).Value = persona.Cargo;
                Comando.Parameters.Add("Placa", SqlDbType.VarChar).Value = persona.Placa;
                Comando.ExecuteNonQuery();
            }
            return "todo bien !!!";
        }

        public string InsertHistorial(Persona persona)
        {
            using (var Comando = _connection.CreateCommand())
            {
                Comando.CommandText = "Insert Into PersonaHistorial (Nombre,Apellido,Cargo,Placa)" +
                "values (@Nombre,@Apellido,@Cargo,@Placa)";
                Comando.Parameters.Add("Nombre", SqlDbType.VarChar).Value = persona.Nombre;
                Comando.Parameters.Add("Apellido", SqlDbType.VarChar).Value = persona.Apellido;
                Comando.Parameters.Add("Cargo", SqlDbType.VarChar).Value = persona.Cargo;
                Comando.Parameters.Add("Placa", SqlDbType.VarChar).Value = persona.Placa;
                Comando.ExecuteNonQuery();
            }
            return "todo bien !!!";
        }

        public Persona BuscarPersona(string placa)
        {
            using (var comando = new SqlCommand())
            {
                var command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Persona WHERE Placa =@Placa";
                command.Parameters.AddWithValue("@Placa", placa);
                SqlDataReader lector = command.ExecuteReader();
                lector.Read();
                Persona persona = MapperToPersona(lector);
                return persona;
            }

            return null;
        }
    }
}
