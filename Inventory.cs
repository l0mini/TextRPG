using System.Text.Json.Serialization;

namespace TextRPG
{
    public class Inventory//인벤토리
    {
        public List<Item> AllItems;

        private Player player;

        public Inventory(Player player)
        {
            this.player = player;
            this.AllItems = new List<Item>();
        }

        public Place InventoryScene()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            if (AllItems.Count == 0)
            {
                Console.WriteLine(" 보유한 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < AllItems.Count; i++)
                {
                    Console.WriteLine(AllItems[i].itemPro.ToInventoryString());
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
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
                    return Place.Inventory;
                }
            }

            switch (choice)
            {
                case 1:
                    return Place.ItemEquipped;
                case 0:
                    return Place.Start;
                default:
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Inventory;


            }
        }
    }
}

