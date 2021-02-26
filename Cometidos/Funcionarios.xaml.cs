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
            DgEmpleados.SelectedItem = 0;
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e) {
            DgEmpleados.ItemsSource = (new EmpleadosBLL().GetEmpleados(TxtBuscar.Text));
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e) {
            this.Close();
            index.IsEnabled = true;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e) {
            Empleados empleado = DgEmpleados.SelectedValue as Empleados;
            index.TxtApellidos.Text = empleado.Apellidos;
            index.TxtCargo.Text = empleado.Cargo;
            index.TxtDepartamento.Text = empleado.Departamento.NombreDepartamento;
            index.TxtGrado.Text = empleado.Grado.ToString();
            index.TxtNombres.Text = empleado.Nombres;
            index.TxtRut.Text = empleado.Rut;
            this.Close();
            index.IsEnabled = true;
        }
    }
}
