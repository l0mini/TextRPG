using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextRPG
{
    internal class Save
    {
        private static string saveFile = "save.json";

        public static void SaveData(Player player)
        {
            string json = JsonConvert.SerializeObject(player, Formatting.Indented);
            File.WriteAllText(saveFile, json);
            Console.WriteLine("잠시 쉬어야겠어");
        }

        public static GameData Load()
        {
            if (File.Exists(saveFile))
            {
                string json = File.ReadAllText(saveFile);
                GameData gameData = JsonConvert.DeserializeObject<GameData>(json);
                Console.WriteLine("전장으로 돌아가자");
                return gameData;
                   
            }
            else
            {
                Console.WriteLine("스파르타에 온 것을 환영하네!");
                return CreateNewCharacter();
            }
        }

        private static GameData CreateNewCharacter()
        {
            return new GameData();
           
        }
    }
}

