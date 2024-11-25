using DAL.Repository;
using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class MediosPagosAdmin
    {
        private MedioPagoRepository db = new MedioPagoRepository(); 
        public Base GuardarTarjetaClientes(ClienteTarjeta t)
        {
            return db.GuardarDatosTarjetaClientes(t);
        }
    }
}
