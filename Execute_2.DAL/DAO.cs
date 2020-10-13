using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Execute_2.EE;
using Execute_2.Utilities;

namespace Execute_2.DAL
{
    public class DAO : IDAO
    {
        

        public void Alta(Genero entidad)
        {
            string query = $"Insert into {CrearTabla<Genero>()} (nombre,fecha_reg) values (@nombre,@fecha_reg)";
            EjecutarQuery.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {
                    "nombre",entidad.Nombre
                },
                {
                    "fecha_reg",entidad.Fecha_reg
                }
            });
        }

        public void Baja(Genero entidad)
        {
            string query = $"delete from {CrearTabla<Genero>()} where id = @id";
            EjecutarQuery.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {
                    "id",entidad.Id
                }
            });
        }

        public IEnumerable<Genero> Listar()
        {
            string query = "Select * from " + CrearTabla<Genero>();
            var devolver = EjecutarQuery.ExecuteSelectStatement<Genero>(query);
            return devolver;         
        }

        private string CrearTabla<T>()
        {
            return typeof(T).Name;
        }

        public void Modificacion(Genero entidad)
        {
            throw new NotImplementedException();
        }
    }
}
