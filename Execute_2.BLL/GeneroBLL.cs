using Execute_2.DAL;
using Execute_2.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execute_2.BLL
{
    public class GeneroBLL
    {
        private readonly IDAO dAO = new DAO();

        public IEnumerable<Genero> Listar()
        {
            return dAO.Listar();
        }

    }
}
