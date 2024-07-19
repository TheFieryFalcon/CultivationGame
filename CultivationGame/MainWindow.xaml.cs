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

namespace CultivationGame
{
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
                brush.ImageSource = new BitmapImage(new Uri(@"assets\icons\breakthrough_button_c.png", UriKind.Relative));
                Game.StopCultSignal = false;
                Game.StartCultivating();
                Cultivate_Button.Background = brush;
                
            }
            else
            {
                brush.ImageSource = new BitmapImage(new Uri(@"assets\icons\breakthrough_button.png", UriKind.Relative));
                Game.StopCultSignal = true;
                Game.IsCultivating = false;
                Cultivate_Button.Background = brush;
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
