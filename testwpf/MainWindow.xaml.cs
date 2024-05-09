using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace testwpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn = null;
        

        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testwpf.Properties.Settings.usersConnectionString"].ConnectionString);
            conn.Open();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 acc = new Window1();
            acc.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
            {
                string login = loginBox.Text;
                string pswd = pswdBox.Password.ToString();
                SqlCommand newuser = new SqlCommand($"insert into users(login,password) values (N'{login}', N'{pswd}')", conn);
                newuser.ExecuteNonQuery();
            }
            else { MessageBox.Show("Поставьте галочку!"); }
        }
    }
}
