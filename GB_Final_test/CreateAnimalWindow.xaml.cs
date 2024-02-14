using GB_Final_test.animals;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GB_Final_test.functions;
using System.Text.RegularExpressions;
using GB_Final_test.data;
using System.Windows.Documents;
using Microsoft.VisualBasic;

namespace GB_Final_test
{
    /// <summary>
    /// Логика взаимодействия для CreateAnimalWindow.xaml
    /// </summary>
    public partial class CreateAnimalWindow : Window
    {
        static List<string> animalTypes = new List<string> { "Домашнее животное", "Вьючное животное" };

        static List<string> petAnimalKinds = new List<string> { "Кошка", "Собака", "Хомяк" };
        static List<string> packAnimalKinds = new List<string> { "Лошадь", "Верблюд", "Осёл" };
        static List<string> animalKinds = new List<string>();

        List<string> _Commands;

        private int? IdIfAnimalExist = null;

        ApplicationContext DB;

        public AnimalList AnimalList { get; private set; }

        public CreateAnimalWindow()
        {
            InitializeComponent();

            this.AnimalList = new AnimalList();
        }

        public CreateAnimalWindow(AnimalList animalList, ApplicationContext _db)
        {
            InitializeComponent();

            this.DB = _db;

            this.AnimalList = animalList;

            IdIfAnimalExist = animalList.id;

            cb_AnimalType.ItemsSource = animalTypes;
            cb_AnimalType.SelectedIndex = Initialize_ComboBox(animalList.type, animalTypes);

            animalKinds.AddRange(petAnimalKinds);
            animalKinds.AddRange(packAnimalKinds);
            cb_AnimalKind.ItemsSource = animalKinds;
            cb_AnimalKind.SelectedIndex = Initialize_ComboBox(animalList.kind, animalKinds);

            tb_Name.Text = animalList.name;
            dp_Birthday.Text = animalList.birthday;
            tb_Command.Text = animalList.commands;
            tb_BearingCapacity.Text = animalList.weight.ToString();
            tb_LikeToy.Text = animalList.toy;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this.AnimalList;
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

        private void cb_AnimalTypeLoaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = animalTypes;

            if (combo.SelectedIndex == -1 || combo.SelectedIndex == animalTypes.IndexOf(animalTypes[0]))
            {
                combo.SelectedIndex = 0;
                tb_BearingCapacity.IsEnabled = false;
                tb_LikeToy.IsEnabled = true;

                tb_BearingCapacity.IsEnabled = false;
                tb_LikeToy.IsEnabled = true;
            }
            else
            {
                tb_BearingCapacity.IsEnabled = true;
                tb_LikeToy.IsEnabled = false;
            }
        }

