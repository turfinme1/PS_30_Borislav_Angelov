using StudentInfoSystem.Enums;
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
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentInfoContext context;

        public Student? Student { get; set; }

        public List<string>? StudStatusChoices { get; set; } = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;
            context = new StudentInfoContext();

            bool result = TestStudentsIfEmpty();

            if (result)
            {
                CopyTestStudents();
            }

            txtStatus.ItemsSource = StudStatusChoices;  
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
        }

        private void btnPopulateModel_Click(object sender, RoutedEventArgs e)
        {
            PopulateForm();
        }

        private void btnDeactivateControls_Click(object sender, RoutedEventArgs e)
        {
            DeactivateControls();
        }

        private void btnActivateControls_Click(object sender, RoutedEventArgs e)
        {
            ActivateControls();
        }

        private void btnEnterUser_Click(object sender, RoutedEventArgs e)
        {
            EnterUser();
        }

        private void ClearForms()
        {
            foreach (var item in PersonalData.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }

            foreach (var item in StudentInformation.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
        }

        private void PopulateForm()
        {
            StudentData studentData = new StudentData();
            Student = studentData.TestStudents?.FirstOrDefault();

            foreach (var item in PersonalData.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Name.Equals("txtFirstName"))
                    {
                        ((TextBox)item).Text = Student?.FirstName;
                    }
                    else if (((TextBox)item).Name.Equals("txtMiddleName"))
                    {
                        ((TextBox)item).Text = Student?.MiddleName;
                    }
                    else if (((TextBox)item).Name.Equals("txtLastName"))
                    {
                        ((TextBox)item).Text = Student?.LastName;
                    }
                }
            }

            foreach (var item in StudentInformation.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Name.Equals("txtFaculty"))
                    {
                        ((TextBox)item).Text = Student?.Faculty;
                    }
                    else if (((TextBox)item).Name.Equals("txtSpeciality"))
                    {
                        ((TextBox)item).Text = Student?.Speciality;
                    }
                    else if (((TextBox)item).Name.Equals("txtDegree"))
                    {
                        ((TextBox)item).Text = Student?.Degree.ToString();
                    }
                    else if (((TextBox)item).Name.Equals("txtFacultyNumber"))
                    {
                        ((TextBox)item).Text = Student?.FacultyNumber;
                    }
                    else if (((TextBox)item).Name.Equals("txtStatus"))
                    {
                        ((TextBox)item).Text = Student?.Status.ToString();
                    }
                    else if (((TextBox)item).Name.Equals("txtCourse"))
                    {
                        ((TextBox)item).Text = Student?.Course.ToString();
                    }
                    else if (((TextBox)item).Name.Equals("txtStream"))
                    {
                        ((TextBox)item).Text = Student?.Stream.ToString();
                    }
                    else if (((TextBox)item).Name.Equals("txtGroup"))
                    {
                        ((TextBox)item).Text = Student?.Group.ToString();
                    }
                }
            }
        }

        private void DeactivateControls()
        {
            foreach (var item in PersonalData.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }

            foreach (var item in StudentInformation.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void ActivateControls()
        {
            foreach (var item in PersonalData.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }

            foreach (var item in StudentInformation.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void EnterUser()
        {
            StudentData studentData = new StudentData();
            Student = new Student();

            foreach (var item in PersonalData.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Name.Equals("txtFirstName"))
                    {
                        Student.FirstName = ((TextBox)item).Text;
                    }
                    else if (((TextBox)item).Name.Equals("txtMiddleName"))
                    {
                        Student.MiddleName = ((TextBox)item).Text;
                    }
                    else if (((TextBox)item).Name.Equals("txtLastName"))
                    {
                        Student.LastName = ((TextBox)item).Text;
                    }
                }
            }

            foreach (var item in StudentInformation.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Name.Equals("txtFaculty"))
                    {
                        Student.Faculty = ((TextBox)item).Text;
                    }
                    else if (((TextBox)item).Name.Equals("txtSpeciality"))
                    {
                        Student.Speciality = ((TextBox)item).Text;
                    }
                    else if (((TextBox)item).Name.Equals("txtDegree"))
                    {
                        Degree degree;

                        if (Enum.TryParse(((TextBox)item).Text, out degree))
                        {
                            Student.Degree = degree;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                    else if (((TextBox)item).Name.Equals("txtFacultyNumber"))
                    {
                        Student.FacultyNumber = ((TextBox)item).Text;
                    }
                    else if (((TextBox)item).Name.Equals("txtStatus"))
                    {
                        EducationStatus status;

                        if (Enum.TryParse(((TextBox)item).Text, out status))
                        {
                            Student.Status = status;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                    else if (((TextBox)item).Name.Equals("txtCourse"))
                    {
                        int result;

                        if (int.TryParse(((TextBox)item).Text, out result))
                        {
                            Student.Course = result;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                    else if (((TextBox)item).Name.Equals("txtStream"))
                    {
                        int result;

                        if (int.TryParse(((TextBox)item).Text, out result))
                        {
                            Student.Stream = result;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                    else if (((TextBox)item).Name.Equals("txtGroup"))
                    {
                        int result;

                        if (int.TryParse(((TextBox)item).Text, out result))
                        {
                            Student.Group = result;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                }

                if (item is ListBox)
                {
                    if (((ListBox)item).Name.Equals("txtStatus"))
                    {
                        EducationStatus status;

                        if (Enum.TryParse(((ListBox)item).SelectedItem.ToString(), out status))
                        {
                            Student.Status = status;
                        }
                        else
                        {
                            DeactivateControls();
                            return;
                        }
                    }
                }
            }

            context.Students.Add(Student);
            context.SaveChanges();
            StudentInfoList studentInfo = new StudentInfoList();
            studentInfo.ShowDialog();
        }

        private void FillStudStatusChoices()
        {
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();

                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices?.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;

            int countStudents = queryStudents.Count();

            return countStudents == 0;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData data = new StudentData();

            foreach (Student st in data.TestStudents)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }
    }
}
