using Ejercicio01.mibd;
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
using System.Text.RegularExpressions;

namespace Ejercicio01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //instanciar "Base de datos"
            if (Regex.IsMatch(Idtext.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Sueldo1.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                Empleado emp = new Empleado();
                emp.Nombre = Nombre.Text;
                emp.Sueldo = int.Parse(Sueldo1.Text);

                emp.Departamentoid= (int)CbDepartamentos.SelectedValue;
                db.Empleados.Add(emp);
                db.SaveChanges();
            }
             else { MessageBox.Show("Verifique ingresar los campos correctos"); }
           

          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Idtext.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Sueldo1.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                int id = int.Parse(Idtext.Text);
                var emp = db.Empleados
                          .SingleOrDefault(x => x.id == id);
                // where x.id == id
                //select x;

                if (emp != null)
                {
                    emp.Nombre = Nombre.Text;
                    emp.Sueldo = int.Parse(Sueldo1.Text);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Idtext.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                int id = int.Parse(Idtext.Text);
                var emp = db.Empleados
                          .SingleOrDefault(x => x.id == id);
                // where x.id == id
                //select x;

                if (emp != null)
                {
                    db.Empleados.Remove(emp);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }

        }

        private void ConsultarId_Click(object sender, RoutedEventArgs e)
        {
            demoEF db = new demoEF();
            int id = int.Parse(Idtext.Text);
            var registros = from s in db.Empleados
                            where s.id == id
                            select new
                            {
                                s.Nombre,
                                s.Sueldo
                            };
            Dbgrid.ItemsSource = registros.ToList();
        }

        private void ConsultarTodo_Click(object sender, RoutedEventArgs e)
        {
            demoEF db = new demoEF();

            var registros = from s in db.Empleados
                            select s;
                            
            Dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Idtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtDeps.Text, @"^[a-zA-Z]+$"))
            {
                demoEF db = new demoEF();
                Departamento dep = new Departamento();
                dep.Nombre = txtDeps.Text;
                

                db.Departamentos.Add(dep);
                db.SaveChanges();
            }
            else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Sueldo_Loaded(object sender, RoutedEventArgs e)
        {
            demoEF db = new demoEF();
            CbDepartamentos.ItemsSource = db.Departamentos.ToList();
            CbDepartamentos.DisplayMemberPath = "Nombre";
            CbDepartamentos.SelectedValuePath = "id";

        }

        private void txtDeps_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
