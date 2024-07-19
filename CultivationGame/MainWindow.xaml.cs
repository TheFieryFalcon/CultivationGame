using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
        public ImageBrush brusha = new();
        public ImageBrush brushb = new();
        public bool SuspendUpdates = false;
        public MainWindow()
        {
            InitializeComponent();
            UpdateGame();
            QiProgress.Maximum = PlayerData.QiRequirement;

        }

        private void Cultivation_Click(object sender, EventArgs e)
        {
            
            if (Game.StopCultSignal == true)
            {
                brusha.ImageSource = new BitmapImage(new Uri(@"assets\icons\cultivation_button_c.png", UriKind.Relative));
                Game.StopCultSignal = false;
                Game.StartCultivating();
                Cultivate.Background = brusha;
                

            }
            else
            {
                brusha.ImageSource = new BitmapImage(new Uri(@"assets\icons\cultivation_button.png", UriKind.Relative));
                Game.StopCultSignal = true;
                Game.IsCultivating = false;
                Cultivate.Background = brusha;
            }



        }
        private async Task BreakthroughFunc()
        {
            SuspendUpdates = true;
            brushb.ImageSource = new BitmapImage(new Uri(@"assets\icons\breakthrough_button_c.png", UriKind.Relative));
            Breakthrough.Background = brushb;
            QiProgress.Maximum = 100;
            for (int i = 0; i < 1000; i++)
            {
                QPLabel.Content = "Breaking through... (" + (i / 10).ToString() + "% complete)";
                QiProgress.Value = i / 10;
                await Task.Delay(10);
            }
            QiProgress.Value = PlayerData.Qi;
            QiProgress.Maximum = PlayerData.QiRequirement;
            brushb.ImageSource = new BitmapImage(new Uri(@"assets\icons\breakthrough_button.png", UriKind.Relative));
            Breakthrough.Background = brushb;


        }

        private async void Breakthrough_Click(object sender, RoutedEventArgs e)
        {

            if (PlayerData.Qi > PlayerData.QiRequirement && SuspendUpdates == false)
            {
                int OldMinorRealm = PlayerData.CultivationStage.Item2;
                await BreakthroughFunc();
                if (PlayerData.CultivationStage.Item1.Stages == PlayerData.CultivationStage.Item2)
                {
                    Type GreatRealmType = typeof(CultivationLevels);
                    PlayerData.CultivationStage.Item1 = (CultivationLevel)GreatRealmType.GetField(PlayerData.CultivationStage.Item1.NextStage).GetValue(null);
                    //placeholder, todo later
                    
                    QPLabel.Content = "Congratulations! You have successfully broken through to the " + PlayerData.CultivationStage.Item1.Name + " Great Realm!";
                    //some special effect or something for every realm, get darko to be average japanese animator (slave)
                    await Task.Delay(2000);
                    SuspendUpdates = false;
                }
                else
                {
                    PlayerData.CultivationStage.Item2 = OldMinorRealm + 1;
                    SuspendUpdates = false;
                }


            }

        }

        private async Task UpdateGame()
        {
            if (SuspendUpdates == false)
            { 
                QPLabel.Content = "Qi: " + PlayerData.Qi.ToString() + "/" + PlayerData.QiRequirement.ToString() + ", Realm: " + PlayerData.CultivationStage.Item1.Name + " " + PlayerData.CultivationStage.Item2;
                Func<int, int, int> a = (x, y) => { if (x > y) { return (y); } else { return (x); } }; QiProgress.Value = a((int)PlayerData.Qi, (int)PlayerData.QiRequirement);
                 
            }
            await Task.Delay(100);
            UpdateGame(); //fuck it we ball, if this causes problems later future me can cope and seethe

        }
    }
}
