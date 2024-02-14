using GB_Final_test.animals;
using GB_Final_test.data;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;

namespace GB_Final_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Animal> _Animals { get; set; }

        ApplicationContext DB;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;

            DB = new ApplicationContext();

            _Animals = new List<Animal>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB.Database.EnsureCreated();
            DB.AnimalsList.Load();
            DataContext = DB.AnimalsList.Local.ToObservableCollection();
        }

        private void Window_MouseLeftBUttonDown(object sender, MouseEventArgs e)
        {
            DragMove();
        }

        private void btn_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Maximize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private void btn_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreateAnimal_Click(object sender, RoutedEventArgs e)
        {
            CreateAnimalWindow createAnimalWindow = new CreateAnimalWindow();

            createAnimalWindow.Owner = this;
            createAnimalWindow.ShowDialog();

            if (createAnimalWindow.DialogResult == true)
            {
                AnimalList animalList = createAnimalWindow.AnimalList;
                DB.AnimalsList.Add(animalList);
                DB.SaveChanges();
            }
        }

        private void AllAnimalsData_Click(object sender, RoutedEventArgs e)
        {
            WindowDB windowDB = new WindowDB();

            windowDB.Owner = this;
            windowDB.ShowDialog();
        }
    }
}