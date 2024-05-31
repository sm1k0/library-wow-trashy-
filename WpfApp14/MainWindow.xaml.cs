using SerializationLibrary;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;

namespace WpfAppWithLibraries
{
    public partial class MainWindow : Window
    {
        private Serializer _serializer;

        public MainWindow()
        {
            InitializeComponent();
            _serializer = new Serializer();
        }

        private async void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            var data = new { Name = "Test", Age = 30 };
            await _serializer.SerializeAsync(data, "data.json");
            MessageBox.Show("Data serialized");
        }

        private async void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.json"))
            {
                var data = await _serializer.DeserializeAsync<dynamic>("data.json");
                MessageBox.Show($"Name: {data.Name}, Age: {data.Age}");
            }
            else
            {
                MessageBox.Show("No data file found");
            }
        }

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var theme = button?.Content.ToString();

            if (theme == "Light")
            {
                Application.Current.Resources.MergedDictionaries[0] =
                    new ResourceDictionary { Source = new Uri("pack://application:,,,/ThemesLibrary;component/Themes/LightTheme.xaml") };
            }
            else if (theme == "Dark")
            {
                Application.Current.Resources.MergedDictionaries[0] =
                    new ResourceDictionary { Source = new Uri("pack://application:,,,/ThemesLibrary;component/Themes/DarkTheme.xaml") };
            }
        }
    }
}
