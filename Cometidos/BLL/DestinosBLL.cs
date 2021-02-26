using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cometidos.BLL {
    class DestinosBLL {
        DBCometidosEntities context;

        public List<Destino> GetDestinos() {
            context = new DBCometidosEntities();
            return (from l in context.Destino orderby l.NombreDestino ascending select l).ToList();
        }

        public Destino GetDestino(int id) {
            context = new DBCometidosEntities();
            return (from l in context.Destino where l.IdDestino == id select l).FirstOrDefault();
        }
    }
}
