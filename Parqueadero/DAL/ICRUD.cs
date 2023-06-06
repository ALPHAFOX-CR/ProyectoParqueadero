using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICRUD
    {
        string Insert(Persona persona);
        string Insert(Parqueadero parqueadero);
        string Insert(Vehiculo vehiculo);
        string Update(Persona persona);
        string Update(Parqueadero parqueadero);
        string Update(Vehiculo vehiculo);
        string Delete(Persona persona);
        string Delete(Parqueadero parqueadero);
        string Delete(Vehiculo vehiculo);
        List<Persona> GetAll();
        List<Parqueadero> GetAll1();
        List<Vehiculo> GetAll2();
    }
}
