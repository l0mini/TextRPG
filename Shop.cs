using System.Text.Json.Serialization;

namespace TextRPG
{
    public class Shop//상점
    {
        public List<Item> AllItems;

        Player player;

        public Shop(Player player)
        {
            this.player = player;
            AllItems = new List<Item>();

            AllItems.Add(new Item(Item.BeginnerArmor()));
            AllItems.Add(new Item(Item.IronArmor()));
            AllItems.Add(new Item(Item.SpartaArmor()));
            AllItems.Add(new Item(Item.Sparta300Armor()));
            AllItems.Add(new Item(Item.ArmorOfSpartacus()));
            AllItems.Add(new Item(Item.OldSword()));
            AllItems.Add(new Item(Item.BronzeAx()));
            AllItems.Add(new Item(Item.SpartaSphere()));
            AllItems.Add(new Item(Item.Sparta300Sphere()));
            AllItems.Add(new Item(Item.SphereOfSpartacus()));
        }

        public Place ShopScene()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.haveGold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (var Item in AllItems)
            {
                Console.WriteLine(Item);
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int choice;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Shop;
                }
            }
            if (choice == 1)
            {
                return Place.Buy;
            }
            else if (choice == 0)
            {
                return Place.Start;
            }
            else if(choice == 2)
            {
                return Place.Sell;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                return Place.Shop;
            }
        }
    } 
}

