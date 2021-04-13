using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cometidos.BLL {
    class EmpleadosBLL {
        DBCometidosEntities context;

        public List<Empleados> GetEmpleados() {
            context = new DBCometidosEntities();
            return (from l in context.Empleados where l.Fecha_fin_contrato >= DateTime.Now select l).ToList();
        }

        public List<Empleados> GetEmpleados(string aux) {
            context = new DBCometidosEntities();
            return (from l in context.Empleados where l.Fecha_fin_contrato >= DateTime.Now && (l.Afp.NombreAfp.Contains(aux) || l.Apellidos.Contains(aux) || l.Nombres.Contains(aux) || l.Rut.Contains(aux)) select l).ToList();
        }

        public Empleados GetEmpleado(string rut) {
            context = new DBCometidosEntities();
            return (from l in context.Empleados where l.Rut == rut select l).FirstOrDefault();
        }

    }
}
