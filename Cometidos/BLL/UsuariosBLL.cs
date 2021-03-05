using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cometidos.BLL {
    class UsuariosBLL {
        DBCometidosEntities context;

        public bool Login(string user, string pass) {
            context = new DBCometidosEntities();
            return (from l in context.Usuarios where l.NombreUsuario == user && l.Password == pass select l).Any();            
        }

        public int GetAdmin(string user) {
            context = new DBCometidosEntities();
            return Convert.ToInt32((from l in context.Usuarios where l.NombreUsuario == user select l.Admin).FirstOrDefault());
        }

    }
}
