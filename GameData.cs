using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class GameData
    {
        public Player player { get; set; }
        public Inventory inventory { get; set; }
        public Shop shop { get; set; } // 예: 상점 품목, 판매 상태 등
        public DateTime lastSaveTime { get; set; }
        public GameData()
        {
            player = new Player();
            inventory = new Inventory(player);
            shop = new Shop(player);
            lastSaveTime = DateTime.Now;
        }
    }
}
