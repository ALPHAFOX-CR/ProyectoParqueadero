using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL
{
    public class ParqueaderoServicio
    {
        #region CodigoComentado
        //RepositorioParqueadero repositorio;
        //public ParqueaderoServicio()
        //{
        //    repositorio = new RepositorioParqueadero();
        //}

        //public string Guardar(Vehiculo vehiculo, Persona persona)
        //{
        //    try
        //    {
        //        if (vehiculo == null)
        //        {
        //            return "\nNo se pudo guardar vehiculo\n";
        //        }
        //        else
        //        {
        //            repositorio.AgregarPersona(persona);
        //            repositorio.AgregarVehiculo(vehiculo);
        //            return "\nEl vehiculo " + vehiculo.Placa + " fue guardado\n";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "\nError " + e + "\n";
        //    }
        //}

        //public List<Persona> ConsultarPersonasServicio()
        //{
        //    return repositorio.ConsultarPersonas();
        //}

        //public List<Vehiculo> ConsultarVehiculosServicio()
        //{
        //    return repositorio.ConsultarVehiculos();
        //}

        //public List<Parqueadero> ConsultarParqueaderoServicio()
        //{
        //    return repositorio.ConsultarParqueadero();
        //}

        //public List<Vehiculo> BuscarVehiculo(string placa)
        //{
        //    return repositorio.BuscarVehiculo(placa);
        //}

        //public string Retirar(string placa)
        //{
        //    try
        //    {
        //        repositorio.EliminarVehiculo(placa);
        //        repositorio.EliminarPersona(placa);
        //        return "Retirado";
        //    }
        //    catch (Exception e)
        //    {
        //        return "\nError " + e + "\n";
        //    }

        //}

        //public Persona BuscarPersona(string placa)
        //{
        //    return repositorio.Buscar(placa);
        //}

        #endregion

        RepositorioParqueadero repositorio;
        private readonly ConnectionManager connection;
        public ParqueaderoServicio(string conexion)
        {
            connection = new ConnectionManager(conexion);
            repositorio = new RepositorioParqueadero(connection);
        }

        public string Guardar(Parqueadero parqueadero)
        {
            try
            {
                connection.Open();
                repositorio.Insert(parqueadero);
                return "Guardado";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
                throw;
            }
            finally { connection.Close(); }
        }

        List<Parqueadero> Parqueaderos = new List<Parqueadero>();
        public List<Parqueadero> Consultar()
        {
            try
            {
                DataTable dataTable = new DataTable();
                connection.Open();
                Parqueaderos = repositorio.Consultar();
                connection.Close();
                return Parqueaderos;
            }
            catch (Exception e)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        public List<Parqueadero> FiltrarPorPlaca(string placa)
        {
            try
            {
                DataTable dataTable = new DataTable();
                connection.Open();
                Parqueaderos = repositorio.FiltrarPorPlaca(placa);
                connection.Close();
                return Parqueaderos;
            }
            catch (Exception e)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
