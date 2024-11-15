using DAL.Repository;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class DropDownListAdmin
    {
        private DropDownListRepository db= new DropDownListRepository();

        public List<Base> DropDownList(string filter="", string filter2 = "")
        {
            return db.DropDownList(filter, filter2);
        }
    }
}
