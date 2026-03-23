using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroscopeSliderWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int zoom = 6;
        public int Zoom
        {
            get => zoom;
            set
            {
                if (zoom != value && value >= 0 && value <= 15)
                {
                    zoom = value;
                    OnPropertyChanged(nameof(Zoom));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ButtonZoomUp_Click(object sender, RoutedEventArgs e)
        {
            MicroSlider.Value++;
        }

        private void ButtonZoomDown_Click(object sender, RoutedEventArgs e)
        {
            MicroSlider.Value--;
        }
    }
}