using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    class GameManager //관리자
    {
        StartScene startScene;
        RestRoom restScene;
        Player player;
        Shop shop;
        Buy buy;
        Sell sell;
        Inventory inventory;
        ItemEquipped itemEquipped;
        Dungeon dongeon;
        DungeonClear dongeonClear;
        Place currentPlace;
        private ItemPro itemProInstance;

        public GameManager()
        {
            startScene = new StartScene();
            player = new Player();
            shop = new Shop(player);
            inventory = new Inventory(player);
            itemEquipped = new ItemEquipped(player, inventory);
            buy = new Buy(shop.AllItems, player, inventory, itemEquipped);
            sell = new Sell(player, inventory);
            restScene = new RestRoom(player);
            dongeon = new Dungeon(player);
            dongeonClear = new DungeonClear(player, dongeon);
            currentPlace = Place.Start;
        }
        
        public void GameRoof()
        {
            Thread.Sleep(1000);
            while (true)
            {
                switch (currentPlace)
                {
                    case Place.Start:
                        currentPlace = startScene.startScene();
                        break;
                    case Place.Player:
                        currentPlace = player.PlayerInfoScene();
                        break;
                    case Place.Inventory:
                        currentPlace = inventory.InventoryScene();
                        break;
                    case Place.ItemEquipped:
                        currentPlace = itemEquipped.EqualsScene();
                        break;
                    case Place.Shop:
                        currentPlace = shop.ShopScene();
                        break;
                    case Place.Buy:
                        currentPlace = buy.BuyScene();
                        break;
                    case Place.Sell:
                        currentPlace = sell.SellScene();
                        break;
                    case Place.Restroom:
                        currentPlace = restScene.RestScene();
                        break;
                    case Place.Dungeon:
                        currentPlace = dongeon.DungeonScene();
                        break; 
                    case Place.DungeonClear:
                        currentPlace = dongeonClear.DungeonClearScene();
                        break;
                    case Place.Exit:
                        Thread.Sleep(1000);
                        Console.WriteLine("게임을 종료합니다.");
                        Thread.Sleep(1000);
                        return;
                }
            }

        }
    }
}

