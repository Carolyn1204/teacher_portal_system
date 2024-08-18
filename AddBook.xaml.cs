using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private DateTime selectedDate = DateTime.Now;
        public AddBook()
        {
            InitializeComponent();

            
        }

        private void addBookDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (addBookCalendar.SelectedDate.HasValue)
            {
                selectedDate = addBookCalendar.SelectedDate.Value;

            }
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bookISBN.Text.Length != 13 || !long.TryParse(bookISBN.Text, out _))
            {
                MessageBox.Show("ISBN must be 13 digits.");
                return;
            }

            if (!decimal.TryParse(bookPrice.Text, out decimal price) || price > 300)
            {
                MessageBox.Show("Price must be a number and cannot exceed 300 CAD.");
                return;
            }


            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string add_data = "insert into [dbo].[Books] (ISBN, Title, Price, Author, Publish_date) values (@ISBN, @Title, @Price, @Author, @Publish_date)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@ISBN", bookISBN.Text);
                cmd.Parameters.AddWithValue("@Title", bookTitle.Text);
                cmd.Parameters.AddWithValue("@Price", bookPrice.Text);
                cmd.Parameters.AddWithValue("@Author", bookAuthor.Text);
                cmd.Parameters.AddWithValue("@Publish_date", selectedDate);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfuly added element", "Add Book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var windowOpen = typeof(TeacherPortal.MainWindow);

            foreach (Window window in Application.Current.Windows)
            {
                
                if (window.GetType() != windowOpen)
                {
                    window.Close();
                }
            }

        }
    }
}
