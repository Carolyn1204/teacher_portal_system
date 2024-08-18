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
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {

        private DateTime selectedDate = DateTime.Now;
        public RegisterPage()
        {
            InitializeComponent();
            
        }

        private void dobDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dobCalendar.SelectedDate.HasValue)
            {
                selectedDate = dobCalendar.SelectedDate.Value;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (idTbx.Text.Length != 4 || !int.TryParse(idTbx.Text, out _))
            {
                MessageBox.Show("Staff ID must be 4 digits.");
                return;
            }

            if (phoneTbx.Text.Length != 10 || !long.TryParse(phoneTbx.Text, out _))
            {
                MessageBox.Show("Cellphone must be 10 digits.");
                return;
            }

            if (passwordTbx.Password.Length < 7)
            {
                MessageBox.Show("Password must be at least 7 characters .");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string add_data = "insert into [dbo].[Teacher] (Id, Name, Email, Dob, Cellphone, Password) values (@Id, @Name, @Email, @Dob, @Cellphone, @Password)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Id", idTbx.Text);
                cmd.Parameters.AddWithValue("@Name", nameTbx.Text);
                cmd.Parameters.AddWithValue("@Email", emailTbx.Text);
                cmd.Parameters.AddWithValue("@Dob", selectedDate);
                cmd.Parameters.AddWithValue("@Cellphone", phoneTbx.Text);
                cmd.Parameters.AddWithValue("@Password", passwordTbx.Password);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfuly added element", "Register Check");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
