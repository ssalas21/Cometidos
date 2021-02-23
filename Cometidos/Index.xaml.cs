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
    /// Lógica de interacción para Index.xaml
    /// </summary>
    public partial class Index : Window {
        string usuario;
        public Index(string user) {
            InitializeComponent();
            usuario = user;
        }

        private void BtnCometido_Click(object sender, RoutedEventArgs e) {
                        
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Funcionario funcionario = new Funcionario(this);
            funcionario.Show();
            this.IsEnabled = false;
        }
    }
}
