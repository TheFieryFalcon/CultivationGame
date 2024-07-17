using CultivationGame;
using System.Media;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(TickTimer);
            timer.Start();
        }

        private void TickTimer(object sender, EventArgs e)
        {
            label2.Text = "Qi: " + PlayerData.Qi.ToString() + "/" + PlayerData.QiRequirement.ToString();
            Refresh();
        }

        private void Cultivate_Click(object sender, EventArgs e)
        {
            if (Game.StopCultSignal == true)
            {
                Game.StopCultSignal = false;
                Game.StartCultivating();
                
            }
            else
            {
                Game.StopCultSignal = true;
            }

            

        }
        private void Cultivate_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Cultivate_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Breakthrough_Click(object sender, EventArgs e)
        {

        }




    }
}