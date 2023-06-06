using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VehiculoServicio
    {
        ConnectionManager connection;
        RepositorioVehiculo repositorio;
        RepositorioPersona RepositorioPersona;
        public VehiculoServicio(string conexion)
        {
            connection = new ConnectionManager(conexion);
            repositorio = new RepositorioVehiculo(connection);
            RepositorioPersona = new RepositorioPersona(connection);
        }

        public string Guardar(Vehiculo vehiculo)
        {
            try
            {
                connection.Open();
                repositorio.Insert(vehiculo);
                repositorio.InsertHistorial(vehiculo);
                return "Guardado";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
                throw;
            }
            finally { connection.Close(); }
        }

        public List<Vehiculo> Vehiculos { get; set; }
        public List<Vehiculo> Consultar()
        {
            try
            {
                connection.Open();
                Vehiculos = repositorio.Consultar();
                connection.Close();
                return Vehiculos;
            }
            catch (Exception e)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        public Vehiculo BuscarVehiculo(string placa)
        {
            try
            {
                connection.Open();
                return repositorio.BuscarVehiculo(placa);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { connection.Close(); }
        }

        public Persona BuscarPersona(string placa)
        {
            try
            {
                connection.Open();
                return RepositorioPersona.BuscarPersona(placa);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { connection.Close(); }
        }

        public void DeleteVehiculo(Vehiculo vehiculo)
        {
            try
            {
                connection.Open();
                repositorio.Delete(vehiculo);
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
