using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cometidos.BLL;
using Spire.Doc;

namespace Cometidos {
    /// <summary>
    /// Lógica de interacción para Index.xaml
    /// </summary>
    public partial class Index : Window {
        string usuario;
        public Index(string user) {
            InitializeComponent();
            usuario = user;
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            TpHoraInicio.Value = start;
            TpHoraFin.Value = end;
            CalFecha.SelectedDate = DateTime.Now;
            CmbMovilizacion.SelectedIndex = 0;
            CmbDestino.ItemsSource = (new DestinosBLL().GetDestinos());
            CmbDestino.DisplayMemberPath = "NombreDestino";
            CmbDestino.SelectedValuePath = "IdDestino";
            CmbDestino.SelectedIndex = 37;
            DgReimprimir.ItemsSource = new CometidosBLL().GetCometidos();
        }

        private void BtnCometido_Click(object sender, RoutedEventArgs e) {
            if (TxtRut.Text == "" || TxtMotivo.Text == "") {
                MessageBox.Show("Por favor complete todos los datos necesarios");
            } else {
                TxtMotivo.Text = TxtMotivo.Text.ToUpper();
                Empleados empleado = new EmpleadosBLL().GetEmpleado(TxtRut.Text);
                Destino destino = new DestinosBLL().GetDestino(Convert.ToInt32(CmbDestino.SelectedValue));
                string texto = "¿Esta seguro de generar el cometido para el funcionario " + empleado.Nombres + " " + empleado.Apellidos + ", con destino a " + destino.NombreDestino + " en transporte " + CmbMovilizacion.SelectionBoxItem + " el día " + CalFecha.SelectedDate.Value.Day + "/" + CalFecha.SelectedDate.Value.Month + "/" + CalFecha.SelectedDate.Value.Year + " desde las " + TpHoraInicio.Value.Value.ToString("h:mm tt") + " hasta las " + TpHoraFin.Value.Value.ToString("h:mm tt") + "?";
                MessageBoxResult result = MessageBox.Show(texto, "Creación de cometido funcionario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) {
                    Cometidos cometidos = new CometidosBLL().InsertCometidos(TxtRut.Text, destino.IdDestino, CalFecha.SelectedDate.Value, TpHoraInicio.Value.Value, TpHoraFin.Value.Value, TxtMotivo.Text, ChkViatico.IsChecked.Value, Convert.ToInt32(TxtGrado.Text), CmbMovilizacion.SelectionBoxItem.ToString(), usuario);
                    Document document = new Document();
                    string path = Environment.CurrentDirectory;
                    string path2 = path + "\\cometido2.docx";
                    path = path + "\\cometido.docx";
                    document.LoadFromFile(path);
                    document.Replace("[fechaActual]", DateTime.Now.ToString("dddd, dd MMMM yyyy"), false, true);
                    document.Replace("[nroCorrelativo]", cometidos.IdCometidos.ToString(), false, true);
                    document.Replace("[fechaCometido]", CalFecha.SelectedDate.Value.ToString("dd MMMM yyyy"), false, true);
                    document.Replace("[nombres]", TxtNombres.Text, false, true);
                    document.Replace("[apellidos]", TxtApellidos.Text, false, true);
                    document.Replace("[grado]", TxtGrado.Text, false, true);
                    document.Replace("[cargo]", TxtCargo.Text, false, true);
                    document.Replace("[departamento]", TxtDepartamento.Text, false, true);
                    document.Replace("[movilizacion]", CmbMovilizacion.SelectionBoxItem.ToString(), false, true);
                    document.Replace("[destino]", destino.NombreDestino, false, true);
                    document.Replace("[motivo]", cometidos.Motivo, false, true);
                    document.Replace("[viatico]", cometidos.Viatico.ToString("C0"), false, true);
                    document.Replace("[horaSalida]", cometidos.Hora_salida.Value.ToString("h:mm tt"), false, true);
                    document.Replace("[horaLlegada]", cometidos.Hora_llegada.Value.ToString("h:mm tt"), false, true);
                    document.Replace("[montoPasaje]", cometidos.Valor_destino_old.ToString("C0"), false, true);
                    document.Replace("[usuario]", usuario, false, true);
                    document.SaveToFile("cometido2.docx", FileFormat.Docx);
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.Documents.Open(path2);
                    wordApp.ActiveDocument.PrintOut();
                    wordApp.ActiveDocument.PrintOut();
                    wordApp.ActiveDocument.Close();                    
                    File.Delete(path2);
                    MessageBox.Show("Cometido ingresado correctamente");
                    BtnLimpiar_Click(sender, e);
                    ReloadCometidos();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Funcionarios funcionario = new Funcionarios(this);
            funcionario.Show();
            this.IsEnabled = false;
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e) {
            CmbDestino.SelectedIndex = 37;
            CmbMovilizacion.SelectedIndex = 0;
            CalFecha.SelectedDate = DateTime.Now;
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            TpHoraInicio.Value = start;
            TpHoraFin.Value = end;
            TxtApellidos.Text = "";
            TxtCargo.Text = "";
            TxtDepartamento.Text = "";
            TxtGrado.Text = "";
            TxtMotivo.Text = "";
            TxtNombres.Text = "";
            TxtRut.Text = "";
        }

        private void ReloadCometidos() {
            DgReimprimir.ItemsSource = new CometidosBLL().GetCometidos();
            DgReimprimir.SelectedIndex = 0;
        }

        private void BtnReimprimir_Click(object sender, RoutedEventArgs e) {
            Cometidos cometido = DgReimprimir.SelectedItem as Cometidos;
            if (MessageBoxResult.Yes == MessageBox.Show("¿Realmente desea reimprimir el cometido seleccionado?", "Reimpresión", MessageBoxButton.YesNo, MessageBoxImage.Question)) {
                Document document = new Document();
                string movilizacion;
                if (cometido.Movilizacion == 0) movilizacion = "MUNICIPAL";
                else movilizacion = "COLECTIVA";
                string path = Environment.CurrentDirectory;
                string path2 = path + "\\cometido2.docx";
                path = path + "\\cometido.docx";
                document.LoadFromFile(path);
                document.Replace("[fechaActual]", DateTime.Now.ToString("dddd, dd MMMM yyyy"), false, true);
                document.Replace("[nroCorrelativo]", cometido.IdCometidos.ToString(), false, true);
                document.Replace("[fechaCometido]", cometido.Fecha_cometido.ToString("dd MMMM yyyy"), false, true);
                document.Replace("[nombres]", cometido.Empleados.Nombres, false, true);
                document.Replace("[apellidos]", cometido.Empleados.Apellidos, false, true);
                document.Replace("[grado]", cometido.Empleados.Grado.ToString(), false, true);
                document.Replace("[cargo]", cometido.Empleados.Cargo, false, true);
                document.Replace("[departamento]", cometido.Empleados.Departamento.NombreDepartamento, false, true);
                document.Replace("[movilizacion]", movilizacion, false, true);
                document.Replace("[destino]", cometido.Destino.NombreDestino, false, true);
                document.Replace("[motivo]", cometido.Motivo, false, true);
                document.Replace("[viatico]", cometido.Viatico.ToString("C0"), false, true);
                document.Replace("[horaSalida]", cometido.Hora_salida.Value.ToString("h:mm tt"), false, true);
                document.Replace("[horaLlegada]", cometido.Hora_llegada.Value.ToString("h:mm tt"), false, true);
                document.Replace("[montoPasaje]", cometido.Valor_destino_old.ToString("C0"), false, true);
                document.Replace("[usuario]", cometido.Usuarios.NombreUsuario, false, true);
                document.SaveToFile("cometido2.docx", FileFormat.Docx);
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Documents.Open(path2);
                wordApp.ActiveDocument.PrintOut();
                wordApp.ActiveDocument.PrintOut();
                wordApp.ActiveDocument.Close();
                File.Delete(path2);
                MessageBox.Show("Cometido ingresado correctamente");
                BtnLimpiar_Click(sender, e);
                ReloadCometidos();
            } else {
                ReloadCometidos();
            }
        }
    }
}
