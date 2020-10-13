using Execute_2.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execute_2.DAL
{
    public interface IDAO
    {
        void Alta(Genero entidad);
        void Baja(Genero entidad);
        void Modificacion(Genero entidad);
        IEnumerable<Genero> Listar();
    }
}
