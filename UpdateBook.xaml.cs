using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for UpdateBook.xaml
    /// </summary>
    public partial class UpdateBook : Window
    {
        private DateTime selectedDate = DateTime.Now;
        public UpdateBook()
        {
            InitializeComponent();
        }

        private void updateBookDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pubishDate.SelectedDate.HasValue)
            {
                selectedDate = pubishDate.SelectedDate.Value;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string update_data = "UPDATE [dbo].[Books] set ISBN=@ISBN, Title=@Title, Price=@Price, Author=@Author, Publish_date=@Publish_date where ISBN=@ISBN";
                SqlCommand cmd = new SqlCommand(update_data, con);

                // cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ISBN", isbn.Text);
                cmd.Parameters.AddWithValue("@Title", title.Text);
                cmd.Parameters.AddWithValue("@Price", price.Text);
                cmd.Parameters.AddWithValue("@Author", author.Text);
                cmd.Parameters.AddWithValue("@Publish_date", selectedDate);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("isbn does not exist, nothing was updated");
                }
                else
                {
                    MessageBox.Show("ISBN " + isbn.Text + "was successfully updated", "Update check");

                }
                con.Close();

                isbn.Text = "";
                title.Text = "";
                price.Text = "";
                price.Text = "";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
