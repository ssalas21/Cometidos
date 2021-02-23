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

namespace Cometidos {
    /// <summary>
    /// Lógica de interacción para Funcionario.xaml
    /// </summary>
    
    public partial class Funcionario : Window {
        Index index;
        public Funcionario(Index aux) {
            InitializeComponent();
            index = aux;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            index.TxtApellidos.Text = "1";
            this.Close();
            index.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            index.TxtApellidos.Text = "2";
            this.Close();
            index.IsEnabled = true;
        }
    }
}
