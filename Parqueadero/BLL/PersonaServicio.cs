using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaServicio
    {
        ConnectionManager connection;
        RepositorioPersona repositorio;
        public PersonaServicio(string conexion)
        {
            connection = new ConnectionManager(conexion);
            repositorio = new RepositorioPersona(connection);
        }
        public string Guardar(Persona persona)
        {
            try
            {
                connection.Open();
                repositorio.Insert(persona);
                repositorio.InsertHistorial(persona);
                return "Guardado";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
                throw;
            }
            finally { connection.Close(); }
        }

        public List<Persona> Personas { get; set; }
        public List<Persona> Consultar()
        {
            try
            {
                connection.Open();
                Personas = repositorio.GetAll();
                connection.Close();
                return Personas;
            }
            catch (Exception e)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        public void DeletePersona(Persona persona)
        {
            try
            {
                connection.Open();
                repositorio.DeleteP(persona);
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
