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
using System.Xml.Linq;

namespace TeacherPortal
{
    /// <summary>
    /// Interaction logic for UpdateSubject.xaml
    /// </summary>
    public partial class UpdateSubject : Window
    {
        private DateTime selectedDate = DateTime.Now;
        public UpdateSubject()
        {
            InitializeComponent();
        }

        private void updateSubjectDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startDate.SelectedDate.HasValue)
            {
                selectedDate = startDate.SelectedDate.Value;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string update_data = "UPDATE [dbo].[Subjects] set Code=@code, Sname=@sname, StartDate=@startdate, NumOfCredits=@credits where Code=@code";
                SqlCommand cmd = new SqlCommand(update_data, con);

                // cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@code", code.Text);
                cmd.Parameters.AddWithValue("@sname", name.Text);
                cmd.Parameters.AddWithValue("@startdate", selectedDate);
                cmd.Parameters.AddWithValue("@credits", credit.Text);
                
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("code does not exist, nothing was updated");
                }
                else
                {
                    MessageBox.Show("code " + code.Text + "was successfully updated", "Update check");

                }
                con.Close();

                code.Text = "";
                name.Text = "";
                credit.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
