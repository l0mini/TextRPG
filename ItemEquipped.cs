﻿namespace TextRPG
{
    class ItemEquipped
    {
        public Inventory inventory;
        public Player player;
        
        public ItemEquipped(Player player, Inventory inventory)
        {
            this.player = player;
            this.inventory = inventory;
        }
        public Place EqualsScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();

                if (inventory.AllItems.Count == 0)
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < inventory.AllItems.Count; i++)
                    {
                        Console.WriteLine($"{i+1}{inventory.AllItems[i].itemPro.ToInventoryString()}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                        return Place.Inventory;

                    int index = input - 1;
                    if (index >= 0 && index < inventory.AllItems.Count)
                    {
                        var selectedItem = inventory.AllItems[index];
                        if (selectedItem.itemPro.IsEquipped)
                        {
                            Console.WriteLine("이미 장착한 아이템입니다.");
                            Thread.Sleep(1000);
                        }
                        else { 
                        foreach (var item in inventory.AllItems)
                        {
                            if (item.itemPro.IsArmor && selectedItem.itemPro.IsArmor)
                                item.itemPro.IsEquipped = false;
                            if (item.itemPro.IsWeapon && selectedItem.itemPro.IsWeapon)
                                item.itemPro.IsEquipped = false;
                        }


                        selectedItem.itemPro.IsEquipped = true;
                        player.UpdateStatsFromInventory(inventory.AllItems);
                        Console.WriteLine($"'{selectedItem.itemPro.ItemName}'를 장착했습니다!");
                        Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다!");
                        Thread.Sleep(1000);
                    }
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}

