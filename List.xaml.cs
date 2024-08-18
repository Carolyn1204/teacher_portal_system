using System;
using System.Collections.Generic;
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

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
           AddBook addb = new AddBook();
           addb.ShowDialog();
        }

        private void addBook1_Click(object sender, RoutedEventArgs e)
        {
            addSubject adds = new addSubject();
            adds.ShowDialog();
        }

        

        private void showBookList_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISBN, Title, Price, Author, Publish_date FROM Books";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();

                        while (reader.Read())
                        {
                            string? isbn = reader["ISBN"].ToString();
                            string? title = reader["Title"].ToString();
                            decimal? price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            string? authorName = reader["Author"].ToString();
                            DateTime dateOfPublication = reader.GetDateTime(reader.GetOrdinal("Publish_date"));

                            sb.AppendLine($"ISBN: {isbn}");
                            sb.AppendLine($"Title: {title}");
                            sb.AppendLine($"Price: {price:C}");
                            sb.AppendLine($"Author: {authorName}");
                            sb.AppendLine($"Publication Date: {dateOfPublication.ToShortDateString()}");
                            sb.AppendLine();
                        }

                        bookList.Text = sb.ToString();
                    }
                }
            }

        }

        private void showSubjectList_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Code, Sname, StartDate, NumOfCredits FROM Subjects";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();

                        while (reader.Read())
                        {
                            string? code = reader["Code"].ToString();
                            string? sname = reader["Sname"].ToString();
                   
                            DateTime startdate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                            string? credit = reader["NumOfCredits"].ToString();


                            sb.AppendLine($"Code: {code}");
                            sb.AppendLine($"Name: {sname}");
                            sb.AppendLine($"Start Date: {startdate.ToShortDateString()}");
                            sb.AppendLine($"Credit: {credit}");
                            sb.AppendLine();
                        }

                        subjectList.Text = sb.ToString();
                    }
                }
            }

        }

        private void deleteBook_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook deleteBook = new DeleteBook();   
            deleteBook.ShowDialog();
        }

        private void deleteSubject_Click(object sender, RoutedEventArgs e)
        {
            DeleteSubject deleteSubject = new DeleteSubject();
            deleteSubject.ShowDialog();
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            UpdateBook updateBook = new UpdateBook();
            updateBook.ShowDialog();
        }

        private void updateSubject_Click(object sender, RoutedEventArgs e)
        {
            UpdateSubject updateSubject = new UpdateSubject();
            updateSubject.ShowDialog();
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
