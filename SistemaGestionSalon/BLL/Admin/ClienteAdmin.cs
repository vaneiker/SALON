using DAL.Repository;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class ClienteAdmin
    {
        private ClienteRepository db = new ClienteRepository();

        public IEnumerable<Clientes> GetClientes()
        {
            return db.ObtenerClientes();
        }

        public void SetClienteCrearActualizar(Clientes C)
        {
             db.CrearActualizarCliente(C);
        }
        public void SetInactivarClientes(int? C)
        {
             db.InactivarClientes(C);
        }
    }
}
