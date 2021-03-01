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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cometidos.BLL;

namespace Cometidos {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e) {
            if (new UsuariosBLL().Login(TxtUser.Text.Trim().ToUpper(), TxtPassword.Password.Trim().ToUpper())) {
                Index index = new Index(TxtUser.Text);
                index.Show();
                this.Close();
            } else {
                MessageBox.Show("Credenciales incorrectas, vuelva a intentar", "Error de acceso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
