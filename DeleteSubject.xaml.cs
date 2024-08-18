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
    /// Interaction logic for DeleteSubject.xaml
    /// </summary>
    public partial class DeleteSubject : Window
    {
        public DeleteSubject()
        {
            InitializeComponent();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=TeacherPortal;Integrated Security=True;");
                con.Open();
                string delete_data = "DELETE FROM [dbo].[Subjects] where Code=@code";
                SqlCommand cmd = new SqlCommand(delete_data, con);


                cmd.Parameters.AddWithValue("@code", code.Text);
                int rowsAffected = cmd.ExecuteNonQuery();


                code.Text = "";

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Code does not exist");
                }
                else
                {
                    MessageBox.Show("Subject " + code.Text + "was successfully deleted");

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
