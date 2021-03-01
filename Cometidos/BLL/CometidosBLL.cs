using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cometidos.BLL {
    class CometidosBLL {
        DBCometidosEntities context;

        public List<Cometidos> GetCometidos() {
            context = new DBCometidosEntities();
            return (from l in context.Cometidos orderby l.IdCometidos descending select l).Take(10).ToList();
        }

        public Cometidos GetCometidos(int id) {
            context = new DBCometidosEntities();
            return (from l in context.Cometidos where l.IdCometidos == id select l).FirstOrDefault();
        }

        public Cometidos InsertCometidos(string rut, int idDestino, DateTime fecha, DateTime horaSalida, DateTime horaLlegada, string motivo, bool viatico, int grado, string movilizacion, string usuario) {
            try {
                context = new DBCometidosEntities();
                ValoresViaticos viaticos;
                Destino destino;
                int locomocion;
                if (movilizacion.Equals("MUNICIPAL")) {
                    destino = new Destino { IdDestino = 0, NombreDestino = "", Valor_destino = 0 };
                    locomocion = 0;
                } else {
                    destino = new DestinosBLL().GetDestino(idDestino);
                    locomocion = 1;
                }
                if (viatico == true) viaticos = new ValoresViaticosBLL().GetViaticos(grado);
                else viaticos = new ValoresViaticos { IdValores = 0, RanMax = 0, RanMin = 0, Valor = 0 };
                Cometidos cometidos = new Cometidos { Rut_fk = rut, IdDestino_FK = idDestino, Fecha_cometido = fecha, Hora_salida = horaSalida, Hora_llegada = horaLlegada, Motivo = motivo, Nulo = 1, Valor_destino_old = destino.Valor_destino, Viatico = viaticos.Valor, NombreUsuario_FK = usuario, Movilizacion = locomocion };
                context.Cometidos.Add(cometidos);
                context.SaveChanges();
                return cometidos;
            } catch (Exception ex) {
                throw ex;    
            }
            
        }
    }
}
