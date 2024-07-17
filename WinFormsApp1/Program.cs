using Enums;
using WinFormsApp1;
using Library;
using System.Timers;

namespace CultivationGame
{
    public record CultivationLevel(string Name, uint Stages, Tuple<Item, int>? BreakthroughRequirement, long BaseQiRequirement, int FailChance, int? RollRangeMax, string Description);
    public record Herb(Item Item, string Name, Location Location, Grade Grade, int Rarity, int SkillRequired, string Description);
    public record Pill(Item Item, string Name, Grade Grade, int SkillRequired, CultivationLevel CultivationLvlRequired, int FailChance, Grade FurnaceRequired, string Description);
    public static class CultivationLevels
    {
        public static CultivationLevel MortalRealm = new("Mortal", 5, (Item.QiCondensationPill, 1).ToTuple(), 10, 1, null, "The first realm (PLACEHOLDER)");
        public static CultivationLevel QiCondensationRealm = new("Mortal", 5, (Item.FoundationBuildingPill, 2).ToTuple(), 800, 5, null, "The second realm (PLACEHOLDER)");
    }
    public static class Herbs
    {
        public static Herb SpiritGinseng = new(Item.SpiritGinseng, "Spirit Ginseng", Location.Swamp, Grade.Mortal, 8000, 0, "Found in the Swamp. \n Mortal Grade \n Legend has it that blah blah blah (PLACEHOLDER)");
        public static Herb HeartLotus = new(Item.HeartLotus, "Heart Lotus", Location.Swamp, Grade.Mortal, 2000, 0, "Found in the Swamp. \n Mortal Grade \n Legend has it that blah blah blah (PLACEHOLDER)");
    }
    public static class Pills
    {
        public static Pill QiCondensationPill = new(Item.QiCondensationPill, "Qi Condensation Pill", Grade.Mortal, 0, CultivationLevels.MortalRealm, 1000, Grade.Mortal, "Pill required to ascend to the Qi Condensation Realm (PLACEHOLDER)");
    }

    public class PlayerData
    {
        //change when saving is implemented
        static public (CultivationLevel, int) CultivationStage = (CultivationLevels.MortalRealm, 1);
        static public long Qi = 0;
        static public long QiGatheringRate = 1;
        static public long QiRequirement = (long)(0.5 * Math.Pow(CultivationStage.Item1.BaseQiRequirement * CultivationStage.Item2, 1.4) + 100);
    }
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public class Game
    {

        public static bool IsCultivating = false; //only here because I get really confused with the 
        public static bool StopCultSignal = true;
        public static System.Timers.Timer timer = new System.Timers.Timer(200);
        

        public static void StartCultivating()
        {
            if (StopCultSignal == false)
            {
                IsCultivating = true;
                PlayerData.Qi = PlayerData.QiGatheringRate + PlayerData.Qi;
                timer.Elapsed += OnTimerElapsed;
                timer.AutoReset = true;
                timer.Enabled = true;
                
            }
            else
            {
                IsCultivating = false;
            }

        }
        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            StartCultivating();
            
        }
    }
}
