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

    }
}
