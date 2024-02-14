using GB_Final_test.animals;
using GB_Final_test.data;
using GB_Final_test.functions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GB_Final_test
{
    /// <summary>
    /// Логика взаимодействия для WindowDB.xaml
    /// </summary>
    public partial class WindowDB : Window
    {
        ApplicationContext DB;

        List<AnimalList> AnimalsList;
        ObservableCollection<AnimalList> NewAnimalsList;

        public WindowDB()
        {
            InitializeComponent();
            DB = new ApplicationContext();
            AnimalsList = DB.AnimalsList.ToList();

            NewAnimalsList = new ObservableCollection<AnimalList>(AnimalsList);
            DataList.ItemsSource = NewAnimalsList;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataList.DataContext = DataContext;
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
            Close();
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {

            AnimalList? _animalList = DataList.SelectedItem as AnimalList; // получаем выделенный объект

            if (_animalList is null)
            {
                MessageBox.Show($"Ни один объект не выбран!");
                return;
            }
            else
            {
                var resalt = MessageBox.Show($"Вы уверенны что хотите обновить данные этого животного?", "Подтвердите своё действие", MessageBoxButton.YesNo);
                if (resalt == MessageBoxResult.Yes)
                {
                    CreateAnimalWindow createAnimalWindow = new CreateAnimalWindow(_animalList, DB);
                    createAnimalWindow.Owner = this;
                    createAnimalWindow.ShowDialog();

                    if (createAnimalWindow.DialogResult == true)
                    {
                        DB.SaveChanges();
                        DataList.Items.Refresh();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalList? _animalList = DataList.SelectedItem as AnimalList; // получаем выделенный объект

            if (_animalList is null)
            {
                MessageBox.Show($"Ни один объект не выбран!");
                return;
            }
            else
            {
                var resalt = MessageBox.Show($"Вы уверенны что хотите удалить данные об этом животном?", "Подтвердите своё действие", MessageBoxButton.YesNo);
                if (resalt == MessageBoxResult.Yes)
                {
                    DB.AnimalsList.Remove(_animalList);
                    DB.SaveChanges();

                    NewAnimalsList = new ObservableCollection<AnimalList>(DB.AnimalsList.ToList());
                    DataList.ItemsSource = NewAnimalsList;
                }
                else
                {
                    return;
                }
            }
        }

        private void TrainAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalList? _animalList = DataList.SelectedItem as AnimalList; // получаем выделенный объект

            if (_animalList is null)
            {
                MessageBox.Show($"Ни один объект не выбран!");
                return;
            }
            else
            {
                var resalt = MessageBox.Show($"Вы обучить это животне новым командам?", "Подтвердите своё действие", MessageBoxButton.YesNo);
                if (resalt == MessageBoxResult.Yes)
                {
                    DB.AnimalsList.Remove(_animalList);
                    DB.SaveChanges();

                    NewAnimalsList = new ObservableCollection<AnimalList>(DB.AnimalsList.ToList());
                    DataList.ItemsSource = NewAnimalsList;
                }
                else
                {
                    return;
                }
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
