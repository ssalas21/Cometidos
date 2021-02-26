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
        }

        private void BtnCometido_Click(object sender, RoutedEventArgs e) {
            if (TxtRut.Text == "" || TxtMotivo.Text == "") {
                MessageBox.Show("Por favor complete todos los datos necesarios");
            } else {
                Empleados empleado = new EmpleadosBLL().GetEmpleado(TxtRut.Text);
                Destino destino = new DestinosBLL().GetDestino(Convert.ToInt32(CmbDestino.SelectedValue));
                string texto = "¿Esta seguro de generar el cometido para el funcionario " + empleado.Nombres + " " + empleado.Apellidos + ", con destino a " + destino.NombreDestino + " en transporte " + CmbMovilizacion.SelectionBoxItem + " el día " + CalFecha.SelectedDate.Value.Day + "/" + CalFecha.SelectedDate.Value.Month + "/" + CalFecha.SelectedDate.Value.Year + " desde las " + TpHoraInicio.Value.Value.ToString("h:mm tt") + " hasta las " + TpHoraFin.Value.Value.ToString("h:mm tt") + "?";
                MessageBoxResult result = MessageBox.Show(texto, "Creación de cometido funcionario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) {
                    Cometidos cometidos = new CometidosBLL().InsertCometidos(TxtRut.Text, destino.IdDestino, CalFecha.SelectedDate.Value, TpHoraInicio.Value.Value, TpHoraFin.Value.Value, TxtMotivo.Text, ChkViatico.IsChecked.Value, Convert.ToInt32(TxtGrado.Text), CmbMovilizacion.SelectionBoxItem.ToString());
                    Document document = new Document();
                    string path = Environment.CurrentDirectory;
                    string path2 = path + "\\cometido2.docx";
                    path = path + "\\cometido.docx";
                    document.LoadFromFile(path);
                    document.Replace("[fechaActual]", DateTime.Now.ToString("dddd, dd MMMM yyyy"), false, true);
                    document.SaveToFile("cometido2.docx", FileFormat.Docx);
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.Documents.Open(path2);
                    wordApp.ActiveDocument.PrintOut();
                    wordApp.ActiveDocument.PrintOut();
                    wordApp.ActiveDocument.Close();                    
                    File.Delete(path2);
                    MessageBox.Show("Cometido ingresado correctamente");
                    BtnLimpiar_Click(sender, e);
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
    }
}
