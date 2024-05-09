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
using System.Windows.Shapes;

namespace testwpf
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private SqlConnection conn;
        public Window1()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testwpf.Properties.Settings.usersConnectionString"].ConnectionString);
            conn.Open();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();
            reg.Show();
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.ToString();
            string pswd = PasswBox.Password.ToString();



            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //adapter = Auth;
            //adapter.Fill(dt);
            //цикл if (dt.Rows.Count > 0)


            SqlCommand Auth = new SqlCommand($"select login, password from users where (login = N'{login}') and (password = N'{pswd}')",conn);
            SqlDataReader adapter = Auth.ExecuteReader();
            if (adapter != null)
            {
                MessageBox.Show("Авторизация прошла успешно!");
                Window2 newf = new Window2();
                newf.Show();
                Close();
            }
            else { MessageBox.Show("Неверный логин или пароль"); }
        }
    }
}
