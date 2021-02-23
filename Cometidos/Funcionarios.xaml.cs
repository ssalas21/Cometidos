using System;
using System.Collections.Generic;
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

namespace Cometidos {
    /// <summary>
    /// Lógica de interacción para Funcionarios.xaml
    /// </summary>
    public partial class Funcionarios : Window {
        Index index;
        public Funcionarios(Index aux) {
            InitializeComponent();
            index = aux;
            DgEmpleados.ItemsSource = (new EmpleadosBLL().GetEmpleados());
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e) {
            DgEmpleados.ItemsSource = (new EmpleadosBLL().GetEmpleados(TxtBuscar.Text));
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e) {
            this.Close();
            index.IsEnabled = true;
        }
                
    }
}
