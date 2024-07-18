using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CultivationGame
{
    public class MultiplyConverter : IMultiValueConverter //literally just stolen from stackoverflow, god I fucking hate XAML
    {
        public object Convert(object[] values, Type targetType,
               object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                    result *= (double)values[i];
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ImageBrush brush = new();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Cultivation_Click(object sender, EventArgs e)
        {
            
            if (Game.StopCultSignal == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(@"assets\icons\cultivation_button_c.png", UriKind.Relative));
                Game.StopCultSignal = false;
                Game.StartCultivating();
                Cultivate.Background = brush;
                

            }
            else
            {
                brush.ImageSource = new BitmapImage(new Uri(@"assets\icons\cultivation_button.png", UriKind.Relative));
                Game.StopCultSignal = true;
                Game.IsCultivating = false;
                Cultivate.Background = brush;
            }



        }

        private void Breakthrough_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task UpdateGame()
        {

        }
    }
}