        private void cb_AnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == animalTypes.IndexOf(animalTypes[0]))
            {
                cb_AnimalKind.ItemsSource = petAnimalKinds;

                if (cb_AnimalKind.SelectedIndex == -1)
                {
                    cb_AnimalKind.SelectedIndex = 0;
                    tb_BearingCapacity.IsEnabled = false;
                    tb_BearingCapacity.Text = "0";

                    tb_LikeToy.IsEnabled = true;
                }
            }
            else
            {
                cb_AnimalKind.ItemsSource = packAnimalKinds;

                if (cb_AnimalKind.SelectedIndex == -1)
                {
                    cb_AnimalKind.SelectedIndex = 0;

                    tb_BearingCapacity.IsEnabled = true;

                    tb_LikeToy.IsEnabled = false;
                    tb_LikeToy.Text = string.Empty;
                }
            }
        }

        private void CreateAnimal_Click(object sender, RoutedEventArgs e)
        {
            // Data for checking the correctness of the input
            string _animalType = cb_AnimalType.Text.Trim();
            string _animalKind = cb_AnimalKind.Text.Trim();
            string _animalName = tb_Name.Text.Trim();
            string _animalBirthday = dp_Birthday.Text.Trim();
            string _animalCommands = tb_Command.Text.Trim();
            string _animalBearingCopasity = tb_BearingCapacity.Text.Trim();
            string _animalLikeToys = tb_LikeToy.Text.Trim();

            tb_Name.Background = Brushes.Transparent;
            dp_Birthday.Background = Brushes.Transparent;
            tb_Command.Background = Brushes.Transparent;
            tb_BearingCapacity.Background = Brushes.Transparent;
            tb_LikeToy.Background = Brushes.Transparent;

            if (!Regex.IsMatch(_animalName, @"^[\p{IsCyrillic}\p{P}\p{N}\s]*$") || String.IsNullOrEmpty(_animalName) || Regex.IsMatch(_animalName, @"[\d\s.,-]"))
            {
                tb_Name.Background = Brushes.LightPink;
                tb_Name.ToolTip = new ToolTip
                {
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.Black,
                    Content = "Значение введено некорректно! Используйте только символы Кириллицы!"
                };
            }
            else if (!Regex.IsMatch(_animalBirthday, @"^[\p{IsCyrillic}\p{P}\p{N}\s]*$") || String.IsNullOrEmpty(_animalBirthday))
            {
                dp_Birthday.Background = Brushes.LightPink;
                dp_Birthday.ToolTip = new ToolTip
                {
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.Black,
                    Content = "Значение введено некорректно! Ведите дату в формате: дд.мм.гг"
                };
            }
            else if (!Regex.IsMatch(_animalCommands, @"^[\p{IsCyrillic}\p{P}\p{N}\s]*$") || String.IsNullOrEmpty(_animalCommands))
            {
                tb_Command.Background = Brushes.LightPink;
                tb_Command.ToolTip = new ToolTip
                {
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.Black,
                    Content = "Значение введено некорректно! Используйте только символы Кириллицы, запятую и пробел!"
                };
            }
            else if (cb_AnimalType.SelectedIndex != 0 && (!Regex.IsMatch(_animalBearingCopasity, @"^[0-9,]+$") || String.IsNullOrEmpty(_animalBearingCopasity)))
            {
                tb_BearingCapacity.Background = Brushes.LightPink;
                tb_BearingCapacity.ToolTip = new ToolTip
                {
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.Black,
                    Content = "Значение введено некорректно! Используйте только цифры и запятую!"
                };
            }
            else if (cb_AnimalType.SelectedIndex != 1 && (!Regex.IsMatch(_animalLikeToys, @"^[\p{IsCyrillic}\p{P}\p{N}\s]*$") || String.IsNullOrEmpty(_animalLikeToys)))
            {
                tb_LikeToy.Background = Brushes.LightPink;
                tb_LikeToy.ToolTip = new ToolTip
                {
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.Black,
                    Content = "Значение введено неверно! Используйте только символы Кириллицы, запятую и пробел!"
                };
            }
            else
            {
                tb_Name.Background = Brushes.Transparent;
                dp_Birthday.Background = Brushes.Transparent;
                tb_Command.Background = Brushes.Transparent;
                tb_BearingCapacity.Background = Brushes.Transparent;
                tb_LikeToy.Background = Brushes.Transparent;

                tb_Name.ToolTip = " ";
                dp_Birthday.ToolTip = " ";
                tb_Command.ToolTip = " ";
                tb_BearingCapacity.ToolTip = " ";
                tb_LikeToy.ToolTip = " ";

                // Additional data for creating a animal
                int _animalTypeNum = cb_AnimalType.SelectedIndex;
                int _animalKindNum = cb_AnimalKind.SelectedIndex;
                _Commands = new List<string>(_animalCommands.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));
                double _animalBearingCopasityNum = Convert.ToDouble(tb_BearingCapacity.Text.Replace(".", ","));

                _Commands = new List<string>(_animalCommands.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));


                if (IdIfAnimalExist is null)
                {
                    var resalt = MessageBox.Show($"Вы уверенны что хотите создать это животное?", "Подтвердите своё действие", MessageBoxButton.YesNo);
                    if (resalt == MessageBoxResult.Yes)
                    {
                        AnimalControl animalControl = new AnimalControl();
                        Animal _animal = animalControl.CreateAnimal(_animalTypeNum, _animalKindNum, _animalName, _animalBirthday, _Commands, _animalBearingCopasityNum, _animalLikeToys);

                        this.AnimalList = new AnimalList(_animal);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    var resalt = MessageBox.Show($"Вы уверенны что хотите обновить данные о животном?", "Подтвердите своё действие", MessageBoxButton.YesNo);
                    if (resalt == MessageBoxResult.Yes)
                    {
                        this.AnimalList = DB.AnimalsList.Find(AnimalList.id);

                        if (this.AnimalList != null)
                        {
                            this.AnimalList.type = _animalType;
                            this.AnimalList.kind = _animalKind;
                            this.AnimalList.name = _animalName;
                            this.AnimalList.birthday = _animalBirthday;
                            this.AnimalList.commands = _animalCommands;
                            this.AnimalList.weight = _animalBearingCopasityNum;
                            this.AnimalList.toy = _animalLikeToys;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                this.DialogResult = true;
            }
        }

        private int Initialize_ComboBox(string typeOrKind, List<string> animalTypesOrKinds)
        {
            int index = -1;

            foreach (string item in animalTypesOrKinds)
            {
                if (string.Equals(typeOrKind, item))
                {
                    index = animalTypesOrKinds.IndexOf(item);
                    break;
                }
            }
            return index;
        }
    }
}