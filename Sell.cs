namespace TextRPG
{
    class Sell//판매 상점
    {

        public Inventory inventory;
        public Player player;

        public Sell(Player player, Inventory inventory)
        {

            this.player = player;
            this.inventory = inventory;
        }
        public Place SellScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 팔 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.haveGold}G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < inventory.AllItems.Count; i++)//아이템의 배열을 위부터 반복해 출력
                {
                    Console.WriteLine($"{i + 1}{inventory.AllItems[i].itemPro.ToSellString()}");
                }
                Console.WriteLine();
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
                        return Place.Sell;
                    }
                }
                if (choice == 0) return Place.Shop;

                int index = choice - 1;
                
                

                if (index >= 0 && index < inventory.AllItems.Count)
                {
                    var selectedItem = inventory.AllItems[index];
                    
                    if (selectedItem.itemPro.IsSold)
                    {
                        player.haveGold += selectedItem.itemPro.ItemValue*17/20;
                        selectedItem.itemPro.IsSold = false;
                        
                        if (selectedItem.itemPro.IsEquipped)
                        {
                            selectedItem.itemPro.IsEquipped = false;
                            if (selectedItem.itemPro.IsWeapon)
                                player.WeaponPower -= selectedItem.itemPro.ItemStat;
                            if (selectedItem.itemPro.IsArmor)
                                player.ArmorPower -= selectedItem.itemPro.ItemStat;
                        }
                        inventory.AllItems.Remove(selectedItem);

                       
                        Console.WriteLine("판매 완료!");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                    return Place.Sell;
                }
            }
        }
    }
}

