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
    /// Lógica de interacción para Solicitud.xaml
    /// </summary>
    public partial class Solicitud : Window {
        string usuario;
        Index index;
        public Solicitud(string user, Index aux) {
            InitializeComponent();
            index = aux;
            usuario = user;
        }

        private void Window_Closed(object sender, EventArgs e) {
            index.IsEnabled = true;
        }
    }
}
