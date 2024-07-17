using CultivationGame;
using System.Media;
using RomanNumerals;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static bool UseBorderedIconCB = false;
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
            progressBar1.Maximum = (int)PlayerData.QiRequirement; //think of a way to handle this better later
        }

        private void TickTimer(object sender, EventArgs e)
        {
            label2.Text = "Qi: " + PlayerData.Qi.ToString() + "/" + PlayerData.QiRequirement.ToString() + ", Realm: " + PlayerData.CultivationStage.Item1.Name + " " + RomanNumerals.Convert.ToRomanNumerals(PlayerData.CultivationStage.Item2);
            Func<int, int, int> a = (x, y) => { if (x > y) { return (y); } else { return (x); } }; progressBar1.Value = a((int)PlayerData.Qi, (int)PlayerData.QiRequirement);
            Refresh();
        }

        private void Cultivate_Click(object sender, EventArgs e)
        {
            if (Game.StopCultSignal == true)
            {
                Game.StopCultSignal = false;
                Game.StartCultivating();
                Cultivate.Image = Properties.Resources.cultivation_button_c;

            }
            else
            {
                Game.StopCultSignal = true;
                Game.IsCultivating = false;
                Cultivate.Image = Properties.Resources.cultivation_button_d;
            }



        }
        private void Cultivate_MouseEnter(object sender, EventArgs e)
        {
            Cultivate.Image = Properties.Resources.cultivation_button_h;
        }

        private void Cultivate_MouseLeave(object sender, EventArgs e)
        {
            if (Game.IsCultivating == false)
            {
                Cultivate.Image = Properties.Resources.cultivation_button_d;
            }
            else
            {
                Cultivate.Image = Properties.Resources.cultivation_button_c;
            }
        }

        private async void Breakthrough_Click(object sender, EventArgs e)
        {
            if (PlayerData.Qi > PlayerData.QiRequirement)
            {
                progressBar1.Maximum = 100;
                for (int i = 0; i < 1000; i++)
                {
                    label2.Text = "Breaking through... (" + (i / 10).ToString() + "% complete)";
                    progressBar1.Value = i / 10;
                    await Task.Delay(10);
                }
                progressBar1.Value = (int)PlayerData.Qi;
                progressBar1.Maximum = (int)PlayerData.QiRequirement;
            }
        }




    }
}