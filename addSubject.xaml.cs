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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for addSubject.xaml
    /// </summary>
    public partial class addSubject : Window
    {
        private DateTime selectedDate = DateTime.Now;
        public addSubject()
        {
            InitializeComponent();

        }

        private void addSubjectDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (subjectCalendar.SelectedDate.HasValue)
            {
                selectedDate = subjectCalendar.SelectedDate.Value;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (subjectCode.Text.Length != 6)
            {
                MessageBox.Show("Subject Code must be exactly 6 characters.");
                return;
            }

            if (!int.TryParse(subjectCredits.Text, out int credits) || credits < 1 || credits > 4)
            {
                MessageBox.Show("Number of Credits must be a positive integer between 1 and 4.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string add_data = "insert into [dbo].[Subjects] (Code, Sname, StartDate, NumOfCredits) values (@Code, @Sname, @StartDate, @NumOfCredits)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Code", subjectCode.Text);
                cmd.Parameters.AddWithValue("@Sname", subjectName.Text);
                cmd.Parameters.AddWithValue("@StartDate", selectedDate);
                cmd.Parameters.AddWithValue("@NumOfCredits", subjectCredits.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfuly added element", "Add Subject");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
