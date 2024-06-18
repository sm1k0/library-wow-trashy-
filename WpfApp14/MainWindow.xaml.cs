using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SerializationLibrary1;  

namespace WpfApp14
{
    public partial class MainWindow : Window
    {
        private Serializer _serializer;

        public MainWindow()
        {
            InitializeComponent();
            _serializer = new Serializer();
        }

    }
}
