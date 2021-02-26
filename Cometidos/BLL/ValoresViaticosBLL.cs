using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cometidos.BLL {
    class ValoresViaticosBLL {
        DBCometidosEntities context;

        public List<ValoresViaticos> GetValores() {
            context = new DBCometidosEntities();
            return (from l in context.ValoresViaticos select l).ToList();
        }

        public ValoresViaticos GetViaticos(int grado) {
            context = new DBCometidosEntities();
            return (from l in context.ValoresViaticos where l.RanMax >= grado && l.RanMin <= grado select l).FirstOrDefault();
        }
    }
}
